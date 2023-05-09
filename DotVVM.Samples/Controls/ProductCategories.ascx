<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductCategories.ascx.cs" Inherits="DotVVM.Samples.Controls.ProductCategories" %>

<div class="categories">
    <input name='categoryCount'
        type="hidden"
        value='<%= Categories.Count() %>' />
        <asp:Repeater ID="CategoryRepeater" runat="server">
            <ItemTemplate>
                <div class="product-category">
                    <input type="text" name='<%# "categoryName_" + Container.ItemIndex %>'
                        value='<%# Eval("Name") %>' />
                    <input name='<%# "categoryId_" + Container.ItemIndex %>'
                        type="hidden"
                        value='<%# Eval("Id") %>' />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    <div class="product-category" id="AddCategoryPanel" runat="server">
        <asp:TextBox name="newCategory" ID="NewCategoryTextBox" runat="server" CssClass="form-control" />
        <asp:Button ID="AddButton" runat="server" CssClass="form-control" Text="Add" OnClick="AddButton_Click" />
    </div>
</div>
