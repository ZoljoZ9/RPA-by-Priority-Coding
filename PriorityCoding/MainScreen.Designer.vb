<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainScreen
    Inherits System.Windows.Forms.Form



    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.txtConsoleOutput = New System.Windows.Forms.TextBox()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainScreen))
        BindingSource1 = New BindingSource(components)
        Panel1 = New Panel()
        PictureBox1 = New PictureBox()
        Label1 = New Label()
        MacInjection1 = New MacInjection()
        DocUnderstanding1 = New DocUnderstanding()
        SideBar1 = New SideBar()
        CType(BindingSource1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(51), CByte(51), CByte(51))
        Panel1.Controls.Add(PictureBox1)
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(191, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(637, 460)
        Panel1.TabIndex = 1
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.pclogo
        PictureBox1.Location = New Point(305, 194)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(89, 82)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial", 16.0F, FontStyle.Bold)
        Label1.Location = New Point(161, 155)
        Label1.Name = "Label1"
        Label1.Size = New Size(211, 26)
        Label1.TabIndex = 0
        Label1.Text = "Welcome to RPA by"
        ' 
        ' MacInjection1
        ' 
        MacInjection1.BackColor = Color.FromArgb(CByte(51), CByte(51), CByte(51))
        MacInjection1.Location = New Point(191, 0)
        MacInjection1.Name = "MacInjection1"
        MacInjection1.Size = New Size(648, 460)
        MacInjection1.TabIndex = 3
        ' 
        ' DocUnderstanding1
        ' 
        DocUnderstanding1.Location = New Point(191, 0)
        DocUnderstanding1.Name = "DocUnderstanding1"
        DocUnderstanding1.Size = New Size(735, 460)
        DocUnderstanding1.TabIndex = 2
        ' 
        ' SideBar1
        ' 
        SideBar1.AutoScroll = True
        SideBar1.AutoScrollMinSize = New Size(0, 460)
        SideBar1.Location = New Point(4, 0)
        SideBar1.MaximumSize = New Size(0, 460)
        SideBar1.Name = "SideBar1"
        SideBar1.Size = New Size(181, 460)
        SideBar1.TabIndex = 3
        ' 
        ' MainScreen
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(835, 449)
        Controls.Add(SideBar1)
        Controls.Add(Panel1)
        Controls.Add(MacInjection1)
        Controls.Add(DocUnderstanding1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        KeyPreview = True
        MaximizeBox = False
        Name = "MainScreen"
        Text = "RPA by Priority Coding"
        CType(BindingSource1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub
    Friend WithEvents txtConsoleOutput As System.Windows.Forms.TextBox

    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents DocUnderstanding1 As DocUnderstanding
    Friend WithEvents MacInjection1 As MacInjection
    Friend WithEvents SideBar1 As SideBar
End Class
