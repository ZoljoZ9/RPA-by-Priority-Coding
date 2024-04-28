' Import necessary namespaces if not already imported
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class MainScreen

    ' Declare VScrollBar1 with WithEvents
    Private WithEvents VScrollBar1 As New VScrollBar()

    Private Sub MainScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Call a method to initialize dynamic controls
        InitializeDynamicControls()
        Panel1.Visible = True

        ' Add the VScrollBar control to the form
        Controls.Add(VScrollBar1)
        ' Set the properties of the VScrollBar control
        VScrollBar1.Dock = DockStyle.Right
        VScrollBar1.Minimum = 0
        VScrollBar1.Maximum = Panel2.Height
        VScrollBar1.LargeChange = Panel2.Height - Panel1.Height ' Set the large change value
        VScrollBar1.SmallChange = 20 ' Set the small change value

        ' Set the value of the VScrollBar to 0 to ensure it starts at the top
        VScrollBar1.Value = 0

        ' Set the vertical scroll position of Panel2 to 0
        Panel2.VerticalScroll.Value = 0
    End Sub




    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub InitializeDynamicControls()
        ' Define an array with button names in descending order
        Dim buttonNames() As String = {"Button 6", "Button 6", "Button 6", "Button 6", "Button 6", "Button 6", "Button 6", "Button 6", "Button 6", "Button 6", "Button 6", "Button 6", "Button 6", "Button 6", "Button 6", "Button 6", "Button 6", "Button 5", "Button 4", "Button 3", "Button 2", "Document understanding"}

        ' Add buttons dynamically based on the buttonNames array
        For Each buttonName As String In buttonNames
            Dim button As New System.Windows.Forms.Button() ' Fully qualify Button class
            button.Text = buttonName
            button.Dock = DockStyle.Top
            AddHandler button.Click, AddressOf OpenForm ' Add click event handler
            Panel2.Controls.Add(button)
        Next
    End Sub

    ' Inside the MainScreen class
    Private WithEvents docunderstanding As New DocUnderstanding()

    Private Sub OpenForm(sender As Object, e As EventArgs)
        ' Handle button click event
        Dim button As System.Windows.Forms.Button = DirectCast(sender, System.Windows.Forms.Button)

        ' Check which button was clicked
        Select Case button.Text
            Case "Document understanding"
                ' Show docunderstanding UserControl
                docunderstanding.Show()

                ' Hide Panel1
                Panel1.Visible = False

                ' Bring docunderstanding UserControl to the front
                docunderstanding.BringToFront()
            Case Else
                ' Handle other buttons here
                MessageBox.Show("This module is not yet developed, please email matthew@zoljan.com for urgent need!")
        End Select
    End Sub

    ' Event handler for the Scroll event of the VScrollBar
    Private Sub VScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBar1.Scroll
        ' Adjust the location of Panel2 based on the scrollbar value
        Panel2.Location = New Point(Panel2.Location.X, -VScrollBar1.Value)
    End Sub
End Class
