﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductCategories.ascx.cs" Inherits="DotVVM.Samples.Controls.ProductCategories" %>

<div class="categories">   
    <div class="filter">
        <%= GetSortSelect() %>
        <asp:Button UseSubmitBehavior="true" ID="SortButton" Text="Sort categories" runat="server" />
    </div>
    <span id="ValidationMessageSpan" class="error" runat="server"></span>
    <asp:Repeater ID="CategoryRepeater" runat="server">
        <ItemTemplate>
            <div class="product-category <%#  (bool)Eval("IsError") ? "category-error": "" %>">
                <asp:HiddenField ID="CategoryIdField" runat="server" Value='<%# Eval("Id") %>' />
                <asp:TextBox ID="CategoryNameField" runat="server" Text='<%# Eval("Name") %>' />
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <div class="product-category add-category" id="AddCategoryPanel" runat="server">
        <asp:TextBox name="newCategory" ID="NewCategoryTextBox" runat="server" CssClass="form-control" />
        <asp:Button ID="AddButton" runat="server" CssClass="form-control" Text="Add" OnClick="AddButton_Click" />
    </div>
</div>
