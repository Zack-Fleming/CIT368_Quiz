<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="RegisterLogin.aspx.cs" Inherits="CIT368_Quiz_App.Pages.RegisterLogin" %>

<asp:Content ID="content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content level2">
        <h1><asp:Label Text="Register" ID="header" runat="server" /></h1>

        <p>
            <asp:Literal ID="lit_error" runat="server" />
        </p>

        <p>
            <asp:Label ID="txt_switch" Text="Already a user? " runat="server" />
            
            <asp:LinkButton ID="btn_switch" Text="Login" OnClick="S" runat="server" />
        </p>

        <p>
            <asp:Label ID="lbl_error" runat="server" />
        </p>

        <div id="register_content" runat="server">
            <p>
                <asp:Label Text="First Name &nbsp;: " runat="server" />
                <asp:TextBox ID="qq" Font-Names="Courier" runat="server" placeholder="John" />
            </p>

            <p>
                <asp:Label Text="Last Name &nbsp;&nbsp;: " runat="server" />
                <asp:TextBox ID="yy" Font-Names="Courier" runat="server" placeholder="Doe" />
            </p>

            <p>
                <asp:Label Text="Email &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: " runat="server" />
                <asp:TextBox ID="ll" Font-Names="Courier" runat="server" placeholder="test@test.com" />
            </p>

            <p>
                <asp:Label Text="Phone Number: " runat="server" />
                <asp:TextBox ID="zz" Font-Names="Courier" runat="server" placeholder="111-111-1111" />
            </p>

            <br /><br />

            <p>
                <asp:Label Text="User Name: " runat="server" />
                <asp:TextBox ID="mm" Font-Names="Courier" runat="server" placeholder="john-Doe_123" />
            </p>

            <p>
                <asp:Label Text="Password : " runat="server" />
                <asp:TextBox ID="ff" Font-Names="Courier" TextMode="Password" runat="server" />
            </p>

            <p>
                <asp:Label Text=" Confirm &nbsp;: " runat="server" />
                <asp:TextBox ID="rr" Font-Names="Courier" TextMode="Password" runat="server" />
            </p>

            <p>Password Requirements:</p>
            <div style="text-align:center">
                <ul style="display:inline-block;">
                    <li>16+ characters long</li>
                    <li>1+ uppercase number</li>
                    <li>1+ number character</li>
                    <li>1+ special character</li>
                    <ul>
                        <li>includes: -_@$!%*?&#|</li>
                        <li>not incl:;:<>().,+='"</li>
                    </ul>
                </ul>
            </div>
        </div>

        <div id="login_content" runat="server" visible="false">
            <p>
                <asp:Label Text="User Name: " runat="server" />
                <asp:TextBox ID="jj" Font-Names="Courier" runat="server" />
            </p>

            <p>
                <asp:Label Text="Password : " runat="server" />
                <asp:TextBox ID="ii" Font-Names="Courier" TextMode="Password" runat="server" />
            </p>
        </div>

        <br />

        <p>
            <asp:Button ID="btn_submit" Text="Register Account" OnClick="B" Font-Names="Courier" runat="server" />
        </p>
    </div>
</asp:Content>