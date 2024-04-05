Imports OfficeOpenXml
Imports HtmlAgilityPack
Imports System.IO
Imports System.Net
Imports System.Text
Imports DocumentFormat.OpenXml.Packaging
Imports UglyToad.PdfPig
Imports UglyToad.PdfPig.Content
Imports System.Windows.Forms
Imports System.ComponentModel



Partial Class ProfileScreen
    Inherits System.Windows.Forms.Form



    ' Designer-generated variables
    Private components As System.ComponentModel.IContainer
    Private WithEvents Dude As Button
    Private scrapedData As New List(Of SearchResult) ' This goes at the top of your form class
    Private WithEvents scrapeWebsiteButton As Button
    Private WithEvents scrapeFileButton As Button
    Friend WithEvents SplitContainer1 As SplitContainer
    Private WithEvents introductionLabel As Label

    ' Constructor
    Public Sub New()
        InitializeComponent()

        ' Set the license context for EPPlus
        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial

        ' Initialize the Dude button
        Dude = New Button With {
        .Text = "Dude",
        .Size = New Size(150, 50),
        .Location = New Point(10, 10),
        .BackColor = ColorTranslator.FromHtml("#333333"), ' Set the button color to #001f0f
        .ForeColor = Color.White ' Set the text color to white
    }

        ' Add Dude button to Panel1 (sidebar)
        Me.SplitContainer1.Panel1.Controls.Add(Dude)

        ' After initializing the Dude button
        Dude.Location = New Point((SplitContainer1.Panel1.Width - Dude.Width) / 2, Dude.Location.Y)


    End Sub

    ' Event handler for the general scrape information button click event
    Private Sub Dude_Click(sender As Object, e As EventArgs) Handles Dude.Click
        ' Call the ScrapeInfoButton_Click method
        ScrapeInfoButton_Click(sender, e)
    End Sub

    ' Event handler for the general scrape information button click event
    Private Sub ScrapeInfoButton_Click(sender As Object, e As EventArgs)
        ' Initialize the introduction label
        Dim introductionLabel As New Label With {
        .Text = "Welcome to the Scrape Information tool. In this tool, you will be able to scrape important information that is needed to save manual, repetitive, and monotonous. Please choose an option below, to either scrape information from a website or a file saved to your computer:",
        .ForeColor = Color.White,
        .Location = New Point(10, 10),
        .Size = New Size(Me.SplitContainer1.Panel2.Width - 20, 60),
        .AutoSize = False
    }
        ' Modify the introduction label initialization
        introductionLabel.AutoSize = True
        introductionLabel.MaximumSize = New Size(Me.SplitContainer1.Panel2.Width - 20, 0) ' Allow the label to grow in height

        ' Initialize the scrape website button
        scrapeWebsiteButton = New Button With {
        .Text = "Scrape Website",
        .Size = New Size(150, 50),
        .Location = New Point(10, introductionLabel.Bottom + 60),
        .BackColor = ColorTranslator.FromHtml("#333333"),
        .ForeColor = Color.White
    }

        ' Initialize the scrape file button
        scrapeFileButton = New Button With {
        .Text = "Scrape File",
        .Size = New Size(150, 50),
        .Location = New Point(10, scrapeWebsiteButton.Bottom + 25),
        .BackColor = ColorTranslator.FromHtml("#333333"),
        .ForeColor = Color.White
    }

        ' Add event handlers for the new buttons
        AddHandler scrapeWebsiteButton.Click, AddressOf ScrapeWebsiteButton_Click
        AddHandler scrapeFileButton.Click, AddressOf ScrapeFileButton_Click

        ' Add the controls to the panel
        Me.SplitContainer1.Panel2.Controls.Clear()
        Me.SplitContainer1.Panel2.Controls.Add(introductionLabel)
        Me.SplitContainer1.Panel2.Controls.Add(scrapeWebsiteButton)
        Me.SplitContainer1.Panel2.Controls.Add(scrapeFileButton)

        ' Set the buttons to be visible
        scrapeWebsiteButton.Visible = True
        scrapeFileButton.Visible = True
    End Sub



    ' Other methods and event handlers

    ' Event handler for the scrape website button click event
    Private Sub ScrapeWebsiteButton_Click(sender As Object, e As EventArgs)
        ' Show the ScrapeOptionsDialog to ask the user whether to scrape a single webpage or the whole website
        Dim optionsDialog As New ScrapeOptionsDialog()
        Dim optionsResult As DialogResult = optionsDialog.ShowDialog()

        If optionsResult = DialogResult.Yes Then
            ' The user chose to scrape a single webpage
            Dim websiteUrl As String = InputBox("Enter the webpage URL:")

            Dim searchTerm As String = InputBox("Enter the search term:")

            If Not String.IsNullOrWhiteSpace(websiteUrl) AndAlso Not String.IsNullOrWhiteSpace(searchTerm) Then
                ' Call the method to scrape the single webpage with the provided URL and search term
                ScrapeSingleWebpage(websiteUrl, searchTerm)
            Else
                MessageBox.Show("Please enter valid inputs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        ElseIf optionsResult = DialogResult.No Then
            ' The user chose to scrape the whole website
            ' Instead of proceeding, show a message that this feature isn't enabled yet
            MessageBox.Show("The 'Scrape Whole Website' feature isn't enabled yet. Please email matthew@zoljan.com to enable it.", "Feature Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ' Method to scrape a single webpage
    Private Sub ScrapeSingleWebpage(websiteUrl As String, searchTerm As String)
        Try
            ' Prepend "http://" if the URL doesn't start with "http://" or "https://"
            If Not websiteUrl.StartsWith("http://") AndAlso Not websiteUrl.StartsWith("https://") Then
                websiteUrl = "http://" & websiteUrl
            End If

            Dim web = New HtmlWeb()
            Dim doc = web.Load(websiteUrl) ' Attempt to load the webpage

            ' If successful, proceed with scraping
            ScrapePage(doc, websiteUrl, searchTerm)
            SaveToExcel() ' Save results after scraping
        Catch ex As HtmlWebException
            ' Handle exceptions specific to HtmlAgilityPack
            MessageBox.Show("Error loading webpage. Please check the URL and try again.", "Webpage Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As WebException
            ' Handle general web exceptions, such as the URL not existing
            MessageBox.Show("The webpage could not be accessed. Please ensure the URL is correct and the webpage exists.", "Webpage Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            ' Catch-all for any other exceptions
            MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    ' Method to scrape a page for the search term along with the corresponding sentence
    Private Sub ScrapePage(doc As HtmlAgilityPack.HtmlDocument, url As String, searchTerm As String)
        Dim lowerSearchTerm = searchTerm.ToLower()
        Dim nodes = doc.DocumentNode.SelectNodes("//text()")

        If nodes IsNot Nothing Then
            For Each node In nodes
                ' Check if the node is within <style> or <script> tags
                If Not IsWithinStyleOrScript(node) Then
                    Dim sentence = GetSentence(node) ' Get the sentence containing the text node
                    If sentence IsNot Nothing AndAlso sentence.ToLower().Contains(lowerSearchTerm) Then
                        ' If the sentence contains the search term, add it without HTML tags
                        scrapedData.Add(New SearchResult(url, sentence))
                    End If
                End If
            Next
        End If
    End Sub

    ' Method to check if a node is within <style> or <script> tags
    Private Function IsWithinStyleOrScript(node As HtmlNode) As Boolean
        Dim parent = node.ParentNode
        While parent IsNot Nothing
            If parent.Name.ToLower() = "style" OrElse parent.Name.ToLower() = "script" Then
                Return True
            End If
            parent = parent.ParentNode
        End While
        Return False
    End Function


    ' Method to get the sentence containing the specified text node without HTML tags
    Private Function GetSentence(node As HtmlNode) As String
        Dim sentence As New StringBuilder()

        ' Traverse upwards in the DOM tree to find the parent element containing the sentence
        While node IsNot Nothing AndAlso node.NodeType = HtmlNodeType.Text
            ' Append the text of the current node to the sentence builder
            sentence.Insert(0, node.InnerText.Trim())

            ' Move to the previous sibling node
            node = node.PreviousSibling
        End While

        ' Remove any HTML tags from the sentence
        Return System.Text.RegularExpressions.Regex.Replace(sentence.ToString(), "<[^>]*(>|$)", String.Empty)
    End Function




    Public Class SearchResult
        Public Property Source As String
        Public Property Content As String ' Sentence or paragraph containing the search term

        Public Sub New(source As String, content As String)
            Me.Source = source
            Me.Content = content
        End Sub
    End Class


    ' Method to save collected data to Excel, handling both web and file search results
    Private Sub SaveToExcel()
        Try
            Using package As New ExcelPackage()
                Dim worksheet = package.Workbook.Worksheets.Add("Results")
                worksheet.Cells("A1").Value = "Source"
                worksheet.Cells("B1").Value = "Content Where Search Term Found"

                Dim row = 2
                For Each item In scrapedData
                    worksheet.Cells($"A{row}").Value = item.Source
                    worksheet.Cells($"B{row}").Value = item.Content
                    row += 1
                Next

                ' Let user choose where to save the Excel file
                Dim saveDialog As New SaveFileDialog()
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx"
                saveDialog.Title = "Save the Results"
                saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

                If saveDialog.ShowDialog() = DialogResult.OK Then
                    Dim fileInfo As New FileInfo(saveDialog.FileName)
                    package.SaveAs(fileInfo)
                    MessageBox.Show($"Results saved to {fileInfo.FullName}")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error saving to Excel: " & ex.Message)
        End Try
    End Sub



    ' Event handler for the scrape file button click event
    Private Sub ScrapeFileButton_Click(sender As Object, e As EventArgs) Handles scrapeFileButton.Click
        Dim optionsDialog As New ScrapeFileOptionsDialog()
        Dim optionsResult As DialogResult = optionsDialog.ShowDialog()

        If optionsResult = DialogResult.OK Then
            Dim searchTerm As String = InputBox("Enter the search term:")

            If String.IsNullOrWhiteSpace(searchTerm) Then
                MessageBox.Show("Please enter a valid search term.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If optionsDialog.ScrapeSingleFile Then
                ' User chose to scrape a single file
                Dim openFileDialog As New OpenFileDialog With {
                .Filter = "Supported Files|*.docx;*.htm;*.html;*.pdf",
                .Title = "Select File(s)",
                .Multiselect = False ' Allow selecting only one file
            }

                If openFileDialog.ShowDialog() = DialogResult.OK Then
                    Dim filePath As String = openFileDialog.FileName
                    Dim fileType = Path.GetExtension(filePath).ToLower()

                    Select Case fileType
                        Case ".docx"
                            ProcessWordDocument(filePath, searchTerm)
                        Case ".htm", ".html"
                            ProcessHtmlFile(filePath, searchTerm)
                        Case ".pdf"
                            ProcessPdfFile(filePath, searchTerm)
                        Case Else
                            MessageBox.Show("File type not supported.")
                    End Select

                    SaveToExcel() ' Save results after processing the selected file
                End If
            ElseIf optionsDialog.ScrapeEntireFolder Then
                ' User chose to scrape an entire folder
                Dim folderBrowserDialog As New FolderBrowserDialog With {
                .Description = "Select Folder",
                .ShowNewFolderButton = False
            }

                If folderBrowserDialog.ShowDialog() = DialogResult.OK Then
                    Dim folderPath As String = folderBrowserDialog.SelectedPath
                    Dim files As String() = Directory.GetFiles(folderPath)

                    For Each filePath In files
                        Dim fileType = Path.GetExtension(filePath).ToLower()

                        Select Case fileType
                            Case ".docx"
                                ProcessWordDocument(filePath, searchTerm)
                            Case ".htm", ".html"
                                ProcessHtmlFile(filePath, searchTerm)
                            Case ".pdf"
                                ProcessPdfFile(filePath, searchTerm)
                            Case Else
                                MessageBox.Show("File type not supported.")
                        End Select
                    Next

                    SaveToExcel() ' Save results after processing all files in the folder
                End If
            End If
        End If
    End Sub


    ' Method to process a Word document with search functionality
    Private Function ProcessWordDocument(filePath As String, searchTerm As String) As Boolean
        Dim textBuilder As New StringBuilder()
        Dim searchTermFound As Boolean = False
        Using doc As WordprocessingDocument = WordprocessingDocument.Open(filePath, False)
            Dim bodyText = doc.MainDocumentPart.Document.Body.InnerText
            If bodyText.ToLower().Contains(searchTerm.ToLower()) Then
                searchTermFound = True
            End If
        End Using

        If searchTermFound Then
            scrapedData.Add(New SearchResult(filePath, "Term found sentence or paragraph"))
        End If

        Return searchTermFound
    End Function



    ' Method to process an HTML file and search for a specific term
    Private Sub ProcessHtmlFile(filePath As String, searchTerm As String)
        Dim doc = New HtmlAgilityPack.HtmlDocument()
        doc.Load(filePath)

        Dim searchTermFound As Boolean = False
        For Each node As HtmlNode In doc.DocumentNode.SelectNodes("//body//text()")
            If node.InnerText.ToLower().Contains(searchTerm.ToLower()) Then
                ' Assuming we want the entire paragraph where the search term was found:
                Dim paragraph = node.ParentNode.InnerText
                scrapedData.Add(New SearchResult(filePath, paragraph))
                Exit For ' Exit if the search term is found
            End If
        Next
    End Sub



    ' Method to process a PDF file and search for a specific term using PdfPig
    Private Sub ProcessPdfFile(filePath As String, searchTerm As String)
        Using pdf = PdfDocument.Open(filePath)
            For Each page As Page In pdf.GetPages()
                If page.Text.ToLower().Contains(searchTerm.ToLower()) Then
                    ' For simplicity, add the first occurrence. You might want to adjust this.
                    Dim text = page.Text
                    scrapedData.Add(New SearchResult(filePath, text))
                    Exit For ' Exit if the search term is found
                End If
            Next
        End Using
    End Sub



    Public Class ScrapeFileOptionsDialog
        Inherits Form

        Public Property ScrapeSingleFile As Boolean
        Public Property ScrapeEntireFolder As Boolean

        Private WithEvents btnOk As Button
        Private WithEvents btnCancel As Button
        Private WithEvents radSingleFile As RadioButton
        Private WithEvents radEntireFolder As RadioButton

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub InitializeComponent()
            ' Initialize controls
            btnOk = New Button()
            btnCancel = New Button()
            radSingleFile = New RadioButton()
            radEntireFolder = New RadioButton()

            ' Set control properties
            btnOk.Text = "OK"
            btnCancel.Text = "Cancel"
            radSingleFile.Text = "Scrape Single File"
            radEntireFolder.Text = "Scrape Entire Folder"

            ' Set form properties
            Me.Text = "Scrape File Options"
            Me.FormBorderStyle = FormBorderStyle.FixedDialog
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Size = New Size(320, 190)
            Me.MaximizeBox = False

            ' Set control locations
            btnOk.Location = New Point(50, 110)
            btnCancel.Location = New Point(150, 110)
            radSingleFile.Location = New Point(20, 20)
            radEntireFolder.Location = New Point(20, 50)

            ' Add controls to form
            Me.Controls.Add(btnOk)
            Me.Controls.Add(btnCancel)
            Me.Controls.Add(radSingleFile)
            Me.Controls.Add(radEntireFolder)

            ' Add event handlers
            AddHandler btnOk.Click, AddressOf btnOk_Click
            AddHandler btnCancel.Click, AddressOf btnCancel_Click
        End Sub

        ' Event handlers for buttons
        Private Sub btnOk_Click(sender As Object, e As EventArgs)
            ' Set properties based on user selection
            ScrapeSingleFile = radSingleFile.Checked
            ScrapeEntireFolder = radEntireFolder.Checked

            ' Close the dialog
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End Sub

        Private Sub btnCancel_Click(sender As Object, e As EventArgs)
            ' Close the dialog without setting properties
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End Sub
    End Class




    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProfileScreen))
        SplitContainer1 = New SplitContainer()
        CType(SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.SuspendLayout()
        SuspendLayout()
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.BackColor = Color.FromArgb(CByte(19), CByte(252), CByte(117))
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.Location = New Point(0, 0)
        SplitContainer1.Name = "SplitContainer1"
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.BackColor = Color.FromArgb(CByte(19), CByte(252), CByte(117))
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.BackColor = Color.FromArgb(CByte(51), CByte(51), CByte(51))
        SplitContainer1.Size = New Size(800, 450)
        SplitContainer1.SplitterDistance = 227
        SplitContainer1.TabIndex = 0
        ' 
        ' ProfileScreen
        ' 
        ClientSize = New Size(800, 450)
        Controls.Add(SplitContainer1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "ProfileScreen"
        CType(SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.ResumeLayout(False)
        ResumeLayout(False)

    End Sub

    Private Sub ProfileScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
