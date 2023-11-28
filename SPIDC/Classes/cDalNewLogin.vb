


#Region "Import"
Imports System.Data.SqlClient
#End Region
Public Class cDalNewLogin

#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Public Shared _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader

    Public Shared _IDNO As String
    Public Shared _Agent As String
    Public Shared _Fname As String
    Public Shared _Lname As String
    Public Shared _BDate As String
    Public Shared _Gender As String
    Public Shared _Email As String
    Public Shared _MobileNo As String
    Public Shared _Residency As String
    Public Shared _Password As String
    Public Shared _UserKeySalt As String
    Public Shared _KeyToken As String
   
    Public Shared _Recidency As Boolean = Nothing
    Public Shared _SecQuestion As String = Nothing
    Public Shared _SecAnswer As String = Nothing
    Public Shared _UserType As String = Nothing ' Taxpayer , LGU
    Public Shared _Office As String = Nothing ' Taxpayer , BPLO,ASSESSOR,TREASUTY,etc..





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

#Region "Variable Field"


#End Region

#Region "Routine Command"
    Public Function _isEmailExists(ByVal Email As String) As Boolean
        Dim hasRows As Boolean = False
        Try
            Dim _nQuery As String =
                " SELECT * from Registered where UserId='" & Email & "'"
            _mQuery = _nQuery
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    hasRows = True
                Else
                    hasRows = False
                End If
            End Using
            Return hasRows
        Catch ex As Exception
            Return hasRows
        End Try
    End Function

    Public Function _isEmailActivated(ByVal Email As String) As Boolean
        Dim hasRows As Boolean = False
        Try
            Dim _nQuery As String =
                " SELECT * from Registered where UserId='" & Email & "' and isActivated='1'"
            _mQuery = _nQuery
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    hasRows = True
                Else
                    hasRows = False
                End If
            End Using
            Return hasRows
        Catch ex As Exception
            Return hasRows
        End Try
    End Function

    Public Function Get_UserKeySalt(ByVal Email As String) As Byte()
        Dim UserKeySalt As Byte() = Nothing
        Try
            Dim _nQuery As String =
                " SELECT * from Registered where UserId='" & Email & "'"
            _mQuery = _nQuery
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        UserKeySalt = _nSqlDr("UserKeySalt")
                    Loop
                Else
                    UserKeySalt = Nothing
                End If
            End Using
            Return UserKeySalt
        Catch ex As Exception
            Return UserKeySalt
        End Try
    End Function

    Public Sub Get_UserDetails(ByVal Email As String)
        Try
            Dim _nQuery As String =
                " SELECT * from Registered where UserId='" & Email & "'"
            _mQuery = _nQuery
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        cSessionUser._pUsertype = _nSqlDr("UserType")
                        cSessionUser._pOffice = _nSqlDr("Office")
                        cSessionLoader._pKeyToken = _nSqlDr("KeyToken")
                        cSessionUser._pUserLevel = _nSqlDr("UserLevel")
                        cSessionUser._pFirstName = _nSqlDr("FirstName")
                        cSessionUser._pLastName = _nSqlDr("LastName")
                        cSessionUser._pMiddleName = _nSqlDr("MiddleName")
                    Loop
                End If
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Public Function _isPasswordCorrect(ByVal Email As String, ByVal Password As String, ByVal UserKeySalt As Byte()) As Boolean
        Dim hasRows As Boolean = False
        Try
            Dim _nEncryption As New cEncryption20140609
            Dim _nEncryptedUserKey As String = _nEncryption.Encrypt(Password, UserKeySalt)
            Dim _nQuery As String =
                " SELECT * from Registered where UserId='" & Email & "' and UserKey='" & _nEncryptedUserKey & "'"
            _mQuery = _nQuery
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    hasRows = True
                Else
                    hasRows = False
                End If
            End Using
            Return hasRows
        Catch ex As Exception
            Return False
        End Try
    End Function



    Public Shared Function Insert_Done() As Boolean
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "INSERT INTO REGISTERED( " & _
                        "[IDNo],[UserID],[DateRegistered]," & _
                        "[UserKey],[UserKeySalt],[UserType]," & _
                        "[LastName],[FirstName],[BirthDate]," & _
                        "[Gender],[Resident],[Contact_Cp]," & _
                        "[Office],[KeyToken])" & _
                      " VALUES (" & _
                        "@IDNo,@UserID,GETDATE()," & _
                        "@UserKey,@UserKeySalt,@UserType," & _
                        "@LastName,@FirstName,@BirthDate," & _
                        "@Gender,@Resident,@Contact_Cp," & _
                        "@Office,@KeyToken)"
            Dim _nSqlCommand As New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_CR)
            With _nSqlCommand.Parameters
                .AddWithValue("@IDNo", _IDNO)
                .AddWithValue("@UserID", _Email)
                .AddWithValue("@UserKey", _Password)
                .AddWithValue("@UserKeySalt", _UserKeySalt)
                .AddWithValue("@UserType", "TAXPAYER")
                .AddWithValue("@LastName", _Lname)
                .AddWithValue("@FirstName", _Fname)
                .AddWithValue("@BirthDate", _BDate)
                .AddWithValue("@Gender", _Gender)
                .AddWithValue("@Resident", _Residency)
                .AddWithValue("@Contact_Cp", _MobileNo)
                .AddWithValue("@Office", _Agent)
                .AddWithValue("@KeyToken", _KeyToken)
            End With
            _nSqlCommand.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function Get_IDNO() As String
        Try
            Dim idno As String
            Dim _nQuery As String =
                " select case when" & _
                " isnull((select top 1 (idno + 1) from registered where idno like concat(format(getdate(),'yyyyMMdd'),'&') order by idno desc),0) = 0 " & _
                " then" & _
                " (Select concat(FORMAT (getdate(), 'yyyyMMdd' )," & _
                " (SELECT REPLACE(STR((select count(*) +1 from [Registered]  where idno like concat(format(getdate(),'yyyyMMdd'),'&')),6),' ','0')) ))" & _
                " else" & _
                " cast((select top 1 idno from registered order by idno desc) as bigint ) +1" & _
                " end IDNO"
            _mQuery = _nQuery
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        idno = _nSqlDr("IDNO")
                    Loop
                Else
                    idno = Nothing
                End If
            End Using
            Return idno
        Catch ex As Exception
            Return Nothing
        End Try
    End Function




#End Region




End Class
