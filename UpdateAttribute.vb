  'Public Shared Sub UpdateAttribute(ByVal epFL As dataXML, ByVal useDirect As Boolean)
  '  If useDirect Then
  '    UpdateAttributeDirect(epFL)
  '    Exit Sub
  '  End If
  '  If VaultUtil.Login(epFL.VaultDBName) Then
  '    Dim file As Autodesk.Connectivity.WebServices.File = Nothing
  '    Try
  '      file = VaultUtil.SearchFileByName(epFL.filename, 3L)
  '      file = ServiceManager.GetDocumentService().GetLatestFileByMasterId(file.MasterId)
  '    Catch ex As Exception
  '      file = Nothing
  '    End Try
  '    If file IsNot Nothing Then
  '      If file.CheckedOut Then
  '      Else
  '        Dim Old_LifeCyleID As String = ""
  '        Dim Old_StateID As String = ""
  '        Dim StateChanged As Boolean = False
  '        Dim WIP As Boolean = False
  '        If Not file.FileLfCyc.LfCycStateName.ToLower = "work in progress" Then
  '          Old_LifeCyleID = file.FileLfCyc.LfCycDefId
  '          Old_StateID = file.FileLfCyc.LfCycStateId
  '          Dim wipID As String = VaultUtil.GetLifeCycleStateId(Old_LifeCyleID, "Work In Progress")
  '          Try
  '            VaultUtil.UpdateFileLifecycle(file.MasterId, wipID, "State changed to update attributes.")
  '            StateChanged = True
  '            WIP = True
  '          Catch ex As Exception
  '          End Try
  '        Else
  '          WIP = True
  '        End If
  '        If WIP Then
  '          Try
  '            Try
  '              VaultUtil.CheckOutAndDownloadFile(file.Id, "c:\temp\test2")
  '            Catch ex As Exception
  '            End Try
  '            Threading.Thread.Sleep(1000)
  '            Try
  '              file = VaultUtil.GetLatestFileByID(file.Id)
  '            Catch ex As Exception
  '            End Try
  '            Threading.Thread.Sleep(1000)
  '            Try
  '              VaultUtil.UpdateFileProperty(file.MasterId, "Comments", Now.ToString)
  '              VaultUtil.UpdateFileProperty(file.MasterId, "ISGEC_PROJECTID", epFL.contract)
  '              VaultUtil.UpdateFileProperty(file.MasterId, "ISGEC_DRAWINGTITLE", epFL.title)
  '              VaultUtil.UpdateFileProperty(file.MasterId, "ISGEC_DATASOURCE", epFL.ISGEC_Datasource)
  '              VaultUtil.UpdateFileProperty(file.MasterId, "ISGEC_DOCUMENTID_DRGID", epFL.drgid)
  '              VaultUtil.UpdateFileProperty(file.MasterId, "ISGEC_DOCUMENTID_NUMBER", epFL.number)
  '              VaultUtil.UpdateFileProperty(file.MasterId, "ISGEC_LATESTREVISION", epFL.rev)
  '              VaultUtil.UpdateFileProperty(file.MasterId, "ISGEC_DRAWNBY", epFL.drawn)
  '              VaultUtil.UpdateFileProperty(file.MasterId, "ISGEC_CHECKEDBY", epFL.chqd)
  '              VaultUtil.UpdateFileProperty(file.MasterId, "ISGEC_APPROVEDBY", epFL.appd)
  '              VaultUtil.UpdateFileProperty(file.MasterId, "ISGEC_DATE", epFL.ddate)
  '              VaultUtil.UpdateFileProperty(file.MasterId, "ISGEC_FORINFORMATION", epFL.inf)
  '              VaultUtil.UpdateFileProperty(file.MasterId, "ISGEC_FORAPPROVAL", epFL.apr)
  '              VaultUtil.UpdateFileProperty(file.MasterId, "ISGEC_FORPRODUCTION", epFL.pro)
  '              VaultUtil.UpdateFileProperty(file.MasterId, "ISGEC_FORERECTION", epFL.ere)
  '              VaultUtil.UpdateFileProperty(file.MasterId, "ISGEC_TOTALWEIGHTINKG", epFL.weight)
  '              VaultUtil.UpdateFileProperty(file.MasterId, "ISGEC_SHEETSIZE", epFL.sheetsize)
  '              VaultUtil.UpdateFileProperty(file.MasterId, "ISGEC_ELEMENTID", epFL.ElId)
  '              VaultUtil.UpdateFileProperty(file.MasterId, "ISGEC_SERVICE1", epFL.service1)
  '              VaultUtil.UpdateFileProperty(file.MasterId, "ISGEC_SERVICE2", epFL.service2)
  '              VaultUtil.UpdateFileProperty(file.MasterId, "ISGEC_IWT", epFL.iwt)
  '              VaultUtil.UpdateFileProperty(file.MasterId, "ISGEC_YEAR", epFL.year)
  '              VaultUtil.UpdateFileProperty(file.MasterId, "ISGEC_CONSULTANT", epFL.consultant)
  '              VaultUtil.UpdateFileProperty(file.MasterId, "ISGEC_CLIENT", epFL.client)
  '              VaultUtil.UpdateFileProperty(file.MasterId, "ISGEC_GROUPNAME", epFL.group)
  '              VaultUtil.UpdateFileProperty(file.MasterId, "ISGEC_SCALE", epFL.scale)
  '              VaultUtil.UpdateFileProperty(file.MasterId, "ISGEC_RESPONSIBLEDEPT", epFL.resp_dept)
  '            Catch ex As Exception
  '            End Try
  '            Threading.Thread.Sleep(1000)
  '            Try
  '              file = VaultUtil.CheckInFile(file)
  '            Catch ex As Exception
  '              If (file.CheckedOut) Then
  '                Try
  '                  VaultUtil.UndoCheckOut(file.MasterId)
  '                Catch ex1 As Exception
  '                End Try
  '              End If
  '            End Try
  '          Catch ex As Exception
  '          End Try
  '        End If 'WIP
  '        If StateChanged Then
  '          VaultUtil.UpdateFileLifecycle(file.MasterId, Old_StateID, "State reverted after attribute update.")
  '        End If
  '      End If 'Main file checkedout
  '    End If
  '    VaultUtil.LogOut()
  '  End If
  'End Sub
