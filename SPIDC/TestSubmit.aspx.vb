Public Class TestSubmit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
         

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnConvert_Click(sender As Object, e As EventArgs)
        Dim _class As New AmountInWords
        Dim words As String = _class.ConvertToWords(Convert.ToDecimal(txtAmount.Text))
        lblAmountInWords.Text = words.ToUpper
    End Sub
End Class