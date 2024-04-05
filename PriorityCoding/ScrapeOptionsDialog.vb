Public Class ScrapeOptionsDialog
    Private Sub btnSingleWebpage_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Set the DialogResult to indicate that the user selected the single webpage option
        Me.DialogResult = DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub btnWholeWebsite_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Set the DialogResult to indicate that the user selected the whole website option
        Me.DialogResult = DialogResult.No
        Me.Close()
    End Sub

    Private Sub ScrapeOptionsDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class
