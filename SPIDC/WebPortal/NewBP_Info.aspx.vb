Imports System
Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
Imports System.Linq
Imports System.Data.SqlClient
Imports VB.NET.Methods

Public Class NewBP_Info
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal eQ As System.EventArgs) Handles Me.Load
        Try
            get_Info(Request.QueryString("AppID"), cSessionUser._pUserID)
        Catch ex As Exception

        End Try

    End Sub
    Sub get_Info(ByVal AppID As String, ByVal Email As String)

        Try
            Dim _nClass As New cDalNewBP
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            With _nClass
                If .Get_NewBPInfo(AppID) Then
                    txt_AppID.Value = .Application_ID
                    txt_AppStatus.Value = .Status
                    txt_B_LotNo1.Value = .B_LotNo
                    txt_BldgName1.Value = .B_BldgName
                    txt_BldgName2.Value = .G_BldgName
                    txt_BlockNo1.Value = .B_BlockNo
                    txt_BlockNo2.Value = .G_BlockNo
                    txt_Brgy1.Value = .B_Brgy
                    txt_Brgy2.Value = .G_Brgy
                    txt_BusinessName.Value = .A_BusName
                    txt_CityMunicipality1.Value = .B_CityMunicipality
                    txt_CityMunicipality2.Value = .G_CityMunicipality
                    txt_DateEsta.Value = .Date_Esta
                    txt_DelMotor.Value = .F_MotorNo
                    txt_DelVanTruck.Value = .F_VanTruckNo
                    txt_DtiSecCda.Value = .A_DtiSecCda
                    txt_HouseNo1.Value = .B_HouseNo
                    txt_HouseNo2.Value = .G_HouseNo
                    txt_LotNo2.Value = .G_LotNo
                    txt_MobileNo.Value = .C_MobileNo
                    txt_Nationality.Value = .D_CTZNDESC
                    txt_NoFemaleEmp.Value = .F_FemaleEmpNo
                    txt_NoMaleEmp.Value = .F_MaleEmpNo
                    txt_NoResidingEmp.Value = .F_ResideEmpNo
                    txt_OwnType.Value = .A_Ownership
                    txt_Province1.Value = .B_Province
                    txt_Province2.Value = .G_Province
                    txt_Sole_Fname.Value = .D_Fname
                    txt_Sole_Lname.Value = .D_Lname
                    txt_Sole_Mname.Value = .D_Mname
                    txt_Sole_Suffix.Value = .D_Suffix
                    txt_Street1.Value = .B_Street
                    txt_Street2.Value = .G_Street
                    txt_Subd1.Value = .B_Subd
                    txt_Subd2.Value = .G_Subd
                    txt_TelNo.Value = .C_TelNo
                    txt_TIN.Value = .A_TIN
                    txt_ZipCode1.Value = .B_ZipCode
                    txt_ZipCode2.Value = .G_ZipCode
                    div_NoB.InnerHtml = .H_Nature

                    Load_Requirements(AppID)
                End If



            End With
           

        Catch ex As Exception

        End Try


    End Sub

    Sub Load_Requirements(ByVal AppID As String)
        Try
            Dim reqCount As Integer
            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pSubGetAttachmentsSubmitted(AppID, reqCount)
            If reqCount = 0 Then
                div_Requirements.Style.Add("display", "none")
            Else
                div_Requirements.Style.Add("display", "")
                _GVRequirements.DataSource = _nClass._mDataTable
                _GVRequirements.DataBind()
            End If

        Catch ex As Exception

        End Try
    End Sub

End Class