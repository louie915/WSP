Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Public Class UserProfile
    Inherits System.Web.UI.Page

    Dim GIDName, GIDType, SPAName, SPAType, BRSecName, BRSecType As String
    Dim GIDByte, SPAByte, BRSecByte As Byte()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim action = Request("__EVENTTARGET")
        Dim val = Request("__EVENTARGUMENT")

        cSessionLGUProfile._pSqlConCR = cGlobalConnections._pSqlCxn_CR

        If Not IsPostBack Then
            Dim tst As String
            cSessionLGUProfile._pGetLGUProfile(tst)
            lblLGUNAME.InnerHtml = "I am a resident of " & cSessionLGUProfile._pLGU_Header2
            lblLGUNAME2.InnerHtml = cSessionLGUProfile._pLGU_Header2
            loadP()
            If cDalProfileLoader.pIsupload = False Then
                RefreshFile()
                FileLoad(" document.getElementById('_oLblGid').innerHTML = '" & Session("GIdName") & "'; " &
                                     " document.getElementById('_oLblSPA').innerHTML = '" & Session("SPAName") & "';" &
                                     " document.getElementById('_oLblBRSec').innerHTML = '" & Session("BRSecName") & "';")

            End If

            FileLoad(" document.getElementById('_oLblGid').innerHTML = '" & Session("GIdName") & " ; " & _
                     " document.getElementById('_oLblSPA').innerHTML = '" & Session("SPAName") & " ;" & _
                     " document.getElementById('_oLblBRSec').innerHTML = '" & Session("BRSecName") & "'; ")

           
            Dim _nDal As New cDalRegistered
            _nDal._pCxn = cGlobalConnections._pSqlCxn_OAIMS
            _nDal._pUserID = cSessionUser._pUserID
            _nDal._pSubSelectSpecificRecord()
            cSessionUser._pUserLevel = _nDal._pUserLevel

            If cSessionUser._pUserLevel = 0 Then
                loadP()
                ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "ShowPopup();", True)
            End If
        Else
            If action = "ctl00$_oBtnLogout" Or action = "Reset" Then

                Session("GIdName") = ""
                Session("GIdType") = ""
                Session("GIdByte") = Nothing

                Session("SPAName") = ""
                Session("SPAType") = ""
                Session("SPAByte") = Nothing

                Session("BRSecName") = ""
                Session("BRSecType") = ""
                Session("BRSecByte") = Nothing

                cDalProfileLoader._pCheckGId = False
                cDalProfileLoader._pCheckSPA = False
                cDalProfileLoader._pCheckBRSec = False


                cDalProfileLoader.pIsupload = False

            End If
            If action = "DownloadFiles" Then
                Download_Selected(val, cSessionUser._pUserID)
            End If
            If action = "Uploadfiles" Then
                action = "UPDATEPROFILE"
                upload_Docs() 
            End If
        End If
       

        If action = "UPDATEPROFILE" Then
            UpdateProfile()
            RefreshFile()
            snackbar("green", "Profile changes successfully saved")
            Exit Sub
        End If

    End Sub

    Protected Sub Update_Text(ByVal sender As Object, ByVal e As EventArgs)

        If _oFileGovernmentID.PostedFile IsNot Nothing And _oFileGovernmentID.PostedFile.ContentLength > 0 Then
            Dim FileData As HttpPostedFile = _oFileGovernmentID.PostedFile
            Dim FileName As String = _oFileGovernmentID.PostedFile.FileName
            Dim FileType As String = _oFileGovernmentID.PostedFile.ContentType
            Dim fs As Stream = FileData.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
            cDalProfileLoader._pGIdName = FileName
            cDalProfileLoader._pGIdType = FileType
            cDalProfileLoader._pGIdData = bytes

            upgid.Update()
        End If

        If _oFileSPA.PostedFile IsNot Nothing And _oFileSPA.PostedFile.ContentLength Then
            Dim FileData As HttpPostedFile = _oFileSPA.PostedFile
            Dim FileName As String = _oFileSPA.PostedFile.FileName
            Dim FileType As String = _oFileSPA.PostedFile.ContentType
            Dim fs As Stream = FileData.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
            cDalProfileLoader._pSPAName = FileName
            cDalProfileLoader._pSPAType = FileType
            cDalProfileLoader._pSPAData = bytes

            upspa.Update()
        End If

        If _oFileBRSec.PostedFile IsNot Nothing And _oFileBRSec.PostedFile.ContentLength Then
            Dim FileData As HttpPostedFile = _oFileBRSec.PostedFile
            Dim FileName As String = _oFileBRSec.PostedFile.FileName
            Dim FileType As String = _oFileBRSec.PostedFile.ContentType
            Dim fs As Stream = FileData.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
            cDalProfileLoader._pBRSecName = FileName
            cDalProfileLoader._pBRSecType = FileType
            cDalProfileLoader._pBRSecData = bytes

            upbrs.Update()
        End If

    End Sub

    Public ReadOnly Property getFirstName As String
        Get
            Dim _nClass As New cDalProfileLoader
            _nClass._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pEmail = cSessionUser._pUserID
            _nClass.loadProfile()

            Return _nClass._pFirstName
        End Get
    End Property

    Public ReadOnly Property getLastName As String
        Get
            Dim _nClass As New cDalProfileLoader
            _nClass._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pEmail = cSessionUser._pUserID
            _nClass.loadProfile()

            Return _nClass._pLastName
        End Get
    End Property

    Public ReadOnly Property getMiddleName As String
        Get
            Dim _nClass As New cDalProfileLoader
            _nClass._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pEmail = cSessionUser._pUserID
            _nClass.loadProfile()

            Return _nClass._pMiddleName
        End Get
    End Property

    Public ReadOnly Property getSuffix As String
        Get
            Dim _nClass As New cDalProfileLoader
            _nClass._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pEmail = cSessionUser._pUserID
            _nClass.loadProfile()

            Return _nClass._pExt
        End Get
    End Property

    Public ReadOnly Property getBirthDate As String
        Get
            Dim _nClass As New cDalProfileLoader
            _nClass._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pEmail = cSessionUser._pUserID
            _nClass.loadProfile()

            Return Format(_nClass._pBirthDay, "yyyy-MM-dd")
        End Get
    End Property

    Public ReadOnly Property getResident As String
        Get
            Dim _nClass As New cDalProfileLoader
            _nClass._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pEmail = cSessionUser._pUserID
            _nClass.loadProfile()

            Return Format(_nClass._pResident)
        End Get
    End Property

    'Private Sub _oBtnSaveChanges_ServerClick(sender As Object, e As EventArgs) Handles _oBtnSaveChanges.ServerClick
    '    Try
    '        'Dim _nClass As New cDalProfileLoader
    '        '_nClass._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
    '        '_nClass._pEmail = cSessionUser._pUserID

    '        '_nClass._pFirstName = _oTextFirstName.Value
    '        '_nClass._pLastName = _oTextLastName.Value
    '        '_nClass._pMiddleName = _oTextMiddleName.Value
    '        '_nClass._pExt = _oTextSuffix.Value
    '        '_nClass._pGender = _oSelectGender.Value
    '        '_nClass._pBirthDay = _oTextBirthday.Value
    '        '_nClass._pProfession = _oTextProfession.Value
    '        '_nClass._pAddress = _oTextAddress.Value
    '        '_nClass._pBirthPlace = _oTextBirthAddress.Value
    '        '_nClass._pCivilStatus = _oSelectCivilStatus.Value
    '        '_nClass._pCitizenship = StrConv(Request.Form_oSelectCitizenship.Value, VbStrConv.ProperCase)
    '        '_nClass._pTin = _oTextTIN.Value
    '        '_nClass._pContactNumber1 = _oTextContactNumber1.Value
    '        '_nClass._pContactNumber2 = _oTextContactNumber2.Value
    '        '_nClass._pContactNumber3 = _oTextContactNumber3.Value
    '        '_nClass._pHeight = _oTextHeight.Value
    '        '_nClass._pWeight = _oTextWeight.Value
    '        '_nClass._pResident = _oChkBoxRes.Value

    '        '_nClass.saveProfile()
    '        'loadP()

    '        'upload_Docs()

    '        snackbar("green", "Profile changes successfully saved")


    '    Catch ex As Exception
    '        snackbar("red", "Error on saving profile changes")
    '    End Try

    'End Sub


    Sub UpdateProfile()
        Try

            Dim _nClass As New cDalProfileLoader
            _nClass._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pEmail = cSessionUser._pUserID

            '_nClass._pFirstName = Request.Form("_oTextFirstName")
            '_nClass._pLastName = Request.Form("_oTextLastName")
            '_nClass._pMiddleName = Request.Form("_oTextMiddleName")
            '_nClass._pExt = Request.Form("_oTextSuffix")
            '_nClass._pGender = Request.Form("_oSelectGender")
            '_nClass._pBirthDay = Request.Form("_oTextBirthday")
            '_nClass._pProfession = Request.Form("_oTextProfession")
            '_nClass._pAddress = Request.Form("_oTextAddress")
            '_nClass._pBirthPlace = Request.Form("_oTextBirthAddress")
            '_nClass._pCivilStatus = Request.Form("_oSelectCivilStatus")
            '_nClass._pCitizenship = StrConv(Request.Form("_oSelectCitizenship"), VbStrConv.ProperCase)
            '_nClass._pTin = Request.Form("_oTextTIN")
            '_nClass._pContactNumber1 = Request.Form("_oTextContactNumber1")
            '_nClass._pContactNumber2 = Request.Form("_oTextContactNumber2")
            '_nClass._pContactNumber3 = Request.Form("_oTextContactNumber3")
            '_nClass._pHeight = Request.Form("_oTextHeight")
            '_nClass._pWeight = Request.Form("_oTextWeight")
            '_nClass._pResident = Request.Form("_oCheckBoxResident")

            _nClass._pFirstName = hdnFname.Value
            _nClass._pLastName = hdnLname.Value
            _nClass._pMiddleName = hdnMname.Value
            _nClass._pExt = hdnSuffix.Value
            _nClass._pGender = hdnGender.Value
            _nClass._pBirthDay = hdnBirthday.Value
            _nClass._pProfession = hdnTextProfession.Value
            _nClass._pAddress = hdnTextAddress.Value
            _nClass._pBirthPlace = hdnTextBirthAddress.Value
            _nClass._pCivilStatus = hdnSelectCivilStatus.Value
            _nClass._pCitizenship = hdnSelectCitizenship.Value
            _nClass._pTin = hdnTextTIN.Value
            _nClass._pContactNumber1 = hdnTextContactNumber1.Value
            _nClass._pContactNumber2 = hdnTextContactNumber2.Value
            _nClass._pContactNumber3 = hdnTextContactNumber3.Value
            _nClass._pHeight = hdnTextHeight.Value
            _nClass._pWeight = hdnTextWeight.Value
            _nClass._pResident = hdnCheckBoxResident.Value
            _nClass._pAlternateEmail = hdnTextAlternateEmail.Value
            _nClass._pResident = hdnCheckBoxResident.Value
            'If _nClass._pResident = hdnCheckBoxResident.Value Then
            '    _nClass._pResident = 1
            'Else
            '    _nClass._pResident = 0
            'End If
            _nClass.saveProfile()

            cDalProfileLoader._pGIdName = Nothing
            cDalProfileLoader._pGIdType = Nothing
            cDalProfileLoader._pGIdData = Nothing
            cDalProfileLoader._pSPAName = Nothing
            cDalProfileLoader._pSPAType = Nothing
            cDalProfileLoader._pSPAData = Nothing
            cDalProfileLoader._pBRSecName = Nothing
            cDalProfileLoader._pBRSecType = Nothing
            cDalProfileLoader._pBRSecData = Nothing
            loadP()
            'Isupload = False
            snackbar("green", "Profile changes successfully saved")

        Catch ex As Exception
            snackbar("red", "Error on saving profile changes")
        End Try


    End Sub
    Public Sub loadP()
        Dim _nClass As New cDalProfileLoader
        Dim gen As String = Nothing
        Dim genIndex As Integer

        _nClass._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
        _nClass._pEmail = cSessionUser._pUserID
        _nClass.loadProfile()

        If _nClass._pGender = "M" Then
            gen = "Male"
            genIndex = 0
        ElseIf _nClass._pGender = "F" Then
            gen = "Female"
            genIndex = 1
        End If

        _oLabelFullname.InnerText = _nClass._pFirstName + " " + _nClass._pMiddleName + " " + _nClass._pLastName + " " & _nClass._pExt
        _oLabelEmail.InnerText = _nClass._pEmail
        _oLabelProfession.InnerText = _nClass._pProfession
        _oLabelBirthday.InnerText = Format(_nClass._pBirthDay, "MMMM dd, yyyy")
        _oLabelBirthPlace.InnerText = _nClass._pBirthPlace
        _oLabelCitizenship.InnerText = CapitalizeFirstLetter(_nClass._pCitizenship)
        _oLabelAddress.InnerText = _nClass._pAddress
        _oLabelGender.InnerText = gen
        _oLabelCivilStatus.InnerText = _nClass._pCivilStatus
        _oLabelTIN.InnerHtml = _nClass._pTin
        _oLabelContactNumber1.InnerText = _nClass._pContactNumber1
        _oLabelContactNumber2.InnerText = _nClass._pContactNumber2
        _oLabelContactNumber3.InnerText = _nClass._pContactNumber3
        _oLabelHeight.InnerText = _nClass._pHeight
        _oLabelWeight.InnerText = _nClass._pWeight
        _oLabelAlternateEmail.InnerText = _nClass._pAlternateEmail 'Gimay 20201120



    End Sub

    Public Sub RefreshFile()
        Dim _nClass As New cDalProfileLoader
        _nClass._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
        _nClass._pEmail = cSessionUser._pUserID
        ' _nClass.loadProfile()

        Dim _nDataTable As New DataTable
        '_nClass._pSubSelect("Attachment", "where EMAIL = '" & cSessionUser._pUserID & "' and  SeqID = '001'  and ModuleID = 'Change/Update Contact Informations' ;")
        _nClass._pSubSelect("Attachment", "where EMAIL = '" & _oLabelEmail.InnerText & "' and  SeqID = '001'  and ModuleID = 'Change/Update Contact Informations' ;")
        _nDataTable = _nClass._pDataTable

        If _nDataTable IsNot Nothing AndAlso _nDataTable.Rows.Count > 0 Then
            If cDalProfileLoader._pGIdName Is Nothing Or Not cDalProfileLoader._pGIdName = _nDataTable.Rows(0)("FileName").ToString() Then
                'If Session("GIDName") Is Nothing Or Not Session("GIDName") = _nDataTable.Rows(0)("FileName").ToString() Then
                'If Session("GIDChanged") = False Then 'Gimay 20201124
                _oTxtGovernmentID.Value = _nDataTable.Rows(0)("FileName").ToString()
                'cDalProfileLoader._pGIdName = _nDataTable.Rows(0)("FileName").ToString()
                'cDalProfileLoader._pGIdType = _nDataTable.Rows(0)("FileType").ToString()
                'cDalProfileLoader._pGIdData = _nDataTable.Rows(0)("FileData")
                Session("GIDName") = _nDataTable.Rows(0)("FileName").ToString()
                Session("GIDType") = _nDataTable.Rows(0)("FileType").ToString()
                Session("GIDByte") = _nDataTable.Rows(0)("FileData")
                'Else
                '    _oTxtGovernmentID.Value = Session("GIDName")
                'End If
            Else
                '_oTxtGovernmentID.Value = cDalProfileLoader._pGIdName
                _oTxtGovernmentID.Value = Session("GIDName")
            End If
        End If

        _nClass._pSubSelect("Attachment", " where EMAIL = '" & cSessionUser._pUserID & "' and  SeqID = '002'  and ModuleID = 'Change/Update Contact Informations' ;")
        _nDataTable = _nClass._pDataTable
        If _nDataTable IsNot Nothing AndAlso _nDataTable.Rows.Count > 0 Then
            If cDalProfileLoader._pSPAName Is Nothing Or cDalProfileLoader._pSPAName = _nDataTable.Rows(0)("FileName").ToString() Then
                'If Session("SPAName") Is Nothing Or Not Session("SPAName") = _nDataTable.Rows(0)("FileName").ToString() Then
                'If Session("SPAChanged") = False Then 'Gimay 20201124
                _oTxtSPA.Value = _nDataTable.Rows(0)("FileName").ToString()
                'cDalProfileLoader._pSPAName = _nDataTable.Rows(0)("FileName").ToString()
                'cDalProfileLoader._pSPAType = _nDataTable.Rows(0)("FileType").ToString()
                'cDalProfileLoader._pSPAData = _nDataTable.Rows(0)("FileData")

                Session("SPAName") = _nDataTable.Rows(0)("FileName").ToString()
                Session("SPAType") = _nDataTable.Rows(0)("FileType").ToString()
                Session("SPAByte") = _nDataTable.Rows(0)("FileData")
                'Else
                '    _oTxtSPA.Value = Session("SPAName")
                'End If
            Else
                '_oTxtSPA.Value = cDalProfileLoader._pSPAName
                _oTxtSPA.Value = Session("SPAName")
            End If
        End If

        _nClass._pSubSelect("Attachment", " where EMAIL = '" & cSessionUser._pUserID & "' and  SeqID = '003'  and ModuleID = 'Change/Update Contact Informations' ;")
        _nDataTable = _nClass._pDataTable
        If _nDataTable IsNot Nothing AndAlso _nDataTable.Rows.Count > 0 Then
            If cDalProfileLoader._pBRSecName Is Nothing Or cDalProfileLoader._pBRSecName = _nDataTable.Rows(0)("FileName").ToString() Then
                'If Session("BRSecName") Is Nothing Or Not Session("BRSecName") = _nDataTable.Rows(0)("FileName").ToString() Then
                '    If Session("BRSecChanged") = False Then 'Gimay 20201124
                _oTxtBRSec.Value = _nDataTable.Rows(0)("FileName").ToString()
                'cDalProfileLoader._pBRSecName =  _nDataTable.Rows(0)("FileName").ToString()
                'cDalProfileLoader._pBRSecType = _nDataTable.Rows(0)("FileType").ToString()
                'cDalProfileLoader._pBRSecData = _nDataTable.Rows(0)("FileData")

                Session("BRSecName") = _nDataTable.Rows(0)("FileName").ToString()
                Session("BRSecType") = _nDataTable.Rows(0)("FileType").ToString()
                Session("BRSecByte") = _nDataTable.Rows(0)("FileData")
                'Else
                '    _oTxtBRSec.Value = Session("BRSecName")
                'End If
            Else
                '_oTxtSPA.Value = cDalProfileLoader._pSPAName
                _oTxtBRSec.Value = Session("BRSecName")
            End If
        End If
        If _oTxtGovernmentID.Value Is Nothing Or String.IsNullOrEmpty(_oTxtGovernmentID.Value) Then _oTxtGovernmentID.Value = "No Attached File"
        If _oTxtSPA.Value Is Nothing Or String.IsNullOrEmpty(_oTxtSPA.Value) Then _oTxtSPA.Value = "No Attached File"
        If _oTxtBRSec.Value Is Nothing Or String.IsNullOrEmpty(_oTxtBRSec.Value) Then _oTxtBRSec.Value = "No Attached File"
    End Sub

    Sub snackbar(Color As String, Caption As String)
        If Color = "red" Then
            _oLabelSnackbar.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "Snackbar();", True)

        ElseIf Color = "green" Then
            _oLabelSnackbargreen.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "SnackbarGreen();", True)
        End If
    End Sub

    Private Function CapitalizeFirstLetter(ByVal str As String) As String
        Dim s As String = str
        s = StrConv(s, VbStrConv.ProperCase)
        Return s
    End Function

    Public Sub FileLoad(Additional)
        Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
        sb.Append("<script language='javascript'>")
        sb.Append(Additional)

        'Gimay 20201120 added alternate email
        sb.Append(" document.getElementById('_oTextFirstName').value = sessionStorage.getItem('_oTextFirstName'); " & _
                  " document.getElementById('_oTextMiddleName').value = sessionStorage.getItem('_oTextMiddleName'); " & _
                  " document.getElementById('_oTextLastName').value = sessionStorage.getItem('_oTextLastName'); " & _
                  " document.getElementById('_oTextSuffix').value = sessionStorage.getItem('_oTextSuffix'); " & _
                  " document.getElementById('_oTextBirthday').value = sessionStorage.getItem('_oTextBirthday'); " & _
                  " document.getElementById('_oTextAddress').value = sessionStorage.getItem('_oTextAddress'); " & _
                  " document.getElementById('_oTextBirthAddress').value = sessionStorage.getItem('_oTextBirthAddress'); " & _
                  " document.getElementById('_oSelectCitizenship').value = sessionStorage.getItem('_oSelectCitizenship'); " & _
                  " document.getElementById('_oSelectCivilStatus').value = sessionStorage.getItem('_oSelectCivilStatus'); " & _
                  " document.getElementById('_oTextTIN').value = sessionStorage.getItem('_oTextTIN'); " & _
                  " document.getElementById('_oTextContactNumber2').value = sessionStorage.getItem('_oTextContactNumber2'); " & _
                  " document.getElementById('_oTextContactNumber3').value = sessionStorage.getItem('_oTextContactNumber3'); " & _
                  " document.getElementById('_oTextContactNumber1').value = sessionStorage.getItem('_oTextContactNumber1'); " & _
                  " document.getElementById('_oTextHeight').value = sessionStorage.getItem('_oTextHeight'); " & _
                  " document.getElementById('_oTextWeight').value = sessionStorage.getItem('_oTextWeight'); " & _
                  " document.getElementById('_oTextProfession').value = sessionStorage.getItem('_oTextProfession'); " & _
                  " document.getElementById('_oCheckBoxResident').value = sessionStorage.getItem('_oCheckBoxResident'); " & _
                  " document.getElementById('_oTextAlternateEmail').value = sessionStorage.getItem('_oTextAlternateEmail'); " &
                  "")
        sb.Append("</script>")
        ClientScript.RegisterStartupScript(Me.[GetType](), "JSScript", sb.ToString())
    End Sub


    'Gimay 20201120
    Protected Sub Upload_Docs_new()
        Try
            If _oFileGovernmentID.PostedFile IsNot Nothing And _oFileGovernmentID.PostedFile.ContentLength > 0 Then
                Dim FileData As HttpPostedFile = _oFileGovernmentID.PostedFile
                Dim FileName As String = _oFileGovernmentID.PostedFile.FileName
                Dim FileType As String = _oFileGovernmentID.PostedFile.ContentType
                Dim fs As Stream = FileData.InputStream
                Dim br As New BinaryReader(fs)
                Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
                'cDalProfileLoader._pGIdName = FileName
                'cDalProfileLoader._pGIdType = FileType
                'cDalProfileLoader._pGIdData = bytes

                'Gimay 20201123
                Session("GIDName") = FileName
                Session("GIDType") = FileType
                Session("GIDByte") = bytes

                'Gimay 20201124
                Session("GIDChanged") = True
                'GIDName = FileName
                'GIDType = FileType
                'GIDByte = bytes
            End If

            If _oFileSPA.PostedFile IsNot Nothing And _oFileSPA.PostedFile.ContentLength Then
                Dim FileData As HttpPostedFile = _oFileSPA.PostedFile
                Dim FileName As String = _oFileSPA.PostedFile.FileName
                Dim FileType As String = _oFileSPA.PostedFile.ContentType
                Dim fs As Stream = FileData.InputStream
                Dim br As New BinaryReader(fs)
                Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
                'cDalProfileLoader._pSPAName = FileName
                'cDalProfileLoader._pSPAType = FileType
                'cDalProfileLoader._pSPAData = bytes

                'Gimay 20201123
                Session("SPAName") = FileName
                Session("SPAType") = FileType
                Session("SPAByte") = bytes

                'Gimay 20201124
                Session("SPAChanged") = True

                'SPAName = FileName
                'SPAType = FileType
                'SPAByte = bytes
            End If

            If _oFileBRSec.PostedFile IsNot Nothing And _oFileBRSec.PostedFile.ContentLength Then
                Dim FileData As HttpPostedFile = _oFileBRSec.PostedFile
                Dim FileName As String = _oFileBRSec.PostedFile.FileName
                Dim FileType As String = _oFileBRSec.PostedFile.ContentType
                Dim fs As Stream = FileData.InputStream
                Dim br As New BinaryReader(fs)
                Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
                'cDalProfileLoader._pBRSecName = FileName
                'cDalProfileLoader._pBRSecType = FileType
                'cDalProfileLoader._pBRSecData = bytes


                'Gimay 20201123
                Session("BRSecName") = FileName
                Session("BRSecType") = FileType
                Session("BRSecByte") = bytes

                'Gimay 20201123
                Session("BRSecChanged") = True

                'BRSecName = FileName
                'BRSecType = FileType
                'BRSecByte = bytes
            End If
        Catch ex As Exception

        Finally
            'FileLoad(" document.getElementById('_oLblGid').innerHTML = '" & cDalProfileLoader._pGIdName & "'; " &
            '          " document.getElementById('_oLblSPA').innerHTML = '" & cDalProfileLoader._pSPAName & "';" &
            '          " document.getElementById('_oLblBRSec').innerHTML = '" & cDalProfileLoader._pBRSecName & "';")

            'Gimay 20201123
            Dim file1, file2, file3 As String

            Try
                file1 = Session("GIDName").ToString
            Catch ex As Exception
                file1 = ""
            End Try

            Try
                file2 = Session("SPAName").ToString
            Catch ex As Exception
                file2 = ""
            End Try

            Try
                file3 = Session("BRSecName").ToString
            Catch ex As Exception
                file3 = ""
            End Try

            FileLoad(" document.getElementById('_oLblGid').innerHTML = '" & file1 & "'; " &
                     " document.getElementById('_oLblSPA').innerHTML = '" & file2 & "';" &
                     " document.getElementById('_oLblBRSec').innerHTML = '" & file3 & "';")

            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            sb.Append("<script language='javascript'>")

            'Gimay 20201120 added alternate email
            sb.Append("$('#myModal').modal('show'); " &
                      "")
            sb.Append("</script>")
            ClientScript.RegisterStartupScript(Me.[GetType](), "JSScriptxxxx", sb.ToString())
        End Try
    End Sub


    'Sub upload_Docs(file)
    '    'Dim Exists As Boolean
    '    'Dim Email As String = cSessionUser._pUserID
    '    Select Case file
    '        Case "file1"
    '            If _oFileGovernmentID.PostedFile IsNot Nothing And _oFileGovernmentID.PostedFile.ContentLength > 0 Then
    '                Dim FileData As HttpPostedFile = _oFileGovernmentID.PostedFile
    '                Dim FileName As String = _oFileGovernmentID.PostedFile.FileName
    '                Dim FileType As String = _oFileGovernmentID.PostedFile.ContentType
    '                Dim fs As Stream = FileData.InputStream
    '                Dim br As New BinaryReader(fs)
    '                Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
    '                cDalProfileLoader._pGIdName = FileName
    '                cDalProfileLoader._pGIdType = FileType
    '                cDalProfileLoader._pGIdData = bytes
    '            End If
    '        Case "file2"
    '            If _oFileSPA.PostedFile IsNot Nothing And _oFileSPA.PostedFile.ContentLength Then
    '                Dim FileData As HttpPostedFile = _oFileSPA.PostedFile
    '                Dim FileName As String = _oFileSPA.PostedFile.FileName
    '                Dim FileType As String = _oFileSPA.PostedFile.ContentType
    '                Dim fs As Stream = FileData.InputStream
    '                Dim br As New BinaryReader(fs)
    '                Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
    '                cDalProfileLoader._pSPAName = FileName
    '                cDalProfileLoader._pSPAType = FileType
    '                cDalProfileLoader._pSPAData = bytes
    '            End If
    '        Case "file3"
    '            If _oFileBRSec.PostedFile IsNot Nothing And _oFileBRSec.PostedFile.ContentLength Then
    '                Dim FileData As HttpPostedFile = _oFileBRSec.PostedFile
    '                Dim FileName As String = _oFileBRSec.PostedFile.FileName
    '                Dim FileType As String = _oFileBRSec.PostedFile.ContentType
    '                Dim fs As Stream = FileData.InputStream
    '                Dim br As New BinaryReader(fs)
    '                Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
    '                cDalProfileLoader._pBRSecName = FileName
    '                cDalProfileLoader._pBRSecType = FileType
    '                cDalProfileLoader._pBRSecData = bytes
    '            End If
    '    End Select




    'End Sub

    Public ReadOnly Property getGID As String 'Gimay 20201126
        Get
            Return Session("GIdName")
        End Get
    End Property

    Public ReadOnly Property getSPA As String 'Gimay 20201126
        Get
            Return Session("SPAName")
        End Get
    End Property

    Public ReadOnly Property getBRSec As String 'Gimay 20201126
        Get
            Return Session("BRSecName")
        End Get
    End Property

    Sub upload_Docs()
        Dim _nclass As New cDalProfileLoader
        _nclass._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
        Dim Exists As Boolean
        Dim Email As String = cSessionUser._pUserID
        Dim RefNo As String = "0" 'Appointment ID        
        Dim ModuleID As String = "Change/Update Contact Informations"  ' Appointment Desc
        'Dim AcctID As String = cSessionLoader._pTDN
        Dim Office As String = ""

        If _oFileGovernmentID.PostedFile IsNot Nothing And _oFileGovernmentID.PostedFile.ContentLength > 0 Then
            Dim SeqID As String = "001" 'image ID
            Dim ReqDesc As String = "Requirement 1"
            Dim FileData As HttpPostedFile = _oFileGovernmentID.PostedFile
            Dim FileName As String = _oFileGovernmentID.PostedFile.FileName
            Dim FileType As String = _oFileGovernmentID.PostedFile.ContentType
            Dim fs As Stream = FileData.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))

            'check if file already exists
            _nclass._pSubSelectImage(Email, ModuleID, "Government ID", SeqID, Exists)
            If Exists = True Then
                'update uploaded file
                _nclass._pSubUpdateAttachFiles(Email, RefNo, ModuleID, "Government ID", SeqID, bytes, FileName, FileType)
            Else
                'upload new file
                _nclass._pSubInsertAttachFiles(Email, RefNo, ModuleID, "Government ID", SeqID, bytes, FileName, FileType, ReqDesc, Office)
            End If
            'cDalAppointment._pFile001 = FileName
            'lblup1.InnerText = FileName
        End If

        If _oFileSPA.PostedFile IsNot Nothing And _oFileSPA.PostedFile.ContentLength > 0 Then
            Dim SeqID As String = "002" 'image ID
            Dim ReqDesc As String = "Requirement 2"
            Dim FileData As HttpPostedFile = _oFileSPA.PostedFile
            Dim FileName As String = _oFileSPA.PostedFile.FileName
            Dim FileType As String = _oFileSPA.PostedFile.ContentType
            Dim fs As Stream = FileData.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))

            'check if file already exists            

            _nclass._pSubSelectImage(Email, ModuleID, "Special Power of Attorney", SeqID, Exists)
            If Exists = True Then
                'update uploaded file
                _nclass._pSubUpdateAttachFiles(Email, RefNo, ModuleID, "Special Power of Attorney", SeqID, bytes, FileName, FileType)
            Else
                'upload new file
                _nclass._pSubInsertAttachFiles(Email, RefNo, ModuleID, "Special Power of Attorney", SeqID, bytes, FileName, FileType, ReqDesc, Office)
            End If

            'cDalAppointment._pFile001 = FileName
            'lblup1.InnerText = FileName
        End If

        If _oFileBRSec.PostedFile IsNot Nothing And _oFileBRSec.PostedFile.ContentLength > 0 Then
            Dim SeqID As String = "003" 'image ID
            Dim ReqDesc As String = "Requirement 3"
            Dim FileData As HttpPostedFile = _oFileBRSec.PostedFile
            Dim FileName As String = _oFileBRSec.PostedFile.FileName
            Dim FileType As String = _oFileBRSec.PostedFile.ContentType
            Dim fs As Stream = FileData.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))

            'check if file already exists
            _nclass._pSubSelectImage(Email, ModuleID, "Board Resolution/Secretary Certificate", SeqID, Exists)
            If Exists = True Then
                'update uploaded file
                _nclass._pSubUpdateAttachFiles(Email, RefNo, ModuleID, "Board Resolution/Secretary Certificate", SeqID, bytes, FileName, FileType)
            Else
                'upload new file
                _nclass._pSubInsertAttachFiles(Email, RefNo, ModuleID, "Board Resolution/Secretary Certificate", SeqID, bytes, FileName, FileType, ReqDesc, Office)
            End If
            'cDalAppointment._pFile001 = FileName
            'lblup1.InnerText = FileName
        End If



    End Sub

    Sub Download_Selected(seqid, userid)
        Try
            Select Case seqid
                Case "001"
                    If _oTxtGovernmentID.Value Is Nothing Or String.IsNullOrEmpty(_oTxtGovernmentID.Value) Then
                        snackbar("red", "No Attached file")
                        Exit Sub
                    End If
                Case "002"
                    If _oTxtSPA.Value Is Nothing Or String.IsNullOrEmpty(_oTxtSPA.Value) Then
                        snackbar("red", "No Attached file")
                        Exit Sub
                    End If
                Case "003"
                    If _oTxtBRSec.Value Is Nothing Or String.IsNullOrEmpty(_oTxtBRSec.Value) Then
                        snackbar("red", "No Attached file")
                        Exit Sub
                    End If
            End Select

            Dim _nclass As New cDalProfileLoader
            _nclass._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _mSqlCommand As SqlCommand
            Dim _mDataTable As DataTable
            Dim filetype As String
            Dim bytes As Byte()
            Dim _nFileExtn As String
            Dim _mFilename As String
            _nQuery = "select * from attachment where SEQID ='" & seqid & "' and EMAIL ='" & userid & "'"
            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_OAIMS)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, cGlobalConnections._pSqlCxn_OAIMS) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    bytes = DirectCast(_nSqlDr.GetValue(_nSqlDr.GetOrdinal(hdnData.Value)), Byte())
                    _nFileExtn = UCase(_nSqlDr.GetValue(_nSqlDr.GetOrdinal(hdnType.Value)))
                    _mFilename = _nSqlDr.GetValue(_nSqlDr.GetOrdinal(hdnName.Value))
                    If _nFileExtn = "TEXT/PLAIN" Then
                        _nFileExtn = ".TXT"
                    End If
                    If _nFileExtn = "APPLICATION/PDF" Then
                        _nFileExtn = ".PDF"
                    End If
                    If _nFileExtn = "IMAGE/PNG" Then
                        _nFileExtn = ".PNG"
                    End If
                    If _nFileExtn = "IMAGE/JPEG" Then
                        _nFileExtn = ".JPG"
                    End If

                End If
                If _nFileExtn = ".PDF" Then
                    Response.Clear()
                    Response.ContentType = "application/pdf"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()

                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                    'Response.Write("<script>window.open('AssessorNewProperty.aspx','_blank');</script>")
                End If
                If _nFileExtn = ".TXT" Then
                    Response.Clear()
                    Response.ContentType = "text/plain"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()
                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                    'Response.Write("<script>window.open('ApplicationRequest.aspx','_blank');</script>")
                End If
                If _nFileExtn = ".PNG" Then
                    Response.Clear()
                    Response.ContentType = "image/png"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()
                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                End If

                If _nFileExtn = ".JPG" Then
                    Response.Clear()
                    Response.ContentType = "image/jpeg"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()
                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        Select Case cSessionUser._pOffice
            Case "TAXPAYER"
                Me.MasterPageFile = "~/WebPortal/OSMainPage.master"
            Case "ASSESSOR"
                Me.MasterPageFile = "~/WebPortal/ASSESSORMaster.master"
            Case "BPLO"
                Me.MasterPageFile = "~/WebPortal/BPLOMaster.master"
        End Select
    End Sub


    Public Sub UpdateFiles()
        Dim _mSqlCmd As SqlCommand
        Dim _mSqlReader As SqlDataReader
        Dim temp As String
        Dim Counter As Boolean
        Dim _nQuery As String = ""
        Dim _mCheckGId, _mCheckSPA, _mCheckBRSec As Boolean
        Try
            _nQuery = "SELECT SEQID, MODULEID FROM ATTACHMENT where EMAIL = '" & cSessionUser._pUserID & "' and MODULEID = 'Change/Update Contact Informations'"
            _mSqlCmd = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_OAIMS)
            _mSqlReader = _mSqlCmd.ExecuteReader
            _nQuery = ""
            Dim _ModuleID As String = Nothing, _Requirement As String = Nothing, _AcctID As String = Nothing
            Dim _FileName As String = Nothing, _FileType As String = Nothing, _FileData As Byte() = Nothing
            Dim _ParamData As String = Nothing, _Seqid As String = Nothing
            If _mSqlReader.HasRows Then
                While _mSqlReader.Read()
                    Select Case _mSqlReader.Item("SEQID")
                        Case "001"
                            _ModuleID = "Change/Update Contact Informations"
                            _Requirement = "Requirement 1"
                            _AcctID = "Government ID"
                            '_FileName = GIDName
                            '_FileType = GIDType
                            '_FileData = GIDByte

                            _FileName = Session("GIDName")
                            _FileType = Session("GIDType")
                            _FileData = Session("GIDByte")

                            _ParamData = "@GIdData"
                            _mCheckGId = True
                        Case "002"
                            _ModuleID = "Change/Update Contact Informations"
                            _Requirement = "Requirement 2"
                            _AcctID = "Special Power of Attorney"
                            '_FileName = SPAName
                            '_FileType = SPAType
                            '_FileData = SPAByte

                            _FileName = Session("SPAName")
                            _FileType = Session("SPAType")
                            _FileData = Session("SPAByte")

                            _ParamData = "@SPAData"
                            _mCheckSPA = True
                        Case "003"
                            _ModuleID = "Change/Update Contact Informations"
                            _Requirement = "Requirement 3"
                            _AcctID = "Board Resolution/Secretary Certificate"
                            '_FileName = BRSecName
                            '_FileType = BRSecType
                            '_FileData = BRSecByte

                            _FileName = Session("BRSecName")
                            _FileType = Session("BRSecType")
                            _FileData = Session("BRSecByte")
                            _ParamData = "@BRSecData"
                            _mCheckBRSec = True
                    End Select
                    If IsDBNull(_mSqlReader.Item("SEQID")) Then
                        temp = 1
                        Select Case _mSqlReader.Item("SEQID")
                            Case "001" : _mCheckGId = True : Case "002" : _mCheckSPA = True : Case "003" : _mCheckBRSec = True
                        End Select
                        _nQuery += "Insert into Attachment(EMAIL,REFNO,MODULEID,ACCTID,SEQID,FileData,FileName,FileType,ReqDesc,OFFICE) " & _
                            "VALUES ('" & cSessionUser._pUserID & "','0','" & _ModuleID & "','" & _AcctID & "', '" & _mSqlReader.Item("SEQID") & ", " & _ParamData & _
                            _FileName & "','" & _FileType & "', '" & _Requirement & "','BPLO'); "
                    Else
                        _nQuery += "update Attachment set FileData = " & _ParamData & ", FileName = '" & _FileName & "', FileType = '" & _FileType & "' where EMAIL = '" & cSessionUser._pUserID & _
                                "' and SeqID = '" & _mSqlReader.Item("SEQID") & "'  and MODULEID = '" & _ModuleID & "' ;"
                    End If
                End While
            End If
            _FileName = Nothing
            _FileType = Nothing
            _FileData = Nothing
            For a As Integer = 0 To 2
                Select Case False
                    Case _mCheckGId
                        _ModuleID = "Change/Update Contact Informations"
                        _Requirement = "Requirement 1"
                        _AcctID = "Government ID"
                        _FileName = Session("GIDName")
                        _FileType = Session("GIDType")
                        _FileData = Session("GIDByte")
                        _ParamData = "@GIdData"
                        _mCheckGId = True
                        _Seqid = "001"
                    Case _mCheckSPA
                        _ModuleID = "Change/Update Contact Informations"
                        _Requirement = "Requirement 2"
                        _AcctID = "Special Power of Attorney"
                        _FileName = Session("SPAName")
                        _FileType = Session("SPAType")
                        _FileData = Session("SPAByte")
                        _ParamData = "@SPAData"
                        _mCheckSPA = True
                        _Seqid = "002"
                    Case _mCheckBRSec
                        _ModuleID = "Change/Update Contact Informations"
                        _Requirement = "Requirement 3"
                        _AcctID = "Board Resolution/Secretary Certificate"
                        _FileName = Session("BRSecName")
                        _FileType = Session("BRSecType")
                        _FileData = Session("BRSecByte")
                        _ParamData = "@BRSecData"
                        _mCheckBRSec = True
                        _Seqid = "003"
                End Select
                If Not _FileData Is Nothing Then
                    _nQuery += "Insert into Attachment(EMAIL,REFNO,MODULEID,ACCTID,SEQID,FileData,FileName,FileType,ReqDesc,OFFICE) " & _
                            "VALUES ('" & cSessionUser._pUserID & "','0','" & _ModuleID & "','" & _AcctID & "', '" & _Seqid & "', " & _ParamData & " ,'" & _FileName & "','" & _FileType & "', '" & _Requirement & "','BPLO'); "
                End If

                _FileName = Nothing
                _FileType = Nothing
                _FileData = Nothing
            Next

            _mSqlCmd = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_OAIMS)

            With _mSqlCmd.Parameters
                If Not Session("BRSecByte") Is Nothing Then
                    .AddWithValue("@GIdData", Session("GIDByte"))
                End If
                If Not Session("SPAByte") Is Nothing Then
                    .AddWithValue("@SPAData", Session("SPAByte"))
                End If
                If Not Session("BRSecByte") Is Nothing Then
                    .AddWithValue("@BRSecData", Session("BRSecByte"))
                End If
            End With

            _mSqlCmd.ExecuteNonQuery()
            _mSqlCmd.Dispose()
        Catch ex As Exception

        End Try
    End Sub

End Class