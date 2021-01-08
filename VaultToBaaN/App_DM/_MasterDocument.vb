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
    Public Shared Function MasterDocumentGetByID(ByVal t_docn As String, ByVal t_revn As String, Comp As String) As SIS.td.MasterDocument
      Dim Results As SIS.td.MasterDocument = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "SELECT * FROM tdmisg121" & Comp & " WHERE t_docn = '" & t_docn & "' AND t_revn = '" & t_revn & "'"
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
    Public Shared Function InsertData(ByVal Record As SIS.td.MasterDocument, Comp As String) As SIS.td.MasterDocument
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spMasterDocumentInsert_" & Comp
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
    Public Shared Function UpdateData(ByVal Record As SIS.td.MasterDocument, Comp As String) As SIS.td.MasterDocument
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spMasterDocumentUpdate_" & Comp
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
    Public Sub New(ByVal Reader As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
