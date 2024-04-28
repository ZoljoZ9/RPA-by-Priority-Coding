Imports System.Windows.Forms

Public Class SideBar

    ' Define an array with button names and their corresponding form names
    Private buttonNamesAndFormNames() As (buttonName As String, formName As String) = {
        ("Document understanding", "DocUnderstand.vb"),
        ("Button 2", "Form2"),
        ("Button 3", "Form3"),
        ("Button 4", "Form4"),
        ("Button 5", "Form5"),
        ("Button 6", "Form6")
    }

    Private Sub SideMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeDynamicControls()
    End Sub

    Private Sub InitializeDynamicControls()
        ' Add buttons dynamically based on the buttonNamesAndFormNames array
        For Each pair In buttonNamesAndFormNames
            Dim button As New Button()
            button.Text = pair.buttonName
            button.Dock = DockStyle.Top
            AddHandler button.Click, AddressOf OpenForm
            Panel1.Controls.Add(button)
        Next
    End Sub

    Private Sub OpenForm(sender As Object, e As EventArgs)
        ' Handle button click event
        Dim button As Button = DirectCast(sender, Button)
        Dim index As Integer = -1

        ' Find the index of the clicked button in the buttonNamesAndFormNames array
        For i As Integer = 0 To buttonNamesAndFormNames.Length - 1
            If buttonNamesAndFormNames(i).buttonName = button.Text Then
                index = i
                Exit For
            End If
        Next

        ' Open the corresponding form based on the index
        If index >= 0 AndAlso index < buttonNamesAndFormNames.Length Then
            Dim formName As String = buttonNamesAndFormNames(index).formName

            ' Assuming that the form files are in the same namespace as SideBar
            If Not String.IsNullOrEmpty(formName) Then
                Dim formInstance As Form = CType(Activator.CreateInstance(Type.GetType(formName)), Form)
                formInstance.Show()
            Else
                MessageBox.Show("Invalid form name or form not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Invalid button index.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Button_Click(sender As Object, e As EventArgs)
        ' Handle button click event
        Dim button As Button = DirectCast(sender, Button)
        MessageBox.Show("Button clicked: " & button.Text)
    End Sub

    ' Add scroll functionality using mouse wheel
    Private Sub Panel1_MouseWheel(sender As Object, e As MouseEventArgs) Handles Panel1.MouseWheel
        If Panel1.VerticalScroll.Visible Then
            Dim newValue As Integer = Panel1.VerticalScroll.Value - (e.Delta * SystemInformation.MouseWheelScrollLines \ SystemInformation.MouseWheelScrollDelta)
            Panel1.VerticalScroll.Value = Math.Max(Panel1.VerticalScroll.Minimum, Math.Min(Panel1.VerticalScroll.Maximum, newValue))
        End If
    End Sub



End Class
