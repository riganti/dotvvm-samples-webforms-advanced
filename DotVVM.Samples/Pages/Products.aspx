<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="DotVVM.Samples.Pages.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
    <script src="https://underscorejs.org/underscore-min.js"></script>
    <script src="/Content/products.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="ProductsForm" runat="server">
        <!-- Underscore template -->
        <script type="text/template" id="product-template">
            <tr>
                <td>
                    <input type="checkbox" name="selected-{{ product.Id }}" />
                    <input type="hidden" name="id" value="{{ product.Id }}" />
                </td>
                <td>{{ product.Code }}</td>
                <td>{{ product.Name }}</td>
                <td>{{ product.Price }} EUR</td>
            </tr>
        </script>

        <!-- Underscore dialog template -->
        <script type="text/template" id="product-dialog-template">
            <div class="product-dialog-template">
                <h3>{{ product.Name }}</h3>
                <p>
                    <span>Code:</span>
                    {{ product.Code }}
                </p>
                <p>
                    <span>Price:</span>
                    {{ product.Price }} EUR
                </p>
                <p>
                    <span>Description:</span>
                    {{ product.Description }}
                </p>
            </div>
        </script>

        <div id="product-dialog"></div>
        <table id="products-table">
            <thead>
                <tr>
                    <th>
                        <input type="checkbox" /></th>
                    <th>Code</th>
                    <th>Name</th>
                    <th>User</th>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </form>
</asp:Content>
