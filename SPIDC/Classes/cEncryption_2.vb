

Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Security.Cryptography

Public Class cEncryption_2


    'excerpts from http://weblogs.asp.net/dwahlin/archive/2009/05/21/encrypting-data-in-net-applications.aspx ...
    'Get Encryption Key here https://www.grc.com/passwords.htm ....
    Public Shared _Pwd As String = "" 'Be careful storing this in code unless it’s secured and not distributed
    Public Shared _PKey As String = "" 'Be careful storing this in code unless it’s secured and not distributed
    Public Shared _xPwd As String = "2B4B99CE8A2EBA33AD2188FA5DE9A9764EDEC4A155E95653BA3516DF0AD6C448" 'Be careful storing this in code unless it’s secured and not distributed 
    Shared _Salt As Byte() = New Byte() {&H45, &HF1, &H61, &H6E, &H20, &H0, &H65, &H64, &H76, &H65, &H64, &H3, &H76}
    'How to Use...
    ' dim creditCardNumber  as string =  Encryptor2.Encrypt(cust.CreditCardNumber)
    'Just always compare encrypted data.... no decryption needed....


    Public Function Decrypt(ByVal cipherText As String) As String
        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
        Dim pdb As New Rfc2898DeriveBytes(_Pwd, _Salt)
        Dim decryptedData As Byte() = Decrypt(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16))
        Return System.Text.Encoding.Unicode.GetString(decryptedData)
    End Function

    Private Function Decrypt(ByVal cipherData As Byte(), ByVal Key As Byte(), ByVal IV As Byte()) As Byte()
        Dim ms As New MemoryStream()
        Dim cs As CryptoStream = Nothing
        Try
            Dim alg As Rijndael = Rijndael.Create()
            alg.Key = Key
            alg.IV = IV
            cs = New CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write)
            cs.Write(cipherData, 0, cipherData.Length)
            cs.FlushFinalBlock()
            Return ms.ToArray()
        Catch
            Return Nothing
        Finally
            cs.Close()
        End Try
    End Function

    Public Function Encrypt(ByVal clearText As String) As String
        Dim clearBytes As Byte() = System.Text.Encoding.Unicode.GetBytes(clearText)
        Dim pdb As New Rfc2898DeriveBytes(_Pwd, _Salt)
        Dim encryptedData As Byte() = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16))
        Return Convert.ToBase64String(encryptedData)
    End Function

    Public Function EncryptPassKey(ByVal clearText As String) As String
        Dim clearBytes As Byte() = System.Text.Encoding.Unicode.GetBytes(clearText)
        Dim pdb As New Rfc2898DeriveBytes(_Pwd, _Salt)
        Dim encryptedData As Byte() = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16))
        Return Convert.ToBase64String(encryptedData)
    End Function


    Private Function Encrypt(ByVal clearData As Byte(), ByVal Key As Byte(), ByVal IV As Byte()) As Byte()
        Dim ms As New MemoryStream()
        Dim cs As CryptoStream = Nothing
        Try
            Dim alg As Rijndael = Rijndael.Create()
            alg.Key = Key
            alg.IV = IV
            cs = New CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write)
            cs.Write(clearData, 0, clearData.Length)
            cs.FlushFinalBlock()
            Return ms.ToArray()
        Catch
            Return Nothing
        Finally
            cs.Close()
        End Try
    End Function
End Class
