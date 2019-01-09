Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Public Class ISGECVault
  Private Class vaultProperty
    Public Property PropertyID As Long
    Public Property PropertyDefID As Integer
    Public Property EntityID As Long
    Public Property Value As String = ""
    Public Property VaultDB As String = ""
    Public Shared Function Update(ByVal propertyDefID As Integer, ByVal entityID As Long, ByVal value As String, ByVal vaultDB As String) As Boolean
      Dim Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetVaultConnection(vaultDB))
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "UPDATE Property SET Value = '" & value & "' WHERE PropertyDefID = " & propertyDefID & " AND EntityID = " & entityID
          Con.Open()
          Result = Cmd.ExecuteNonQuery()
        End Using
      End Using
      Return Result
    End Function
    Public Shared Function Insert(ByVal propertyDefID As Integer, ByVal entityID As Long, ByVal value As String, ByVal vaultDB As String) As Boolean
      Dim Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetVaultConnection(vaultDB))
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "INSERT Property (PropertyDefID, EntityID, Value) VALUES ( " & propertyDefID & "," & entityID & ",'" & value & "')"
          Con.Open()
          Result = Cmd.ExecuteNonQuery()
        End Using
      End Using
      Return Result
    End Function
    Public Shared Function GetByID(ByVal propertyDefID As Integer, ByVal entityID As Long, ByVal vaultDB As String) As vaultProperty
      Dim Result As vaultProperty = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetVaultConnection(vaultDB))
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "SELECT * FROM Property where PropertyDefID = " & propertyDefID & " AND EntityID =" & entityID
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Result = New vaultProperty
            With Result
              .PropertyID = Reader("PropertyID")
              .PropertyDefID = Reader("PropertyDefID")
              .EntityID = Reader("EntityID")
              .Value = Reader("Value")
              .VaultDB = vaultDB
            End With
          End While
          Reader.Close()
        End Using
      End Using
      Return Result
    End Function
    Public Shared Function GetLatestEntityID(ByVal FileName As String, ByVal vaultDB As String) As String
      Dim mSql As String = ""
      mSql = mSql & "select max(FileIterationId) from FileIteration where FileName = '" & FileName & "'"
      Dim Results As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetVaultConnection(vaultDB))
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = mSql
          Con.Open()
          Results = Cmd.ExecuteScalar()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function GetPropertyDefID(ByVal PropertyName As String, ByVal vaultDB As String) As String
      Dim mSql As String = ""
      mSql = mSql & "select PropertyDefID from PropertyDef where FriendlyName = '" & PropertyName & "'"
      Dim Results As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetVaultConnection(vaultDB))
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = mSql
          Con.Open()
          Results = Cmd.ExecuteScalar()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UpdateProperty(ByVal EntityID As ULong, ByVal AttributeName As String, ByVal Value As String, ByVal vaultDB As String) As Boolean
      Try
        Dim propID As ULong = GetPropertyDefID(AttributeName, vaultDB)
        Dim oVP As vaultProperty = GetByID(propID, EntityID, vaultDB)
        If oVP IsNot Nothing Then
          Update(propID, EntityID, Value, vaultDB)
        Else
          Insert(propID, EntityID, Value, vaultDB)
        End If

      Catch ex As Exception
        Return False
      End Try
      Return True
    End Function
  End Class
  Public Shared Sub UpdateAttributeDirect(ByVal epFL As dataXML)
    Dim EntityID As Long = vaultProperty.GetLatestEntityID(epFL.filename, epFL.VaultDBName)
    'vaultProperty.UpdateProperty(EntityID, "Comments", Now.ToString, epFL.VaultDBName)
    vaultProperty.UpdateProperty(EntityID, "ISGEC_PROJECTID", epFL.contract, epFL.VaultDBName)
    vaultProperty.UpdateProperty(EntityID, "ISGEC_DRAWINGTITLE", epFL.title, epFL.VaultDBName)
    vaultProperty.UpdateProperty(EntityID, "ISGEC_DATASOURCE", epFL.ISGEC_Datasource, epFL.VaultDBName)
    vaultProperty.UpdateProperty(EntityID, "ISGEC_DOCUMENTID_DRGID", epFL.drgid, epFL.VaultDBName)
    vaultProperty.UpdateProperty(EntityID, "ISGEC_DOCUMENTID_NUMBER", epFL.number, epFL.VaultDBName)
    vaultProperty.UpdateProperty(EntityID, "ISGEC_LATESTREVISION", epFL.rev, epFL.VaultDBName)
    vaultProperty.UpdateProperty(EntityID, "ISGEC_DRAWNBY", epFL.drawn, epFL.VaultDBName)
    vaultProperty.UpdateProperty(EntityID, "ISGEC_CHECKEDBY", epFL.chqd, epFL.VaultDBName)
    vaultProperty.UpdateProperty(EntityID, "ISGEC_APPROVEDBY", epFL.appd, epFL.VaultDBName)
    vaultProperty.UpdateProperty(EntityID, "ISGEC_DATE", epFL.ddate, epFL.VaultDBName)
    vaultProperty.UpdateProperty(EntityID, "ISGEC_FORINFORMATION", epFL.inf, epFL.VaultDBName)
    vaultProperty.UpdateProperty(EntityID, "ISGEC_FORAPPROVAL", epFL.apr, epFL.VaultDBName)
    vaultProperty.UpdateProperty(EntityID, "ISGEC_FORPRODUCTION", epFL.pro, epFL.VaultDBName)
    vaultProperty.UpdateProperty(EntityID, "ISGEC_FORERECTION", epFL.ere, epFL.VaultDBName)
    vaultProperty.UpdateProperty(EntityID, "ISGEC_TOTALWEIGHTINKG", epFL.weight, epFL.VaultDBName)
    vaultProperty.UpdateProperty(EntityID, "ISGEC_SHEETSIZE", epFL.sheetsize, epFL.VaultDBName)
    vaultProperty.UpdateProperty(EntityID, "ISGEC_ELEMENTID", epFL.ElId, epFL.VaultDBName)
    vaultProperty.UpdateProperty(EntityID, "ISGEC_SERVICE1", epFL.service1, epFL.VaultDBName)
    vaultProperty.UpdateProperty(EntityID, "ISGEC_SERVICE2", epFL.service2, epFL.VaultDBName)
    vaultProperty.UpdateProperty(EntityID, "ISGEC_IWT", epFL.iwt, epFL.VaultDBName)
    vaultProperty.UpdateProperty(EntityID, "ISGEC_YEAR", epFL.year, epFL.VaultDBName)
    vaultProperty.UpdateProperty(EntityID, "ISGEC_CONSULTANT", epFL.consultant, epFL.VaultDBName)
    vaultProperty.UpdateProperty(EntityID, "ISGEC_CLIENT", epFL.client, epFL.VaultDBName)
    vaultProperty.UpdateProperty(EntityID, "ISGEC_GROUPNAME", epFL.group, epFL.VaultDBName)
    vaultProperty.UpdateProperty(EntityID, "ISGEC_SCALE", epFL.scale, epFL.VaultDBName)
    vaultProperty.UpdateProperty(EntityID, "ISGEC_RESPONSIBLEDEPT", epFL.resp_dept, epFL.VaultDBName)
  End Sub

  Public Shared Function ChangeToSubmitted(ByVal MainFile As String, ByVal IsgecDataSource As String, ByVal VaultDB As String) As Boolean
    Dim mRet As Boolean = False
    If VaultUtil.Login(VaultDB) Then
      Dim StateToSet As String = "Submitted"
      'Main File
      Dim file As Autodesk.Connectivity.WebServices.File = Nothing
      Try
        file = VaultUtil.SearchFileByName(MainFile, 3L)
      Catch ex As Exception
        file = Nothing
      End Try
      If file IsNot Nothing Then
        If Not file.CheckedOut Then
          Dim fileLfCyc As Autodesk.Connectivity.WebServices.FileLfCyc
          Try
            fileLfCyc = file.FileLfCyc
          Catch ex As Exception
            Return False
          End Try
          If fileLfCyc.LfCycDefId = 1 Then
            StateToSet = "Released"
          End If
          Try
            Dim lifeCycleStateId As Long = VaultUtil.GetLifeCycleStateId(fileLfCyc.LfCycDefId, StateToSet)
            mRet = VaultUtil.UpdateFileLifecycle(file.MasterId, lifeCycleStateId, "State changed by EDI")
          Catch ex As Exception
          End Try
          'Data Source
          If MainFile.ToLower <> IsgecDataSource.ToLower Then
            Try
              file = VaultUtil.SearchFileByName(IsgecDataSource, 3L)
            Catch ex As Exception
              file = Nothing
            End Try
            If file IsNot Nothing Then
              If Not file.CheckedOut Then
                fileLfCyc = file.FileLfCyc
                Try
                  Dim lifeCycleStateId As Long = VaultUtil.GetLifeCycleStateId(fileLfCyc.LfCycDefId, StateToSet)
                  mRet = VaultUtil.UpdateFileLifecycle(file.MasterId, lifeCycleStateId, "State changed by EDI")
                Catch ex As Exception
                End Try
              End If
            End If
          End If
        End If 'Main file checkedout
      End If
      VaultUtil.LogOut()
    End If 'LogIn
    Return mRet
  End Function

  Sub New()
    'dummy
  End Sub
End Class
