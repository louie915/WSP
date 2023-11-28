Imports System.Globalization
Imports System.Net
Imports System.IO
Imports System.Data.SqlClient

Public Class DLFormsSetup
    Inherits System.Web.UI.Page
    Dim strSize As String = Nothing
    Dim intSize As Integer = Nothing
    Dim err As String = Nothing
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FileUpload1.Attributes("multiple") = "multiple"
            LoadDLFormList()
        End If

    End Sub

    Protected Sub Upload(sender As Object, e As EventArgs)
        Try
            Dim _FileSize As Integer = 0
            For x As Integer = 0 To Request.Files.Count - 1
                Dim FileData As HttpPostedFile = Request.Files(x)
                If FileData.ContentLength > 0 Then
                    _FileSize += Request.Files(x).ContentLength
                End If
            Next

            Dim _nClass As New cDalImageSetup
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            _nClass._pSubGetTotFileSize(strSize, intSize, err, "DLForms")

            If (_FileSize + intSize) < 10485760 Then ' 10485760 = 10 MB
                For i As Integer = 0 To Request.Files.Count - 1
                    Dim FileData As HttpPostedFile = Request.Files(i)
                    If FileData.ContentLength > 0 Then
                        Dim FileName As String = Request.Files(i).FileName
                        Dim FileType As String = Request.Files(i).ContentType
                        Dim FileSize As String = Request.Files(i).ContentLength
                        Dim fs As Stream = FileData.InputStream
                        Dim br As New BinaryReader(fs)
                        Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))

                        Dim _nQuery As String = Nothing
                        _nQuery = "INSERT INTO DLForms values(@FileName,@FileType,@FileData,@FileSize)"

                        Dim _nSqlCommand As New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_CR)

                        With _nSqlCommand.Parameters
                            .AddWithValue("@FileName", FileName)
                            .AddWithValue("@FileType", FileType)
                            .AddWithValue("@FileData", bytes)
                            .AddWithValue("@FileSize", FileSize)
                        End With
                        '----------------------------------
                        _nSqlCommand.ExecuteNonQuery()
                        '----------------------------------

                    End If
                Next
            Else
                Response.Write("<script>")
                Response.Write("alert('Over Max Size');")
                Response.Write("</script>")
            End If


            LoadDLFormList()
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub Remove(sender As Object, e As EventArgs)
        Try
            Dim _nClass As New cDalImageSetup
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            _nClass._pSubRemoveDLForms(hdnFileID.Value, hdnFileName.Value)
            LoadDLFormList()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub RemoveAll(sender As Object, e As EventArgs)
        Try
            Dim _nClass As New cDalImageSetup
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            _nClass._pSubRemoveAllDLForms()
            LoadDLFormList()
        Catch ex As Exception

        End Try
    End Sub

    Public Function ConvertFileToBase64(ByVal fileName As String) As String
        Return Convert.ToBase64String(System.IO.File.ReadAllBytes(fileName))
    End Function

    Public Sub LoadDLFormList()
        Try
            Dim _nClass As New cDalImageSetup
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            _nClass._pSubSelectDLForms()
            gv_DLForms.DataSource = _nClass._mDataTable
            gv_DLForms.DataBind()
            _nClass._pSubGetTotFileSize(strSize, intSize, err, "DLForms")
            lblTotFileSize.InnerText = "Total Uploaded File Size : " & strSize & " / 10 MB"
        Catch ex As Exception

        End Try
    End Sub


End Class