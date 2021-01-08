Imports System.Xml
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Net.Mail
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Text
Public Class dataXML
  Implements IDisposable
  Public Property PDF_filename As String = ""
  Public Property filename As String = ""
  Public Property number As String = ""
  Public Property title As String = ""
  Public Property rev As String = ""
  Public Property ElId As String = "" ' el.id.
  Public Property sheetsize As String = ""
  Public Property scale As String = ""
  Public Property weight As String = ""
  Public Property drawn As String = ""
  Public Property chqd As String = ""
  Public Property appd As String = ""
  Public Property ddate As String = "" 'date
  Public Property resp_dept As String = ""
  Public Property apr As String = ""
  Public Property inf As String = ""
  Public Property pro As String = ""
  Public Property ere As String = ""
  Public Property drgid As String = ""
  Public Property VaultDBName As String = ""
  Public Property VaultUserName As String = ""
  Public Property VaultClientMachine As String = ""
  Public Property VaultSubmittedDate As String = ""
  Public Property ISGEC_Datasource As String = ""
  Public Property contract As String = ""
  Public Property service1 As String = ""
  Public Property service2 As String = ""
  Public Property iwt As String = ""
  Public Property year As String = ""
  Public Property consultant As String = ""
  Public Property client As String = ""
  Public Property group As String = ""
  'Custom Attributes
  Public Property dataXMLPath As String = ""
  Public Property Errors As ArrayList = Nothing
  Public Property State As Integer = 0
  Public Property DrawingDataFile As String = ""
  Public Property slzFileName As String = ""
  Public Property PDFFilePathName As String = ""
  Public Property ORGFilePathName As String = ""
  Public Property LibraryID As String = ""
  Public Property LibraryPath As String = ""
  Public ReadOnly Property AttachmentIndex As String
    Get
      Return drgid & "_" & rev
    End Get
  End Property
  Public ReadOnly Property ERPCompany As String
    Get
      If VaultDBName = "ISGEC REDECAM" Then
        Return "700"
      ElseIf VaultDBName = "ISGEC COVEMA" Then
        Return "651"
      Else
        Return "200"
      End If
    End Get
  End Property
  Public ReadOnly Property ItemSuffix As String
    Get
      Return drgid.Substring(6, drgid.Length)
    End Get
  End Property
  Public Shared Function GetDataXML(ByVal FilePath As String) As dataXML
    Dim lf As dataXML = Nothing
    Dim oXml As New XmlDocument
    On Error GoTo mErr
    oXml.Load(FilePath)
    On Error Resume Next
    lf = New dataXML
    lf.slzFileName = oXml.ChildNodes(1).Attributes("slzFileName").Value
    lf.PDF_filename = oXml.ChildNodes(1).Attributes("PDF_filename").Value
    lf.filename = oXml.ChildNodes(1).Attributes("filename").Value
    lf.number = oXml.ChildNodes(1).Attributes("number").Value
    lf.title = oXml.ChildNodes(1).Attributes("title").Value
    lf.rev = oXml.ChildNodes(1).Attributes("rev").Value
    lf.ElId = oXml.ChildNodes(1).Attributes("el.id.").Value

    lf.sheetsize = oXml.ChildNodes(1).Attributes("sheetsize").Value

    lf.scale = oXml.ChildNodes(1).Attributes("scale").Value
    lf.weight = oXml.ChildNodes(1).Attributes("weight").Value
    lf.drawn = oXml.ChildNodes(1).Attributes("drawn").Value
    lf.chqd = oXml.ChildNodes(1).Attributes("chqd").Value
    lf.appd = oXml.ChildNodes(1).Attributes("appd").Value
    lf.ddate = oXml.ChildNodes(1).Attributes("date").Value
    lf.resp_dept = oXml.ChildNodes(1).Attributes("resp_dept").Value
    lf.apr = oXml.ChildNodes(1).Attributes("apr").Value
    lf.inf = oXml.ChildNodes(1).Attributes("inf").Value
    lf.pro = oXml.ChildNodes(1).Attributes("pro").Value
    lf.ere = oXml.ChildNodes(1).Attributes("ere").Value
    lf.drgid = oXml.ChildNodes(1).Attributes("drgid").Value
    lf.VaultDBName = oXml.ChildNodes(1).Attributes("VaultDBName").Value
    lf.VaultUserName = oXml.ChildNodes(1).Attributes("VaultUserName").Value
    lf.VaultClientMachine = oXml.ChildNodes(1).Attributes("VaultClientMachine").Value
    lf.VaultSubmittedDate = oXml.ChildNodes(1).Attributes("VaultSubmittedDate").Value
    lf.ISGEC_Datasource = oXml.ChildNodes(1).Attributes("ISGEC_Datasource").Value

    lf.contract = oXml.ChildNodes(1).ChildNodes(0).Attributes("contract").Value
    lf.service1 = oXml.ChildNodes(1).ChildNodes(0).Attributes("service1").Value
    lf.service2 = oXml.ChildNodes(1).ChildNodes(0).Attributes("service2").Value
    lf.iwt = oXml.ChildNodes(1).ChildNodes(0).Attributes("iwt").Value
    lf.year = oXml.ChildNodes(1).ChildNodes(0).Attributes("year").Value
    lf.consultant = oXml.ChildNodes(1).ChildNodes(0).Attributes("consultant").Value
    lf.client = oXml.ChildNodes(1).ChildNodes(0).Attributes("client").Value
    lf.group = oXml.ChildNodes(1).ChildNodes(0).Attributes("group").Value

    GoTo ret
