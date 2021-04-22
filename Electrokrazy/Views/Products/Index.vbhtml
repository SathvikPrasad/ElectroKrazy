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



<style>
    body {
        padding: 0px;
    }

    .body-content {
        padding: 0px;
        margin: 0px;
    }

    .main {
        margin-top: 62px;
        background-color: #caa26d;
        color: #e6e6e6;
        width: 100vw;
        height: calc(100vh - 62px)
    }

    .main {
        display: flex;
        flex-wrap: wrap;
    }

        .main > * {
        }

    .main_side_bar {
        background-color: #caa26d;
        flex: 0 1 20%;
    }

    .main_content {
        height: 100%;
        width: 80%;
        box-sizing: border-box;
        background-color: #caa26d;
        padding: 10px;
        padding-top: 40px;
        display: grid;
        grid-template-columns: repeat(auto-fit, minmax(310px,1fr));
        grid-gap: 1.5rem;
        overflow-y: scroll;
    }

        .main_content > * {
            box-sizing: border-box;
            background-color: rgba(255, 255, 255, 0.8);
            box-shadow: 3px 6px 9px #44321a;
        }

    .main_side_bar .category_names {
        flex-direction: column;
        margin-top: 20px
    }

    .category_names p {
        font-size: large;
    }

        .category_names p a {
            color: black
        }

    .main_side_bar .category_names .selected_link {
        padding: 0px;
        background: none;
        border: none;
    }

        .main_side_bar .category_names .selected_link a {
            color: #34A0C2;
        }

    .main_content_card {
        max-width: 100%;
        height: 350px;
        background-color: #44321a;
        border-radius: 12px;
    }

    .card_primary {
        width: 100%;
        height: 60%;
        border-radius: 12px;
        background-color: #44321a;
        background-image: url("https://fdn2.gsmarena.com/vv/bigpic/apple-iphone-x.jpg");
        background-size: contain;
        background-repeat: no-repeat;
        background-position: center;
        margin-top: 10px;
    }

    .card_items_list a {
        padding: 10px 20px;
        background-color: #34A0C2;
        border-radius: 8px;
        color: white
    }


    .card_secondary {
        height: 40%;
    }

    .add_product_button {
        position: absolute;
        z-index: 9;
        bottom: 20px;
        right: 25px;
    }

        .add_product_button a {
            border-color: #44321a !important;
        }

            .add_product_button a:hover, a:active {
                background-color: #44321a;
                color: #e6e6e6;
            }

    .main_side_bar {
        box-shadow: 10px 10px 18px #888888;
    }

    .search {
        position: absolute;
        z-index: 9;
        width: 50%;
        top: 80px;
        left: 50%;
        transform: translate(-50%, -50%);
        display: inline-block;
        border: 1px solid #34A0C2;
        border-radius: 4px;
        box-sizing: border-box;
        padding: 5px;
    }

    .filter {
        text-align: center;
        display: flex;
        justify-content: space-around;
        align-content: center;
        align-items: center;
    }

        .filter input {
            width: 25%;
        }

    .max_number {
        display: inline-block;
        border: 1px solid #34A0C2;
        border-radius: 4px;
        box-sizing: border-box;
        padding: 5px;
    }

    .min_number {
        display: inline-block;
        border: 1px solid #34A0C2;
        border-radius: 4px;
        box-sizing: border-box;
        padding: 5px;
    }

    .popup {
        position: absolute;
        width: 50vw;
        z-index: 19;
        -webkit-box-shadow: 4px -2px 15px 48px #000000;
        box-shadow: 4px -2px 50px 48px #333;
        height: 80vh;
        left: 50%;
        top: 53%;
        margin: auto;
        transform: translate(-50%, -50%);
    }
</style>





@If Session("UserEmail") IsNot Nothing Then

    If Session("UserEmail").ToString().ToLower().Contains("admin@gmail.com") Then


        @<p Class="add_product_button">@Html.ActionLink("Add a New Product ", "Create")</p>
    Else


    End If
End If









<input type="text" class="search " placeholder="search" />

