Imports System.Runtime.InteropServices
Imports System.Windows.Forms

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

    ' Dictionary to store information for each PictureBox
    Private pictureBoxInformation As New Dictionary(Of String, String)

    Public Sub New()
        InitializeComponent()
        ' Register the hotkeys
        RegisterHotKey(Me.Handle, HOTKEY_ID_F1, MOD_NONE, CUInt(Keys.F1))
        RegisterHotKey(Me.Handle, HOTKEY_ID_F2, MOD_NONE, CUInt(Keys.F2))
        Debug.WriteLine("Hotkeys registered.")
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
            End Select
        End If
        MyBase.WndProc(m)
    End Sub

    ' Unregister the hotkeys when the control is disposed
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            UnregisterHotKey(Me.Handle, HOTKEY_ID_F1)
            UnregisterHotKey(Me.Handle, HOTKEY_ID_F2)
            Debug.WriteLine("Hotkeys unregistered.")
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Method to add information for a PictureBox
    Private Sub AddInformationToPictureBox(ByVal pictureBoxName As String)
        Debug.WriteLine("AddInformationToPictureBox called for " & pictureBoxName)
        Dim information As String = InputBox("Enter information for " & pictureBoxName, "Information Input")
        If Not String.IsNullOrEmpty(information) Then
            ' Store the information in the dictionary
            pictureBoxInformation(pictureBoxName) = information
            Debug.WriteLine("Information added for " & pictureBoxName & ": " & information)
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

    Private Sub MacInjection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ensure the control can receive focus
        Me.Focus()
        Debug.WriteLine("MacInjection control loaded and focused.")
    End Sub

End Class
