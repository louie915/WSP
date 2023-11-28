Imports System.IO
Imports System.Web.Services
Imports System.Data.SqlClient
Imports System.Web.UI
Imports Ionic.Zip

Partial Public Class UploadDocs

    'Protected Sub _oButton_Click(sender As Object, e As EventArgs) Handles _
    '  _oButtonUploadImages.Click
    '    Try

    '        ' === SAVE IMAGE REQUIREMENTS ===============================================================================================
    '        _UploadRequirements(sender, e)

    '        _CheckCompliance()
    '        '============================================================================================================================

    '    Catch ex As Exception
    '        snackbar("red", "Error Occured: " & ex.Message)
    '    End Try

    'End Sub

    Private Sub _BindGridview(_nGridview As GridView, _nDataTable As DataTable)
        Try

            If _nDataTable.HasErrors Then
                'Griderr = True
                '_mSubShowBlank()
            End If

            If _nDataTable.Rows.Count > 0 Then
                _nGridview.DataSource = _nDataTable
                _nGridview.DataBind()

            Else
                snackbar("red", "No Records Found.")

            End If
        Catch ex As Exception
            snackbar("red", ex.Message)
        End Try


    End Sub
    Protected Sub _BindRequirements(_nGridview As GridView)
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing


            'BPLTAS
            Dim _nBPLTAS As New cDalGlobalConnectionsDefault
            _nBPLTAS._pCxn = cGlobalConnections._pSqlCxn_CR
            _nBPLTAS._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nBPLTAS._pSubRecordSelectSpecific()

            Dim _nLiveSvr As String = _nBPLTAS._pDBDataSource
            Dim _nLiveDB As String = _nBPLTAS._pDBInitialCatalog

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "SELECT  [REQCODE],[REQDESC],[COMPLIANT],ISNULL([SWITCH],''NEW'') as SWITCH,[OFFICE],[XSEQ],[XDEFAULT]" & _
                            ",isnull((SELECT COUNT(*) FROM [BP_SubmittedReq] B  "

                ._pCondition = " WHERE B.ReqCode COLLATE DATABASE_DEFAULT = R.REQCODE  COLLATE DATABASE_DEFAULT and B.Foryear  = " & _
                            " (SELECT YEAR(GETDATE()) as FORYEAR)  and B.Accountno COLLATE DATABASE_DEFAULT =  ''" & cSessionLoader._pAccountNo & "''  COLLATE DATABASE_DEFAULT  ),0) as ImageCount " & _
                            " FROM [" & _nLiveSvr & "].[" & _nLiveDB & "].dbo.[REQ1] as R " & _
                            " WHERE ISNULL([SWITCH],''NEW'') = ''NEW'' " & _
                            " AND REQCODE NOT IN ( " & _
                            " Select REQCODE " & _
                            " from [" & _nLiveSvr & "].[" & _nLiveDB & "].dbo.REQ1EXTN where ISNULL([SWITCH],''NEW'') = ''NEW'' " & _
                            " AND OWNCODE COLLATE DATABASE_DEFAULT  <> (Select OWNCODE From dbo.BUSMAST WHERE ACCTNO = ''" & cSessionLoader._pAccountNo & "'')) "
                ._pExec(_nSuccess, _nErrMsg)

                _BindGridview(_nGridview, ._pDataTable)

            End With


        Catch ex As Exception
            snackbar("red", "Error Occured: " & ex.Message)
        End Try
    End Sub
    Sub snackbar(Color As String, Caption As String)
        If Color = "red" Then
            _oLabelSnackbar.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "Snackbar();", True)

        ElseIf Color = "green" Then
            _oLabelSnackbargreen.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "SnackbarGreen();", True)
        End If
    End Sub
    Protected Sub _UploadRequirements(ByVal sender As Object, e As EventArgs)

        Try

            'Dim index As Integer = Integer.Parse((CType(sender, Button)).CommandArgument)
            'Dim file As FileUpload = CType(_oGridViewRequirementsList.Rows(index).FindControl("_oFileUploadRequirements"), FileUpload)

            Dim FileCtr As Integer = 0
            For Each row As GridViewRow In _oGridViewRequirementsList.Rows
                Dim file As FileUpload = CType(row.FindControl("_oFileUploadRequirements"), FileUpload)


                If file.HasFile Then
                    FileCtr = FileCtr + 1
                    Dim _nAccountNo As String = cSessionLoader._pControlNo
                    Dim _nUniqueID As String = cSessionLoader._pUniqueID
                    Dim _nImageID As String = Nothing
                    'Dim _nCode = TryCast(TryCast(sender, LinkButton).NamingContainer, GridViewRow).Cells(0).Text ' DirectCast(row.FindControl("_oLabelListReqCode"), Label).Text
                    Dim nDescription = DirectCast(row.FindControl("_oLabelListDescription"), Label).Text
                    Dim _nReqCode As String = DirectCast(row.FindControl("_oLabelListReqCode"), Label).Text
                    Dim _nFilename = Path.GetFileName(file.FileName)
                    Dim _nFileExtension As String = Path.GetExtension(_nFilename)

                    Dim _nPostedFile As HttpPostedFile = file.PostedFile
                    Dim _nFileSize As Integer = _nPostedFile.ContentLength
                    Dim _nMaxFileSize As Integer = 10485760 ' < Maximum File Size is 10 MB
                    Dim br As New BinaryReader(_nPostedFile.InputStream)
                    Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(_nPostedFile.InputStream.Length))

                    Dim _nForYear As Integer = Year(Now)

                    Dim Remarks As String = Nothing
                    Dim ToFollow As Boolean = True

                    Dim iMinAircraftImgWidth As Integer = 10000
                    Dim iMinAircraftImgHeight As Integer = 10000
                    Dim strNewFileName As String = "Px" + _nFilename

                    Dim _nValidateMsg As String = Nothing
                    If _ValidateImage(_nFilename, _nFileExtension, _nAccountNo, _nUniqueID, _nReqCode, _nForYear, _nFileSize, _nMaxFileSize, _nValidateMsg) = True Then

                        'AutoCreate Temporary folder for collection of image file
                        Dim _nPath As String = Path.Combine(Server.MapPath("~/Temp/"), cSessionLoader._pControlNo & "\" & nDescription)

                        'Create Temporary folder if not exist
                        If Directory.Exists(_nPath) Then

                        Else
                            Directory.CreateDirectory(_nPath)
                        End If

                        Dim _nFileCount As Integer = 0
                        'SaveControlState multiple select images to temporary folder
                        For Each uploadedFile As HttpPostedFile In file.PostedFiles
                            Dim _nfileName2 As String = Path.GetFileName(uploadedFile.FileName)
                            uploadedFile.SaveAs(_nPath & "/" & _nfileName2)
                            _nFileCount = _nFileCount + 1
                        Next

                        If _nFileCount > 1 Then
                            'Zip file collection
                            Dim zip As New ZipFile
                            zip.AddDirectory(_nPath)
                            zip.Save(_nPath & ".zip")

                            Dim _nZipFileName As String = cSessionLoader._pControlNo & "_" & nDescription
                            _SaveZipppedImageRequirements_Temp(_nAccountNo, _nForYear, _nReqCode, _nZipFileName, _nFileSize, bytes, _nFileExtension, Nothing, _nPath)
                            _nImageID = _FnGetImageID(_nAccountNo, _nForYear, _nReqCode)
                            DirectCast(row.FindControl("_oHyperLinkViewImages"), HyperLink).Enabled = True
                            DirectCast(row.FindControl("_oHyperLinkViewImages"), HyperLink).NavigateUrl = "viewimage/ViewImage.aspx?Id=" + _nImageID + "&Switch=B"
                            DirectCast(row.FindControl("_oHyperLinkViewImages"), HyperLink).Visible = True
                            FileIO.FileSystem.DeleteDirectory(HttpContext.Current.Server.MapPath("~/Temp/" & cSessionLoader._pControlNo), FileIO.DeleteDirectoryOption.DeleteAllContents) ' Delete Temporary Folder

                            _BindRequirements(_oGridViewRequirementsList)
                            '  OnRowDataBound(sender)
                            snackbar("green", "Files Successfully uploaded!")

                            Exit Sub

                        End If

                        If Directory.Exists(_nPath) Then
                            FileIO.FileSystem.DeleteDirectory(HttpContext.Current.Server.MapPath("~/Temp/" & cSessionLoader._pControlNo), FileIO.DeleteDirectoryOption.DeleteAllContents) ' Delete Temporary Folder
                        End If

                        If _nFileSize > (_nMaxFileSize / 2) And (_nFileExtension.ToLower <> ".rar" And _nFileExtension.ToLower <> ".zip") Then
                            _ResizeAndSaveImage(file, _nFilename, _nFileExtension, _nFileSize, iMinAircraftImgWidth, iMinAircraftImgHeight, strNewFileName, _nAccountNo, _nUniqueID, _nReqCode, _nForYear)

                        End If

                        _DeleteExistingImage(_nAccountNo, _nForYear, _nReqCode)


                        _SaveImageRequirements_Temp(_nAccountNo, _nForYear, _nReqCode, _nFilename, _nFileSize, bytes, _nFileExtension, _nImageID)
                        _nImageID = _FnGetImageID(_nAccountNo, _nForYear, _nReqCode)

                        DirectCast(row.FindControl("_oHyperLinkViewImages"), HyperLink).Enabled = True
                        DirectCast(row.FindControl("_oHyperLinkViewImages"), HyperLink).NavigateUrl = "viewimage/ViewImage.aspx?Id=" + _nImageID + "&Switch=B"
                        DirectCast(row.FindControl("_oHyperLinkViewImages"), HyperLink).Visible = True




                    Else
                        'SNACK BAR RED - Invalid Messege
                        snackbar("red", _nValidateMsg + "<br>" + "Filename: " + _nFilename)
                        Exit Sub
                    End If

                End If


            Next
            If FileCtr = 0 Then
                '  snackbar("red", "No file was uploaded!")
                Exit Sub
            End If

            _BindRequirements(_oGridViewRequirementsList)
            '  OnRowDataBound(sender)
            snackbar("green", "Files Successfully uploaded!")

        Catch ex As Exception
            snackbar("red", ex.Message)
        End Try
        'Dim _nBtn As Button = TryCast(sender, Button)
        'Dim _nGridRow As GridViewRow = CType(_nBtn.NamingContainer, GridViewRow)

        'Dim _nFileName = DirectCast(_nGridRow.FindControl("_oFileUploadRequirements"), FileUpload).FileName

    End Sub
    Public Sub _DeleteExistingImage(_nAcctNo As String, _nForYear As String, _nReqCode As String)
        Try
            Dim _nSuccessful As Boolean, _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "DELETE"
                ._pSelect = "DELETE FROM BP_SubmittedReq_Temp "
                ._pCondition = "WHERE UniqueID = ''" & _nAcctNo & "'' " & _
                                "AND ForYear = ''" & _nForYear & "'' " & _
                                "AND ReqCode = ''" & _nReqCode & "'' "
                ._pExec(_nSuccessful, _nErrMsg)

            End With
        Catch ex As Exception
            snackbar("red", ex.Message)
        End Try
    End Sub


    Public Sub _ResizeAndSaveImage(_nFile As FileUpload _
                            , _nFileName As String _
                            , _nFileExtension As String _
                            , _nFileSize As Integer _
                            , iMinAircraftImgWidth As Integer _
                            , iMinAircraftImgHeight As Integer _
                            , strNewFileName As String _
                             , _nAccountNo As String _
                             , _nUniqueID As String _
                              , _nReqCode As String _
                                , _nForYear As String
                            )
        _nFile.SaveAs(Server.MapPath("~/" & Path.GetFileName(_nFileName)))
        ResizeImage(_nFileName, "imagepath", "imagepath", iMinAircraftImgWidth, iMinAircraftImgHeight, strNewFileName)

        _nFileExtension = System.IO.Path.GetExtension(_nFile.PostedFile.FileName)
        Dim stream As Stream = _nFile.PostedFile.InputStream
        Dim BinaryReader As New BinaryReader(stream)
        Dim bytes As Byte() = BinaryReader.ReadBytes(CInt(stream.Length))
        bytes = System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/images/" & _nFileName))

        Dim _nImageID As String = Nothing
        _SaveImageRequirements_Temp(_nUniqueID, _nReqCode, _nForYear, _nFileName, _nFileSize, bytes, _nFileExtension, _nImageID)
        cSessionLoader._pImageID = _nImageID
    End Sub
    Public Shared Sub ResizeImage(ByVal image As String, ByVal Okey As String, ByVal key As String, ByVal width As Integer, ByVal height As Integer, ByVal newimagename As String)

        Try

            Dim oImg As System.Drawing.Image = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath("~/" & ConfigurationManager.AppSettings(Okey) & image))
            Dim oThumbNail As System.Drawing.Image = New System.Drawing.Bitmap(width, height)
            Dim oGraphic As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(oThumbNail)
            oGraphic.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality
            oGraphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
            oGraphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
            oGraphic.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality
            Dim oRectangle As System.Drawing.Rectangle = New System.Drawing.Rectangle(0, 0, width, height)
            oGraphic.DrawImage(oImg, oRectangle)

            If image.Substring(newimagename.LastIndexOf(".")) <> ".png" Then
                oThumbNail.Save(HttpContext.Current.Server.MapPath("~/images/" & ConfigurationManager.AppSettings(Okey) & image), System.Drawing.Imaging.ImageFormat.Jpeg)
            Else : oThumbNail.Save(HttpContext.Current.Server.MapPath("~/images/" & ConfigurationManager.AppSettings(Okey) & image), System.Drawing.Imaging.ImageFormat.Png)
            End If

            oImg.Dispose()

        Catch ex As Exception

        End Try
    End Sub
    Public Function _ValidateImage(
                             _nFilename As String _
                               , _nFileExtension As String _
                                   , _nAccountNo As String _
                                       , _nUniqueID As String _
                                           , _nReqCode As String _
                                               , _nForYear As String _
                                                   , _nFileSize As Integer _
                                                       , _nMaxFileSize As Integer _
                                                           , ByRef _nMsg As String
                            ) As Boolean

        Try


            _ValidateImage = True

            Select Case True

                Case _nFilename = ""
                    _nMsg = "No file selected!"
                    Return False
                Case _nFileExtension.ToLower <> ".jpg" And _nFileExtension.ToLower() <> ".jpeg" And _nFileExtension.ToLower() <> ".gif" And _nFileExtension.ToLower() <> ".png" And _nFileExtension.ToLower() <> ".pdf" And _nFileExtension.ToLower() <> ".bmp" And _nFileExtension.ToLower() <> ".rar" And _nFileExtension.ToLower() <> ".zip"
                    _nMsg = "Invalid File Format!"
                    Return False
                    'Case CheckIfFileExist(_nAccountNo, _nReqCode, _nForYear, _nFilename) 'Check If Exist in Table (BP_SubmittedReq)
                    '    _nMsg = "Cannot upload same image file within the same requirement!"
                    '    Return False

                Case _nFileSize > _nMaxFileSize
                    _nMsg = "Cannot upload image, file exceeds the maximum size of 10 MB!"
                    Return False
                Case Else
                    Return True

            End Select


        Catch ex As Exception
            snackbar("red", ex.Message)
        End Try
    
    End Function
    Private Function CheckIfFileExist(xAcctNo As String, xReqCode As String, xYear As String, xFileName As String) As Boolean
        Try
            CheckIfFileExist = False

            Dim _nClass As New cDalRequirements
            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAccount = xAcctNo
                ._pReqCode = xReqCode
                ._pReqYear = xYear
                ._pReqFileName = xFileName

                ._pSubSelectSpecificFilename()

                Dim _nDataTable As New DataTable
                _nDataTable = _nClass._pDataTable

                If _nDataTable.Rows.Count <> 0 Then
                    Return True
                Else
                    Return False
                End If

            End With
        Catch ex As Exception
            CheckIfFileExist = False
            snackbar("red", ex.Message)
        End Try

    End Function
    Private Function _FnGetImageID(_nAccountNo As String, _nFoYear As String, _nReCode As String)
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "SELECT ImagesId FROM BP_SubmittedReq_Temp "
                ._pCondition = " Where UniqueID = ''" & _nAccountNo & "'' " & _
                                " AND ReqCode = ''" & _nReCode & "'' " & _
                                " AND ForYear = ''" & _nFoYear & "''"
                ._pExec(_nSuccess, _nErrMsg)

                Dim _nDatatable As New DataTable
                _nDatatable = ._pDataTable

                If _nDatatable.Rows.Count > 0 Then
                    _FnGetImageID = _nDatatable.Rows(0).Item("ImagesId")
                End If

            End With
        Catch ex As Exception
            snackbar("red", ex.Message)
        End Try
    End Function
    Public Sub _SaveImageRequirements_Temp(ByVal _nUniqueID As String, ByVal ForYear As String, ByVal ReqCode As String, ByVal FileName As String, ByVal FileSize As Integer, ByVal Bytes As Byte(), ByVal FileExtension As String, ByRef _nImageID As String)
        Try

            'Using con As New SqlConnection(cGlobalConnections._pSqlCxn_BPLTIMS.ToString)
            Dim cmd As New SqlCommand("spUploadImageReqImages_Temp", cGlobalConnections._pSqlCxn_BPLTIMS)
            cmd.CommandType = CommandType.StoredProcedure

            Dim paramUniqueID As New SqlParameter("@UniqueID", SqlDbType.NVarChar)
            paramUniqueID.Value = _nUniqueID
            cmd.Parameters.Add(paramUniqueID)

            Dim paramForYear As New SqlParameter("@ForYear", SqlDbType.Int)
            paramForYear.Value = ForYear
            cmd.Parameters.Add(paramForYear)

            Dim paramReqCode As New SqlParameter("@ReqCode", SqlDbType.NVarChar)
            paramReqCode.Value = ReqCode
            cmd.Parameters.Add(paramReqCode)

            Dim paramRemarks As New SqlParameter("@Remarks", SqlDbType.NVarChar)
            paramRemarks.Value = " "
            cmd.Parameters.Add(paramRemarks)

            Dim paramToFollow As New SqlParameter("@ToFollow", SqlDbType.Bit)
            paramToFollow.Value = 1
            cmd.Parameters.Add(paramToFollow)

            '/////// For Image Data
            Dim paramName As New SqlParameter("@Name", SqlDbType.VarChar)
            paramName.Value = FileName
            cmd.Parameters.Add(paramName)

            Dim paramSize As New SqlParameter("@Size", SqlDbType.Int)
            paramSize.Value = FileSize
            cmd.Parameters.Add(paramSize)

            Dim paramImageData As New SqlParameter("@ImageData", SqlDbType.VarBinary)
            paramImageData.Value = Bytes
            cmd.Parameters.Add(paramImageData)

            Dim paramFileExtn As New SqlParameter("@FileExtn", SqlDbType.NVarChar)
            paramFileExtn.Value = FileExtension
            cmd.Parameters.Add(paramFileExtn)

            Dim paramNewId As New SqlParameter("@ImagesID", SqlDbType.Int)
            paramNewId.Value = -1 '_FnAutoGenID("ReqImageID")
            _nImageID = paramNewId.Value
            cmd.Parameters.Add(paramNewId)

            'cmd.Open()
            cmd.ExecuteNonQuery()
            cmd.Dispose()

        Catch ex As Exception
            snackbar("red", ex.Message)
        End Try

    End Sub

    Public Sub _SaveZipppedImageRequirements_Temp(ByVal _nUniqueID As String, ByVal ForYear As String, ByVal ReqCode As String, ByVal FileName As String, ByVal FileSize As Integer, ByVal Bytes As Byte(), ByVal FileExtension As String, ByRef _nImageID As String, ByVal _nPath As String)
        Try

            'Using con As New SqlConnection(cGlobalConnections._pSqlCxn_BPLTIMS.ToString)
            Dim cmd As New SqlCommand("spUploadImageReqImages_Temp", cGlobalConnections._pSqlCxn_BPLTIMS)
            cmd.CommandType = CommandType.StoredProcedure

            Dim paramUniqueID As New SqlParameter("@UniqueID", SqlDbType.NVarChar)
            paramUniqueID.Value = _nUniqueID
            cmd.Parameters.Add(paramUniqueID)

            Dim paramForYear As New SqlParameter("@ForYear", SqlDbType.Int)
            paramForYear.Value = ForYear
            cmd.Parameters.Add(paramForYear)

            Dim paramReqCode As New SqlParameter("@ReqCode", SqlDbType.NVarChar)
            paramReqCode.Value = ReqCode
            cmd.Parameters.Add(paramReqCode)

            Dim paramRemarks As New SqlParameter("@Remarks", SqlDbType.NVarChar)
            paramRemarks.Value = " "
            cmd.Parameters.Add(paramRemarks)

            Dim paramToFollow As New SqlParameter("@ToFollow", SqlDbType.Bit)
            paramToFollow.Value = 1
            cmd.Parameters.Add(paramToFollow)

            '/////// For Image Data
            Dim paramName As New SqlParameter("@Name", SqlDbType.VarChar)
            paramName.Value = FileName
            cmd.Parameters.Add(paramName)

            Dim paramSize As New SqlParameter("@Size", SqlDbType.Int)
            paramSize.Value = FileSize
            cmd.Parameters.Add(paramSize)

            Dim paramImageData As New SqlParameter("@ImageData", SqlDbType.VarBinary)
            paramImageData.Value = System.IO.File.ReadAllBytes(_nPath & ".zip") 'Bytes ''  Get Zipped File from Temporary Folder
            cmd.Parameters.Add(paramImageData)

            Dim paramFileExtn As New SqlParameter("@FileExtn", SqlDbType.NVarChar)
            paramFileExtn.Value = ".zip" ' Zip Extension
            cmd.Parameters.Add(paramFileExtn)

            Dim paramNewId As New SqlParameter("@ImagesID", SqlDbType.Int)
            paramNewId.Value = -1 '_FnAutoGenID("ReqImageID")
            _nImageID = paramNewId.Value
            cmd.Parameters.Add(paramNewId)

            'cmd.Open()
            cmd.ExecuteNonQuery()
            cmd.Dispose()

        Catch ex As Exception
            snackbar("red", ex.Message)
        End Try

    End Sub

    Protected Sub OnRowDataBound(sender As Object, e As GridViewRowEventArgs)
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim ReqCode As String = _oGridViewRequirementsList.DataKeys(e.Row.RowIndex).Value.ToString()
                Dim _nGridviewsub As GridView = TryCast(e.Row.FindControl("_oGridviewReqSubmitted"), GridView)
                _nGridviewsub.DataSource = GetData_SubmittedReq(ReqCode, e)
                _nGridviewsub.DataBind()

            End If
        Catch ex As Exception
            snackbar("red", ex.Message)
        End Try

    End Sub

    <WebMethod()> _
    Public Shared Function GetData_SubmittedReq(ReqCode As String, e As GridViewRowEventArgs) As DetailsClass()
        Try
            Dim _nGridviewsub As GridView = CType(e.Row.FindControl("_oGridviewReqSubmitted"), GridView)
            Dim Detail As List(Of DetailsClass) = New List(Of DetailsClass)()
            Dim SelectString As String = "SELECT * FROM BP_SubmittedReq_Temp where UniqueID = '" & cSessionLoader._pControlNo & "' and ReqCode ='" & ReqCode & "' "
            Dim cn As SqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            Dim cmd As SqlCommand = New SqlCommand(SelectString, cn)
            'cn.Open()
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim dtGetData As DataTable = New DataTable()
            da.Fill(dtGetData)

            For Each dtRow As DataRow In dtGetData.Rows
                Dim DataObj As DetailsClass = New DetailsClass()
                DataObj.AcctNo = dtRow("UniqueID").ToString()
                DataObj.ReqCode = dtRow("ReqCode").ToString()
                DataObj.ImageID = dtRow("ImagesID").ToString()
                DataObj.ForYear = dtRow("ForYear").ToString()
                DataObj.Name = dtRow("Name").ToString()
                Detail.Add(DataObj)

            Next

            Return Detail.ToArray()
        Catch ex As Exception

        End Try

    End Function

    Public Class DetailsClass
        Public Property AcctNo As String
        Public Property ReqCode As String
        Public Property ImageID As String
        Public Property ForYear As String
        Public Property Name As String
    End Class

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class


  
End Class