Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Net

Public Class MainScreen
    Private notifyIcon As NotifyIcon

    Private Sub MainScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the system tray icon
        InitializeSystemTrayIcon()

        Me.KeyPreview = True

    End Sub

    ' Handler for restoring the form from the system tray
    Private Sub MenuItemRestore_Click(sender As Object, e As EventArgs)
        ' Restore the form
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        ' Hide the system tray icon
        notifyIcon.Visible = False
    End Sub

    ' Override the OnFormClosing event to minimize the form to the system tray when closed
    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        MyBase.OnFormClosing(e)

        If e.CloseReason = CloseReason.UserClosing Then
            ' Minimize to system tray instead of closing
            e.Cancel = True
            Me.WindowState = FormWindowState.Minimized
            Me.Hide()
            notifyIcon.ShowBalloonTip(1000, "Application Minimized", "The application has been minimized to the system tray.", ToolTipIcon.Info)
        End If
    End Sub

    ' Method to initialize the system tray icon
    Private Sub InitializeSystemTrayIcon()
        ' Initialize the NotifyIcon
        notifyIcon = New NotifyIcon With {
            .Icon = SystemIcons.Application,
            .Visible = True
        }

        ' Add a context menu to the notifyIcon
        Dim contextMenu As New ContextMenuStrip()
        Dim menuItemRestore As New ToolStripMenuItem("Restore")
        AddHandler menuItemRestore.Click, AddressOf MenuItemRestore_Click
        contextMenu.Items.Add(menuItemRestore)
        notifyIcon.ContextMenuStrip = contextMenu
    End Sub

    Public Sub ShowDocUnderstanding()
        Panel1.Visible = False
        DocUnderstanding1.Visible = True
        CRMcopilot1.visable = False
        MacInjection1.Visible = False
        DocUnderstanding1.BringToFront()
    End Sub

    Public Sub ShowMacInjection()
        Panel1.Visible = False
        DocUnderstanding1.Visible = False
        CRMcopilot1.visable = False
        MacInjection1.Visible = True
        MacInjection1.BringToFront()
    End Sub

    Public Sub ShowCRMcopilot()
        Panel1.Visible = False
        DocUnderstanding1.Visible = False
        MacInjection1.Visible = False
        CRMcopilot1.Visible = True
        CRMcopilot1.BringToFront()
    End Sub


    ' Inside the MainScreen class
    Private WithEvents docunderstanding As New DocUnderstanding()

    ' Event handler for the Scroll event of the VScrollBar
    ' Rename one of the event handlers to make them unique

    Private Sub MacInjection1_Load(sender As Object, e As EventArgs) Handles MacInjection1.Load
        ' No additional code needed here for now
    End Sub

    Private Sub SideBar1_Load(sender As Object, e As EventArgs)
    End Sub

    Private Sub SideBar2_Load(sender As Object, e As EventArgs)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
