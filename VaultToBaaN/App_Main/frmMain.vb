Imports System.Xml
Imports System.IO
Imports System.Timers
Imports System.Diagnostics
Imports System.Security

Public Class frmMain

  Dim configXml As String = ""
  Delegate Sub ThreadedSub()
  Delegate Sub NewThreadedSub(ByVal lb As ListBox)
  Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    configXml = Application.StartupPath & "\EDIConfig.xml"
    SIS.SYS.SQLDatabase.DBCommon.BaaNLive = True
  End Sub
#Region " LockUnlock Service "
  Private oLU As LockUnlockService
  Private oLUM As LUMonitor
  Private Sub luStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles luStart.Click
    luStart.Enabled = False
    luLogs.Items.Clear()
    Dim lu As NewThreadedSub = AddressOf StartLockUnlockService
    lu.BeginInvoke(luLogs, Nothing, Nothing)
    luStop.Enabled = True
    lumStart.Enabled = True
  End Sub
  Private Sub luStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles luStop.Click
    luStop.Enabled = False
    lumStart.Enabled = False
    lumStop.Enabled = False
    oLU.StopJob()
    oLU = Nothing
    luStart.Enabled = True
  End Sub
  Private Sub StartLockUnlockService(ByVal lb As ListBox)
    oLU = New LockUnlockService(lb)
    oLU.Start()
  End Sub
  Private Sub lumStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lumStart.Click
    lumStart.Enabled = False
    luStop.Enabled = False
    Dim lum As ThreadedSub = AddressOf LUMonitoring
    lum.BeginInvoke(Nothing, Nothing)
    lumStop.Enabled = True
  End Sub
  Private Sub lumStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lumStop.Click
    lumStop.Enabled = False
    oLUM.StopJob()
    oLUM = Nothing
    lumStart.Enabled = True
    luStop.Enabled = True
  End Sub
  Private Sub LUMonitoring()
    If pmSplit1.Panel2.InvokeRequired Then
      pmSplit1.Panel2.Invoke(New ThreadedSub(AddressOf StartLUMonitoring))
    Else
      StartLUMonitoring()
    End If
  End Sub
  Private Sub StartLUMonitoring()
    pmSplit1.Panel2.Controls.Clear()
    oLUM = New LUMonitor()
    Dim tmp As TreeView = oLUM.Monitor
    tmp.Dock = DockStyle.Fill
    tmp.Visible = True
    pmSplit1.Panel2.Controls.Add(tmp)
    oLUM.Start()
  End Sub
#End Region
#Region " Job Distributer "
  Private oJD As JobDistributer
  Private oJDM As JDMonitor
  Private Sub jdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles jdStop.Click
    jdStop.Enabled = False
    jdmStart.Enabled = False
    jdmStop.Enabled = False
    oJD.StopJob()
    oJD = Nothing
    jdStart.Enabled = True
  End Sub
  Private Sub jdStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles jdStart.Click
    jdStart.Enabled = False
    Dim jd As ThreadedSub = AddressOf StartJobDistributer
    jd.BeginInvoke(Nothing, Nothing)
    jdStop.Enabled = True
    jdmStart.Enabled = True
  End Sub
  Private Sub StartJobDistributer()
    oJD = New JobDistributer
    oJD.Start()
  End Sub
  Private Sub jdmStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles jdmStop.Click
    jdmStop.Enabled = False
    oJDM.StopJob()
    oJDM = Nothing
    jdmStart.Enabled = True
    jdStop.Enabled = True
  End Sub
  Private Sub jdmStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles jdmStart.Click
    jdmStart.Enabled = False
    jdStop.Enabled = False
    Dim jdm As ThreadedSub = AddressOf JDMonitoring
    jdm.BeginInvoke(Nothing, Nothing)
    jdmStop.Enabled = True
  End Sub
  Private Sub JDMonitoring()
    If pmSplit.Panel1.InvokeRequired Then
      pmSplit.Panel1.Invoke(New ThreadedSub(AddressOf StartJDMonitoring))
    Else
      StartJDMonitoring()
    End If
  End Sub
  Private Sub StartJDMonitoring()
    pmSplit.Panel1.Controls.Clear()
    oJDM = New JDMonitor()
    Dim tmp As TreeView = oJDM.Monitor
    tmp.Dock = DockStyle.Fill
    tmp.Visible = True
    pmSplit.Panel1.Controls.Add(tmp)
    oJDM.Start()
  End Sub
