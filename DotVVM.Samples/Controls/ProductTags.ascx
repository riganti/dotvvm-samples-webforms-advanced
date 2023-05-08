<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductTags.ascx.cs" Inherits="DotVVM.Samples.Controls.ProductTags" %>

<div class="product-tags">
    <asp:Repeater ID="TagRepeater" runat="server">
        <ItemTemplate>
            <span class="product-tag badge badge-primary"><%# Eval("Name") %></span>
        </ItemTemplate>
    </asp:Repeater>
    <div ID="AddTagPanel" runat="server" Visible="false">
        <asp:TextBox ID="NewTagTextBox" runat="server" CssClass="form-control" />
        <asp:Button ID="AddTagButton" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="AddTagButton_Click" />
    </div>
</div>