Imports System.Data.SqlClient
Imports System.Web.Services


Partial Public Class BPLTIMSNewBusinessApplication

    <WebMethod> _
    Public Sub _mSubDataBindRequirementsList(_nGridView As GridView, ByVal xOwnCode As String)
        Try
            '----------------------------------
            'Dim _nGridView As New GridView
            '_nGridView = _oGridViewRequirementsList
            _nGridView.DataSourceID = Nothing

            Dim _nClass As New cDalRequirements
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pReqYear = cSessionLoader._pCurrentYear
            _nClass._pReviewMode = cSessionLoader._pReviewMode
            _nClass._pStatus = "NEW"
            _nClass._pOwnCode = xOwnCode
            _nClass._pSubSelectReqList()
            '_nClass._pGetRequirementList(cCookieUser._pIDNo)

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try
                '----------------------------------
                If _nDataTable.HasErrors Then
                    '  _mSubShowEmptyTraningCourseGridView()
                End If

                If _nDataTable.Rows.Count > 0 Then
                    _nGridView.DataSource = _nDataTable
                    _nGridView.DataBind()

                Else
                    '  _mSubShowEmptyTraningCourseGridViewSearch()
                End If
                '----------------------------------
            Catch ex As Exception
                '_mSubShowEmptyTraningCourseGridView()
            End Try

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


End Class