<div class="main">
    <div class="main_side_bar">
        <h2 class="text-center">Categories</h2>

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

            <h3 style="margin-top:25px">Filter By Price</h3>
            <div class="filter">
                <input class="min_number" value="0" />

                <span style="font-size:large">To</span>
                <input class="max_number" />
                <input type="checkbox" class="filter_check" />
            </div>


        </div>
    </div>
    <div class="main_content">



        @If Bycat = "All" Then

            @For Each item In Model



                @<div Class="main_content_card">

                    <div Class="card_primary " style="background-image:url(@item.Image)">

                    </div>
                    <div Class="card_secondary">
                        <h3 Class="text-center item_name" style="margin-bottom:30px;">@Html.DisplayFor(Function(modelItem) item.ProductName)</h3>
                        <div Class="card_items_list d-flex text-center">
                            <h4 Class="m-0 d-block item_price" value="@item.Price" style="display: contents;font-size: large">$@Html.DisplayFor(Function(modelItem) item.Price)</h4>


                            @If Session("UserEmail") IsNot Nothing Then

                                If Session("UserEmail").ToString().ToLower().Contains("admin@gmail.com") Then


                                    @Html.ActionLink("Edit", "Edit", New With {.id = item.Id})
                                    @Html.ActionLink("Details", "Details", New With {.id = item.Id})
                                    @Html.ActionLink("Delete", "Delete", New With {.id = item.Id})
                                Else

                                    @Html.ActionLink("Buy", "Buy", New With {.id = item.Id})
                                    @Html.ActionLink("Add to Cart", "AddToCart", New With {.id = item.Id})



                                End If
                            End If


                        </div>
                    </div>

                </div>



            Next
        End If
        @If Bycat <> "All" Then

            @For Each item In Model
                If Bycat = item.Category.CategoryName Then

                    @<div Class="main_content_card">

                        <div Class="card_primary" style="background-image:url(@item.Image)">

                        </div>
                        <div Class="card_secondary">
                            <h3 Class="text-center item_name" style="margin-bottom:30px;">@Html.DisplayFor(Function(modelItem) item.ProductName)</h3>
                            <div Class="card_items_list d-flex text-center">
                                <h4 Class="m-0 d-block item_price" style="display:  contents;font-size: large" value="@item.Price">$@Html.DisplayFor(Function(modelItem) item.Price)</h4>


                                @If Session("UserEmail") IsNot Nothing Then

                                    If Session("UserEmail").ToString().ToLower().Contains("admin@gmail.com") Then


                                        @Html.ActionLink("Edit", "Edit", New With {.id = item.Id})
                                        @Html.ActionLink("Details", "Details", New With {.id = item.Id})
                                        @Html.ActionLink("Delete", "Delete", New With {.id = item.Id})
                                    Else

                                        @Html.ActionLink("Buy", "Buy", New With {.id = item.Id})
                                        @Html.ActionLink("Add to Cart", "AddToCart", New With {.id = item.Id})



                                    End If
                                End If


                            </div>
                        </div>

                    </div>
                End If


            Next
        End If


    </div>

</div>



<script src="https://code.jquery.com/jquery-3.6.0.js" integrity="sha256-H+K7U5CnXl1h5ywQfKtSj8PCmoN9aaq30gDh27Xc0jk=" crossorigin="anonymous"></script>

<script>


    $('.search').on('keyup', e => {

        let search_string = $(e.target).val().toLowerCase()
        $(".main_content_card").each((i, item) => {
            if (search_string.length > 0) {
                let search_item = $(item).find('.item_name').text().trim().toLowerCase()
                if (search_item.includes(search_string)) {
                    $(item).show()
                } else {
                    $(item).hide()
                }
            }
            else {
                $(item).show()
            }


        })

    })



    $(".filter_check").on("click", (e) => {
        var filter = $(e.target).is(":checked")
        if (filter) {
            let number = parseInt($('.max_number').val())
            let min_num = parseInt($('.min_number').val())
            $(".main_content_card").each((i, item) => {
                console.log(item)
                let price = parseInt($(item).find('.item_price').attr('value'))
                console.log(price)
                if (price <= number && price >= min_num) {
                    $(item).show()
                } else {
                    $(item).hide()
                }

            })
        } else {
            $(".main_content_card").each((i, item) => {

                $(item).show()

            })
        }
    })


    let selected_item = ''

    $('.card_primary').on('click', e => {
        console.log(selected_item.length)

        if (selected_item.length > 0) {
            selected_item.parent().removeClass('popup')
            selected_item = ''

        } else {
            $(e.target).parent().addClass('popup')
            selected_item = $(e.target)

        }




    })





</script>