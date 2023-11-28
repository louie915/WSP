Partial Public Class BPLTIMSNewBusinessApplication

    Protected Sub _oButton_Click(sender As Object, e As EventArgs) Handles _
         _oButtonSaveBusline.ServerClick
        _PassValuetoClassLoader()
        _SaveSeletecBusline()


    End Sub

    Private Sub _SaveSeletecBusline()
        Dim _nSuccessful As Boolean
        Dim _nErrMsg As String = ""

        For i As Integer = 0 To CheckBoxList1.Items.Count - 1

            If CheckBoxList1.Items(i).Selected Then
                cLoader_BPLTIMS._pBUS_CODE = CheckBoxList1.Items(i).Value
                '_nBusDesc += CheckBoxList1.Items(i).Text
                _SaveBusLine(_nSuccessful, _nErrMsg)
            End If
        Next

        _DeleteBusExtn(_nSuccessful, _nErrMsg)
        _SaveBusExtn(_nSuccessful, _nErrMsg)

    End Sub

    Public Sub _SaveBusLine(ByRef _nSuccessful As Boolean, Optional ByRef _nErrMsg As String = "")
        Try
            _nSuccessful = True

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "INSERT"
                ._pSelect = " INSERT INTO BUSLINE " & _
                            " ( " & _
                            " ACCTNO " & _
                            " ,FORYEAR " & _
                            " ,BUS_CODE " & _
                            " ,AREA " & _
                            " ,CAPITAL " & _
                            " ,GROSSREC " & _
                            " ) " & _
                            " VALUES " & _
                            " ( ''" & cLoader_BPLTIMS._pACCTNO & "'' " & _
                            " ,''" & cLoader_BPLTIMS._pFORYEAR & "'' " & _
                            " ,''" & cLoader_BPLTIMS._pBUS_CODE & "'' " & _
                            " ,''" & cLoader_BPLTIMS._pAREA & "'' " & _
                            " ,''" & cLoader_BPLTIMS._pCAPITAL & "'' " & _
                            " ,''" & cLoader_BPLTIMS._pGROSSREC & "'')"

                ._pExec(_nSuccessful, _nErrMsg)

            End With


        Catch ex As Exception
            _nSuccessful = False
        End Try

    End Sub

    Public Sub _SaveBusExtn(ByRef _nSuccessful As Boolean, Optional ByRef _nErrMsg As String = "")
        Try
            _nSuccessful = True

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "INSERT"
                ._pSelect = " INSERT INTO BUSEXTN " & _
                            " ( " & _
                            " ACCTNO " & _
                            " ,FORYEAR " & _
                            " ,STATCODE " & _
                            " ) " & _
                            " VALUES " & _
                            " ( ''" & cLoader_BPLTIMS._pACCTNO & "'' " & _
                            " ,''" & cLoader_BPLTIMS._pFORYEAR & "'' " & _
                            " ,''" & cLoader_BPLTIMS._pSTATCODE & "'') "

                ._pExec(_nSuccessful, _nErrMsg)

            End With


        Catch ex As Exception
            _nSuccessful = False
        End Try

    End Sub

    Public Sub _DeleteBusExtn(ByRef _nSuccessful As Boolean, Optional ByRef _nErrMsg As String = "")
        Try
            _nSuccessful = True

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "DELETE"
                ._pSelect = " DELETE FROM BUSEXTN  " & _
                            " WHERE ACCTNO = ''" & cLoader_BPLTIMS._pACCTNO & "'' " & _
                            " AND FORYEAR = ''" & cLoader_BPLTIMS._pFORYEAR & "'' " & _
                            " AND STATCODE = ''" & cLoader_BPLTIMS._pSTATCODE & "'' "

                ._pExec(_nSuccessful, _nErrMsg)

            End With


        Catch ex As Exception
            _nSuccessful = False
        End Try

    End Sub


End Class