#End Region
#Region " XML Processor "
  Private oXP As XmlProcessor
  Private oXPM As XPMonitor
  Private Sub xpStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles xpStart.Click
    xpStart.Enabled = False
    Dim xp As ThreadedSub = AddressOf StartXMLProcessor
    xp.BeginInvoke(Nothing, Nothing)

    xpStop.Enabled = True
    xpmStart.Enabled = True
  End Sub
  Private Sub xpStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles xpStop.Click
    xpStop.Enabled = False
    xpmStart.Enabled = False
    xpmStop.Enabled = False
    oXP.StopJob()
    oXP = Nothing
    xpStart.Enabled = True
  End Sub
  Private Sub StartXMLProcessor()
    oXP = New XmlProcessor
    If cmdDirect.Text = "Use Direct Property Update" Then
      oXP.UseDirect = True
    End If
    oXP.Start()
  End Sub
  Private Sub xpmStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles xpmStart.Click
    xpmStart.Enabled = False
    xpStop.Enabled = False
    Dim xpm As ThreadedSub = AddressOf XPMonitoring
    xpm.BeginInvoke(Nothing, Nothing)
    xpmStop.Enabled = True
  End Sub
  Private Sub xpmStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles xpmStop.Click
    xpmStop.Enabled = False
    oXPM.StopJob()
    oXPM = Nothing
    xpmStart.Enabled = True
    xpStop.Enabled = True
  End Sub
  Private Sub XPMonitoring()
    If pmSplit1.Panel1.InvokeRequired Then
      pmSplit1.Panel1.Invoke(New ThreadedSub(AddressOf StartXPMonitoring))
    Else
      StartXPMonitoring()
    End If
  End Sub
  Private Sub StartXPMonitoring()
    pmSplit1.Panel1.Controls.Clear()
    oXPM = New XPMonitor()
    Dim tmp As TreeView = oXPM.Monitor
    tmp.Dock = DockStyle.Fill
    tmp.Visible = True
    pmSplit1.Panel1.Controls.Add(tmp)
    oXPM.Start()
  End Sub
