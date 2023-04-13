<%@ Page MasterPageFile="~/Pages/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="CustomerNotes.aspx.cs" Inherits="DotVVM.Samples.Pages.CustomerNotes" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <form id="NotesForm" runat="server">
        <div id="ResultsDiv" runat="server">
            <table id="notes">
                <% if (!string.IsNullOrEmpty(Error)) { %><tr><td colspan="3" class="error"><%=Error %></td></tr><% } %>
                <% if(User.IsInRole("Manager")) { %>
                <tr>
                    <td colspan="3">
                        <% if(ProductId > 0) { %>
                            <a href="Products.aspx?productId=<%=ProductId%>">To product</a>
                        <% } else if (CategoryId > 0) { %>
                            <a href="Categories.aspx?categoryId=<%=CategoryId%>">To category</a>
                        <% } else { %>
                            <a href="Dashboard.aspx">To Dashboard</a>
                        <% } %>
                    </td>
                </tr>
                <% } %>
                <tr>
                    <th>Date</th>
                    <th>User</th>
                    <th>Comment</th>
                </tr>
                <% if( Notes == null || Notes.Count == 0 ) { %>
                <tr>
                    <td colspan="3">No notes entered
                    </td>
                </tr>
                <% } else { %>
                <% foreach( var note in Notes ) { %>
                <tr>
                    <td><%=note.CreateDate.ToString( "MM/dd/yyyy hh:mm" )%></td>
                    <td><%=note.UserName%></td>
                    <td><%=note.Text%></td>
                </tr>
                <% } %>
                <% } %>
            </table>
        </div>

        <div id="CreateNewDiv" runat="server">
            <h2>Add a Note</h2>
            <asp:TextBox runat="server" TextMode="MultiLine" ID="NoteTextField"></asp:TextBox>
            <asp:Button runat="server" ID="SubmitButton" Text="Create" OnClick="SubmitButton_Click" />
        </div>
    </form>
</asp:Content>
