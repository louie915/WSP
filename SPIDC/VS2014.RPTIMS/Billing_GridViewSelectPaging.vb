Imports System.Reflection
Imports System.Reflection.MethodBase
Imports System.Web.HttpContext

Partial Public Class RPTIMSAssessmentBilling
#Region "Variables"

    Private Shared _mPrefix As String = GetCurrentMethod.DeclaringType.FullName

#End Region
    Shared Property _psDtMainLoan() As DataTable
        Get
            Return Current.Session(_mPrefix & GetCurrentMethod.Name.Substring(4))
        End Get
        Set(ByVal value As DataTable)
            Current.Session(_mPrefix & GetCurrentMethod.Name.Substring(4)) = value
        End Set
    End Property

End Class
