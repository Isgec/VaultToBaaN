Public Class mstDocList
  Public Shared Sub InsUpdMasterDocumentList(ByVal dx As luXMLFile)
    Dim dm As SIS.td.DM = SIS.td.DM.DMGetByID(dx.DocumentID, dx.RevNo)
    If dm IsNot Nothing Then
      Dim mdNew As Boolean = False
      Dim md As SIS.td.MasterDocument = SIS.td.MasterDocument.MasterDocumentGetByID(dx.DocumentID, dx.RevNo)
      If md Is Nothing Then
        md = New SIS.td.MasterDocument
        mdNew = True
      End If
      Dim div As String = ""
      Select Case dx.VaultDB
        Case "BOILER"
          div = "EU200"
        Case "SMD"
          div = "EU230"
        Case "EPC"
          div = "EU210"
        Case "PC"
          div = "EU220"
        Case "APC"
          div = "EU240"
      End Select
      With md
        .t_cprj = dm.t_cprj
        .t_docn = dx.DocumentID
        .t_revn = dx.RevNo
        .t_dsca = dm.t_dttl
        .t_cspa = dm.t_cspa
        .t_type = dm.t_type
        .t_eunt = div
        Select Case dm.t_resp.ToLower
          Case "c&i"
            .t_resp = "C&I"
          Case "civil"
            .t_resp = "CVL"
          Case "electrical"
            .t_resp = "ELE"
          Case "mechanical"
            .t_resp = "MEC"
          Case "other"
            .t_resp = "OTR"
          Case "piping"
            .t_resp = "PIP"
          Case "process"
            .t_resp = "PRC"
          Case "smd-mhe"
            .t_resp = "MHE"
          Case "structure"
            .t_resp = "STR"
        End Select
        Select Case dm.t_size
          Case "A0"
            .t_size = 1
          Case "A1"
            .t_size = 2
          Case "A2"
            .t_size = 3
          Case "A3"
            .t_size = 4
          Case "A4"
            .t_size = 5
          Case Else
            .t_size = 1
        End Select
        .t_orgn = IIf(dx.DocumentID.IndexOf("-VEN-") > 0, "VEN", "ISG")
        .t_subm = dm.t_appr
        .t_intr = 1
        .t_prod = dm.t_prod
        .t_erec = dm.t_erec
        .t_info = 1
        .t_vend = IIf(dx.DocumentID.IndexOf("-VEN-") > 0, 1, 2)
        '.t_cler = 1 technically Cleared
        '.t_appr = 2  Once for approval
        Select Case dm.t_wfst
          Case 1, 2, 3, 4
            .t_rele = 2 'No
            .t_bloc = 2 'No
          Case 5
            .t_rele = 1 'Yes
            .t_bloc = 2 'No
          Case 6, 7, 8, 9
            .t_rele = 1 'Yes
            .t_bloc = 1 'Yes
        End Select
        Select Case dm.t_stat
          Case 1
            .t_rele = 2 'No
            .t_bloc = 2 'No
          Case 2, 3
            .t_rele = 1 'Yes
            .t_bloc = 2 'No
          Case 4
            .t_rele = 1 'Yes
            .t_bloc = 1 'Yes
        End Select
        Select Case dx.Action.ToLower
          Case "lock"
          Case "unlock"
          Case "revised"
            .t_bloc = 1
          Case "released"
            .t_rele = 1
            .t_acdt = dm.t_adat
        End Select
        'Originator ID update from Previous Revision if Rev. > 00
        If dx.RevNo > "00" Then
          Dim pRev As String = (Convert.ToInt32(dx.RevNo) - 1).ToString.PadLeft(2, "0")
          Dim tmp_md As SIS.td.MasterDocument = SIS.td.MasterDocument.MasterDocumentGetByID(dx.DocumentID, pRev)
          If tmp_md IsNot Nothing Then
            .t_orgn = tmp_md.t_orgn
            .t_pldt = tmp_md.t_pldt
          End If
        End If
      End With
      If mdNew Then
        SIS.td.MasterDocument.InsertData(md)
      Else
        SIS.td.MasterDocument.UpdateData(md)
      End If

    End If
  End Sub
  'Public Sub InsUpdMasterDocumentList(ByVal fPrj As String, ByVal tPrj As String)
  '  Dim NextI As Integer = 0
  '  Try
  '    NextI = fPrj.Substring(2, 4)
  '  Catch ex As Exception
  '    Exit Sub
  '  End Try
  '  Do While fPrj <= tPrj
  '    Dim oDms As List(Of SIS.td.DM) = SIS.td.DM.DMSelectList(fPrj)
  '    For Each dm As SIS.td.DM In oDms
  '      Dim mdNew As Boolean = False
  '      Dim md As SIS.td.MasterDocument = SIS.td.MasterDocument.MasterDocumentGetByID(dm.t_docn, dm.t_revn)
  '      If md Is Nothing Then
  '        md = New SIS.td.MasterDocument
  '        mdNew = True
  '      End If
  '      With md
  '        .t_cprj = dm.t_cprj
  '        .t_docn = dm.t_docn
  '        .t_revn = dm.t_revn
  '        .t_dsca = dm.t_dttl
  '        .t_cspa = dm.t_cspa
  '        .t_type = dm.t_type
  '        .t_eunt = "EU200"
  '        Select Case dm.t_resp
  '          Case "C&I"
  '            .t_resp = "C&I"
  '          Case "CIVIL"
  '            .t_resp = "CVL"
  '          Case "ELECTRICAL"
  '            .t_resp = "ELE"
  '          Case "MECHANICAL"
  '            .t_resp = "MEC"
  '          Case "OTHER"
  '            .t_resp = "OTR"
  '          Case "PIPING"
  '            .t_resp = "PIP"
  '          Case "Process"
  '            .t_resp = "PRC"
  '          Case "SMD-MHE"
  '            .t_resp = "MHE"
  '          Case "STRUCTURE"
  '            .t_resp = "STR"
  '        End Select
  '        .t_size = dm.t_size
  '        .t_orgn = IIf(dm.t_docn.IndexOf("-VEN-") > 0, "VEN", "ISG")
  '        .t_subm = dm.t_appr
  '        .t_intr = 1
  '        .t_prod = dm.t_prod
  '        .t_erec = dm.t_erec
  '        .t_info = 1
  '        .t_pldt = dm.t_adat
  '        .t_acdt = dm.t_adat
  '        .t_vend = IIf(dm.t_docn.IndexOf("-VEN-") > 0, 1, 2)
  '        .t_cler = 1
  '        .t_appr = 2
  '        Select Case dm.t_wfst
  '          Case 1, 2, 3, 4
  '            .t_rele = 2 'No
  '            .t_bloc = 2 'No
  '          Case 5
  '            .t_rele = 1 'Yes
  '            .t_bloc = 2 'No
  '          Case 6, 7, 8, 9
  '            .t_rele = 1 'Yes
  '            .t_bloc = 1 'Yes
  '        End Select
  '        Select Case dm.t_stat
  '          Case 1
  '            .t_rele = 2 'No
  '            .t_bloc = 2 'No
  '          Case 2, 3
  '            .t_rele = 1 'Yes
  '            .t_bloc = 2 'No
  '          Case 4
  '            .t_rele = 1 'Yes
  '            .t_bloc = 1 'Yes
  '        End Select
  '      End With
  '      If mdNew Then
  '        SIS.td.MasterDocument.InsertData(md)
  '      Else
  '        SIS.td.MasterDocument.UpdateData(md)
  '      End If
  '    Next
  '    NextI += 1
  '    fPrj = fPrj.Substring(0, 2) & Microsoft.VisualBasic.Strings.Right("0000" & NextI, 4)
  '  Loop
  'End Sub
End Class
