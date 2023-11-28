Imports System.Globalization
Imports System.Net
Imports System.IO
Imports System.Data.SqlClient

Public Class eORSetup
    Inherits System.Web.UI.Page
    Dim strSize As String = Nothing
    Dim intSize As Integer = Nothing
    Dim err As String = Nothing
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'get existing
            Load_Existing()
        End If
    End Sub

    Sub Load_Existing()

        Dim header1 As String
        Dim header2 As String
        Dim OfficerName As String
        Dim _nClass As New eOR
        _nClass.Get_Setup(header1, header2, OfficerName)
        txtlguName.Value = header1
        txtOffice.Value = header2
        txtOfficerName.Value = OfficerName


    End Sub

    Protected Sub Upload(sender As Object, e As EventArgs)
        Try
            '"Insert into eOR_Setup (Office_Name,Header1,Header2) values(@Office_Name,@Header1,@Header2)"
            Dim _nQuery1 As String = Nothing
            _nQuery1 = _
           " IF EXISTS (SELECT * FROM eOR_Setup)" &
           "     BEGIN" &
           "       UPDATE eOR_Setup SET Header1 = @Header1,Header2=@Header2,Officer_Name=@Officer_Name" &
           "     End" &
           " Else" &
           "     BEGIN" &
           "     INSERT INTO eOR_Setup (Header1, Header2, Officer_Name) VALUES (@Header1, @Header2, @Officer_Name)" &
           "     End"

            Dim _nSqlCommand1 As New SqlCommand(_nQuery1, cGlobalConnections._pSqlCxn_OAIMS)

            With _nSqlCommand1.Parameters
                .AddWithValue("@Header1", txtlguName.Value)
                .AddWithValue("@Header2", txtOffice.Value)
                .AddWithValue("@Officer_Name", txtOfficerName.Value)
            End With
            '----------------------------------
            _nSqlCommand1.ExecuteNonQuery()
            '----------------------------------


            Dim _FileSize As Integer = 0
            Dim eSignature As Byte() = FileUpload1.FileBytes
            Dim watermark As Byte() = FileUpload2.FileBytes
            Dim eSignature_FileSize As Integer = FileUpload1.FileContent.Length
            Dim watermark_FileSize As Integer = FileUpload2.FileContent.Length
            _FileSize = FileUpload1.FileContent.Length + FileUpload2.FileContent.Length

            'For x As Integer = 0 To Request.Files.Count - 1
            '    Dim FileData As HttpPostedFile = Request.Files(x)
            '    If FileData.ContentLength > 0 Then
            '        _FileSize += Request.Files(x).ContentLength
            '    End If
            'Next

            If _FileSize = 0 Then
                Exit Sub
            End If
            If (_FileSize) < 10485760 Then ' 10485760 = 10 MB
                'For i As Integer = 0 To Request.Files.Count - 1
                'Dim FileData As HttpPostedFile = Request.Files(i)
                'If FileData.ContentLength > 0 Then

                'Dim fs As Stream = FileData.InputStream
                'Dim br As New BinaryReader(fs)
                'Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))


                Dim _nQuery As String = Nothing
                Dim eSignature_qry As String = Nothing
                Dim watermark_qry As String = Nothing
                If eSignature_FileSize > 0 Then
                    eSignature_qry = "Update eOR_Setup set eSignature_File=@eSignature_File"
                End If

                If watermark_FileSize > 0 Then
                    watermark_qry = "Update eOR_Setup set Watermark_File=@Watermark_File"
                End If

                _nQuery = eSignature_qry & ";" & watermark_qry

                Dim _nSqlCommand As New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_OAIMS)

                With _nSqlCommand.Parameters
                    .AddWithValue("@Watermark_File", watermark)
                    .AddWithValue("@eSignature_File", eSignature)
                End With
                '----------------------------------
                _nSqlCommand.ExecuteNonQuery()
                '----------------------------------

                'End If
                'Next
            Else
                Response.Write("<script>")
                Response.Write("alert('Over Max Size');")
                Response.Write("</script>")
            End If
        Catch ex As Exception

        End Try

    End Sub

 
   
End Class