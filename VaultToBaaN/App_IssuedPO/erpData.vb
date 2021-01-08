Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel

Namespace SIS.PAK
  Public Class erpData
    Public Class erpPO
      Public Shared Function pakPOGetByPONumber(ByVal PONumber As String, ByVal forTC As Boolean) As SIS.PAK.pakPO
        Dim Results As SIS.PAK.pakPO = Nothing
        Dim TC As String = IIf(forTC, "TC", "PK")
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "sppak_LG_POSelectByPONumber"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@forTC", SqlDbType.NVarChar, 2, TC)
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PONumber", SqlDbType.NVarChar, PONumber.Length, PONumber)
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, "")
            Con.Open()
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            If Reader.Read() Then
              Results = New SIS.PAK.pakPO(Reader)
            End If
            Reader.Close()
          End Using
        End Using
        Return Results
      End Function

      '1.1. Used
      Public Shared Sub UpdateIssuedPO(DocumentID As String, RevisionNo As String, Comp As String)
        Dim ePOs As List(Of EffectedPOByDrawings) = EffectedPOByDrawings.GetPOList(DocumentID, Comp)
        If ePOs.Count > 0 Then
          Dim MoreThanOnePO As Boolean = IIf(ePOs.Count > 1, True, False)
          For Each ePO As EffectedPOByDrawings In ePOs
            UpdateIssuedPOFromDrawing(ePO, DocumentID, RevisionNo, Comp, MoreThanOnePO)
          Next
        End If
      End Sub
      '1.2. Used
      Public Shared Sub UpdateIssuedPOFromDrawing(ePO As EffectedPOByDrawings, DocumentID As String, RevisionNo As String, Comp As String, MoreThanOnePO As Boolean)
        Dim PO As SIS.PAK.pakPO = SIS.PAK.erpData.erpPO.pakPOGetByPONumber(ePO.PONumber, False)
        If PO IsNot Nothing Then
          Try
            Select Case PO.POTypeID
              Case pakErpPOTypes.ISGECEngineered, pakErpPOTypes.Boughtout
                Dim dmItems As List(Of dmisg002) = dmisg002.GetItems(DocumentID, RevisionNo, Comp)
                Dim bItems As List(Of SIS.PAK.pakPOBItems) = SIS.PAK.pakPOBItems.GetByDocRev(PO.SerialNo, ePO.POLine, DocumentID, RevisionNo)
                Dim Found As Boolean = False
                For Each dmItem As dmisg002 In dmItems
                  Found = False
                  Dim bItem As SIS.PAK.pakPOBItems = Nothing
                  For Each bItem In bItems
                    If bItem.ItemCode.Trim = dmItem.t_item.Trim Then
                      Found = True
                      Exit For
                    End If
                  Next
                  If Not Found Then
                    If MoreThanOnePO Then
                      Continue For 'Do Not Insert New Item
                    End If
                    bItem = bItems(0)
                    Dim mNextItemNo As Integer = GetNextItemNo(bItem.SerialNo, bItem.BOMNo)
                    With bItem
                      .ItemNo = mNextItemNo
                      .ItemCode = dmItem.t_item.Trim
                      .ItemDescription = dmItem.t_dsca
                      .QuantityToPack = 0
                      .TotalWeightToPack = 0
                      .QuantityToDespatch = 0
                      .TotalWeightToDespatch = 0
                      .QuantityDespatched = 0
                      .TotalWeightDespatched = 0
                      .QuantityReceived = 0
                      .TotalWeightReceived = 0
                    End With
                  End If
                  With bItem
                    Try
                      .ItemDescription = dmItem.t_dsca
                      If dmItem.t_cuni <> "" Then
                        .UOMQuantity = SIS.PAK.pakUnits.pakUnitsGetByDescription(dmItem.t_cuni).UnitID
                      End If
                      If dmItem.t_qnty < 0.0001 Then dmItem.t_qnty = 0
                      If PO.QCRequired Then
                        If dmItem.t_qnty < bItem.QualityClearedQty Then
                          dmItem.t_qnty = bItem.QualityClearedQty
                        End If
                      Else
                        If dmItem.t_qnty < bItem.QuantityDespatched Then
                          dmItem.t_qnty = bItem.QuantityDespatched
                        End If
                      End If
                      .Quantity = dmItem.t_qnty
                      .UOMWeight = SIS.PAK.pakUnits.pakUnitsGetByDescription("kg").UnitID
                      If dmItem.t_wght >= 0.0001 AndAlso dmItem.t_qnty >= 0.0001 Then
                        .WeightPerUnit = dmItem.t_wght / dmItem.t_qnty
                      Else
                        .WeightPerUnit = 0
                      End If
                    Catch ex As Exception
                      Throw New Exception("Err Updating: " & ex.Message)
                    End Try
                  End With
                  If Found Then
                    bItem = SIS.PAK.pakPOBItems.UpdateData(bItem)
                  Else
                    bItem = SIS.PAK.pakPOBItems.InsertData(bItem)
                  End If
                Next
                'Update Document Revision
                SIS.PAK.pakPOBItems.CreateNewRevDocumentAndLink(PO.SerialNo, ePO.POLine, DocumentID, RevisionNo)
                'Reverse check to Delete Items Removed from Drawing
                'Do Not Reverse Check to delete if more than One PO
                If Not MoreThanOnePO Then
                  For Each bItem As SIS.PAK.pakPOBItems In bItems
                    Found = False
                    For Each dmItem As dmisg002 In dmItems
                      If bItem.ItemCode.Trim = dmItem.t_item.Trim Then
                        Found = True
                        Exit For
                      End If
                    Next
                    If Not Found Then
                      If SIS.PAK.pakPOBItems.CanBeDeleted(bItem) Then
                        SIS.PAK.pakPOBItems.pakPOBItemsDeleteRecursive(bItem)
                      Else
                        bItem.DeletedInERP = True
                        SIS.PAK.pakPOBItems.UpdateData(bItem)
                      End If
                    End If
                  Next
                End If
            End Select
          Catch ex As Exception
          End Try
        End If
      End Sub

      Private Shared Function GetNextItemNo(ByVal SerialNo As Integer, ByVal BomNo As Integer) As Integer
        Dim tmp As Integer = 0
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
          Using Cmd As SqlCommand = Con.CreateCommand()
            Dim mSql As String = "SELECT MAX(ISNULL(ItemNo,0)) FROM [PAK_POBitems] WHERE SerialNo = " & SerialNo & " and BOMNo=" & BomNo
            Cmd.CommandType = System.Data.CommandType.Text
            Cmd.CommandText = mSql
            Con.Open()
            Try
              tmp = Cmd.ExecuteScalar()
              tmp += 1
            Catch ex As Exception
              tmp = 1
            End Try
          End Using
        End Using
        Return tmp
      End Function
      Sub New()
        'dummy
      End Sub
    End Class
    Public Class EffectedPOByDrawings
      Public Property PONumber As String = ""
      Public Property POLine As Integer = 0
      Public Shared Function GetPOList(DocumentID As String, Comp As String) As List(Of EffectedPOByDrawings)
        Dim Sql As String = ""
        Sql &= " SELECT distinct t_orno as PONumber,t_pono As POLine FROM ttdisg002" & Comp
        Sql &= " WHERE t_docn='" & DocumentID & "' "
        Dim mRet As New List(Of EffectedPOByDrawings)
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            Con.Open()
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            While (Reader.Read())
              mRet.Add(New EffectedPOByDrawings(Reader))
            End While
            Reader.Close()
          End Using
        End Using
        Return mRet
      End Function
      Sub New(rd As SqlDataReader)
        SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, rd)
      End Sub
    End Class
    Public Class dmisg002
      Public Property t_docn As String = ""
      Public Property t_revn As String = ""
      Public Property t_srno As Integer = 0
      Public Property t_item As String = ""
      Public Property t_dsca As String = ""
      Public Property t_citg As String = ""
      Public Property t_qnty As Double = 0
      Public Property t_wght As Double = 0
      Public Property t_itmt As String = ""
      Public Property t_txta As Integer = 0
      Public Property t_txtb As Integer = 0
      Public Property t_cuni As String = ""
      Public Property t_oitm As String = ""
      Public Property t_elem As String = ""
      Public Property t_Refcntd As Integer = 0
      Public Property t_Refcntu As Integer = 0
      Public Property t_sitm As String = ""

      Public Shared Function GetItems(DocumentID As String, RevisionNo As String, comp As String) As List(Of dmisg002)
        Dim Ret As New List(Of dmisg002)
        Dim Sql As String = ""
        Sql &= "select *  "
        Sql &= "  from tdmisg002" & comp & "  "
        Sql &= "  where t_docn ='" & DocumentID & "'"
        Sql &= "    and t_revn ='" & RevisionNo & "'"
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            Con.Open()
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            Do While (Reader.Read())
              Ret.Add(New dmisg002(Reader))
            Loop
            Reader.Close()
          End Using
        End Using
        Return Ret
      End Function

      Sub New(ByVal rd As SqlDataReader)
        SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, rd)
      End Sub
      Sub New()
        MyBase.New()
      End Sub

    End Class
  End Class
End Namespace
