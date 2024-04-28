<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainScreen
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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainScreen))
        BindingSource1 = New BindingSource(components)
        Panel1 = New Panel()
        PictureBox1 = New PictureBox()
        Label1 = New Label()
        DocUnderstanding1 = New DocUnderstanding()
        Panel2 = New Panel()
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
        Panel1.Size = New Size(637, 440)
        Panel1.TabIndex = 1
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.pclogo
        PictureBox1.Location = New Point(206, 183)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(89, 82)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial", 16F, FontStyle.Bold)
        Label1.Location = New Point(161, 155)
        Label1.Name = "Label1"
        Label1.Size = New Size(211, 26)
        Label1.TabIndex = 0
        Label1.Text = "Welcome to RPA by"
        ' 
        ' DocUnderstanding1
        ' 
        DocUnderstanding1.Location = New Point(191, 0)
        DocUnderstanding1.Name = "DocUnderstanding1"
        DocUnderstanding1.Size = New Size(735, 460)
        DocUnderstanding1.TabIndex = 2
        ' 
        ' Panel2
        ' 
        Panel2.AutoScroll = True
        Panel2.AutoScrollMargin = New Size(5, 5)
        Panel2.AutoScrollMinSize = New Size(5, 5)
        Panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Panel2.BackColor = Color.FromArgb(CByte(19), CByte(252), CByte(117))
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(185, 443)
        Panel2.TabIndex = 0
        ' 
        ' MainScreen
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(826, 439)
        Controls.Add(Panel1)
        Controls.Add(DocUnderstanding1)
        Controls.Add(Panel2)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        Name = "MainScreen"
        Text = "MainScreen"
        CType(BindingSource1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents DocUnderstanding1 As DocUnderstanding
End Class
