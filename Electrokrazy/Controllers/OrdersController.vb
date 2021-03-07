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
    Public Class OrdersController
        Inherits System.Web.Mvc.Controller

        Private db As New Electronica_DBEntities2

        ' GET: Orders
        Function Index() As ActionResult
            Dim orders = db.Orders.Include(Function(o) o.Product).Include(Function(o) o.User)
            Return View(orders.ToList())
        End Function

        ' GET: Orders/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim order As Order = db.Orders.Find(id)
            If IsNothing(order) Then
                Return HttpNotFound()
            End If
            Return View(order)
        End Function

        ' GET: Orders/Create
        Function Create() As ActionResult
            ViewBag.ProductId = New SelectList(db.Products, "Id", "ProductName")
            ViewBag.UserId = New SelectList(db.Users, "Id", "FirstName")
            Return View()
        End Function

        ' POST: Orders/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,UserId,ProductId,Quantity,Price")> ByVal order As Order) As ActionResult


            Dim product As Product = db.Products.Find(Convert.ToInt32(Session("ProductId")))
            order.UserId = Convert.ToInt32(Session("UserId"))
            order.ProductId = Convert.ToInt32(Session("ProductId"))
            order.Quantity = 1
            order.Price = product.Price
            If ModelState.IsValid Then
                db.Orders.Add(order)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.ProductId = New SelectList(db.Products, "Id", "ProductName", order.ProductId)
            ViewBag.UserId = New SelectList(db.Users, "Id", "FirstName", order.UserId)
            Return View(order)
        End Function

        ' GET: Orders/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim order As Order = db.Orders.Find(id)
            If IsNothing(order) Then
                Return HttpNotFound()
            End If
            ViewBag.ProductId = New SelectList(db.Products, "Id", "ProductName", order.ProductId)
            ViewBag.UserId = New SelectList(db.Users, "Id", "FirstName", order.UserId)
            Return View(order)
        End Function

        ' POST: Orders/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,UserId,ProductId,Quantity,Price")> ByVal order As Order) As ActionResult
            If ModelState.IsValid Then
                db.Entry(order).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.ProductId = New SelectList(db.Products, "Id", "ProductName", order.ProductId)
            ViewBag.UserId = New SelectList(db.Users, "Id", "FirstName", order.UserId)
            Return View(order)
        End Function

        ' GET: Orders/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim order As Order = db.Orders.Find(id)
            If IsNothing(order) Then
                Return HttpNotFound()
            End If
            Return View(order)
        End Function

        ' POST: Orders/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim order As Order = db.Orders.Find(id)
            db.Orders.Remove(order)
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
