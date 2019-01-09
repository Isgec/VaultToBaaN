Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.td
  <DataObject()> _
  Partial Public Class MasterDocument
    Private Shared _RecordCount As Integer
    Private _t_docn As String = ""
    Private _t_revn As String = ""
    Private _t_cprj As String = ""
    Private _t_dsca As String = ""
    Private _t_aldo As String = ""
    Private _t_alre As String = ""
    Private _t_cspa As String = ""
    Private _t_type As String = ""
    Private _t_resp As String = ""
    Private _t_eunt As String = ""
    Private _t_size As Int32 = 0
    Private _t_orgn As String = ""
    Private _t_subm As Int32 = 0
    Private _t_intr As Int32 = 0
    Private _t_prod As Int32 = 0
    Private _t_erec As Int32 = 0
    Private _t_info As Int32 = 0
    Private _t_remk As String = ""
    Private _t_pldt As String = ""
    Private _t_rele As Int32 = 0
    Private _t_acdt As String = ""
    Private _t_vend As Int32 = 0
    Private _t_bpid As String = ""
    Private _t_revd As Int32 = 0
    Private _t_redt As String = ""
    Private _t_logn As String = ""
    Private _t_verk As String = ""
    Private _t_extn As Int32 = 0
    Private _t_ofbp As String = ""
    Private _t_nama As String = ""
    Private _t_eogn As String = ""
    Private _t_exdt As String = ""
    Private _t_exrk As String = ""
    Private _t_cler As Int32 = 0
    Private _t_bloc As Int32 = 0
    Private _t_appr As Int32 = 0
    Private _t_link As Int32 = 0
    Public ReadOnly Property ForeColor() As System.Drawing.Color
      Get
        Dim mRet As System.Drawing.Color = Drawing.Color.Blue
        Try
					mRet = GetColor()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Visible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Enable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Property t_docn() As String
      Get
        Return _t_docn
      End Get
      Set(ByVal value As String)
        _t_docn = value
      End Set
    End Property
    Public Property t_revn() As String
      Get
        Return _t_revn
      End Get
      Set(ByVal value As String)
        _t_revn = value
      End Set
    End Property
    Public Property t_cprj() As String
      Get
        Return _t_cprj
      End Get
      Set(ByVal value As String)
        _t_cprj = value
      End Set
    End Property
    Public Property t_dsca() As String
      Get
        Return _t_dsca
      End Get
      Set(ByVal value As String)
        _t_dsca = value
      End Set
    End Property
    Public Property t_aldo() As String
      Get
        Return _t_aldo
      End Get
      Set(ByVal value As String)
        _t_aldo = value
      End Set
    End Property
    Public Property t_alre() As String
      Get
        Return _t_alre
      End Get
      Set(ByVal value As String)
        _t_alre = value
      End Set
    End Property
    Public Property t_cspa() As String
      Get
        Return _t_cspa
      End Get
      Set(ByVal value As String)
        _t_cspa = value
      End Set
    End Property
    Public Property t_type() As String
      Get
        Return _t_type
      End Get
      Set(ByVal value As String)
        _t_type = value
      End Set
    End Property
    Public Property t_resp() As String
      Get
        Return _t_resp
      End Get
      Set(ByVal value As String)
        _t_resp = value
      End Set
    End Property
    Public Property t_eunt() As String
      Get
        Return _t_eunt
      End Get
      Set(ByVal value As String)
        _t_eunt = value
      End Set
    End Property
    Public Property t_size() As Int32
      Get
        Return _t_size
      End Get
      Set(ByVal value As Int32)
        _t_size = value
      End Set
    End Property
    Public Property t_orgn() As String
      Get
        Return _t_orgn
      End Get
      Set(ByVal value As String)
        _t_orgn = value
      End Set
    End Property
    Public Property t_subm() As Int32
      Get
        Return _t_subm
      End Get
      Set(ByVal value As Int32)
        _t_subm = value
      End Set
    End Property
    Public Property t_intr() As Int32
      Get
        Return _t_intr
      End Get
      Set(ByVal value As Int32)
        _t_intr = value
      End Set
    End Property
    Public Property t_prod() As Int32
      Get
        Return _t_prod
      End Get
      Set(ByVal value As Int32)
        _t_prod = value
      End Set
    End Property
    Public Property t_erec() As Int32
      Get
        Return _t_erec
      End Get
      Set(ByVal value As Int32)
        _t_erec = value
      End Set
    End Property
    Public Property t_info() As Int32
      Get
        Return _t_info
      End Get
      Set(ByVal value As Int32)
        _t_info = value
      End Set
    End Property
    Public Property t_remk() As String
      Get
        Return _t_remk
      End Get
      Set(ByVal value As String)
        _t_remk = value
      End Set
    End Property
    Public Property t_pldt() As String
      Get
        If Not _t_pldt = String.Empty Then
          Return Convert.ToDateTime(_t_pldt).ToString("dd/MM/yyyy")
        End If
        Return _t_pldt
      End Get
      Set(ByVal value As String)
			   _t_pldt = value
      End Set
    End Property
    Public Property t_rele() As Int32
      Get
        Return _t_rele
      End Get
      Set(ByVal value As Int32)
        _t_rele = value
      End Set
    End Property
    Public Property t_acdt() As String
      Get
        If Not _t_acdt = String.Empty Then
          Return Convert.ToDateTime(_t_acdt).ToString("dd/MM/yyyy")
        End If
        Return _t_acdt
      End Get
      Set(ByVal value As String)
			   _t_acdt = value
      End Set
    End Property
    Public Property t_vend() As Int32
      Get
        Return _t_vend
      End Get
      Set(ByVal value As Int32)
        _t_vend = value
      End Set
    End Property
    Public Property t_bpid() As String
      Get
        Return _t_bpid
      End Get
      Set(ByVal value As String)
        _t_bpid = value
      End Set
    End Property
    Public Property t_revd() As Int32
      Get
        Return _t_revd
      End Get
      Set(ByVal value As Int32)
        _t_revd = value
      End Set
    End Property
    Public Property t_redt() As String
      Get
        If Not _t_redt = String.Empty Then
          Return Convert.ToDateTime(_t_redt).ToString("dd/MM/yyyy")
        End If
        Return _t_redt
      End Get
      Set(ByVal value As String)
			   _t_redt = value
      End Set
    End Property
    Public Property t_logn() As String
      Get
        Return _t_logn
      End Get
      Set(ByVal value As String)
        _t_logn = value
      End Set
    End Property
    Public Property t_verk() As String
      Get
        Return _t_verk
      End Get
      Set(ByVal value As String)
        _t_verk = value
      End Set
    End Property
    Public Property t_extn() As Int32
      Get
        Return _t_extn
      End Get
      Set(ByVal value As Int32)
        _t_extn = value
      End Set
    End Property
    Public Property t_ofbp() As String
      Get
        Return _t_ofbp
      End Get
      Set(ByVal value As String)
        _t_ofbp = value
      End Set
    End Property
    Public Property t_nama() As String
      Get
        Return _t_nama
      End Get
      Set(ByVal value As String)
        _t_nama = value
      End Set
    End Property
    Public Property t_eogn() As String
      Get
        Return _t_eogn
      End Get
      Set(ByVal value As String)
        _t_eogn = value
      End Set
    End Property
    Public Property t_exdt() As String
      Get
        If Not _t_exdt = String.Empty Then
          Return Convert.ToDateTime(_t_exdt).ToString("dd/MM/yyyy")
        End If
        Return _t_exdt
      End Get
      Set(ByVal value As String)
			   _t_exdt = value
      End Set
    End Property
    Public Property t_exrk() As String
      Get
        Return _t_exrk
      End Get
      Set(ByVal value As String)
        _t_exrk = value
      End Set
    End Property
    Public Property t_cler() As Int32
      Get
        Return _t_cler
      End Get
      Set(ByVal value As Int32)
        _t_cler = value
      End Set
    End Property
    Public Property t_bloc() As Int32
      Get
        Return _t_bloc
      End Get
      Set(ByVal value As Int32)
        _t_bloc = value
      End Set
    End Property
    Public Property t_appr() As Int32
      Get
        Return _t_appr
      End Get
      Set(ByVal value As Int32)
        _t_appr = value
      End Set
    End Property
    Public Property t_link() As Int32
      Get
        Return _t_link
      End Get
      Set(ByVal value As Int32)
        _t_link = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _t_docn & "|" & _t_revn
      End Get
    End Property
    Public Shared Property RecordCount() As Integer
      Get
        Return _RecordCount
      End Get
      Set(ByVal value As Integer)
        _RecordCount = value
      End Set
    End Property
    Public Class PKMasterDocument
			Private _t_docn As String = ""
			Private _t_revn As String = ""
			Public Property t_docn() As String
				Get
					Return _t_docn
				End Get
				Set(ByVal value As String)
					_t_docn = value
				End Set
			End Property
			Public Property t_revn() As String
				Get
					Return _t_revn
				End Get
				Set(ByVal value As String)
					_t_revn = value
				End Set
			End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function MasterDocumentSelectList(ByVal OrderBy As String) As List(Of SIS.td.MasterDocument)
      Dim Results As List(Of SIS.td.MasterDocument) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spMasterDocumentSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, "")
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.td.MasterDocument)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.td.MasterDocument(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function MasterDocumentGetNewRecord() As SIS.td.MasterDocument
      Return New SIS.td.MasterDocument()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function MasterDocumentGetByID(ByVal t_docn As String, ByVal t_revn As String) As SIS.td.MasterDocument
      Dim Results As SIS.td.MasterDocument = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spMasterDocumentSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_docn", SqlDbType.VarChar, t_docn.ToString.Length, t_docn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_revn", SqlDbType.VarChar, t_revn.ToString.Length, t_revn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, "")
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.td.MasterDocument(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function MasterDocumentSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.td.MasterDocument)
      Dim Results As List(Of SIS.td.MasterDocument) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spMasterDocumentSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spMasterDocumentSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, "")
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.td.MasterDocument)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.td.MasterDocument(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function MasterDocumentSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function MasterDocumentInsert(ByVal Record As SIS.td.MasterDocument) As SIS.td.MasterDocument
      Dim _Rec As SIS.td.MasterDocument = SIS.td.MasterDocument.MasterDocumentGetNewRecord()
      With _Rec
        .t_docn = Record.t_docn
        .t_revn = Record.t_revn
        .t_cprj = Record.t_cprj
        .t_dsca = Record.t_dsca
        .t_aldo = Record.t_aldo
        .t_alre = Record.t_alre
        .t_cspa = Record.t_cspa
        .t_type = Record.t_type
        .t_resp = Record.t_resp
        .t_eunt = Record.t_eunt
        .t_size = Record.t_size
        .t_orgn = Record.t_orgn
        .t_subm = Record.t_subm
        .t_intr = Record.t_intr
        .t_prod = Record.t_prod
        .t_erec = Record.t_erec
        .t_info = Record.t_info
        .t_remk = Record.t_remk
        .t_pldt = Record.t_pldt
        .t_rele = Record.t_rele
        .t_acdt = Record.t_acdt
        .t_vend = Record.t_vend
        .t_bpid = Record.t_bpid
        .t_revd = Record.t_revd
        .t_redt = Record.t_redt
        .t_logn = Record.t_logn
        .t_verk = Record.t_verk
        .t_extn = Record.t_extn
        .t_ofbp = Record.t_ofbp
        .t_nama = Record.t_nama
        .t_eogn = Record.t_eogn
        .t_exdt = Record.t_exdt
        .t_exrk = Record.t_exrk
        .t_cler = Record.t_cler
        .t_bloc = Record.t_bloc
        .t_appr = Record.t_appr
        .t_link = Record.t_link
      End With
      Return SIS.td.MasterDocument.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.td.MasterDocument) As SIS.td.MasterDocument
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spMasterDocumentInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_docn", SqlDbType.VarChar, 33, Record.t_docn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_revn", SqlDbType.VarChar, 33, Record.t_revn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj", SqlDbType.VarChar, 10, Record.t_cprj)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_dsca", SqlDbType.VarChar, 101, Record.t_dsca)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_aldo", SqlDbType.VarChar, 33, Record.t_aldo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_alre", SqlDbType.VarChar, 21, Record.t_alre)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cspa", SqlDbType.VarChar, 9, Record.t_cspa)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_type", SqlDbType.VarChar, 8, Record.t_type)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_resp", SqlDbType.VarChar, 4, Record.t_resp)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_eunt", SqlDbType.VarChar, 7, Record.t_eunt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_size", SqlDbType.Int, 11, Record.t_size)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_orgn", SqlDbType.VarChar, 4, Record.t_orgn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_subm", SqlDbType.Int, 11, Record.t_subm)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_intr", SqlDbType.Int, 11, Record.t_intr)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_prod", SqlDbType.Int, 11, Record.t_prod)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_erec", SqlDbType.Int, 11, Record.t_erec)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_info", SqlDbType.Int, 11, Record.t_info)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_remk", SqlDbType.VarChar, 101, Record.t_remk)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_pldt", SqlDbType.NVarChar, 21, Record.t_pldt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rele", SqlDbType.Int, 11, Record.t_rele)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_acdt", SqlDbType.NVarChar, 21, Record.t_acdt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_vend", SqlDbType.Int, 11, Record.t_vend)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_bpid", SqlDbType.VarChar, 10, Record.t_bpid)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_revd", SqlDbType.Int, 11, Record.t_revd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_redt", SqlDbType.NVarChar, 21, Record.t_redt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_logn", SqlDbType.VarChar, 17, Record.t_logn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_verk", SqlDbType.VarChar, 101, Record.t_verk)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_extn", SqlDbType.Int, 11, Record.t_extn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ofbp", SqlDbType.VarChar, 10, Record.t_ofbp)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_nama", SqlDbType.VarChar, 36, Record.t_nama)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_eogn", SqlDbType.VarChar, 17, Record.t_eogn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_exdt", SqlDbType.NVarChar, 21, Record.t_exdt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_exrk", SqlDbType.VarChar, 101, Record.t_exrk)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cler", SqlDbType.Int, 11, Record.t_cler)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_bloc", SqlDbType.Int, 11, Record.t_bloc)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_appr", SqlDbType.Int, 11, Record.t_appr)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_link", SqlDbType.Int, 11, Record.t_link)
          Cmd.Parameters.Add("@Return_t_docn", SqlDbType.VarChar, 33)
          Cmd.Parameters("@Return_t_docn").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_t_revn", SqlDbType.VarChar, 33)
          Cmd.Parameters("@Return_t_revn").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.t_docn = Cmd.Parameters("@Return_t_docn").Value
          Record.t_revn = Cmd.Parameters("@Return_t_revn").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function MasterDocumentUpdate(ByVal Record As SIS.td.MasterDocument) As SIS.td.MasterDocument
      Dim _Rec As SIS.td.MasterDocument = SIS.td.MasterDocument.MasterDocumentGetByID(Record.t_docn, Record.t_revn)
      With _Rec
        .t_cprj = Record.t_cprj
        .t_dsca = Record.t_dsca
        .t_aldo = Record.t_aldo
        .t_alre = Record.t_alre
        .t_cspa = Record.t_cspa
        .t_type = Record.t_type
        .t_resp = Record.t_resp
        .t_eunt = Record.t_eunt
        .t_size = Record.t_size
        .t_orgn = Record.t_orgn
        .t_subm = Record.t_subm
        .t_intr = Record.t_intr
        .t_prod = Record.t_prod
        .t_erec = Record.t_erec
        .t_info = Record.t_info
        .t_remk = Record.t_remk
        .t_pldt = Record.t_pldt
        .t_rele = Record.t_rele
        .t_acdt = Record.t_acdt
        .t_vend = Record.t_vend
        .t_bpid = Record.t_bpid
        .t_revd = Record.t_revd
        .t_redt = Record.t_redt
        .t_logn = Record.t_logn
        .t_verk = Record.t_verk
        .t_extn = Record.t_extn
        .t_ofbp = Record.t_ofbp
        .t_nama = Record.t_nama
        .t_eogn = Record.t_eogn
        .t_exdt = Record.t_exdt
        .t_exrk = Record.t_exrk
        .t_cler = Record.t_cler
        .t_bloc = Record.t_bloc
        .t_appr = Record.t_appr
        .t_link = Record.t_link
      End With
      Return SIS.td.MasterDocument.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.td.MasterDocument) As SIS.td.MasterDocument
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spMasterDocumentUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_docn", SqlDbType.VarChar, 33, Record.t_docn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_revn", SqlDbType.VarChar, 33, Record.t_revn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_docn", SqlDbType.VarChar, 33, Record.t_docn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_revn", SqlDbType.VarChar, 33, Record.t_revn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj", SqlDbType.VarChar, 10, Record.t_cprj)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_dsca", SqlDbType.VarChar, 101, Record.t_dsca)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_aldo", SqlDbType.VarChar, 33, Record.t_aldo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_alre", SqlDbType.VarChar, 21, Record.t_alre)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cspa", SqlDbType.VarChar, 9, Record.t_cspa)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_type", SqlDbType.VarChar, 8, Record.t_type)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_resp", SqlDbType.VarChar, 4, Record.t_resp)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_eunt", SqlDbType.VarChar, 7, Record.t_eunt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_size", SqlDbType.Int, 11, Record.t_size)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_orgn", SqlDbType.VarChar, 4, Record.t_orgn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_subm", SqlDbType.Int, 11, Record.t_subm)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_intr", SqlDbType.Int, 11, Record.t_intr)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_prod", SqlDbType.Int, 11, Record.t_prod)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_erec", SqlDbType.Int, 11, Record.t_erec)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_info", SqlDbType.Int, 11, Record.t_info)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_remk", SqlDbType.VarChar, 101, Record.t_remk)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_pldt", SqlDbType.DateTime, 21, Record.t_pldt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rele", SqlDbType.Int, 11, Record.t_rele)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_acdt", SqlDbType.DateTime, 21, Record.t_acdt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_vend", SqlDbType.Int, 11, Record.t_vend)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_bpid", SqlDbType.VarChar, 10, Record.t_bpid)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_revd", SqlDbType.Int, 11, Record.t_revd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_redt", SqlDbType.DateTime, 21, Record.t_redt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_logn", SqlDbType.VarChar, 17, Record.t_logn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_verk", SqlDbType.VarChar, 101, Record.t_verk)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_extn", SqlDbType.Int, 11, Record.t_extn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ofbp", SqlDbType.VarChar, 10, Record.t_ofbp)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_nama", SqlDbType.VarChar, 36, Record.t_nama)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_eogn", SqlDbType.VarChar, 17, Record.t_eogn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_exdt", SqlDbType.DateTime, 21, Record.t_exdt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_exrk", SqlDbType.VarChar, 101, Record.t_exrk)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cler", SqlDbType.Int, 11, Record.t_cler)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_bloc", SqlDbType.Int, 11, Record.t_bloc)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_appr", SqlDbType.Int, 11, Record.t_appr)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_link", SqlDbType.Int, 11, Record.t_link)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Shared Function MasterDocumentDelete(ByVal Record As SIS.td.MasterDocument) As Int32
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spMasterDocumentDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_docn", SqlDbType.VarChar, Record.t_docn.ToString.Length, Record.t_docn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_revn", SqlDbType.VarChar, Record.t_revn.ToString.Length, Record.t_revn)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _RecordCount
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _t_docn = CType(Reader("t_docn"), String)
      _t_revn = CType(Reader("t_revn"), String)
      _t_cprj = CType(Reader("t_cprj"), String)
      _t_dsca = CType(Reader("t_dsca"), String)
      _t_aldo = CType(Reader("t_aldo"), String)
      _t_alre = CType(Reader("t_alre"), String)
      _t_cspa = CType(Reader("t_cspa"), String)
      _t_type = CType(Reader("t_type"), String)
      _t_resp = CType(Reader("t_resp"), String)
      _t_eunt = CType(Reader("t_eunt"), String)
      _t_size = CType(Reader("t_size"), Int32)
      _t_orgn = CType(Reader("t_orgn"), String)
      _t_subm = CType(Reader("t_subm"), Int32)
      _t_intr = CType(Reader("t_intr"), Int32)
      _t_prod = CType(Reader("t_prod"), Int32)
      _t_erec = CType(Reader("t_erec"), Int32)
      _t_info = CType(Reader("t_info"), Int32)
      _t_remk = CType(Reader("t_remk"), String)
      _t_pldt = CType(Reader("t_pldt"), DateTime)
      _t_rele = CType(Reader("t_rele"), Int32)
      _t_acdt = CType(Reader("t_acdt"), DateTime)
      _t_vend = CType(Reader("t_vend"), Int32)
      _t_bpid = CType(Reader("t_bpid"), String)
      _t_revd = CType(Reader("t_revd"), Int32)
      _t_redt = CType(Reader("t_redt"), DateTime)
      _t_logn = CType(Reader("t_logn"), String)
      _t_verk = CType(Reader("t_verk"), String)
      _t_extn = CType(Reader("t_extn"), Int32)
      _t_ofbp = CType(Reader("t_ofbp"), String)
      _t_nama = CType(Reader("t_nama"), String)
      _t_eogn = CType(Reader("t_eogn"), String)
      _t_exdt = CType(Reader("t_exdt"), DateTime)
      _t_exrk = CType(Reader("t_exrk"), String)
      _t_cler = CType(Reader("t_cler"), Int32)
      _t_bloc = CType(Reader("t_bloc"), Int32)
      _t_appr = CType(Reader("t_appr"), Int32)
      _t_link = CType(Reader("t_link"), Int32)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
