Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Text
Imports System.Xml
Namespace SIS.EDI
  <DataObject()>
  Partial Public Class ediTmtlH
    Private Shared _RecordCount As Integer
    Private _t_tran As String = ""
    Private _t_type As Int32 = 0
    Private _t_bpid As String = ""
    Private _t_cadr As String = ""
    Private _t_cprj As String = ""
    Private _t_logn As String = ""
    Private _t_subj As String = ""
    Private _t_remk As String = ""
    Private _t_issu As String = ""
    Private _t_stat As Int32 = 0
    Private _t_ofbp As String = ""
    Private _t_vadr As String = ""
    Private _t_padr As String = ""
    Private _t_dprj As String = ""
    Private _t_user As String = ""
    Private _t_date As String = ""
    Private _t_subt As Int32 = 0
    Private _t_refr As String = ""
    Private _t_appr As Int32 = 0
    Private _t_rejc As Int32 = 0
    Private _t_rekm As String = ""
    Private _t_apdt As String = ""
    Private _t_apsu As String = ""
    Private _t_irmk As String = ""
    Private _t_iisu As Int32 = 0
    Private _t_retn As Int32 = 0
    Private _t_smdt As String = ""
    Private _t_isby As String = ""
    Private _t_isdt As String = ""
    Private _t_Refcntd As Int32 = 0
    Private _t_Refcntu As Int32 = 0
    Private _t_edif As Int32 = 0
    Public Property t_tran() As String
      Get
        Return _t_tran
      End Get
      Set(ByVal value As String)
        _t_tran = value
      End Set
    End Property
    Public Property t_type() As Int32
      Get
        Return _t_type
      End Get
      Set(ByVal value As Int32)
        _t_type = value
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
    Public Property t_cadr() As String
      Get
        Return _t_cadr
      End Get
      Set(ByVal value As String)
        _t_cadr = value
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
    Public Property t_logn() As String
      Get
        Return _t_logn
      End Get
      Set(ByVal value As String)
        _t_logn = value
      End Set
    End Property
    Public Property t_subj() As String
      Get
        Return _t_subj
      End Get
      Set(ByVal value As String)
        _t_subj = value
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
    Public Property t_issu() As String
      Get
        Return _t_issu
      End Get
      Set(ByVal value As String)
        _t_issu = value
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
    Public Property t_ofbp() As String
      Get
        Return _t_ofbp
      End Get
      Set(ByVal value As String)
        _t_ofbp = value
      End Set
    End Property
    Public Property t_vadr() As String
      Get
        Return _t_vadr
      End Get
      Set(ByVal value As String)
        _t_vadr = value
      End Set
    End Property
    Public Property t_padr() As String
      Get
        Return _t_padr
      End Get
      Set(ByVal value As String)
        _t_padr = value
      End Set
    End Property
    Public Property t_dprj() As String
      Get
        Return _t_dprj
      End Get
      Set(ByVal value As String)
        _t_dprj = value
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
    Public Property t_date() As String
      Get
        If Not _t_date = String.Empty Then
          Return Convert.ToDateTime(_t_date).ToString("dd/MM/yyyy")
        End If
        Return _t_date
      End Get
      Set(ByVal value As String)
        _t_date = value
      End Set
    End Property
    Public Property t_subt() As Int32
      Get
        Return _t_subt
      End Get
      Set(ByVal value As Int32)
        _t_subt = value
      End Set
    End Property
    Public Property t_refr() As String
      Get
        Return _t_refr
      End Get
      Set(ByVal value As String)
        _t_refr = value
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
    Public Property t_rejc() As Int32
      Get
        Return _t_rejc
      End Get
      Set(ByVal value As Int32)
        _t_rejc = value
      End Set
    End Property
    Public Property t_rekm() As String
      Get
        Return _t_rekm
      End Get
      Set(ByVal value As String)
        _t_rekm = value
      End Set
    End Property
    Public Property t_apdt() As String
      Get
        If Not _t_apdt = String.Empty Then
          Return Convert.ToDateTime(_t_apdt).ToString("dd/MM/yyyy")
        End If
        Return _t_apdt
      End Get
      Set(ByVal value As String)
        _t_apdt = value
      End Set
    End Property
    Public Property t_apsu() As String
      Get
        Return _t_apsu
      End Get
      Set(ByVal value As String)
        _t_apsu = value
      End Set
    End Property
    Public Property t_irmk() As String
      Get
        Return _t_irmk
      End Get
      Set(ByVal value As String)
        _t_irmk = value
      End Set
    End Property
    Public Property t_iisu() As Int32
      Get
        Return _t_iisu
      End Get
      Set(ByVal value As Int32)
        _t_iisu = value
      End Set
    End Property
    Public Property t_retn() As Int32
      Get
        Return _t_retn
      End Get
      Set(ByVal value As Int32)
        _t_retn = value
      End Set
    End Property
    Public Property t_smdt() As String
      Get
        If Not _t_smdt = String.Empty Then
          Return Convert.ToDateTime(_t_smdt).ToString("dd/MM/yyyy")
        End If
        Return _t_smdt
      End Get
      Set(ByVal value As String)
        _t_smdt = value
      End Set
    End Property
    Public Property t_isby() As String
      Get
        Return _t_isby
      End Get
      Set(ByVal value As String)
        _t_isby = value
      End Set
    End Property
    Public Property t_isdt() As String
      Get
        If Not _t_isdt = String.Empty Then
          Return Convert.ToDateTime(_t_isdt).ToString("dd/MM/yyyy")
        End If
        Return _t_isdt
      End Get
      Set(ByVal value As String)
        _t_isdt = value
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
    Public Property t_edif() As Int32
      Get
        Return _t_edif
      End Get
      Set(ByVal value As Int32)
        _t_edif = value
      End Set
    End Property
    Public ReadOnly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public ReadOnly Property PrimaryKey() As String
      Get
        Return _t_tran
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
    Public Class PKediTmtlH
      Private _t_tran As String = ""
      Public Property t_tran() As String
        Get
          Return _t_tran
        End Get
        Set(ByVal value As String)
          _t_tran = value
        End Set
      End Property
    End Class
    Public Shared Function TmtlEMailIDsForDCR(ByVal DCRNo As String) As List(Of SIS.EDI.ediTmtlH)
      Dim Results As New List(Of SIS.EDI.ediTmtlH)
      Dim Sql As String = ""
      Sql &= " select distinct tmH.*  "
      Sql &= " from tdmisg131200 as tmH "
      Sql &= " inner join tdmisg132200 as tmD on tmH.t_tran=tmD.t_tran "
      Sql &= " inner join tdmisg115200 as dcD on tmD.t_docn=dcD.t_docd "
      Sql &= " where dcD.t_dcrn='" & DCRNo & "'"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While Reader.Read()
            Results.Add(New SIS.EDI.ediTmtlH(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function TmtlEMailIDsForDoc(ByVal DocID As String) As List(Of SIS.EDI.ediTmtlH)
      Dim Results As New List(Of SIS.EDI.ediTmtlH)
      Dim Sql As String = ""
      Sql &= " select distinct tmH.*  "
      Sql &= " from tdmisg131200 as tmH "
      Sql &= " inner join tdmisg132200 as tmD on tmH.t_tran=tmD.t_tran "
      Sql &= " inner join tdmisg115200 as dcD on tmD.t_docn=dcD.t_docd "
      Sql &= " where dcD.t_docd='" & DocID & "'"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While Reader.Read()
            Results.Add(New SIS.EDI.ediTmtlH(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function

    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              Dim Found As Boolean = False
              For I As Integer = 0 To Reader.FieldCount - 1
                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                  Found = True
                  Exit For
                End If
              Next
              If Found Then
                If Convert.IsDBNull(Reader(pi.Name)) Then
                  Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                    Case "decimal"
                      CallByName(Me, pi.Name, CallType.Let, "0.00")
                    Case "bit"
                      CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                    Case Else
                      CallByName(Me, pi.Name, CallType.Let, String.Empty)
                  End Select
                Else
                  CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                End If
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
    Public Sub New()
    End Sub
    Private Class emp
      Public Property empID As Integer = 0
      Public Property empName As String = ""
      Public Property empEMail As String = ""

      Public Shared Function GetEmp(ByVal empID As Integer) As emp
        Dim mSql As String = ""
        mSql = mSql & " select "
        mSql = mSql & " emp1.t_nama as empName,"
        mSql = mSql & " bpe1.t_mail as empEMail "
        mSql = mSql & " from ttccom001200 as emp1 "
        mSql = mSql & " left outer join tbpmdm001200 as bpe1 on emp1.t_emno=bpe1.t_emno "
        mSql = mSql & " where emp1.t_emno = '" & empID & "'"
        Dim tmp As emp = Nothing
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = mSql
            tmp = New emp
            Con.Open()
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            If (Reader.Read()) Then
              With tmp
                .empID = empID
                If Not Convert.IsDBNull(Reader("empName")) Then .empName = Reader("empName")
                If Not Convert.IsDBNull(Reader("empEMail")) Then .empEMail = Reader("empEMail")
              End With
            End If
            Reader.Close()
          End Using
        End Using
        Return tmp
      End Function
      Public Shared Function GetProjectName(ByVal ProjectID As String) As String
        Dim mSql As String = ""
        mSql = mSql & " select top 1 "
        mSql = mSql & " t_dsca "
        mSql = mSql & " from ttcmcs052200 "
        mSql = mSql & " where t_cprj = '" & ProjectID & "'"
        Dim tmp As String = ""
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = mSql
            Con.Open()
            tmp = Cmd.ExecuteScalar()
          End Using
        End Using
        Return tmp
      End Function

      Public Shared Function GetBPName(ByVal BPID As String) As String
        Dim mSql As String = ""
        mSql = mSql & " select top 1 "
        mSql = mSql & " t_nama "
        mSql = mSql & " from ttccom100200 "
        mSql = mSql & " where t_bpid = '" & BPID & "'"
        Dim tmp As String = ""
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = mSql
            Con.Open()
            tmp = Cmd.ExecuteScalar()
          End Using
        End Using
        Return tmp
      End Function
      Public Shared Function GetIssuedVia(ByVal IssueID As String) As String
        Dim mSql As String = ""
        mSql = mSql & " select top 1 "
        mSql = mSql & " t_dsca "
        mSql = mSql & " from tdmisg125200 "
        mSql = mSql & " where t_issu = '" & IssueID & "'"
        Dim tmp As String = ""
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = mSql
            Con.Open()
            tmp = Cmd.ExecuteScalar()
          End Using
        End Using
        Return tmp
      End Function

      Public Shared Function GetReceiptCreator(ByVal tmtlID As String) As String
        Dim mSql As String = ""
        mSql = mSql & " select "
        mSql = mSql & " t_user as [user] "
        mSql = mSql & " from tdmisg134200 "
        mSql = mSql & " where t_trno = '" & tmtlID & "'"
        Dim tmp As String = ""
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = mSql
            Con.Open()
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            If (Reader.Read()) Then
              If Not Convert.IsDBNull(Reader("user")) Then tmp = Reader("user")
            End If
            Reader.Close()
          End Using
        End Using
        Return tmp
      End Function
    End Class

  End Class

End Namespace
