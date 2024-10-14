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

        ' Call the method to create the table
        CreateTable()
    End Sub


    Public Sub CreateTable()
        Using connection As New SQLiteConnection(connectionString)
            connection.Open()

            ' SQL statement to create the table if it doesn't exist
            Dim commandText As String = "
        CREATE TABLE IF NOT EXISTS MyTable (
            ID INTEGER PRIMARY KEY AUTOINCREMENT, 
            Name TEXT, 
            Content TEXT
        );"

            ' Execute the command
            Using command As New SQLiteCommand(commandText, connection)
                command.ExecuteNonQuery()
            End Using

            ' Output a message for debugging purposes
            Debug.WriteLine("Table 'MyTable' created or already exists.")
        End Using
    End Sub


    ' Insert data with Quill-formatted text and optional binary data
    Public Sub InsertData(name As String, content As String)
        Using connection As New SQLiteConnection(connectionString)
            connection.Open()

            ' Adjust the SQL to handle content as a string
            Dim commandText As String = "INSERT INTO MyTable (Name, Content) VALUES (@name, @content);"
            Dim command As New SQLiteCommand(commandText, connection)
            command.Parameters.AddWithValue("@name", name)
            command.Parameters.AddWithValue("@content", content) ' Save the formatted Quill content

            command.ExecuteNonQuery()
        End Using
    End Sub



    ' Get all data from the table
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

    Public Sub InsertOrUpdateData(name As String, content As String)
        Using connection As New SQLiteConnection(connectionString)
            connection.Open()

            ' Insert or update the content in the database
            Dim commandText As String = "INSERT INTO MyTable (Name, Content) " &
                                    "VALUES (@name, @content) " &
                                    "ON CONFLICT(Name) DO UPDATE SET Content = excluded.Content;"

            Using command As New SQLiteCommand(commandText, connection)
                command.Parameters.AddWithValue("@name", name)
                command.Parameters.AddWithValue("@content", content)
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Class
