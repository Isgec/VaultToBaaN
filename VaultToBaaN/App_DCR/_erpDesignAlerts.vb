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
Namespace SIS.Design
  Public Class Alerts
    Public Shared Function DcrAlert(ByVal DCRNo As String, Optional ByVal oDoc As SIS.ERP.erpDCRDetail = Nothing, Optional ByVal ReleasedRevision As String = "") As Boolean
      Dim ForRelease As Boolean = IIf(oDoc Is Nothing, False, True)
      'First Check If E-Mail Already Sent for DCR ID
      Dim oDCR As SIS.ERP.erpDCRHeader = SIS.ERP.erpDCRHeader.erpDCRHeaderGetByID(DCRNo)
      If Not ForRelease Then
        If oDCR IsNot Nothing Then
          Return False
        End If
      End If
      'End Of Already Sent Check
      Dim aErr As New ArrayList
      Dim IndentFound As Boolean = False
      Dim mRet As String = ""
      Dim oClient As SmtpClient = New SmtpClient("192.9.200.214", 25)
      Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
      oClient.Credentials = New Net.NetworkCredential("adskvaultadmin", "isgec@123")
      Dim oDcrH As SIS.ERP.erpDCRHeader = SIS.ERP.erpDCRHeader.BaaNDCRHeaderSelectList(DCRNo)
      Dim oDcrD As List(Of SIS.ERP.erpDCRDetail) = SIS.ERP.erpDCRDetail.BaaNDCRDetailSelectList(DCRNo)
      With oMsg
        If oDcrH.CreatedEMail = String.Empty Then
          aErr.Add(oDcrH.CreatedBy & " " & oDcrH.CreatedName)
          .From = New MailAddress("baansupport@isgec.co.in", "BaaN Support")
          .CC.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
        Else
          .From = New MailAddress(oDcrH.CreatedEMail, oDcrH.CreatedName)
          .CC.Add(New MailAddress(oDcrH.CreatedEMail, oDcrH.CreatedName))
        End If
        .Bcc.Add(New MailAddress("lalit@isgec.co.in", "Lalit Gupta"))
        '.CC.Add(New MailAddress("harishkumar@isgec.co.in", "Harish Kumar"))
        '.CC.Add(New MailAddress("ajay.gupta@isgec.co.in", "Ajay Gupta"))
        .Bcc.Add(New MailAddress("dcrlog@isgec.co.in", "DCR Alerts Log"))
        If Not ForRelease Then
          .Subject = "Drawing Change Initiated: PROJECT " & oDcrH.ProjectID & " " & oDcrH.ProjectDescription
        Else
          .Subject = "Document of DCR No." & DCRNo & " Released: " & oDoc.DocumentID & " REV: " & ReleasedRevision
        End If
        For Each dcrD As SIS.ERP.erpDCRDetail In oDcrD
          If dcrD.IndentNo <> String.Empty Then
            IndentFound = True
            Try
              If dcrD.IndenterEMail = String.Empty Then
                aErr.Add(dcrD.IndenterID & " " & dcrD.IndenterName)
              Else
                Dim Indenter As MailAddress = New MailAddress(dcrD.IndenterEMail, dcrD.IndenterName)
                If Not .CC.Contains(Indenter) Then
                  .CC.Add(Indenter)
                End If
              End If
            Catch ex As Exception
            End Try
            Try
              Dim Buyer As MailAddress = Nothing
              If dcrD.OrderNo <> String.Empty Then
                If dcrD.BuyerIDinPOEMail = String.Empty Then
                  aErr.Add(dcrD.BuyerIDinPO & " " & dcrD.BuyerIDinPOName)
                  If dcrD.BuyerEMail = String.Empty Then
                    aErr.Add(dcrD.BuyerID & " " & dcrD.BuyerName)
                  Else
                    Buyer = New MailAddress(dcrD.BuyerEMail, dcrD.BuyerName)
                  End If
                Else
                  Buyer = New MailAddress(dcrD.BuyerIDinPOEMail, dcrD.BuyerName)
                End If
              Else
                If dcrD.BuyerEMail = String.Empty Then
                  aErr.Add(dcrD.BuyerID & " " & dcrD.BuyerName)
                Else
                  Buyer = New MailAddress(dcrD.BuyerEMail, dcrD.BuyerName)
                End If
              End If
              If Buyer IsNot Nothing Then
                If Not .To.Contains(Buyer) Then
                  .To.Add(Buyer)
                End If
              End If
            Catch ex As Exception
            End Try
          End If
        Next
        '=============Transmittal============
        Dim aTmtls As List(Of SIS.EDI.ediTmtlH) = Nothing
        If oDoc Is Nothing Then
          aTmtls = SIS.EDI.ediTmtlH.TmtlEMailIDsForDCR(DCRNo)
        Else
          aTmtls = SIS.EDI.ediTmtlH.TmtlEMailIDsForDoc(oDoc.DocumentID)
        End If
        For Each oTmtl As SIS.EDI.ediTmtlH In aTmtls
          Dim Issuer As emp = emp.GetEmp(oTmtl.t_isby)
          Dim Approver As emp = emp.GetEmp(oTmtl.t_apsu)
          Dim Creator As emp = emp.GetEmp(oTmtl.t_user)
          Dim EMailIDError As String = ""
          Dim x As MailAddress = Nothing
          Try
            Select Case oTmtl.t_type
              Case tmtlType.Customer
                x = gma(Issuer, aErr, "CT-Issuer-From")
                If x IsNot Nothing Then
                  '.From = x
                  If Not .CC.Contains(x) Then .CC.Add(x)
                End If
                x = gma(Approver, aErr, "CT-Approver-To")
                If x IsNot Nothing Then If Not .To.Contains(x) Then .To.Add(x)
                x = gma(Creator, aErr, "CT-Creator-CC")
                If x IsNot Nothing Then If Not .CC.Contains(x) Then .CC.Add(x)
              Case tmtlType.Internal
                Dim IssuedTo As emp = emp.GetEmp(oTmtl.t_logn)
                x = gma(Issuer, aErr, "IT-Issuer-From")
                If x IsNot Nothing Then
                  '.From = x
                  If Not .CC.Contains(x) Then .CC.Add(x)
                End If
                x = gma(IssuedTo, aErr, "IT-IssuedTo-To")
                If x IsNot Nothing Then If Not .To.Contains(x) Then .To.Add(x)
                x = gma(Approver, aErr, "IT-Approver-CC")
                If x IsNot Nothing Then If Not .CC.Contains(x) Then .CC.Add(x)
                x = gma(Creator, aErr, "IT-Creator-CC")
                If x IsNot Nothing Then If Not .CC.Contains(x) Then .CC.Add(x)
              Case tmtlType.Site
                x = gma(Issuer, aErr, "ST-Issuer-From")
                If x IsNot Nothing Then
                  '.From = x
                  If Not .CC.Contains(x) Then .CC.Add(x)
                End If
                x = gma(Approver, aErr, "ST-Approver-To")
                If x IsNot Nothing Then If Not .To.Contains(x) Then .To.Add(x)
                x = gma(Creator, aErr, "ST-Creator-CC")
                If x IsNot Nothing Then If Not .CC.Contains(x) Then .CC.Add(x)
                'Transmittal Site Address
                Dim SiteIDs As String = emp.GetSiteEmailIDs(oTmtl.t_cprj, oTmtl.t_padr)
                If SiteIDs <> "" Then
                  Dim aIDs() As String = SiteIDs.Split(",;".ToCharArray)
                  For Each id As String In aIDs
                    Try
                      x = New MailAddress(id.Trim, id.Trim)
                      If Not .CC.Contains(x) Then .CC.Add(x)
                    Catch ex As Exception
                    End Try
                  Next
                End If
              Case tmtlType.Vendor
                x = gma(Issuer, aErr, "VT-Issuer-From")
                If x IsNot Nothing Then
                  '.From = x
                  If Not .CC.Contains(x) Then .CC.Add(x)
                End If
                Dim tmp As String = emp.GetReceiptCreator(oTmtl.t_tran)
                If tmp = "SUPPLIER" Or tmp = "" Then
                  x = gma(Approver, aErr, "VT-Approver-To")
                  If x IsNot Nothing Then If Not .To.Contains(x) Then .To.Add(x)
                Else
                  Dim tmpR As emp = emp.GetEmp(tmp)
                  x = gma(tmpR, aErr, "VT-ReceiptCreator-To")
                  If x IsNot Nothing Then If Not .To.Contains(x) Then .To.Add(x)
                  x = gma(Approver, aErr, "VT-Approver-CC")
                  If x IsNot Nothing Then If Not .CC.Contains(x) Then .CC.Add(x)
                End If
                x = gma(Creator, aErr, "VT-Creator-CC")
                If x IsNot Nothing Then If Not .CC.Contains(x) Then .CC.Add(x)
                'GetPOIssuer From Joomla
                Dim tmpPONo As String = emp.GetPONoOfReceipt(oTmtl.t_tran)
                If tmpPONo <> "" Then
                  Dim POIssuer As String = emp.GetTCPOIssuer(tmpPONo)
                  Dim POBuyer As String = emp.GetPOBuyer(tmpPONo)
                  x = gma(emp.GetWebUser(POIssuer), aErr, "PO-Issuer")
                  If x IsNot Nothing Then If Not .CC.Contains(x) Then .CC.Add(x)
                  x = gma(emp.GetWebUser(POBuyer), aErr, "PO-Buyer")
                  If x IsNot Nothing Then If Not .CC.Contains(x) Then .CC.Add(x)
                End If
            End Select
          Catch ex As Exception
            EMailIDError = ex.Message
          End Try
        Next
        '====================================
      End With
      With oMsg
        If .To.Count <= 0 Then
          .To.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
        End If
        .IsBodyHtml = True
        Dim oTbl As Table = GetTable(oDcrH, oDcrD, oDoc)
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
        If aErr.Count > 0 Then
          Header = Header & "<table>"
          Header = Header & "<tr><td style=""color: red""><i><b>"
          Header = Header & "NOTE: DCR Alert could not be delivered to following recipient(s), Please update their E-Mail ID in ERP-LN."
          Header = Header & "</b></i></td></tr>"
          For Each Err As String In aErr
            Header = Header & "<tr><td color=""red""><i>"
            Header = Header & Err
            Header = Header & "</i></td></tr>"
          Next
          Header = Header & "</table>"
        End If
        Header = Header & sb.ToString
        Header = Header & "</body></html>"
        .Body = Header
      End With
      Try
        If IndentFound Then
          If SIS.SYS.SQLDatabase.DBCommon.BaaNLive Then
            oClient.Send(oMsg)
          End If
        End If
      Catch ex As Exception
      End Try
      If Not ForRelease Then
        If IndentFound Then
          'Insert in PerkDB
          SIS.ERP.erpDCRHeader.InsertData(oDcrH)
          For Each dcrD As SIS.ERP.erpDCRDetail In oDcrD
            SIS.ERP.erpDCRDetail.InsertData(dcrD)
          Next
          'End Of Insert
        End If
      End If
      Return True
    End Function
    Private Enum tmtlType
      Customer = 1
      Internal = 2
      Site = 3
      Vendor = 4
    End Enum
    Private Class emp
      Public Property empID As Integer = 0
      Public Property empName As String = ""
      Public Property empEMail As String = ""
      Public Property webUser As String = ""

      Public Shared Function GetEmp(ByVal empID As Integer) As emp
        Dim mSql As String = ""
        mSql = mSql & " select "
        mSql = mSql & " emp1.t_nama as empName,"
        mSql = mSql & " bpe1.t_mail as empEMail "
        mSql = mSql & " from ttccom001200 as emp1 "
        mSql = mSql & " left outer join tbpmdm001200 as bpe1 on emp1.t_emno=bpe1.t_emno "
        mSql = mSql & " where emp1.t_emno = '" & empID & "'"
        Dim tmp As emp = Nothing
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = mSql
            tmp = New emp
            Con.Open()
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            If (Reader.Read()) Then
              With tmp
                .empID = empID
                If Not Convert.IsDBNull(Reader("empName")) Then .empName = Reader("empName")
                If Not Convert.IsDBNull(Reader("empEMail")) Then .empEMail = Reader("empEMail")
              End With
            End If
            Reader.Close()
          End Using
        End Using
        Return tmp
      End Function

      Public Shared Function GetReceiptCreator(ByVal tmtlID As String) As String
        Dim mSql As String = ""
        mSql = mSql & " select "
        mSql = mSql & " t_user as [user] "
        mSql = mSql & " from tdmisg134200 "
        mSql = mSql & " where t_trno = '" & tmtlID & "'"
        Dim tmp As String = ""
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = mSql
            Con.Open()
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            If (Reader.Read()) Then
              If Not Convert.IsDBNull(Reader("user")) Then tmp = Reader("user")
            End If
            Reader.Close()
          End Using
        End Using
        Return tmp
      End Function
      Public Shared Function GetPONoOfReceipt(ByVal tmtlID As String) As String
        Dim mSql As String = ""
        mSql = mSql & " select top 1 "
        mSql = mSql & " t_orno  "
        mSql = mSql & " from tdmisg134200 "
        mSql = mSql & " where t_trno = '" & tmtlID & "'"
        Dim tmp As String = ""
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = mSql
            Con.Open()
            tmp = Cmd.ExecuteScalar()
            If tmp Is Nothing Then tmp = ""
          End Using
        End Using
        Return tmp
      End Function
      Public Shared Function GetSiteEmailIDs(ByVal ProjectID As String, ByVal AddressID As String) As String
        Dim mSql As String = ""
        mSql = mSql & " select top 1 "
        mSql = mSql & " t_mail  "
        mSql = mSql & " from tdmisg126200 "
        mSql = mSql & " where t_cprj = '" & ProjectID & "'"
        mSql = mSql & " and   t_cadr = '" & AddressID & "'"
        Dim tmp As String = ""
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = mSql
            Con.Open()
            tmp = Cmd.ExecuteScalar()
            If tmp Is Nothing Then tmp = ""
          End Using
        End Using
        Return tmp
      End Function

      Public Shared Function GetTCPOIssuer(ByVal PONo As String) As String
        Dim mSql As String = ""
        mSql = mSql & " select top 1 "
        mSql = mSql & " IssuedBy  "
        mSql = mSql & " from pak_po "
        mSql = mSql & " where pofor='TC' and ponumber = '" & PONo & "'"
        Dim tmp As String = ""
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = mSql
            Con.Open()
            tmp = Cmd.ExecuteScalar()
            If tmp Is Nothing Then tmp = ""
          End Using
        End Using
        Return tmp
      End Function
      Public Shared Function GetPOBuyer(ByVal PONo As String) As String
        Dim mSql As String = ""
        mSql = mSql & " select top 1 "
        mSql = mSql & " BuyerID  "
        mSql = mSql & " from pak_po "
        mSql = mSql & " where pofor='TC' and ponumber = '" & PONo & "'"
        Dim tmp As String = ""
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = mSql
            Con.Open()
            tmp = Cmd.ExecuteScalar()
            If tmp Is Nothing Then tmp = ""
          End Using
        End Using
        Return tmp
      End Function
      Public Shared Function GetWebUser(ByVal webUser As String) As emp
        Dim mSql As String = ""
        mSql = mSql & " select "
        mSql = mSql & " UserFullName as empName,"
        mSql = mSql & " emailid as empEMail "
        mSql = mSql & " from aspnet_users "
        mSql = mSql & " where username = '" & webUser & "'"
        Dim tmp As emp = Nothing
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = mSql
            tmp = New emp
            Con.Open()
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            If (Reader.Read()) Then
              With tmp
                .webUser = webUser
                If Not Convert.IsDBNull(Reader("empName")) Then .empName = Reader("empName")
                If Not Convert.IsDBNull(Reader("empEMail")) Then .empEMail = Reader("empEMail")
              End With
            End If
            Reader.Close()
          End Using
        End Using
        Return tmp
      End Function
    End Class

    Private Shared Function gma(ByVal tmp As emp, ByRef aErr As ArrayList, Optional ByVal State As String = "") As MailAddress
      Dim x As MailAddress = Nothing
      If tmp IsNot Nothing Then
        If tmp.empEMail <> "" Then
          Try
            x = New MailAddress(tmp.empEMail, tmp.empName)
          Catch ex As Exception
            aErr.Add(State & "=> " & ex.Message)
          End Try
        Else
          aErr.Add(State & "=> " & tmp.empID & " : " & tmp.empName)
        End If
      End If
      Return x
    End Function

    Public Shared Function RevisedAlert(ByVal DocumentID As String, ByVal RevisionNo As String) As Boolean
      'Find DCR of Previous Revision
      Dim LastRevision As String = ""
      If RevisionNo > "00" Then
        LastRevision = Right("00" & (Convert.ToInt32(RevisionNo) - 1).ToString, 2)
      Else
        Return False
      End If
      Dim oDoc As SIS.ERP.erpDCRDetail = SIS.ERP.erpDCRDetail.erpDCRDocument(DocumentID, LastRevision)
      If oDoc Is Nothing Then Return False
      '=======Update Drawing New Revision Released Status=========
      With oDoc
        .Released = True
        .ReleasedOn = Now
        .NextRevision = RevisionNo
        .DownloadKey = Guid.NewGuid().ToString
        .DownloadExpiresOn = Now.AddDays(15)
      End With
      SIS.ERP.erpDCRDetail.UpdateData(oDoc)
      '===========================================================
      DcrAlert(oDoc.DCRNo, oDoc, RevisionNo)
      Return True
    End Function
    Public Shared Function GetTable(ByVal dcrH As SIS.ERP.erpDCRHeader, ByVal dcrD As List(Of SIS.ERP.erpDCRDetail), Optional ByVal oDoc As SIS.ERP.erpDCRDetail = Nothing) As Table

      Dim oTbl As New Table
      oTbl.GridLines = GridLines.Both
      oTbl.Width = 900
      oTbl.Style.Add("text-align", "left")
      oTbl.Style.Add("font", "Tahoma")

      Dim oCol As TableCell = Nothing
      Dim oRow As TableRow = Nothing
      '1.
      oRow = New TableRow
      oCol = New TableCell
      oCol.ColumnSpan = "9"
      If oDoc Is Nothing Then
        oCol.Text = "Design Change Initiated"
      Else
        oCol.Text = "Document Released"
      End If
      oCol.Style.Add("text-align", "center")
      oCol.Style.Add("border-bottom", "none")
      oCol.Font.Size = "14"
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      '2.
      oRow = New TableRow
      oCol = New TableCell
      oCol.ColumnSpan = "9"
      If oDoc Is Nothing Then
        oCol.Text = "DCR Approved"
      Else
        oCol.Text = "Request to update Purchase Order"
      End If
      oCol.Style.Add("text-align", "center")
      oCol.Style.Add("border-bottom", "none")
      oCol.Font.Size = "12"
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      '3.
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "DCR NUMBER"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.ColumnSpan = "2"
      oCol.Text = dcrH.DCRNo
      oRow.Cells.Add(oCol)

      oCol = New TableCell
      oCol.Text = "DCR DATE"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.ColumnSpan = "2"
      oCol.Text = dcrH.DCRDate
      oRow.Cells.Add(oCol)

      oCol = New TableCell
      oCol.ColumnSpan = "3"
      oCol.Text = " "
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)

      '4.
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "DCR DESCRIPTION"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.ColumnSpan = "2"
      oCol.Text = dcrH.DCRDescription
      oRow.Cells.Add(oCol)

      oCol = New TableCell
      oCol.Text = "CREATED BY"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.ColumnSpan = "2"
      oCol.Text = dcrH.CreatedName
      oRow.Cells.Add(oCol)

      oCol = New TableCell
      oCol.ColumnSpan = "3"
      oCol.Text = " "
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)

      '5.
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "PROJECT CODE"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.ColumnSpan = "2"
      oCol.Text = dcrH.ProjectID
      oRow.Cells.Add(oCol)

      oCol = New TableCell
      oCol.Text = "PROJECT DESCRIPTION"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.ColumnSpan = "2"
      oCol.Text = dcrH.ProjectDescription
      oRow.Cells.Add(oCol)

      oCol = New TableCell
      oCol.ColumnSpan = "3"
      oCol.Text = " "
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)

      '6.
      oRow = New TableRow
      oCol = New TableCell
      oCol.ColumnSpan = "9"
      oCol.BackColor = Drawing.Color.LightGray
      oCol.Text = "DCR DETAILS"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)

      '7. Column Header
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "DOCUMENT ID"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "REV NO"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "INDENT NO"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "IND.LINE"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "LOT ITEM"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "PO NUMBER"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "PO LINE"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "SUPPLIER"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = "DOCUMENT TITLE"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      '8. Column Details

      For Each dd As SIS.ERP.erpDCRDetail In dcrD
        Dim Found As Boolean = False
        If oDoc IsNot Nothing Then
          If dd.DocumentID = oDoc.DocumentID And dd.RevisionNo = oDoc.RevisionNo Then
            Found = True
          End If
        End If
        oRow = New TableRow
        oCol = New TableCell
        If Found Then
          oCol.ForeColor = Color.Red
          oCol.Font.Bold = True
          oCol.Text = "<a href=http://cloud.isgec.co.in/WebCom1/DCR/EF_erpDCRDetail.aspx?DownloadKey=" & oDoc.DownloadKey & ">" & dd.DocumentID & "</a>"
        Else
          oCol.Text = dd.DocumentID
        End If
        oRow.Cells.Add(oCol)
        oCol = New TableCell
        If Found Then
          oCol.ForeColor = Color.Red
          oCol.Font.Bold = True
        End If
        oCol.Text = dd.RevisionNo
        oRow.Cells.Add(oCol)
        oCol = New TableCell
        If Found Then
          oCol.ForeColor = Color.Red
          oCol.Font.Bold = True
        End If
        oCol.Text = dd.IndentNo
        oRow.Cells.Add(oCol)
        oCol = New TableCell
        If Found Then
          oCol.ForeColor = Color.Red
          oCol.Font.Bold = True
        End If
        oCol.Text = dd.IndentLine
        oRow.Cells.Add(oCol)
        oCol = New TableCell
        If Found Then
          oCol.ForeColor = Color.Red
          oCol.Font.Bold = True
        End If
        oCol.Text = dd.LotItem & " : " & dd.ItemDescription
        oRow.Cells.Add(oCol)
        oCol = New TableCell
        If Found Then
          oCol.ForeColor = Color.Red
          oCol.Font.Bold = True
        End If
        oCol.Text = dd.OrderNo
        oRow.Cells.Add(oCol)
        oCol = New TableCell
        If Found Then
          oCol.ForeColor = Color.Red
          oCol.Font.Bold = True
        End If
        oCol.Text = dd.OrderLine
        oRow.Cells.Add(oCol)
        oCol = New TableCell
        If Found Then
          oCol.ForeColor = Color.Red
          oCol.Font.Bold = True
        End If
        oCol.Text = dd.SupplierID & " : " & dd.SupplierName
        oRow.Cells.Add(oCol)
        oCol = New TableCell
        If Found Then
          oCol.ForeColor = Color.Red
          oCol.Font.Bold = True
        End If
        oCol.Text = dd.DocumentTitle
        oRow.Cells.Add(oCol)
        oTbl.Rows.Add(oRow)
      Next

      Return oTbl
    End Function
  End Class
End Namespace
