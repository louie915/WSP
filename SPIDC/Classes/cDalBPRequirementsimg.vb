

#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods
Imports VS2014.CL.BPLTIMS.Resources


#End Region

Public Class cDalBPRequirementsimg

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

    Private _mFileExtn As String
    Private _mFileName As String
    Private _mImagesID As String

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

    Public Property _pFileName() As String
        Get
            Return _mFileName
        End Get
        Set(ByVal value As String)
            _mFileName = value
        End Set
    End Property

    Public Property _pImagesID() As String
        Get
            Return _mImagesID
        End Get
        Set(ByVal value As String)
            _mImagesID = value
        End Set
    End Property

#End Region


#Region "Routine Command"


    Public Sub _pSubSelect()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.


            '----------------------------------
            _mQuery = _
            " SELECT FileExtn,Name,ImageData " & _
            " FROM BP_SubmittedReq WHERE ImagesID = '" & _mImagesID & "' "


            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)

            '----------------------------------
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nSqlCommand)

            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)

            '_mDataTable.Clear()
            '_nSqlDataAdapter.Fill(_mDataTable)

            If _mDataTable.Rows.Count > 0 Then

                If IsDBNull(_mDataTable.Rows(0).Item("FileExtn")) Then
                    _mFileExtn = ""
                    _mFileName = ""
                Else

                    _mFileExtn = _mDataTable.Rows(0).Item("FileExtn")
                    _mFileName = _mDataTable.Rows(0).Item("Name")
                End If





            End If

            _nSqlDataAdapter.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubSelect_Temp()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.


            '----------------------------------
            _mQuery = _
            " SELECT FileExtn,Name,ImageData " & _
            " FROM BP_SubmittedReq_Temp WHERE ImagesID = '" & _mImagesID & "' "


            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)

            '----------------------------------
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nSqlCommand)

            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)

            '_mDataTable.Clear()
            '_nSqlDataAdapter.Fill(_mDataTable)

            If _mDataTable.Rows.Count > 0 Then

                If IsDBNull(_mDataTable.Rows(0).Item("FileExtn")) Then
                    _mFileExtn = ""
                    _mFileName = ""
                Else

                    _mFileExtn = _mDataTable.Rows(0).Item("FileExtn")
                    _mFileName = _mDataTable.Rows(0).Item("Name")
                End If





            End If

            _nSqlDataAdapter.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
#End Region



End Class

