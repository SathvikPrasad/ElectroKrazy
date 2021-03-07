@ModelType Electrokrazy.Order

@Code
    ViewData("Title") = "Create"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code


<div class="buy_options">

    <img src="@Session("Image")" alt="Sample Image" />

    <div>
        <h1>@Session("ProductName")</h1>
        <h3>@Session("product_discription")</h3>


    </div>
    <h3>$@Session("Price")</h3>

    <div>
        @Using (Html.BeginForm())
            @Html.AntiForgeryToken()

            @<div class="form-horizontal">


                @Html.ValidationSummary(True, "", New With {.class = "text-danger"})

                <div class="form-group">
                    <div class="text-center">
                        <input type="submit" value="Buy" class="btn btn-default" />
                    </div>
                </div>
            </div>
        End Using
    </div>

</div>






@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")
End Section
