Imports System.Data.SQLite

Public Class DatabaseHelper
    Private connectionString As String

    Public Sub New()
        ' Construct the connection string
        Dim dbFilePath As String = System.IO.Path.Combine(Application.StartupPath, "mydatabase.db")
        connectionString = $"Data Source={dbFilePath};Version=3;"

        ' Ensure the database file exists or create it
        If Not System.IO.File.Exists(dbFilePath) Then
            SQLiteConnection.CreateFile(dbFilePath)
        End If
    End Sub

    Public Sub CreateTable()
        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Dim commandText As String = "CREATE TABLE IF NOT EXISTS MyTable (ID INTEGER PRIMARY KEY, Name TEXT);"
            Dim command As New SQLiteCommand(commandText, connection)
            command.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub InsertData(id As Integer, name As String)
        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Dim commandText As String = "INSERT INTO MyTable (ID, Name) VALUES (@id, @name);"
            Dim command As New SQLiteCommand(commandText, connection)
            command.Parameters.AddWithValue("@id", id)
            command.Parameters.AddWithValue("@name", name)
            command.ExecuteNonQuery()
        End Using
    End Sub

    Public Function GetData() As DataTable
        Dim table As New DataTable()
        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Dim commandText As String = "SELECT * FROM MyTable;"
            Dim command As New SQLiteCommand(commandText, connection)
            Dim adapter As New SQLiteDataAdapter(command)
            adapter.Fill(table)
        End Using
        Return table
    End Function
End Class
