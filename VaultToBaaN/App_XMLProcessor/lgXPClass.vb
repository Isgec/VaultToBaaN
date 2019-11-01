Imports System.ServiceProcess
Imports System.Management

Public Class XPMonitor
  Inherits TimerSupport
  Private _BomExportEXECount As Integer = 0

  Private _BomExportOutputPath As String = ""
  Private _XMLProcessorRestrictedOutputPath As String = ""
  Private _XMLProcessorCommonOutputPath As String = ""
  Private _XMLProcessorErrorOutputPath As String = ""
  Private _BomExportPDFOutputPath As String = ""
  Private WithEvents _tv As TreeView
  Public Delegate Sub RenderTreeDelegate()
  Private Sub tv_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles _tv.NodeMouseDoubleClick
    Dim nd As TreeNode = e.Node
    Try
      nd.Nodes.Clear()
      Dim ext As String() = {"*.xml", "*.pdf"}
      Dim aFiles() As String = ext.SelectMany(Function(f) IO.Directory.GetFiles(nd.Tag, f, IO.SearchOption.TopDirectoryOnly)).OrderBy(Function(f) f).ToArray
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
    'Dim pc As String = "192.9.200.122"
    'Dim srName As String = "InforODMVaultServer"
    'Dim obj As ManagementObject
    'Dim sc As ServiceController

    'obj = New ManagementObject("\\" & pc & "\root\cimv2:Win32_Service.Name='" & srName & "'")
    'If obj("State").ToString <> "Running" Then
    '  sc = New ServiceController(srName, pc)
    '  sc.Start()
    '  sc.WaitForStatus(ServiceControllerStatus.Running)
    'End If

    With _tv
      For Each nd As TreeNode In _tv.Nodes
        Try
          Dim aFiles() As String
          If nd.Tag.ToString.ToLower.StartsWith(_BomExportPDFOutputPath.ToLower) Then
            aFiles = IO.Directory.GetFiles(nd.Tag, "*.pdf", IO.SearchOption.TopDirectoryOnly)
          Else
            aFiles = IO.Directory.GetFiles(nd.Tag, "*.xml", IO.SearchOption.TopDirectoryOnly)
          End If
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
      Dim nd As TreeNode
      For i = 0 To _BomExportEXECount - 1
        nd = .Nodes.Add(_BomExportOutputPath & "\" & i.ToString)
        nd.Tag = _BomExportOutputPath & "\" & i.ToString
        nd.ForeColor = Color.Red
      Next
      For i = 0 To _BomExportEXECount - 1
        nd = .Nodes.Add(_BomExportPDFOutputPath & "\" & i.ToString)
        nd.Tag = _BomExportPDFOutputPath & "\" & i.ToString
        nd.ForeColor = Color.Red
      Next
      nd = .Nodes.Add(_XMLProcessorRestrictedOutputPath)
      nd.Tag = _XMLProcessorRestrictedOutputPath
      nd.ForeColor = Color.Green
      For i = 0 To _BomExportEXECount - 1
        nd = .Nodes.Add(_XMLProcessorCommonOutputPath & "\" & i.ToString)
        nd.Tag = _XMLProcessorCommonOutputPath & "\" & i.ToString
        nd.ForeColor = Color.Green
      Next
      nd = .Nodes.Add(_XMLProcessorErrorOutputPath)
      nd.Tag = _XMLProcessorErrorOutputPath
      nd.ForeColor = Color.DarkOrchid
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
    _BomExportOutputPath = AppConfigs.Value("BomExportOutputPath")
    _BomExportEXECount = AppConfigs.Value("BomExportEXECount")
    _XMLProcessorRestrictedOutputPath = AppConfigs.Value("XMLProcessorRestrictedOutputPath")
    _XMLProcessorCommonOutputPath = AppConfigs.Value("XMLProcessorCommonOutputPath")
    _XMLProcessorErrorOutputPath = AppConfigs.Value("XMLProcessorErrorOutputPath")
    _BomExportPDFOutputPath = AppConfigs.Value("BomExportPDFOutputPath")
    Interval = AppConfigs.Value("XMLProcessorMonitorInterval")
  End Sub
  Public Overrides Sub Stopped()
    _tv.Dispose()
  End Sub
End Class
Public Class XmlProcessor
  Inherits TimerSupport
  Private _BomExportEXECount As Integer = 0
  Private _RestrictedBomExportEXENumber As String = ""
  Private _BomExportOutputPath As String = ""
  Private _XMLProcessorRestrictedOutputPath As String = ""
  Private _XMLProcessorCommonOutputPath As String = ""
  Private _XMLProcessorErrorOutputPath As String = ""
  Private _BomExportPDFOutputPath As String = ""
  Private _XMLProcessorWillLockInVault As Boolean = False

  Public Property UseDirect As Boolean = False
  Public Overrides Sub Process()
    Try
      For i = 0 To _BomExportEXECount - 1
        Dim aFiles() As String = IO.Directory.GetFiles(_BomExportOutputPath & "\" & i, "*.xml", IO.SearchOption.TopDirectoryOnly)
        If aFiles.Length > 0 Then
          For Each tmpFile As String In aFiles
            Dim tmpFileName As String = IO.Path.GetFileName(tmpFile)
            Dim tmpFileNoExt As String = IO.Path.GetFileNameWithoutExtension(tmpFileName)
            'Check Availability of All 3 Files, XML, ORG, PDF=>PDF will Insure All Files
            If Not dataXML.IsFileAvailable(_BomExportPDFOutputPath & "\" & i & "\" & tmpFileNoExt & ".pdf") Then
              Continue For
            End If
            Dim tmpXML As dataXML = dataXML.GetFile(tmpFile)
            Dim moveIn3 As Boolean = False
            Dim moveIn4 As Boolean = False
            If tmpXML.VaultDBName = "ISGEC REDECAM" Then
              moveIn3 = True
            End If
            If tmpXML.VaultDBName = "ISGEC COVEMA" Then
              moveIn4 = True
            End If
            If tmpXML.State = 1 Then Continue For 'process next time, If PDF file is available, this will never happen
            If tmpXML.State = 2 Or tmpXML.State = 3 Then 'ISGEC Specific Error in XML, Send E-Mail & Move file to error
              Try
                dataXML.SendMail(tmpXML)
              Catch ex As Exception
              End Try
              Dim tFiles() As String = IO.Directory.GetFiles(_BomExportOutputPath & "\" & i, tmpFileNoExt & ".*", IO.SearchOption.TopDirectoryOnly)
              For Each tFile As String In tFiles
                Try
                  IO.File.Copy(tFile, _XMLProcessorErrorOutputPath & "\" & IO.Path.GetFileName(tFile), True)
                  IO.File.Delete(tFile)
                Catch ex As Exception
                End Try
              Next
              Try
                IO.File.Copy(_BomExportPDFOutputPath & "\" & i & "\" & tmpFileNoExt & ".pdf", _XMLProcessorErrorOutputPath & "\" & tmpFileNoExt & ".pdf", True)
                IO.File.Delete(_BomExportPDFOutputPath & "\" & i & "\" & tmpFileNoExt & ".pdf")
              Catch ex As Exception
              End Try
            End If 'tmpXML.State=2
            If tmpXML.State = 0 Then
              If i.ToString <> _RestrictedBomExportEXENumber Then
                '1. Update Attribute in Vault
                Try
                  ISGECVault.UpdateAttributeDirect(tmpXML)
                Catch ex As Exception
                End Try
                '2. LockInVault
                If _XMLProcessorWillLockInVault Then
                  Try
                    ISGECVault.ChangeToSubmitted(tmpXML.filename, tmpXML.ISGEC_Datasource, tmpXML.VaultDBName)
                  Catch ex As Exception
                  End Try
                End If
                '3. Insert/Update in ERP-LN

                '4. Move Files to Output Folder
                Try
                  If moveIn3 Then
                    IO.File.Copy(tmpFile, _XMLProcessorCommonOutputPath & "\" & "3" & "\" & IO.Path.GetFileName(tmpFile), True)
                  ElseIf moveIn4 Then
                    IO.File.Copy(tmpFile, _XMLProcessorCommonOutputPath & "\" & "4" & "\" & IO.Path.GetFileName(tmpFile), True)
                  Else
                    IO.File.Copy(tmpFile, _XMLProcessorCommonOutputPath & "\" & i & "\" & IO.Path.GetFileName(tmpFile), True)
                  End If
                  IO.File.Delete(tmpFile)
                Catch ex As Exception
                End Try
                Try
                  If moveIn3 Then
                    IO.File.Copy(_BomExportPDFOutputPath & "\" & i & "\" & tmpFileNoExt & ".pdf", _XMLProcessorCommonOutputPath & "\" & "3" & "\" & tmpFileNoExt & ".pdf", True)
                  ElseIf moveIn4 Then
                    IO.File.Copy(_BomExportPDFOutputPath & "\" & i & "\" & tmpFileNoExt & ".pdf", _XMLProcessorCommonOutputPath & "\" & "4" & "\" & tmpFileNoExt & ".pdf", True)
                  Else
                    IO.File.Copy(_BomExportPDFOutputPath & "\" & i & "\" & tmpFileNoExt & ".pdf", _XMLProcessorCommonOutputPath & "\" & i & "\" & tmpFileNoExt & ".pdf", True)
                  End If
                  IO.File.Delete(_BomExportPDFOutputPath & "\" & i & "\" & tmpFileNoExt & ".pdf")
                Catch ex As Exception
                End Try
                Try
                  If moveIn3 Then
                    IO.File.Copy(IO.Path.ChangeExtension(tmpFile, "slz"), _XMLProcessorCommonOutputPath & "\" & "3" & "\" & IO.Path.GetFileNameWithoutExtension(tmpFile) & ".slz", True)
                  ElseIf moveIn4 Then
                    IO.File.Copy(IO.Path.ChangeExtension(tmpFile, "slz"), _XMLProcessorCommonOutputPath & "\" & "4" & "\" & IO.Path.GetFileNameWithoutExtension(tmpFile) & ".slz", True)
                  Else
                    IO.File.Copy(IO.Path.ChangeExtension(tmpFile, "slz"), _XMLProcessorCommonOutputPath & "\" & i & "\" & IO.Path.GetFileNameWithoutExtension(tmpFile) & ".slz", True)
                  End If
                  IO.File.Delete(IO.Path.ChangeExtension(tmpFile, "slz"))
                Catch ex As Exception
                End Try
              Else 'Not Restricted Output
                Try
                  IO.File.Copy(tmpFile, _XMLProcessorRestrictedOutputPath & "\" & IO.Path.GetFileName(tmpFile), True)
                  IO.File.Delete(tmpFile)
                Catch ex As Exception
                End Try
              End If
            End If
          Next ' XML File in BOM Output
        End If
      Next ' BOM Exe Count I
    Catch ex As Exception
    End Try
  End Sub
  Public Sub New()
    _BomExportEXECount = AppConfigs.Value("BomExportEXECount")
    _RestrictedBomExportEXENumber = AppConfigs.Value("RestrictedBomExportEXENumber")
    _BomExportOutputPath = AppConfigs.Value("BomExportOutputPath")
    _XMLProcessorRestrictedOutputPath = AppConfigs.Value("XMLProcessorRestrictedOutputPath")
    _XMLProcessorCommonOutputPath = AppConfigs.Value("XMLProcessorCommonOutputPath")
    _XMLProcessorErrorOutputPath = AppConfigs.Value("XMLProcessorErrorOutputPath")
    _BomExportPDFOutputPath = AppConfigs.Value("BomExportPDFOutputPath")
    Interval = AppConfigs.Value("XMLProcessorInterval")
    Try
      _XMLProcessorWillLockInVault = IIf(AppConfigs.Value("XMLProcessorWillLockInVault").ToLower = "false", False, True)
    Catch ex As Exception
      _XMLProcessorWillLockInVault = False
    End Try

  End Sub
  Public Overrides Sub Stopped()
  End Sub


End Class
