Imports OfficeOpenXml
Imports HtmlAgilityPack
Imports System.IO
Imports System.Net

Friend Class ProfileScreen
    Inherits Form

    Private mainContainer As Panel
    Private scrapedData As New List(Of Tuple(Of String, String)) ' Declare scrapedData here

    Public Sub New()
        ' Set the license context for EPPlus
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial
        ' Create a Panel for the sidebar
        Dim sidebar As New Panel With {
            .Dock = DockStyle.Left,
            .Width = 200,
            .BackColor = ColorTranslator.FromHtml("#13fc75"), ' Change the sidebar color to #13fc75
            .ForeColor = Color.White ' Change the text color to white
        }

        ' Create a Panel for the main container
        mainContainer = New Panel With {
            .Dock = DockStyle.Fill,
            .BackColor = ColorTranslator.FromHtml("#333333"), ' Change the main container color to a lighter shade of black
            .ForeColor = Color.White ' Change the text color to white
        }

        ' Create a Button for the general scrape information button
        Dim scrapeInfoButton = New Button With {
            .Text = "Scrape Information",
            .Size = New Size(150, 50),
            .Location = New Point(25, 20),
            .BackColor = ColorTranslator.FromHtml("#333333"), ' Set the button color to #001f0f
            .ForeColor = Color.White ' Set the text color to white
        }

        ' Event handler for the general scrape information button click event
        AddHandler scrapeInfoButton.Click, AddressOf ScrapeInfoButton_Click

        ' Add the button to the sidebar
        sidebar.Controls.Add(scrapeInfoButton)

        ' Add the main container and the sidebar to the form
        Controls.Add(mainContainer)
        Controls.Add(sidebar)

    End Sub

    ' Event handler for the general scrape information button click event
    Private Sub ScrapeInfoButton_Click(sender As Object, e As EventArgs)
        ' Clear the main container
        mainContainer.Controls.Clear()

        ' Add introduction text
        Dim introductionLabel = New Label With {
            .Text = "Welcome to the Scrape Information tool. In this tool, you will be able to scrape important information that is needed to save manual, repetitive, and monotonous. Please choose an option below, to either scrape information from a website or a file saved to your computer:",
            .Location = New Point(20, 20),
            .AutoSize = True,
            .ForeColor = Color.White
        }

        ' Set the width of the introduction label
        Dim maxWidth As Integer = mainContainer.Width - 40 ' Subtracting 40 for padding
        introductionLabel.MaximumSize = New Size(maxWidth, 0)

        ' Create a Button for the scrape website button
        Dim scrapeWebsiteButton = New Button With {
            .Text = "Scrape Website",
            .Size = New Size(150, 50),
            .Location = New Point(25, introductionLabel.Bottom + 60) ' Adjusted position to be 2 cm below the introduction label
        }

        ' Create a Button for the scrape file button
        Dim scrapeFileButton = New Button With {
            .Text = "Scrape File",
            .Size = New Size(150, 50),
            .Location = New Point(25, scrapeWebsiteButton.Bottom + 25) ' Position it below the scrape website button
        }

        ' Event handler for the scrape website button click event
        AddHandler scrapeWebsiteButton.Click, AddressOf ScrapeWebsiteButton_Click

        ' Event handler for the scrape file button click event
        AddHandler scrapeFileButton.Click, AddressOf ScrapeFileButton_Click

        ' Add the controls to the main container
        mainContainer.Controls.Add(introductionLabel)
        mainContainer.Controls.Add(scrapeWebsiteButton)
        mainContainer.Controls.Add(scrapeFileButton)

        ' Refresh the main container
        mainContainer.Refresh()
    End Sub

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


    Private Function EnsureHttpPrefix(url As String) As String
        If Not url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) AndAlso Not url.StartsWith("https://", StringComparison.OrdinalIgnoreCase) Then
            ' If the URL does not start with either "http://" or "https://", prepend "https://"
            Return "https://" & url
        Else
            ' If it already starts with "http://" or "https://", return the URL unchanged
            Return url
        End If
    End Function




    ' Method to scrape the whole website
    Private Sub ScrapeWholeWebsite(websiteUrl As String, searchTerm As String)
        ' Show a message box indicating the feature is not enabled and provide a contact email
        MessageBox.Show("The feature to scrape the whole website is currently not enabled. If you'd like to request this feature, please email matthew@zoljan.com.", "Feature Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


    ' Helper method to convert a relative URL to an absolute URL
    Private Function EnsureAbsoluteUrl(relativeUrl As String, baseUrl As String) As String
        If relativeUrl.StartsWith("http") Then Return relativeUrl ' Already absolute
        Dim baseUri = New Uri(baseUrl)
        Dim absoluteUri = New Uri(baseUri, relativeUrl)
        Return absoluteUri.ToString()
    End Function


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




    ' Method to scrape a page for the search term
    Private Sub ScrapePage(doc As HtmlDocument, url As String, searchTerm As String)
        ' Convert the search term to lowercase (or uppercase) for case-insensitive comparison
        Dim lowerSearchTerm = searchTerm.ToLower()

        ' Use XPath to select all text nodes in the document
        Dim nodes = doc.DocumentNode.SelectNodes("//text()")

        If nodes IsNot Nothing Then
            For Each node In nodes
                ' Check if the text node (converted to lowercase) contains the lowercase search term
                If node.InnerText.ToLower().Contains(lowerSearchTerm) Then
                    ' If a match is found, add the URL and the text of the node to the scrapedData list
                    scrapedData.Add(Tuple.Create(url, node.InnerText))
                End If
            Next
        End If
    End Sub



    ' Method to get absolute URL from relative URL
    Private Function GetAbsoluteUrl(baseUrl As String, relativeUrl As String) As String
        Dim uri = New Uri(relativeUrl, UriKind.RelativeOrAbsolute)
        If Not uri.IsAbsoluteUri Then
            uri = New Uri(New Uri(baseUrl), uri)
        End If
        Return uri.ToString()
    End Function


    ' Method to save collected data to Excel
    Private Sub SaveToExcel()
        Try
            Using package As New ExcelPackage()
                Dim worksheet = package.Workbook.Worksheets.Add("ScrapedData")
                worksheet.Cells("A1").Value = "URL"
                worksheet.Cells("B1").Value = "Content"

                Dim row = 2
                For Each item In scrapedData
                    worksheet.Cells($"A{row}").Value = item.Item1
                    worksheet.Cells($"B{row}").Value = item.Item2
                    row += 1
                Next

                Dim filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ScrapedData.xlsx")
                package.SaveAs(New FileInfo(filePath))

                MessageBox.Show($"Data saved to {filePath}")
            End Using
        Catch ex As Exception
            MessageBox.Show("Error saving to Excel: " & ex.Message)
        End Try
    End Sub

    ' Event handler for the scrape file button click event
    Private Sub ScrapeFileButton_Click(sender As Object, e As EventArgs)
        ' Add your implementation here
    End Sub

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProfileScreen))
        SuspendLayout()
        ' 
        ' ProfileScreen
        ' 
        ClientSize = New Size(284, 261)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "ProfileScreen"
        ResumeLayout(False)

    End Sub

    Friend Sub ShowProfileScreen()
        Me.ShowDialog()
    End Sub

    Private Sub ProfileScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
