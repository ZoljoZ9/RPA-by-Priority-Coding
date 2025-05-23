Imports System.IO

Module PathHelper
    Public Function GetUserDocumentsPriorityPath() As String
        Dim basePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "PriorityCoding")
        If Not Directory.Exists(basePath) Then
            Directory.CreateDirectory(basePath)
        End If
        Return basePath
    End Function
End Module
