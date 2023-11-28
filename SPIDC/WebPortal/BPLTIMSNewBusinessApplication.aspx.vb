Imports System.Net.Mail
Imports System.Net
Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Web.Services
Public Class BPLTIMSNewBusinessApplication
    Inherits System.Web.UI.Page
    Dim CatCode As String = ""
    Dim CatDesc As String = ""

   

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Try
            '----------------------------------

            If Not IsPostBack Then
                If String.IsNullOrEmpty(cSessionUser._pUserID()) Then
                    Response.Redirect("Register.aspx")
                End If
                Slide_08_Email.Value = cSessionUser._pUserID()
                '    getDataCategory()
                Get_Brgy()
                Get_Street()
                Get_Citizenship()
                _SetDefault()



            Else

            End If
            '----------------------------------
        Catch ex As Exception



        End Try
        End Sub


    Private Sub Get_Brgy()
        Try
            '----------------------------------
            Slide_07_Brgy.DataSourceID = Nothing

            Dim _nClass As New cDalBarangay
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass._pSubSelect()


            Dim _nDataSet As New DataSet()
            _nDataSet = _nClass._pDataSet

            Try
                '----------------------------------
                If _nDataSet.HasErrors Then
                    'Shoiw Blank Table
                    '  _mSubShowBlank()
                End If

                Slide_07_Brgy.DataSource = _nDataSet
                Slide_07_Brgy.DataTextField = "BRGYDESC"
                Slide_07_Brgy.DataValueField = "DISTCODE_BRGYCODE"
                Slide_07_Brgy.DataBind()

                Slide_07_Brgy.Items.Insert(0, New ListItem("Select Barangay", ""))

                '----------------------------------
            Catch ex As Exception
                'Shoiw Blank Table
                '  _mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Get_Street()
        Try
            '----------------------------------
            Slide_07_Street.DataSourceID = Nothing

            Dim _nClass As New cDalStreet
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass._pSubSelect()


            Dim _nDataSet As New DataSet()
            _nDataSet = _nClass._pDataSet

            Try
                '----------------------------------
                If _nDataSet.HasErrors Then
                    'Shoiw Blank Table
                    '  _mSubShowBlank()
                End If

                Slide_07_Street.DataSource = _nDataSet
                Slide_07_Street.DataTextField = "STRTDESC"
                Slide_07_Street.DataValueField = "BRGYCODE"
                Slide_07_Street.DataBind()

                Slide_07_Street.Items.Insert(0, New ListItem("Select Street", ""))

                '----------------------------------
            Catch ex As Exception
                'Shoiw Blank Table
                '  _mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Get_Citizenship()
        Try
            '----------------------------------
            Slide_08_Citizenship.DataSourceID = Nothing

            Dim _nClass As New cDalCitizenship
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass._pSubSelect()


            Dim _nDataSet As New DataSet()
            _nDataSet = _nClass._pDataset

            Try
                '----------------------------------
                If _nDataSet.HasErrors Then
                    'Shoiw Blank Table
                    '  _mSubShowBlank()
                End If

                Slide_08_Citizenship.DataSource = _nDataSet
                Slide_08_Citizenship.DataTextField = "CTZNDESC"
                Slide_08_Citizenship.DataValueField = "CTZNCODE"
                Slide_08_Citizenship.DataBind()

                Slide_08_Citizenship.Items.Insert(0, New ListItem("Citizenship", ""))

                '----------------------------------
            Catch ex As Exception
                'Shoiw Blank Table
                '  _mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub
  
 

  

    Protected Sub _oButton_Click(sender As Object, e As EventArgs) Handles Confirm_12.ServerClick
  
        Dim _nSuccessful As Boolean
        Dim _nErrMsg As String = ""
        Dim _nMsg As String = Nothing

        _PassValuetoClassLoader()
        _SaveInformation(_nSuccessful, _nErrMsg)
        If _nSuccessful = True Then
            ' === SAVE IMAGE ATTACHMENT =================================================================================================
            _mAcquireAttachmentTemp(_nSuccessful, _nErrMsg)

              ' === SAVE IMAGE REQUIREMENTS ===============================================================================================
            _AcquireRequirementSubmittedTemp(_nSuccessful, _nErrMsg)
            '============================================================================================================================

            Session("AccountNumber") = cSessionLoader._pAccountNo
            Response.Redirect("BPLTIMSBusinessLine.aspx")


        Else
            ScriptManager.RegisterStartupScript(Me, Page.[GetType](), "alert", "alert('Failed to Save Information:'  + _nErrMsg);", True)
            Exit Sub
        End If

    End Sub
End Class