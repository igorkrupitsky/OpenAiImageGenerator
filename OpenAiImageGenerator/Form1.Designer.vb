<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPrompt = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.pbMask = New System.Windows.Forms.PictureBox()
        Me.btnMask = New System.Windows.Forms.Button()
        Me.txtMaskFile = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.pbOuput = New System.Windows.Forms.PictureBox()
        Me.btnOutput = New System.Windows.Forms.Button()
        Me.txtOutputFile = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnFile = New System.Windows.Forms.Button()
        Me.pbInput = New System.Windows.Forms.PictureBox()
        Me.txtInputFile = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.cbImageSize = New System.Windows.Forms.ComboBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnCreateMask = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtApiKey = New System.Windows.Forms.TextBox()
        Me.btnApiKeyShow = New System.Windows.Forms.Button()
        Me.urlApiKey = New System.Windows.Forms.LinkLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        CType(Me.pbMask, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.pbOuput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbInput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(501, 102)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(116, 37)
        Me.btnGenerate.TabIndex = 1
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Prompt"
        '
        'txtPrompt
        '
        Me.txtPrompt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPrompt.Location = New System.Drawing.Point(92, 40)
        Me.txtPrompt.Multiline = True
        Me.txtPrompt.Name = "txtPrompt"
        Me.txtPrompt.Size = New System.Drawing.Size(1385, 54)
        Me.txtPrompt.TabIndex = 3
        Me.txtPrompt.Text = "Draw Flowers"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.pbMask)
        Me.GroupBox2.Controls.Add(Me.btnMask)
        Me.GroupBox2.Controls.Add(Me.txtMaskFile)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(730, 959)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        '
        'pbMask
        '
        Me.pbMask.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbMask.BackColor = System.Drawing.Color.PeachPuff
        Me.pbMask.Location = New System.Drawing.Point(3, 59)
        Me.pbMask.Name = "pbMask"
        Me.pbMask.Size = New System.Drawing.Size(720, 596)
        Me.pbMask.TabIndex = 23
        Me.pbMask.TabStop = False
        '
        'btnMask
        '
        Me.btnMask.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMask.Location = New System.Drawing.Point(681, 14)
        Me.btnMask.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnMask.Name = "btnMask"
        Me.btnMask.Size = New System.Drawing.Size(42, 37)
        Me.btnMask.TabIndex = 18
        Me.btnMask.Text = "..."
        Me.btnMask.UseVisualStyleBackColor = True
        '
        'txtMaskFile
        '
        Me.txtMaskFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMaskFile.Location = New System.Drawing.Point(3, 19)
        Me.txtMaskFile.Name = "txtMaskFile"
        Me.txtMaskFile.Size = New System.Drawing.Size(671, 26)
        Me.txtMaskFile.TabIndex = 5
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.pbOuput)
        Me.GroupBox3.Controls.Add(Me.btnOutput)
        Me.GroupBox3.Controls.Add(Me.txtOutputFile)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(732, 702)
        Me.GroupBox3.TabIndex = 21
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Output File"
        '
        'pbOuput
        '
        Me.pbOuput.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbOuput.Location = New System.Drawing.Point(6, 59)
        Me.pbOuput.Name = "pbOuput"
        Me.pbOuput.Size = New System.Drawing.Size(700, 631)
        Me.pbOuput.TabIndex = 0
        Me.pbOuput.TabStop = False
        '
        'btnOutput
        '
        Me.btnOutput.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOutput.Location = New System.Drawing.Point(665, 16)
        Me.btnOutput.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnOutput.Name = "btnOutput"
        Me.btnOutput.Size = New System.Drawing.Size(42, 37)
        Me.btnOutput.TabIndex = 18
        Me.btnOutput.Text = "..."
        Me.btnOutput.UseVisualStyleBackColor = True
        '
        'txtOutputFile
        '
        Me.txtOutputFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOutputFile.Location = New System.Drawing.Point(6, 25)
        Me.txtOutputFile.Name = "txtOutputFile"
        Me.txtOutputFile.Size = New System.Drawing.Size(650, 26)
        Me.txtOutputFile.TabIndex = 5
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(768, 706)
        Me.TabControl1.TabIndex = 22
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(760, 673)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Input File"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnFile)
        Me.GroupBox1.Controls.Add(Me.pbInput)
        Me.GroupBox1.Controls.Add(Me.txtInputFile)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(733, 661)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        '
        'btnFile
        '
        Me.btnFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFile.Location = New System.Drawing.Point(684, 14)
        Me.btnFile.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnFile.Name = "btnFile"
        Me.btnFile.Size = New System.Drawing.Size(42, 37)
        Me.btnFile.TabIndex = 19
        Me.btnFile.Text = "..."
        Me.btnFile.UseVisualStyleBackColor = True
        '
        'pbInput
        '
        Me.pbInput.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbInput.Location = New System.Drawing.Point(6, 59)
        Me.pbInput.Name = "pbInput"
        Me.pbInput.Size = New System.Drawing.Size(720, 596)
        Me.pbInput.TabIndex = 0
        Me.pbInput.TabStop = False
        '
        'txtInputFile
        '
        Me.txtInputFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInputFile.Location = New System.Drawing.Point(6, 19)
        Me.txtInputFile.Name = "txtInputFile"
        Me.txtInputFile.Size = New System.Drawing.Size(671, 26)
        Me.txtInputFile.TabIndex = 5
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(760, 673)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Mask File"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cbImageSize
        '
        Me.cbImageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbImageSize.FormattingEnabled = True
        Me.cbImageSize.Items.AddRange(New Object() {"256", "512", "1024"})
        Me.cbImageSize.Location = New System.Drawing.Point(92, 105)
        Me.cbImageSize.Name = "cbImageSize"
        Me.cbImageSize.Size = New System.Drawing.Size(130, 28)
        Me.cbImageSize.TabIndex = 21
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(247, 102)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(79, 37)
        Me.btnClear.TabIndex = 20
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        Me.btnClear.Visible = False
        '
        'btnCreateMask
        '
        Me.btnCreateMask.Location = New System.Drawing.Point(334, 102)
        Me.btnCreateMask.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnCreateMask.Name = "btnCreateMask"
        Me.btnCreateMask.Size = New System.Drawing.Size(154, 37)
        Me.btnCreateMask.TabIndex = 18
        Me.btnCreateMask.Text = "Create Mask File"
        Me.btnCreateMask.UseVisualStyleBackColor = True
        Me.btnCreateMask.Visible = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(-1, 154)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TabControl1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox3)
        Me.SplitContainer1.Size = New System.Drawing.Size(1478, 740)
        Me.SplitContainer1.SplitterDistance = 754
        Me.SplitContainer1.TabIndex = 19
        '
        'lblMsg
        '
        Me.lblMsg.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.Location = New System.Drawing.Point(12, 906)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(0, 46)
        Me.lblMsg.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 9)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 20)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "API key"
        '
        'txtApiKey
        '
        Me.txtApiKey.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtApiKey.Location = New System.Drawing.Point(92, 6)
        Me.txtApiKey.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtApiKey.Name = "txtApiKey"
        Me.txtApiKey.Size = New System.Drawing.Size(1334, 26)
        Me.txtApiKey.TabIndex = 23
        '
        'btnApiKeyShow
        '
        Me.btnApiKeyShow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApiKeyShow.Location = New System.Drawing.Point(1434, 2)
        Me.btnApiKeyShow.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnApiKeyShow.Name = "btnApiKeyShow"
        Me.btnApiKeyShow.Size = New System.Drawing.Size(42, 35)
        Me.btnApiKeyShow.TabIndex = 49
        Me.btnApiKeyShow.Text = "*"
        Me.btnApiKeyShow.UseVisualStyleBackColor = True
        '
        'urlApiKey
        '
        Me.urlApiKey.AutoSize = True
        Me.urlApiKey.Location = New System.Drawing.Point(67, 9)
        Me.urlApiKey.Name = "urlApiKey"
        Me.urlApiKey.Size = New System.Drawing.Size(18, 20)
        Me.urlApiKey.TabIndex = 50
        Me.urlApiKey.TabStop = True
        Me.urlApiKey.Text = "?"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 20)
        Me.Label3.TabIndex = 51
        Me.Label3.Text = "File Size"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1489, 970)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.cbImageSize)
        Me.Controls.Add(Me.btnCreateMask)
        Me.Controls.Add(Me.urlApiKey)
        Me.Controls.Add(Me.btnApiKeyShow)
        Me.Controls.Add(Me.txtApiKey)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.txtPrompt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnGenerate)
        Me.Name = "Form1"
        Me.Text = "dall-e-2 Image Edit"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.pbMask, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.pbOuput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pbInput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGenerate As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtPrompt As TextBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnMask As Button
    Friend WithEvents txtMaskFile As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents pbOuput As PictureBox
    Friend WithEvents btnOutput As Button
    Friend WithEvents txtOutputFile As TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents pbInput As PictureBox
    Friend WithEvents btnCreateMask As Button
    Friend WithEvents txtInputFile As TextBox
    Friend WithEvents btnFile As Button
    Friend WithEvents pbMask As PictureBox
    Friend WithEvents btnClear As Button
    Friend WithEvents lblMsg As Label
    Friend WithEvents cbImageSize As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtApiKey As TextBox
    Friend WithEvents btnApiKeyShow As Button
    Friend WithEvents urlApiKey As LinkLabel
    Friend WithEvents Label3 As Label
End Class
