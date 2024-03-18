<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Quiz.aspx.cs" Inherits="CIT368_Quiz_App.Pages.Quiz" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="content level2">
        <asp:Literal ID="aa" runat="server" />

        <asp:Panel ID="bb" runat="server" />

        <p>
            <asp:Button ID="cc" Text="Submit Quiz" Font-Names="Courier" OnClick="AA"  runat="server" />
        </p>

        <asp:Literal ID="dd" runat="server" />
    </div>

</asp:Content>
