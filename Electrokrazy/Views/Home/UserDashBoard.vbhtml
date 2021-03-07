@Code
    ViewData("Title") = "UserDashBoard"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>UserDashBoard</h2>


@If Session("UserEmail") IsNot Nothing Then
    @<p>The price is too high.</p>
    @<p>
        Welcome @Session("UserEmail").ToString()
    </p>
    @<p> Welcome @Session("UserId").ToString() </p>
End If