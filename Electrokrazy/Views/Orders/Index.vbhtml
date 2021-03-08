@ModelType IEnumerable(Of Electrokrazy.Order)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h1>Orders</h1>
<p>
    @If Session("UserName") = "admin@gmail.com" Then
        @Html.ActionLink("Create New", "Create")

    End If
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.User.FirstName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Product.ProductName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Price)
        </th>
        <th>
          Details
        </th>


    </tr>



    @If Session("UserEmail") IsNot Nothing Then

        If Session("UserEmail").ToString().ToLower().Contains("admin@gmail.com") Then


            @For Each item In Model


                    @<tr>
                         <td>
                             @Html.DisplayFor(Function(modelItem) item.User.FirstName)
                         </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.Product.ProductName)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(modelItem) item.Price)
                        </td>
                      
                        
                        <td>
                            @Html.ActionLink("Edit", "Edit", New With {.id = item.Id}) |
                            @Html.ActionLink("Details", "Details", New With {.id = item.Id}) |
                            @Html.ActionLink("Delete", "Delete", New With {.id = item.Id})
                        </td>
                    </tr>

            Next
        Else

            @For Each item In Model

                If item.UserId = Convert.ToInt32(Session("UserId")) Then
                    @<tr>
    <td>
        @Html.DisplayFor(Function(modelItem) item.User.FirstName)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.Product.ProductName)
    </td>
    <td>
        $@Html.DisplayFor(Function(modelItem) item.Price)
    </td>


    <td>

        @Html.ActionLink("Details", "Details", New With {.id = item.Id}) |
        @Html.ActionLink("Delete", "Delete", New With {.id = item.Id})


    </td>
</tr>
                End If
            Next
        End If
    End If






</table>
