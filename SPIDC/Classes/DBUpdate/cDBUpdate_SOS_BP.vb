Public Class cDBUpdate_SOS_BP


    Public Shared Sub Initialize()
        ' cDBUpdate.Update_Views(cGlobalConnections._pSqlCxn_BPLTIMS, "eOR_Setup", , )
        cDBUpdate.Update_Views(cGlobalConnections._pSqlCxn_BPLTIMS, "SP_GETACCT")

    End Sub


  

End Class
