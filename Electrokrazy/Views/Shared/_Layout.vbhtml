<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - My ASP.NET Application</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")

    <style>
        .navbar a {
            color: white !important;
            font-size: large;
            margin-right: 20px
        }


            .navbar a:hover {
                background-color: #01076C;
                border-radius: 10px;
                transition: all 0.2s ease-in-out;
            }

        .navbar:hover {
        }

        .navbar div:hover {
        }

        .active {
            background-color: #2f9dad;
            color: #01076C;
            border-radius: 15px;
        }

        .active_link a {
            background-color: #2f9dad;
            color: #01076C;
            border-radius: 15px;
        }

        .logout a {
            color: #CAA26D !important;
        }
    </style>
</head>

<body>
    <div class="navbar navbar-inverse navbar-fixed-top " style="background-image:url(../../Images/Electrokraze.png);background-size:contain;background-repeat:no-repeat;background-color:#5f411a;">
        <div class="container " style="float:right;background-color:rgba(0,0,0,0);width:70%;" >
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @If Session("current_page") IsNot Nothing Then


                    If Session("current_page") Is "home" Then
                        @Html.ActionLink("ElectroKraze", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand active "})

                    Else
                        @Html.ActionLink("ElectroKraze", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})

                    End If



                End If

                @If Session("current_page") IsNot Nothing Then


                    If Session("current_page") Is "about" Then
                        @Html.ActionLink("About Us", "AboutUs", "Home", New With {.area = ""}, New With {.class = "navbar-brand active"})

                    Else
                        @Html.ActionLink("About Us", "AboutUs", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
                    End If



                End If


            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">


                    @If Session("UserEmail") IsNot Nothing Then

                If Session("UserEmail").ToString().ToLower().Contains("admin@gmail.com") Then
                            @If Session("current_page") IsNot Nothing Then


                        If Session("current_page") Is "products" Then

                                    @<li class="active_link">@Html.ActionLink("Products", "Index", "Products")</li>
                        Else

                                    @<li>@Html.ActionLink("Products", "Index", "Products")</li>End If



                    End If



                            @If Session("current_page") IsNot Nothing Then


                        If Session("current_page") Is "catcreate" Then

                                    @<li class="active_link">@Html.ActionLink("Add Category", "Create", "Categories")</li>
                        Else

                                    @<li>@Html.ActionLink("Add Category", "Create", "Categories")</li>End If



                    End If


                            @If Session("current_page") IsNot Nothing Then


                        If Session("current_page") Is "orders" Then

                                    @<li class="active_link">@Html.ActionLink("Orders", "Index", "Orders")</li>
                        Else

                                    @<li>@Html.ActionLink("Orders", "Index", "Orders")</li>End If



                    End If




                            If Session("current_page") Is "users" Then

                                    @<li class="active_link">@Html.ActionLink("Users", "Index", "Users")</li>
                            Else

                                    @<li>@Html.ActionLink("Users", "Index", "Users")</li>



                        End If



                                @If Session("current_page") IsNot Nothing Then


                            If Session("current_page") Is "userinfo" Then

                                        @<li class="active_link">@Html.ActionLink("User Info", "Details", "Users")</li>
                            Else

                                        @<li>@Html.ActionLink("User Info", "Details", "Users")</li>End If



                        End If

                                @<li class="logout">@Html.ActionLink("log out", "LogOut", "Home")</li>




                    Else

                                @If Session("current_page") IsNot Nothing Then


                            If Session("current_page") Is "products" Then

                                        @<li class="active_link">@Html.ActionLink("Products", "Index", "Products")</li>
                            Else

                                        @<li>@Html.ActionLink("Products", "Index", "Products")</li>End If



                        End If

                                @If Session("current_page") IsNot Nothing Then


                            If Session("current_page") Is "orders" Then

                                        @<li class="active_link">@Html.ActionLink("Orders", "Index", "Orders")</li>
                            Else

                                        @<li>@Html.ActionLink("Orders", "Index", "Orders")</li>End If



                        End If

                                @If Session("current_page") IsNot Nothing Then


                            If Session("current_page") Is "userinfo" Then

                                        @<li class="active_link">@Html.ActionLink("User Info", "Details", "Users")</li>
                            Else

                                        @<li>@Html.ActionLink("User Info", "Details", "Users")</li>End If



                        End If



                                @If Session("current_page") IsNot Nothing Then


                            If Session("current_page") Is "cart" Then

                                        @<li class="active_link">@Html.ActionLink("Cart", "Cart", "Products")</li>
                            Else

                                        @<li>@Html.ActionLink("Cart", "Cart", "Products")</li>End If



                        End If



                                @<li class="logout">@Html.ActionLink("log out", "LogOut", "Home")</li>



                    End If

                Else
                            @If Session("current_page") IsNot Nothing Then


                        If Session("current_page") Is "login" Then
                                    @<li class="active_link">@Html.ActionLink("Login", "Login", "Home")</li>

                        Else
                                    @<li>@Html.ActionLink("Login", "Login", "Home")</li>

                        End If



                    End If


                End If

            




                </ul>


                    </div>
                </div>
            </div>
            <div Class="container body-content">
                @RenderBody()

                    </div>

                @Scripts.Render("~/bundles/jquery")
                @Scripts.Render("~/bundles/bootstrap")
                @RenderSection("scripts", required:=False)

</body>
</html>
