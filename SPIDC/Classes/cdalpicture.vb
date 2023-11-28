

#Region "Imports"

Imports System.Data
Imports System.Data.SqlClient
Imports VB.NET.Methods
'Imports VS2014.CL.BPLTIMS.Resources


#End Region

Public Class cdalpicture

#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mStrCon As String

    Private _mSqlCommand As SqlCommand
    Private _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader

    Private Shared _mQuery As String = Nothing

#End Region

#Region "Properties Data"

    Public ReadOnly Property _pSqlCommand() As SqlCommand
        Get
            Return _mSqlCommand
        End Get
    End Property

    Public ReadOnly Property _pDataTable() As DataTable
        Get
            Try
                Return _mDataTable
                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public Property _pSqlCon() As SqlConnection
        Get
            Try
                Return _mSqlCon
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
        Set(value As SqlConnection)
            _mSqlCon = value
        End Set
    End Property

    Public ReadOnly Property _pSqlDataReader() As SqlDataReader
        Get
            Try
                '----------------------------------
                '_mSqlDataReader = Nothing
                _mSqlDataReader = _mSqlCommand.ExecuteReader

                Return _mSqlDataReader
                ' _mSqlCommand.Dispose()
                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

#End Region

#Region "Variables Field"


    Private _mACCTNO As String
    Private _mFileExtn As String
    Private _mpicdata As Byte()
    Private _mFileName As String
    Private _mFileNo As String
    Private _mForYear As String
    Private _mUniqueID As String



#End Region

#Region "Properties Field"

    Public Property _pFileExtn() As String
        Get
            Return _mFileExtn
        End Get
        Set(ByVal value As String)
            _mFileExtn = value
        End Set
    End Property

    Public Property _pACCTNO() As String
        Get
            Return _mACCTNO
        End Get
        Set(ByVal value As String)
            _mACCTNO = value
        End Set
    End Property
    Public Property _ppicdata() As Byte()
        Get
            Return _mpicdata
        End Get
        Set(ByVal value As Byte())
            _mpicdata = value
        End Set
    End Property

    Public Property _pFileName() As String
        Get
            Return _mFileName
        End Get
        Set(ByVal value As String)
            _mFileName = value
        End Set
    End Property

    Public Property _pFileNo() As String
        Get
            Return _mFileNo
        End Get
        Set(ByVal value As String)
            _mFileNo = value
        End Set
    End Property

    Public Property _pForYear() As String
        Get
            Return _mForYear
        End Get
        Set(ByVal value As String)
            _mForYear = value
        End Set
    End Property

    Public Property _pUniqueID As String
        Get
            Return _mUniqueID
        End Get
        Set(ByVal value As String)
            _mUniqueID = value
        End Set
    End Property
#End Region



