'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class User
    Public Property Id As Integer
    Public Property FirstName As String
    Public Property LastName As String
    Public Property Email As String
    Public Property Password As String
    Public Property Phone As Integer
    Public Property Address As String

    Public Overridable Property Orders As ICollection(Of Order) = New HashSet(Of Order)

End Class
