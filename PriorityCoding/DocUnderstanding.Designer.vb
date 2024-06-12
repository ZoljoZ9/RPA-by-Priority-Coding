<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DocUnderstanding
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocUnderstanding))
        Panel1 = New Panel()
        scrapeFileButton = New Button()
        PictureBox2 = New PictureBox()
        PictureBox1 = New PictureBox()
        scrapeWebsiteButton = New Button()
        Label2 = New Label()
        Label1 = New Label()
        Panel1.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(51), CByte(51), CByte(51))
        Panel1.Controls.Add(scrapeFileButton)
        Panel1.Controls.Add(PictureBox2)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Controls.Add(scrapeWebsiteButton)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(645, 454)
        Panel1.TabIndex = 2
        ' 
        ' scrapeFileButton
        ' 
        scrapeFileButton.Location = New Point(376, 327)
        scrapeFileButton.Name = "scrapeFileButton"
        scrapeFileButton.Size = New Size(109, 23)
        scrapeFileButton.TabIndex = 5
        scrapeFileButton.Text = "Scrape file(s)"
        scrapeFileButton.UseVisualStyleBackColor = True
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(134, 186)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(116, 111)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 4
        PictureBox2.TabStop = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(376, 186)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(109, 111)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 3
        PictureBox1.TabStop = False
        ' 
        ' scrapeWebsiteButton
        ' 
        scrapeWebsiteButton.Location = New Point(134, 327)
        scrapeWebsiteButton.Name = "scrapeWebsiteButton"
        scrapeWebsiteButton.Size = New Size(116, 23)
        scrapeWebsiteButton.TabIndex = 2
        scrapeWebsiteButton.Text = "Scrape the web"
        scrapeWebsiteButton.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.ForeColor = Color.White
        Label2.Location = New Point(3, 45)
        Label2.Name = "Label2"
        Label2.Size = New Size(639, 150)
        Label2.TabIndex = 1
        Label2.Text = resources.GetString("Label2.Text")
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial", 16F, FontStyle.Bold)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(0, 8)
        Label1.Name = "Label1"
        Label1.Size = New Size(351, 26)
        Label1.TabIndex = 0
        Label1.Text = "Document understanding module"
        ' 
        ' DocUnderstanding
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Panel1)
        Name = "DocUnderstanding"
        Size = New Size(644, 452)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub


    Friend WithEvents Panel1 As Panel
    Friend WithEvents scrapeFileButton As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents scrapeWebsiteButton As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label

End Class
