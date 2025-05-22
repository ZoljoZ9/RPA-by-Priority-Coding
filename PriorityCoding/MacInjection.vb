Imports System.Data.SQLite
Imports System.IO
Imports System.Windows.Forms
Imports System.Text
Imports System.Runtime.InteropServices

Imports System.Web



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
    ' Declare the WebView2 controls at the class level
    Private WithEvents webView21 As New Microsoft.Web.WebView2.WinForms.WebView2()
    Private WithEvents webView22 As New Microsoft.Web.WebView2.WinForms.WebView2()
    ' Add declarations for other WebView2 controls if necessary

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
    Private Async Sub InitializeWebViewControls()
        Try
            ' Initialize WebView2 for PictureBox1
            Await webView21.EnsureCoreWebView2Async(Nothing)
            webView21.Source = New Uri("about:blank") ' Load blank initially or any valid URL
            Me.Controls.Add(webView21)

            ' Initialize WebView2 for PictureBox2 (if needed)
            Await webView22.EnsureCoreWebView2Async(Nothing)
            webView22.Source = New Uri("about:blank") ' Load blank initially or any valid URL
            Me.Controls.Add(webView22)

        Catch ex As Exception
            Debug.WriteLine($"Error initializing WebView2: {ex.Message}")
        End Try
    End Sub

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

        ' Initialize the WebView2 controls for displaying HTML content
        InitializeWebViewControls()

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
                    ExecutePictureBoxMacroAsync("PictureBox1")
                Case HOTKEY_ID_F2
                    Debug.WriteLine("F2 was hit")
                    ExecutePictureBoxMacroAsync("PictureBox2")
                Case HOTKEY_ID_F3
                    Debug.WriteLine("F3 was hit")
                    ExecutePictureBoxMacroAsync("PictureBox3")
                Case HOTKEY_ID_F4
                    Debug.WriteLine("F4 was hit")
                    ExecutePictureBoxMacroAsync("PictureBox4")
                Case HOTKEY_ID_F5
                    Debug.WriteLine("F5 was hit")
                    ExecutePictureBoxMacroAsync("PictureBox5")
                Case HOTKEY_ID_F6
                    Debug.WriteLine("F6 was hit")
                    ExecutePictureBoxMacroAsync("PictureBox6")
                Case HOTKEY_ID_F7
                    Debug.WriteLine("F7 was hit")
                    ExecutePictureBoxMacroAsync("PictureBox7")
                Case HOTKEY_ID_F8
                    Debug.WriteLine("F8 was hit")
                    ExecutePictureBoxMacroAsync("PictureBox8")
                Case HOTKEY_ID_F9
                    Debug.WriteLine("F9 was hit")
                    ExecutePictureBoxMacroAsync("PictureBox9")
                Case HOTKEY_ID_F10
                    Debug.WriteLine("F10 was hit")
                    ExecutePictureBoxMacroAsync("PictureBox10")
                Case HOTKEY_ID_F11
                    Debug.WriteLine("F11 was hit")
                    ExecutePictureBoxMacroAsync("PictureBox11")
                Case HOTKEY_ID_F12
                    Debug.WriteLine("F12 was hit")
                    ExecutePictureBoxMacroAsync("PictureBox12")
            End Select
        End If
        MyBase.WndProc(m)
    End Sub

    Private Async Sub ExecutePictureBoxMacroAsync(ByVal pictureBoxName As String)
        Debug.WriteLine($"{pictureBoxName} macro action executed")

        ' Reload latest content
        Await ReloadPictureBoxInformationFromDatabase(pictureBoxName)

        If pictureBoxInformation.ContainsKey(pictureBoxName) Then
            Dim html As String = pictureBoxInformation(pictureBoxName)

            ' Create plain text fallback
            Dim plainText As String = HtmlToPlainText(html)

            ' Format HTML clipboard block
            Dim htmlClipboard As String = WrapHtmlClipboardFormat(html)

            ' Populate DataObject for clipboard
            Dim dataObj As New DataObject()
            dataObj.SetData(DataFormats.Html, htmlClipboard)
            dataObj.SetData(DataFormats.Text, plainText)
            dataObj.SetData(DataFormats.UnicodeText, plainText)

            Clipboard.SetDataObject(dataObj, True)

            ' Simulate Ctrl+V paste
            SendKeys.SendWait("^v")
        Else
            Debug.WriteLine("No content found for " & pictureBoxName)
        End If
    End Sub

    Private Function WrapHtmlClipboardFormat(htmlFragment As String) As String
        Const HeaderTemplate As String =
        "Version:0.9" & vbCrLf &
        "StartHTML:{0:00000000}" & vbCrLf &
        "EndHTML:{1:00000000}" & vbCrLf &
        "StartFragment:{2:00000000}" & vbCrLf &
        "EndFragment:{3:00000000}" & vbCrLf

        Dim startFragment = "<!--StartFragment-->"
        Dim endFragment = "<!--EndFragment-->"
        Dim fullHtmlBody = $"<html><body>{startFragment}{htmlFragment}{endFragment}</body></html>"

        Dim startHTML = HeaderTemplate.Length
        Dim startFrag = fullHtmlBody.IndexOf(startFragment) + startHTML
        Dim endFrag = fullHtmlBody.IndexOf(endFragment) + endFragment.Length + startHTML
        Dim endHTML = fullHtmlBody.Length + startHTML

        Dim header = String.Format(HeaderTemplate, startHTML, endHTML, startFrag, endFrag)

        Return header & fullHtmlBody
    End Function


    Private Function HtmlToPlainText(html As String) As String
        Dim browser As New WebBrowser()
        browser.DocumentText = html
        Do While browser.ReadyState <> WebBrowserReadyState.Complete
            Application.DoEvents()
        Loop
        Return browser.Document.Body.InnerText
    End Function



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
    Private currentPictureBoxName As String

    ' Method to add information for a PictureBox and save to SQLite
    ' Method to receive formatted content from EditorForm
    ' Method to receive formatted content from EditorForm
    ' Method to receive formatted content from EditorForm
    ' Method to receive formatted content from EditorForm
    ' Debug added here to trace content passed from Quill editor
    Public Sub FormattedContentFromEditor(content As String)
        ' Debugging: Print the received content
        Debug.WriteLine("Content from Quill Editor: " & content)

        ' Ensure the content is not empty
        If String.IsNullOrWhiteSpace(content) Then
            Debug.WriteLine("No content to save.")
            Return
        End If

        ' Save the content to the database and update the UI
        SaveToDatabase(currentPictureBoxName, content)
        UpdateTextBox(currentPictureBoxName, content)
    End Sub





    ' Method to open EditorForm for a specific PictureBox
    ' Method to handle the content from the Quill editor and update the TextBox
    Private Sub AddInformationToPictureBox(ByVal pictureBoxName As String)
        ' Set currentPictureBoxName for later use
        currentPictureBoxName = pictureBoxName

        ' Retrieve existing information for the PictureBox (if any)
        Dim existingInformation As String = If(pictureBoxInformation.ContainsKey(pictureBoxName), pictureBoxInformation(pictureBoxName), String.Empty)

        ' Create a new instance of EditorForm and pass the current instance of MacInjection
        Dim editorForm As New EditorForm(Me)

        ' Load existing content into Quill editor if it exists
        If Not String.IsNullOrEmpty(existingInformation) Then
            editorForm.SetContent(existingInformation) ' Pass the existing content to Quill
        End If

        ' Show the editor form as a dialog
        If editorForm.ShowDialog() = DialogResult.OK Then
            ' The Quill editor was closed successfully and content was updated in FormattedContentFromEditor
            Debug.WriteLine("EditorForm closed and content updated successfully.")
        Else
            Debug.WriteLine("EditorForm was canceled.")
        End If
    End Sub




    ' Method to update TextBox/WebView2 based on PictureBox name
    Private Async Sub UpdateTextBox(ByVal pictureBoxName As String, ByVal content As String)
        Try
            If Not String.IsNullOrWhiteSpace(content) Then
                ' Decode HTML entities and pass valid HTML to WebView2
                Dim decodedContent As String = System.Net.WebUtility.HtmlDecode(content)
                Dim htmlContent As String = $"<html><body>{decodedContent}</body></html>"

                ' Ensure WebView2 is initialized before using it
                Await webView21.EnsureCoreWebView2Async(Nothing)

                Select Case pictureBoxName
                    Case "PictureBox1"
                        Debug.WriteLine($"Updating WebView2 for PictureBox1 with content: {decodedContent}")
                        webView21.NavigateToString(htmlContent)
                        ' Handle other PictureBoxes as needed
                End Select
            Else
                Debug.WriteLine("Content is empty or null.")
            End If
        Catch ex As Exception
            Debug.WriteLine($"Error in UpdateTextBox for {pictureBoxName}: {ex.Message}")
        End Try
    End Sub






    ' Save information to SQLite database, updating existing records if necessary
    Private Sub SaveToDatabase(ByVal pictureBoxName As String, ByVal information As String)
        Try
            ' Ensure content is not null or empty
            If String.IsNullOrWhiteSpace(information) Then
                Debug.WriteLine($"Cannot save empty or null content for {pictureBoxName}")
                Return
            End If

            ' Debugging: Log what we are saving
            Debug.WriteLine($"Saving content for {pictureBoxName}: {information}")

            ' Insert or update the content in the SQLite database
            Dim commandText As String = "INSERT INTO MyTable (Name, Content) " &
                                    "VALUES (@pictureBoxName, @information) " &
                                    "ON CONFLICT(Name) DO UPDATE SET Content = excluded.Content;"

            Using cmd As New SQLiteCommand(commandText, connection)
                cmd.Parameters.AddWithValue("@pictureBoxName", pictureBoxName)
                cmd.Parameters.AddWithValue("@information", information)
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                Debug.WriteLine($"Data saved to SQLite database. Rows affected: {rowsAffected}, Information: {information}")
            End Using

        Catch ex As Exception
            ' Log any errors during the saving process
            Debug.WriteLine($"Error saving data to SQLite: {ex.Message}")
        End Try
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

        ' Load information from the database and display it
        LoadInformationFromDatabase()
    End Sub

    ' Load information from the database
    Public Sub LoadInformationFromDatabase()
        Try
            Dim commandText As String = "SELECT Name, Content FROM MyTable;"
            Using cmd As New SQLiteCommand(commandText, connection)
                Using reader As SQLiteDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim pictureBoxName As String = reader("Name").ToString()
                        Dim content As String = reader("Content").ToString()

                        ' Log retrieved data
                        Debug.WriteLine($"Retrieved from database: {pictureBoxName} - {content}")

                        ' Decode the HTML content if necessary
                        Dim decodedContent As String = System.Net.WebUtility.HtmlDecode(content)

                        ' Store the decoded content in the dictionary
                        pictureBoxInformation(pictureBoxName) = decodedContent

                        ' Set the information in the corresponding TextBox/WebView2
                        UpdateTextBox(pictureBoxName, decodedContent)
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
            ' Ensure the connection is open
            If connection Is Nothing Then
                connection = New SQLiteConnection(connectionString)
            End If
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If

            ' SQL command to create the table if it does not exist
            Dim commandText As String = "CREATE TABLE IF NOT EXISTS MyTable (" &
                                        "ID INTEGER PRIMARY KEY AUTOINCREMENT, " &
                                        "Name TEXT NOT NULL UNIQUE, " &
                                        "Content TEXT);"

            ' Execute the command to create the table
            Using cmd As New SQLiteCommand(commandText, connection)
                cmd.ExecuteNonQuery()
            End Using

            ' Log table creation or confirmation
            Debug.WriteLine("Table 'MyTable' is created or already exists.")

        Catch ex As Exception
            ' Log any errors during table creation
            Debug.WriteLine($"Error creating table 'MyTable': {ex.Message}")
        End Try
    End Sub
    Private Async Function ReloadPictureBoxInformationFromDatabase(ByVal pictureBoxName As String) As Task
        Try
            ' SQL command to get the latest information for the specified PictureBox
            Dim commandText As String = "SELECT Content FROM MyTable WHERE Name = @pictureBoxName;"
            Using cmd As New SQLiteCommand(commandText, connection)
                cmd.Parameters.AddWithValue("@pictureBoxName", pictureBoxName)
                Using reader As SQLiteDataReader = Await cmd.ExecuteReaderAsync()
                    If reader.Read() Then
                        Dim information As String = reader("Content").ToString()
                        ' Decode the HTML content if necessary
                        Dim decodedInformation As String = System.Net.WebUtility.HtmlDecode(information)

                        ' Update the dictionary with the latest data
                        pictureBoxInformation(pictureBoxName) = decodedInformation

                        ' Log retrieved data for debugging
                        Debug.WriteLine($"Latest data for {pictureBoxName}: {decodedInformation}")
                    Else
                        Debug.WriteLine($"No data found in the database for {pictureBoxName}")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine($"Error reloading data from SQLite for {pictureBoxName}: {ex.Message}")
        End Try
    End Function



End Class