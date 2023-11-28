Imports System.Data.SqlClient
Imports System.Threading.Tasks

Public Class cEOR_Posting

    Public Shared _pPaymentRefNo
    Public Shared _pTransactionType
    Public Shared _pGateWaySelected
    Public Shared _pGateWayRefNo
    Public Shared _pTaxpayerEmail
    Public Shared _pEOR_No




    Public Shared Function _ProcessEORPosting(ByVal _nPaymentRefNo As String) As String
        _ProcessEORPosting = Nothing
        Try

            _pPaymentRefNo = _nPaymentRefNo
            _GetPaymentDetais()

            'START_POSTING()

        Catch ex As Exception

        End Try
    End Function


    Public Shared Function _IsWithExistingGen_OR() As Boolean
        _IsWithExistingGen_OR = False


        Dim result As String = Nothing
        Try
            Dim _Query As String = " Select SRS + LEFT(Setup,6) + '-' + OR_No as EOR_No from gen_or where PaymentRefno  = '" & _pPaymentRefNo & "' "
            Dim _SqlCommand = New SqlCommand(_Query, cGlobalConnections._pSqlCxn_TOIMS)
            Dim _nSqlDr As SqlDataReader = _SqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        _pEOR_No() = _nSqlDr("EOR_No").ToString
                        Return True
                    Loop
                End If
            End Using

        Catch ex As SqlException When ex.Number = -2 ' SQL Server timeout error code
            Console.WriteLine("A timeout error occurred: " + ex.Message)
            ' Handle the timeout error appropriately, such as retrying the operation or notifying the user
        Catch ex As Exception
            Console.WriteLine("An error occurred: " + ex.Message)
            ' Handle other exceptions here
        End Try

    End Function


    Private Shared Function _GetFromAssessment_TDN()
        
    End Function

    Private Shared Sub START_POSTING(ByRef err As String, Optional ByRef eORNO As String = Nothing, Optional ByVal isTaxpayer As Boolean = Nothing, Optional ByVal gatewayRefNo As String = Nothing, Optional ByRef strChecker As String = Nothing)
        'Dim qry As String = Nothing
        Dim rand As New Random() ' Create a new instance of the Random class    
        Task.Delay((rand.Next(1, 10)) * 1000).Wait()

        '_1PostPayment(err, eORNO, strChecker)
        ''    Response.Write(strChecker)
        'If String.IsNullOrEmpty(err) = False Then
        '    Response.Write(";_1PostPayment:" & err)
        '    Exit Sub
        'Else
        '    _2GetPostedDetails(err, eORNO, gatewayRefNo)

        '    If String.IsNullOrEmpty(err) = False Then
        '        Response.Write(";_2GetPostedDetails:" & err)
        '        Exit Sub
        '    End If
        'End If
        ''Dim HomeURL As String
        'If isTaxpayer = True Then
        '    Exit Sub
        'Else
        '    ' _GenerateReport_eOR(1, Process.TransactionType, eORNO)
        '    ' _3GenerateEORReport()
        'End If

    End Sub

    Private Shared Sub _GetPaymentDetais()
        Try


            Dim result As String = Nothing
            Try
                Dim _Query As String = "select acctno from onlinepaymentrefno where  GateWayRefNo ='" & _pGateWayRefNo & "'"
                Dim _SqlCommand = New SqlCommand(_Query, cGlobalConnections._pSqlCxn_OAIMS)
                Dim _nSqlDr As SqlDataReader = _SqlCommand.ExecuteReader
                Using _nSqlDr
                    If _nSqlDr.HasRows Then
                        Do While _nSqlDr.Read

                            _pTransactionType() = _nSqlDr("Type").ToString
                            _pGateWaySelected() = _nSqlDr("PAYMENTCHANNEL").ToString
                            _pGateWayRefNo() = _nSqlDr("GateWayRefNo").ToString
                            _pTaxpayerEmail() = _nSqlDr("EMAILADDR").ToString

                        Loop
                    End If
                End Using
            Catch ex As Exception

            End Try


        Catch ex As Exception

        End Try
    End Sub

    Private Function _GetLastOR() As String

    End Function

    Private Function _InsertGenOR()

    End Function

End Class
