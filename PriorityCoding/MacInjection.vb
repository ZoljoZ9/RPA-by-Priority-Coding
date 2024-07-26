Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports System.Data.SQLite
Imports System.IO

Public Class MacInjection
    Inherits UserControl

    ' Import the necessary functions from user32.dll
    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function RegisterHotKey(hWnd As IntPtr, id As Integer, fsModifiers As UInteger, vk As UInteger) As Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function UnregisterHotKey(hWnd As IntPtr, id As Integer) As Boolean
    End Function

    ' Constants for the hotkeys
    Private Const MOD_NONE As UInteger = &H0 ' No modifiers
    Private Const HOTKEY_ID_F1 As Integer = 1
    Private Const HOTKEY_ID_F2 As Integer = 2
    Private Const HOTKEY_ID_F3 As Integer = 3
    Private Const HOTKEY_ID_F4 As Integer = 4
    Private Const HOTKEY_ID_F5 As Integer = 5
    Private Const HOTKEY_ID_F6 As Integer = 6
    Private Const HOTKEY_ID_F7 As Integer = 7
    Private Const HOTKEY_ID_F8 As Integer = 8
    Private Const HOTKEY_ID_F9 As Integer = 9
    Private Const HOTKEY_ID_F10 As Integer = 10
    Private Const HOTKEY_ID_F11 As Integer = 11
    Private Const HOTKEY_ID_F12 As Integer = 12

    ' SQLite connection string and connection object
    Private connectionString As String = $"Data Source={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "mydatabase.db")};Version=3;"
    Private connection As SQLiteConnection

    ' Dictionary to store information for each PictureBox
    Private pictureBoxInformation As New Dictionary(Of String, String)

    ' Controls for displaying and updating information
    Private textBox1 As New TextBox()
    Private button1 As New Button()
    Private textBox2 As New TextBox()
    Private button2 As New Button()
    Private textBox3 As New TextBox()
    Private button3 As New Button()
    Private textBox4 As New TextBox()
    Private button4 As New Button()
    Private textBox5 As New TextBox()
    Private button5 As New Button()
    Private textBox6 As New TextBox()
    Private button6 As New Button()
    Private textBox7 As New TextBox()
    Private button7 As New Button()
    Private textBox8 As New TextBox()
    Private button8 As New Button()
    Private textBox9 As New TextBox()
    Private button9 As New Button()
    Private textBox10 As New TextBox()
    Private button10 As New Button()
    Private textBox11 As New TextBox()
    Private button11 As New Button()
    Private textBox12 As New TextBox()
    Private button12 As New Button()

    Public Sub New()
        InitializeComponent()
        ' Initialize SQLite connection
        connection = New SQLiteConnection(connectionString)
        Try
            ' Ensure the database file exists
            Dim databaseFilePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "mydatabase.db")
            If Not File.Exists(databaseFilePath) Then
                SQLiteConnection.CreateFile(databaseFilePath)
            End If

            connection.Open()
            Debug.WriteLine("SQLite connection opened.")
            CreateTableIfNotExists()
        Catch ex As Exception
            Debug.WriteLine($"Error opening SQLite connection: {ex.Message}")
        End Try

        ' Initialize TextBox and Button controls
        InitializeControls()
    End Sub


    Protected Overrides Sub OnHandleCreated(e As EventArgs)
        MyBase.OnHandleCreated(e)
        ' Register the hotkeys here
        RegisterHotKey(Me.Handle, HOTKEY_ID_F1, MOD_NONE, CUInt(Keys.F1))
        RegisterHotKey(Me.Handle, HOTKEY_ID_F2, MOD_NONE, CUInt(Keys.F2))
        RegisterHotKey(Me.Handle, HOTKEY_ID_F3, MOD_NONE, CUInt(Keys.F3))
        RegisterHotKey(Me.Handle, HOTKEY_ID_F4, MOD_NONE, CUInt(Keys.F4))
        RegisterHotKey(Me.Handle, HOTKEY_ID_F5, MOD_NONE, CUInt(Keys.F5))
        RegisterHotKey(Me.Handle, HOTKEY_ID_F6, MOD_NONE, CUInt(Keys.F6))
        RegisterHotKey(Me.Handle, HOTKEY_ID_F7, MOD_NONE, CUInt(Keys.F7))
        RegisterHotKey(Me.Handle, HOTKEY_ID_F8, MOD_NONE, CUInt(Keys.F8))
        RegisterHotKey(Me.Handle, HOTKEY_ID_F9, MOD_NONE, CUInt(Keys.F9))
        RegisterHotKey(Me.Handle, HOTKEY_ID_F10, MOD_NONE, CUInt(Keys.F10))
        RegisterHotKey(Me.Handle, HOTKEY_ID_F11, MOD_NONE, CUInt(Keys.F11))
        RegisterHotKey(Me.Handle, HOTKEY_ID_F12, MOD_NONE, CUInt(Keys.F12))
        Debug.WriteLine("Hotkeys registered.")
    End Sub
    Private Sub InitializeControls()
        ' Initialize TextBox and Button controls for PictureBox1
        textBox1.Location = New Point(20, 60)
        textBox1.Width = 200
        button1.Location = New Point(230, 60)
        button1.Text = "Re-enter"
        AddHandler button1.Click, AddressOf Button1_Click
        Me.Controls.Add(textBox1)
        Me.Controls.Add(button1)

        ' Initialize TextBox and Button controls for PictureBox2
        textBox2.Location = New Point(20, 120)
        textBox2.Width = 200
        button2.Location = New Point(230, 120)
        button2.Text = "Re-enter"
        AddHandler button2.Click, AddressOf Button2_Click
        Me.Controls.Add(textBox2)
        Me.Controls.Add(button2)

        ' Initialize TextBox and Button controls for PictureBox3
        textBox3.Location = New Point(20, 120)
        textBox3.Width = 200
        button3.Location = New Point(230, 120)
        button3.Text = "Re-enter"
        AddHandler button3.Click, AddressOf Button3_Click
        Me.Controls.Add(textBox3)
        Me.Controls.Add(button3)

        ' Initialize TextBox and Button controls for PictureBox2
        textBox4.Location = New Point(20, 120)
        textBox4.Width = 200
        button4.Location = New Point(230, 120)
        button4.Text = "Re-enter"
        AddHandler button4.Click, AddressOf Button4_Click
        Me.Controls.Add(textBox4)
        Me.Controls.Add(button4)

        ' Initialize TextBox and Button controls for PictureBox2
        textBox5.Location = New Point(20, 120)
        textBox5.Width = 200
        button5.Location = New Point(230, 120)
        button5.Text = "Re-enter"
        AddHandler button5.Click, AddressOf Button5_Click
        Me.Controls.Add(textBox5)
        Me.Controls.Add(button5)

        ' Initialize TextBox and Button controls for PictureBox2
        textBox6.Location = New Point(20, 120)
        textBox6.Width = 200
        button6.Location = New Point(230, 120)
        button6.Text = "Re-enter"
        AddHandler button6.Click, AddressOf Button6_Click
        Me.Controls.Add(textBox6)
        Me.Controls.Add(button6)

        ' Initialize TextBox and Button controls for PictureBox2
        textBox7.Location = New Point(20, 120)
        textBox7.Width = 200
        button7.Location = New Point(230, 120)
        button7.Text = "Re-enter"
        AddHandler button7.Click, AddressOf Button7_Click
        Me.Controls.Add(textBox7)
        Me.Controls.Add(button7)

        ' Initialize TextBox and Button controls for PictureBox2
        textBox8.Location = New Point(20, 120)
        textBox8.Width = 200
        button8.Location = New Point(230, 120)
        button8.Text = "Re-enter"
        AddHandler button8.Click, AddressOf Button8_Click
        Me.Controls.Add(textBox8)
        Me.Controls.Add(button8)

        ' Initialize TextBox and Button controls for PictureBox2
        textBox9.Location = New Point(20, 120)
        textBox9.Width = 200
        button9.Location = New Point(230, 120)
        button9.Text = "Re-enter"
        AddHandler button9.Click, AddressOf Button9_Click
        Me.Controls.Add(textBox9)
        Me.Controls.Add(button9)

        ' Initialize TextBox and Button controls for PictureBox2
        textBox10.Location = New Point(20, 120)
        textBox10.Width = 200
        button10.Location = New Point(230, 120)
        button10.Text = "Re-enter"
        AddHandler button10.Click, AddressOf Button10_Click
        Me.Controls.Add(textBox10)
        Me.Controls.Add(button10)

        ' Initialize TextBox and Button controls for PictureBox2
        textBox11.Location = New Point(20, 120)
        textBox11.Width = 200
        button11.Location = New Point(230, 120)
        button11.Text = "Re-enter"
        AddHandler button11.Click, AddressOf Button11_Click
        Me.Controls.Add(textBox11)
        Me.Controls.Add(button11)

        ' Initialize TextBox and Button controls for PictureBox2
        textBox12.Location = New Point(20, 120)
        textBox12.Width = 200
        button12.Location = New Point(230, 120)
        button12.Text = "Re-enter"
        AddHandler button12.Click, AddressOf Button12_Click
        Me.Controls.Add(textBox12)
        Me.Controls.Add(button12)

        textBox12.Location = New Point(20, 120)
        textBox12.Width = 200
        button12.Location = New Point(230, 120)
        button12.Text = "Re-enter"
        AddHandler button12.Click, AddressOf Button12_Click
        Me.Controls.Add(textBox12)
        Me.Controls.Add(button12)
    End Sub




    ' Override WndProc to handle hotkey messages
    Protected Overrides Sub WndProc(ByRef m As Message)
        Const WM_HOTKEY As Integer = &H312
        If m.Msg = WM_HOTKEY Then
            Select Case m.WParam.ToInt32()
                Case HOTKEY_ID_F1
                    Debug.WriteLine("F1 was hit")
                    ExecutePictureBoxMacro("PictureBox1")
                Case HOTKEY_ID_F2
                    Debug.WriteLine("F2 was hit")
                    ExecutePictureBoxMacro("PictureBox2")
                Case HOTKEY_ID_F3
                    Debug.WriteLine("F3 was hit")
                    ExecutePictureBoxMacro("PictureBox3")
                Case HOTKEY_ID_F4
                    Debug.WriteLine("F4 was hit")
                    ExecutePictureBoxMacro("PictureBox4")
                Case HOTKEY_ID_F5
                    Debug.WriteLine("F5 was hit")
                    ExecutePictureBoxMacro("PictureBox5")
                Case HOTKEY_ID_F6
                    Debug.WriteLine("F6 was hit")
                    ExecutePictureBoxMacro("PictureBox6")
                Case HOTKEY_ID_F7
                    Debug.WriteLine("F7 was hit")
                    ExecutePictureBoxMacro("PictureBox7")
                Case HOTKEY_ID_F8
                    Debug.WriteLine("F8 was hit")
                    ExecutePictureBoxMacro("PictureBox8")
                Case HOTKEY_ID_F9
                    Debug.WriteLine("F9 was hit")
                    ExecutePictureBoxMacro("PictureBox9")
                Case HOTKEY_ID_F10
                    Debug.WriteLine("F10 was hit")
                    ExecutePictureBoxMacro("PictureBox10")
                Case HOTKEY_ID_F11
                    Debug.WriteLine("F11 was hit")
                    ExecutePictureBoxMacro("PictureBox11")
                Case HOTKEY_ID_F12
                    Debug.WriteLine("F12 was hit")
                    ExecutePictureBoxMacro("PictureBox12")
            End Select
        End If
        MyBase.WndProc(m)
    End Sub

    ' Unregister the hotkeys when the control is disposed
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            UnregisterHotKey(Me.Handle, HOTKEY_ID_F1)
            UnregisterHotKey(Me.Handle, HOTKEY_ID_F2)
            UnregisterHotKey(Me.Handle, HOTKEY_ID_F3)
            UnregisterHotKey(Me.Handle, HOTKEY_ID_F4)
            UnregisterHotKey(Me.Handle, HOTKEY_ID_F5)
            UnregisterHotKey(Me.Handle, HOTKEY_ID_F6)
            UnregisterHotKey(Me.Handle, HOTKEY_ID_F7)
            UnregisterHotKey(Me.Handle, HOTKEY_ID_F8)
            UnregisterHotKey(Me.Handle, HOTKEY_ID_F9)
            UnregisterHotKey(Me.Handle, HOTKEY_ID_F10)
            UnregisterHotKey(Me.Handle, HOTKEY_ID_F11)
            UnregisterHotKey(Me.Handle, HOTKEY_ID_F12)
            Debug.WriteLine("Hotkeys unregistered.")

            ' Close SQLite connection
            If connection.State = ConnectionState.Open Then
                connection.Close()
                Debug.WriteLine("SQLite connection closed.")
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Method to add information for a PictureBox and save to SQLite
    Private Sub AddInformationToPictureBox(ByVal pictureBoxName As String)
        Debug.WriteLine("AddInformationToPictureBox called for " & pictureBoxName)
        Dim existingInformation As String = If(pictureBoxInformation.ContainsKey(pictureBoxName), pictureBoxInformation(pictureBoxName), String.Empty)
        Dim prompt As String = If(String.IsNullOrEmpty(existingInformation), "Enter information for " & pictureBoxName, "Current information: " & existingInformation & vbCrLf & "Enter new information for " & pictureBoxName)
        Dim information As String = InputBox(prompt, "Information Input", existingInformation)
        If Not String.IsNullOrEmpty(information) Then
            ' Store the information in the dictionary
            pictureBoxInformation(pictureBoxName) = information
            Debug.WriteLine("Information added for " & pictureBoxName & ": " & information)

            ' Save to SQLite database
            SaveToDatabase(pictureBoxName, information)

            ' Update the corresponding TextBox
            If pictureBoxName = "PictureBox1" Then
                textBox1.Text = information
            ElseIf pictureBoxName = "PictureBox2" Then
                textBox2.Text = information
            ElseIf pictureBoxName = "PictureBox3" Then
                textBox3.Text = information
            ElseIf pictureBoxName = "PictureBox4" Then
                textBox4.Text = information
            ElseIf pictureBoxName = "PictureBox5" Then
                textBox5.Text = information
            ElseIf pictureBoxName = "PictureBox6" Then
                textBox6.Text = information
            ElseIf pictureBoxName = "PictureBox7" Then
                textBox7.Text = information
            ElseIf pictureBoxName = "PictureBox8" Then
                textBox8.Text = information
            ElseIf pictureBoxName = "PictureBox9" Then
                textBox9.Text = information
            ElseIf pictureBoxName = "PictureBox10" Then
                textBox10.Text = information
            ElseIf pictureBoxName = "PictureBox11" Then
                textBox11.Text = information
            ElseIf pictureBoxName = "PictureBox12" Then
                textBox12.Text = information
            End If
        Else
            Debug.WriteLine("No information entered for " & pictureBoxName)
        End If
    End Sub

    ' Macro action for a PictureBox
    Private Sub ExecutePictureBoxMacro(ByVal pictureBoxName As String)
        Debug.WriteLine(pictureBoxName & " macro action executed")
        ' Retrieve the information from the dictionary
        If pictureBoxInformation.ContainsKey(pictureBoxName) Then
            Dim information As String = pictureBoxInformation(pictureBoxName)
            Debug.WriteLine("Information retrieved from " & pictureBoxName & ": " & information)
            ' Simulate pasting the information into a focused text box
            SendKeys.SendWait(information)
        Else
            Debug.WriteLine("No information found for " & pictureBoxName)
        End If
    End Sub

    ' Save information to SQLite database, updating existing records if necessary
    Private Sub SaveToDatabase(ByVal pictureBoxName As String, ByVal information As String)
        Try
            Dim commandText As String = "INSERT INTO PictureBoxData (PictureBoxName, Information) VALUES (@pictureBoxName, @information) " &
                                    "ON CONFLICT(PictureBoxName) DO UPDATE SET Information = excluded.Information;"
            Using cmd As New SQLiteCommand(commandText, connection)
                cmd.Parameters.AddWithValue("@pictureBoxName", pictureBoxName)
                cmd.Parameters.AddWithValue("@information", information)
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                Debug.WriteLine("Data saved to SQLite database. Rows affected: " & rowsAffected)
            End Using
        Catch ex As Exception
            Debug.WriteLine($"Error saving data to SQLite: {ex.Message}")
        End Try
    End Sub


    ' Click event handler for PictureBox1
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        ' Call the method to add information for PictureBox1
        AddInformationToPictureBox("PictureBox1")
    End Sub

    ' Click event handler for PictureBox2
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        ' Call the method to add information for PictureBox2
        AddInformationToPictureBox("PictureBox2")
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        ' Call the method to add information for PictureBox1
        AddInformationToPictureBox("PictureBox3")
    End Sub

    ' Click event handler for PictureBox2
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        ' Call the method to add information for PictureBox2
        AddInformationToPictureBox("PictureBox4")
    End Sub
    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        ' Call the method to add information for PictureBox1
        AddInformationToPictureBox("PictureBox5")
    End Sub

    ' Click event handler for PictureBox2
    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        ' Call the method to add information for PictureBox2
        AddInformationToPictureBox("PictureBox6")
    End Sub
    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        ' Call the method to add information for PictureBox1
        AddInformationToPictureBox("PictureBox7")
    End Sub

    ' Click event handler for PictureBox2
    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        ' Call the method to add information for PictureBox2
        AddInformationToPictureBox("PictureBox8")
    End Sub
    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        ' Call the method to add information for PictureBox1
        AddInformationToPictureBox("PictureBox9")
    End Sub

    ' Click event handler for PictureBox2
    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click
        ' Call the method to add information for PictureBox2
        AddInformationToPictureBox("PictureBox10")
    End Sub
    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click
        ' Call the method to add information for PictureBox2
        AddInformationToPictureBox("PictureBox11")
    End Sub
    Private Sub PictureBox12_Click(sender As Object, e As EventArgs) Handles PictureBox12.Click
        ' Call the method to add information for PictureBox2
        AddInformationToPictureBox("PictureBox12")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        ' Re-enter information for PictureBox1
        AddInformationToPictureBox("PictureBox1")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        ' Re-enter information for PictureBox2
        AddInformationToPictureBox("PictureBox2")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        ' Re-enter information for PictureBox3
        AddInformationToPictureBox("PictureBox3")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        ' Re-enter information for PictureBox4
        AddInformationToPictureBox("PictureBox4")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        ' Re-enter information for PictureBox5
        AddInformationToPictureBox("PictureBox5")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        ' Re-enter information for PictureBox6
        AddInformationToPictureBox("PictureBox6")
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        ' Re-enter information for PictureBox7
        AddInformationToPictureBox("PictureBox7")
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)
        ' Re-enter information for PictureBox8
        AddInformationToPictureBox("PictureBox8")
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)
        ' Re-enter information for PictureBox9
        AddInformationToPictureBox("PictureBox9")
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs)
        ' Re-enter information for PictureBox10
        AddInformationToPictureBox("PictureBox10")
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs)
        ' Re-enter information for PictureBox11
        AddInformationToPictureBox("PictureBox11")
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs)
        ' Re-enter information for PictureBox12
        AddInformationToPictureBox("PictureBox12")
    End Sub

    Private Sub MacInjection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ensure the control can receive focus
        Me.Focus()
        Debug.WriteLine("MacInjection control loaded and focused.")

        ' Load information from database and display it
        LoadInformationFromDatabase()
    End Sub

    ' Load information from database
    Private Sub LoadInformationFromDatabase()
        Try
            Dim commandText As String = "SELECT PictureBoxName, Information FROM PictureBoxData;"
            Using cmd As New SQLiteCommand(commandText, connection)
                Using reader As SQLiteDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim pictureBoxName As String = reader("PictureBoxName").ToString()
                        Dim information As String = reader("Information").ToString()
                        pictureBoxInformation(pictureBoxName) = information

                        ' Set the information in the corresponding TextBox
                        Select Case pictureBoxName
                            Case "PictureBox1"
                                textBox1.Text = information
                            Case "PictureBox2"
                                textBox2.Text = information
                            Case "PictureBox3"
                                textBox3.Text = information
                            Case "PictureBox4"
                                textBox4.Text = information
                            Case "PictureBox5"
                                textBox5.Text = information
                            Case "PictureBox6"
                                textBox6.Text = information
                            Case "PictureBox7"
                                textBox7.Text = information
                            Case "PictureBox8"
                                textBox8.Text = information
                            Case "PictureBox9"
                                textBox9.Text = information
                            Case "PictureBox10"
                                textBox10.Text = information
                            Case "PictureBox11"
                                textBox11.Text = information
                            Case "PictureBox12"
                                textBox12.Text = information
                        End Select
                    End While
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine($"Error loading data from SQLite: {ex.Message}")
        End Try
    End Sub

    ' Create the PictureBoxData table if it does not exist
    Private Sub CreateTableIfNotExists()
        Try
            Dim commandText As String = "CREATE TABLE IF NOT EXISTS PictureBoxData (PictureBoxName TEXT PRIMARY KEY, Information TEXT);"
            Using cmd As New SQLiteCommand(commandText, connection)
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Debug.WriteLine($"Error creating table: {ex.Message}")
        End Try
    End Sub

End Class