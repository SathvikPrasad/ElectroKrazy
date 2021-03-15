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
    Public Class ProductsController
        Inherits System.Web.Mvc.Controller

        Private db As New Electronica_DBEntities2

        ' GET: Products
        Function Index() As ActionResult
            Dim products = db.Products.Include(Function(p) p.Category)
            Return View(products.ToList())
        End Function

        ' GET: Products/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim product As Product = db.Products.Find(id)
            If IsNothing(product) Then
                Return HttpNotFound()
            End If
            Return View(product)
        End Function

        ' GET: Products/Create
        Function Create() As ActionResult
            ViewBag.CatId = New SelectList(db.Categories, "Id", "CategoryName")
            Return View()
        End Function

        ' POST: Products/Create
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,ProductName,Quantity,Price,Description,CatId,Image")> ByVal product As Product) As ActionResult
            If ModelState.IsValid Then
                db.Products.Add(product)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.CatId = New SelectList(db.Categories, "Id", "CategoryName", product.CatId)
            Return View(product)
        End Function

        ' GET: Products/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim product As Product = db.Products.Find(id)
            If IsNothing(product) Then
                Return HttpNotFound()
            End If
            ViewBag.CatId = New SelectList(db.Categories, "Id", "CategoryName", product.CatId)
            Return View(product)
        End Function

        ' POST: Products/Edit/5
        'To protect from overposting attacks, enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,ProductName,Quantity,Price,Description,CatId,Image")> ByVal product As Product) As ActionResult
            If ModelState.IsValid Then
                db.Entry(product).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.CatId = New SelectList(db.Categories, "Id", "CategoryName", product.CatId)
            Return View(product)
        End Function

        ' GET: Products/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim product As Product = db.Products.Find(id)
            If IsNothing(product) Then
                Return HttpNotFound()
            End If
            Return View(product)
        End Function

        ' POST: Products/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim product As Product = db.Products.Find(id)
            db.Products.Remove(product)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function
        Function Buy(ByVal id As Integer?) As ActionResult
            Dim product As Product = db.Products.Find(id)
            Session("ProductId") = id.ToString
            Session("ProductName") = product.ProductName
            Session("Price") = product.Price
            Session("Image") = product.Image
            Session("product_discription") = product.Description

            Return RedirectToAction("create", "Orders")
        End Function

        Function AddToCart(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim product As Product = db.Products.Find(id)
            If IsNothing(product) Then
                Return HttpNotFound()
            End If
            Session("cart") = Session("cart") + "," + id.ToString()

            Return RedirectToAction("index", "products")
        End Function
        Function Cart() As ActionResult
            Dim products = db.Products.Include(Function(p) p.Category)

            Return View(products.ToList())
        End Function
        Function ByCategory(ByVal category As String) As ActionResult

            Session("BYCAT") = category

            Return RedirectToAction("index", "products")
        End Function
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
