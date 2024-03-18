<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Home.aspx.cs" Inherits="CIT368_Quiz_App.Pages.Home" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h1>World Capital Quiz</h1>

    <div class="content level2">
        <h2>About the Quiz</h2>

        <p>
            Are you a Geography nerd? Test your knowledge in the capitals of the world. 
            Take a quiz that tests your knowledge in the capitals, either from the U.S 
            or the coutries of the world. The quizes are randomly generated and can 
            range from only a couple or all of the selected capitals. The quizes can 
            be run in two different modes: guessing the capitals from the state/country 
            or by guessing the state/country from the capital. 
        </p>

        <p>
            <asp:Button ID="btn_quiz" Text="Start a New Quiz" Font-Names="Courier" OnClick="Quiz_Redirect" runat="server" />
        </p>
    </div>

    <div class="content level2">
        <h2>User Metrics</h2>

        <p>
            This site collects a user's name, email, and phone number along side their 
            login credentials. This site does not do anything with the collected 
            information, other than to display the user their information in their 
            profile page. This site does not process any personal information in any 
            way, other than to encrypt it for storage in a database. All standard 
            security practices are being taken to ensure that user information is 
            kept private and safe within the database, and if a potential leak is 
            detected, users will be notified as soon as possible. 
        </p>

        <p>
            By loggin into the site, the user's quiz history can be tracked. The quiz 
            history shows the number of correct questions, the total number of quiz 
            questions, the calculated percentage score, and the date the quiz was 
            taken. Also, the user can see the total number of quizes taken, as well 
            as their average core percentage of all of their quizes. 
        </p>

        <p>
            <asp:Button ID="btn_user" Text="Register/Login" Font-Names="Courier" OnClick="Login_Redirect" runat="server" />
        </p>
    </div>
</asp:Content>
