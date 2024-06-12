Public Class SplashScreen
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
    Private Sub SplashScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the form's border style to FixedSingle to disallow resizing
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Hide the current form
        Me.Hide()

        ' Create an instance of the MainScreen form
        Dim mainScreenForm As New MainScreen()

        ' Show the MainScreen form
        mainScreenForm.Show()
    End Sub
End Class