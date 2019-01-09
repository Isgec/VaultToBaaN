Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.IO
<DataObject()> _
Public Class Monitor
  Public Property jdM As List(Of jDList)
    Get
      Dim jdl As New List(Of jDList)
      For i As Integer = 0 To 3
        Dim jd As New jDList
        jd.jdPath = "c:\temp\j\" & i
        jdl.Add(jd)
      Next
      Return jdl
    End Get
    Set(ByVal value As List(Of jDList))

    End Set
  End Property
End Class

<DataObject()> _
Public Class jDList
  Public Property jdPath As String = ""
  Public Property jdFiles As List(Of jobFile)
    Get
      Return jobFile.SelectList(jdPath)
    End Get
    Set(ByVal value As List(Of jobFile))

    End Set
  End Property
End Class