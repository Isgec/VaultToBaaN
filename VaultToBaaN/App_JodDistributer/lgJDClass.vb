Imports System.Diagnostics
Public Class JDMonitor
  Inherits TimerSupport
  Private _BomExportEXECount As Integer = 0
  Private _JobDistributerInputPath As String = ""
  Private _JobDistributerOutputPath As String = ""
  Private _JobDistributerDuplicateJobOutputPath As String = ""
  Private WithEvents _tv As TreeView
  Public Delegate Sub RenderTreeDelegate()
  Private Sub tv_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles _tv.NodeMouseDoubleClick
    Dim nd As TreeNode = e.Node
    Try
      nd.Nodes.Clear()
      Dim aFiles() As String = IO.Directory.GetFiles(nd.Tag, "*.job", IO.SearchOption.TopDirectoryOnly)
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
          Dim aFiles() As String = IO.Directory.GetFiles(nd.Tag, "*.job", IO.SearchOption.TopDirectoryOnly)
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
      Dim nd As TreeNode = .Nodes.Add(_JobDistributerInputPath)
      nd.Tag = _JobDistributerInputPath
      nd.ForeColor = Color.Red
      'nd.NodeFont = New Font(_tv.Font, FontStyle.Bold)
      For i = 0 To _BomExportEXECount - 1
        nd = .Nodes.Add(_JobDistributerOutputPath & "\" & i.ToString)
        nd.Tag = _JobDistributerOutputPath & "\" & i.ToString
        nd.ForeColor = Color.Green
      Next
      nd = .Nodes.Add(_JobDistributerDuplicateJobOutputPath)
      nd.Tag = _JobDistributerDuplicateJobOutputPath
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
    _JobDistributerInputPath = AppConfigs.Value("JobDistributerInputPath")
    _BomExportEXECount = AppConfigs.Value("BomExportEXECount")
    _JobDistributerOutputPath = AppConfigs.Value("JobDistributerOutputPath")
    _JobDistributerDuplicateJobOutputPath = AppConfigs.Value("JobDistributerDuplicateJobOutputPath")
    Interval = AppConfigs.Value("JobDistributerMonitorInterval")
  End Sub
  Public Overrides Sub Stopped()
    _tv.Dispose()
  End Sub
End Class
Public Class JobDistributer
  Inherits TimerSupport
  Private _BomExportEXECount As Integer = 0
  Private _JobDistributerInputPath As String = ""
  Private _JobDistributerOutputPath As String = ""
  Private _MoveInPath As Integer = 0
  Private _MoveInPathRestricted As Integer = 0
  Private _RestrictedBomExportEXENumber As String = ""
  Private _RestrictedBomExportProjects As String = ""
  Private _RestrictedBomExportUsers As String = ""
  Private _JobDistributerDuplicateJobOutputPath As String = ""
  Private _aRestrictedProjects() As String
  Private _aRestrictedUsers() As String
  Public Overrides Sub Process()
    Try
      Dim aFiles() As String = IO.Directory.GetFiles(_JobDistributerInputPath, "*.job", IO.SearchOption.TopDirectoryOnly)
      If aFiles.Length > 0 Then
        For Each tmpFile As String In aFiles
          Dim tmpFileName As String = IO.Path.GetFileName(tmpFile)
          'Remove Duplicate Job
          Dim aSearch() As String = tmpFile.Split("_".ToCharArray)
          Dim DuplicateFound As Boolean = False
          Dim toSearch As String = "_" & aSearch(aSearch.Length - 2) & "_" 'Penultimate Element is File ID
          For i = 1 To _BomExportEXECount - 1
            Try
              Dim tFiles() As String = IO.Directory.GetFiles(_JobDistributerOutputPath & "\" & i, "*" & toSearch & "*.job", IO.SearchOption.TopDirectoryOnly)
              If tFiles.Length > 0 Then
                Try
                  IO.File.Copy(tmpFile, _JobDistributerDuplicateJobOutputPath & "\" & tmpFileName, True)
                  IO.File.Delete(tmpFile)
                Catch ex As Exception
                End Try
                DuplicateFound = True
              End If
            Catch ex As Exception
            End Try
          Next
          'Distribute Jobs in output folders
          If Not DuplicateFound Then
            'Process for Restricted
            Dim RestrictedFound As Boolean = False
            If _RestrictedBomExportEXENumber <> String.Empty Then
              Dim oJF As jobFile = jobFile.GetFile(tmpFile)
              'Project List is used for => VaultDB 
              If _RestrictedBomExportProjects.IndexOf(oJF.VaultDB, StringComparison.CurrentCultureIgnoreCase) < -1 Then
                RestrictedFound = True
              End If
            End If
            If RestrictedFound Then
              Try
                IO.File.Copy(tmpFile, _JobDistributerOutputPath & "\" & _RestrictedBomExportEXENumber & "\" & tmpFileName, True)
                IO.File.Delete(tmpFile)
              Catch ex As Exception
              End Try
            Else 'Restricted Not Found
              Try
                IO.File.Copy(tmpFile, _JobDistributerOutputPath & "\" & _MoveInPath & "\" & tmpFileName, True)
                IO.File.Delete(tmpFile)
                _MoveInPath += 1
                If _RestrictedBomExportEXENumber <> String.Empty Then
                  If _MoveInPath = Convert.ToInt32(_RestrictedBomExportEXENumber) Then
                    _MoveInPath += 1
                  End If
                End If
                If _MoveInPath >= _BomExportEXECount Then
                  If _RestrictedBomExportEXENumber <> "0" Then
                    _MoveInPath = 0
                  Else
                    _MoveInPath = 1
                  End If
                End If
              Catch ex As Exception
              End Try
            End If 'End of Restricted Not Found
          End If 'End of Duplicate Not Found
        Next ' Go to Next File For Processing
      End If ' Files.count > 0
    Catch ex As Exception
    End Try
  End Sub

  Sub New()
    _JobDistributerInputPath = AppConfigs.Value("JobDistributerInputPath")
    _BomExportEXECount = AppConfigs.Value("BomExportEXECount")
    _JobDistributerOutputPath = AppConfigs.Value("JobDistributerOutputPath")
    _RestrictedBomExportEXENumber = AppConfigs.Value("RestrictedBomExportEXENumber")
    _RestrictedBomExportProjects = AppConfigs.Value("RestrictedBomExportProjects")
    _RestrictedBomExportUsers = AppConfigs.Value("RestrictedBomExportUsers")
    _JobDistributerDuplicateJobOutputPath = AppConfigs.Value("JobDistributerDuplicateJobOutputPath")
    If _RestrictedBomExportEXENumber <> "0" Then _MoveInPath = 0 Else _MoveInPath = 1
    Interval = AppConfigs.Value("JobDistributerInterval")
  End Sub
  Public Overrides Sub Started()
    MyBase.Started()
  End Sub
  Public Overrides Sub Stopped()
  End Sub
End Class