#Region "Routine Command"

    Public Sub _pSubSelectowner()
        Try
            '----------------------------------
            _mQuery = _
            " SELECT TOP 1 pic_owner,O_FileType,O_FileName   " & _
            " FROM BPLTAS_PICTURES WHERE ACCTNO = '" & _mACCTNO & "' AND XDEFAULT = '1' AND ISNULL(O_FileType,'')<>'' ORDER BY XCODE DESC"

            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            '---------------------------------- 
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                If IsDBNull(_mDataTable.Rows(0).Item("O_FileType")) Then
                    _mFileExtn = ""
                    _mFileName = ""
                Else
                    _mFileExtn = _mDataTable.Rows(0).Item("O_FileType")
                    _mFileName = _mDataTable.Rows(0).Item("O_FileName")
                End If
            End If

            _nSqlDataAdapter.Dispose()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectowner_Temp() '@Added 20200217
        Try
            '----------------------------------
            _mQuery = _
            " SELECT TOP 1 pic_owner,O_FileType,O_FileName   " & _
            " FROM BPLTAS_PICTURES_Temp WHERE ID = '" & _mUniqueID & "' "

            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            '---------------------------------- 
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                If IsDBNull(_mDataTable.Rows(0).Item("O_FileType")) Then
                    _mFileExtn = ""
                    _mFileName = ""
                Else
                    _mFileExtn = _mDataTable.Rows(0).Item("O_FileType")
                    _mFileName = _mDataTable.Rows(0).Item("O_FileName")
                End If
            End If

            _nSqlDataAdapter.Dispose()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectestab_Temp()
        Try
            '----------------------------------
            _mQuery = _
            " SELECT TOP 1 picture,E_FileType,E_FileName  " & _
            " FROM BPLTAS_PICTURES_Temp WHERE ID = '" & _mUniqueID & "' "

            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)

            '----------------------------------
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nSqlCommand)

            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                If IsDBNull(_mDataTable.Rows(0).Item("E_FileType")) Then
                    _mFileExtn = ""
                    _mFileName = ""
                Else

                    _mFileExtn = _mDataTable.Rows(0).Item("E_FileType")
                    _mFileName = _mDataTable.Rows(0).Item("E_FileName")
                End If
            End If
            _nSqlDataAdapter.Dispose()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectmap_Temp()
        Try
            '----------------------------------
            _mQuery = _
            " SELECT TOP 1 pic_location,M_FileType,M_FileName  " & _
            " FROM BPLTAS_PICTURES_Temp WHERE ID = '" & _mUniqueID & "'  "

            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            '----------------------------------
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nSqlCommand)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                If IsDBNull(_mDataTable.Rows(0).Item("M_FileType")) Then
                    _mFileExtn = ""
                    _mFileName = ""
                Else
                    _mFileExtn = _mDataTable.Rows(0).Item("M_FileType")
                    _mFileName = _mDataTable.Rows(0).Item("M_FileName")
                End If
            End If
            _nSqlDataAdapter.Dispose()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pTemp_SubSelectowner()
        Try
            '----------------------------------
            _mQuery = _
            " SELECT TOP 1 pic_owner,O_FileType,O_FileName   " & _
            " FROM TEMP_BPLTAS_PICTURES WHERE UNIQUEID = '" & _mUniqueID & "' "

            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            '---------------------------------- 
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                If IsDBNull(_mDataTable.Rows(0).Item("O_FileType")) Then
                    _mFileExtn = ""
                    _mFileName = ""
                Else
                    _mFileExtn = _mDataTable.Rows(0).Item("O_FileType")
                    _mFileName = _mDataTable.Rows(0).Item("O_FileName")
                End If
            End If

            _nSqlDataAdapter.Dispose()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectowner2() ' Added 20180306 == Select Latest Uploaded Image by Taxpayer /xDefault not filtered
        Try
            '----------------------------------
            _mQuery = _
            " SELECT TOP 1 pic_owner,O_FileType,O_FileName  " & _
            " FROM BPLTAS_PICTURES WHERE ACCTNO = '" & _mACCTNO & "' AND ISNULL(O_FileType,'')<>'' ORDER BY XCODE DESC"

            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            '---------------------------------- 
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                If IsDBNull(_mDataTable.Rows(0).Item("O_FileType")) Then
                    _mFileExtn = ""
                    _mFileName = ""
                Else
                    _mFileExtn = _mDataTable.Rows(0).Item("O_FileType")
                    _mFileName = _mDataTable.Rows(0).Item("O_FileName")
                End If
            End If

            _nSqlDataAdapter.Dispose()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectTOPFile()
        Try
            'BPLTAS FILE
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS_F"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nLiveServerName As String = _nClBP._pDBDataSource
            Dim _nLiveDatabaseName As String = _nClBP._pDBInitialCatalog

            '----------------------------------
            _mQuery = _
            " SELECT *  FROM [" & _nLiveServerName & "].[" & _nLiveDatabaseName & "].[dbo].[TOPFile] " & _
            " WHERE FORYEAR = (SELECT YEAR(getdate()) as xYear) AND xFileNo ='" & _mFileNo & "'"

            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            '---------------------------------- 
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                If IsDBNull(_mDataTable.Rows(0).Item("xFileName")) Then
                    _mFileExtn = ""
                    _mFileName = ""
                Else
                    _mFileExtn = ".pdf"
                    _mFileName = _mDataTable.Rows(0).Item("xFileName")
                End If
            End If

            _nSqlDataAdapter.Dispose()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectestab()
        Try
            '----------------------------------
            _mQuery = _
            " SELECT TOP 1 picture,E_FileType,E_FileName  " & _
            " FROM BPLTAS_PICTURES WHERE ACCTNO = '" & _mACCTNO & "' AND XDEFAULT = '1' AND ISNULL(E_FileType,'')<>'' ORDER BY XCODE DESC "

            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)

            '----------------------------------
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nSqlCommand)

            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                If IsDBNull(_mDataTable.Rows(0).Item("E_FileType")) Then
                    _mFileExtn = ""
                    _mFileName = ""
                Else

                    _mFileExtn = _mDataTable.Rows(0).Item("E_FileType")
                    _mFileName = _mDataTable.Rows(0).Item("E_FileName")
                End If
            End If
            _nSqlDataAdapter.Dispose()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

  

    Public Sub _pTemp_SubSelectestab()
        Try
            '----------------------------------
            _mQuery = _
            " SELECT TOP 1 picture,E_FileType,E_FileName  " & _
            " FROM TEMP_BPLTAS_PICTURES WHERE UNIQUEID = '" & _mUniqueID & "' "

            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)

            '----------------------------------
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nSqlCommand)

            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                If IsDBNull(_mDataTable.Rows(0).Item("E_FileType")) Then
                    _mFileExtn = ""
                    _mFileName = ""
                Else

                    _mFileExtn = _mDataTable.Rows(0).Item("E_FileType")
                    _mFileName = _mDataTable.Rows(0).Item("E_FileName")
                End If
            End If
            _nSqlDataAdapter.Dispose()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectestab2() ' Added 20180306 == Select Latest Uploaded Image by Taxpayer /xDefault not filtered
        Try
            '----------------------------------
            _mQuery = _
            " SELECT TOP 1 picture,E_FileType,E_FileName  " & _
            " FROM BPLTAS_PICTURES WHERE ACCTNO = '" & _mACCTNO & "' AND ISNULL(E_FileType,'')<>'' ORDER BY XCODE DESC "

            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)

            '----------------------------------
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nSqlCommand)

            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                If IsDBNull(_mDataTable.Rows(0).Item("E_FileType")) Then
                    _mFileExtn = ""
                    _mFileName = ""
                Else

                    _mFileExtn = _mDataTable.Rows(0).Item("E_FileType")
                    _mFileName = _mDataTable.Rows(0).Item("E_FileName")
                End If
            End If
            _nSqlDataAdapter.Dispose()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectmap()
        Try
            '----------------------------------
            _mQuery = _
            " SELECT TOP 1 pic_location,M_FileType,M_FileName  " & _
            " FROM BPLTAS_PICTURES WHERE ACCTNO = '" & _mACCTNO & "' AND XDEFAULT = '1' AND ISNULL(M_FileType,'')<>'' ORDER BY XCODE DESC "

            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            '----------------------------------
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nSqlCommand)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                If IsDBNull(_mDataTable.Rows(0).Item("M_FileType")) Then
                    _mFileExtn = ""
                    _mFileName = ""
                Else
                    _mFileExtn = _mDataTable.Rows(0).Item("M_FileType")
                    _mFileName = _mDataTable.Rows(0).Item("M_FileName")
                End If
            End If
            _nSqlDataAdapter.Dispose()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pTemp_SubSelectmap()
        Try
            '----------------------------------
            _mQuery = _
            " SELECT TOP 1 pic_location,M_FileType,M_FileName  " & _
            " FROM TEMP_BPLTAS_PICTURES WHERE UNIQUEID = '" & _mUniqueID & "'  "

            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            '----------------------------------
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nSqlCommand)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                If IsDBNull(_mDataTable.Rows(0).Item("M_FileType")) Then
                    _mFileExtn = ""
                    _mFileName = ""
                Else
                    _mFileExtn = _mDataTable.Rows(0).Item("M_FileType")
                    _mFileName = _mDataTable.Rows(0).Item("M_FileName")
                End If
            End If
            _nSqlDataAdapter.Dispose()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectmap2() ' Added 20180306 == Select Latest Uploaded Image by Taxpayer /xDefault not filtered
        Try
            '----------------------------------
            _mQuery = _
            " SELECT TOP 1 pic_location,M_FileType,M_FileName  " & _
            " FROM BPLTAS_PICTURES WHERE ACCTNO = '" & _mACCTNO & "' AND ISNULL(M_FileType,'')<>'' ORDER BY XCODE DESC "

            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            '----------------------------------
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nSqlCommand)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                If IsDBNull(_mDataTable.Rows(0).Item("M_FileType")) Then
                    _mFileExtn = ""
                    _mFileName = ""
                Else
                    _mFileExtn = _mDataTable.Rows(0).Item("M_FileType")
                    _mFileName = _mDataTable.Rows(0).Item("M_FileName")
                End If
            End If
            _nSqlDataAdapter.Dispose()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubUpdateImageowner()
        Try

            _mQuery = _
             "UPDATE " & _
              "[BPLTAS_PICTURES] SET " & _
              " PIC_OWNER = @pic  , O_FileType = @extn, O_FileName = '" & _mFileName & "' " & _
              "WHERE [ACCTNO] = '" & _mACCTNO & "' AND  XCODE = (SELECT MAX(XCODE) FROM BPLTAS_PICTURES  WHERE ACCTNO = '" & _mACCTNO & "') "

            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            With _nSqlCommand.Parameters
                .AddWithValue("@pic", _mpicdata)
                .AddWithValue("@extn", _mFileExtn)

            End With
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubUpdateImageowner_Temp() ' @Added 20200217 -Louie
        Try

            _mQuery = _
             "UPDATE " & _
              "[BPLTAS_PICTURES_TEMP] SET " & _
              " PIC_OWNER = @pic  , O_FileType = @extn, O_FileName = '" & _mFileName & "' " & _
              "WHERE [ID] = '" & _mUniqueID & "'  "

            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            With _nSqlCommand.Parameters
                .AddWithValue("@pic", _mpicdata)
                .AddWithValue("@extn", _mFileExtn)

            End With
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubUpdateImagemap_Temp() '@Added 20200217
        Try

            _mQuery = _
             "UPDATE " & _
              "[BPLTAS_PICTURES_TEMP] SET " & _
              " pic_location = @pic , M_FileType = @extn, M_FileName = '" & _mFileName & "'" & _
              "WHERE [ID] = '" & _mUniqueID & "'  "

            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            With _nSqlCommand.Parameters
                .AddWithValue("@pic", _mpicdata)
                .AddWithValue("@extn", _mFileExtn)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub

    Public Sub _pSubUpdateImageestab_Temp()  '@Added 20200217
        Try

            _mQuery = _
             "UPDATE " & _
              "[BPLTAS_PICTURES_TEMP] SET " & _
              " PICTURE = @pic , E_FileType = @extn, E_FileName = '" & _mFileName & "' " & _
              "WHERE [ID] = '" & _mUniqueID & "' "



            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            With _nSqlCommand.Parameters
                .AddWithValue("@pic", _mpicdata)
                .AddWithValue("@extn", _mFileExtn)

            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pTemp_SubUpdateImageowner()
        Try

            _mQuery = _
             "UPDATE " & _
              "[TEMP_BPLTAS_PICTURES] SET " & _
              " PIC_OWNER = @pic  , O_FileType = @extn, O_FileName = '" & _mFileName & "' " & _
              "WHERE [UNIQUEID] = '" & _mUniqueID & "'  "

            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            With _nSqlCommand.Parameters
                .AddWithValue("@pic", _mpicdata)
                .AddWithValue("@extn", _mFileExtn)

            End With
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pTemp_SubUpdateImageestab()
        Try

            _mQuery = _
             "UPDATE " & _
              "[TEMP_BPLTAS_PICTURES] SET " & _
              " PICTURE = @pic , E_FileType = @extn, E_FileName = '" & _mFileName & "' " & _
              "WHERE [UNIQUEID] = '" & _mUniqueID & "' "



            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            With _nSqlCommand.Parameters
                .AddWithValue("@pic", _mpicdata)
                .AddWithValue("@extn", _mFileExtn)

            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pTemp_SubUpdateImagemap()
        Try

            _mQuery = _
             "UPDATE " & _
              "[TEMP_BPLTAS_PICTURES] SET " & _
              " pic_location = @pic , M_FileType = @extn, M_FileName = '" & _mFileName & "'" & _
              "WHERE [UNIQUEID] = '" & _mUniqueID & "'  "

            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            With _nSqlCommand.Parameters
                .AddWithValue("@pic", _mpicdata)
                .AddWithValue("@extn", _mFileExtn)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub


    Public Sub _pSubUpdateEmptyImageowner() ' @ ADDED 20180308
        Try

            _mQuery = _
             "UPDATE " & _
              "[BPLTAS_PICTURES] SET " & _
              " PIC_OWNER = @pic  , O_FileType = @extn, O_FileName = '" & _mFileName & "'  " & _
              "WHERE [ACCTNO] = '" & _mACCTNO & "' AND XDEFAULT = 1 AND ISNULL(O_FileType,'')='' "

            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            With _nSqlCommand.Parameters
                .AddWithValue("@pic", _mpicdata)
                .AddWithValue("@extn", _mFileExtn)

            End With
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubUpdateImageestab()
        Try

            _mQuery = _
             "UPDATE " & _
              "[BPLTAS_PICTURES] SET " & _
              " PICTURE = @pic , E_FileType = @extn, E_FileName = '" & _mFileName & "' " & _
              "WHERE [ACCTNO] = '" & _mACCTNO & "' AND  XCODE = (SELECT MAX(XCODE) FROM BPLTAS_PICTURES WHERE ACCTNO = '" & _mACCTNO & "') "



            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            With _nSqlCommand.Parameters
                .AddWithValue("@pic", _mpicdata)
                .AddWithValue("@extn", _mFileExtn)

            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub



    Public Sub _pSubUpdateEmptyImageestab() ' @ ADDED 20180308
        Try

            _mQuery = _
             "UPDATE " & _
              "[BPLTAS_PICTURES] SET " & _
              " PICTURE = @pic , E_FileType = @extn, E_FileName = '" & _mFileName & "'  " & _
              "WHERE [ACCTNO] = '" & _mACCTNO & "' AND XDEFAULT = 1 AND ISNULL(E_FileType,'')='' "



            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            With _nSqlCommand.Parameters
                .AddWithValue("@pic", _mpicdata)
                .AddWithValue("@extn", _mFileExtn)

            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubUpdateImagemap()
        Try

            _mQuery = _
             "UPDATE " & _
              "[BPLTAS_PICTURES] SET " & _
              " pic_location = @pic , M_FileType = @extn, M_FileName = '" & _mFileName & "'" & _
              "WHERE [ACCTNO] = '" & _mACCTNO & "' AND  XCODE = (SELECT MAX(XCODE) FROM BPLTAS_PICTURES WHERE ACCTNO = '" & _mACCTNO & "') "

            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            With _nSqlCommand.Parameters
                .AddWithValue("@pic", _mpicdata)
                .AddWithValue("@extn", _mFileExtn)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub



    Public Sub _pSubUpdateEmptyImagemap()   ' @ ADDED 20180308
        Try

            _mQuery = _
             "UPDATE " & _
              "[BPLTAS_PICTURES] SET " & _
              " pic_location = @pic , M_FileType = @extn, M_FileName = '" & _mFileName & "' " & _
              "WHERE [ACCTNO] = '" & _mACCTNO & "' AND XDEFAULT = 1 AND ISNULL(M_FileType,'')='' "

            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            With _nSqlCommand.Parameters
                .AddWithValue("@pic", _mpicdata)
                .AddWithValue("@extn", _mFileExtn)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub

    Public Sub _pSubinsertblank()
        Try

            _mQuery = _
             "INSERT INTO " & _
              "[BPLTAS_PICTURES] " & _
              " (id,FORYEAR,ACCTNO,XCODE,XDEFAULT) " & _
              " VALUES " & _
              " ('" & _mACCTNO & "-0001', CONVERT(DATE, GETDATE()),'" & _mACCTNO & "','0001','1') "

            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub

    Public Sub _pSubCopyFileNewLine(xCode As String, xID As String)
        Try


            _mQuery = _
            " INSERT INTO BPLTAS_PICTURES " & _
            " ([ID], [ACCTNO], [FORYEAR], [REMARKS], [PICTURE], [XDEFAULT], [XCODE], [PIC_OWNER], [TMNO], [TMDATE], [BOOKACCUSED], [DSALESRECEIPT], [TMREMARKS], [INSPECTOR], [PIC_LOCATION], [DOWNLOADED], [UPLOADED], [O_FileType], [E_FileType], [M_FileType], [O_FileName], [E_FileName], [M_FileName]) " & _
            " SELECT TOP 1 '" & xID & "', [ACCTNO], Convert(DATE, GETDATE())  , [REMARKS], [PICTURE], 0, '" & xCode & "', [PIC_OWNER], [TMNO], [TMDATE], [BOOKACCUSED], [DSALESRECEIPT], [TMREMARKS], [INSPECTOR], [PIC_LOCATION], [DOWNLOADED], [UPLOADED], [O_FileType], [E_FileType], [M_FileType], [O_FileName], [E_FileName], [M_FileName] " & _
            " FROM BPLTAS_PICTURES WHERE ACCTNO = '" & _mACCTNO & "' ORDER BY ID DESC "

            '"INSERT INTO " & _
            ' "[BPLTAS_PICTURES] " & _
            ' " (id,FORYEAR,ACCTNO,XCODE,XDEFAULT) " & _
            ' " VALUES " & _
            ' " ('0001',GETDATE(),'" & _mACCTNO & "','0001','1') "



            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub

#End Region



End Class

