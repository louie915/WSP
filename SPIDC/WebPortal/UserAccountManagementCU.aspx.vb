Public Class UserAccountManagementCU
    Inherits System.Web.UI.Page    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Get_UserAccount_Data()
                Enable_Fields()
            Else

            End If

            '----------------------------------
        Catch ex As Exception
            'snackbar("red", "Transaction : " & ex.Message)
            'GridErr = True
            '_mSubShowBlank()
        End Try

    End Sub
    Sub Get_UserAccount_Data()
        Try
            'Dim LastID As String = cDalUserAccountManagement._pSelected_IDNO                
            Dim _nClass As New cDalUserAccountManagement
            _nClass._pCxn = cGlobalConnections._pSqlCxn_OAIMS
            '_nClass._pIDNo = LastID
            _nClass._pIDNo = cDalUserAccountManagement._pSelected_IDNO
            _nClass._pSubSelectSpecificRecord()
            _otxt_EmailAddress.Text = _nClass._pUserID
            _otxt_Lastname.Text = _nClass._pLastName
            _otxt_Firstname.Text = _nClass._pFirstName
            _otxt_Middlename.Text = _nClass._pMiddleName
            _otxt_NameSuffix.Text = _nClass._pExtnName
            _otxt_Office.Text = _nClass._pOffice
            _otxt_Birthdate.Value = Convert.ToDateTime(_nClass._pBirthDate).ToString("yyyy-MM-dd")
            _otxt_BirthPlace.Value = _nClass._pBirthPlace
            _otxt_Address.Value = _nClass._pAddress
            _otxt_UserLevel.Value = _nClass._pUserLevel
            _otxt_Gender.Value = _nClass._pSetupGender
            '_otxt_Citizenship.Value = (_nClass._pCitizenship).ToLower.First
            If String.IsNullOrEmpty(_nClass._pCitizenship) Then

            Else
                If _nClass._pCitizenship.Length > 1 Then
                    _otxt_Citizenship.Value = _nClass._pCitizenship.Substring(0, 1).ToLower() + _nClass._pCitizenship.Substring(1)
                ElseIf _nClass._pCitizenship.Length = 1 Then
                    _otxt_Citizenship.Value = _nClass._pCitizenship.ToLower()
                End If
            End If
            
            _otxt_CivilStatus.Value = _nClass._pSetupCivilStatus
            _otxt_Profession.Value = _nClass._pProfession
            _otxt_TIN.Value = _nClass._pTIN
            _otxt_Contact_Number.Value = _nClass._pContactCp
            _otxt_Contact_OtherNumber.Value = _nClass._pContactCpAlt
            _otxt_Contact_Telephone.Value = _nClass._pContactTel
            _otxt_Height.Value = _nClass._pHeight
            _otxt_Weight.Value = _nClass._pWeight
            _otxt_EmailAddress.ReadOnly = True
            _otxt_Office.ReadOnly = True
            '----------------------------------  
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Enable_Fields()
        '_otxt_EmailAddress.ReadOnly = Not _otxt_EmailAddress.ReadOnly
        _otxt_Lastname.ReadOnly = Not _otxt_Lastname.ReadOnly
        _otxt_Firstname.ReadOnly = Not _otxt_Firstname.ReadOnly
        _otxt_Middlename.ReadOnly = Not _otxt_Middlename.ReadOnly
        _otxt_NameSuffix.ReadOnly = Not _otxt_NameSuffix.ReadOnly        
        _otxt_Birthdate.Disabled = Not _otxt_Birthdate.Disabled
        _otxt_BirthPlace.Disabled = Not _otxt_BirthPlace.Disabled
        _otxt_Address.Disabled = Not _otxt_Address.Disabled
        _otxt_UserLevel.Disabled = Not _otxt_UserLevel.Disabled
        _otxt_Gender.Disabled = Not _otxt_Gender.Disabled
        _otxt_Citizenship.Disabled = Not _otxt_Citizenship.Disabled
        _otxt_CivilStatus.Disabled = Not _otxt_CivilStatus.Disabled
        _otxt_Profession.Disabled = Not _otxt_Profession.Disabled
        _otxt_TIN.Disabled = Not _otxt_TIN.Disabled
        _otxt_Contact_Number.Disabled = Not _otxt_Contact_Number.Disabled
        _otxt_Contact_OtherNumber.Disabled = Not _otxt_Contact_OtherNumber.Disabled
        _otxt_Contact_Telephone.Disabled = Not _otxt_Contact_Telephone.Disabled
        _otxt_Height.Disabled = Not _otxt_Height.Disabled
        _otxt_Weight.Disabled = Not _otxt_Weight.Disabled
        _obtn_Save.Disabled = Not _obtn_Save.Disabled
        _obtn_Cancel.Disabled = Not _obtn_Cancel.Disabled
        _obtn_Edit.Disabled = Not _obtn_Edit.Disabled
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As EventArgs)
        Enable_Fields()
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        Get_UserAccount_Data()
        Enable_Fields()
    End Sub


    Protected Sub _oBtnSaveChanges_ServerClick(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim _nClass As New cDalUserAccountManagement
            _nClass._pCxn = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pUserID = _otxt_EmailAddress.Text

            _nClass._pLastName = _otxt_Lastname.Text
            _nClass._pFirstName = _otxt_Firstname.Text
            _nClass._pMiddleName = _otxt_Middlename.Text
            _nClass._pExtnName = _otxt_NameSuffix.Text
            _nClass._pSetupGender = _otxt_Gender.Value
            _nClass._pBirthDate = _otxt_Birthdate.Value
            _nClass._pProfession = _otxt_Profession.Value
            _nClass._pAddress = _otxt_Address.Value
            _nClass._pBirthPlace = _otxt_BirthPlace.Value
            _nClass._pCivilStatus = _otxt_CivilStatus.Value
            _nClass._pCitizenship = _otxt_Citizenship.Value
            _nClass._pTIN = _otxt_TIN.Value
            _nClass._pContactCp = _otxt_Contact_Number.Value
            _nClass._pContactCpAlt = _otxt_Contact_OtherNumber.Value
            _nClass._pContactTel = _otxt_Contact_Telephone.Value
            _nClass._pHeight = _otxt_Height.Value
            _nClass._pWeight = _otxt_Weight.Value
            _nClass._pUserLevel = _otxt_UserLevel.Value
            _nClass._pOffice = _otxt_Office.Text
            '_nClass._pResident = _oChkBoxRes.Value

            _nClass._pSubUpdate()
            'loadP()

            'snackbar("green", "Profile changes successfully saved")
        Catch ex As Exception
            'snackbar("red", "Error on saving profile changes")
        End Try
        Get_UserAccount_Data()
        Enable_Fields()
    End Sub

End Class