
Imports System.Data.SqlClient
Public Class cDBUpdate_OAIMS

    Public Shared Sub Initialize()

        cDBUpdate.Update_Table(cGlobalConnections._pSqlCxn_OAIMS, "Department", "UserType", "nvarchar(50)")
        cDBUpdate.Update_Table(cGlobalConnections._pSqlCxn_OAIMS, "Department", "Regulatory", "bit")
        cDBUpdate.Update_Table(cGlobalConnections._pSqlCxn_OAIMS, "eOR", , )
        cDBUpdate.Update_Table(cGlobalConnections._pSqlCxn_OAIMS, "eOR_Extn", , )
        cDBUpdate.Update_Table(cGlobalConnections._pSqlCxn_OAIMS, "eOR_Setup", , )

    End Sub


End Class
