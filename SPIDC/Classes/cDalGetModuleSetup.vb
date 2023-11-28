Public Class cDalGetModuleSetup

    Public Shared Function BP_DisplayTaxbase() As Boolean
        BP_DisplayTaxbase = True
            Return IIf(GetSetupValue("BP_DisplayTaxbase") = True, False, True)
    End Function

    Private Shared Function GetSetupValue(SubModule As String) As Boolean
        Dim _nClass As New cDalGetModules
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR

        Return _nClass._pSubGetAvailableModules(SubModule)
    End Function



End Class
