Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.td
  <DataObject()> _
  Partial Public Class DM
    Private Shared _RecordCount As Integer
    Private _t_docn As String = ""
    Private _t_revn As String = ""
    Private _t_dcid As String = ""
    Private _t_dsca As String = ""
    Private _t_dttl As String = ""
    Private _t_cspa As String = ""
    Private _t_erec As Int32 = 0
    Private _t_prod As Int32 = 0
    Private _t_info As Int32 = 0
    Private _t_appr As Int32 = 0
    Private _t_resp As String = ""
    Private _t_date As String = ""
    Private _t_appb As String = ""
    Private _t_chkb As String = ""
    Private _t_drwb As String = ""
    Private _t_wght As Double = 0
    Private _t_scal As String = ""
    Private _t_size As String = ""
    Private _t_pdfn As String = ""
    Private _t_cprj As String = ""
    Private _t_grup As String = ""
    Private _t_clnt As String = ""
    Private _t_cnsl As String = ""
    Private _t_year As String = ""
    Private _t_iwtn As String = ""
    Private _t_ser2 As String = ""
    Private _t_ser1 As String = ""
    Private _t_stat As Int32 = 0
    Private _t_name As String = ""
    Private _t_user As String = ""
    Private _t_mach As String = ""
    Private _t_sdat As String = ""
    Private _t_sorc As String = ""
    Private _t_crtp As Int32 = 0
    Private _t_Refcntd As Int32 = 0
    Private _t_Refcntu As Int32 = 0
    Private _t_drdt As String = ""
    Private _t_drur As String = ""
    Private _t_aact As Int32 = 0
    Private _t_aact_1 As Int32 = 0
    Private _t_aact_2 As Int32 = 0
    Private _t_aact_3 As Int32 = 0
    Private _t_adat As String = ""
    Private _t_apre As String = ""
    Private _t_atxt As Int32 = 0
    Private _t_ausr As String = ""
    Private _t_dcrr As Int32 = 0
    Private _t_docs As Int32 = 0
    Private _t_drwd As String = ""
    Private _t_link As Int32 = 0
    Private _t_pdfd As String = ""
    Private _t_ract As Int32 = 0
    Private _t_ract_1 As Int32 = 0
    Private _t_ract_2 As Int32 = 0
    Private _t_rdat As String = ""
    Private _t_rere As String = ""
    Private _t_rtxt As Int32 = 0
    Private _t_rusr As String = ""
    Private _t_sudt As String = ""
    Private _t_type As String = ""
    Private _t_wfst As Int32 = 0
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
    Public Property t_dcid() As String
      Get
        Return _t_dcid
      End Get
      Set(ByVal value As String)
        _t_dcid = value
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
    Public Property t_dttl() As String
      Get
        Return _t_dttl
      End Get
      Set(ByVal value As String)
        _t_dttl = value
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
    Public Property t_erec() As Int32
      Get
        Return _t_erec
      End Get
      Set(ByVal value As Int32)
        _t_erec = value
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
    Public Property t_info() As Int32
      Get
        Return _t_info
      End Get
      Set(ByVal value As Int32)
        _t_info = value
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
    Public Property t_resp() As String
      Get
        Return _t_resp
      End Get
      Set(ByVal value As String)
        _t_resp = value
      End Set
    End Property
    Public Property t_date() As String
      Get
        Return _t_date
      End Get
      Set(ByVal value As String)
        _t_date = value
      End Set
    End Property
    Public Property t_appb() As String
      Get
        Return _t_appb
      End Get
      Set(ByVal value As String)
        _t_appb = value
      End Set
    End Property
    Public Property t_chkb() As String
      Get
        Return _t_chkb
      End Get
      Set(ByVal value As String)
        _t_chkb = value
      End Set
    End Property
    Public Property t_drwb() As String
      Get
        Return _t_drwb
      End Get
      Set(ByVal value As String)
        _t_drwb = value
      End Set
    End Property
    Public Property t_wght() As Double
      Get
        Return _t_wght
      End Get
      Set(ByVal value As Double)
        _t_wght = value
      End Set
    End Property
    Public Property t_scal() As String
      Get
        Return _t_scal
      End Get
      Set(ByVal value As String)
        _t_scal = value
      End Set
    End Property
    Public Property t_size() As String
      Get
        Return _t_size
      End Get
      Set(ByVal value As String)
        _t_size = value
      End Set
    End Property
    Public Property t_pdfn() As String
      Get
        Return _t_pdfn
      End Get
      Set(ByVal value As String)
        _t_pdfn = value
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
    Public Property t_grup() As String
      Get
        Return _t_grup
      End Get
      Set(ByVal value As String)
        _t_grup = value
      End Set
    End Property
    Public Property t_clnt() As String
      Get
        Return _t_clnt
      End Get
      Set(ByVal value As String)
        _t_clnt = value
      End Set
    End Property
    Public Property t_cnsl() As String
      Get
        Return _t_cnsl
      End Get
      Set(ByVal value As String)
        _t_cnsl = value
      End Set
    End Property
    Public Property t_year() As String
      Get
        Return _t_year
      End Get
      Set(ByVal value As String)
        _t_year = value
      End Set
    End Property
    Public Property t_iwtn() As String
      Get
        Return _t_iwtn
      End Get
      Set(ByVal value As String)
        _t_iwtn = value
      End Set
    End Property
    Public Property t_ser2() As String
      Get
        Return _t_ser2
      End Get
      Set(ByVal value As String)
        _t_ser2 = value
      End Set
    End Property
    Public Property t_ser1() As String
      Get
        Return _t_ser1
      End Get
      Set(ByVal value As String)
        _t_ser1 = value
      End Set
    End Property
    Public Property t_stat() As Int32
      Get
        Return _t_stat
      End Get
      Set(ByVal value As Int32)
        _t_stat = value
      End Set
    End Property
    Public Property t_name() As String
      Get
        Return _t_name
      End Get
      Set(ByVal value As String)
        _t_name = value
      End Set
    End Property
    Public Property t_user() As String
      Get
        Return _t_user
      End Get
      Set(ByVal value As String)
        _t_user = value
      End Set
    End Property
    Public Property t_mach() As String
      Get
        Return _t_mach
      End Get
      Set(ByVal value As String)
        _t_mach = value
      End Set
    End Property
    Public Property t_sdat() As String
      Get
        If Not _t_sdat = String.Empty Then
          Return Convert.ToDateTime(_t_sdat).ToString("dd/MM/yyyy")
        End If
        Return _t_sdat
      End Get
      Set(ByVal value As String)
         _t_sdat = value
      End Set
    End Property
    Public Property t_sorc() As String
      Get
        Return _t_sorc
      End Get
      Set(ByVal value As String)
        _t_sorc = value
      End Set
    End Property
    Public Property t_crtp() As Int32
      Get
        Return _t_crtp
      End Get
      Set(ByVal value As Int32)
        _t_crtp = value
      End Set
    End Property
    Public Property t_Refcntd() As Int32
      Get
        Return _t_Refcntd
      End Get
      Set(ByVal value As Int32)
        _t_Refcntd = value
      End Set
    End Property
    Public Property t_Refcntu() As Int32
      Get
        Return _t_Refcntu
      End Get
      Set(ByVal value As Int32)
        _t_Refcntu = value
      End Set
    End Property
    Public Property t_drdt() As String
      Get
        If Not _t_drdt = String.Empty Then
          Return Convert.ToDateTime(_t_drdt).ToString("dd/MM/yyyy")
        End If
        Return _t_drdt
      End Get
      Set(ByVal value As String)
         _t_drdt = value
      End Set
    End Property
    Public Property t_drur() As String
      Get
        Return _t_drur
      End Get
      Set(ByVal value As String)
        _t_drur = value
      End Set
    End Property
    Public Property t_aact() As Int32
      Get
        Return _t_aact
      End Get
      Set(ByVal value As Int32)
        _t_aact = value
      End Set
    End Property
    Public Property t_aact_1() As Int32
      Get
        Return _t_aact_1
      End Get
      Set(ByVal value As Int32)
        _t_aact_1 = value
      End Set
    End Property
    Public Property t_aact_2() As Int32
      Get
        Return _t_aact_2
      End Get
      Set(ByVal value As Int32)
        _t_aact_2 = value
      End Set
    End Property
    Public Property t_aact_3() As Int32
      Get
        Return _t_aact_3
      End Get
      Set(ByVal value As Int32)
        _t_aact_3 = value
      End Set
    End Property
    Public Property t_adat() As String
      Get
        If Not _t_adat = String.Empty Then
          Return Convert.ToDateTime(_t_adat).ToString("dd/MM/yyyy")
        End If
        Return _t_adat
      End Get
      Set(ByVal value As String)
         _t_adat = value
      End Set
    End Property
    Public Property t_apre() As String
      Get
        Return _t_apre
      End Get
      Set(ByVal value As String)
        _t_apre = value
      End Set
    End Property
    Public Property t_atxt() As Int32
      Get
        Return _t_atxt
      End Get
      Set(ByVal value As Int32)
        _t_atxt = value
      End Set
    End Property
    Public Property t_ausr() As String
      Get
        Return _t_ausr
      End Get
      Set(ByVal value As String)
        _t_ausr = value
      End Set
    End Property
    Public Property t_dcrr() As Int32
      Get
        Return _t_dcrr
      End Get
      Set(ByVal value As Int32)
        _t_dcrr = value
      End Set
    End Property
    Public Property t_docs() As Int32
      Get
        Return _t_docs
      End Get
      Set(ByVal value As Int32)
        _t_docs = value
      End Set
    End Property
    Public Property t_drwd() As String
      Get
        Return _t_drwd
      End Get
      Set(ByVal value As String)
        _t_drwd = value
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
    Public Property t_pdfd() As String
      Get
        Return _t_pdfd
      End Get
      Set(ByVal value As String)
        _t_pdfd = value
      End Set
    End Property
    Public Property t_ract() As Int32
      Get
        Return _t_ract
      End Get
      Set(ByVal value As Int32)
        _t_ract = value
      End Set
    End Property
    Public Property t_ract_1() As Int32
      Get
        Return _t_ract_1
      End Get
      Set(ByVal value As Int32)
        _t_ract_1 = value
      End Set
    End Property
    Public Property t_ract_2() As Int32
      Get
        Return _t_ract_2
      End Get
      Set(ByVal value As Int32)
        _t_ract_2 = value
      End Set
    End Property
    Public Property t_rdat() As String
      Get
        If Not _t_rdat = String.Empty Then
          Return Convert.ToDateTime(_t_rdat).ToString("dd/MM/yyyy")
        End If
        Return _t_rdat
      End Get
      Set(ByVal value As String)
         _t_rdat = value
      End Set
    End Property
    Public Property t_rere() As String
      Get
        Return _t_rere
      End Get
      Set(ByVal value As String)
        _t_rere = value
      End Set
    End Property
    Public Property t_rtxt() As Int32
      Get
        Return _t_rtxt
      End Get
      Set(ByVal value As Int32)
        _t_rtxt = value
      End Set
    End Property
    Public Property t_rusr() As String
      Get
        Return _t_rusr
      End Get
      Set(ByVal value As String)
        _t_rusr = value
      End Set
    End Property
    Public Property t_sudt() As String
      Get
        If Not _t_sudt = String.Empty Then
          Return Convert.ToDateTime(_t_sudt).ToString("dd/MM/yyyy")
        End If
        Return _t_sudt
      End Get
      Set(ByVal value As String)
         _t_sudt = value
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
    Public Property t_wfst() As Int32
      Get
        Return _t_wfst
      End Get
      Set(ByVal value As Int32)
        _t_wfst = value
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
    Public Class PKDM
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
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function DMGetByID(ByVal t_docn As String, ByVal t_revn As String, Comp As String) As SIS.td.DM
      Dim Results As SIS.td.DM = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "SELECT * FROM tdmisg001" & Comp & " WHERE t_docn = '" & t_docn & "' AND t_revn = '" & t_revn & "'"
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.td.DM(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
