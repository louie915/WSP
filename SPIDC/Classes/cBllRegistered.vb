

#Region "Imports"

Imports System.Data.SqlClient
Imports System.Reflection.MethodBase
Imports System.Web.UI.WebControls
Imports SPIDC.cEventLog
Imports SPIDC.cReturnDataType
Imports VB.NET.Methods

#End Region

Public Class cBllRegistered


#Region "Variable Data"

    Private Shared _mCxn As SqlConnection = Nothing

    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Private _mSqlDataReader As SqlDataReader
    Private _mstrDate As String
    Public Shared _mCertType As String
    Public Shared _mDataTable As DataTable
    Private Shared _mDbCon As New SqlConnection
    Public Shared _mSqlCon As SqlConnection

    Private Shared _mSqlConCR As New SqlConnection
    Private Shared _mSqlConTIMS As New SqlConnection
    Private Shared _mSqlConBPLTAS As New SqlConnection
    Private Shared _mSqlConRPT As New SqlConnection
    Private Shared _mSqlConOAIMS As New SqlConnection

#End Region

#Region "Property Data"

    Public WriteOnly Property _pCxn() As SqlConnection
        Set(value As SqlConnection)
            _mCxn = value
        End Set
    End Property

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


    Public Shared Property _pSqlConCR() As SqlConnection
        Get
            Try
                Return _mSqlConCR
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
        Set(value As SqlConnection)
            _mSqlConCR = value
        End Set
    End Property

    Public Shared Property _pSqlConTIMS() As SqlConnection
        Get
            Try
                Return _mSqlConTIMS
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
        Set(value As SqlConnection)
            _mSqlConTIMS = value
        End Set
    End Property

    Public Shared Property _pSqlConBPLTAS() As SqlConnection
        Get
            Try
                Return _mSqlConBPLTAS
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
        Set(value As SqlConnection)
            _mSqlConBPLTAS = value
        End Set
    End Property

    Public Shared Property _pSqlConRPT() As SqlConnection
        Get
            Try
                Return _mSqlConRPT
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
        Set(value As SqlConnection)
            _mSqlConRPT = value
        End Set
    End Property

    Public Shared Property _pSqlConOAIMS() As SqlConnection
        Get
            Try
                Return _mSqlConOAIMS
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
        Set(value As SqlConnection)
            _mSqlConOAIMS = value
        End Set
    End Property


#End Region






