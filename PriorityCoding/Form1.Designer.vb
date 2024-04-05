<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        emailLogin = New TextBox()
        passwordLogin = New TextBox()
        loginLogin = New Button()
        ImageList1 = New ImageList(components)
        ImageList2 = New ImageList(components)
        logoLogin = New PictureBox()
        registerLogin = New Button()
        CType(logoLogin, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' emailLogin
        ' 
        emailLogin.Location = New Point(255, 259)
        emailLogin.Name = "emailLogin"
        emailLogin.Size = New Size(232, 23)
        emailLogin.TabIndex = 0
        emailLogin.Text = "Email"
        ' 
        ' passwordLogin
        ' 
        passwordLogin.Location = New Point(255, 288)
        passwordLogin.Name = "passwordLogin"
        passwordLogin.Size = New Size(232, 23)
        passwordLogin.TabIndex = 1
        passwordLogin.Text = "Password"
        ' 
        ' loginLogin
        ' 
        loginLogin.Location = New Point(255, 317)
        loginLogin.Name = "loginLogin"
        loginLogin.Size = New Size(119, 23)
        loginLogin.TabIndex = 2
        loginLogin.Text = "Login"
        loginLogin.UseVisualStyleBackColor = True
        ' 
        ' ImageList1
        ' 
        ImageList1.ColorDepth = ColorDepth.Depth32Bit
        ImageList1.ImageSize = New Size(16, 16)
        ImageList1.TransparentColor = Color.Transparent
        ' 
        ' ImageList2
        ' 
        ImageList2.ColorDepth = ColorDepth.Depth32Bit
        ImageList2.ImageSize = New Size(16, 16)
        ImageList2.TransparentColor = Color.Transparent
        ' 
        ' logoLogin
        ' 
        logoLogin.Location = New Point(272, 50)
        logoLogin.Name = "logoLogin"
        logoLogin.Size = New Size(203, 203)
        logoLogin.SizeMode = PictureBoxSizeMode.StretchImage
        logoLogin.TabIndex = 3
        logoLogin.TabStop = False
        ' 
        ' registerLogin
        ' 
        registerLogin.Location = New Point(380, 317)
        registerLogin.Name = "registerLogin"
        registerLogin.Size = New Size(107, 23)
        registerLogin.TabIndex = 4
        registerLogin.Text = "Register"
        registerLogin.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(registerLogin)
        Controls.Add(logoLogin)
        Controls.Add(loginLogin)
        Controls.Add(passwordLogin)
        Controls.Add(emailLogin)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Form1"
        Text = "Form1"
        CType(logoLogin, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents emailLogin As TextBox
    Friend WithEvents passwordLogin As TextBox
    Friend WithEvents loginLogin As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents logoLogin As PictureBox
    Friend WithEvents registerLogin As Button
    Private plusButton As Button




End Class
