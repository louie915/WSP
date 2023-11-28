

#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods
Imports System.Web.HttpContext


#End Region

Public Class cDalCBP


#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Public Shared _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader


#End Region

#Region "Properties Data"
    Public WriteOnly Property _pSqlConnection() As SqlConnection
        Set(value As SqlConnection)
            _mSqlCon = value
        End Set
    End Property
    Public ReadOnly Property _pQuery() As String
        Get
            Return _mQuery
        End Get
    End Property
    Public ReadOnly Property _pSqlCommand() As SqlCommand
        Get
            Return _mSqlCommand
        End Get
    End Property
    Public ReadOnly Property _pDataTable() As DataTable
        Get
            Try
                '----------------------------------
                Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
                _mDataTable = New DataTable
                _nSqlDataAdapter.Fill(_mDataTable)

                Return _mDataTable
                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property
    Public ReadOnly Property _pSqlDataReader() As SqlDataReader
        Get
            Try
                '----------------------------------
                _mSqlDataReader = _mSqlCommand.ExecuteReader

                Return _mSqlDataReader
                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property
#End Region

#Region "Variables Field"
    Public Shared LBP_MerchantCode As String
#End Region

#Region "Properties Field"

#End Region

#Region "Properties Field Original"

#End Region

#Region "Routine Command"
    Public Sub _pSubSelectNewBP()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "" & _
            "SELECT Application_ID,IIF(A_OWNERSHIP='Single',D_Lname + ' ' + D_FName +' ' + D_Mname + ' ' + D_Suffix,E_Lname + ' ' + E_FName +' ' + E_Mname + ' ' + E_Suffix) AS 'OWNER', A_BusName, [Status], (G_HouseNo + ', ' + G_BldgName + ', ' + G_LotNo + ', ' + G_BlockNo + ', ' + G_Street + ', ' + G_Brgy + ', ' + G_Subd + ', ' + G_CityMunicipality + ', ' + G_Province + ', ' + G_ZipCode) as 'BusAdd'" & _
            " FROM NEWBP_DRAFT where UserID='" & cSessionUser._pUserID & "'"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)


            With _mSqlCommand.Parameters
            End With
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectNewBPSubmitted()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "SELECT  Application_ID,Date_Submitted as 'APP_DATE',userid as 'EMAILADDR',IIF(A_OWNERSHIP='Single',D_Lname + ' ' + D_FName +' ' + D_Mname + ' ' + D_Suffix,E_Lname + ' ' + E_FName +' ' + E_Mname + ' ' + E_Suffix) AS 'OwnerName', A_BusName as 'COMMNAME', [Status] FROM NEWBP_DRAFT order by Date_Submitted asc"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)


            With _mSqlCommand.Parameters
            End With
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubGetDate(ByRef getdate As String)
        Try
            '----------------------------------       
            Dim _nQuery As String = Nothing
            _nQuery = "select getdate() as 'getdate'"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)

            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _igetdate As Integer = .GetOrdinal("getdate")
                    '----------------------------------
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                getdate = ._pReturnString(_nSqlDataReader(_igetdate))
                            Loop
                        End If

                    End With
                End With

                _nSqlDataReader.Close()
            End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubCheckIfExist(ByRef DraftExists As Boolean, ByRef Application_ID As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select * from NewBP_Draft where userID = '" & cSessionUser._pUserID & "' and Submitted = 0 "
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iApplication_ID As Integer = .GetOrdinal("Application_ID")
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                DraftExists = True
                                Application_ID = ._pReturnString(_nSqlDataReader(_iApplication_ID))
                            Loop
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubDisplayExisting(ByVal Application_ID As String, ByVal UserID As String,
                                ByRef A As String, ByRef B As String, ByRef C As String,
                                ByRef D As String, ByRef E As String, ByRef F As String,
                                ByRef G As String, _
                                ByRef H_Capital As String,
                                ByRef H_Nature As String,
                                ByRef H_Owned As String,
                                ByRef H_TDN As String,
                                ByRef H_PIN As String,
                                ByRef H_GovIncentive As String,
                                ByRef H_BusAct As String,
                                ByRef H_D1 As Byte(), ByRef H_N1 As String, ByRef H_T1 As String, _
                                ByRef I_D1 As Byte(), ByRef I_N1 As String, ByRef I_T1 As String, _
                                ByRef I_D2 As Byte(), ByRef I_N2 As String, ByRef I_T2 As String, _
                                ByRef I_D3 As Byte(), ByRef I_N3 As String, ByRef I_T3 As String, _
                                ByRef I_D4 As Byte(), ByRef I_N4 As String, ByRef I_T4 As String, _
                                ByRef I_D5 As Byte(), ByRef I_N5 As String, ByRef I_T5 As String, _
                                ByRef I_D6 As Byte(), ByRef I_N6 As String, ByRef I_T6 As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "SELECT  ([A_Ownership] +';'+ [A_DtiSecCda]  +';'+ [A_BusName] +';'+ [A_TIN]) as 'A'" & _
     ",([B_HouseNo] +';'+ [B_BldgName] +';'+ [B_LotNo]  +';'+ [B_BlockNo]+';'+ [B_Street]+';'+ [B_Brgy]+';'+ [B_Subd]+';'+ [B_CityMunicipality]+';'+ [B_Province]+';'+ [B_ZipCode]) as 'B'" & _
     ",([C_TelNo]+';'+[C_MobileNo]+';'+[C_Email]) as 'C'" & _
     ",([D_Lname]+';'+[D_Fname]+';'+[D_Mname]+';'+[D_Suffix]) as 'D'" & _
     ",([E_Lname]+';'+[E_Fname]+';'+[E_Mname]+';'+[E_Suffix]+';'+[E_Nationality]) as 'E'" & _
     ",([F_BusArea]+';'+[F_FlrArea]+';'+[F_MaleEmpNo]+';'+[F_FemaleEmpNo]+';'+[F_ResideEmpNo]+';'+[F_VanTruckNo]+';'+[F_MotorNo]) as 'F'" & _
     ",([G_HouseNo]+';'+[G_BldgName]+';'+[G_LotNo]+';'+[G_BlockNo]+';'+[G_Street]+';'+[G_Brgy]+';'+[G_Subd]+';'+[G_CityMunicipality]+';'+[G_Province]+';'+[G_ZipCode]) as 'G'" & _
     ",* " & _
     "FROM [NewBP_Draft]where userID = '" & cSessionUser._pUserID & "' and Submitted = 0 "


            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iA As Integer = .GetOrdinal("A")
                    Dim _iB As Integer = .GetOrdinal("B")
                    Dim _iC As Integer = .GetOrdinal("C")
                    Dim _iD As Integer = .GetOrdinal("D")
                    Dim _iE As Integer = .GetOrdinal("E")
                    Dim _iF As Integer = .GetOrdinal("F")
                    Dim _iG As Integer = .GetOrdinal("G")
                    Dim _iH_Capital As Integer = .GetOrdinal("H_Capital")
                    Dim _iH_Nature As Integer = .GetOrdinal("H_Nature")
                    Dim _iH_Owned As Integer = .GetOrdinal("H_Owned")
                    Dim _iH_TDN As Integer = .GetOrdinal("H_TDN")
                    Dim _iH_PIN As Integer = .GetOrdinal("H_PIN")
                    Dim _iH_GovIncentive As Integer = .GetOrdinal("H_GovIncentive")
                    Dim _iH_BusAct As Integer = .GetOrdinal("H_BusAct")

                    Dim _iH_D1 As Integer = .GetOrdinal("H_GovIncentiveFileData")
                    Dim _iH_N1 As Integer = .GetOrdinal("H_GovIncentiveFileName")
                    Dim _iH_T1 As Integer = .GetOrdinal("H_GovIncentiveFileType")

                    Dim _iI_D1 As Integer = .GetOrdinal("I_OwnerPicFileData")
                    Dim _iI_N1 As Integer = .GetOrdinal("I_OwnerPicFileName")
                    Dim _iI_T1 As Integer = .GetOrdinal("I_OwnerPicFileType")

                    Dim _iI_D2 As Integer = .GetOrdinal("I_BusEstPicFileData")
                    Dim _iI_N2 As Integer = .GetOrdinal("I_BusEstPicFileName")
                    Dim _iI_T2 As Integer = .GetOrdinal("I_BusEstPicFileType")

                    Dim _iI_D3 As Integer = .GetOrdinal("I_BusMapPicFileData")
                    Dim _iI_N3 As Integer = .GetOrdinal("I_BusMapPicFileName")
                    Dim _iI_T3 As Integer = .GetOrdinal("I_BusMapPicFileType")

                    Dim _iI_D4 As Integer = .GetOrdinal("I_AppFormFileData")
                    Dim _iI_N4 As Integer = .GetOrdinal("I_AppFormFileName")
                    Dim _iI_T4 As Integer = .GetOrdinal("I_AppFormFileType")

                    Dim _iI_D5 As Integer = .GetOrdinal("I_DtiSecCdaFileData")
                    Dim _iI_N5 As Integer = .GetOrdinal("I_DtiSecCdaFileName")
                    Dim _iI_T5 As Integer = .GetOrdinal("I_DtiSecCdaFileType")

                    Dim _iI_D6 As Integer = .GetOrdinal("I_TINFileData")
                    Dim _iI_N6 As Integer = .GetOrdinal("I_TINFileName")
                    Dim _iI_T6 As Integer = .GetOrdinal("I_TINFileType")



                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                A = ._pReturnString(_nSqlDataReader(_iA))
                                B = ._pReturnString(_nSqlDataReader(_iB))
                                C = ._pReturnString(_nSqlDataReader(_iC))
                                D = ._pReturnString(_nSqlDataReader(_iD))
                                E = ._pReturnString(_nSqlDataReader(_iE))
                                F = ._pReturnString(_nSqlDataReader(_iF))
                                G = ._pReturnString(_nSqlDataReader(_iG))

                                H_Capital = ._pReturnString(_nSqlDataReader(_iH_Capital))
                                H_Nature = ._pReturnString(_nSqlDataReader(_iH_Nature))
                                H_Owned = ._pReturnString(_nSqlDataReader(_iH_Owned))
                                H_TDN = ._pReturnString(_nSqlDataReader(_iH_TDN))
                                H_PIN = ._pReturnString(_nSqlDataReader(_iH_PIN))
                                H_GovIncentive = ._pReturnString(_nSqlDataReader(_iH_GovIncentive))
                                H_BusAct = ._pReturnString(_nSqlDataReader(_iH_BusAct))

                                H_D1 = ._pReturnByteArray(_nSqlDataReader(_iH_D1))
                                H_N1 = ._pReturnString(_nSqlDataReader(_iH_N1))
                                H_T1 = ._pReturnString(_nSqlDataReader(_iH_T1))

                                I_D1 = ._pReturnByteArray(_nSqlDataReader(_iI_D1))
                                I_N1 = ._pReturnString(_nSqlDataReader(_iI_N1))
                                I_T1 = ._pReturnString(_nSqlDataReader(_iI_T1))

                                I_D2 = ._pReturnByteArray(_nSqlDataReader(_iI_D2))
                                I_N2 = ._pReturnString(_nSqlDataReader(_iI_N2))
                                I_T2 = ._pReturnString(_nSqlDataReader(_iI_T2))

                                I_D3 = ._pReturnByteArray(_nSqlDataReader(_iI_D3))
                                I_N3 = ._pReturnString(_nSqlDataReader(_iI_N3))
                                I_T3 = ._pReturnString(_nSqlDataReader(_iI_T3))

                                I_D4 = ._pReturnByteArray(_nSqlDataReader(_iI_D4))
                                I_N4 = ._pReturnString(_nSqlDataReader(_iI_N4))
                                I_T4 = ._pReturnString(_nSqlDataReader(_iI_T4))

                                I_D5 = ._pReturnByteArray(_nSqlDataReader(_iI_D5))
                                I_N5 = ._pReturnString(_nSqlDataReader(_iI_N5))
                                I_T5 = ._pReturnString(_nSqlDataReader(_iI_T5))

                                I_D6 = ._pReturnByteArray(_nSqlDataReader(_iI_D6))
                                I_N6 = ._pReturnString(_nSqlDataReader(_iI_N6))
                                I_T6 = ._pReturnString(_nSqlDataReader(_iI_T6))

                            Loop
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubApplicationID(ByRef ApplicationID As String)

        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select 'NBP' + replace(CONVERT(date, getdate()),'-','') +'-'+  REPLACE(STR(CAST((select count(*)+1 from NewBP_Draft) AS nvarchar),5),' ','0') as 'ApplicationID'"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iApplicationID As Integer = .GetOrdinal("ApplicationID")
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                ApplicationID = ._pReturnString(_nSqlDataReader(_iApplicationID))
                            Loop
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubInsertDraft(ByVal Application_ID As String, ByVal UserID As String,
                                ByVal A() As String, ByVal B() As String, ByVal C() As String,
                                ByVal D() As String, ByVal E() As String, ByVal F() As String,
                                ByVal G() As String, ByVal H() As String, _
                                ByVal H_D1 As Byte(), ByVal H_N1 As String, ByVal H_T1 As String, _
                                ByVal I_D1 As Byte(), ByVal I_N1 As String, ByVal I_T1 As String, _
                                ByVal I_D2 As Byte(), ByVal I_N2 As String, ByVal I_T2 As String, _
                                ByVal I_D3 As Byte(), ByVal I_N3 As String, ByVal I_T3 As String, _
                                ByVal I_D4 As Byte(), ByVal I_N4 As String, ByVal I_T4 As String, _
                                ByVal I_D5 As Byte(), ByVal I_N5 As String, ByVal I_T5 As String, _
                                ByVal I_D6 As Byte(), ByVal I_N6 As String, ByVal I_T6 As String)
        Dim Submitted As Integer = 0
        Dim getdate As Date
        _pSubGetDate(getdate)

        Try

            Dim _nQuery As String = Nothing
            _nQuery = "INSERT INTO NewBP_Draft VALUES(" & _
                       "@Application_ID," & _
                       "@UserID," & _
                       "@A_Ownership," & _
                       "@A_DtiSecCda," & _
                       "@A_BusName," & _
                       "@A_TIN," & _
                       "@B_HouseNo," & _
                       "@B_BldgName," & _
                       "@B_LotNo," & _
                       "@B_BlockNo," & _
                       "@B_Street," & _
                       "@B_Brgy," & _
                       "@B_Subd," & _
                       "@B_CityMunicipality," & _
                       "@B_Province," & _
                       "@B_ZipCode," & _
                       "@C_TelNo," & _
                       "@C_MobileNo," & _
                       "@C_Email," & _
                       "@D_Lname," & _
                       "@D_Fname," & _
                       "@D_Mname," & _
                       "@D_Suffix," & _
                       "@E_Lname," & _
                       "@E_Fname," & _
                       "@E_Mname," & _
                       "@E_Suffix," & _
                       "@E_Nationality," & _
                       "@F_BusArea," & _
                       "@F_FlrArea," & _
                       "@F_MaleEmpNo," & _
                       "@F_FemaleEmpNo," & _
                       "@F_ResideEmpNo," & _
                       "@F_VanTruckNo," & _
                       "@F_MotorNo," & _
                       "@G_HouseNo," & _
                       "@G_BldgName," & _
                       "@G_LotNo," & _
                       "@G_BlockNo," & _
                       "@G_Street," & _
                       "@G_Brgy," & _
                       "@G_Subd," & _
                       "@G_CityMunicipality," & _
                       "@G_Province," & _
                       "@G_ZipCode," & _
                       "@H_Capital," & _
                       "@H_Nature," & _
                       "@H_Owned," & _
                       "@H_TDN," & _
                       "@H_PIN," & _
                       "@H_GovIncentive," & _
                       "@H_GovIncentiveFileData," & _
                       "@H_GovIncentiveFileName," & _
                       "@H_GovIncentiveFileType," & _
                       "@H_BusAct," & _
                       "@I_OwnerPicFileData," & _
                       "@I_OwnerPicFileName," & _
                       "@I_OwnerPicFileType," & _
                       "@I_OwnerPicStatus," & _
                       "@I_OwnerPicRemarks," & _
                       "@I_BusEstPicFileData," & _
                       "@I_BusEstPicFileName," & _
                       "@I_BusEstPicFileType," & _
                       "@I_BusEstPicStatus," & _
                       "@I_BusEstPicRemarks," & _
                       "@I_BusMapPicFileData," & _
                       "@I_BusMapPicFileName," & _
                       "@I_BusMapPicFileType," & _
                       "@I_BusMapPicStatus," & _
                       "@I_BusMapPicRemarks," & _
                       "@I_AppFormFileData," & _
                       "@I_AppFormFileName," & _
                       "@I_AppFormFileType," & _
                       "@I_AppFormStatus," & _
                       "@I_AppFormRemarks," & _
                       "@I_DtiSecCdaFileData," & _
                       "@I_DtiSecCdaFileName," & _
                       "@I_DtiSecCdaFileType," & _
                       "@I_DtiSecCdaFileStatus," & _
                       "@I_DtiSecCdaFileRemarks," & _
                       "@I_TINFileData," & _
                       "@I_TINFileName," & _
                       "@I_TINFileType," & _
                       "@I_TINFileStatus," & _
                       "@I_TINFileRemarks," & _
                       "@Submitted," & _
                       "@Date_Created," & _
                       "@Date_LastEdit," & _
                       "@Date_Submitted," & _
                       "@Status" & _
                      ")"





            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            With _nSqlCommand.Parameters
                .AddWithValue("@Application_ID", Application_ID)
                .AddWithValue("@UserID", UserID)
                .AddWithValue("@A_Ownership", A(0))
                .AddWithValue("@A_DtiSecCda", A(1))
                .AddWithValue("@A_BusName", A(2))
                .AddWithValue("@A_TIN", A(3))
                .AddWithValue("@B_HouseNo", B(0))
                .AddWithValue("@B_BldgName", B(1))
                .AddWithValue("@B_LotNo", B(2))
                .AddWithValue("@B_BlockNo", B(3))
                .AddWithValue("@B_Street", B(4))
                .AddWithValue("@B_Brgy", B(5))
                .AddWithValue("@B_Subd", B(6))
                .AddWithValue("@B_CityMunicipality", B(7))
                .AddWithValue("@B_Province", B(8))
                .AddWithValue("@B_ZipCode", B(9))
                .AddWithValue("@C_TelNo", C(0))
                .AddWithValue("@C_MobileNo", C(1))
                .AddWithValue("@C_Email", C(2))
                .AddWithValue("@D_Lname", D(0))
                .AddWithValue("@D_Fname", D(1))
                .AddWithValue("@D_Mname", D(2))
                .AddWithValue("@D_Suffix", D(3))
                .AddWithValue("@E_Lname", E(0))
                .AddWithValue("@E_Fname", E(1))
                .AddWithValue("@E_Mname", E(2))
                .AddWithValue("@E_Suffix", E(3))
                .AddWithValue("@E_Nationality", E(4))
                .AddWithValue("@F_BusArea", F(0))
                .AddWithValue("@F_FlrArea", F(1))
                .AddWithValue("@F_MaleEmpNo", F(2))
                .AddWithValue("@F_FemaleEmpNo", F(3))
                .AddWithValue("@F_ResideEmpNo", F(4))
                .AddWithValue("@F_VanTruckNo", F(5))
                .AddWithValue("@F_MotorNo", F(6))
                .AddWithValue("@G_HouseNo", G(0))
                .AddWithValue("@G_BldgName", G(1))
                .AddWithValue("@G_LotNo", G(2))
                .AddWithValue("@G_BlockNo", G(3))
                .AddWithValue("@G_Street", G(4))
                .AddWithValue("@G_Brgy", G(5))
                .AddWithValue("@G_Subd", G(6))
                .AddWithValue("@G_CityMunicipality", G(7))
                .AddWithValue("@G_Province", G(8))
                .AddWithValue("@G_ZipCode", G(9))
                .AddWithValue("@H_Capital", H(0))
                .AddWithValue("@H_Nature", H(1))
                .AddWithValue("@H_Owned", H(2))
                .AddWithValue("@H_TDN", H(3))
                .AddWithValue("@H_PIN", H(4))
                .AddWithValue("@H_GovIncentive", H(6))
                .AddWithValue("@H_GovIncentiveFileData", 0)
                .AddWithValue("@H_GovIncentiveFileName", "")
                .AddWithValue("@H_GovIncentiveFileType", "")
                .AddWithValue("@H_BusAct", IIf(H(7) = "Others", H(8), H(7)))
                .AddWithValue("@I_OwnerPicFileData", 0)
                .AddWithValue("@I_OwnerPicFileName", "")
                .AddWithValue("@I_OwnerPicFileType", "")
                .AddWithValue("@I_OwnerPicStatus", "")
                .AddWithValue("@I_OwnerPicRemarks", "")
                .AddWithValue("@I_BusEstPicFileData", 0)
                .AddWithValue("@I_BusEstPicFileName", "")
                .AddWithValue("@I_BusEstPicFileType", "")
                .AddWithValue("@I_BusEstPicStatus", "")
                .AddWithValue("@I_BusEstPicRemarks", "")
                .AddWithValue("@I_BusMapPicFileData", 0)
                .AddWithValue("@I_BusMapPicFileName", "")
                .AddWithValue("@I_BusMapPicFileType", "")
                .AddWithValue("@I_BusMapPicStatus", "")
                .AddWithValue("@I_BusMapPicRemarks", "")
                .AddWithValue("@I_AppFormFileData", 0)
                .AddWithValue("@I_AppFormFileName", "")
                .AddWithValue("@I_AppFormFileType", "")
                .AddWithValue("@I_AppFormStatus", "")
                .AddWithValue("@I_AppFormRemarks", "")
                .AddWithValue("@I_DtiSecCdaFileData", 0)
                .AddWithValue("@I_DtiSecCdaFileName", "")
                .AddWithValue("@I_DtiSecCdaFileType", "")
                .AddWithValue("@I_DtiSecCdaFileStatus", "")
                .AddWithValue("@I_DtiSecCdaFileRemarks", "")
                .AddWithValue("@I_TINFileData", 0)
                .AddWithValue("@I_TINFileName", "")
                .AddWithValue("@I_TINFileType", "")
                .AddWithValue("@I_TINFileStatus", "")
                .AddWithValue("@I_TINFileRemarks", "")
                .AddWithValue("@Submitted", 0)
                .AddWithValue("@Date_Created", getdate)
                .AddWithValue("@Date_LastEdit", "")
                .AddWithValue("@Date_Submitted", "")
                .AddWithValue("@Status", "Incomplete")
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubUpdateSubmit(ByVal Application_ID As String, ByVal UserID As String)

        Dim Submitted As Integer = 1
        Dim getdate As Date
        _pSubGetDate(getdate)


        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update NewBP_Draft SET " & _
                  "Submitted = @Submitted ," & _
                 "Date_LastEdit = @Date_LastEdit ," & _
                "Date_Submitted = @Date_Submitted," & _
                "Status = @Status" & _
                " where UserID=@UserID and Application_ID=@Application_ID"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@Application_ID", Application_ID)
                .AddWithValue("@UserID", UserID)
                .AddWithValue("@Submitted", Submitted)
                .AddWithValue("@Date_LastEdit", getdate)
                .AddWithValue("@Date_Submitted", getdate)
                .AddWithValue("@Status", "Submitted/Pending")
            End With

            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubUpdateDraft(ByVal Application_ID As String, ByVal UserID As String,
                                ByVal A() As String, ByVal B() As String, ByVal C() As String,
                                ByVal D() As String, ByVal E() As String, ByVal F() As String,
                                ByVal G() As String, ByVal H() As String, _
                                ByVal H_D1 As Byte(), ByVal H_N1 As String, ByVal H_T1 As String, _
                                ByVal I_D1 As Byte(), ByVal I_N1 As String, ByVal I_T1 As String, _
                                ByVal I_D2 As Byte(), ByVal I_N2 As String, ByVal I_T2 As String, _
                                ByVal I_D3 As Byte(), ByVal I_N3 As String, ByVal I_T3 As String, _
                                ByVal I_D4 As Byte(), ByVal I_N4 As String, ByVal I_T4 As String, _
                                ByVal I_D5 As Byte(), ByVal I_N5 As String, ByVal I_T5 As String, _
                                ByVal I_D6 As Byte(), ByVal I_N6 As String, ByVal I_T6 As String)
        Try
            Dim getdate As Date
            _pSubGetDate(getdate)

            Dim _nQuery As String = Nothing
            _nQuery = "Update NewBP_Draft SET " & _
                "A_Ownership = @A_Ownership," & _
                "A_DtiSecCda = @A_DtiSecCda," & _
                "A_BusName = @A_BusName," & _
                "A_TIN = @A_TIN," & _
                "B_HouseNo = @B_HouseNo," & _
                "B_BldgName = @B_BldgName," & _
                "B_LotNo = @B_LotNo," & _
                "B_BlockNo = @B_BlockNo," & _
                "B_Street = @B_Street," & _
                "B_Brgy = @B_Brgy," & _
                "B_Subd = @B_Subd," & _
                "B_CityMunicipality = @B_CityMunicipality," & _
                "B_Province = @B_Province," & _
                "B_ZipCode = @B_ZipCode," & _
                "C_TelNo = @C_TelNo," & _
                "C_MobileNo = @C_MobileNo," & _
                "C_Email = @C_Email," & _
                "D_Lname = @D_Lname," & _
                "D_Fname = @D_Fname," & _
                "D_Mname = @D_Mname," & _
                "D_Suffix = @D_Suffix," & _
                "E_Lname = @E_Lname," & _
                "E_Fname = @E_Fname," & _
                "E_Mname = @E_Mname," & _
                "E_Suffix = @E_Suffix," & _
                "E_Nationality = @E_Nationality," & _
                "F_BusArea = @F_BusArea," & _
                "F_FlrArea = @F_FlrArea," & _
                "F_MaleEmpNo = @F_MaleEmpNo," & _
                "F_FemaleEmpNo = @F_FemaleEmpNo," & _
                "F_ResideEmpNo = @F_ResideEmpNo," & _
                "F_VanTruckNo = @F_VanTruckNo," & _
                "F_MotorNo = @F_MotorNo," & _
                "G_HouseNo = @G_HouseNo," & _
                "G_BldgName = @G_BldgName," & _
                "G_LotNo = @G_LotNo," & _
                "G_BlockNo = @G_BlockNo," & _
                "G_Street = @G_Street," & _
                "G_Brgy = @G_Brgy," & _
                "G_Subd = @G_Subd," & _
                "G_CityMunicipality = @G_CityMunicipality," & _
                "G_Province = @G_Province," & _
                "G_ZipCode = @G_ZipCode," & _
                "H_Capital = @H_Capital," & _
                "H_Nature = @H_Nature," & _
                "H_Owned = @H_Owned," & _
                "H_TDN = @H_TDN," & _
                "H_PIN = @H_PIN," & _
                "H_GovIncentive = @H_GovIncentive," & _
                "H_BusAct = @H_BusAct," & _
                "Date_LastEdit = @Date_LastEdit" & _
                " where UserID=@UserID and Application_ID=@Application_ID"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@Application_ID", Application_ID)
                .AddWithValue("@UserID", UserID)
                .AddWithValue("@A_Ownership", A(0))
                .AddWithValue("@A_DtiSecCda", A(1))
                .AddWithValue("@A_BusName", A(2))
                .AddWithValue("@A_TIN", A(3))
                .AddWithValue("@B_HouseNo", B(0))
                .AddWithValue("@B_BldgName", B(1))
                .AddWithValue("@B_LotNo", B(2))
                .AddWithValue("@B_BlockNo", B(3))
                .AddWithValue("@B_Street", B(4))
                .AddWithValue("@B_Brgy", B(5))
                .AddWithValue("@B_Subd", B(6))
                .AddWithValue("@B_CityMunicipality", B(7))
                .AddWithValue("@B_Province", B(8))
                .AddWithValue("@B_ZipCode", B(9))
                .AddWithValue("@C_TelNo", C(0))
                .AddWithValue("@C_MobileNo", C(1))
                .AddWithValue("@C_Email", C(2))
                .AddWithValue("@D_Lname", D(0))
                .AddWithValue("@D_Fname", D(1))
                .AddWithValue("@D_Mname", D(2))
                .AddWithValue("@D_Suffix", D(3))
                .AddWithValue("@E_Lname", E(0))
                .AddWithValue("@E_Fname", E(1))
                .AddWithValue("@E_Mname", E(2))
                .AddWithValue("@E_Suffix", E(3))
                .AddWithValue("@E_Nationality", E(4))
                .AddWithValue("@F_BusArea", F(0))
                .AddWithValue("@F_FlrArea", F(1))
                .AddWithValue("@F_MaleEmpNo", F(2))
                .AddWithValue("@F_FemaleEmpNo", F(3))
                .AddWithValue("@F_ResideEmpNo", F(4))
                .AddWithValue("@F_VanTruckNo", F(5))
                .AddWithValue("@F_MotorNo", F(6))
                .AddWithValue("@G_HouseNo", G(0))
                .AddWithValue("@G_BldgName", G(1))
                .AddWithValue("@G_LotNo", G(2))
                .AddWithValue("@G_BlockNo", G(3))
                .AddWithValue("@G_Street", G(4))
                .AddWithValue("@G_Brgy", G(5))
                .AddWithValue("@G_Subd", G(6))
                .AddWithValue("@G_CityMunicipality", G(7))
                .AddWithValue("@G_Province", G(8))
                .AddWithValue("@G_ZipCode", G(9))
                .AddWithValue("@H_Capital", H(0))
                .AddWithValue("@H_Nature", H(1))
                .AddWithValue("@H_Owned", H(2))
                .AddWithValue("@H_TDN", H(3))
                .AddWithValue("@H_PIN", H(4))
                .AddWithValue("@H_GovIncentive", H(6))
                .AddWithValue("@H_BusAct", IIf(H(7) = "Others", H(8), H(7)))
                .AddWithValue("@Date_LastEdit", getdate)

            End With

            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubUpdateAttachment(ByVal DB_FieldData As String, _
                                       ByVal DB_FieldName As String, _
                                       ByVal DB_FieldType As String, _
                                       ByVal UserID As String, _
                                       ByVal Application_ID As String, _
                                       ByVal FileData As Byte(), _
                                       ByVal FileName As String, _
                                       ByVal FileType As String _
                                       )
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update NewBP_Draft SET " & _
                 DB_FieldData & " = @" & DB_FieldData & " ," & _
                 DB_FieldName & " = @" & DB_FieldName & " ," & _
                 DB_FieldType & " = @" & DB_FieldType & _
                " where UserID=@UserID and Application_ID=@Application_ID"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@Application_ID", Application_ID)
                .AddWithValue("@UserID", UserID)
                .AddWithValue("@" & DB_FieldData, FileData)
                .AddWithValue("@" & DB_FieldName, FileName)
                .AddWithValue("@" & DB_FieldType, FileType)
            End With

            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub



#End Region

End Class
