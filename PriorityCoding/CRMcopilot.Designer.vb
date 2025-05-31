<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CRMcopilot
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CRMcopilot))
        CRMLabel1 = New Label()
        CRMLabel2 = New Label()
        AIConversation = New PictureBox()
        PictureBox1 = New PictureBox()
        Sumarize = New Button()
        Notes = New Button()
        CType(AIConversation, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' CRMLabel1
        ' 
        CRMLabel1.AutoSize = True
        CRMLabel1.Font = New Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        CRMLabel1.ForeColor = Color.White
        CRMLabel1.Location = New Point(3, 9)
        CRMLabel1.Name = "CRMLabel1"
        CRMLabel1.Size = New Size(134, 24)
        CRMLabel1.TabIndex = 2
        CRMLabel1.Text = "CRM Copilot"
        ' 
        ' CRMLabel2
        ' 
        CRMLabel2.ForeColor = Color.White
        CRMLabel2.Location = New Point(3, 45)
        CRMLabel2.Name = "CRMLabel2"
        CRMLabel2.Size = New Size(639, 109)
        CRMLabel2.TabIndex = 1
        CRMLabel2.Text = resources.GetString("CRMLabel2.Text")
        ' 
        ' AIConversation
        ' 
        AIConversation.Image = CType(resources.GetObject("AIConversation.Image"), Image)
        AIConversation.Location = New Point(109, 173)
        AIConversation.Name = "AIConversation"
        AIConversation.Size = New Size(117, 109)
        AIConversation.SizeMode = PictureBoxSizeMode.Zoom
        AIConversation.TabIndex = 3
        AIConversation.TabStop = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImageLayout = ImageLayout.None
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(370, 173)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(125, 109)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 4
        PictureBox1.TabStop = False
        ' 
        ' Sumarize
        ' 
        Sumarize.Location = New Point(109, 315)
        Sumarize.Name = "Sumarize"
        Sumarize.Size = New Size(117, 23)
        Sumarize.TabIndex = 5
        Sumarize.Text = "Sumarize a ticket"
        Sumarize.UseVisualStyleBackColor = True
        ' 
        ' Notes
        ' 
        Notes.Location = New Point(370, 315)
        Notes.Name = "Notes"
        Notes.Size = New Size(125, 23)
        Notes.TabIndex = 6
        Notes.Text = "Internal notes"
        Notes.UseVisualStyleBackColor = True
        ' 
        ' CRMcopilot
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(51), CByte(51), CByte(51))
        Controls.Add(Notes)
        Controls.Add(Sumarize)
        Controls.Add(PictureBox1)
        Controls.Add(AIConversation)
        Controls.Add(CRMLabel2)
        Controls.Add(CRMLabel1)
        Name = "CRMcopilot"
        Size = New Size(645, 454)
        CType(AIConversation, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents CRMLabel1 As Label
    Friend WithEvents CRMLabel2 As Label
    Friend WithEvents AIConversation As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Sumarize As Button
    Friend WithEvents Notes As Button

End Class
