Public Class LUMonitor
  Inherits TimerSupport
  Private _ERPLnLockFolder As String = ""
  Private _ERPLnUnlockFolder As String = ""
  Private _LockProcessedPath As String = ""
  Private _LockErrorPath As String = ""
  Private _UnlockProcessedPath As String = ""
  Private _UnlockErrorPath As String = ""
  Private _ERPLnXMLProcessedFolder As String = ""
  Private _ERPLnXMLErrorFolder As String = ""
  Private WithEvents _tv As TreeView
  Public Delegate Sub RenderTreeDelegate()
  Private Sub tv_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles _tv.NodeMouseDoubleClick
    Dim nd As TreeNode = e.Node
    Try
      nd.Nodes.Clear()
      Dim aFiles() As String = IO.Directory.GetFiles(nd.Tag, "*.xml", IO.SearchOption.TopDirectoryOnly)
      If aFiles.Length > 0 Then
        For Each tmpFile As String In aFiles
          Dim nnd As TreeNode = e.Node.Nodes.Add(IO.Path.GetFileName(tmpFile))
          nnd.Tag = tmpFile
          nnd.ForeColor = Color.Blue
        Next
      End If
      nd.Text = "Files: " & aFiles.Length & " [" & nd.Tag.ToString & "]"
    Catch ex As Exception
      nd.Text = "Error: " & ex.Message
      nd.ForeColor = Color.DarkOrange
    End Try
  End Sub
  Public Sub RenderTree()
    With _tv
      For Each nd As TreeNode In _tv.Nodes
        Try
          Dim aFiles() As String = IO.Directory.GetFiles(nd.Tag, "*.xml", IO.SearchOption.TopDirectoryOnly)
          If nd.IsExpanded Then
            nd.Nodes.Clear()
            If aFiles.Length > 0 Then
              For Each tmpFile As String In aFiles
                Dim nnd As TreeNode = nd.Nodes.Add(IO.Path.GetFileName(tmpFile))
                nnd.Tag = tmpFile
                nnd.ForeColor = Color.Blue
              Next
            End If
          End If
          nd.Text = "Files: " & aFiles.Length & " [" & nd.Tag.ToString & "]"
        Catch ex As Exception
          nd.Text = "Error: " & ex.Message
          nd.ForeColor = Color.DarkOrange
        End Try
      Next
    End With
  End Sub
  Public Sub InitializeTree()
    With _tv
      .Nodes.Clear()
      Dim nd As TreeNode = .Nodes.Add(_ERPLnLockFolder)
      nd.Tag = _ERPLnLockFolder
      nd.ForeColor = Color.Red
      nd = .Nodes.Add(_LockProcessedPath)
      nd.Tag = _LockProcessedPath
      nd.ForeColor = Color.Green
      nd = .Nodes.Add(_LockErrorPath)
      nd.Tag = _LockErrorPath
      nd.ForeColor = Color.DarkOrchid

      nd = .Nodes.Add(_ERPLnUnlockFolder)
      nd.Tag = _ERPLnUnlockFolder
      nd.ForeColor = Color.Red
      nd = .Nodes.Add(_UnlockProcessedPath)
      nd.Tag = _UnlockProcessedPath
      nd.ForeColor = Color.Green
      nd = .Nodes.Add(_UnlockErrorPath)
      nd.Tag = _UnlockErrorPath
      nd.ForeColor = Color.DarkOrchid

      nd = .Nodes.Add(_ERPLnXMLErrorFolder)
      nd.Tag = _ERPLnXMLErrorFolder
      nd.ForeColor = Color.Crimson

    End With
  End Sub
  Public Overrides Sub Process()
    If _tv.InvokeRequired Then
      _tv.Invoke(New RenderTreeDelegate(AddressOf RenderTree))
    Else
      RenderTree()
    End If
  End Sub
  Public Overrides Sub Started()
    MyBase.Started()
    If _tv.InvokeRequired Then
      _tv.Invoke(New RenderTreeDelegate(AddressOf InitializeTree))
    Else
      InitializeTree()
    End If
  End Sub
  Public Function Monitor() As TreeView
    Return _tv
  End Function
  Sub New()
    _tv = New TreeView
    _ERPLnUnlockFolder = AppConfigs.Value("ERPLnUnlockFolder")
    _ERPLnLockFolder = AppConfigs.Value("ERPLnLockFolder")
    _LockProcessedPath = _ERPLnLockFolder & "\Processed"
    _LockErrorPath = _ERPLnLockFolder & "\Error"
    _UnlockProcessedPath = _ERPLnUnlockFolder & "\Processed"
    _UnlockErrorPath = _ERPLnUnlockFolder & "\Error"
    Interval = AppConfigs.Value("LockUnlockInterval")
    _ERPLnXMLProcessedFolder = AppConfigs.Value("ERPLnXMLProcessedFolder")
    _ERPLnXMLErrorFolder = AppConfigs.Value("ERPLnXMLErrorFolder")
  End Sub
  Public Overrides Sub Stopped()
    _tv.Dispose()
  End Sub
