Imports System.IO
Imports System.Text
Imports System.Xml

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim strFileName As String

        fd.Title = "Choose CSV-File to convert to XML"
        fd.InitialDirectory = "C:\Projects\DNET1-P\DNET1\P13_VB"
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If Not fd.ShowDialog() = DialogResult.OK Then
            Return
        End If

        strFileName = fd.FileName
        Console.WriteLine(strFileName)

        ' Read File Content
        Dim al As ArrayList = New ArrayList()
        Dim reader As StreamReader = File.OpenText(strFileName)
        Dim firstLine = reader.ReadLine() 'first line
        Dim line As String = reader.ReadLine()
        While Not line = Nothing
            Console.WriteLine(line)
            al.Add(line)
            line = reader.ReadLine()
        End While
        reader.Close()

        ' Create XmlWriterSettings.
        Dim settings As XmlWriterSettings = New XmlWriterSettings()
        settings.Indent = True
        settings.Encoding = Encoding.UTF8

        ' Create XmlWriter.
        Using writer As XmlWriter = XmlWriter.Create(strFileName.Replace(".csv", ".xml"), settings)
            ' Begin writing.
            writer.WriteStartDocument()
            writer.WriteStartElement("Employees") ' Root.

            ' Loop over employees in array.
            Dim currentLine As String
            Dim elements As Array
            Dim titleElements As Array
            titleElements = firstLine.Split(";")
            For Each currentLine In al
                elements = currentLine.Split(";")
                writer.WriteStartElement("Employee")
                writer.WriteElementString(titleElements(0), elements(0).Trim())
                writer.WriteElementString(titleElements(1), elements(1).Trim())
                writer.WriteElementString(titleElements(2), elements(2).Trim())
                writer.WriteElementString(titleElements(3), elements(3).Trim())
                writer.WriteElementString(titleElements(4), elements(4).Trim())
                writer.WriteElementString(titleElements(5), elements(5).Trim())
                writer.WriteElementString(titleElements(6), elements(6).Trim())
                writer.WriteElementString(titleElements(7), elements(7).Trim())
                writer.WriteElementString(titleElements(8), elements(8).Trim())
                writer.WriteEndElement()
            Next

            ' End document.
            writer.WriteEndElement()
            writer.WriteEndDocument()
            Me.Label1.Text = "Finish"
        End Using
    End Sub
End Class
