Imports System.Net.Mail

Public Class QueueWatcher
  Inherits TimerSupport

  Private _BomExportEXECount As Integer = 0
  'Queue when Job File Not Converted to XML
  Private _JobDistributerOutputPath As String = ""
  'Queue when XML File not imported in ERP-LN
  Private _XMLProcessorCommonOutputPath As String = ""
  Private _AlertIfNotProcessedTill As Long = 0
  Private _AlertToEMailIDs As String = ""
  Private aJobWatcher(_BomExportEXECount - 1) As ArrayList
  Private aXmlWatcher(_BomExportEXECount - 1) As ArrayList
  Private elapsed As Long = 0
  Public Overrides Sub Process()
    Dim I As Integer = 0
    If elapsed < _AlertIfNotProcessedTill Then
      elapsed += Me.Interval
    End If
    Try
      For I = 0 To _BomExportEXECount - 1
        'Job
        Try
          Dim dirInfo As New IO.DirectoryInfo(_JobDistributerOutputPath & "\" & I)
          Dim aFiles() As IO.FileInfo = dirInfo.GetFiles("*.job")
          If aFiles.Count <= 0 Then Continue For
          Array.Sort(aFiles, Function(x, y) y.LastWriteTime.CompareTo(x.LastWriteTime))
          Dim oldestFile As IO.FileInfo = aFiles(0)
          If elapsed < _AlertIfNotProcessedTill Then
            aJobWatcher(I).Add(oldestFile)
          Else
            If CType(aJobWatcher(I)(0), IO.FileInfo).Name = oldestFile.Name Then
              SendMail(aJobWatcher(I)(0))
            End If
            aJobWatcher(I).RemoveAt(0)
            aJobWatcher(I).Add(oldestFile)
          End If
        Catch ex As Exception
        End Try
        'XML
        Try
          Dim dirInfo As New IO.DirectoryInfo(_XMLProcessorCommonOutputPath & "\" & I)
          Dim aFiles() As IO.FileInfo = dirInfo.GetFiles("*.xml")
          If aFiles.Count <= 0 Then Continue For
          Array.Sort(aFiles, Function(x, y) y.LastWriteTime.CompareTo(x.LastWriteTime))
          Dim oldestFile As IO.FileInfo = aFiles(0)
          If elapsed < _AlertIfNotProcessedTill Then
            aXmlWatcher(I).Add(oldestFile)
          Else
            If CType(aXmlWatcher(I)(0), IO.FileInfo).Name = oldestFile.Name Then
              SendMail(aXmlWatcher(I)(0))
            End If
            aXmlWatcher(I).RemoveAt(0)
            aXmlWatcher(I).Add(oldestFile)
          End If
        Catch ex As Exception
        End Try
      Next ' BOM Exe Count I
    Catch ex As Exception
    End Try
  End Sub
  Public Sub New()
    _BomExportEXECount = AppConfigs.Value("BomExportEXECount")
    _XMLProcessorCommonOutputPath = AppConfigs.Value("XMLProcessorCommonOutputPath")
    _JobDistributerOutputPath = AppConfigs.Value("JobDistributerOutputPath")
    _AlertIfNotProcessedTill = AppConfigs.Value("AlertIfNotProcessedTill")
    _AlertToEMailIDs = AppConfigs.Value("AlertToEMailIDs")
    Me.Interval = AppConfigs.Value("XMLProcessorInterval")
  End Sub
  Public Overrides Sub Started()
    MyBase.Started()
    For i = 0 To _BomExportEXECount - 1
      aJobWatcher(i) = New ArrayList
    Next
    For i = 0 To _BomExportEXECount - 1
      aXmlWatcher(i) = New ArrayList
    Next
  End Sub

  Public Overrides Sub Stopped()
  End Sub
  Public Sub SendMail(ByVal fl As IO.FileInfo)
    Dim emailIDError As Boolean = False
    Dim aToEMailID() As String = _AlertToEMailIDs.Split(",".ToCharArray)
    Try
      Dim oClient As SmtpClient = New SmtpClient("192.9.200.214", 25)
      oClient.Credentials = New Net.NetworkCredential("adskvaultadmin", "isgec@123")
      Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
      oMsg.From = New System.Net.Mail.MailAddress("Stopped-Transfer To BaaN-PLM<adskvaultadmin@isgec.co.in>")
      With oMsg
        For Each tmp As String In aToEMailID
          .To.Add(tmp)
        Next
        .To.Add("adskvaultadmin@isgec.co.in")
        .IsBodyHtml = True
        .Subject = fl.Name & " Not transfered in BaaN since " & fl.LastWriteTime
        .Body = fl.Name & " Not transfered in BaaN since " & fl.LastWriteTime
      End With
      If SIS.SYS.SQLDatabase.DBCommon.BaaNLive Then
        oClient.Send(oMsg)
      End If
    Catch ex As Exception
    End Try
  End Sub

End Class
