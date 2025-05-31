Imports System.Windows.Forms

Public Class SideBar

    Private Sub SideBar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Attach event handlers to buttons
        AttachButtonHandlers()

        ' Calculate the total height of the buttons
        Dim totalButtonHeight As Integer = 0
        For Each ctrl As Control In Panel1.Controls
            If TypeOf ctrl Is Button Then
                totalButtonHeight += ctrl.Height
            End If
        Next

        ' Set the size of Panel1 based on the total button height
        Panel1.Height = totalButtonHeight
    End Sub

    Private Sub AttachButtonHandlers()
        For Each ctrl As Control In Panel1.Controls
            If TypeOf ctrl Is Button Then
                AddHandler DirectCast(ctrl, Button).Click, AddressOf Button_Click
            End If
        Next
    End Sub

    Private Sub Button_Click(sender As Object, e As EventArgs)
        Dim button As Button = DirectCast(sender, Button)
        If button.Name = "Button1" Then
            Dim docUnderstandingForm As New DocUnderstanding()
            docUnderstandingForm.Show()
        ElseIf button.Name = "Button2" Then
            Dim macInjectionForm As New MacInjection()
            macInjectionForm.Show()
        ElseIf button.Name = "Button3" Then
            Dim macInjectionForm As New MacInjection()
            CRMcopilotForm.Show()
        Else
            MessageBox.Show("New features coming soon")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TypeOf ParentForm Is MainScreen Then
            Dim mainScreenForm As MainScreen = DirectCast(ParentForm, MainScreen)
            mainScreenForm.ShowDocUnderstanding()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TypeOf ParentForm Is MainScreen Then
            Dim mainScreenForm As MainScreen = DirectCast(ParentForm, MainScreen)
            mainScreenForm.ShowMacInjection()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TypeOf ParentForm Is MainScreen Then
            Dim mainScreenForm As MainScreen = DirectCast(ParentForm, MainScreen)
            mainScreenForm.ShowCRMcopilot()
        End If
    End Sub
End Class
