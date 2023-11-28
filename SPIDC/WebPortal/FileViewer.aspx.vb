Imports System.Globalization
Imports System.Net

Public Class FileViewer
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim FileName As String = Nothing
        Get_Attachment()
        FileName = hdnFileName.Value
        If Not IsPostBack Then
        
        Else
            If FileName <> "" Then

                Dim action = Request("__EVENTTARGET")
                Dim val = Request("__EVENTARGUMENT")

                If action = "View" Then
                    DownloadFile(val)
                ElseIf action = "Delete_Attachment" Then
                    DeleteAttachment(val)
                    Get_Attachment()
                End If
            Else : Exit Sub

            End If
        End If


    End Sub
    Sub Get_Attachment()
        Try
            '----------------------------------


            Dim _nGridView As New GridView
            _nGridView = Gv_FileViewer
            _nGridView.DataSourceID = Nothing

            Dim _nClass As New cDalProfileLoader
            _nClass._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pSubSelectAttachment()

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable



            Try
                '----------------------------------
                If _nDataTable.HasErrors Then
                    'Griderr = True
                    '_mSubShowBlank()
                End If

                'If _nDataTable.Rows.Count > 0 Then
                _nGridView.DataSource = _nDataTable
                _nGridView.DataBind()

                'Else
                '' snackbar("red", "No Records Found.")
                'End If
                '----------------------------------
            Catch ex As Exception

                'GridErr = True
                '_mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception



        End Try


    End Sub

    Protected Sub DownloadFile(val)
        Dim FileData As Byte() = Nothing
        Dim _nEmail As String = hdnEmail.Value
        Dim FileName As String = hdnFileName.Value
        Dim FileType As String = Nothing


        Dim _nclass As New cDalProfileLoader
        _nclass._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
        _nclass._pSubSelectSpecificAttachment(_nEmail, FileName, val, FileType, FileData)

        ''Dim FilePath As String = Server.MapPath(FileName)
        ''Dim User As New WebClient()
        ''Dim FileBuffer As [Byte]() = User.DownloadData(FilePath)
        ''If Not (FileBuffer Is Nothing) Then
        ''    Response.ContentType = FileType '---"application/pdf"
        ''    Response.AddHeader("content-length", FileBuffer.Length.ToString())
        ''    Response.BinaryWrite(FileBuffer)
        ''End If


        Response.Clear()
        Response.Buffer = True
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = FileType
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName)
        Response.BinaryWrite(FileData)
        Response.Flush()
        Response.End()
    End Sub

    Protected Sub DeleteAttachment(val)
        Dim _nEmail As String = hdnEmail.Value
        Dim FileName As String = hdnFileName.Value
        Dim _nclass As New cDalProfileLoader
        _nclass._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
        _nclass._pSubDeleteSpecificAttachment(Trim(_nEmail), Trim(FileName), val)

    End Sub


    Private Sub Gv_FileViewer_Sorting(sender As Object, e As GridViewSortEventArgs) Handles Gv_FileViewer.Sorting

        Dim dt As DataTable = DirectCast(Gv_FileViewer.DataSource, DataTable)
        Dim dv As New DataView(dt)
        Try

 
        If Gv_FileViewer.Attributes("dir") = SortDirection.Ascending Then
            dv.Sort = e.SortExpression & " DESC"
            Gv_FileViewer.Attributes("dir") = SortDirection.Descending

        Else
            Gv_FileViewer.Attributes("dir") = SortDirection.Ascending
            dv.Sort = e.SortExpression & " ASC"

        End If

        Gv_FileViewer.DataSource = dv
            Gv_FileViewer.DataBind()
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub datagrid_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            'loaddata()
            'ShowApplicationSearch(_oHdnTopCounterApp.Value)
            Gv_FileViewer.PageIndex = e.NewPageIndex
            Gv_FileViewer.DataBind()

            'GetFiles(hdnEmail.Value)

        Catch ex As Exception
        End Try
    End Sub


End Class