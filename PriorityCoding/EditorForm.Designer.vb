<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditorForm
    Inherits System.Windows.Forms.Form



    ' In the Designer file
    Friend WithEvents webView21 As Microsoft.Web.WebView2.WinForms.WebView2

    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.webView21 = New Microsoft.Web.WebView2.WinForms.WebView2()
        CType(Me.webView21, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        ' 
        ' Button1
        ' 
        Me.Button1.Location = New System.Drawing.Point(305, 356)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Upload"
        Me.Button1.UseVisualStyleBackColor = True
        ' 
        ' webView21
        ' 
        Me.webView21.AllowExternalDrop = True
        Me.webView21.CreationProperties = Nothing
        Me.webView21.DefaultBackgroundColor = System.Drawing.Color.White
        Me.webView21.Location = New System.Drawing.Point(12, 38)
        Me.webView21.Name = "webView21"
        Me.webView21.Size = New System.Drawing.Size(751, 268)
        Me.webView21.TabIndex = 1
        Me.webView21.ZoomFactor = 1.0R
        ' 
        ' EditorForm
        ' 
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0F, 15.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.webView21)
        Me.Controls.Add(Me.Button1)
        Me.Name = "EditorForm"
        Me.Text = "EditorForm"
        CType(Me.webView21, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents Button1 As Button
End Class
