Public Class Miscellaneous
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GetCategory()
        GetSpecific()
    End Sub
    Sub GetCategory()
        _oSelectCategory.DataSourceID = Nothing

        Dim _nClass As New cDalGetCertification
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_TIMS
        _nClass._pSubSelectCategory()

        Dim _nDataSet As New DataSet()
        _nDataSet = _nClass._pDataSet

        Try
            '----------------------------------
            If _nDataSet.HasErrors Then
                'Shoiw Blank Table
                '  _mSubShowBlank()
            End If

            _oSelectCategory.DataSource = _nDataSet
            _oSelectCategory.DataTextField = "GroupName"
            _oSelectCategory.DataValueField = "GroupCd"
            _oSelectCategory.DataBind()

           
            _oSelectCategory.Items.Insert(0, New ListItem("Select Category", "", False))



            '----------------------------------
        Catch ex As Exception
            'Shoiw Blank Table
            '  _mSubShowBlank()
        End Try
    End Sub
    Sub GetSpecific()
        _oSelectSpecific.DataSourceID = Nothing

        Dim _nClass As New cDalGetCertification
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_TIMS
        _nClass._pSubSelectSpecific()

        Dim _nDataSet As New DataSet()
        _nDataSet = _nClass._pDataSet

        Try
            '----------------------------------
            If _nDataSet.HasErrors Then
                'Shoiw Blank Table
                '  _mSubShowBlank()
            End If

            _oSelectSpecific.DataSource = _nDataSet
            _oSelectSpecific.DataTextField = "Description"
            _oSelectSpecific.DataValueField = "GroupCd_AcctNo_Description_Fee"
            _oSelectSpecific.DataBind()

            _oSelectSpecific.Items.Insert(0, New ListItem("Select Misc", "", False))




            '----------------------------------
        Catch ex As Exception
            'Shoiw Blank Table
            '  _mSubShowBlank()
        End Try
    End Sub
  

End Class