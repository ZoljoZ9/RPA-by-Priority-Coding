Public Class EditorForm
    ' Reference to the calling MacInjection form
    Private callingForm As MacInjection
    Public Property FormattedContent As String

    ' Constructor that accepts a reference to MacInjection
    Public Sub New(ByVal parentForm As MacInjection)
        InitializeComponent()

        ' Set the reference to the calling MacInjection form
        Me.callingForm = parentForm

        ' Initialize WebView2 and load the Quill editor
        InitializeWebViewAsync()
    End Sub

    ' Initialize WebView2 and load Quill editor
    Private Async Sub InitializeWebViewAsync()
        Try ' Load the local HTML file for Quill editor
            Await webView21.EnsureCoreWebView2Async(Nothing)
            webView21.Source = New Uri("file:///C:/Users/matth/OneDrive/Desktop/New%20Laptop/Code/PriorityCoding/PriorityCoding/quill-editor.html")
            Debug.WriteLine("WebView2 loaded Quill editor successfully.")
        Catch ex As Exception
            Debug.WriteLine("Error initializing WebView2: " & ex.Message)
        End Try
    End Sub

    ' Set existing content into Quill editor
    Public Sub SetContent(content As String)
        ' Inject content into Quill editor using JavaScript
        Dim script As String = $"quill.setText('{content.Replace("'", "\'")}');"
        webView21.ExecuteScriptAsync(script)
    End Sub

    ' Retrieve content from Quill editor
    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Retrieve content from the Quill editor
        Await GetEditorContent()

        ' Ensure content is not null or empty before passing it back
        If String.IsNullOrWhiteSpace(FormattedContent) Then
            MessageBox.Show("No content to save!")
            Return
        End If

        ' Debugging: Check if FormattedContent has been properly populated
        Debug.WriteLine("FormattedContent after GetEditorContent: " & FormattedContent)

        ' Call the method in MacInjection to pass back the formatted content
        callingForm.FormattedContentFromEditor(FormattedContent)

        ' Close the form with an OK result
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub





    ' Retrieve content from Quill editor
    Public Async Function GetEditorContent() As Task
        Try
            ' This retrieves the content from the Quill editor using JavaScript
            Dim result As String = Await webView21.ExecuteScriptAsync("quill.root.innerHTML;")

            ' Check if the result contains valid HTML
            If String.IsNullOrWhiteSpace(result) Then
                Debug.WriteLine("No content retrieved from Quill editor.")
            Else
                Debug.WriteLine("Content retrieved from Quill Editor: " & result)
            End If

            ' Assign the result to the FormattedContent property
            FormattedContent = result.Trim()

        Catch ex As Exception
            ' Log any errors during JavaScript execution
            Debug.WriteLine("Error retrieving content from Quill editor: " & ex.Message)
        End Try
    End Function


End Class