#Region "Routine"

    Public Shared Function _pSubUpdateLogin(Email, MachineID)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update Registered SET MachineID = @MachineID where UserID=@Email"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@Email", Email)
                .AddWithValue("@MachineID", MachineID)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Function
    Public Sub _pSubSelectIdNo()

        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing


            '_nQuery = " select(select IDno from registered where IDno like (Select(CONVERT(VARCHAR(10),GETDATE(),112)) + '%')) as IDNo,(CONVERT(VARCHAR(10),GETDATE(),112)) as strDate"
            _nQuery = "select top 1 IDno from registered where IDno like (Select CONVERT(VARCHAR(10),GETDATE(),112)+ '%')  order by IDno desc"

            _mQuery = _nQuery & _nWhere
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubGetAutoIDno(ByRef _mIDNo As String)
        Try
            _pSubSelectIdNo()
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iIDNo As Integer = .GetOrdinal("IDNo")

                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                _mIDNo = ._pReturnString(_nSqlDataReader(_iIDNo))
                                If _mIDNo = Nothing Then
                                    _mIDNo = Format(Now, "yyyyMMdd") & "000001"
                                Else
                                    _mIDNo = Format(Now, "yyyyMMdd") & Format(Right(_mIDNo, 6) + 1, "000000")
                                End If
                            Loop
                        Else
                            _mIDNo = Format(Now, "yyyyMMdd") & "000001"
                        End If

                    End With
                End With

                _nSqlDataReader.Close()
            End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Function _pSubGetWhoLogged(ByVal Email As String, ByRef MachineID As String)
        Dim _nReturnValue As Boolean = Nothing
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Select MachineID from Registered where [UserID] = @UserID"
            Using _nCommand As New SqlCommand
                _nCommand.Connection = _mSqlConOAIMS '_mSqlConOAIMS 'cGlobalConnections._pSqlCxn_OAIMS
                _nCommand.CommandText = _nQuery
                _nCommand.CommandType = CommandType.Text
                _nCommand.Parameters.AddWithValue("@UserID", Email)
                Using _nSqlDataReader As SqlDataReader = _nCommand.ExecuteReader
                    Dim _iMachineID As Integer = _nSqlDataReader.GetOrdinal("MachineID")

                    If _nSqlDataReader.HasRows Then
                        Do While _nSqlDataReader.Read
                            MachineID = _pYieldString(_nSqlDataReader(_iMachineID))
                        Loop
                    End If
                    _nSqlDataReader.Close()
                End Using
            End Using
            _nReturnValue = MachineID
            Return _nReturnValue
        Catch ex As Exception

        End Try
    End Function

    Public Shared Function _pFuncVerifyIfAccountIsRegistered( _
        ByVal _nUserID As String, Optional ByVal xLiteral As String = Nothing _
    ) As Boolean

        Dim _nReturnValue As Boolean = Nothing
        Try
            '----------------------------------
            Dim _nPrmUserIDExists As Boolean = False
            Dim _nPrmUserType As String = Nothing

            '----------------------------------
            Dim _nDal As New cDalRegistered

            _nDal._pCxn = cGlobalConnections._pSqlCxn_OAIMS '_mCxn 


            _nDal._pUserID = _nUserID
            _nDal._pSubSelect()

            Using _nSqlDataReader As SqlDataReader = _nDal._pDr
                Dim _iUserType As Integer = _nSqlDataReader.GetOrdinal("UserType")

                If _nSqlDataReader.HasRows Then
                    Do While _nSqlDataReader.Read
                        _nPrmUserType = _pYieldString(_nSqlDataReader(_iUserType))

                    Loop
                    _nPrmUserIDExists = True
                    cSessionUser._pUsertype = _nPrmUserType
                End If

            End Using

            _nDal = Nothing
            '----------------------------------
            _nReturnValue = _nPrmUserIDExists
            Return _nReturnValue



        Catch ex As Exception
            _pSubEventLog(ex, 2)
            Return False
        End Try
        'Commented temporarily by Tomi 10/14/2019
        '_pSubEventLog("Verify If Account Is Registered" & ":End")
        '_pSubEventLog(_nSw.Elapsed, 2)


    End Function

    Public Shared Function _pFuncVerifyIfAccountIsActivated( _
        ByVal _nUserID As String, Optional ByVal xLiteral As String = "" _
    ) As Boolean
        'Commented temporarily by Tomi 10/14/2019
        'Dim _nSw As Stopwatch = Stopwatch.StartNew
        '_pSubEventLog("Verify If Account Is Activated" & ":Start")

        Dim _nReturnValue As Boolean = Nothing
        Try
            '----------------------------------
            Dim _nPrmIsActivated As Boolean

            '----------------------------------
            Dim _nQuery As String = Nothing
            _nQuery = _
                "SELECT " & _
                "* " & _
                "FROM " & _
                "[uvw.VS2014.WA.OAIMS.Registerred.Data.Read] " & _
                "WHERE " & _
                "[UserID] = @UserID"

            '----------------------------------
            Using _nCommand As New SqlCommand

                _nCommand.Connection = _mSqlConOAIMS 'cGlobalConnections._pSqlCxn_OAIMS
                _nCommand.CommandText = _nQuery
                _nCommand.CommandType = CommandType.Text

                _nCommand.Parameters.AddWithValue("@UserID", _nUserID)

                Using _nSqlDataReader As SqlDataReader = _nCommand.ExecuteReader

                    Dim _iIsActivated As Integer = _nSqlDataReader.GetOrdinal("IsActivated")

                    If _nSqlDataReader.HasRows Then
                        Do While _nSqlDataReader.Read
                            _nPrmIsActivated = _pYieldString(_nSqlDataReader(_iIsActivated))
                        Loop

                    End If

                    _nSqlDataReader.Close()
                End Using '_nSqlDataReader

            End Using '_nCommand

            '----------------------------------
            _nReturnValue = _nPrmIsActivated
            'Commented temporarily by Tomi 10/14/2019
            '_pSubEventLog("Verify If Account Is Activated" & ":End")
            '_pSubEventLog(_nSw.Elapsed, 2)
            Return _nReturnValue

            '----------------------------------
        Catch ex As Exception
            _pSubEventLog(ex, 2)
            Return False
        End Try
    End Function

    Public Shared Function _pFuncInsertNewAccount( _
          ByVal _nIDNo As String _
        , ByVal _nAgent As String _
        , ByVal _nUserID As String _
        , ByVal _nFirstName As String _
        , ByVal _nMiddleName As String _
        , ByVal _nLastName As String _
        , ByVal _nBirthDate As String _
        , ByVal _nSetupGender As String _
        , ByVal _nGender As String _
        , ByVal _nSecurityQ As String _
        , ByVal _nSecurityA As String _
        , ByVal _nContact_Cp As String _
        , ByVal _nResident As String _
        , ByRef ERRO As String _
        , Optional ByVal _nCompleteAddress As String = "" _
        , Optional ByVal xLiteral As String = ""
    ) As Boolean



        'Commented temporarily
        '_pLiteral.Text = xLiteral
        'Dim _nSw As Stopwatch = Stopwatch.StartNew
        '_pSubEventLog("Insert New Account" & ":Begin")

        Dim _nReturnValue As Boolean = Nothing

        Try

            '----------------------------------
            Dim _nQuery As String = Nothing
            '_nQuery = _
            '    "INSERT INTO " & _
            '    "[uvw.VS2014.WA.OAIMS.Registerred.Data.Write] " & _
            '    "(UserId, FirstName, LastName, BirthDate, SetupGender,Gender,SecurityQ,SecurityA,Contact_Cp) " & _
            '    "VALUES " & _
            '    "(@UserId, @FirstName, @LastName, @BirthDate, @SetupGender,@Gender,@SecurityQ,@SecurityA,@Contact_Cp) "

            _nQuery = _
                "INSERT INTO " & _
                "Registered " & _
                "(IDNo,UserId, FirstName, LastName, BirthDate, SetupGender,Gender,SecurityQ,SecurityA,Contact_Cp,Resident,UserType,Office,UserLevel,Address) " & _
                "VALUES " & _
                "(@IDNo,@UserId, @FirstName, @LastName, @BirthDate, @SetupGender,@Gender,@SecurityQ,@SecurityA,@Contact_Cp,@Resident,@UserType,@Office,@UserLevel,@Address) "

            '----------------------------------
            Using _nCommand As New SqlCommand
                _nCommand.Connection = cGlobalConnections._pSqlCxn_OAIMS
                _nCommand.CommandText = _nQuery
                _nCommand.CommandType = CommandType.Text
                _nCommand.Parameters.AddWithValue("@IDNo", _nIDNo)
                _nCommand.Parameters.AddWithValue("@UserID", _nUserID)
                _nCommand.Parameters.AddWithValue("@FirstName", _nFirstName)
                _nCommand.Parameters.AddWithValue("@LastName", _nLastName)
                _nCommand.Parameters.AddWithValue("@BirthDate", _nBirthDate)
                _nCommand.Parameters.AddWithValue("@SetupGender", _nSetupGender)
                _nCommand.Parameters.AddWithValue("@Gender", _nGender)
                _nCommand.Parameters.AddWithValue("@SecurityQ", _nSecurityQ)
                _nCommand.Parameters.AddWithValue("@SecurityA", _nSecurityA)
                _nCommand.Parameters.AddWithValue("@Contact_Cp", _nContact_Cp)
                _nCommand.Parameters.AddWithValue("@Resident", _nResident)
                _nCommand.Parameters.AddWithValue("@UserType", "TAXPAYER")
                _nCommand.Parameters.AddWithValue("@Office", _nAgent)
                _nCommand.Parameters.AddWithValue("@UserLevel", 0)
                _nCommand.Parameters.AddWithValue("@Address", _nCompleteAddress)
                _nReturnValue = _nCommand.ExecuteNonQuery()

            End Using '_nCommand

            '----------------------------------
            Return _nReturnValue

            '----------------------------------
        Catch ex As Exception
            ' _pSubEventLog(ex, 2)
            ERRO = ex.Message
            Return False
        End Try
        'Commented temporarily 
        '_pSubEventLog("Insert New Account" & ":End")
        '_pSubEventLog(_nSw.Elapsed, 2)
    End Function

    Public Shared Function _pFuncInsertLGUAccount( _
         ByVal _nIDNo As String _
       , ByVal _nUserID As String _
       , ByVal _nFirstName As String _
       , ByVal _nMiddleName As String _
       , ByVal _nLastName As String _
       , ByVal _nBirthDate As String _
       , ByVal _nSetupGender As String _
       , ByVal _nGender As String _
       , ByVal _nSecurityQ As String _
       , ByVal _nSecurityA As String _
       , ByVal _nContact_Cp As String _
       , ByVal _nResident As String _
       , ByVal _nUserType As String _
       , ByVal _nOffice As String _
        , ByVal _nUserLevel As String _
        , ByRef _err As String _
       , Optional ByVal xLiteral As String = ""
   ) As Boolean

        Dim _nReturnValue As Boolean = Nothing

        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            _nQuery = _
                "INSERT INTO " & _
                "Registered " & _
                "(IDNo,UserId, FirstName, LastName, BirthDate, SetupGender,Gender,SecurityQ,SecurityA,Contact_Cp,Resident, UserType,Office,UserLevel) " & _
                "VALUES " & _
                "(@IDNo,@UserId, @FirstName, @LastName, getdate(), @SetupGender,@Gender,@SecurityQ,@SecurityA,@Contact_Cp,@Resident,@UserType,@Office,@UserLevel) "

            '----------------------------------
            Using _nCommand As New SqlCommand
                _nCommand.Connection = cGlobalConnections._pSqlCxn_OAIMS '_mSqlConOAIMS '
                _nCommand.CommandText = _nQuery
                _nCommand.CommandType = CommandType.Text
                _nCommand.Parameters.AddWithValue("@IDNo", _nIDNo)
                _nCommand.Parameters.AddWithValue("@UserID", _nUserID)
                _nCommand.Parameters.AddWithValue("@FirstName", _nFirstName)
                _nCommand.Parameters.AddWithValue("@LastName", _nLastName)
                '_nCommand.Parameters.AddWithValue("@BirthDate", _nBirthDate)
                _nCommand.Parameters.AddWithValue("@SetupGender", _nSetupGender)
                _nCommand.Parameters.AddWithValue("@Gender", _nGender) '==== for Register.aspx
                _nCommand.Parameters.AddWithValue("@SecurityQ", _nSecurityQ) '==== for Register.aspx
                _nCommand.Parameters.AddWithValue("@SecurityA", _nSecurityA) '==== for Register.aspx
                _nCommand.Parameters.AddWithValue("@Contact_Cp", _nContact_Cp) '==== for Register.aspx
                _nCommand.Parameters.AddWithValue("@Resident", _nResident) '==== for Register.aspx
                _nCommand.Parameters.AddWithValue("@UserType", _nUserType)
                _nCommand.Parameters.AddWithValue("@Office", _nOffice)
                _nCommand.Parameters.AddWithValue("@UserLevel", _nUserLevel)
                _nReturnValue = _nCommand.ExecuteNonQuery()


            End Using '_nCommand

            If _nOffice = "EXECUTIVE" Then

                _nQuery = _
                "INSERT INTO " & _
                "Registered_Extn " & _
                "(UserId) " & _
                "VALUES " & _
                "(@UserId) "

                Using _nCommand As New SqlCommand
                    _nCommand.Connection = _mSqlConOAIMS 'cGlobalConnections._pSqlCxn_OAIMS
                    _nCommand.CommandText = _nQuery
                    _nCommand.CommandType = CommandType.Text
                    _nCommand.Parameters.AddWithValue("@UserID", _nUserID)
                    _nReturnValue = _nCommand.ExecuteNonQuery()

                End Using

            End If
            _err = " Con | " & cGlobalConnections._pSqlCxn_OAIMS.ConnectionString
            _err += " Query | " & _nQuery
            '----------------------------------
            Return _nReturnValue

            '----------------------------------
        Catch ex As Exception
            _err = _nReturnValue & " | " & ex.Message
            Return False
        End Try
        'Commented temporarily 
        '_pSubEventLog("Insert New Account" & ":End")
        '_pSubEventLog(_nSw.Elapsed, 2)
    End Function

    Public Shared Function _pFuncUpdateNewAccount( _
       ByVal _nIDNo As String _
     , ByVal _nUserID As String _
     , ByVal _nFirstName As String _
     , ByVal _nMiddleName As String _
     , ByVal _nLastName As String _
     , ByVal _nBirthDate As String _
     , ByVal _nSetupGender As String _
     , ByVal _nGender As String _
     , ByVal _nSecurityQ As String _
     , ByVal _nSecurityA As String _
     , ByVal _nContact_Cp As String _
     , ByVal _nResident As String _
     , ByVal _nUserType As String _
     , Optional ByVal xLiteral As String = ""
 ) As Boolean


        Dim _nReturnValue As Boolean = Nothing

        Try

            '----------------------------------
            Dim _nQuery As String = Nothing
            _nQuery = _
                "Update " & _
                "Registered " & _
                "set FirstName =  @FirstName, " & _
                " LastName =  @LastName," & _
                " BirthDate = @BirthDate, " & _
                " SetupGender = @SetupGender," & _
                " Gender = @Gender ," & _
                " SecurityQ = @SecurityQ," & _
                " SecurityA = @SecurityA," & _
                " Contact_Cp = @Contact_Cp," & _
                " Resident = @Resident," & _
                " UserType = @UserType where UserID = @UserID"

            '----------------------------------
            Using _nCommand As New SqlCommand
                _nCommand.Connection = _mSqlConOAIMS 'cGlobalConnections._pSqlCxn_OAIMS
                _nCommand.CommandText = _nQuery
                _nCommand.CommandType = CommandType.Text
                _nCommand.Parameters.AddWithValue("@IDNo", _nIDNo)
                _nCommand.Parameters.AddWithValue("@UserID", _nUserID)
                _nCommand.Parameters.AddWithValue("@FirstName", _nFirstName)
                _nCommand.Parameters.AddWithValue("@LastName", _nLastName)
                _nCommand.Parameters.AddWithValue("@BirthDate", _nBirthDate)
                _nCommand.Parameters.AddWithValue("@SetupGender", _nSetupGender)
                _nCommand.Parameters.AddWithValue("@Gender", _nGender) '==== for Register.aspx
                _nCommand.Parameters.AddWithValue("@SecurityQ", _nSecurityQ) '==== for Register.aspx
                _nCommand.Parameters.AddWithValue("@SecurityA", _nSecurityA) '==== for Register.aspx
                _nCommand.Parameters.AddWithValue("@Contact_Cp", _nContact_Cp) '==== for Register.aspx
                _nCommand.Parameters.AddWithValue("@UserType", _nUserType) '==== for Register.aspx
                _nCommand.Parameters.AddWithValue("@Resident", _nResident) '==== for Register.aspx
                _nReturnValue = _nCommand.ExecuteNonQuery()

            End Using '_nCommand

            '----------------------------------
            Return _nReturnValue

            '----------------------------------
        Catch ex As Exception
            _pSubEventLog(ex, 2)
            Return False
        End Try
        'Commented temporarily 
        '_pSubEventLog("Insert New Account" & ":End")
        '_pSubEventLog(_nSw.Elapsed, 2)
    End Function

    Public Shared Function _pFuncGetUserInfo(ByVal _nUserID As String, ByRef _nUsertype As String) As Boolean

        Try

            '----------------------------------
            Dim _nQuery As String = Nothing
            _nQuery = _
                "SELECT * FROM REGISTERED WHERE [USERID] = @UserID"
            '"SELECT " & _
            '"* " & _
            '"FROM " & _
            '"[uvw.VS2014.WA.OAIMS.Registerred.Data.Read] " & _

            '"WHERE " & _
            '"[UserID] = @UserID"

            '----------------------------------
            '----------------------------------
            Using _nCommand As New SqlCommand

                _nCommand.Connection = _mSqlConOAIMS 'cGlobalConnections._pSqlCxn_OAIMS
                _nCommand.CommandText = _nQuery
                _nCommand.CommandType = CommandType.Text

                _nCommand.Parameters.AddWithValue("@UserID", _nUserID)

                Using _nSqlDataReader As SqlDataReader = _nCommand.ExecuteReader

                    Dim _iUserType As Integer = _nSqlDataReader.GetOrdinal("USERTYPE")

                    If _nSqlDataReader.HasRows Then
                        Do While _nSqlDataReader.Read
                            _nUsertype = _pYieldString(_nSqlDataReader(_iUserType))
                        Loop
                        Return True
                    End If

                End Using '_nSqlDataReader

            End Using '_nCommand

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Shared Function _pFuncValidateEmail(ByVal _nUserID As String, _nKeyToken As String) As Boolean

        Try
            Dim _nReturnValue As Boolean = Nothing
            '----------------------------------
            Dim _nQuery As String = Nothing
            _nQuery = _
                "SELECT * FROM REGISTERED WHERE [USERID] = @UserID and [KEYTOKEN] = @KeyToken"

            '----------------------------------
            Using _nCommand As New SqlCommand

                _nCommand.Connection = _mSqlConOAIMS 'cGlobalConnections._pSqlCxn_OAIMS
                _nCommand.CommandText = _nQuery
                _nCommand.CommandType = CommandType.Text

                _nCommand.Parameters.AddWithValue("@UserID", _nUserID)
                _nCommand.Parameters.AddWithValue("@KeyToken", _nKeyToken)
                Using _nSqlDataReader As SqlDataReader = _nCommand.ExecuteReader


                    If _nSqlDataReader.HasRows Then
                        Return True
                    End If

                End Using '_nSqlDataReader

            End Using '_nCommand
            Return _nReturnValue
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Shared Function _pFuncGetKeyToken( _
        ByVal _nUserID As String _
        , ByRef _nKeyToken As String _
    ) As Boolean

        Try
            '----------------------------------
            Dim _nPrmKeyToken As String = Nothing

            '----------------------------------
            Dim _nQuery As String = Nothing
            _nQuery = _
               "SELECT " & _
               "* " & _
               "FROM " & _
               "[uvw.VS2014.WA.OAIMS.Registerred.Data.Read] " & _
               "WHERE " & _
               "[UserID] = @UserID"

            '----------------------------------
            Using _nCommand As New SqlCommand

                _nCommand.Connection = _mSqlConOAIMS 'cGlobalConnections._pSqlCxn_OAIMS
                _nCommand.CommandText = _nQuery
                _nCommand.CommandType = CommandType.Text

                _nCommand.Parameters.AddWithValue("@UserID", _nUserID)

                Using _nSqlDataReader As SqlDataReader = _nCommand.ExecuteReader

                    Dim _iKeyToken As Integer = _nSqlDataReader.GetOrdinal("KeyToken")

                    If _nSqlDataReader.HasRows Then
                        Do While _nSqlDataReader.Read
                            _nPrmKeyToken = _pYieldString(_nSqlDataReader(_iKeyToken))
                        Loop
                    End If

                End Using '_nSqlDataReader

            End Using '_nCommand

            '----------------------------------
            If Not String.IsNullOrEmpty(_nPrmKeyToken.Trim()) Then
                _nKeyToken = _nPrmKeyToken
                Return True
            Else
                Return False
            End If

            '----------------------------------
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function _pFuncActivateAccount( _
    ByVal _nUserID As String _
    ) As Boolean

        Dim _nReturnValue As Boolean = Nothing
        Try
            '----------------------------------
            Dim _nPrmIsActivated As Boolean = True

            '----------------------------------
            Dim _nQuery As String = Nothing
            _nQuery = _
                "UPDATE " & _
                "[uvw.VS2014.WA.OAIMS.Registerred.Data.Write] " & _
                "SET " & _
                "[IsActivated] = @IsActivated " & _
                "WHERE " & _
                "[UserID] = @UserId "

            '----------------------------------
            Using _nCommand As New SqlCommand

                _nCommand.Connection = _mSqlConOAIMS 'cGlobalConnections._pSqlCxn_OAIMS
                _nCommand.CommandText = _nQuery
                _nCommand.CommandType = CommandType.Text

                _nCommand.Parameters.AddWithValue("@UserID", _nUserID)
                _nCommand.Parameters.AddWithValue("@IsActivated", _nPrmIsActivated)

                _nReturnValue = _nCommand.ExecuteNonQuery()

            End Using '_nCommand

            '----------------------------------
            Return _nReturnValue

            '----------------------------------
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Sub _pSubGenerateKeyTokenSignOut( _
    ByVal _nUserID As String _
    )

        Try
            '----------------------------------
            Dim _nNewKeyToken As String = Guid.NewGuid.ToString

            '----------------------------------
            Dim _nQuery As String = Nothing
            _nQuery = _
                "UPDATE " & _
                "[uvw.VS2014.WA.OAIMS.Registerred.Data.Write] " & _
                "SET " & _
                "[KeyToken] = @KeyToken " & _
                "WHERE " & _
                "[UserID] = @UserId "

            '----------------------------------
            Using _nCommand As New SqlCommand

                _nCommand.Connection = _mSqlConOAIMS 'cGlobalConnections._pSqlCxn_OAIMS
                _nCommand.CommandText = _nQuery
                _nCommand.CommandType = CommandType.Text

                _nCommand.Parameters.AddWithValue("@UserID", _nUserID)
                _nCommand.Parameters.AddWithValue("@KeyToken", _nNewKeyToken)

            End Using '_nCommand

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Function _pFuncGetUserKeySalt( _
    ByVal _nUserID As String _
    , ByRef _nUserKeySalt As Byte() _
    , Optional ByVal xLiteral As String = "" _
    ) As Boolean

        Dim _nReturnValue As Boolean = Nothing
        'Commented temporarily by Tomi 10/14/2019
        '_pLiteral.Text = xLiteral
        'Dim _nSw As Stopwatch = Stopwatch.StartNew
        '_pSubEventLog("Get User Key Salt" & ":Begin")
        Try
            '----------------------------------
            Dim _nPrmUserKeySalt As Byte() = Nothing

            '----------------------------------
            Dim _nQuery As String = Nothing
            _nQuery = _
                "SELECT " & _
                "* " & _
                "FROM " & _
                "[uvw.VS2014.WA.OAIMS.Registerred.Data.Read] " & _
                "WHERE " & _
                "[UserID] = @UserID"

            '----------------------------------
            Using _nCommand As New SqlCommand

                _nCommand.Connection = cGlobalConnections._pSqlCxn_OAIMS
                _nCommand.CommandText = _nQuery
                _nCommand.CommandType = CommandType.Text

                _nCommand.Parameters.AddWithValue("@UserID", _nUserID)

                Using _nSqlDataReader As SqlDataReader = _nCommand.ExecuteReader

                    '----------------------------------
                    'Indexes
                    Dim _iUserKeySalt As Integer = _nSqlDataReader.GetOrdinal("UserKeySalt")
                    '----------------------------------

                    If _nSqlDataReader.HasRows Then
                        Do While _nSqlDataReader.Read
                            _nPrmUserKeySalt = _pYieldByteArray(_nSqlDataReader(_iUserKeySalt))
                        Loop

                    End If

                End Using '_nSqlDataReader

            End Using '_nCommand

            '----------------------------------
            If Not _nPrmUserKeySalt Is Nothing Then
                _nUserKeySalt = _nPrmUserKeySalt
                _nReturnValue = True
            Else
                _nReturnValue = False
            End If

            '----------------------------------
            Return _nReturnValue

            '----------------------------------
        Catch ex As Exception
            _pSubEventLog(ex, 2)
            Return False
        End Try
        'Commented temporarily by Tomi 10/14/2019
        '_pSubEventLog("Get User Key Salt" & ":End")
        '_pSubEventLog(_nSw.Elapsed, 2)
    End Function

    Public Shared Function _pFuncGetPassKeySalt( _
    ByVal _nUserID As String _
    , ByRef _nUserKeySalt As Byte() _
    , Optional ByVal xLiteral As String = "" _
    ) As Boolean

        Dim _nReturnValue As Boolean = Nothing
        'Commented temporarily by Tomi 10/14/2019
        '_pLiteral.Text = xLiteral
        'Dim _nSw As Stopwatch = Stopwatch.StartNew
        '_pSubEventLog("Get User Key Salt" & ":Begin")
        Try
            '----------------------------------
            Dim _nPrmUserKeySalt As Byte() = Nothing

            '----------------------------------
            Dim _nQuery As String = Nothing
            _nQuery = _
                "SELECT " & _
                "* " & _
                "FROM " & _
                "[uvw.VS2014.WA.OAIMS.Registerred.Data.Read] " & _
                "WHERE " & _
                "[UserID] = @UserID"

            '----------------------------------
            Using _nCommand As New SqlCommand

                _nCommand.Connection = _mSqlConOAIMS 'cGlobalConnections._pSqlCxn_OAIMS
                _nCommand.CommandText = _nQuery
                _nCommand.CommandType = CommandType.Text

                _nCommand.Parameters.AddWithValue("@UserID", _nUserID)

                Using _nSqlDataReader As SqlDataReader = _nCommand.ExecuteReader

                    '----------------------------------
                    'Indexes
                    Dim _iUserKeySalt As Integer = _nSqlDataReader.GetOrdinal("UserKeySalt")
                    '----------------------------------

                    If _nSqlDataReader.HasRows Then
                        Do While _nSqlDataReader.Read
                            _nPrmUserKeySalt = _pYieldByteArray(_nSqlDataReader(_iUserKeySalt))
                        Loop

                    End If

                End Using '_nSqlDataReader

            End Using '_nCommand

            '----------------------------------
            If Not _nPrmUserKeySalt Is Nothing Then
                _nUserKeySalt = _nPrmUserKeySalt
                _nReturnValue = True
            Else
                _nReturnValue = False
            End If

            '----------------------------------
            Return _nReturnValue

            '----------------------------------
        Catch ex As Exception
            _pSubEventLog(ex, 2)
            Return False
        End Try
        'Commented temporarily by Tomi 10/14/2019
        '_pSubEventLog("Get User Key Salt" & ":End")
        '_pSubEventLog(_nSw.Elapsed, 2)
    End Function

    Public Shared Function _pFuncVerifyUserIDUserKey( _
    ByVal _nUserID As String _
    , ByVal _nUserKey As String _
    , ByVal _nUserKeySalt As Byte() _
    ) As Boolean

        Dim _nReturnValue As Boolean = Nothing
        Try
            '----------------------------------
            Dim _nEncryptedUserKey As String = Nothing
            Dim _nPrmUserKey As String = Nothing
            Dim _nPrmUserType As String = Nothing

            '----------------------------------
            'Encrypt UserKey.
            Dim _nEncryption As New cEncryption20140609
            _nEncryptedUserKey = _nEncryption.Encrypt(_nUserKey, _nUserKeySalt)

            '----------------------------------
            Dim _nQuery As String = Nothing
            _nQuery = _
                "SELECT " & _
                "* " & _
                "FROM " & _
                "[uvw.VS2014.WA.OAIMS.Registerred.Data.Read] " & _
                "WHERE " & _
                "[UserID] = @UserID"

            '----------------------------------
            Using _nCommand As New SqlCommand

                _nCommand.Connection = _mSqlConOAIMS 'cGlobalConnections._pSqlCxn_OAIMS
                _nCommand.CommandText = _nQuery
                _nCommand.CommandType = CommandType.Text

                _nCommand.Parameters.AddWithValue("@UserID", _nUserID)

                Using _nSqlDataReader As SqlDataReader = _nCommand.ExecuteReader

                    '----------------------------------
                    'Indexes
                    Dim _iUserKey As Integer = _nSqlDataReader.GetOrdinal("UserKey")

                    '----------------------------------

                    If _nSqlDataReader.HasRows Then
                        Do While _nSqlDataReader.Read
                            _nPrmUserKey = _pYieldString(_nSqlDataReader(_iUserKey))

                        Loop

                    End If

                    _nSqlDataReader.Close()
                End Using '_nSqlDataReader

            End Using '_nCommand

            '----------------------------------
            If _nEncryptedUserKey = _nPrmUserKey Then

                _nReturnValue = True
            End If

            '----------------------------------
            Return _nReturnValue

            '----------------------------------
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function _pFuncUpdateUserKey( _
    ByVal _nUserID As String _
    , ByVal _nUserKey As String _
    , ByVal _nOffice As String _
    , ByVal _nUserKeySalt As Byte() _
    , Optional ByVal xLiteral As String = "" _
    ) As Boolean

        Dim _nReturnValue As Boolean = Nothing

        '_pLiteral.Text = xLiteral
        'Dim _nSw As Stopwatch = Stopwatch.StartNew
        '_pSubEventLog("Update User Key" & ":Begin")

        Try
            '----------------------------------
            Dim _nEncryptedUserKey As String = Nothing

            '----------------------------------
            'Encrypt UserKey.
            Dim _nEncryption As New cEncryption20140609
            _nEncryptedUserKey = _nEncryption.Encrypt(_nUserKey, _nUserKeySalt)

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '   Dim userType As String
            '   Dim UserLevel As Integer

            '    If _nOffice = "TAXPAYER" Then
            '        userType = "TAXPAYER"
            '        UserLevel = 1
            '    ElseIf _nOffice = "APPLICANT" Then
            '        userType = "APPLICANT"
            '        UserLevel = 1
            '    ElseIf _nOffice = "ADMIN" Then
            '        userType = "LGU"
            '        UserLevel = 100
            '    ElseIf _nOffice = "ASSESSOR" Or _nOffice = "BPLO" Or _nOffice = "TREASURY" Or _nOffice = "HR" Or _nOffice = "EMPLOYEE" Then
            '        userType = "LGU"
            '        UserLevel = 1
            '    Else
            '        userType = cSessionUser._pOffice
            '        _nOffice = cSessionUser._pUsertype
            '        If _nOffice <> "ADMIN" Then
            '            UserLevel = 1
            '        End If
            '    End If

            _nQuery = _
          "UPDATE " & _
          "Registered " & _
          "SET " & _
          "[UserKey] = '" & _nEncryptedUserKey & "'" & _
           " WHERE [UserID] = '" & _nUserID & "' "

            '         _nQuery = _
            '   "UPDATE " & _
            '   "Registered " & _
            '   "SET " & _
            '   "[UserKey] = '" & _nEncryptedUserKey & "', " & _
            '   "[UserType] = '" & userType & "', " & _
            '   "[UserLevel] = '" & UserLevel & "', " & _
            '   "[Office] = '" & _nOffice & "' " & _
            '    " WHERE [UserID] = '" & _nUserID & "' "


            '----------------------------------
            Using _nCommand As New SqlCommand

                _nCommand.Connection = cGlobalConnections._pSqlCxn_OAIMS
                _nCommand.CommandText = _nQuery
                _nCommand.CommandType = CommandType.Text

                '_nCommand.Parameters.AddWithValue("@UserID", _nUserID)
                '_nCommand.Parameters.AddWithValue("@UserKey", _nEncryptedUserKey)
                '_nCommand.Parameters.AddWithValue("@_nOffice", _nOffice)
                _nReturnValue = _nCommand.ExecuteNonQuery()

            End Using '_nCommand

            '----------------------------------
            Return _nReturnValue

            '----------------------------------
        Catch ex As Exception
            _pSubEventLog(ex, 2)
            Return _nReturnValue
        End Try
        'Commented temporarily by Tomi 10/14/2019
        '_pSubEventLog("_pFuncVerifyLGURegistry" & ":End")
        '_pSubEventLog(_nSw.Elapsed, 2)

    End Function

    Public Shared Function _pFuncUpdateLGUUserKey( _
   ByVal _nUserID As String _
   , ByVal _nUserKey As String _
   , ByVal _nUserKeySalt As Byte() _
   , Optional ByVal xLiteral As String = "" _
   ) As Boolean

        Dim _nReturnValue As Boolean = Nothing

        Try
            '----------------------------------
            Dim _nEncryptedUserKey As String = Nothing

            '----------------------------------
            'Encrypt UserKey.
            Dim _nEncryption As New cEncryption20140609
            _nEncryptedUserKey = _nEncryption.Encrypt(_nUserKey, _nUserKeySalt)

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = _
          "UPDATE " & _
          "Registered " & _
          "SET " & _
          "[UserKey] = '" & _nEncryptedUserKey & "' " & _
           " WHERE [UserID] = '" & _nUserID & "' "


            '----------------------------------
            Using _nCommand As New SqlCommand

                _nCommand.Connection = _mSqlConOAIMS 'cGlobalConnections._pSqlCxn_OAIMS
                _nCommand.CommandText = _nQuery
                _nCommand.CommandType = CommandType.Text
                _nReturnValue = _nCommand.ExecuteNonQuery()

            End Using

            '----------------------------------
            Return _nReturnValue

            '----------------------------------
        Catch ex As Exception
            _pSubEventLog(ex, 2)
            Return _nReturnValue
        End Try


    End Function

    Public Shared Function _pFuncUpdateLGUPassKey( _
   ByVal _nUserID As String _
   , ByVal _nUserKey As String _
   , ByVal _nUserKeySalt As Byte() _
   , Optional ByVal xLiteral As String = "" _
   ) As Boolean

        Dim _nReturnValue As Boolean = Nothing

        Try
            '----------------------------------
            Dim _nEncryptedUserKey As String = Nothing

            '----------------------------------
            'Encrypt UserKey.
            Dim _nEncryption As New cEncryption20140609
            _nEncryptedUserKey = _nEncryption.Encrypt(_nUserKey, _nUserKeySalt)

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = _
          "UPDATE " & _
          "Registered_Extn " & _
          "SET " & _
          "[UserKey] = '" & _nEncryptedUserKey & "' " & _
           " WHERE [UserID] = '" & _nUserID & "' "


            '----------------------------------
            Using _nCommand As New SqlCommand

                _nCommand.Connection = _mSqlConOAIMS 'cGlobalConnections._pSqlCxn_OAIMS
                _nCommand.CommandText = _nQuery
                _nCommand.CommandType = CommandType.Text
                _nReturnValue = _nCommand.ExecuteNonQuery()

            End Using

            '----------------------------------
            Return _nReturnValue

            '----------------------------------
        Catch ex As Exception
            _pSubEventLog(ex, 2)
            Return _nReturnValue
        End Try


    End Function

    Public Shared Function _pFuncResetUserKey( _
    ByVal _nUserID As String _
    ) As Boolean

        Dim _nReturnValue As Boolean = Nothing
        Try
            '----------------------------------
            Dim _nEncryptedUserKey As String = Nothing

            '----------------------------------
            Dim _nQuery As String = Nothing
            _nQuery = _
                "UPDATE " & _
                "[uvw.VS2014.WA.OAIMS.Registerred.Data.Write] " & _
                "SET " & _
                "[UserKey] = @UserKey " & _
                ", [UserKeySalt] = Crypt_Gen_Random(32) " & _
                "WHERE " & _
                "[UserID] = @UserId "

            '----------------------------------
            Using _nCommand As New SqlCommand

                _nCommand.Connection = _mSqlConOAIMS 'cGlobalConnections._pSqlCxn_OAIMS
                _nCommand.CommandText = _nQuery
                _nCommand.CommandType = CommandType.Text

                _nCommand.Parameters.AddWithValue("@UserID", _nUserID)
                _nCommand.Parameters.AddWithValue("@UserKey", "")

                _nReturnValue = _nCommand.ExecuteNonQuery()

            End Using '_nCommand

            '----------------------------------
            Return _nReturnValue

            '----------------------------------
        Catch ex As Exception
            Return _nReturnValue
        End Try
    End Function

    Public Shared Function _pFuncVerifyIfValidKeyToken( _
    ByVal _nUserID As String _
    , ByVal _nKeyToken As String _
    ) As Boolean

        Dim _nReturnValue As Boolean = Nothing
        Try
            '----------------------------------
            Dim _nPrmKeyToken As String = Nothing

            '----------------------------------
            Dim _nQuery As String = Nothing
            _nQuery = _
                "SELECT " & _
                "* " & _
                "FROM " & _
                "[uvw.VS2014.WA.OAIMS.Registerred.Data.Read] " & _
                "WHERE " & _
                "[UserID] = @UserID"
            '----------------------------------
            Using _nCommand As New SqlCommand

                _nCommand.Connection = _mSqlConOAIMS 'cGlobalConnections._pSqlCxn_OAIMS
                _nCommand.CommandText = _nQuery
                _nCommand.CommandType = CommandType.Text

                _nCommand.Parameters.AddWithValue("@UserID", _nUserID)

                Using _nSqlDataReader As SqlDataReader = _nCommand.ExecuteReader

                    '----------------------------------
                    'Indexes
                    Dim _iKeyToken As Integer = _nSqlDataReader.GetOrdinal("KeyToken")
                    '----------------------------------

                    If _nSqlDataReader.HasRows Then
                        Do While _nSqlDataReader.Read
                            _nPrmKeyToken = _pYieldString(_nSqlDataReader(_iKeyToken))
                        Loop

                    End If

                    _nSqlDataReader.Close()
                End Using '_nSqlDataReader

            End Using '_nCommand

            '----------------------------------
            If _nKeyToken = _nPrmKeyToken Then
                'NOTE: 
                'TODO: Encrypt Parameters being passed.
                _nReturnValue = True

            End If
            '----------------------------------

            Return _nReturnValue
            '----------------------------------
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function _pFuncGenerateKeyToken( _
    ByVal _nUserID As String _
    ) As Boolean

        Dim _nReturnValue As Boolean = Nothing
        Try
            '----------------------------------
            Dim _nNewKeyToken As String = Guid.NewGuid.ToString

            '----------------------------------
            Dim _nQuery As String = Nothing
            _nQuery = _
                "UPDATE " & _
                "[uvw.VS2014.WA.OAIMS.Registerred.Data.Write] " & _
                "SET " & _
                "[KeyToken] = @KeyToken " & _
                "WHERE " & _
                "[UserID] = @UserId "

            '----------------------------------
            Using _nCommand As New SqlCommand

                _nCommand.Connection = _mSqlConOAIMS 'cGlobalConnections._pSqlCxn_OAIMS
                _nCommand.CommandText = _nQuery
                _nCommand.CommandType = CommandType.Text

                _nCommand.Parameters.AddWithValue("@UserID", _nUserID)
                _nCommand.Parameters.AddWithValue("@KeyToken", _nNewKeyToken)

                _nReturnValue = _nCommand.ExecuteNonQuery()

            End Using '_nCommand

            '----------------------------------
            Return _nReturnValue

            '----------------------------------
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function _pFuncCheckifLoginNameExist(ByVal _nLoginName As String) As Boolean

        Try
            '----------------------------------
            Dim _nDal As New cDalBPCheckAuthentication
            _nDal._pSqlConnection = _mSqlConBPLTAS '_mSqlConBPLTAS 'cGlobalConnections._pSqlCxn_BPLTAS
            _nDal._pLoginname = _nLoginName
            _nDal._pSubSelect()

            Dim _nDataTable As New DataTable
            _nDataTable = _nDal._pDataTable

            If _nDataTable.Rows.Count = 0 Then
                Return False
            Else

                Return True
            End If

            _nDal = Nothing

            '----------------------------------
        Catch ex As Exception
            Return False
        End Try
    End Function '@ Added 20180727 

    Public Shared Function _pFuncVerifyPasskey(ByVal _mLoginName As String, ByVal _mPassKey As String) As Boolean '@ Added 20180727 
        _pFuncVerifyPasskey = False
        Try


            Dim _nPassKey As String = Nothing

            '----------------------------------
            Dim _nDal As New cDalBPCheckAuthentication
            _nDal._pSqlConnection = _mSqlConBPLTAS 'cGlobalConnections._pSqlCxn_BPLTAS
            _nDal._pLoginname = _mLoginName
            _nDal._pSubSelect()

            Dim _nDataTable As New DataTable
            _nDataTable = _nDal._pDataTable

            If _nDataTable.Rows.Count <> 0 Then
                _nPassKey = _nDataTable.Rows("0").Item("webpassword").ToString()

                If _nPassKey = _mPassKey Then
                    Return True
                Else
                    Return False
                End If

            End If

            _nDal = Nothing

            '----------------------------------
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function _pFuncVerifyWebEmail(ByVal _mLoginName As String, ByVal _mWebEmail As String, Optional ByVal xLiteral As String = "") As Boolean '@ Added 20180727 
        _pFuncVerifyWebEmail = False
        'MsgBox("BEGIN")

        '_pLiteral.Text = xLiteral
        'Dim _nSw As Stopwatch = Stopwatch.StartNew
        '_pSubEventLog("Verify WebEmail" & ":Begin")

        Try
            Dim _nWebEmail As String = Nothing

            '----------------------------------
            Dim _nDal As New cDalBPCheckAuthentication
            _nDal._pSqlConnection = _mSqlConBPLTAS 'cGlobalConnections._pSqlCxn_BPLTAS
            _nDal._pLoginname = _mLoginName

            _nDal._pSubSelect()

            Dim _nDataTable As New DataTable
            _nDataTable = _nDal._pDataTable

            If _nDataTable.Rows.Count <> 0 Then
                _nWebEmail = _nDataTable.Rows("0").Item("WebEmailAdd").ToString()
                MsgBox(_nWebEmail & _mWebEmail)
                If _nWebEmail = _mWebEmail Then
                    MsgBox("True")
                    Return True

                Else
                    MsgBox("FASLE")
                    Return False

                End If

            End If

            _nDal = Nothing

            '----------------------------------
        Catch ex As Exception
            _pSubEventLog(ex, 2)
            MsgBox("ERROR")
            Return False
        End Try

        '_pSubEventLog("Verify WebEmail" & ":End")
        '_pSubEventLog(_nSw.Elapsed, 2)

    End Function

    Public Shared Function _pFuncVerifyOffice(ByVal _mLoginName As String, ByVal _mOffice As String, Optional ByVal xLiteral As String = "") As Boolean '@ Added 20180727 
        _pFuncVerifyOffice = False
        'Commented temporarily by Tomi 10/14/2019
        '_pLiteral.Text = xLiteral
        'Dim _nSw As Stopwatch = Stopwatch.StartNew
        '_pSubEventLog("Verify Office" & ":Begin")

        Try
            Dim _nOffice As String = Nothing

            '----------------------------------
            Dim _nDal As New cDalBPCheckAuthentication
            _nDal._pSqlConnection = _mSqlConBPLTAS 'cGlobalConnections._pSqlCxn_BPLTAS
            _nDal._pLoginname = _mLoginName
            _nDal._pSubSelect()

            Dim _nDataTable As New DataTable
            _nDataTable = _nDal._pDataTable

            If _nDataTable.Rows.Count <> 0 Then
                _nOffice = _nDataTable.Rows("0").Item("weboffice").ToString()

                If _nOffice = "license" And _mOffice = "BPLO" Then
                    Return True
                ElseIf _nOffice = "treasurer" And _mOffice = "Treasury" Then
                    Return True
                Else
                    Return False
                End If

            End If

            _nDal = Nothing

            '----------------------------------
        Catch ex As Exception
            _pSubEventLog(ex, 2)
            Return False
        End Try
        'Commented temporarily by Tomi 10/14/2019
        '_pSubEventLog("Verify Office" & ":End")
        '_pSubEventLog(_nSw.Elapsed, 2)

    End Function

    Public Shared Function _pFuncVerifyIfWebAuthorized(ByVal _mLoginName As String, Optional ByVal xLiteral As String = "") As Boolean '@ Added 20180727 
        _pFuncVerifyIfWebAuthorized = False
        'Commented temporarily by Tomi 10/14/2019
        '_pLiteral.Text = xLiteral
        'Dim _nSw As Stopwatch = Stopwatch.StartNew
        '_pSubEventLog("Verify If Web Authorized" & ":Begin")

        Try
            Dim _nWebUser As String = Nothing

            '----------------------------------
            Dim _nDal As New cDalBPCheckAuthentication
            _nDal._pSqlConnection = _mSqlConBPLTAS 'cGlobalConnections._pSqlCxn_BPLTAS
            _nDal._pLoginname = _mLoginName
            _nDal._pSubSelect()

            Dim _nDataTable As New DataTable
            _nDataTable = _nDal._pDataTable

            If _nDataTable.Rows.Count <> 0 Then
                _nWebUser = _nDataTable.Rows("0").Item("WebUser").ToString()

                If _nWebUser <> "0" Then
                    Return True
                Else
                    Return False
                End If

            End If

            _nDal = Nothing

            '----------------------------------
        Catch ex As Exception
            _pSubEventLog(ex, 2)
            Return False
        End Try
        'Commented temporarily by Tomi 10/14/2019
        '_pSubEventLog("Verify If Web Authorized" & ":End")
        '_pSubEventLog(_nSw.Elapsed, 2)
    End Function

    Public Shared Function _pFuncVerifyIfActiveLocal(ByVal _mLoginName As String, Optional ByVal xLiteral As String = "") As Boolean '@ Added 20180727 

        'Commented temporarily by Tomi 10/14/2019
        '_pLiteral.Text = xLiteral
        'Dim _nSw As Stopwatch = Stopwatch.StartNew
        '_pSubEventLog("Verify If Active Local" & ":Begin")

        _pFuncVerifyIfActiveLocal = False
        Try
            Dim _mStatus As String = Nothing

            '----------------------------------
            Dim _nDal As New cDalBPCheckAuthentication
            _nDal._pSqlConnection = _mSqlConBPLTAS 'cGlobalConnections._pSqlCxn_BPLTAS
            _nDal._pLoginname = _mLoginName
            _nDal._pSubSelect()

            Dim _nDataTable As New DataTable
            _nDataTable = _nDal._pDataTable

            If _nDataTable.Rows.Count <> 0 Then
                _mStatus = _nDataTable.Rows("0").Item("Status").ToString()

                If _mStatus = "0" Then
                    Return True
                Else
                    Return False
                End If

            End If

            _nDal = Nothing

            '----------------------------------
        Catch ex As Exception
            _pSubEventLog(ex, 2)
            Return False
        End Try
        'Commented temporarily by Tomi 10/14/2019
        '_pSubEventLog("Verify If Active Local" & ":End")
        '_pSubEventLog(_nSw.Elapsed, 2)

    End Function


    Public Shared Function _pFuncVerifyLGURegistry(ByVal _nLoginName As String, ByVal _mPassKey As String, ByVal _mWebEmail As String, ByVal _mOffice As String, ByRef _mResult As String, Optional ByVal xLiteral As String = "") As Boolean
        'Commented temporarily by Tomi 10/14/2019
        '_pLiteral.Text = xLiteral
        'Dim _nSw As Stopwatch = Stopwatch.StartNew
        '_pSubEventLog("Verify LGU Registry" & ":Begin")


        Try

            Dim _nPassKey As String = Nothing
            Dim _nWebEmail As String = Nothing
            Dim _nOffice As String = Nothing
            Dim _nWebUser As String = Nothing
            Dim _mStatus As String = Nothing
            '----------------------------------
            Dim _nDal As New cDalBPCheckAuthentication
            _nDal._pSqlConnection = _mSqlConBPLTAS 'cGlobalConnections._pSqlCxn_BPLTAS
            _nDal._pLoginname = _nLoginName
            _nDal._pSubSelect()

            Dim _nDataTable As New DataTable
            _nDataTable = _nDal._pDataTable

            If _nDataTable.Rows.Count = 0 Then
                Return False
            Else

                _nPassKey = _nDataTable.Rows("0").Item("webpassword").ToString()
                _nWebEmail = _nDataTable.Rows("0").Item("WebEmailAdd").ToString()
                _nOffice = _nDataTable.Rows("0").Item("weboffice").ToString()
                _nWebUser = _nDataTable.Rows("0").Item("WebUser").ToString()
                _mStatus = _nDataTable.Rows("0").Item("Status").ToString()

                Select Case False
                    Case _nPassKey = _mPassKey
                        _mResult = "Invalid Passkey."
                        Return False
                    Case _nWebEmail = _mWebEmail
                        _mResult = "Email address did not match with local email."
                        Return False
                    Case (_nOffice = "license" And _mOffice = "BPLO" Or UCase(_mOffice) = "REGULATORY") Or (_nOffice = "treasurer" And _mOffice = "Treasury")
                        _mResult = "Invalid User Type."
                        Return False
                    Case _nWebUser <> "0"
                        _mResult = "Unauthorized Web User."
                        Return False
                    Case _mStatus = "0"
                        _mResult = "Inactive Local User."
                        Return False
                    Case Else
                        Return True
                End Select

            End If

            _nDal = Nothing

            '----------------------------------
        Catch ex As Exception
            _pSubEventLog(ex, 2)
            Return False

        End Try
        'Commented temporarily by Tomi 10/14/2019
        '_pSubEventLog("Verify LGU Registry" & ":End")
        '_pSubEventLog(_nSw.Elapsed, 2)
    End Function '@ Added 20180727 

#End Region



End Class