End Class
Public Class LockUnlockService
  Inherits TimerSupport
  Private _ERPLnLockFolder As String = ""
  Private _ERPLnUnlockFolder As String = ""
  Private _LockProcessedPath As String = ""
  Private _LockErrorPath As String = ""
  Private _UnlockProcessedPath As String = ""
  Private _UnlockErrorPath As String = ""
  Private _ERPLnXMLProcessedFolder As String = ""
  Private _ERPLnXMLErrorFolder As String = ""
  Private _lb As ListBox = Nothing
  Delegate Sub ShowMsg(ByVal str As string)
  Private Sub msg(ByVal str As String)
    _lb.Items.Add(str)
  End Sub
  Private Sub logMsg(ByVal str As String)
    If _lb.InvokeRequired Then
      Dim a As ShowMsg = AddressOf msg
      _lb.Invoke(a, str)
    Else
      msg(str)
    End If
  End Sub
  Public Overrides Sub Process()
    Try
      ActualProcess(_ERPLnLockFolder, _LockErrorPath, _LockProcessedPath)
      ActualProcess(_ERPLnUnlockFolder, _UnlockErrorPath, _UnlockProcessedPath)
    Catch ex As Exception
    End Try
  End Sub

  Private Sub ActualProcess(mainFolder As String, errFolder As String, okFolder As String)
    Try
      Dim aFiles() As String = IO.Directory.GetFiles(mainFolder, "*.xml", IO.SearchOption.TopDirectoryOnly)
      If aFiles.Length > 0 Then
        For Each tmpFile As String In aFiles
          If Not dataXML.IsFileAvailable(tmpFile) Then Continue For
          Dim tmpFileName As String = IO.Path.GetFileName(tmpFile)
          Dim fl As luXMLFile = Nothing
          Try
            fl = luXMLFile.GetFile(tmpFile)
            logMsg("Started==> " & fl.Action & " : " & fl.MainFile)
          Catch ex As Exception
          End Try
          If fl Is Nothing Then Continue For
          'Bug: 08-10-2020
          If fl.DocumentID.Length <= 22 Then
            logMsg("Error==> " & fl.DocumentID & " length is less than 22 char.: " & fl.MainFile)
            Try
              IO.File.Copy(tmpFile, errFolder & "\" & tmpFileName, True)
              IO.File.Delete(tmpFile)
            Catch ex As Exception
            End Try
            Continue For
          End If
          'Bug====================
          ''*****Master Document List Insert/Update
          'Try
          '  mstDocList.InsUpdMasterDocumentList(fl, fl.ERPCompany)
          'Catch ex As Exception
          '  logMsg("MDL==> " & ex.Message)
          'End Try
          ''*****End of Master Document List
          '*****Design Alert
          Try
            Select Case fl.Action.ToLower
              Case "released"
                SIS.Design.Alerts.RevisedAlert(fl.DocumentID, fl.RevNo, fl.ERPCompany)
                Try
                  SIS.PAK.erpData.erpPO.UpdateIssuedPO(fl.DocumentID, fl.RevNo, fl.ERPCompany)
                Catch ex1 As Exception
                  logMsg("Err Issued PO: " & ex1.Message)
                End Try
              Case "revised"
                SIS.Design.Alerts.DcrAlert(fl.DCRNo, fl.ERPCompany)
            End Select
          Catch ex As Exception
          End Try
          '*****End of Design Alert
          If Login(fl) Then
            logMsg("Logged In==> " & fl.VaultDB)
            If ExecuteAction(fl) Then
              logMsg("Process Over Successful ==> " & fl.MainFile)
              Try
                IO.File.Copy(tmpFile, okFolder & "\" & tmpFileName, True)
                IO.File.Delete(tmpFile)
              Catch ex As Exception
              End Try
            Else 'If Error
              logMsg("Error: Process Failed ==> " & fl.MainFile)
              logMsg("**************************")
              Try
                IO.File.Copy(tmpFile, errFolder & "\" & tmpFileName, True)
                IO.File.Delete(tmpFile)
              Catch ex As Exception
              End Try
            End If
            VaultUtil.LogOut()
          End If 'Login
        Next ' Go to Next File For Processing
      End If ' Files.count > 0
    Catch ex As Exception
    End Try
  End Sub

  Private Function ExecuteAction(ByVal fl As luXMLFile) As Boolean
    Dim mRet As Boolean = False
    Dim StateToSet As String = ""
    Select Case fl.Action.ToLower
      Case "lock"
        StateToSet = "Submitted"
      Case "unlock"
        StateToSet = "Work in Progress"
      Case "released"
        StateToSet = "Released"
      Case "revised"
        StateToSet = "Superseded"
    End Select
    'Main File
    Dim file As Autodesk.Connectivity.WebServices.File = Nothing
    Try
      file = VaultUtil.SearchFileByName(fl.MainFile, 3L)
      logMsg("Found in Vault==> " & fl.MainFile)
    Catch ex As Exception
      Try
        logMsg("Waiting for 30 Sec: " & Now)
        Threading.Thread.Sleep(30000)
        logMsg("Reattempting: " & Now)
        file = VaultUtil.SearchFileByName(fl.MainFile, 3L)
        logMsg("Found in Vault in 2nd attempt==> " & fl.MainFile)
      Catch ex1 As Exception
        file = Nothing
        logMsg("Error: While SearchFileByName==> " & ex.Message)
      End Try
    End Try
    If file Is Nothing Then
      logMsg("Error: Not Found in Vault ==> " & fl.MainFile)
    Else
      If file.CheckedOut Then
        logMsg("Error: Checkedout state in Vault==> " & fl.MainFile)
      Else
        Dim fileLfCyc As Autodesk.Connectivity.WebServices.FileLfCyc
        Try
          fileLfCyc = file.FileLfCyc
        Catch ex As Exception
          Return False
        End Try
        If fileLfCyc.LfCycDefId = 1 Then
          Select Case fl.Action.ToLower
            Case "lock"
              StateToSet = "Released"
            Case "unlock"
              StateToSet = "Work in Progress"
            Case "released"
              StateToSet = "Released"
            Case "revised"
              StateToSet = "Work in Progress"
          End Select
        End If
        If StateToSet = "" Then Return False
        Try
          Dim lifeCycleStateId As Long = VaultUtil.GetLifeCycleStateId(fileLfCyc.LfCycDefId, StateToSet)
          logMsg("Changing state to ==> " & StateToSet)
          mRet = VaultUtil.UpdateFileLifecycle(file.MasterId, lifeCycleStateId, "State changed by EDI")
          If StateToSet = "Superseded" Then
            logMsg("Changing againg to ==> Work in Progress")
            lifeCycleStateId = VaultUtil.GetLifeCycleStateId(fileLfCyc.LfCycDefId, "Work in Progress")
            mRet = VaultUtil.UpdateFileLifecycle(file.MasterId, lifeCycleStateId, "State changed by EDI")
          End If
        Catch ex As Exception
          logMsg("Error: during changing state to ==> " & fl.MainFile)
        End Try
        'Data Source
        If fl.MainFile.ToLower <> fl.DataSource.ToLower Then
          Try
            file = VaultUtil.SearchFileByName(fl.DataSource, 3L)
            logMsg("Data Source found in Vault ==> " & fl.DataSource)
          Catch ex As Exception
            file = Nothing
            logMsg("Error: While SearchFileByName==> " & ex.Message)
          End Try
          If file Is Nothing Then
            logMsg("Error: Data Source not found in Vault ==> " & fl.DataSource)
          Else
            If file.CheckedOut Then
              logMsg("Error: Checkedout state in Vault==> " & fl.DataSource)
            Else
              fileLfCyc = file.FileLfCyc
              Try
                Dim lifeCycleStateId As Long = VaultUtil.GetLifeCycleStateId(fileLfCyc.LfCycDefId, StateToSet)
                logMsg("Changing state to ==> " & StateToSet)
                mRet = VaultUtil.UpdateFileLifecycle(file.MasterId, lifeCycleStateId, "State changed by EDI")
                If StateToSet = "Superseded" Then
                  logMsg("Changing againg to ==> Work in Progress")
                  lifeCycleStateId = VaultUtil.GetLifeCycleStateId(fileLfCyc.LfCycDefId, "Work in Progress")
                  mRet = VaultUtil.UpdateFileLifecycle(file.MasterId, lifeCycleStateId, "State changed by EDI")
                End If
              Catch ex As Exception
                logMsg("Error: during changing state to ==> " & fl.DataSource)
              End Try
            End If
          End If
        End If
      End If 'Main file checkedout
    End If
    Return mRet
  End Function
  Private Function Login(ByVal fl As luXMLFile) As Boolean
    VaultUtil.userName = "VAULTPROCESS"
    VaultUtil.password = "VAULTPROCESS"
    VaultUtil.serverName = "bramha"
    VaultUtil.vaultName = fl.VaultDB
    If fl.VaultDB <> String.Empty Then
      Try
        VaultUtil.LogInStandard(VaultUtil.serverName, VaultUtil.vaultName, VaultUtil.userName, VaultUtil.password)
      Catch ex As Exception
        logMsg("Error: in Vault Login ==> " & fl.VaultDB & " : " & ex.Message)
        Return False
      End Try
    Else
      logMsg("Error: *****Vault DB not defined in XML File.*****")
      Return False
    End If
    Return True
  End Function
  Sub New(ByVal lb As ListBox)
    _ERPLnUnlockFolder = AppConfigs.Value("ERPLnUnlockFolder")
    _ERPLnLockFolder = AppConfigs.Value("ERPLnLockFolder")
    _LockProcessedPath = _ERPLnLockFolder & "\Processed"
    _LockErrorPath = _ERPLnLockFolder & "\Error"
    _UnlockProcessedPath = _ERPLnUnlockFolder & "\Processed"
    _UnlockErrorPath = _ERPLnUnlockFolder & "\Error"
    Interval = AppConfigs.Value("LockUnlockInterval")
    _ERPLnXMLProcessedFolder = AppConfigs.Value("ERPLnXMLProcessedFolder")
    _ERPLnXMLErrorFolder = AppConfigs.Value("ERPLnXMLErrorFolder")
    _lb = lb
  End Sub
  Public Overrides Sub Stopped()
    _lb = Nothing
    _lb.Dispose()
  End Sub
  Public Overrides Sub Started()
    MyBase.Started()
    Try
      If Not IO.Directory.Exists(_LockProcessedPath) Then
        IO.Directory.CreateDirectory(_LockProcessedPath)
      End If
      If Not IO.Directory.Exists(_LockErrorPath) Then
        IO.Directory.CreateDirectory(_LockErrorPath)
      End If
      If Not IO.Directory.Exists(_UnlockProcessedPath) Then
        IO.Directory.CreateDirectory(_UnlockProcessedPath)
      End If
      If Not IO.Directory.Exists(_UnlockErrorPath) Then
        IO.Directory.CreateDirectory(_UnlockErrorPath)
      End If
    Catch ex As Exception
      Throw New Exception(ex.Message)
    End Try
  End Sub
End Class
