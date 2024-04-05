Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Use Application.ExecutablePath to get the path of the executable
        Dim imagePath As String = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "splash_layout.jpg")

        ' Check if the file exists before loading
        If System.IO.File.Exists(imagePath) Then
            logoLogin.Image = Image.FromFile(imagePath)
            logoLogin.SizeMode = PictureBoxSizeMode.StretchImage ' Stretch the image to fill the PictureBox
        Else
            MessageBox.Show("Image file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub LogoLogin_Click(sender As Object, e As EventArgs) Handles logoLogin.Click

    End Sub

    Private Sub EmailLogin_TextChanged(sender As Object, e As EventArgs) Handles emailLogin.TextChanged

    End Sub
    Private Sub LoginLogin_Click(sender As Object, e As EventArgs) Handles loginLogin.Click
        ' Create a new instance of the ProfileScreen
        Dim profileScreen As New ProfileScreen()

        ' Set the size of the ProfileScreen to the size of Form1
        profileScreen.Size = Me.Size

        ' Show the ProfileScreen
        profileScreen.Show()

        ' Hide the current form
        Me.Hide()
    End Sub
End Class
