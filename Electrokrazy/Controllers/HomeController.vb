Imports System.Linq
Imports System.Web.Mvc

Namespace MvcLoginAppDemo.Controllers
    Public Class HomeController
        Inherits Controller
        Function Index() As ActionResult
            Return View()
        End Function
        Public Function Login() As ActionResult
            Return View()
        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Function Login(ByVal objUser As User) As ActionResult
            If ModelState.IsValid Then

                Using db As Electronica_DBEntities2 = New Electronica_DBEntities2()
                    Dim obj = db.Users.Where(Function(a) a.Email.Equals(objUser.Email) AndAlso a.Password.Equals(objUser.Password)).FirstOrDefault()

                    If obj IsNot Nothing Then
                        Session("UserID") = obj.Id.ToString()
                        Session("UserEmail") = obj.Email.ToString()
                        Session("BYCAT") = "All"
                        Session("cart") = "0"
                        If (objUser.Email = "admin@gmail.com") Then
                            Return RedirectToAction("Index", "Users")

                        Else

                            Return RedirectToAction("Index", "Products")
                        End If

                    End If
                End Using
            End If

            Return View(objUser)
        End Function

        Public Function UserDashBoard() As ActionResult
            If Session("UserID") IsNot Nothing Then
                Return View()
            Else
                Return RedirectToAction("Login")
            End If
        End Function


        Public Function LogOut() As ActionResult

            Session.Remove("UserEmail")
            Return RedirectToAction("Index")

        End Function

        Public Function AboutUs() As ActionResult

            Return View()

        End Function



    End Class
End Namespace
