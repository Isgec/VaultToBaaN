Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ERP
  <DataObject()> _
  Partial Public Class erpDCRDetail
    Public Property DCRNo As String = ""
    Public Property DocumentID As String = ""
    Public Property RevisionNo As String = ""
    Public Property IndentNo As String = ""
    Public Property IndentLine As String = ""
    Public Property LotItem As String = ""
    Public Property ItemDescription As String = ""
    Public Property IndenterID As String = ""
    Public Property BuyerID As String = ""
    Public Property OrderNo As String = ""
    Public Property OrderLine As String = ""
    Public Property SupplierID As String = ""
    Public Property BuyerIDinPO As String = ""
    Public Property IndenterName As String = ""
    Public Property IndenterEMail As String = ""
    Public Property BuyerName As String = ""
    Public Property BuyerEMail As String = ""
    Public Property BuyerIDinPOName As String = ""
    Public Property BuyerIDinPOEMail As String = ""
    Public Property SupplierName As String = ""
    Public Property DocumentTitle As String = ""
    Public Property ERP_DCRHeader1_DCRDescription As String = ""
    Public Property Released As Boolean = False
    Public Property NextRevision As String = ""
    Public Property ReleasedOn As String = ""
    Public Property DownloadKey As String = ""
    Public Property DownloadExpiresOn As String = ""
    Public Shared Function InsertData(ByVal Record As SIS.ERP.erpDCRDetail, Comp As String) As SIS.ERP.erpDCRDetail
      'Used
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString(Comp))
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpDCRDetailInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DCRNo", SqlDbType.NVarChar, 11, Record.DCRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentID", SqlDbType.NVarChar, 31, Record.DocumentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RevisionNo", SqlDbType.NVarChar, 6, Record.RevisionNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndentNo", SqlDbType.NVarChar, 11, IIf(Record.IndentNo = "", Convert.DBNull, Record.IndentNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndentLine", SqlDbType.NVarChar, 6, IIf(Record.IndentLine = "", Convert.DBNull, Record.IndentLine))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LotItem", SqlDbType.NVarChar, 51, IIf(Record.LotItem = "", Convert.DBNull, Record.LotItem))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemDescription", SqlDbType.NVarChar, 101, IIf(Record.ItemDescription = "", Convert.DBNull, Record.ItemDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndenterID", SqlDbType.NVarChar, 9, IIf(Record.IndenterID = "", Convert.DBNull, Record.IndenterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerID", SqlDbType.NVarChar, 9, IIf(Record.BuyerID = "", Convert.DBNull, Record.BuyerID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderNo", SqlDbType.NVarChar, 11, IIf(Record.OrderNo = "", Convert.DBNull, Record.OrderNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderLine", SqlDbType.NVarChar, 6, IIf(Record.OrderLine = "", Convert.DBNull, Record.OrderLine))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID", SqlDbType.NVarChar, 11, IIf(Record.SupplierID = "", Convert.DBNull, Record.SupplierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerIDinPO", SqlDbType.NVarChar, 9, IIf(Record.BuyerIDinPO = "", Convert.DBNull, Record.BuyerIDinPO))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndenterName", SqlDbType.NVarChar, 51, IIf(Record.IndenterName = "", Convert.DBNull, Record.IndenterName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndenterEMail", SqlDbType.NVarChar, 51, IIf(Record.IndenterEMail = "", Convert.DBNull, Record.IndenterEMail))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerName", SqlDbType.NVarChar, 51, IIf(Record.BuyerName = "", Convert.DBNull, Record.BuyerName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerEMail", SqlDbType.NVarChar, 51, IIf(Record.BuyerEMail = "", Convert.DBNull, Record.BuyerEMail))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerIDinPOName", SqlDbType.NVarChar, 51, IIf(Record.BuyerIDinPOName = "", Convert.DBNull, Record.BuyerIDinPOName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerIDinPOEMail", SqlDbType.NVarChar, 51, IIf(Record.BuyerIDinPOEMail = "", Convert.DBNull, Record.BuyerIDinPOEMail))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierName", SqlDbType.NVarChar, 101, IIf(Record.SupplierName = "", Convert.DBNull, Record.SupplierName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentTitle", SqlDbType.NVarChar, 101, IIf(Record.DocumentTitle = "", Convert.DBNull, Record.DocumentTitle))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Released", SqlDbType.Bit, 3, Record.Released)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NextRevision", SqlDbType.NVarChar, 6, IIf(Record.NextRevision = "", Convert.DBNull, Record.NextRevision))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReleasedOn", SqlDbType.DateTime, 21, IIf(Record.ReleasedOn = "", Convert.DBNull, Record.ReleasedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DownloadKey", SqlDbType.NVarChar, 51, IIf(Record.DownloadKey = "", Convert.DBNull, Record.DownloadKey))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DownloadExpiresOn", SqlDbType.DateTime, 21, IIf(Record.DownloadExpiresOn = "", Convert.DBNull, Record.DownloadExpiresOn))
          Cmd.Parameters.Add("@Return_DCRNo", SqlDbType.NVarChar, 11)
          Cmd.Parameters("@Return_DCRNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_DocumentID", SqlDbType.NVarChar, 31)
          Cmd.Parameters("@Return_DocumentID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_RevisionNo", SqlDbType.NVarChar, 6)
          Cmd.Parameters("@Return_RevisionNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.DCRNo = Cmd.Parameters("@Return_DCRNo").Value
          Record.DocumentID = Cmd.Parameters("@Return_DocumentID").Value
          Record.RevisionNo = Cmd.Parameters("@Return_RevisionNo").Value
        End Using
      End Using
      Return Record
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.ERP.erpDCRDetail, Comp As String) As SIS.ERP.erpDCRDetail
      'Used
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString(Comp))
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpDCRDetailUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DCRNo", SqlDbType.NVarChar, 11, Record.DCRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DocumentID", SqlDbType.NVarChar, 31, Record.DocumentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RevisionNo", SqlDbType.NVarChar, 6, Record.RevisionNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DCRNo", SqlDbType.NVarChar, 11, Record.DCRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentID", SqlDbType.NVarChar, 31, Record.DocumentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RevisionNo", SqlDbType.NVarChar, 6, Record.RevisionNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndentNo", SqlDbType.NVarChar, 11, IIf(Record.IndentNo = "", Convert.DBNull, Record.IndentNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndentLine", SqlDbType.NVarChar, 6, IIf(Record.IndentLine = "", Convert.DBNull, Record.IndentLine))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LotItem", SqlDbType.NVarChar, 51, IIf(Record.LotItem = "", Convert.DBNull, Record.LotItem))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemDescription", SqlDbType.NVarChar, 101, IIf(Record.ItemDescription = "", Convert.DBNull, Record.ItemDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndenterID", SqlDbType.NVarChar, 9, IIf(Record.IndenterID = "", Convert.DBNull, Record.IndenterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerID", SqlDbType.NVarChar, 9, IIf(Record.BuyerID = "", Convert.DBNull, Record.BuyerID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderNo", SqlDbType.NVarChar, 11, IIf(Record.OrderNo = "", Convert.DBNull, Record.OrderNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderLine", SqlDbType.NVarChar, 6, IIf(Record.OrderLine = "", Convert.DBNull, Record.OrderLine))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID", SqlDbType.NVarChar, 11, IIf(Record.SupplierID = "", Convert.DBNull, Record.SupplierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerIDinPO", SqlDbType.NVarChar, 9, IIf(Record.BuyerIDinPO = "", Convert.DBNull, Record.BuyerIDinPO))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndenterName", SqlDbType.NVarChar, 51, IIf(Record.IndenterName = "", Convert.DBNull, Record.IndenterName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndenterEMail", SqlDbType.NVarChar, 51, IIf(Record.IndenterEMail = "", Convert.DBNull, Record.IndenterEMail))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerName", SqlDbType.NVarChar, 51, IIf(Record.BuyerName = "", Convert.DBNull, Record.BuyerName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerEMail", SqlDbType.NVarChar, 51, IIf(Record.BuyerEMail = "", Convert.DBNull, Record.BuyerEMail))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerIDinPOName", SqlDbType.NVarChar, 51, IIf(Record.BuyerIDinPOName = "", Convert.DBNull, Record.BuyerIDinPOName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerIDinPOEMail", SqlDbType.NVarChar, 51, IIf(Record.BuyerIDinPOEMail = "", Convert.DBNull, Record.BuyerIDinPOEMail))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierName", SqlDbType.NVarChar, 101, IIf(Record.SupplierName = "", Convert.DBNull, Record.SupplierName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentTitle", SqlDbType.NVarChar, 101, IIf(Record.DocumentTitle = "", Convert.DBNull, Record.DocumentTitle))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Released", SqlDbType.Bit, 3, Record.Released)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NextRevision", SqlDbType.NVarChar, 6, IIf(Record.NextRevision = "", Convert.DBNull, Record.NextRevision))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReleasedOn", SqlDbType.DateTime, 21, IIf(Record.ReleasedOn = "", Convert.DBNull, Record.ReleasedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DownloadKey", SqlDbType.NVarChar, 51, IIf(Record.DownloadKey = "", Convert.DBNull, Record.DownloadKey))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DownloadExpiresOn", SqlDbType.DateTime, 21, IIf(Record.DownloadExpiresOn = "", Convert.DBNull, Record.DownloadExpiresOn))
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
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
