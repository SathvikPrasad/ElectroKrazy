@ModelType IEnumerable(Of Electrokrazy.Product)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"

    Dim aList As New List(Of String)


    @For Each item In Model
        aList.Add(item.Category.CategoryName)
        aList = aList.Distinct.ToList()
    Next

    Dim Bycat As String = "All"


    @If Session("BYCAT") IsNot Nothing Then
        Bycat = Session("BYCAT").ToString()

    End If

End Code




<h2 class="text-center">Products</h2>
<p>
    @If Session("UserEmail") IsNot Nothing Then

        If Session("UserEmail").ToString().ToLower().Contains("admin@gmail.com") Then


        @<p Class="add_product_button">@Html.ActionLink("Add a New Product ", "Create")</p>
        Else


        End If
    End If


    <div class="category_names">
        @If Bycat = "All" Then
            @<p class="selected_link">@Html.ActionLink("All Products", "ByCategory", New With {.category = "All"})</p>

        Else

            @<p>@Html.ActionLink("All Products", "ByCategory", New With {.category = "All"})</p>

        End If
        @For Each item In aList
            If Bycat = item Then
                @<p class="selected_link">@Html.ActionLink(item, "ByCategory", New With {.category = item})</p>
            Else
                @<p>@Html.ActionLink(item, "ByCategory", New With {.category = item})</p>

            End If


        Next

    </div>







    <Table Class="table product_table">

        @If Bycat = "All" Then

            @For Each item In Model
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


                    <td>


                        @If Session("UserEmail") IsNot Nothing Then

                            If Session("UserEmail").ToString().ToLower().Contains("admin@gmail.com") Then


                                @Html.ActionLink("Edit", "Edit", New With {.id = item.Id})
                                @Html.ActionLink("Details", "Details", New With {.id = item.Id})
                                @Html.ActionLink("Delete", "Delete", New With {.id = item.Id})
                            Else
                                @<div>
                            <span class="buy_button">@Html.ActionLink("Buy", "Buy", New With {.id = item.Id})</span>
                            <span Class="buy_button">@Html.ActionLink("Add to Cart", "AddToCart", New With {.id = item.Id})</span>
                                </div>


                            End If
                        End If
                    </td>
                </tr>
            Next
        End If
        @If Bycat <> "All" Then

            @For Each item In Model
                If Bycat = item.Category.CategoryName Then

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


                        <td>


                            @If Session("UserEmail") IsNot Nothing Then

                                If Session("UserEmail").ToString().ToLower().Contains("admin@gmail.com") Then


                                    @Html.ActionLink("Edit", "Edit", New With {.id = item.Id})
                                    @Html.ActionLink("Details", "Details", New With {.id = item.Id})
                                    @Html.ActionLink("Delete", "Delete", New With {.id = item.Id})
                                Else

                                    @<p class="buy_button">@Html.ActionLink("Buy", "Buy", New With {.id = item.Id})</p>
                                End If
                            End If


                        </td>
                    </tr>
                End If


            Next
            End If


    </Table>






  

