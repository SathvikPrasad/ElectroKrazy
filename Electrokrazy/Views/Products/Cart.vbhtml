@ModelType IEnumerable(Of Electrokrazy.Product)
@Code
    ViewData("Title") = "Cart"
    Layout = "~/Views/Shared/_Layout.vbhtml"
    Dim Total As Integer = 0

End Code

<h2>Shopping Cart</h2>








<table class="table product_table">



    @If Session("cart") IsNot Nothing Then
        Dim words As String() = Session("cart").Split(New Char() {","c})

        ' Use For Each loop over words and display them

        Dim word As String
        For Each word In words
            Dim intNumber As Integer

            If IsNumeric(word) = True Then

                @For Each item In Model
                    If item.Id = word Then
                        Total = Total + item.Price

                        @<tr class="table_items">
                            <td>

                                <img src="@item.Image" alt="Sample Image" />
                            </td>
                            <td>
                                @Html.DisplayFor(Function(modelItem) item.ProductName)
                            </td>

                            <td>
                                @Html.DisplayFor(Function(modelItem) item.Category.CategoryName)
                            </td>
                            <td>
                                @Html.DisplayFor(Function(modelItem) item.Description)
                            </td>
                            <td>
                                $@Html.DisplayFor(Function(modelItem) item.Price)
                            </td>
                        </tr>
                    End If
                Next
            Else

                'do something here, your “number” is not a number

            End If
        Next

    End If




</table>

@If Session("cart") IsNot Nothing Then
    If Len(Session("cart")) > 1 Then
        @<h1>Order Total @Total</h1>

        @<p Class=" button_login">@Html.ActionLink("Buy", "BuyItemsFromCart", "Orders")</p>

    Else
        @<h1>No Items in the cart</h1>

    End If

Else
    @<h1>No Items in the cart</h1>

End If


