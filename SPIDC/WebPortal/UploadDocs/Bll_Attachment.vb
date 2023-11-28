Imports System.IO
Imports Ionic.Zip

Partial Public Class UploadDocs

    Private Sub _mcheckdata()  ' @ Added 20171124
        Try

            Dim _nClass As New cdalpicture
            _nClass._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pUniqueID = cSessionLoader._pControlNo
            ' cPageSession_BPLTASnew._pAccountNo = ""
            _nClass._pSubSelectowner_Temp()
            If _nClass._pDataTable.Rows.Count <> 0 Then
                If IsDBNull(_nClass._pDataTable.Rows(0).Item("O_FileType")) Then

                Else
                    _oHyperLinkowner.Visible = True
                    _oHyperLinkowner.Enabled = True
                    _oHyperLinkowner.NavigateUrl = "ViewImage/ViewImage.aspx?Id=" + cSessionLoader._pControlNo + "&Switch=A" + "&Settings=8"
                    '   _oLinkButtonOwner.Visible = True
                End If
            Else
                _oHyperLinkowner.Visible = False
                ' _oLinkButtonOwner.Visible = False
            End If

            _nClass._pSubSelectestab_Temp()
            If _nClass._pDataTable.Rows.Count <> 0 Then
                If IsDBNull(_nClass._pDataTable.Rows(0).Item("E_FileType")) Then

                Else
                    _oHyperLinkestablishment.Visible = True
                    _oHyperLinkestablishment.Enabled = True
                    _oHyperLinkestablishment.NavigateUrl = "ViewImage/ViewImage.aspx?Id=" + cSessionLoader._pControlNo + "&Switch=A" + "&Settings=9"
                    '  _oLinkButtonEstablishment.Visible = True
                End If
            Else
                _oHyperLinkestablishment.Visible = False
                ' _oLinkButtonEstablishment.Visible = False
            End If

            _nClass._pSubSelectmap_Temp()
            If _nClass._pDataTable.Rows.Count <> 0 Then
                If IsDBNull(_nClass._pDataTable.Rows(0).Item("M_FileType")) Then

                Else
                    _oHyperLinkmaplocation.Visible = True
                    _oHyperLinkmaplocation.Enabled = True
                    _oHyperLinkmaplocation.NavigateUrl = "ViewImage/ViewImage.aspx?Id=" + cSessionLoader._pControlNo + "&Switch=A" + "&Settings=10"
                    ' _oLinkButtonMapLocation.Visible = True
                End If
            Else
                _oHyperLinkmaplocation.Visible = False
                ' _oLinkButtonMapLocation.Visible = False
            End If


        Catch ex As Exception
            snackbar("red", "Error Occured: " & ex.Message)
        End Try

       
    End Sub

    Protected Sub _oButtonSaveImg_Click(sender As Object, e As EventArgs) Handles _oButtonUploadAttachment.Click
        Try

         
            _UploadAttachment()

        Catch ex As Exception
            'snackbar("red", "Error Occured: " & ex.Message)
        End Try

    End Sub

    Private Sub _UploadAttachment()
        Try
            Dim _nSuccessful As Boolean
            Dim _nErrMsg As String = ""
            ' cSessionLoader._pControlNo = _FnAutoGenID("ControlNo")
            If _FnCheckifExistTempImageAttachment(_nSuccessful, _nErrMsg) = False Then
                _mSaveImageAttachment(_nSuccessful, _nErrMsg)
            End If
            _SaveFileImage(cSessionLoader._pAccountNo, _oFileUploadOwnerPic, "O")
            _SaveFileImage(cSessionLoader._pAccountNo, _oFileUploadEstablishment, "E")
            _SaveFileImage(cSessionLoader._pAccountNo, _oFileUploadMapLoc, "M")


            If _oFileUploadOwnerPic.HasFile = True Then _oFileUploadOwnerPic.Style.Add("color", "transparent")
            If _oFileUploadEstablishment.HasFile = True Then _oFileUploadEstablishment.Style.Add("color", "transparent")
            If _oFileUploadMapLoc.HasFile = True Then _oFileUploadMapLoc.Style.Add("color", "transparent")

            _mcheckdata()
            '  _CheckCompliance()

        Catch ex As Exception
            snackbar("red", "Error Occured: " & ex.Message)
        End Try
    End Sub


    Public Function _FnCheckifExistTempImageAttachment(ByRef _nSuccessful As Boolean, Optional ByRef _nErrMsg As String = "") As Boolean
        Try
            Dim _nClass As New cDal_IUD
            Dim _nAcctno As String = cSessionLoader._pAccountNo

            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "SELECT * FROM [BPLTAS_PICTURES_Temp] Where ID = ''" & cSessionLoader._pControlNo & "''"

                ._pExec(_nSuccessful, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            End With

        Catch ex As Exception
            snackbar("red", "Error Occured: " & ex.Message)
        End Try

    End Function

    Public Sub _mSaveImageAttachment(ByRef _nSuccessful As Boolean, Optional ByRef _nErrMsg As String = "")
        Try
            Dim _nClass As New cDal_IUD
            Dim _nAcctno As String = cSessionLoader._pAccountNo

            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "INSERT"
                ._pSelect = "INSERT INTO " & _
                              "[BPLTAS_PICTURES_Temp] " & _
                              " (id,FORYEAR,XDEFAULT) " & _
                              " VALUES " & _
                              " (''" & cSessionLoader._pControlNo & "'', CONVERT(DATE, GETDATE()),''1'') "

                ._pExec(_nSuccessful, _nErrMsg)

            End With

        Catch ex As Exception
            snackbar("red", "Error Occured: " & ex.Message)
        End Try
      
    End Sub
    Public Sub _SaveFileImage(_nAccountNo As String, _oImgFile As FileUpload, _nImageKind As String)
        Try
            Dim iMinAircraftImgWidth As Integer = 10000
            Dim iMinAircraftImgHeight As Integer = 10000
            Dim MaxFileSize As Integer = 10485760 ' < Maximum File Size is 10 MB

            If _oImgFile.HasFile = True Then

                Dim postedFile As HttpPostedFile = _oImgFile.PostedFile
                Dim fileName As String = _nAccountNo + _nImageKind + "_" + Path.GetFileName(postedFile.FileName)
                Dim fileExtension As String = Path.GetExtension(fileName)
                Dim fileSize As Integer = postedFile.ContentLength
                Dim strNewFileName As String = "Px" + fileName

                If fileExtension.ToLower() = ".jpg" Or fileExtension.ToLower() = ".jpeg" Or fileExtension.ToLower() = ".png" Or fileExtension.ToLower() = ".gif" Or fileExtension.ToLower() = ".bmp" Or fileExtension.ToLower() = ".zip" Or fileExtension.ToLower = ".rar" Or fileExtension.ToLower = ".pdf" Then

                    If fileSize > MaxFileSize Then

                        snackbar("red", "File exceeds the maximum limit of 10 MB. <br> Filename: " & fileName)
                        Exit Sub
                        '_oPanelErrMsgOwner.Visible = True
                        '_oLabelErrMsgOwner.Text = "Cannot upload image, file exceeds the maximum limit of 10 MB."
                        '_oLabelErrMsgOwner.ForeColor = Drawing.Color.Red

                    Else

                        Dim _nType As String = Nothing
                        Select Case _nImageKind
                            Case "O"
                                _nType = "OWNER"
                            Case "E"
                                _nType = "ESTABLISHMENT"
                            Case "M"
                                _nType = "MAP"
                        End Select

                        'AutoCreate Temporary folder for collection of image file
                        Dim _nPath As String = Path.Combine(Server.MapPath("~/Temp/"), cSessionLoader._pControlNo & "\" & _nType)

                        'Create Temporary folder if not exist
                        If Directory.Exists(_nPath) Then

                        Else
                            Directory.CreateDirectory(_nPath)
                        End If

                        Dim _nFileCOunt As Integer = 0
                        'SaveControlState multiple select images to temporary folder
                        For Each uploadedFile As HttpPostedFile In _oImgFile.PostedFiles
                            Dim _nfileName As String = Path.GetFileName(uploadedFile.FileName)
                            uploadedFile.SaveAs(_nPath & "/" & _nfileName)
                            _nFileCOunt = _nFileCOunt + 1
                        Next

                        If _nFileCOunt > 1 Then
                            'Zip file collection
                            Dim zip As New ZipFile
                            zip.AddDirectory(_nPath)
                            zip.Save(_nPath & ".zip")

                            Dim _nZipFileName As String = cSessionLoader._pControlNo & "_" & _nType

                            _mSubSaveZippedImage(_nZipFileName, _nImageKind, _oImgFile, _nAccountNo, _nPath)
                            FileIO.FileSystem.DeleteDirectory(HttpContext.Current.Server.MapPath("~/Temp/" & cSessionLoader._pControlNo), FileIO.DeleteDirectoryOption.DeleteAllContents) ' Delete Temporary Folder
                            Exit Sub

                        End If


                        If Directory.Exists(_nPath) Then
                            FileIO.FileSystem.DeleteDirectory(HttpContext.Current.Server.MapPath("~/Temp/" & cSessionLoader._pControlNo), FileIO.DeleteDirectoryOption.DeleteAllContents) ' Delete Temporary Folder
                        End If

                        If fileSize > (MaxFileSize / 2) And (fileExtension.ToLower() <> ".zip" And fileExtension.ToLower <> ".rar") Then

                            _oImgFile.SaveAs(Server.MapPath("~/" & Path.GetFileName(fileName))) '< Save Image to Temporary folder

                            ResizeImage(fileName, "imagepath", "imagepath", iMinAircraftImgWidth, iMinAircraftImgHeight, strNewFileName) ' < Initialize Resize Image
                            _mSubSaveResizedImage(fileName, _nImageKind, _oImgFile, _nAccountNo)

                            File.Delete(HttpContext.Current.Server.MapPath("~/images/" & fileName)) '< Drop Image from Temporary Folder
                            File.Delete(HttpContext.Current.Server.MapPath("~/" & fileName))

                        Else
                            _mSubSaveImages(fileName, _nImageKind, _oImgFile, _nAccountNo)
                            Exit Sub
                        End If

                        '_oPanelErrMsgOwner.Visible = False

                    End If

                Else
                    snackbar("red", "Invalid file format! <br> Filename: " & fileName)
                    Exit Sub
                    '_oLabelErrMsgOwner.Text = "Invalid File Format!"
                    '_oLabelErrMsgOwner.ForeColor = Drawing.Color.Red

                End If

            End If

        Catch ex As Exception
            snackbar("red", "Error Occured: " & ex.Message)
        End Try


    End Sub
    Private Sub _mSubSaveImages(ByVal FileName As String, ByVal ImageKind As String, xFile As FileUpload, ByVal _nAcctNo As String)
        Try
            Dim _nClass As New cdalpicture
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pUniqueID = cSessionLoader._pControlNo

                ._pFileExtn = System.IO.Path.GetExtension(xFile.PostedFile.FileName)
                ._ppicdata = xFile.FileBytes
                ._pFileName = FileName

                Select Case ImageKind

                    Case "O"
                        ._pSubUpdateImageowner_Temp()

                    Case "E"
                        ._pSubUpdateImageestab_Temp()

                    Case "M"
                        ._pSubUpdateImagemap_Temp()

                End Select

            End With

        Catch ex As Exception
            snackbar("red", "Error Occured: " & ex.Message)
        End Try


    End Sub

    Private Sub _mSubSaveZippedImage(ByVal FileName As String, ByVal ImageKind As String, xFile As FileUpload, ByVal _nAcctNo As String, ByVal _nPath As String)
        Try
            Dim _nClass As New cdalpicture
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS

                ._pUniqueID = cSessionLoader._pControlNo
                ._pFileExtn = ".zip"
                ._ppicdata = System.IO.File.ReadAllBytes(_nPath & ".zip")
                ._pFileName = FileName

                Select Case ImageKind


                    Case "O"
                        ._pSubUpdateImageowner_Temp()

                    Case "E"
                        ._pSubUpdateImageestab_Temp()

                    Case "M"
                        ._pSubUpdateImagemap_Temp()

                End Select



            End With
        Catch ex As Exception
            snackbar("red", "Error Occured: " & ex.Message)
        End Try

    End Sub

    Private Sub _mSubSaveResizedImage(ByVal FileName As String, ByVal ImageKind As String, xFile As FileUpload, ByVal _nAcctNo As String)
        Try
            Dim _nClass As New cdalpicture
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pACCTNO = _nAcctNo


                ._pFileExtn = System.IO.Path.GetExtension(xFile.PostedFile.FileName)
                ._ppicdata = System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/images/" & FileName))
                ._pFileName = FileName

                Select Case ImageKind

                    Case "O"
                        ._pSubUpdateImageowner()

                    Case "E"
                        ._pSubUpdateImageestab()

                    Case "M"
                        ._pSubUpdateImagemap()

                End Select



            End With
        Catch ex As Exception
            snackbar("red", "Error Occured: " & ex.Message)
        End Try

    End Sub

End Class
