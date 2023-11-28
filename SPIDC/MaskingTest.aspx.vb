Public Class MaskingTest
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

      
    End Sub

    Private Sub btn001_ServerClick(sender As Object, e As EventArgs) Handles btn001.ServerClick
        Dim array As String() = txt001.Value.Split("@".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)

        Dim queryStr As String
        queryStr = "Select concat("
        For ctr As Integer = 0 To array.Length - 1
            Response.Write(array(ctr) & "<br/>")
            If array(ctr).Contains("MM") or array(ctr).Contains("MM") or array(ctr).Contains("MM") Then
                queryStr += "FORMAT (getdate(), '" & array(ctr) & "' ),"
            ElseIf array(ctr).Contains("DD") Then
                queryStr += "FORMAT (getdate(), '" & array(ctr).ToLower & "' ),"
            ElseIf array(ctr).Contains("YYYY") Then
                queryStr += "FORMAT (getdate(), '" & array(ctr).ToLower & "' ),"
            ElseIf array(ctr).Contains("YY") Then
                queryStr += "FORMAT (getdate(), '" & array(ctr).ToLower & "' ),"
            ElseIf array(ctr).Contains("XXXX") Then
                queryStr += "FORMAT (getdate(), '" & array(ctr).Replace("XXXX", "yyyy") & "'),"
            ElseIf array(ctr).Contains("XX") Then
                queryStr += "FORMAT (getdate(), '" & array(ctr).Replace("XX", "yy") & "'),"
            ElseIf array(ctr).Contains("TRANSNO") Then
                queryStr += array(ctr).Replace("TRANSNO", "(SELECT REPLACE(STR((select count(*)+1 from LCR_RegistrationMaster),5),' ','0')),")
            ElseIf array(ctr).Contains("REGNO") Then
                queryStr += "'" & array(ctr).Replace("REGNO", "00002") & "',"
            End If

            If ctr = array.Length - 1 Then
                queryStr = queryStr.Substring(0, queryStr.Length - 1)
            End If

        Next
        queryStr += " ) as TransNo"
        Response.Write(queryStr)
    End Sub

End Class