<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - My ASP.NET Application</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")


</head>
<style>
    .navbar a{
        color:white !important;
        font-size:large
    }
    .navbar li:hover{
        cursor:none !important;

    }
    .navbar {
        cursor: none !important;
    }
    .navbar a{
        cursor:none !important;
    }
        .navbar a:hover {
            background-color: #01076C !important;
            border-radius:10px;
            cursor:none;
            transition:all 0.2s ease-in-out;
        } 
        .navbar:hover{
            cursor:none !important;
        }
        .navbar div:hover{
            cursor:none !important

        }
</style>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top " style="background-image:url(../../Images/ElectroKraze6.png);background-size:contain;background-repeat:no-repeat;background-color:#020B95;">
        <div class="container " style="float:right;background-color:rgba(0,0,0,0);width:70%;" >
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("ElectroKrazy", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">

                    @If Session("UserEmail") IsNot Nothing Then

                        If Session("UserEmail").ToString().ToLower().Contains("admin@gmail.com") Then
                            @<li>@Html.ActionLink("Products", "Index", "Products")</li>
                            @<li>@Html.ActionLink("Add Category", "Create", "Categories")</li>

                            @<li>@Html.ActionLink("Orders", "Index", "Orders")</li>
                            @<li>@Html.ActionLink("Users", "Index", "Users")</li>
                            @<li>@Html.ActionLink("User Info", "Details", "Users")</li>

                            @<li>@Html.ActionLink("log out", "LogOut", "Home")</li>




                        Else
                            @<li>@Html.ActionLink("Products", "Index", "Products")</li>
                            @<li>@Html.ActionLink("Orders", "Index", "Orders")</li>
                            @<li>@Html.ActionLink("User Info", "Details", "Users")</li>
                             @<li>@Html.ActionLink("Cart", "Cart", "Products")</li>
                              @<li>@Html.ActionLink("log out", "LogOut", "Home")</li>

                        End If

                    Else
                           @<li>@Html.ActionLink("Login", "Login", "Home")</li>

                    End If





                </ul>
                

            </div>
        </div>
    </div>
    <div class="container body-content">
        @RenderBody()
      
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
    
</body>
</html>
