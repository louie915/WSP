Public Class GCash_OrderCreate0
     Public Class Head
        Public Property reqTime As String
        Public Property reqMsgId As String
        Public Property clientSecret As String
        Public Property clientId As String
        Public Property _function As String
        Public Property version As String
    End Class

    Public Class EnvInfo
        Public Property terminalType As String
        Public Property orderTerminalType As String
    End Class

    Public Class OrderAmount
        Public Property currency As String
        Public Property value As String
    End Class

    Public Class Buyer
        Public Property externalUserId As String
        Public Property externalUserType As String
        Public Property userId As String
    End Class

    Public Class Seller
        Public Property externalUserId As String
        Public Property externalUserType As String
        Public Property userId As String
    End Class

    Public Class Order
        Public Property orderTitle As String
        Public Property merchantTransId As String
        Public Property createdTime As String
        Public Property orderAmount As OrderAmount
        Public Property expirytime As String
        Public Property buyer As Buyer
        Public Property seller As Seller
    End Class

    Public Class NotificationUrl
        Public Property type As String
        Public Property url As String
    End Class

    Public Class Body
        Public Property envInfo As EnvInfo
        Public Property order As Order
        Public Property productCode As String
        Public Property merchantId As String
        Public Property subMerchantId As String
        Public Property subMerchantName As String
        Public Property notificationUrls As NotificationUrl()
    End Class

    Public Class Request
        Public Property head As Head
        Public Property body As Body
    End Class

    Public Class Gcash_OrderCreate
        Public Property request As Request
        Public Property signature As String
    End Class





End Class

