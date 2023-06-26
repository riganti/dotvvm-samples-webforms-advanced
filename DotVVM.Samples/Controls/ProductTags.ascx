<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductTags.ascx.cs" Inherits="DotVVM.Samples.Controls.ProductTags" %>

<div class="product-tags">
    <div id="EditTagPanel" runat="server" visible="false">
        You can <a href="EditTags.aspx?productId=<%=ProductId %>">edit tags</a>.
    </div>
    <div class="tagContainer">
        <asp:Repeater ID="TagRepeater" runat="server">
            <ItemTemplate>
                <span class="product-tag"><%# Eval("Name") %></span>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>