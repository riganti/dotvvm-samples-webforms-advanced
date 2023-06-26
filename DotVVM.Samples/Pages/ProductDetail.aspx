<%@ Page Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="DotVVM.Samples.Pages.ProductDetail" %>

<%@ Register TagPrefix="uc" TagName="ProductTags" Src="~/Controls/ProductTags.ascx" %>
<%@ Register TagPrefix="uc" TagName="ProductCategories" Src="~/Controls/ProductCategories.ascx" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <form id="NotesForm" runat="server">
        <%=Message %>
        <h1><%= Product?.Name %></h1>
        <div class="detail">
            <ul>
                <li><%= Product?.Price %></li>
                <li><%= Product?.Code %></li>
                <li><%= Product?.Description %></li>
            </ul>

            <h2>Tags:</h2>
            <uc:ProductTags ID="ProductTagsControl" AllowEditing="true" runat="server" />
            <h2>Categories:</h2>
            <uc:ProductCategories ID="ProductCategoriesControl" runat="server" />
        </div>
        <asp:Button UseSubmitBehavior="true" runat="server" Text="Save" OnClick="Save_Click" />
    </form>
</asp:Content>
