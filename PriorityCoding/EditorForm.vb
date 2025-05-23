' Refactored version with proper RTE population, delayed WebView2 load handling, and fixed DB saving

Imports Microsoft.Web.WebView2.Core
Imports System.IO
Imports System.Diagnostics
Imports Newtonsoft.Json
Imports PriorityCoding.PathHelper

Public Class EditorForm
    Private callingForm As MacInjection
    Public Property FormattedContent As String
    Private isWebViewReady As Boolean = False
    Private queuedContent As String = Nothing
    Private htmlEditorPath As String

    Public Sub New(ByVal parentForm As MacInjection)
        InitializeComponent()
        Me.callingForm = parentForm

        Try
            Dim destDir As String = GetUserDocumentsPriorityPath()
            Dim destPath As String = Path.Combine(destDir, "quill-editor.html")
            htmlEditorPath = destPath

            Dim sourcePath As String = Path.Combine(Application.StartupPath, "quill-editor.html")
            If Not File.Exists(sourcePath) Then
                MessageBox.Show("Missing source HTML file: " & sourcePath)
                Return
            End If

            If Not File.Exists(destPath) Then
                File.Copy(sourcePath, destPath)
            End If

            Debug.WriteLine("Quill Editor HTML Path: " & htmlEditorPath)

        Catch ex As Exception
            MessageBox.Show("Error preparing HTML file: " & ex.Message)
            Return
        End Try

        InitializeWebViewAsync()
    End Sub



    Private Async Sub InitializeWebViewAsync()
        Try
            Dim userDataFolder As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PriorityCoding\WebView2Cache")
            Dim env As CoreWebView2Environment = Await CoreWebView2Environment.CreateAsync(Nothing, userDataFolder)
            Await webView21.EnsureCoreWebView2Async(env)

            AddHandler webView21.CoreWebView2.NavigationCompleted, AddressOf OnWebViewNavigationCompleted

            If Not File.Exists(htmlEditorPath) Then
                MessageBox.Show("HTML file not found at: " & htmlEditorPath)
                Return
            End If

            Dim htmlContent As String = File.ReadAllText(htmlEditorPath)
            webView21.NavigateToString(htmlContent)

        Catch ex As Exception
            MessageBox.Show("Error initializing WebView2: " & ex.Message)
        End Try
    End Sub


    Private Sub OnWebViewNavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs)
        isWebViewReady = True
        If Not String.IsNullOrEmpty(queuedContent) Then
            InjectContent(queuedContent)
            queuedContent = Nothing
        End If
    End Sub

    Public Sub SetContent(content As String)
        If isWebViewReady Then
            InjectContent(content)
        Else
            queuedContent = content
        End If
    End Sub

    Private Sub InjectContent(content As String)
        Dim safeHtml As String = content.Replace("\", "\\").Replace("""", "\""")
        Dim script As String = "quill.clipboard.dangerouslyPasteHTML(""" & safeHtml & """);"
        webView21.ExecuteScriptAsync(script)
    End Sub

    Public Function GetUserDocumentsPriorityPath() As String
        Dim basePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "PriorityCoding")
        If Not Directory.Exists(basePath) Then
            Directory.CreateDirectory(basePath)
        End If
        Return basePath
    End Function

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Await GetEditorContent()
        If String.IsNullOrWhiteSpace(FormattedContent) Then
            MessageBox.Show("No content to save!")
            Return
        End If

        Debug.WriteLine("[SAVE] Sending content to MacInjection: " & FormattedContent)
        callingForm.FormattedContentFromEditor(FormattedContent)

        ' Refresh data after save
        If callingForm IsNot Nothing Then
            Try
                callingForm.LoadInformationFromDatabase()
            Catch ex As Exception
                Debug.WriteLine("Error refreshing data after save: " & ex.Message)
            End Try
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Public Async Function GetEditorContent() As Task
        Try
            Dim result As String = Await webView21.ExecuteScriptAsync("quill.root.innerHTML;")
            If Not String.IsNullOrEmpty(result) Then
                FormattedContent = JsonConvert.DeserializeObject(Of String)(result)
                Debug.WriteLine("[GET] Retrieved from WebView2: " & FormattedContent)
            End If
        Catch ex As Exception
            Debug.WriteLine("Error retrieving content: " & ex.Message)
        End Try
    End Function
End Class
