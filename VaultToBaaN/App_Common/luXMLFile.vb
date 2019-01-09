Imports System.Xml
Public Class luXMLFile
  Public Property Action As String = ""
  Public Property MainFile As String = ""
  Public Property DataSource As String = ""
  Public Property VaultDB As String = ""
  Public Property Project As String = ""
  Public Property DCRNo As String = ""
  Public Property DocumentID As String = ""
  Public Property RevNo As String = ""
  Public Shared Function GetFile(ByVal FileName As String) As luXMLFile
    Dim lf As luXMLFile = Nothing
    Dim oXml As New XmlDocument
    Try
      oXml.Load(FileName)
      lf = New luXMLFile
      Try
        lf.Action = oXml.ChildNodes(1).Attributes("Type").Value
      Catch ex As Exception
      End Try
      Try
        lf.MainFile = oXml.ChildNodes(1).ChildNodes(0).ChildNodes(0).Attributes("FileName").Value
      Catch ex As Exception
      End Try
      Try
        lf.DCRNo = oXml.ChildNodes(1).ChildNodes(0).ChildNodes(0).Attributes("DCRNo").Value.Trim
      Catch ex As Exception
      End Try
      Try
        lf.DataSource = oXml.ChildNodes(1).ChildNodes(0).ChildNodes(0).Attributes("IsgecDataSource").Value
      Catch ex As Exception
      End Try
      Try
        lf.VaultDB = oXml.ChildNodes(1).ChildNodes(0).ChildNodes(0).Attributes("VaultDBName").Value
      Catch ex As Exception
      End Try
      Try
        lf.DocumentID = oXml.ChildNodes(1).ChildNodes(0).ChildNodes(0).Attributes("DocumentID").Value
      Catch ex As Exception
      End Try
      Try
        lf.RevNo = oXml.ChildNodes(1).ChildNodes(0).ChildNodes(0).Attributes("RevisionNo").Value
      Catch ex As Exception
      End Try
    Catch ex As Exception
    End Try
    Return lf
  End Function
  Sub New()
    'dummy
  End Sub
End Class
