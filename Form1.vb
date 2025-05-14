Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.IO

Public Class Form1

    Dim oAppSetting As New AppSetting()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbImageSize.SelectedIndex = 0

        oAppSetting.LoadData()
        txtApiKey.Text = oAppSetting.GetValue("ApiKey")
        txtPrompt.Text = oAppSetting.GetValue("Prompt")
        txtInputFile.Text = CheckFile(oAppSetting.GetValue("InputFile"))
        txtMaskFile.Text = CheckFile(oAppSetting.GetValue("MaskFile"))
        txtOutputFile.Text = CheckFile(oAppSetting.GetValue("OutputFile"))
        SetComboBox(cbImageSize, oAppSetting.GetValue("ImageSize"))

        If txtApiKey.Text <> "" Then
            txtApiKey.PasswordChar = "*"
        End If

        SetPictureBox(pbInput, txtInputFile.Text)
        SetPictureBox(pbMask, txtMaskFile.Text)
        SetPictureBox(pbOuput, txtOutputFile.Text)

    End Sub


    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        oAppSetting.SetValue("ApiKey", txtApiKey.Text)
        oAppSetting.SetValue("Prompt", txtPrompt.Text)
        oAppSetting.SetValue("InputFile", txtInputFile.Text)
        oAppSetting.SetValue("MaskFile", txtMaskFile.Text)
        oAppSetting.SetValue("OutputFile", txtOutputFile.Text)
        oAppSetting.SetValue("ImageSize", GetComboBoxVal(cbImageSize, "256"))
        oAppSetting.SaveData()
    End Sub

    Private Function CheckFile(sFilePath As String) As String
        If IO.File.Exists(sFilePath) Then
            Return sFilePath
        Else
            Return ""
        End If
    End Function

    Private Sub SetPictureBox(oPictureBox As PictureBox, sFilePath As String)
        If sFilePath = "" Then
            Exit Sub
        End If

        Dim oImage As Image = Image.FromFile(sFilePath)
        oPictureBox.SizeMode = PictureBoxSizeMode.StretchImage
            oPictureBox.Image = oImage
        ' End Using

    End Sub

    Private Function GetComboBoxVal(ByRef oComboBox As ComboBox, sDefaultValue As String) As String
        If oComboBox.SelectedIndex = -1 Then
            Return sDefaultValue
        End If

        Return oComboBox.Items(oComboBox.SelectedIndex)
    End Function

    Private Sub SetComboBox(ByRef oComboBox As ComboBox, sValue As String)
        For i As Integer = 0 To oComboBox.Items.Count - 1
            If oComboBox.Items(i) = sValue Then
                oComboBox.SelectedIndex = i
                Exit Sub
            End If
        Next
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        'https://platform.openai.com/docs/guides/images/usage?lang=curl
        'https://platform.openai.com/docs/api-reference/images/create
        Dim url As String = "https://api.openai.com/v1/images/edits"

        Dim authToken As String = txtApiKey.Text
        If authToken = "" Then
            MsgBox("auth Token Missing")
            Exit Sub
        End If

        Dim sPrompt As String : sPrompt = txtPrompt.Text
        If sPrompt = "" Then
            MsgBox("Missing Prompt")
            Exit Sub
        End If

        Dim sFilePath As String = txtInputFile.Text
        If sFilePath = "" Then
            MsgBox("Missing image file")
            Exit Sub
        End If

        Dim sMaskPath As String = txtMaskFile.Text
        If sMaskPath = "" Then
            MsgBox("Missing mask file")
            Exit Sub
        End If

        'Must be one of 256x256, 512x512, or 1024x1024 for dall-e-2
        Const sModel = "dall-e-2"
        Dim sImageSize = "256x256"
        Select Case cbImageSize.SelectedIndex
            Case 0 : sImageSize = "256x256"
            Case 1 : sImageSize = "512x512"
            Case 2 : sImageSize = "1024x1024"
        End Select

        Dim data As New Hashtable()
        data("model") = sModel
        data("prompt") = sPrompt
        data("n") = 1 ' only n=1 is supported.
        data("size") = sImageSize
        data("image") = "@" & sFilePath
        data("mask") = "@" & sMaskPath

        Dim sJson As String = ""

        Try
            pbOuput.Image = Nothing
            lblMsg.Text = "Loading..."
            txtOutputFile.Text = ""
            Application.DoEvents()
            sJson = SendMultipartHttpRequest(url, authToken, data)
            lblMsg.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        Dim sImageUrl As String = ""
        Try
            Dim oJavaScriptSerializer As New System.Web.Script.Serialization.JavaScriptSerializer
            Dim oJson As Hashtable = oJavaScriptSerializer.Deserialize(Of Hashtable)(sJson)
            sImageUrl = oJson("data")(0)("url")
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        ' Generate output path
        Dim directory As String = Path.GetDirectoryName(sFilePath)
        Dim fileName As String = Path.GetFileNameWithoutExtension(sFilePath)
        Dim sOutputPath As String = Path.Combine(directory, fileName & "_output.png")

        For i As Integer = 1 To 1000
            If IO.File.Exists(sOutputPath) = False Then
                Exit For
            End If

            sOutputPath = Path.Combine(directory, fileName & "_output" & i & ".png")
        Next

        If IO.File.Exists(sOutputPath) Then
            Dim oGuid As Guid = Guid.NewGuid()
            Dim sGuid As String = Replace(Replace(oGuid.ToString(), "{", ""), "}", "")
            sOutputPath = Path.Combine(directory, fileName & "_output_" & sGuid & ".png")
        End If

        Using client As New System.Net.WebClient()
            client.DownloadFile(sImageUrl, sOutputPath)
            txtOutputFile.Text = sOutputPath
            pbOuput.Image = Image.FromFile(sOutputPath)
            pbOuput.SizeMode = PictureBoxSizeMode.StretchImage
        End Using

    End Sub

    Private Sub btnOutput_Click(sender As Object, e As EventArgs) Handles btnOutput.Click
        'Process.Start(New ProcessStartInfo(txtOutputFile.Text) With {.UseShellExecute = True})

        OpenFileDialog1.FileName = txtOutputFile.Text
        OpenFileDialog1.Title = "Open Image File"
        OpenFileDialog1.Filter = "Image files|*.png"
        OpenFileDialog1.ShowDialog()

        If OpenFileDialog1.FileName <> "" Then
            txtOutputFile.Text = OpenFileDialog1.FileName
            Dim oImage = Image.FromFile(txtOutputFile.Text)
            pbOuput.Image = oImage
            pbOuput.SizeMode = PictureBoxSizeMode.StretchImage
        End If
    End Sub

    Public Function SendMultipartHttpRequest(url As String, authToken As String, parameters As Hashtable) As String
        Using client As New HttpClient()
            Using content As New MultipartFormDataContent()

                ' Add form fields
                For Each oEntry As DictionaryEntry In parameters
                    If oEntry.Value.ToString().StartsWith("@") Then
                        Dim filePath As String = oEntry.Value.ToString().Substring(1)
                        If File.Exists(filePath) Then
                            Dim fileContent As ByteArrayContent = New ByteArrayContent(File.ReadAllBytes(filePath))
                            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(GetFileContentType(filePath))
                            content.Add(fileContent, oEntry.Key.ToString(), Path.GetFileName(filePath))
                        Else
                            Throw New FileNotFoundException("File not found: " & filePath)
                        End If
                    Else
                        content.Add(New StringContent(oEntry.Value.ToString()), oEntry.Key.ToString())
                    End If
                Next

                client.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", authToken)
                Dim response As HttpResponseMessage = client.PostAsync(url, content).Result
                If Not response.IsSuccessStatusCode Then
                    Dim errorContent As String = response.Content.ReadAsStringAsync().Result
                    Throw New HttpRequestException($"Error: {response.StatusCode} - {errorContent}")
                End If
                Return response.Content.ReadAsStringAsync().Result
            End Using
        End Using
    End Function

    Private Function GetFileContentType(filePath As String) As String
        Dim ext As String = Path.GetExtension(filePath).ToLower()

        Select Case ext
            Case ".jpg", ".jpeg"
                Return "image/jpeg"
            Case ".png"
                Return "image/png"
            Case Else
                Return "application/octet-stream"
        End Select
    End Function

    Private Sub btnFile_Click(sender As Object, e As EventArgs) Handles btnFile.Click
        OpenFileDialog1.FileName = txtInputFile.Text
        OpenFileDialog1.Title = "Open Image File"
        OpenFileDialog1.Filter = "PNG files (*.png)|*.png|" &
                         "JPEG files (*.jpg; *.jpeg)|*.jpg; *.jpeg|" &
                         "GIF files (*.gif)|*.gif|" &
                         "BMP files (*.bmp)|*.bmp|" &
                         "TIFF files (*.tiff; *.tif)|*.tiff; *.tif|" &
                         "WebP files (*.webp)|*.webp|" &
                         "All Image files|*.jpg; *.jpeg; *.png; *.gif; *.bmp; *.tiff; *.tif; *.webp|" &
                         "All files (*.*)|*.*"
        OpenFileDialog1.ShowDialog()

        Dim sFilePath As String = OpenFileDialog1.FileName
        If sFilePath <> "" Then
            Dim oImage = Image.FromFile(sFilePath)
            Dim sExt As String = Path.GetExtension(sFilePath)
            Dim sImageProblems As String = ""

            If sExt <> ".png" Then
                sImageProblems = "Only PNG images are supported."
            End If

            If oImage.Width <> oImage.Height Then
                sImageProblems += " Only square images are supported."
            End If

            Select Case oImage.Width
                Case 256 : cbImageSize.SelectedIndex = 0
                Case 512 : cbImageSize.SelectedIndex = 1
                Case 1024 : cbImageSize.SelectedIndex = 2
                Case Else
                    sImageProblems += " Image size must be: 256x256, 512x512, or 1024x1024."
            End Select

            If sImageProblems <> "" Then
                oImage.Dispose()

                If MsgBox(sImageProblems & " Fix image File?", vbYesNo) = vbYes Then
                    sFilePath = ResizeImage(sFilePath)
                    oImage = Image.FromFile(sFilePath)
                Else
                    sFilePath = ""
                End If
            End If

            If sFilePath <> "" Then
                txtInputFile.Text = sFilePath
                pbInput.Image = oImage
                pbInput.SizeMode = PictureBoxSizeMode.StretchImage
                btnCreateMask.Show()
                lblMsg.Text = "Click on the Image to draw the area that needs to be changed"
            End If

        End If
    End Sub

    Function ResizeImage(ByVal sFilePath As String)
        Dim iWidth As Integer = 256
        Select Case cbImageSize.SelectedIndex
            Case 0 : iWidth = 256
            Case 1 : iWidth = 512
            Case 2 : iWidth = 1024
        End Select

        ' Generate output path
        Dim directory As String = Path.GetDirectoryName(sFilePath)
        Dim fileName As String = Path.GetFileNameWithoutExtension(sFilePath)
        Dim outputPath As String = Path.Combine(directory, fileName & "_" & iWidth & ".png")

        If IO.File.Exists(outputPath) Then
            IO.File.Delete(outputPath)
        End If

        Return ResizeImage(sFilePath, outputPath, iWidth, iWidth)
    End Function

    Function ResizeImage(ByVal inputPath As String,
                         ByVal outputPath As String,
                         ByVal newWidth As Integer,
                         ByVal newHeight As Integer) As String

        ' Load the original image
        Using originalImage As Image = Image.FromFile(inputPath)
            ' Create a new Bitmap with the desired dimensions
            Using resizedImage As New Bitmap(newWidth, newHeight)
                ' Create Graphics object for the new image
                Using g As Graphics = Graphics.FromImage(resizedImage)
                    ' Set the resize quality modes
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic
                    g.SmoothingMode = SmoothingMode.HighQuality
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality
                    g.CompositingQuality = CompositingQuality.HighQuality

                    ' Draw the original image onto the new image
                    g.DrawImage(originalImage, 0, 0, newWidth, newHeight)
                End Using

                ' Save the resized image
                resizedImage.Save(outputPath, Imaging.ImageFormat.Png)
            End Using
        End Using

        ' Return the path of the resized image
        Return outputPath
    End Function

    Private Sub btnMask_Click(sender As Object, e As EventArgs) Handles btnMask.Click
        OpenFileDialog1.FileName = txtMaskFile.Text
        OpenFileDialog1.Title = "Open Image File"
        OpenFileDialog1.Filter = "Image files|*.png"
        OpenFileDialog1.ShowDialog()

        If OpenFileDialog1.FileName <> "" Then
            txtMaskFile.Text = OpenFileDialog1.FileName
            Dim oImage = Image.FromFile(txtMaskFile.Text)
            pbMask.Image = oImage
            pbMask.SizeMode = PictureBoxSizeMode.StretchImage
        End If
    End Sub

    Private Sub btnCreateMask_Click(sender As Object, e As EventArgs) Handles btnCreateMask.Click

        If txtInputFile.Text = "" Then
            MsgBox("Select Input image file first")
            Exit Sub
        End If

        Dim oFileInfo As New IO.FileInfo(txtInputFile.Text)
        Dim sMaskFileName As String = Path.GetFileNameWithoutExtension(txtInputFile.Text)
        Dim sMaskFilePath As String = ""

        For i As Integer = 1 To 100
            sMaskFilePath = Path.Combine(oFileInfo.Directory.FullName, sMaskFileName & "_Mask" & i & ".png")

            If IO.File.Exists(sMaskFilePath) Then
                Try
                    IO.File.Delete(sMaskFilePath)
                Catch ex As Exception
                    'Ignore
                End Try
            End If

            If IO.File.Exists(sMaskFilePath) = False Then
                Exit For
            End If
        Next

        CreateTransparentPng(txtInputFile.Text, sMaskFilePath, pbInput)
        txtMaskFile.Text = sMaskFilePath
        pbMask.Image = Image.FromFile(txtMaskFile.Text)
        pbMask.SizeMode = PictureBoxSizeMode.StretchImage
        TabControl1.SelectedIndex = 1 'Select second tab
        HideClearButton()
        btnCreateMask.Hide()
    End Sub


    Sub CreateTransparentPng(ByVal sInFilePath As String, ByVal sOutFilePath As String, ByVal pictureBox As PictureBox)
        Dim originalImage As Image = Image.FromFile(sInFilePath)
        Dim bmp As New Bitmap(originalImage.Width, originalImage.Height)

        Using g As Graphics = Graphics.FromImage(bmp)
            g.DrawImage(originalImage, 0, 0, originalImage.Width, originalImage.Height)
        End Using

        ' Calculate the scale factors based on PictureBox size and image size
        Dim scaleX As Double = originalImage.Width / pictureBox.ClientSize.Width
        Dim scaleY As Double = originalImage.Height / pictureBox.ClientSize.Height

        Dim path As New GraphicsPath()

        ' Transform and add points for each polygon to the path
        For Each polygon As List(Of Point) In allPolygons
            Dim transformedPoints As New List(Of Point)
            For Each pt In polygon
                transformedPoints.Add(New Point(CInt(pt.X * scaleX), CInt(pt.Y * scaleY)))
            Next
            path.AddPolygon(transformedPoints.ToArray())
        Next

        Dim region As New [Region](path)

        Dim rect As New Rectangle(0, 0, bmp.Width, bmp.Height)
        Dim bmpData As BitmapData = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

        Dim pixels As Integer = Math.Abs(bmpData.Stride) * bmp.Height
        Dim rgbValues(pixels - 1) As Byte
        System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, rgbValues, 0, pixels)

        For y As Integer = 0 To bmp.Height - 1
            For x As Integer = 0 To bmp.Width - 1
                If region.IsVisible(x, y) Then
                    Dim index As Integer = y * bmpData.Stride + x * 4
                    rgbValues(index + 3) = 0 ' Set alpha to 0 (transparent)
                End If
            Next
        Next

        System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, bmpData.Scan0, pixels)
        bmp.UnlockBits(bmpData)

        bmp.Save(sOutFilePath, Imaging.ImageFormat.Png)
        bmp.Dispose()
        originalImage.Dispose()
    End Sub

    Private drawing As Boolean = False
    Private currentPoints As New List(Of Point)
    Private allPolygons As New List(Of List(Of Point))
    Private Sub pbInput_MouseDown(sender As Object, e As MouseEventArgs) Handles pbInput.MouseDown
        If e.Button = MouseButtons.Left Then
            lblMsg.Text = "Right Click to close the polygon"
            drawing = True
            currentPoints.Add(e.Location)
            pbInput.Invalidate() ' Redraw the picture box
        ElseIf e.Button = MouseButtons.Right Then
            CloseCurrentPolygon()
        End If
    End Sub

    Sub CloseCurrentPolygon()
        lblMsg.Text = ""
        drawing = False
        If currentPoints.Count > 2 Then ' Ensure it's a valid polygon
            allPolygons.Add(New List(Of Point)(currentPoints))
        End If
        currentPoints.Clear()
        pbInput.Invalidate()
        btnCreateMask.Show()
    End Sub

    Private Sub pbInput_MouseMove(sender As Object, e As MouseEventArgs) Handles pbInput.MouseMove
        If drawing Then
            If currentPoints.Count > 1 Then
                currentPoints(currentPoints.Count - 1) = e.Location
            End If
            pbInput.Invalidate()
        End If
    End Sub

    Private Sub pbInput_MouseUp(sender As Object, e As MouseEventArgs) Handles pbInput.MouseUp
        If e.Button = MouseButtons.Left AndAlso drawing Then
            currentPoints(currentPoints.Count - 1) = e.Location
            currentPoints.Add(e.Location) ' Add a new point for the next segment
            pbInput.Invalidate()
            btnClear.Show()
        End If
    End Sub

    Private Sub pbInput_Paint(sender As Object, e As PaintEventArgs) Handles pbInput.Paint
        ' Draw all polygons
        For Each polygon As List(Of Point) In allPolygons
            If polygon.Count > 1 Then
                e.Graphics.FillPolygon(Brushes.LightBlue, polygon.ToArray())
                e.Graphics.DrawPolygon(Pens.Black, polygon.ToArray())
            End If
        Next

        ' Draw the current polygon
        If currentPoints.Count > 1 Then
            e.Graphics.FillPolygon(Brushes.LightBlue, currentPoints.ToArray())
            e.Graphics.DrawPolygon(Pens.Black, currentPoints.ToArray())
        End If
    End Sub

    Private Sub pbInput_DoubleClick(sender As Object, e As EventArgs) Handles pbInput.DoubleClick
        If drawing Then
            CloseCurrentPolygon()
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        HideClearButton()
    End Sub

    Sub HideClearButton()
        currentPoints.Clear()
        allPolygons.Clear()
        pbInput.Invalidate()
        btnClear.Hide()
    End Sub

    Private Sub txtPrompt_MouseWheel(sender As Object, e As MouseEventArgs) Handles txtPrompt.MouseWheel
        If Control.ModifierKeys = Keys.Control Then
            Dim currentSize As Single = txtPrompt.Font.Size
            Dim newSize As Single

            If e.Delta > 0 Then
                ' Mouse wheel was moved up, increase font size
                newSize = currentSize + 1
            Else
                ' Mouse wheel was moved down, decrease font size
                newSize = Math.Max(currentSize - 1, 1)
            End If

            txtPrompt.Font = New Font(txtPrompt.Font.FontFamily, newSize, txtPrompt.Font.Style)
        End If
    End Sub

    Private Sub btnApiKeyShow_Click(sender As Object, e As EventArgs) Handles btnApiKeyShow.Click
        If txtApiKey.PasswordChar = "*" Then
            txtApiKey.PasswordChar = ""
        Else
            txtApiKey.PasswordChar = "*"
        End If
    End Sub

    Private Sub urlApiKey_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles urlApiKey.LinkClicked
        Process.Start(New ProcessStartInfo("https://platform.openai.com/api-keys"))
    End Sub


End Class
