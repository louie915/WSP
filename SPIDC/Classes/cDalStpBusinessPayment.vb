

#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods


#End Region

Public Class cDalStpBusinessPayment

#Region "Variables Data"
    Public Shared _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Public Shared _mSqlCommand As SqlCommand
    Private _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader




#End Region

#Region "Properties Data"
    Shared _nSuccessful As Object

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

Private Shared _mAmountInWord_Left as string
    Private Shared _mAmountInWord_Top As String
    Private Shared _mDateIssued_Left As String
    Private Shared _mDateIssued_Top As String
    Private Shared _mOr_Number_Left As String
    Private Shared _mOr_Number_Top As String
    Private Shared _mTable_Left As String
    Private Shared _mTable_Top As String
    Private Shared _mValidation_Left As String
    Private Shared _mValidation_Top As String




#End Region

#Region "Properties Field"
    Public Shared Pro
   Public Shared Property _pAmountInWord_Left() As String
        Get
            Return _mAmountInWord_Left
        End Get
        Set(value As String)
            _mAmountInWord_Left = value
        End Set
    End Property

    Public Shared Property _pAmountInWord_Top() As String
        Get
            Return _mAmountInWord_Top
        End Get
        Set(value As String)
            _mAmountInWord_Top = value
        End Set
    End Property

    Public Shared Property _pDateIssued_Left() As String
        Get
            Return _mDateIssued_Left
        End Get
        Set(value As String)
            _mDateIssued_Left = value
        End Set
    End Property

    Public Shared Property _pDateIssued_Top() As String
        Get
            Return _mDateIssued_Top
        End Get
        Set(value As String)
            _mDateIssued_Top = value
        End Set
    End Property

    Public Shared Property _pOr_Number_Left() As String
        Get
            Return _mOr_Number_Left
        End Get
        Set(value As String)
            _mOr_Number_Left = value
        End Set
    End Property

    Public Shared Property _pOr_Number_Top() As String
        Get
            Return _mOr_Number_Top
        End Get
        Set(value As String)
            _mOr_Number_Top = value
        End Set
    End Property

    Public Shared Property _pTable_Left() As String
        Get
            Return _mTable_Left
        End Get
        Set(value As String)
            _mTable_Left = value
        End Set
    End Property

    Public Shared Property _pTable_Top() As String
        Get
            Return _mTable_Top
        End Get
        Set(value As String)
            _mTable_Top = value
        End Set
    End Property

    Public Shared Property _pValidation_Left() As String
        Get
            Return _mValidation_Left
        End Get
        Set(value As String)
            _mValidation_Left = value
        End Set
    End Property

    Public Shared Property _pValidation_Top() As String
        Get
            Return _mValidation_Top
        End Get
        Set(value As String)
            _mValidation_Top = value
        End Set
    End Property

#End Region

#Region "Properties Field Original"

#End Region