mErr:
    lf.State = 3
ret:
    Return lf
  End Function
  Public Shared Function GetFile(ByVal FilePath As String) As dataXML
    Dim lf As dataXML = New dataXML
    lf.State = RemoveInvalidChars(FilePath)


    If lf.State <> 0 Then Return lf
    Dim oXml As New XmlDocument
    On Error GoTo mErr
    oXml.Load(FilePath)

    On Error Resume Next
    lf.slzFileName = oXml.ChildNodes(1).Attributes("slzFileName").Value
    lf.PDF_filename = oXml.ChildNodes(1).Attributes("PDF_filename").Value
    lf.filename = oXml.ChildNodes(1).Attributes("filename").Value
    lf.number = oXml.ChildNodes(1).Attributes("number").Value
    lf.title = oXml.ChildNodes(1).Attributes("title").Value
    lf.rev = oXml.ChildNodes(1).Attributes("rev").Value
    lf.ElId = oXml.ChildNodes(1).Attributes("el.id.").Value
    lf.sheetsize = oXml.ChildNodes(1).Attributes("sheetsize").Value
    lf.scale = oXml.ChildNodes(1).Attributes("scale").Value
    lf.weight = oXml.ChildNodes(1).Attributes("weight").Value
    lf.drawn = oXml.ChildNodes(1).Attributes("drawn").Value
    lf.chqd = oXml.ChildNodes(1).Attributes("chqd").Value
    lf.appd = oXml.ChildNodes(1).Attributes("appd").Value
    lf.ddate = oXml.ChildNodes(1).Attributes("date").Value
    lf.resp_dept = oXml.ChildNodes(1).Attributes("resp_dept").Value
    lf.apr = oXml.ChildNodes(1).Attributes("apr").Value
    lf.inf = oXml.ChildNodes(1).Attributes("inf").Value
    lf.pro = oXml.ChildNodes(1).Attributes("pro").Value
    lf.ere = oXml.ChildNodes(1).Attributes("ere").Value
    lf.drgid = oXml.ChildNodes(1).Attributes("drgid").Value
    lf.VaultDBName = oXml.ChildNodes(1).Attributes("VaultDBName").Value
    lf.VaultUserName = oXml.ChildNodes(1).Attributes("VaultUserName").Value
    lf.VaultClientMachine = oXml.ChildNodes(1).Attributes("VaultClientMachine").Value
    lf.VaultSubmittedDate = oXml.ChildNodes(1).Attributes("VaultSubmittedDate").Value
    lf.ISGEC_Datasource = oXml.ChildNodes(1).Attributes("ISGEC_Datasource").Value

    lf.contract = oXml.ChildNodes(1).ChildNodes(0).Attributes("contract").Value
    lf.service1 = oXml.ChildNodes(1).ChildNodes(0).Attributes("service1").Value
    lf.service2 = oXml.ChildNodes(1).ChildNodes(0).Attributes("service2").Value
    lf.iwt = oXml.ChildNodes(1).ChildNodes(0).Attributes("iwt").Value
    lf.year = oXml.ChildNodes(1).ChildNodes(0).Attributes("year").Value
    lf.consultant = oXml.ChildNodes(1).ChildNodes(0).Attributes("consultant").Value
    lf.client = oXml.ChildNodes(1).ChildNodes(0).Attributes("client").Value
    lf.group = oXml.ChildNodes(1).ChildNodes(0).Attributes("group").Value

    With lf
      'Specific Logic
      '======Old Code for User Name=====
      '.VaultClientMachine = Left(.VaultClientMachine, 4)
      '.VaultUserName = Right("0000" & .VaultUserName.Replace("isgecnet\", ""), 4)
      '======New Code For User Name======
      .VaultClientMachine = .VaultClientMachine.Trim
      If .VaultClientMachine.Length >= 5 Then
        If IsNumeric(Left(.VaultClientMachine, 5)) Then
          .VaultClientMachine = Left(.VaultClientMachine, 5)
        Else
          If IsNumeric(Left(.VaultClientMachine, 4)) Then
            .VaultClientMachine = Left(.VaultClientMachine, 4)
          End If
        End If
      ElseIf .VaultClientMachine.Length = 4 Then
        If IsNumeric(Left(.VaultClientMachine, 4)) Then
          .VaultClientMachine = Left(.VaultClientMachine, 4)
        End If
      End If
      .VaultUserName = .VaultUserName.Trim.Replace("isgecnet\", "")
      If .VaultUserName.Length < 4 Then
        .VaultUserName = Right("0000" & .VaultUserName, 4)
      End If
      '==========End of New Code==========
      If .VaultUserName <> .VaultClientMachine Then
        .VaultUserName = .VaultClientMachine
      End If
      'Validations
      If .rev.Trim = String.Empty Then
        .Errors.Add("Revision Number is blank.")
      End If
      If .rev.Length > 2 Then
        .Errors.Add("Revision Number <b>" & .rev & "</b> is invalid.")
      End If
      If Not IsNumeric(.rev) Then
        .Errors.Add("Revision Number <b>" & .rev & "</b> is not Numeric.")
      Else
        If Convert.ToInt32(.rev) < 0 Then
          .Errors.Add("Revision Number <b>" & .rev & "</b> is Negative.")
        End If
      End If
      If .title = String.Empty Then
        .Errors.Add("Document Title is blank.")
      End If
      If .ElId.Trim.Length <> 8 Then
        .Errors.Add("Element ID is not valid.")
      End If
      If .contract = String.Empty Then
        .Errors.Add("Project ID is blank.")
      End If
      If .sheetsize.Trim = String.Empty Then
        .Errors.Add("Sheet Size is blank.")
        'added 2 lines'hkk
      Else
        .sheetsize = .sheetsize.Trim
      End If
      If IO.Path.GetFileNameWithoutExtension(.filename).ToLower <> IO.Path.GetFileNameWithoutExtension(.PDF_filename).ToLower Then
        .Errors.Add("Invalid XML: Pl check the files mentioned in MCD-BOM Sheet should be present in vault.")
      End If
      If .contract.ToLower <> .number.Substring(0, 6).ToLower Then
        .Errors.Add("Project Code: " & .contract & " does not match with Document ID: " & .number)
      End If
      If .drgid.ToLower <> .number.ToLower Then
        .Errors.Add("Mismatch in DRGID & Number attribute.")
      End If
      If .rev = "00" Or .rev = "0" Then
        Dim tfile As String = IO.Path.GetFileNameWithoutExtension(FilePath)
        If tfile.Length < 9 Or tfile.Length > 24 Then
          .Errors.Add("Invalid Physical File Name. [Valid: File name should be drawing/document number (24) + file extension. for rev 00")
        Else
          For tmpI As Integer = 0 To tfile.Length - 1
            Dim ch As String = tfile.Substring(tmpI, 1).ToLower
            If ch >= "a" And ch <= "z" Then
            ElseIf ch >= "0" And ch <= "9" Then
            ElseIf ch = "-" Then
            Else
              .Errors.Add("Physical file name contains invalid characters.")
            End If
          Next
        End If
      End If
      If .rev = "00" Or .rev = "0" Then
        If .number.Trim.Length <> 24 Then
          .Errors.Add("Document Number is not as per ISGEC Standard [XXXXXX-99999999-XXX-9999] for new drawings.")
        Else
          Dim aTmp() As String = .number.Trim.Split("-".ToCharArray)
          If aTmp(aTmp.Length - 1).Length <> 4 Then
            .Errors.Add("Document Serial No. must be of 4 digits in new drawings (i.e. 00 Rev).")
          Else
            If Not IsNumeric(aTmp(aTmp.Length - 1)) Then
              .Errors.Add("Document Serial No. must be 4 DIGIT NUMBER in new drawings (i.e. 00 Rev).")
            End If
          End If
        End If
      Else
        'Check MainFile Name and Isgec DataSource should be same in subsiquent release
        'And Check also First revision should be 00
        'First Check Current Revision in BaaN, If not found, then check Last Revision in BaaN
        Dim LastRevision As String = ""
        LastRevision = Right("00" & (Convert.ToInt32(.rev) - 1).ToString, 2)
        'To be done Latter
      End If
      '========================
      If .Errors.Count <= 0 Then
        .State = 0
        'Reverse Update
        oXml.ChildNodes(1).Attributes("VaultUserName").Value = .VaultUserName
        oXml.ChildNodes(1).Attributes("rev").Value = Right("00" & .rev, 2)
        oXml.ChildNodes(1).Attributes("sheetsize").Value = oXml.ChildNodes(1).Attributes("sheetsize").Value.Trim
        'Remove Blank Items
        With oXml.ChildNodes(1).ChildNodes(1)
          For I As Integer = .ChildNodes.Count - 1 To 0 Step -1
            Dim chnd As XmlNode = .ChildNodes(I)
            If chnd.Attributes("item_code").Value.Trim = String.Empty Then
              .RemoveChild(chnd)
            End If
          Next
        End With
        'And Save XML
        oXml.Save(FilePath)
      Else
        .State = 2
      End If
      '================================
    End With
    Return lf
mErr:
    lf.State = 3
    Return lf
  End Function
  Public Shared Function IsFileAvailable(ByVal FilePath As String) As Boolean
    If Not IO.File.Exists(FilePath) Then Return False
    Dim fInfo As IO.FileInfo = Nothing
    Dim st As IO.FileStream = Nothing
    Try
      fInfo = New IO.FileInfo(FilePath)
    Catch ex As Exception
      Return False
    End Try
    Dim ret As Boolean = False
    If fInfo.IsReadOnly Then
      If DateDiff(DateInterval.Minute, fInfo.CreationTime, Now) >= 1 Then
        fInfo.IsReadOnly = False
      End If
    End If
    Try
      st = fInfo.Open(IO.FileMode.Open, IO.FileAccess.ReadWrite, IO.FileShare.None)
      ret = True
    Catch ex As Exception
      ret = False
    Finally
      If st IsNot Nothing Then
        st.Close()
      End If
    End Try
    Return ret
  End Function
  Private Shared Function RemoveInvalidChars(ByVal FilePath As String) As Integer
    If Not IsFileAvailable(FilePath) Then
      Return 1
    End If
    Dim ret As Boolean = False
    Dim tr As IO.StreamReader = New IO.StreamReader(FilePath)
    Dim mStr As String = tr.ReadToEnd
    tr.Close()
    tr.Dispose()

    Try
      mStr = mStr.Replace("∅", "Dia").Replace("ø", "Dia").Replace("€", "Euro").Replace("—", "-")
      mStr = mStr.Replace("&#xA;", "").Replace("–", "-")
      mStr = mStr.Replace("'", " ")
      mStr = mStr.Replace(Chr(145), " ").Replace(Chr(146), " ").Replace(Chr(96), " ").Replace(Chr(180), " ")
      mStr = mStr.Replace(Chr(147), " ").Replace(Chr(148), " ")
    Catch ex As Exception
      Return 3
    End Try
    mStr = RemoveIllegalXMLCharacters(mStr)
    Try
      Dim tw As IO.StreamWriter = New IO.StreamWriter(FilePath)
      tw.Write(mStr)
      tw.Close()
      tw.Dispose()
    Catch ex As Exception
      Return 3
    End Try
    Return 0
  End Function
  Public Shared Function RemoveIllegalXMLCharacters(ByVal Content As String) As String
    'Used to hold the output.
    Dim textOut As New StringBuilder()
    'Used to reference the current character.
    Dim current As Char
    'Exit out and return an empty string if nothing was passed in to method
    If Content Is Nothing OrElse Content = String.Empty Then
      Return String.Empty
    End If


    'Loop through the lenght of the content (1) character at a time to see if there
    'are any illegal characters to be removed:
    For i As Integer = 0 To Content.Length - 1
      'Reference the current character
      current = Content(i)
      'Only append back to the StringBuilder valid non-illegal characters
      If (AscW(current) = &H9 OrElse AscW(current) = &HA OrElse AscW(current) = &HD) _
               OrElse ((AscW(current) >= &H20) AndAlso (AscW(current) <= &HD7FF)) _
               OrElse ((AscW(current) >= &HE000) AndAlso (AscW(current) <= &HFFFD)) _
               OrElse ((AscW(current) >= &H10000) AndAlso (AscW(current) <= &H10FFFF)) Then
        textOut.Append(current)
      End If
    Next


    'Return the screened content with only valid characters
    Return textOut.ToString()


  End Function
  Sub New()
    Errors = New ArrayList
  End Sub
  Public Shared Function GetHTMLError(ByVal fl As dataXML) As String
    Dim oTbl As New Table
    oTbl.GridLines = GridLines.Both
    oTbl.Width = 700
    oTbl.Style.Add("text-align", "left")
    oTbl.Style.Add("font", "Tahoma")
    Dim oCol As TableCell = Nothing
    Dim oRow As TableRow = Nothing
    '1.
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Transfer to BaaN-PLM Failed"
    oCol.Style.Add("text-align", "center")
    oCol.Style.Add("border-bottom", "none")
    oCol.Font.Size = "14"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    '2.
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "<u>Error(s) found while Transfering Document to BaaN-PLM</u>"
    oCol.Style.Add("text-align", "center")
    oCol.Style.Add("border-bottom", "none")
    oCol.Font.Size = "10"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    '2.
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Transfer Stopped. Please correct them and transfer again."
    oCol.Style.Add("text-align", "center")
    oCol.Style.Add("border-bottom", "none")
    oCol.Font.Size = "10"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    For Each dd As String In fl.Errors
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = dd
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = dd
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
    Next

    Dim sb As StringBuilder = New StringBuilder()
    Dim sw As IO.StringWriter = New IO.StringWriter(sb)
    Dim writer As HtmlTextWriter = New HtmlTextWriter(sw)
    Try
      oTbl.RenderControl(writer)
    Catch ex As Exception
    End Try
    Dim Header As String = ""
    Header = Header & "<html xmlns=""http://www.w3.org/1999/xhtml"">"
    Header = Header & "<head>"
    Header = Header & "<title></title>"
    Header = Header & "<style>"
    Header = Header & "table{"

    Header = Header & "border: solid 1pt black;"
    Header = Header & "border-collapse:collapse;"
    Header = Header & "font-family: Tahoma;}"

    Header = Header & "td{"
    Header = Header & "border: solid 1pt black;"
    Header = Header & "font-family: Tahoma;"
    Header = Header & "font-size: 9px;"
    Header = Header & "vertical-align:top;}"

    Header = Header & "</style>"
    Header = Header & "</head>"
    Header = Header & "<body>"
    Header = Header & sb.ToString
    Header = Header & "</body></html>"

    Return sb.ToString
  End Function
  Public Shared Function GetMailID(ByVal LoginID As String) As String
    Dim _Result As String = ""
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
      Using Cmd As SqlCommand = Con.CreateCommand()
        Dim mSql As String = "SELECT TOP 1 EMailID FROM HRM_Employees WHERE CardNo = '" & LoginID & "'"
        Cmd.CommandType = System.Data.CommandType.Text
        Cmd.CommandText = mSql
        Con.Open()
        _Result = Cmd.ExecuteScalar()
        If _Result IsNot Nothing Then
          If Convert.IsDBNull(_Result) Then
            _Result = ""
          End If
        Else
          _Result = ""
        End If
      End Using
    End Using
    Return _Result
  End Function
  Public Shared Sub SendMail(ByVal fl As dataXML)
    Dim emailIDError As Boolean = False
    Dim ToEMailID As String = ""
    Try
      ToEMailID = GetMailID(fl.VaultUserName)
    Catch ex As Exception
      ToEMailID = "baansupport@isgec.co.in"
      emailIDError = True
    End Try
    Try
      Dim oClient As SmtpClient = New SmtpClient("192.9.200.214", 25)
      oClient.Credentials = New Net.NetworkCredential("adskvaultadmin", "isgec@123")
      Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
      oMsg.From = New System.Net.Mail.MailAddress("Error IN Transfer Vault To ERPLN<adskvaultadmin@isgec.co.in>")
      With oMsg
        If ToEMailID <> String.Empty Then
          .To.Add(ToEMailID)
        End If
        .To.Add("adskvaultadmin@isgec.co.in")
        '.CC.Add("harishkumar@isgec.co.in")
        .IsBodyHtml = True
        .Subject = fl.number & " Not Transfered in BaaN"
        If emailIDError Then
          .Body = "E-Mail Address Not found for Vault User : " & fl.VaultUserName
        End If
        .Body = .Body & dataXML.GetHTMLError(fl)
      End With
      If SIS.SYS.SQLDatabase.DBCommon.BaaNLive Then
        oClient.Send(oMsg)
      End If
    Catch ex As Exception
    End Try
  End Sub
#Region "IDisposable Support"
  Private disposedValue As Boolean ' To detect redundant calls

  ' IDisposable
  Protected Overridable Sub Dispose(ByVal disposing As Boolean)
    If Not Me.disposedValue Then
      If disposing Then
        ' TODO: dispose managed state (managed objects).
        Errors.Clear()
        Errors = Nothing
      End If

      ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
      ' TODO: set large fields to null.
    End If
    Me.disposedValue = True
  End Sub

  ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
  'Protected Overrides Sub Finalize()
  '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
  '    Dispose(False)
  '    MyBase.Finalize()
  'End Sub

  ' This code added by Visual Basic to correctly implement the disposable pattern.
  Public Sub Dispose() Implements IDisposable.Dispose
    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    Dispose(True)
    GC.SuppressFinalize(Me)
  End Sub
#End Region

End Class
