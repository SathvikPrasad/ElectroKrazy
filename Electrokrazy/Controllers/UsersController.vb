Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Electrokrazy

Namespace Controllers
    Public Class UsersController
        Inherits System.Web.Mvc.Controller

        Private db As New Electronica_DBEntities2

        ' GET: Users
        Function Index() As ActionResult

            If Session("UserEmail") IsNot Nothing Then

                If Session("UserEmail").ToString().ToLower().Contains("admin@gmail.com") Then

                    Return View(db.Users.ToList())
                Else
                    Return RedirectToAction("Index", "Products")
                End If
            End If


        End Function

        ' GET: Users/Details/5
        Function Details() As ActionResult
            If Session("UserId") IsNot Nothing Then
                Dim user_id As Int32 = Convert.ToInt32(Session("UserId"))
                Dim user As User = db.Users.Find(user_id)
                Return View(user)

            End If
        End Function


        ' GET: Users/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Users/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,FirstName,LastName,Email,Password,Phone,Address")> ByVal user As User) As ActionResult
            If ModelState.IsValid Then
                db.Users.Add(user)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(user)
        End Function

        ' GET: Users/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim user As User = db.Users.Find(id)
            If IsNothing(user) Then
                Return HttpNotFound()
            End If
            Return View(user)
        End Function

        ' POST: Users/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,FirstName,LastName,Email,Password,Phone,Address")> ByVal user As User) As ActionResult
            If ModelState.IsValid Then
                db.Entry(user).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(user)
        End Function

        ' GET: Users/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim user As User = db.Users.Find(id)
            If IsNothing(user) Then
                Return HttpNotFound()
            End If
            Return View(user)
        End Function

        ' POST: Users/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim user As User = db.Users.Find(id)
            db.Users.Remove(user)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
