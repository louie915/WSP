
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web



Public Class ViewImage
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim _nSwitch As String = Request.QueryString("Switch")
            Select Case _nSwitch
                Case "A"
                    LoadImageAttachment() 'Initialize Image attachment display.
                Case "B"
                    LoadImageRequirements() 'Initialize Image Requirements display
            End Select

        End If
    End Sub

    Private Sub LoadImageAttachment()
        'Using con As SqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        'Dim cmd As New SqlCommand("spGetUploadedImageById", con)
        'cmd.CommandType = CommandType.StoredProcedure

        'Dim paramId As New SqlParameter("@Id", SqlDbType.Int)

        'paramId.Value = Request.QueryString("Id")
        'cmd.Parameters.Add(paramId)

        Dim _nCls As New cdalpicture
        Dim field As String = ""
        Dim settings As String = Request.QueryString("Settings")
        _nCls._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS

        Select Case settings

            Case "8", "9", "10"
                _nCls._pUniqueID = Request.QueryString("Id")

            Case Else
                _nCls._pACCTNO = Request.QueryString("Id")

        End Select

        If settings = "1" Then
            _nCls._pSubSelectowner()
            field = "pic_owner"
        ElseIf settings = "2" Then
            _nCls._pSubSelectestab()
            field = "picture"
        ElseIf settings = "3" Then
            _nCls._pSubSelectmap()
            field = "pic_location"
        ElseIf settings = "4" Then
            _nCls._pSubSelectowner2()
            field = "pic_owner"
        ElseIf settings = "5" Then
            _nCls._pSubSelectestab2()
            field = "picture"
        ElseIf settings = "6" Then
            _nCls._pSubSelectmap2()
            field = "pic_location"
        ElseIf settings = "7" Then
            _nCls._pFileNo = Request.QueryString("FileNo")
            _nCls._pSubSelectTOPFile()
            field = "ARXFile"
        ElseIf settings = "8" Then
            _nCls._pSubSelectowner_Temp()
            field = "pic_owner"
        ElseIf settings = "9" Then
            _nCls._pSubSelectestab_Temp()
            field = "picture"
        ElseIf settings = "10" Then
            _nCls._pSubSelectmap_Temp()
            field = "pic_location"
        End If

        Dim bytes As Byte() = DirectCast(_nCls._pDataTable.Rows(0).Item(field), Byte())


        Dim _nFileExtn As String = UCase(_nCls._pFileExtn)
        _oLabel_FileName.Text = _nCls._pFileName & _nFileExtn

        If _nFileExtn = ".PDF" Then
            Response.Clear()
            Response.ContentType = "application/pdf"
            Response.BinaryWrite(bytes)
            Response.Flush()
            Response.End()

            Image1.Visible = True
            Image2.Visible = False

        ElseIf _nFileExtn = UCase(".rar") Or _nFileExtn = UCase(".zip") Then
            Image1.Visible = False
            Image2.Visible = True
        Else
            Try
                Image1.Visible = True
                Image2.Visible = False
                Dim strBase64 As String = Convert.ToBase64String(bytes)
                Image1.ImageUrl = Convert.ToString("data:Image/pdf;base64,") & strBase64

            Catch ex As Exception

            End Try

        End If


        'End Using
    End Sub

    Private Sub LoadImageRequirements()
        Using con As SqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            Dim cmd As New SqlCommand("spGetUploadedImageById", con)
            cmd.CommandType = CommandType.StoredProcedure

            Dim paramId As New SqlParameter("@Id", SqlDbType.Int)

            paramId.Value = Request.QueryString("Id")
            cmd.Parameters.Add(paramId)
            Dim field As String = "ImageData"


            'Dim bytes As Byte() = DirectCast(cmd.ExecuteScalar(), Byte())

            Dim _nCls As New cDalBPRequirementsimg

            _nCls._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
            _nCls._pImagesID = Request.QueryString("Id")

            If cSessionLoader._pControlNo <> Nothing Then
                _nCls._pSubSelect_Temp()
            Else
                _nCls._pSubSelect()
            End If

            Dim bytes As Byte() = DirectCast(_nCls._pDataTable.Rows(0).Item(field), Byte())

            Dim _nFileExtn As String = UCase(_nCls._pFileExtn)
            _oLabel_FileName.Text = _nCls._pFileName & _nFileExtn.ToLower

            If _nFileExtn = ".PDF" Then
                Response.Clear()
                Response.ContentType = "application/pdf"
                Response.AddHeader("name", "value")
                Response.BinaryWrite(bytes)
                Response.Flush()
                Response.End()

            ElseIf _nFileExtn = UCase(".rar") Or _nFileExtn = UCase(".zip") Then
                Image1.Visible = False
                Image2.Visible = True

            Else
                Image1.Visible = True
                Image2.Visible = False
                Dim base64String As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                Image1.ImageUrl = "data:image/png;base64," & base64String
            End If

        End Using
    End Sub


    Public Sub _InitDownload()
        Dim _nSwitch As String = Request.QueryString("Switch")
        Select Case _nSwitch
            Case "A"
                _DownloadAttachment() 'Initialize Image Download attachment.
            Case "B"
                _DownloadRequirements() 'Initialize Image Download requirements.
        End Select

    End Sub
    Private Sub _DownloadAttachment()
        Try
            Dim _nCls As New cdalpicture
            Dim field As String = ""
            Dim settings As String = Request.QueryString("Settings")
            _nCls._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS

            Select Case settings

                Case "8", "9", "10"
                    _nCls._pUniqueID = Request.QueryString("Id")

                Case Else
                    _nCls._pACCTNO = Request.QueryString("Id")

            End Select

            If settings = "1" Then
                _nCls._pSubSelectowner()
                field = "pic_owner"
            ElseIf settings = "2" Then
                _nCls._pSubSelectestab()
                field = "picture"
            ElseIf settings = "3" Then
                _nCls._pSubSelectmap()
                field = "pic_location"
            ElseIf settings = "4" Then
                _nCls._pSubSelectowner2()
                field = "pic_owner"
            ElseIf settings = "5" Then
                _nCls._pSubSelectestab2()
                field = "picture"
            ElseIf settings = "6" Then
                _nCls._pSubSelectmap2()
                field = "pic_location"
            ElseIf settings = "7" Then
                _nCls._pFileNo = Request.QueryString("FileNo")
                _nCls._pSubSelectTOPFile()
                field = "ARXFile"
            ElseIf settings = "8" Then
                _nCls._pSubSelectowner_Temp()
                field = "pic_owner"
            ElseIf settings = "9" Then
                _nCls._pSubSelectestab_Temp()
                field = "picture"
            ElseIf settings = "10" Then
                _nCls._pSubSelectmap_Temp()
                field = "pic_location"
            End If

            Dim bytes As Byte() = DirectCast(_nCls._pDataTable.Rows(0).Item(field), Byte())


            Dim _nFileExtn As String = UCase(_nCls._pFileExtn)
            Dim _nFileName As String = _nCls._pFileName & _nFileExtn.ToLower

            ' Response Excecute Export
            Response.Clear()
            Response.Buffer = True
            Response.Charset = ""
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.ContentType = ContentType
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + _nFileName)
            Response.BinaryWrite(bytes)
            Response.Flush()
            Response.End()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub _DownloadRequirements()
        Try


            Using con As SqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                Dim cmd As New SqlCommand("spGetUploadedImageById", con)
                cmd.CommandType = CommandType.StoredProcedure

                Dim paramId As New SqlParameter("@Id", SqlDbType.Int)

                paramId.Value = Request.QueryString("Id")
                cmd.Parameters.Add(paramId)
                Dim field As String = "ImageData"

                'Dim bytes As Byte() = DirectCast(cmd.ExecuteScalar(), Byte())

                Dim _nCls As New cDalBPRequirementsimg

                _nCls._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                _nCls._pImagesID = Request.QueryString("Id")

                If cSessionLoader._pControlNo <> Nothing Then
                    _nCls._pSubSelect_Temp()
                Else
                    _nCls._pSubSelect()
                End If

                Dim bytes As Byte() = DirectCast(_nCls._pDataTable.Rows(0).Item(field), Byte())

                Dim _nFileExtn As String = UCase(_nCls._pFileExtn)
                Dim _nFileName = _nCls._pFileName & _nFileExtn.ToLower

                ' Response Excecute Export
                Response.Clear()
                Response.Buffer = True
                Response.Charset = ""
                Response.Cache.SetCacheability(HttpCacheability.NoCache)
                Response.ContentType = ContentType
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + _nFileName)
                Response.BinaryWrite(bytes)
                Response.Flush()
                Response.End()
            End Using


        Catch ex As Exception

        End Try

    End Sub

End Class