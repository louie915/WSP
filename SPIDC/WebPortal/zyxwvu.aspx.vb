
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Public Class zyxwvu
    Inherits System.Web.UI.Page
    Private _mKey As String = "C1B32EBED50A5F1CA4AF0A6B405A5F5BC5179B98644522618D499056A528D80E"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Function Decrypt(ByVal _nCipherText As String, ByVal _nSalt As Byte()) As String
        Decrypt = Nothing
        Dim cipherBytes As Byte() = Convert.FromBase64String(_nCipherText)
        Dim pdb As New Rfc2898DeriveBytes(_mKey, _nSalt)
        Dim decryptedData As Byte() = Decrypt(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16))
        Return System.Text.Encoding.Unicode.GetString(decryptedData)
    End Function

    Private Function Decrypt(ByVal cipherData As Byte(), ByVal Key As Byte(), ByVal IV As Byte()) As Byte()
        Decrypt = Nothing
        Dim ms As New MemoryStream()
        Dim cs As CryptoStream = Nothing

        Dim alg As Rijndael = Rijndael.Create()
        alg.Key = Key
        alg.IV = IV
        cs = New CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write)
        cs.Write(cipherData, 0, cipherData.Length)
        cs.FlushFinalBlock()
        Return ms.ToArray()
    End Function

    Private Sub GetDetails(ByVal email As String, ByRef EncryptedText As String, ByRef Salt As Byte())

    End Sub
  
    Private Sub btnGet_ServerClick(sender As Object, e As EventArgs) Handles btnGet.ServerClick
        Dim pass As String = Nothing
        Dim EncryptedText As String = Nothing
        Dim email As String = Nothing
        Dim salt As Byte() = Nothing
        GetDetails(email, EncryptedText, salt)
        pass = Decrypt(EncryptedText, salt)
        txtPassword.Value = pass
    End Sub
End Class