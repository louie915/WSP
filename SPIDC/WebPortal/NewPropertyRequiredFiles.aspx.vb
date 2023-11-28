Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class NewPropertyRequiredFiles
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then

            'Dim action = Request("__EVENTTARGET")
            'Dim val = Request("__EVENTARGUMENT")

            'If action = "Save" Then
            '    _oContinue()
            'End If

        End If
    End Sub   

    Sub upload_Docs(ByVal sender As Object, ByVal e As System.EventArgs) Handles _oBtnContinue.Click
        Dim _nclass As New cDalNewProperty
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        Dim Exists As Boolean
        Dim Email As String = cSessionUser._pUserID              

        If _oTxtDeedofsale.PostedFile IsNot Nothing And _oTxtDeedofsale.PostedFile.ContentLength > 0 Then
            Dim FileData As HttpPostedFile = _oTxtDeedofsale.PostedFile
            Dim FileName As String = _oTxtDeedofsale.PostedFile.FileName
            Dim FileType As String = _oTxtDeedofsale.PostedFile.ContentType
            Dim fs As Stream = FileData.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
            cDalNewProperty._pDofSName = FileName
            cDalNewProperty._pDofSType = FileType
            cDalNewProperty._pDofSData = bytes
        End If
        If _oTxtCopyofTitle.PostedFile IsNot Nothing And _oTxtCopyofTitle.PostedFile.ContentLength > 0 Then
            Dim FileData As HttpPostedFile = _oTxtCopyofTitle.PostedFile
            Dim FileName As String = _oTxtCopyofTitle.PostedFile.FileName
            Dim FileType As String = _oTxtCopyofTitle.PostedFile.ContentType
            Dim fs As Stream = FileData.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
            cDalNewProperty._pCofTName = FileName
            cDalNewProperty._pCofType = FileType
            cDalNewProperty._pCofData = bytes
        End If
        If _oTxtProofofPayment.PostedFile IsNot Nothing And _oTxtProofofPayment.PostedFile.ContentLength > 0 Then
            Dim FileData As HttpPostedFile = _oTxtProofofPayment.PostedFile
            Dim FileName As String = _oTxtProofofPayment.PostedFile.FileName
            Dim FileType As String = _oTxtProofofPayment.PostedFile.ContentType
            Dim fs As Stream = FileData.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
            cDalNewProperty._pPofPName = FileName
            cDalNewProperty._pPofPType = FileType
            cDalNewProperty._pPofPData = bytes
        End If
        If _oTxtTaxClearance.PostedFile IsNot Nothing And _oTxtTaxClearance.PostedFile.ContentLength > 0 Then
            Dim FileData As HttpPostedFile = _oTxtTaxClearance.PostedFile
            Dim FileName As String = _oTxtTaxClearance.PostedFile.FileName
            Dim FileType As String = _oTxtTaxClearance.PostedFile.ContentType
            Dim fs As Stream = FileData.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
            cDalNewProperty._pTCName = FileName
            cDalNewProperty._pTCType = FileType
            cDalNewProperty._pTCData = bytes
        End If
        If _oTxtDeclarationCopy.PostedFile IsNot Nothing And _oTxtDeclarationCopy.PostedFile.ContentLength > 0 Then
            Dim FileData As HttpPostedFile = _oTxtDeclarationCopy.PostedFile
            Dim FileName As String = _oTxtDeclarationCopy.PostedFile.FileName
            Dim FileType As String = _oTxtDeclarationCopy.PostedFile.ContentType
            Dim fs As Stream = FileData.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
            cDalNewProperty._pDCName = FileName
            cDalNewProperty._pDCType = FileType
            cDalNewProperty._pDCData = bytes
        End If
        If _oTxtCorporateProperty.PostedFile IsNot Nothing And _oTxtCorporateProperty.PostedFile.ContentLength > 0 Then
            Dim FileData As HttpPostedFile = _oTxtCorporateProperty.PostedFile
            Dim FileName As String = _oTxtCorporateProperty.PostedFile.FileName
            Dim FileType As String = _oTxtCorporateProperty.PostedFile.ContentType
            Dim fs As Stream = FileData.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
            cDalNewProperty._pCPName = FileName
            cDalNewProperty._pCPType = FileType
            cDalNewProperty._pCPData = bytes
        End If
        If _oTxtValidID.PostedFile IsNot Nothing And _oTxtValidID.PostedFile.ContentLength > 0 Then
            Dim FileData As HttpPostedFile = _oTxtValidID.PostedFile
            Dim FileName As String = _oTxtValidID.PostedFile.FileName
            Dim FileType As String = _oTxtValidID.PostedFile.ContentType
            Dim fs As Stream = FileData.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
            cDalNewProperty._pVIdName = FileName
            cDalNewProperty._pVIdType = FileType
            cDalNewProperty._pVIdData = bytes
        End If

        Response.Redirect("NewProperty.aspx")
    End Sub


End Class