#End Region
#Region " BOM Export EXE Launcher "

  Function ConvertToSecureString(ByVal str As String)
    Dim password As New SecureString
    For Each c As Char In str.ToCharArray
      password.AppendChar(c)
    Next
    Return password
  End Function
  Private Function RestartBOM(ByVal strUser As String) As Boolean
    Dim oPrcs() As Process = Process.GetProcessesByName(strUser)
    If oPrcs.Length > 0 Then
      If MsgBox("Process " & strUser & " is allready running. Restart Process ?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
        For Each prc As Process In oPrcs
          prc.Kill()
        Next
        Return True
      End If
    Else
      Return True
    End If
    Return False
  End Function
  Private Sub cmdBom0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBom0.Click
    If RestartBOM("0BomExport") Then
      Try
        Dim password As SecureString = ConvertToSecureString("bom@12345".ToString())
        Dim proc As Process = Process.Start(AppConfigs.Value("BomExportEXEPath") & "\0\0BomExport.exe".ToString(), "bom0".ToString(), password, "".ToString())
        proc.EnableRaisingEvents = True
      Catch w32e As System.ComponentModel.Win32Exception
      End Try
    End If
  End Sub
  Private Sub cmdBom1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBom1.Click
    If RestartBOM("1BomExport") Then
      Try
        Dim password As SecureString = ConvertToSecureString("bom@12345".ToString())
        Dim proc As Process = Process.Start(AppConfigs.Value("BomExportEXEPath") & "\1\1BomExport.exe".ToString(), "bom1".ToString(), password, "".ToString())
        proc.EnableRaisingEvents = True
      Catch w32e As System.ComponentModel.Win32Exception
      End Try
    End If
  End Sub

  Private Sub cmdBom2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBom2.Click
    If RestartBOM("2BomExport") Then
      Try
        Dim password As SecureString = ConvertToSecureString("bom@12345".ToString())
        Dim proc As Process = Process.Start(AppConfigs.Value("BomExportEXEPath") & "\2\2BomExport.exe".ToString(), "bom2".ToString(), password, "".ToString())
        proc.EnableRaisingEvents = True
      Catch w32e As System.ComponentModel.Win32Exception
      End Try
    End If
  End Sub
  Private Sub cmdBom3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBom3.Click
    If RestartBOM("3BomExport") Then
      Try
        Dim password As SecureString = ConvertToSecureString("bom@12345".ToString())
        Dim proc As Process = Process.Start(AppConfigs.Value("BomExportEXEPath") & "\3\3BomExport.exe".ToString(), "bom3".ToString(), password, "".ToString())
        proc.EnableRaisingEvents = True
      Catch w32e As System.ComponentModel.Win32Exception
      End Try
    End If
  End Sub
#End Region
#Region " Configuration File Handling "
  Private Function CreateConfig(ByVal TableName As String, ByVal ParamArray ColumnNames() As String) As Boolean
    Dim writer As New XmlTextWriter(configXml, System.Text.Encoding.UTF8)
    Try
      writer.WriteStartDocument(True)
      writer.Formatting = Formatting.Indented
      writer.Indentation = 2
      writer.WriteStartElement("Table")
      writer.WriteStartElement(TableName)
      For Each ColumnName As String In ColumnNames
        writer.WriteStartElement(ColumnName)
        writer.WriteString(String.Empty)
        writer.WriteEndElement()
      Next
      writer.WriteEndElement()
      writer.WriteEndElement()
      writer.WriteEndDocument()
      writer.Close()
    Catch ex As Exception
      MsgBox("Cannot create new table.")
      Return False
    End Try

    Return True
  End Function
  Private Sub ReadConfig()
    Dim xmlFile As XmlReader
    Dim ds As New DataSet
    xmlFile = XmlReader.Create(configXml, New XmlReaderSettings())
    ds.ReadXml(xmlFile)
    xmlFile.Close()
    Me.GrdConfig.DataSource = ds.Tables(0)
    ReSetDisplay()
  End Sub
  Private Sub ReSetDisplay()
    With Me.GrdConfig
      .Columns(0).Width = (GrdConfig.Width - 100) / 2
      .Columns(1).Width = .Columns(0).Width
    End With
    For Each row As DataGridViewRow In GrdConfig.Rows
      If row.Cells(0).Value <> String.Empty Then
        row.Cells(0).ReadOnly = True
      End If
    Next
  End Sub
  Private Sub mConfigLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mConfigLoad.Click
    If Not IO.File.Exists(configXml) Then
      Me.CreateConfig("Properties", "FieldName", "FieldValue")
    End If
    ReadConfig()
  End Sub
  Private Sub mConfigSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mConfigSave.Click
    Dim dt As New DataTable
    Me.GrdConfig.EndEdit()
    dt = Me.GrdConfig.DataSource
    dt.WriteXml(configXml)
    ReadConfig()
  End Sub
#End Region

#Region " Queue Watcher "
  Private oQ As QueueWatcher
  Private Sub qStart_Click(sender As Object, e As EventArgs) Handles qStart.Click
    qStart.Enabled = False
    Dim q As ThreadedSub = AddressOf StartqWatcherService
    q.BeginInvoke(Nothing, Nothing)
    qStop.Enabled = True
  End Sub
  Private Sub qStop_Click(sender As Object, e As EventArgs) Handles qStop.Click
    qStop.Enabled = False
    oQ.StopJob()
    oQ = Nothing
    qStart.Enabled = True

  End Sub
  Private Sub StartqWatcherService()
    oQ = New QueueWatcher()
    oQ.Start()
  End Sub

#End Region


  Private Sub cmSaveLog_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmSaveLog.Click
    With sfd
      .Title = "Save log file"
      .Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
      .ShowDialog()
      If .FileName <> String.Empty Then
        Dim oTW As IO.StreamWriter = New IO.StreamWriter(.FileName)
        Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)
        Dim olst As ListBox = CType(cms.SourceControl, ListBox)
        For Each itm As String In olst.Items
          oTW.WriteLine(itm)
        Next
        oTW.Close()
        oTW.Dispose()
      End If
    End With
  End Sub
  Private Sub cmClearLog_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmClearLog.Click
    If MessageBox.Show("Clear Log ?", "", MessageBoxButtons.OKCancel) = DialogResult.OK Then
      Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
      Dim cms As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)
      CType(cms.SourceControl, ListBox).Items.Clear()
    End If
  End Sub
  Private Sub cmFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmFind.Click
    Dim mStr As String = InputBox("Text to find", "Find", "")
    If mStr <> String.Empty Then
      Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
      Dim cms As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)
      Dim olst As ListBox = CType(cms.SourceControl, ListBox)
      For i As Integer = 0 To olst.Items.Count - 1
        If olst.Items(i).ToString.IndexOf(mStr, StringComparison.CurrentCultureIgnoreCase) > -1 Then
          olst.SelectedIndex = i
          Exit For
        End If
      Next
    End If
  End Sub

  Private Sub cmdDirect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDirect.Click
    Dim oBut As Button = CType(sender, Button)
    If oBut.Text = "Use Direct Property Update" Then
      oBut.Text = "Using Direct Update"
      If oXP IsNot Nothing Then
        oXP.UseDirect = True
      End If
    Else
      oBut.Text = "Use Direct Property Update"
      If oXP IsNot Nothing Then
        oXP.UseDirect = False
      End If
    End If
  End Sub
#Region " BaaN Upload "
  Private Sub bnStart_Click(sender As System.Object, e As System.EventArgs) Handles bnStart.Click

  End Sub

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    VaultUtil.userName = "VAULTPROCESS"
    VaultUtil.password = "VAULTPROCESS"
    VaultUtil.serverName = "bramha"
    VaultUtil.vaultName = "SMD"
    Try
      VaultUtil.LogInStandard(VaultUtil.serverName, VaultUtil.vaultName, VaultUtil.userName, VaultUtil.password)
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try

  End Sub


#End Region
End Class



