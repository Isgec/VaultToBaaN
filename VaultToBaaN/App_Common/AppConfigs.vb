Imports System.Xml
Public Class AppConfigs
  Implements IDisposable
  Private Shared ConfigDoc As XmlDocument = Nothing
  Shared Sub New()
    ConfigDoc = New XmlDocument
    ConfigDoc.Load(Application.StartupPath & "\EDIConfig.xml")
  End Sub
  Public Shared Function Value(ByVal KeyName As String) As String
    For Each nd As XmlNode In ConfigDoc.ChildNodes(1)
      If nd.HasChildNodes Then
        If nd.ChildNodes(0).InnerText.ToLower = KeyName.ToLower Then
          Return nd.ChildNodes(1).InnerText
        End If
      End If
    Next
    Return ""
  End Function
#Region " IDisposable Support "
  Private disposedValue As Boolean = False    ' To detect redundant calls
  ' IDisposable
  Protected Overridable Sub Dispose(ByVal disposing As Boolean)
    If Not Me.disposedValue Then
      If disposing Then
        ' TODO: free other state (managed objects).
      End If

      ' TODO: free your own state (unmanaged objects).
      ' TODO: set large fields to null.
    End If
    Me.disposedValue = True
  End Sub

  ' This code added by Visual Basic to correctly implement the disposable pattern.
  Public Sub Dispose() Implements IDisposable.Dispose
    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    Dispose(True)
    GC.SuppressFinalize(Me)
  End Sub
#End Region
End Class
