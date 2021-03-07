
@ModelType  Electrokrazy.User

@Code
    ViewData("Title") = "Login"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code





@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal mt-5">
    <h2 class="headig text-center mb-5">Login</h2>
    <div class="login_form_container">
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Email, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Email, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Email, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Password, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Password, New With {.htmlAttributes = New With {.class = "form-control password"}})
                @Html.ValidationMessageFor(Function(model) model.Password, "", New With {.class = "text-danger"})
            </div>
        </div>



        <div class="form-group button_login">
            <div class="">
                <input type="submit" value="Login" class="btn btn-default" />
            </div>
        </div>
    </div>
  

    <P class="login_signup_link">Don't have an account ? <span class="text-White">@Html.ActionLink("Sign Up", "Create", "Users")</span></P>
</div>
End Using
