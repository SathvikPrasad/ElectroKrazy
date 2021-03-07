@ModelType Electrokrazy.Category
@Code
    ViewData("Title") = "Create"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Add Category</h2>

@Using (Html.BeginForm()) 
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <hr />
        @Html.ValidationSummary(True, "", New With { .class = "text-danger" })
        <div class="form-group">
            @Html.LabelFor(Function(model) model.CategoryName, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.CategoryName, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.CategoryName, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group button_login">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Add" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using



@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")
End Section
