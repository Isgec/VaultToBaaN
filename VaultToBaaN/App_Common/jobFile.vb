Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.IO
<DataObject()> _
Public Class jobFile
  'Derived Properties
  Public Property ProjectID As String = ""
  Public Property CardNo As String = ""
  'Main Properties
  Public Property FileID As String = ""

  Public Property FileName As String = ""
  Public Property UserID As String = ""
  Public Property VaultDB As String = ""
  Public Property ClientVersion As String = ""
  Public Property ClientMachineName As String = ""
  Public Property JobCreationDate As String = ""
  Public Property JobCreationTime As String = ""
  Public Property JobFilePath As String = ""
  Public Shared Function SelectList(ByVal JobPath As String) As List(Of jobFile)
    Dim tmp As New List(Of jobFile)
    Dim aFiles() As String = IO.Directory.GetFiles(JobPath, "*.job", IO.SearchOption.TopDirectoryOnly)
    If aFiles.Length > 0 Then
      For Each tmpFile As String In aFiles
        tmp.Add(GetFile(tmpFile))
      Next
    End If
    Return tmp
  End Function
  Public Shared Function GetFile(ByVal FilePath As String) As jobFile
    Dim tmp As jobFile = Nothing
    Dim sFileID As String = ""
    If IO.File.Exists(FilePath) Then
      Dim tr As IO.StreamReader = New IO.StreamReader(FilePath)
      Dim str As String = tr.ReadLine
      tmp = New jobFile()
      Do While str IsNot Nothing
        With tmp
          If str.StartsWith("[FileID]", StringComparison.OrdinalIgnoreCase) Then
            .FileID = str.Replace("[FileID]", "")
            sFileID = .FileID
          ElseIf str.StartsWith("[FileName]", StringComparison.OrdinalIgnoreCase) Then
            .FileName = str.Replace("[FileName]", "")
            .ProjectID = .FileName.Substring(0, 6)
          ElseIf str.StartsWith("[UserID]", StringComparison.OrdinalIgnoreCase) Then
            .UserID = str.Replace("[UserID]", "").Replace(" ", "")
          ElseIf str.StartsWith("[VaultDB]", StringComparison.OrdinalIgnoreCase) Then
            .VaultDB = str.Replace("[VaultDB]", "")
          ElseIf str.StartsWith("[ClientVersion]", StringComparison.OrdinalIgnoreCase) Then
            .ClientVersion = str.Replace("[ClientVersion]", "")
          ElseIf str.StartsWith("[ClientMachineName]", StringComparison.OrdinalIgnoreCase) Then
            .ClientMachineName = str.Replace("[ClientMachineName]", "")
            .CardNo = .ClientMachineName.Substring(0, 4)
          ElseIf str.StartsWith("[JobCreationDate]", StringComparison.OrdinalIgnoreCase) Then
            .JobCreationDate = str.Replace("[JobCreationDate]", "")
          ElseIf str.StartsWith("JobCreationTime]", StringComparison.OrdinalIgnoreCase) Then
            .JobCreationTime = str.Replace("[JobCreationTime]", "")
          End If
        End With
        str = tr.ReadLine
      Loop
      tr.Close()
    End If
    Return tmp
  End Function
  Public Sub New()
    'Dummy
  End Sub
End Class
