

#Region "Imports"

Imports System.Reflection
Imports System.Reflection.MethodBase
Imports System.Web.HttpContext
Imports System.Web.UI

#End Region

Public Class cControlValidation

#Region "Variables"

    Private Shared _mPrefix As String = GetCurrentMethod.DeclaringType.FullName

#End Region

#Region "Properties"

    Shared Property _psTextBoxCssOrig() As String
        Get
            Return Current.Session(_mPrefix & GetCurrentMethod.Name.Substring(4))
        End Get
        Set(ByVal value As String)
            Current.Session(_mPrefix & GetCurrentMethod.Name.Substring(4)) = value
        End Set
    End Property

    Shared ReadOnly Property _psTextBoxCssInvalid() As String
        Get
            Return _psTextBoxCssOrig & "Invalid"
        End Get
    End Property

#End Region

#Region "Routine"

    'Reset Control Properties.
    Shared Sub _pSubTextBoxSetProperties(
        _oContainer As Object
        )
        Try
            '---------- ---------- ---------- ----------
            ' Do Something.
            For Each _oControl As Control In _oContainer.Controls
                If TypeOf _oControl Is TextBox Then
                    Dim _oNewControl As TextBox = _oControl
                    _oNewControl.CssClass = _psTextBoxCssOrig
                End If

                'Recursive call.
                If _oControl.HasControls Then
                    _pSubTextBoxSetProperties(_oControl)
                End If
            Next
            '---------- ---------- ---------- ----------
        Catch ex As Exception

        End Try
    End Sub

    'Mark Required Controls.
    Shared Function _pFnControlIsRequired(
        _oControl As Object
        ) As Boolean

        _pFnControlIsRequired = False
        Try
            '---------- ---------- ---------- ----------
            Dim _nPage As Page = DirectCast(HttpContext.Current.Handler, Page)

            If TypeOf _oControl Is TextBox Then
                Dim _oNewControl As TextBox = _oControl
                If String.IsNullOrEmpty(_oNewControl.Text) Then
                    DirectCast(_nPage.FindControl(_oNewControl.UniqueID), TextBox).CssClass = _psTextBoxCssInvalid
                    Return True
                Else
                    DirectCast(_nPage.FindControl(_oNewControl.UniqueID), TextBox).CssClass = _psTextBoxCssOrig
                    Return False
                End If
            End If

            '---------- ---------- ---------- ----------
        Catch ex As Exception

        End Try
    End Function

    'Mark Required Controls.    ' @Added 20170308   - Louie
    Shared Function _pFnControlIsRequiredInc(
        _oControl As Object
        ) As Boolean

        _pFnControlIsRequiredInc = False
        Try
            '---------- ---------- ---------- ----------
            Dim _nPage As Page = DirectCast(HttpContext.Current.Handler, Page)

            If TypeOf _oControl Is TextBox Then
                Dim _oNewControl As TextBox = _oControl
                If String.IsNullOrEmpty(_oNewControl.Text) Then
                    DirectCast(_nPage.FindControl(_oNewControl.UniqueID), TextBox).CssClass = _psTextBoxCssInvalid
                    Return True
                Else
                    DirectCast(_nPage.FindControl(_oNewControl.UniqueID), TextBox).CssClass = _psTextBoxCssOrig
                    Return False
                End If
            End If

            '---------- ---------- ---------- ----------
        Catch ex As Exception

        End Try
    End Function

    'louie @ 
    Shared Function _pFnControlIsRequiredfileUpload(
       _oControl As Object
       ) As Boolean

        _pFnControlIsRequiredfileUpload = False
        Try
            '---------- ---------- ---------- ----------
            Dim _nPage As Page = DirectCast(HttpContext.Current.Handler, Page)

            If TypeOf _oControl Is FileUpload Then
                Dim _oNewControl As FileUpload = _oControl
                If (_oNewControl.HasFile) = False Then
                    DirectCast(_nPage.FindControl(_oNewControl.UniqueID), FileUpload).CssClass = _psTextBoxCssInvalid
                    Return True
                Else
                    DirectCast(_nPage.FindControl(_oNewControl.UniqueID), TextBox).CssClass = _psTextBoxCssOrig
                    Return False
                End If

            End If

            '---------- ---------- ---------- ----------
        Catch ex As Exception

        End Try
    End Function
#End Region

End Class
