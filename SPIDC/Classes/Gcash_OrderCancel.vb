Public Class GCash_OrderCancel
    Public Class Head
        Public Property version As String
        Public Property _function As String
        Public Property clientId As String
        Public Property clientSecret As String
        Public Property reqMsgId As String
        Public Property reqTime As String
    End Class

    Public Class Body
        Public Property acquirementId As String
        Public Property merchantId As String
    End Class

    Public Class Request
        Public Property head As Head
        Public Property body As Body
    End Class

    Public Class Gcash_OrderCancel
        Public Property request As Request
        Public Property signature As String
    End Class





End Class

