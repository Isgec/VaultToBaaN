Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ERP
  Partial Public Class erpDCRHeader
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function BaaNDCRHeaderSelectList(ByVal DCRNo As String, Comp As String) As SIS.ERP.erpDCRHeader
      'Used
      Dim mSql As String = ""
      mSql = mSql & "select "
      mSql = mSql & "dcrh.t_dcrn as DCRNo,"
      mSql = mSql & "dcrh.t_apdt as DCRDate, "
      mSql = mSql & "dcrh.t_dsca as DCRDescription,"
      mSql = mSql & "dcrh.t_crea as CreatedBy,"
      mSql = mSql & "dcrh.t_cprj as ProjectID,"
      mSql = mSql & "emp1.t_nama as CreatedName,"
      mSql = mSql & "bpe1.t_mail as CreatedEMail,"
      mSql = mSql & "adr1.t_dsca as ProjectDescription "
      mSql = mSql & "from tdmisg114" & Comp & " dcrh "
      mSql = mSql & "left outer join ttccom001" & Comp & " as emp1 on dcrh.t_crea=emp1.t_emno "
      mSql = mSql & "left outer join tbpmdm001" & Comp & " as bpe1 on dcrh.t_crea=bpe1.t_emno "
      mSql = mSql & "left outer join ttcmcs052" & Comp & " as adr1 on dcrh.t_cprj=adr1.t_cprj "
      mSql = mSql & "where dcrh.t_dcrn = '" & DCRNo & "'"
      Dim Results As SIS.ERP.erpDCRHeader = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = mSql
          _RecordCount = -1
          Results = New SIS.ERP.erpDCRHeader
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results = New SIS.ERP.erpDCRHeader(Reader)
            Exit While
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
  End Class
End Namespace
