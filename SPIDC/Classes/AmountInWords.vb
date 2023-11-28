Public Class AmountInWords
    Public Function ConvertToWords(ByVal num As Double) As String
        Dim pesos As Integer = Math.Floor(num)
        Dim cents As Integer = Math.Round((num - pesos) * 100)

        Dim words As String = ConvertToWords(pesos) + " Pesos "

        If cents > 0 Then
            words += "and " + ConvertToWords(cents) + " Cents"
        End If

        Return words
    End Function

    Private Function ConvertToWords(ByVal num As Integer) As String
        If num = 0 Then
            Return "Zero"
        End If

        Dim words As String = ""

        If (num \ 1000000) > 0 Then
            words += ConvertToWords(num \ 1000000) + " Million "
            num = num Mod 1000000
        End If

        If (num \ 1000) > 0 Then
            words += ConvertToWords(num \ 1000) + " Thousand "
            num = num Mod 1000
        End If

        If (num \ 100) > 0 Then
            words += ConvertToWords(num \ 100) + " Hundred "
            num = num Mod 100
        End If

        If num > 0 Then
            Dim ones() As String = {"", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"}
            Dim tens() As String = {"", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"}

            If num < 20 Then
                words += ones(num)
            Else
                words += tens(num \ 10)
                If (num Mod 10) > 0 Then
                    words += "-" + ones(num Mod 10)
                End If
            End If
        End If

        Return words
    End Function

End Class
