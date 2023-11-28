Imports System.Globalization
Imports System.Net
Imports System.IO
Imports System.Data.SqlClient

Public Class ImgUpload
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
   

    Sub upload_Docs()
        If up1.PostedFile IsNot Nothing And up1.PostedFile.ContentLength > 0 Then
            Dim FileData As HttpPostedFile = up1.PostedFile
            Dim FileName As String = up1.PostedFile.FileName
            Dim FileType As String = up1.PostedFile.ContentType
            Dim fs As Stream = FileData.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))

            Try
                Dim _nQuery As String = Nothing
                _nQuery = "Update LGU_Profile SET LGU_LOGO = @LGU_LOGO, LGU_LOGO_Name = @LGU_LOGO_Name, LGU_LOGO_Ext = @LGU_LOGO_Ext "

                Dim _nSqlCommand As New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_CR)

                With _nSqlCommand.Parameters
                    .AddWithValue("@LGU_LOGO", bytes)
                    .AddWithValue("@LGU_LOGO_Name", FileName)
                    .AddWithValue("@LGU_LOGO_Ext", FileType)
                End With
                '----------------------------------
                _nSqlCommand.ExecuteNonQuery()
                '----------------------------------
            Catch ex As Exception

            End Try

        End If

        If up2.PostedFile IsNot Nothing And up2.PostedFile.ContentLength > 0 Then
            Dim FileData2 As HttpPostedFile = up2.PostedFile
            Dim FileName2 As String = up2.PostedFile.FileName
            Dim FileType2 As String = up2.PostedFile.ContentType
            Dim fs As Stream = FileData2.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes2 As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))

            Try
                Dim _nQuery As String = Nothing
                _nQuery = "Update LGU_Profile SET HEADER_TEMPLATE = @HEADER_TEMPLATE, HEADER_TEMPLATE_Name = @HEADER_TEMPLATE_Name, HEADER_TEMPLATE_Ext = @HEADER_TEMPLATE_Ext "

                Dim _nSqlCommand As New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_CR)

                With _nSqlCommand.Parameters
                    .AddWithValue("@HEADER_TEMPLATE", bytes2)
                    .AddWithValue("@HEADER_TEMPLATE_Name", FileName2)
                    .AddWithValue("@HEADER_TEMPLATE_Ext", FileType2)
                End With
                '----------------------------------
                _nSqlCommand.ExecuteNonQuery()
                '----------------------------------
            Catch ex As Exception

            End Try

        End If
    End Sub


    Private Sub btnUpload_ServerClick(sender As Object, e As EventArgs) Handles btnUpload.ServerClick
 upload_Docs

    End Sub
End Class