#Region "Routine Command"

    Public Sub _pSubReqinsert()
        Try
            Dim _nQuery As String = Nothing ' For For Requirements module 20161114

            _nQuery = _
                "sp_StpBusinessPayment_IUD " & _
                " " & _
                "@Action= 'INSERT' " & _
                IIf(_mAmountInWord_Left = "", "", ",@AmountInWord_Left= N'" & _mAmountInWord_Left & "' ") & _
                IIf(_mAmountInWord_Top = "", "", ",@AmountInWord_Top= N'" & _mAmountInWord_Top & "' ") & _
                IIf(_mDateIssued_Left = "", "", ",@DateIssued_Left= N'" & _mDateIssued_Left & "' ") & _
                IIf(_mDateIssued_Top = "", "", ",@DateIssued_Top= N'" & _mDateIssued_Top & "' ") & _
                IIf(_mOr_Number_Left = "", "", ",@Or_Number_Left= N'" & _mOr_Number_Left & "' ") & _
                IIf(_mOr_Number_Top = "", "", ",@Or_Number_Top= N'" & _mOr_Number_Top & "' ") & _
                IIf(_mTable_Left = "", "", ",@Table_Left= N'" & _mTable_Left & "' ") & _
                IIf(_mTable_Top = "", "", ",@Table_Top= N'" & _mTable_Top & "' ") & _
                IIf(_mValidation_Left = "", "", ",@Validation_Left= N'" & _mValidation_Left & "' ") & _
                IIf(_mValidation_Top = "", "", ",@Validation_Top= N'" & _mValidation_Top & "' ") & _
              ") "

            _mQuery = _nQuery

            _mQuery = Replace(_mQuery, "(,", "(") ' INSERT INTO BUSMAST_WEB

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            'With _mSqlCommand.Parameters
            '    If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
            'End With

            _mSqlCommand.ExecuteNonQuery()
        Catch ex As Exception
            '_pSubEventLog(ex, 2)
        End Try

    End Sub

    Public Sub _pSubSelectDetails()
        Try
            Dim _nErrMsg As String = ""
            Dim _nOutput As String = ""
            '_mStrSql = Nothing
            Dim _nStrSql As String = ""
            Dim _nSelectCond As String
            'Dim _nCntQuery As String = Nothing
            Dim _nQuery As String = Nothing
            'Dim _nStartRowIndex As Integer
            '_nStartRowIndex = (_nPageIndex * _nPageSize) + 1

            _nSelectCond = ""

            _nStrSql = " EXEC [sp_StpBusinessPayment_IUD] " & _
                        " @Action = 'SELECT'" & _
                        ",@SelectCond = N'" & _nSelectCond & "'" & _
                        ",@Successful = @Successful output " & _
                        ",@ErrMsg = @ErrMsg output " & _
                        ""



            _mSqlCommand = New SqlCommand(_nStrSql, _mSqlCon)
            'set paramater Success
            _mSqlCommand.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCommand.Parameters("@Successful").Direction = ParameterDirection.Output



            'set paramater Error Msg
            _mSqlCommand.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCommand.Parameters("@ErrMsg").Direction = ParameterDirection.Output

            'Execute and Read the content with datareader
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                'If _nSqlDr.HasRows Then
                Do While _nSqlDr.Read

                    If IsDBNull(_nSqlDr.Item("AmountInWord_Left").ToString) Then
                        _mAmountInWord_Left = ""
                    Else
                        _mAmountInWord_Left = UCase(_nSqlDr.Item("AmountInWord_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("AmountInWord_Top").ToString) Then
                        _mAmountInWord_Top = ""
                    Else
                        _mAmountInWord_Top = UCase(_nSqlDr.Item("AmountInWord_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("DateIssued_Left").ToString) Then
                        _mDateIssued_Left = ""
                    Else
                        _mDateIssued_Left = UCase(_nSqlDr.Item("DateIssued_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("DateIssued_Top").ToString) Then
                        _mDateIssued_Top = ""
                    Else
                        _mDateIssued_Top = UCase(_nSqlDr.Item("DateIssued_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("Or_Number_Left").ToString) Then
                        _mOr_Number_Left = ""
                    Else
                        _mOr_Number_Left = UCase(_nSqlDr.Item("Or_Number_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("Or_Number_Top").ToString) Then
                        _mOr_Number_Top = ""
                    Else
                        _mOr_Number_Top = UCase(_nSqlDr.Item("Or_Number_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("Table_Left").ToString) Then
                        _mTable_Left = ""
                    Else
                        _mTable_Left = UCase(_nSqlDr.Item("Table_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("Table_Top").ToString) Then
                        _mTable_Top = ""
                    Else
                        _mTable_Top = UCase(_nSqlDr.Item("Table_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("Validation_Left").ToString) Then
                        _mValidation_Left = ""
                    Else
                        _mValidation_Left = UCase(_nSqlDr.Item("Validation_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("Validation_Top").ToString) Then
                        _mValidation_Top = ""
                    Else
                        _mValidation_Top = UCase(_nSqlDr.Item("Validation_Top").ToString)
                    End If



                Loop
                'End If
            End Using
            'Get values of parameter output
            _nSuccessful = _mSqlCommand.Parameters("@Successful").Value
            _nErrMsg = _mSqlCommand.Parameters("@ErrMsg").Value

            _mSqlCommand.Dispose()


        Catch ex As Exception

        End Try
    End Sub


    Public Shared Sub _pSubUpdateStp()
        Try
            Dim _nErrMsg As String = ""
            Dim _nOutput As String = ""
            Dim _nStrSql As String = ""
            Dim _nSelectCond As String = ""
            'Initialize String SQL


            _nStrSql = " EXEC [sp_StpCtcCorp_IUD] @Action = 'UPDATE'" & _
                                IIf(_mAmountInWord_Left = "", "", ",@AmountInWord_Left= N'" & _mAmountInWord_Left & "' ") & _
                                IIf(_mAmountInWord_Top = "", "", ",@AmountInWord_Top= N'" & _mAmountInWord_Top & "' ") & _
                                IIf(_mDateIssued_Left = "", "", ",@DateIssued_Left= N'" & _mDateIssued_Left & "' ") & _
                                IIf(_mDateIssued_Top = "", "", ",@DateIssued_Top= N'" & _mDateIssued_Top & "' ") & _
                                IIf(_mOr_Number_Left = "", "", ",@Or_Number_Left= N'" & _mOr_Number_Left & "' ") & _
                                IIf(_mOr_Number_Top = "", "", ",@Or_Number_Top= N'" & _mOr_Number_Top & "' ") & _
                                IIf(_mTable_Left = "", "", ",@Table_Left= N'" & _mTable_Left & "' ") & _
                                IIf(_mTable_Top = "", "", ",@Table_Top= N'" & _mTable_Top & "' ") & _
                                IIf(_mValidation_Left = "", "", ",@Validation_Left= N'" & _mValidation_Left & "' ") & _
                                IIf(_mValidation_Top = "", "", ",@Validation_Top= N'" & _mValidation_Top & "' ") & _
                                ",@Successful = @Successful output " & _
                                ",@ErrMsg = @ErrMsg output  "



            _mSqlCommand = New SqlCommand(_nStrSql, _mSqlCon)

            'set paramater Success
            _mSqlCommand.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCommand.Parameters("@Successful").Direction = ParameterDirection.Output
            'set paramater Error
            _mSqlCommand.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCommand.Parameters("@ErrMsg").Direction = ParameterDirection.Output

            'set paramater COde


            'Execute and Read the content
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        '_mCode = _nSqlDr.Item(0).ToString
                    Loop
                End If

            End Using
            'Get values of parameter output
            _nSuccessful = _mSqlCommand.Parameters("@Successful").Value
            _nErrMsg = _mSqlCommand.Parameters("@ErrMsg").Value
            _mSqlCommand.Dispose()



        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub _pSubInsert()
        Try
            Dim _nErrMsg As String = ""
            Dim _nOutput As String = ""
            Dim _nStrSql As String = ""


            _nStrSql = " EXEC [sp_StpBusinessPayment_IUD] @Action = 'INSERT'" & _
                                IIf(_mAmountInWord_Left = "", "", ",@AmountInWord_Left= N'" & _mAmountInWord_Left & "' ") & _
                                IIf(_mAmountInWord_Top = "", "", ",@AmountInWord_Top= N'" & _mAmountInWord_Top & "' ") & _
                                IIf(_mDateIssued_Left = "", "", ",@DateIssued_Left= N'" & _mDateIssued_Left & "' ") & _
                                IIf(_mDateIssued_Top = "", "", ",@DateIssued_Top= N'" & _mDateIssued_Top & "' ") & _
                                IIf(_mOr_Number_Left = "", "", ",@Or_Number_Left= N'" & _mOr_Number_Left & "' ") & _
                                IIf(_mOr_Number_Top = "", "", ",@Or_Number_Top= N'" & _mOr_Number_Top & "' ") & _
                                IIf(_mTable_Left = "", "", ",@Table_Left= N'" & _mTable_Left & "' ") & _
                                IIf(_mTable_Top = "", "", ",@Table_Top= N'" & _mTable_Top & "' ") & _
                                IIf(_mValidation_Left = "", "", ",@Validation_Left= N'" & _mValidation_Left & "' ") & _
                                IIf(_mValidation_Top = "", "", ",@Validation_Top= N'" & _mValidation_Top & "' ") & _
                                ",@Successful = @Successful output " & _
                                ",@ErrMsg = @ErrMsg output  " & _
                                " "





            _mSqlCommand = New SqlCommand(_nStrSql, _mSqlCon)

            'set paramater Success
            _mSqlCommand.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCommand.Parameters("@Successful").Direction = ParameterDirection.Output

            'set paramater Error
            _mSqlCommand.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCommand.Parameters("@ErrMsg").Direction = ParameterDirection.Output

            'Execute and Read the content

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        '_mCode = _nSqlDr.Item(0).ToString
                    Loop
                End If

            End Using
            'Get values of parameter output

            _nErrMsg = _mSqlCommand.Parameters("@ErrMsg").Value
            '_mCode = _mSqlCommand.Parameters("@Code").Value

            _mSqlCommand.Dispose()

            'Dim _nSqlDataAdapter As New SqlDataAdapter(_mStrSql, _mSqlCon) '_gDBCon
            '_nSqlDataAdapter.SelectCommand.ExecuteNonQuery()

            '_nSqlDataAdapter.Dispose()

        Catch ex As Exception

        End Try
    End Sub


#End Region
End Class

