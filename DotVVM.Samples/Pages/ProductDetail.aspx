<%@ Page Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="DotVVM.Samples.Pages.ProductDetail" %>
<%@ Register TagPrefix="uc" TagName="ProductTags" Src="~/Controls/ProductTags.ascx" %>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <form id="NotesForm" runat="server">
        <%=Message %>
        <%= Product?.Name %>
        
        <uc:ProductTags ID="ProductTagsControl" runat="server" />

        <div class="categories">
            <input name='categoryCount' 
                   type="hidden" 
                   value='<%= CategoryCount %>' />
            <asp:Repeater ID="CategoryRepeater" runat="server">
                <ItemTemplate>
                    <input type="text" name='<%# "categoryName_" + Container.ItemIndex %>' 
                        class="product-tag badge badge-primary" 
                        value='<%# Eval("Name") %>' />
                    <input name='<%# "categoryId_" + Container.ItemIndex %>' 
                        type="hidden" 
                        value='<%# Eval("Id") %>'/>
                </ItemTemplate>
            </asp:Repeater>
            <div id="AddCategoryPanel" runat="server" visible="false">
                <asp:TextBox ID="NewCategoryTextBox" runat="server" CssClass="form-control" />
                <asp:Button ID="AddCategoryButton" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="AddCategoryButton_Click" />
            </div>
        </div>
        <asp:Button UseSubmitBehavior="true" runat="server" Text="Save" OnClick="Save_Click" />
    </form>
</asp:Content>
