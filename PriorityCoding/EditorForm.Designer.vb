<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditorForm
    Inherits System.Windows.Forms.Form



    ' In the Designer file
    Friend WithEvents webView21 As Microsoft.Web.WebView2.WinForms.WebView2

    Private Sub InitializeComponent()
        Button1 = New Button()
        webView21 = New Microsoft.Web.WebView2.WinForms.WebView2()
        CType(webView21, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(305, 356)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 0
        Button1.Text = "Upload"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' webView21
        ' 
        webView21.AllowExternalDrop = True
        webView21.CreationProperties = Nothing
        webView21.DefaultBackgroundColor = Color.White
        webView21.Location = New Point(12, 38)
        webView21.Name = "webView21"
        webView21.Size = New Size(751, 268)
        webView21.TabIndex = 1
        webView21.ZoomFactor = 1R
        ' 
        ' EditorForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(webView21)
        Controls.Add(Button1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        Name = "EditorForm"
        Text = "EditorForm"
        CType(webView21, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Button1 As Button
End Class
