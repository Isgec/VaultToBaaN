Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ERP
  <DataObject()> _
  Partial Public Class erpDCRHeader
    Private Shared _RecordCount As Integer
    Private _DCRNo As String = ""
    Private _DCRDate As String = ""
    Private _DCRDescription As String = ""
    Private _CreatedBy As String = ""
    Private _CreatedName As String = ""
    Private _CreatedEMail As String = ""
    Private _ProjectID As String = ""
    Private _ProjectDescription As String = ""
    Public Property DCRNo() As String
      Get
        Return _DCRNo
      End Get
      Set(ByVal value As String)
        _DCRNo = value
      End Set
    End Property
    Public Property DCRDate() As String
      Get
        Return _DCRDate
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _DCRDate = ""
				 Else
					 _DCRDate = value
			   End If
      End Set
    End Property
    Public Property DCRDescription() As String
      Get
        Return _DCRDescription
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _DCRDescription = ""
				 Else
					 _DCRDescription = value
			   End If
      End Set
    End Property
    Public Property CreatedBy() As String
      Get
        Return _CreatedBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _CreatedBy = ""
				 Else
					 _CreatedBy = value
			   End If
      End Set
    End Property
    Public Property CreatedName() As String
      Get
        Return _CreatedName
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _CreatedName = ""
				 Else
					 _CreatedName = value
			   End If
      End Set
    End Property
    Public Property CreatedEMail() As String
      Get
        Return _CreatedEMail
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _CreatedEMail = ""
				 Else
					 _CreatedEMail = value
			   End If
      End Set
    End Property
    Public Property ProjectID() As String
      Get
        Return _ProjectID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ProjectID = ""
				 Else
					 _ProjectID = value
			   End If
      End Set
    End Property
    Public Property ProjectDescription() As String
      Get
        Return _ProjectDescription
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ProjectDescription = ""
				 Else
					 _ProjectDescription = value
			   End If
      End Set
    End Property
    Public Shared Function erpDCRHeaderGetByID(ByVal DCRNo As String, comp As String) As SIS.ERP.erpDCRHeader
      'Used
      Dim Results As SIS.ERP.erpDCRHeader = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString(comp))
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpDCRHeaderSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DCRNo", SqlDbType.NVarChar, DCRNo.ToString.Length, DCRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, "")
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ERP.erpDCRHeader(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.ERP.erpDCRHeader, Comp As String) As SIS.ERP.erpDCRHeader
      'Used
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString(Comp))
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpDCRHeaderInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DCRNo", SqlDbType.NVarChar, 11, Record.DCRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DCRDate", SqlDbType.NVarChar, 21, IIf(Record.DCRDate = "", Convert.DBNull, Record.DCRDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DCRDescription", SqlDbType.NVarChar, 101, IIf(Record.DCRDescription = "", Convert.DBNull, Record.DCRDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy", SqlDbType.NVarChar, 9, IIf(Record.CreatedBy = "", Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedName", SqlDbType.NVarChar, 51, IIf(Record.CreatedName = "", Convert.DBNull, Record.CreatedName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedEMail", SqlDbType.NVarChar, 51, IIf(Record.CreatedEMail = "", Convert.DBNull, Record.CreatedEMail))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 7, IIf(Record.ProjectID = "", Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectDescription", SqlDbType.NVarChar, 101, IIf(Record.ProjectDescription = "", Convert.DBNull, Record.ProjectDescription))
          Cmd.Parameters.Add("@Return_DCRNo", SqlDbType.NVarChar, 11)
          Cmd.Parameters("@Return_DCRNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.DCRNo = Cmd.Parameters("@Return_DCRNo").Value
        End Using
      End Using
      Return Record
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
