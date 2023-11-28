Public Class cDalRegulatoryFees

#Region "Variable Field"


    Private _mDeptCode As String
    Private _mDeptName As String
    Private _mTaxCode As String
    Private _mTaxDesc As String
    Private _mDefaultAmount As Double

    Private _mFeesDue As Double

#End Region


#Region "Property Field"

    Public Property _pDeptCode As String
        Get
            Return _mDeptCode
        End Get
        Set(value As String)
            _mDeptCode = value
        End Set
    End Property

    Public Property _pDeptName As String
        Get
            Return _mDeptName
        End Get
        Set(value As String)
            _mDeptName = value
        End Set
    End Property

    Public Property _pTaxCode As String
        Get
            Return _mTaxCode
        End Get
        Set(value As String)
            _mTaxCode = value
        End Set
    End Property

    Public Property _pTaxDesc As String
        Get
            Return _mTaxDesc
        End Get
        Set(value As String)
            _mTaxDesc = value
        End Set
    End Property

    Public Property _pDefaultAmount As Double
        Get
            Return _mDefaultAmount
        End Get
        Set(value As Double)
            _mDefaultAmount = value
        End Set
    End Property

    Public Property _pFeesDue As Double
        Get
            Return _mFeesDue
        End Get
        Set(value As Double)
            _mFeesDue = value
        End Set
    End Property

#End Region


#Region "Routine"

    Public Sub _pLoadDefaultFeesGridview(_nGridview As GridView)
        Try
            Dim _nSuccessful As Boolean
            Dim _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = " Select * from Regulatory_DefaultFees "
                ._pCondition = ""
                ._pExec(_nSuccessful, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    cGridview._pGridviewBind(_nDataTable, _nGridview)
                Else
                    cGridview.pEmptyGridView(_nDataTable, _nGridview, "No Data Available...")
                End If

            End With
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pLoadFeesGridview(_nGridView As GridView)
        Try
            Dim _nSuccessfull As Boolean
            Dim _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD

            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = " Select * from Regulatory_Fees "
                ._pCondition = " WHERE ApplicationID =  ''" & cSessionLoader_NEWBP_Draft._pApplication_ID & "'' and ForYear = Year(GETDATE()) and DeptCode = ''" & _mDeptCode & "''"

                ._pExec(_nSuccessfull, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = _nClass._pDataTable

                Try
                    '----------------------------------
                    If _nDataTable.HasErrors Then

                    End If

                    If _nDataTable.Rows.Count > 0 Then
                        _nGridView.DataSource = _nDataTable
                        _nGridView.DataBind()
                    Else
                        cEmptyGridview.pEmpyGridViewWithHeader(_nGridView, _nDataTable, "No record available")
                    End If
                    '----------------------------------
                Catch ex As Exception

                End Try
            End With
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSaveFees()
        Try
            Dim _nSuccessful As Boolean
            Dim _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "INSERT"
                ._pSelect = "INSERT INTO Regulatory_Fees " & _
                            " (ApplicationID, ForYear, DeptCode, TaxCode, Amount, TaxDesc)" & _
                            " Values " & _
                            " (''" & cSessionLoader_NEWBP_Draft._pApplication_ID & "'', Year(Getdate()), ''" & _mDeptCode & "'',''" & _mTaxCode & "'',''" & _mFeesDue & "'',''" & _mTaxDesc & "'')"
                ._pExec(_nSuccessful, _nErrMsg)

            End With
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pUpdateFees()
        Try
            Dim _nSuccessful As Boolean
            Dim _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "UPDATE"
                ._pSelect = "UPDATE Regulatory_Fees " & _
                            "SET [Amount] = ''" & _mFeesDue & "''  "
                ._pCondition = " WHERE ApplicationID = ''" & cSessionLoader_NEWBP_Draft._pApplication_ID & "'' AND DeptCode = ''" & _mDeptCode & "'' AND TAXCODE = ''" & _mTaxCode & "''"
                ._pExec(_nSuccessful, _nErrMsg)

            End With
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pRemoveFees()
        Try
            Dim _nSuccessful As Boolean
            Dim _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "DELETE"
                ._pSelect = "DELETE FROM Regulatory_Fees "
                ._pCondition = " WHERE ApplicationID = ''" & cSessionLoader_NEWBP_Draft._pApplication_ID & "'' AND DeptCode = ''" & _mDeptCode & "'' AND TAXCODE = ''" & _mTaxCode & "''"
                ._pExec(_nSuccessful, _nErrMsg)

            End With
        Catch ex As Exception

        End Try
    End Sub

    Public Function _GetFeesTotal() As String
        Try
            Dim _nSuccessfull As Boolean
            Dim _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD

            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = " Select SUM(Amount) as TotalFees from Regulatory_Fees "
                ._pCondition = " WHERE ApplicationID =  ''" & cSessionLoader_NEWBP_Draft._pApplication_ID & "'' and ForYear = Year(GETDATE()) and DeptCode = ''" & _mDeptCode & "''"

                ._pExec(_nSuccessfull, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = _nClass._pDataTable

                Try
                    '----------------------------------
                    If _nDataTable.HasErrors Then
                        Return "0.00"
                    End If

                    If _nDataTable.Rows.Count > 0 Then
                        Return IIf(_nDataTable.Rows(0).Item("TotalFees").ToString = Nothing, "0.00", _nDataTable.Rows(0).Item("TotalFees").ToString)
                    Else
                        Return "0.00"
                    End If
                    '----------------------------------
                Catch ex As Exception

                End Try
            End With
        Catch ex As Exception

        End Try

    End Function
#End Region

End Class
