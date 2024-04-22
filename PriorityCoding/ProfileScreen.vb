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

        ' Initialize scrapeFileButton and scrapeWebsiteButton
        scrapeFileButton = New Button()
        scrapeWebsiteButton = New Button()

        ' Initialize scrapeFileButton
        InitializeScrapeFileButton()

        ' Initialize scrapeWebsiteButton
        InitializeScrapeWebsiteButton()

        ' Set the buttons to be initially invisible
        scrapeFileButton.Visible = False
        scrapeWebsiteButton.Visible = False
    End Sub



    ' Method to initialize the scrape file button
    Private Sub InitializeScrapeFileButton()
        scrapeFileButton.Text = "Scrape File" ' Set the button text
        scrapeFileButton.Size = New Size(150, 50) ' Set the button size
        scrapeFileButton.Location = New Point(10, 80) ' Set the button location
        scrapeFileButton.BackColor = ColorTranslator.FromHtml("#333333") ' Set the background color
        scrapeFileButton.ForeColor = Color.White ' Set the text color
        AddHandler scrapeFileButton.Click, AddressOf ScrapeFileButton_Click
        Me.SplitContainer1.Panel2.Controls.Add(scrapeFileButton)
    End Sub

    ' Method to initialize the scrape website button
    Private Sub InitializeScrapeWebsiteButton()
        scrapeWebsiteButton.Text = "Scrape Website" ' Set the button text
        scrapeWebsiteButton.Size = New Size(150, 50) ' Set the button size
        scrapeWebsiteButton.Location = New Point(10, 140) ' Set the button location
        scrapeWebsiteButton.BackColor = ColorTranslator.FromHtml("#333333") ' Set the background color
        scrapeWebsiteButton.ForeColor = Color.White ' Set the text color
        AddHandler scrapeWebsiteButton.Click, AddressOf ScrapeWebsiteButton_Click
        Me.SplitContainer1.Panel2.Controls.Add(scrapeWebsiteButton)
    End Sub

    ' Event handler for the general scrape information button click event
    Private Sub PerformClickScrapeInfoButton()
        ' Initialize the introduction label
        InitializeIntroductionLabel()

        ' Add the controls to the panel
        Me.SplitContainer1.Panel2.Controls.Clear()
        Me.SplitContainer1.Panel2.Controls.Add(introductionLabel)
        Me.SplitContainer1.Panel2.Controls.Add(scrapeWebsiteButton)
        Me.SplitContainer1.Panel2.Controls.Add(scrapeFileButton)

        ' Set the buttons to be visible
        scrapeWebsiteButton.Visible = True
        scrapeFileButton.Visible = True
    End Sub

    ' Method to initialize the introduction label
    Private Sub InitializeIntroductionLabel()
        introductionLabel = New Label With {
            .Text = "Welcome to the Scrape Information tool. In this tool, you will be able to scrape important information that is needed to save manual, repetitive, and monotonous tasks. Please choose an option below, to either scrape information from a website or a file saved to your computer:",
            .ForeColor = Color.White,
            .Location = New Point(10, 10),
            .AutoSize = True
        }
        introductionLabel.MaximumSize = New Size(Me.SplitContainer1.Panel2.Width - 20, 0) ' Allow the label to grow in height
    End Sub




    ' Event handler for the Dude button click event
    Private Sub Dude_Click(sender As Object, e As EventArgs) Handles Dude.Click
        ' Call the PerformClickScrapeInfoButton method instead of directly invoking ScrapeInfoButton_Click
        PerformClickScrapeInfoButton()
    End Sub


    ' Event handler for the general scrape information button click event
    Private Sub ScrapeInfoButton_Click(sender As Object, e As EventArgs)
        ' Initialize the introduction label
        Dim introductionLabel As New Label With {
        .Text = "Welcome to the Scrape Information tool. In this tool, you will be able to scrape important information that is needed to save manual, repetitive, and monotonous tasks. Please choose an option below, to either scrape information from a website or a file saved to your computer:",
        .ForeColor = Color.White,
        .Location = New Point(10, 10),
        .Size = New Size(Me.SplitContainer1.Panel2.Width - 20, 60),
        .AutoSize = False
    }
        ' Modify the introduction label initialization
        introductionLabel.AutoSize = True
        introductionLabel.MaximumSize = New Size(Me.SplitContainer1.Panel2.Width - 20, 0) ' Allow the label to grow in height

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
            Dim websiteUrl As String = InputBox("Enter the website URL:")
            Dim searchTerm As String = InputBox("Enter the search term:")

            If Not String.IsNullOrWhiteSpace(websiteUrl) AndAlso Not String.IsNullOrWhiteSpace(searchTerm) Then
                ' Prepend "http://" if the URL doesn't start with "http://" or "https://"
                If Not websiteUrl.StartsWith("http://") AndAlso Not websiteUrl.StartsWith("https://") Then
                    websiteUrl = "http://" & websiteUrl
                End If

                ' Call the method to scrape the whole website with the provided URL and search term
                ScrapeWholeWebsite(websiteUrl, searchTerm)
            Else
                MessageBox.Show("Please enter valid inputs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
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

    ' Method to scrape a webpage and its subpages
    Private Sub ScrapeWholeWebsite(websiteUrl As String, searchTerm As String)
        Try
            Dim web As New HtmlWeb()
            Dim doc As HtmlAgilityPack.HtmlDocument = web.Load(websiteUrl)

            ' Create a HashSet to store visited URLs
            Dim visitedUrls As New HashSet(Of String)()

            ' Scrape the main webpage for relevant information
            ScrapePage(doc, websiteUrl, searchTerm)

            ' Add the main webpage URL to the visited URLs set
            visitedUrls.Add(websiteUrl)

            ' Recursively scrape subpages
            ScrapeSubpages(doc, websiteUrl, searchTerm, visitedUrls)

            ' Save the collected data to Excel
            SaveToExcel() ' Add this line to save data after scraping the whole website
        Catch ex As Exception
            ' Handle exceptions
            MessageBox.Show("An error occurred while scraping the website: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Method to scrape subpages of a website while avoiding duplicate scraping
    Private Sub ScrapeSubpages(parentDoc As HtmlAgilityPack.HtmlDocument, baseUrl As String, searchTerm As String, visitedUrls As HashSet(Of String))
        ' Extract all anchor elements (links) from the parent document
        Dim anchorNodes As HtmlNodeCollection = parentDoc.DocumentNode.SelectNodes("//a[@href]")

        If anchorNodes IsNot Nothing Then
            For Each anchorNode As HtmlNode In anchorNodes
                ' Get the value of the "href" attribute to obtain the URL of the subpage
                Dim subpageUrl As String = anchorNode.GetAttributeValue("href", String.Empty)

                ' Construct the absolute URL if the URL is relative
                If Not subpageUrl.StartsWith("http://") AndAlso Not subpageUrl.StartsWith("https://") Then
                    subpageUrl = New Uri(New Uri(baseUrl), subpageUrl).AbsoluteUri
                End If

                ' Check if the absolute URL belongs to the same domain and has not been visited
                If IsSameDomain(baseUrl, subpageUrl) AndAlso Not visitedUrls.Contains(subpageUrl) Then
                    ' Mark the URL as visited
                    visitedUrls.Add(subpageUrl)

                    ' Load the subpage
                    Dim web As New HtmlWeb()
                    Dim subpageDoc As HtmlAgilityPack.HtmlDocument = web.Load(subpageUrl)

                    ' Scrape the subpage for relevant information
                    ScrapePage(subpageDoc, subpageUrl, searchTerm)

                    ' Recursively scrape subpages of the subpage
                    ScrapeSubpages(subpageDoc, baseUrl, searchTerm, visitedUrls)
                End If
            Next
        End If
    End Sub

    ' Method to check if a URL belongs to the same domain as the main website
    Private Function IsSameDomain(baseUrl As String, url As String) As Boolean
        Dim baseUri As New Uri(baseUrl)
        Dim uri As New Uri(url)
        Return baseUri.Host = uri.Host
    End Function

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
        While node IsNot Nothing AndAlso (node.NodeType = HtmlNodeType.Text OrElse node.Name = "span")
            ' Append the text of the current node to the sentence builder
            If node.NodeType = HtmlNodeType.Text Then
                sentence.Insert(0, node.InnerText.Trim())
            ElseIf node.Name = "span" Then
                sentence.Insert(0, node.InnerText.Trim() & " ")
            End If

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
            If scrapedData.Count > 0 Then
                MessageBox.Show("SaveToExcel function is being executed...")

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
            Else
                MessageBox.Show("No data to save to Excel.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error saving to Excel: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Clear the scrapedData list after saving data to Excel
            scrapedData.Clear()
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
    Private Sub ProcessWordDocument(filePath As String, searchTerm As String)
        Dim searchTermFound As Boolean = False
        Using doc As WordprocessingDocument = WordprocessingDocument.Open(filePath, False)
            Dim bodyText = doc.MainDocumentPart.Document.Body.InnerText
            Dim lowerSearchTerm = searchTerm.ToLower()

            ' Split the body text into sentences
            Dim sentences() As String = bodyText.Split(New String() {". "}, StringSplitOptions.RemoveEmptyEntries)

            ' Iterate through each sentence
            For Each sentence As String In sentences
                If sentence.ToLower().Contains(lowerSearchTerm) Then
                    ' Add the sentence to scraped data
                    scrapedData.Add(New SearchResult(filePath, sentence))
                    searchTermFound = True
                End If
            Next
        End Using

        If Not searchTermFound Then
            ' If the search term is not found in any sentence, still add an entry indicating it was not found
            scrapedData.Add(New SearchResult(filePath, "Search term not found"))
        End If
    End Sub


    ' Method to process an HTML file and search for a specific term
    Private Sub ProcessHtmlFile(filePath As String, searchTerm As String)
        Dim doc = New HtmlAgilityPack.HtmlDocument()
        doc.Load(filePath)

        Dim lowerSearchTerm = searchTerm.ToLower()
        Dim paragraph As New StringBuilder()

        For Each node As HtmlNode In doc.DocumentNode.SelectNodes("//body//text()")
            ' Check if the node contains the search term
            If node.InnerText.ToLower().Contains(lowerSearchTerm) Then
                ' Traverse upwards in the DOM tree to find the parent element containing the entire paragraph
                Dim currentNode As HtmlNode = node
                While currentNode IsNot Nothing AndAlso currentNode.Name <> "body"
                    paragraph.Insert(0, currentNode.InnerText.Trim() & " ")
                    currentNode = currentNode.ParentNode
                End While

                ' Remove any HTML tags from the paragraph
                Dim cleanParagraph = System.Text.RegularExpressions.Regex.Replace(paragraph.ToString(), "<[^>]*(>|$)", String.Empty)
                scrapedData.Add(New SearchResult(filePath, cleanParagraph))
                Exit For ' Exit if the search term is found
            End If
        Next
    End Sub

    ' Method to process a PDF file and search for a specific term using PdfPig
    Private Sub ProcessPdfFile(filePath As String, searchTerm As String)
        Using pdf = PdfDocument.Open(filePath)
            For Each page As Page In pdf.GetPages()
                Dim text As String = page.Text
                Dim lowerSearchTerm As String = searchTerm.ToLower()

                ' Split the text into sentences
                Dim sentences() As String = text.Split(New String() {". "}, StringSplitOptions.RemoveEmptyEntries)

                For Each sentence As String In sentences
                    If sentence.ToLower().Contains(lowerSearchTerm) Then
                        ' Add the sentence to scraped data
                        scrapedData.Add(New SearchResult(filePath, sentence))
                    End If
                Next
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
            Me.Size = New Size(400, 190) ' Increase the width of the form

            ' Set control locations
            btnOk.Location = New Point(50, 110)
            btnCancel.Location = New Point(150, 110)
            radSingleFile.Location = New Point(20, 20)
            radEntireFolder.Location = New Point(20, 50)

            ' Set control sizes
            radSingleFile.Size = New Size(200, 20) ' Adjust width as needed
            radEntireFolder.Size = New Size(200, 20) ' Adjust width as needed

            ' Set font size for radio buttons
            radSingleFile.Font = New Font(radSingleFile.Font.FontFamily, 10) ' Adjust font size as needed
            radEntireFolder.Font = New Font(radEntireFolder.Font.FontFamily, 10) ' Adjust font size as needed


            ' Add controls to form
            Me.Controls.Add(btnOk)
            Me.Controls.Add(btnCancel)
            Me.Controls.Add(radSingleFile)
            Me.Controls.Add(radEntireFolder)

            ' Add event handlers
            AddHandler btnOk.Click, AddressOf btnOk_Click
            AddHandler btnCancel.Click, AddressOf btnCancel_Click
            AddHandler Me.FormClosing, AddressOf ScrapeFileOptionsDialog_FormClosing

        End Sub

        Private Sub ScrapeFileOptionsDialog_FormClosing(sender As Object, e As FormClosingEventArgs)
            ' Check if the form is being closed without OK button being clicked
            If e.CloseReason = CloseReason.UserClosing Then
                ' Handle the event here, e.g., setting DialogResult to Cancel
                Me.DialogResult = DialogResult.Cancel
            End If
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
