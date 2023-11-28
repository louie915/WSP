

Imports System
Imports System.Drawing
Imports System.IO
Imports QRCoder
Imports System.Security
Imports System.Security.Cryptography
Imports System.Text
Imports System.Net



Public Class GenerateQR
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Protected Sub btnGenerate_Click(ByVal sender As Object, ByVal e As EventArgs)
        '    Dim code As String = txtQRCode.Text
        '    Dim qrGenerator As QRCodeGenerator = New QRCodeGenerator()
        '    '      Dim qrCode As QRCodeGenerator.QRCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q)
        '    Dim imgBarCode As System.Web.UI.WebControls.Image = New System.Web.UI.WebControls.Image()
        '    imgBarCode.Height = 150
        '    imgBarCode.Width = 150
        '
        '    '     Using bitMap As Bitmap = qrCode.GetGraphic(20)
        '
        '    Using ms As MemoryStream = New MemoryStream()
        '        Bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
        '        Dim byteImage As Byte() = ms.ToArray()
        '        imgBarCode.ImageUrl = "data:image/png;base64," & Convert.ToBase64String(byteImage)
        '    End Using
        '
        '    PlaceHolder1.Controls.Add(imgBarCode)
        '    End Using
    End Sub

    Shared Function GetHashMD5(theInput As String) As String

        Using hasher As MD5 = MD5.Create()    ' create hash object

            ' Convert to byte array and get hash
            Dim dbytes As Byte() =
                 hasher.ComputeHash(Encoding.UTF8.GetBytes(theInput))

            ' sb to create string from bytes
            Dim sBuilder As New StringBuilder()

            ' convert byte data to hex string
            For n As Integer = 0 To dbytes.Length - 1
                sBuilder.Append(dbytes(n).ToString("X2"))
            Next n

            Return sBuilder.ToString()
        End Using

    End Function
End Class

