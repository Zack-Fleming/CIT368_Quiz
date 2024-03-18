<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="CIT368_Quiz_App.Pages.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="content">
        <asp:Literal ID="aa" runat="server" />
    </div>

    <div class="two-columns">
        <div>
            <div class="content level2">
                <h1>User Info</h1>

                <asp:Literal ID="bb" runat="server" />
            </div>

            <div class="content level2">
                <h1>Quiz Metrics</h1>

                <p>
                    Your quizes, shown below, are organized by the date taken, 
                    by default. Additionally, quizes can be organized by type 
                    of quiz, num of right questions, and total number of 
                    questions.
                </p>
            </div>
        </div>

        <div class="content level2">
            <h1>New Quiz</h1>

            <p>
                Are you a Geography nerd? Test your knowledge in the capitals of the world. 
                Take a quiz that tests your knowledge in the capitals, either from the U.S 
                or the coutries of the world. The quizes are randomly generated and can 
                range from only a couple or all of the selected capitals. The quizes can 
                be run in two different modes: guessing the capitals from the state/country 
                or by guessing the state/country from the capital. 
            </p>

            <p>
                When the quiz is grades, you will notice a few thing happening:
                <div style="text-align:center">
                    <ol style="display:inline-block">
                        <li>Your answer will be bolded</li>
                        <li>Wrong answers will be striked through</li>
                        <li>Correct answer will not be striked through</li>
                        <li>If your answer is right, it will be bolded</li>
                        <li>If your answer is wrong, it will be bold and striked</li>
                        <li>Your score will be displayed at the bottom of the quiz</li>
                        <li>The 'Quiz Submit' button will change to say 'Finish Quiz'</li>
                        <li>After finishing the quiz, you will be brought to your dashboard</li>
                    </ol>
                </div>
            </p>

            <br />


                <p>
                    Quiz Mode:
                    <div style="font-weight:bold;">
                        <asp:RadioButtonList ID="cc" runat="server" OnSelectedIndexChanged="AA" AutoPostBack="true">
                            <asp:ListItem Text="US States from Capitals" Value="sc" />
                            <asp:ListItem Text="US Capitals from States" Value="cs" />
                            <asp:ListItem Text="Countries from Capitals" Value="gc" />
                            <asp:ListItem Text="Capitals from Countries" Value="cg" />
                        </asp:RadioButtonList>
                    </div>
                </p>

            <p style="float:left; width: 100%">
                Num Questions:
                <asp:TextBox ID="dd" Font-Names="Courier" Enabled="false" runat="server" />
                <br />
                <asp:RangeValidator ID="ff" ControlToValidate="dd" Type="Integer" MinimumValue="1" MaximumValue="50" EnableClientScript="false" Text="The value must be in range!!!" runat="server" />
            </p>

            <p>
                <asp:Button ID="ee" Text="New Quiz" Font-Names="Courier" CausesValidation="false" OnClick="BB" runat="server" />
            </p>
        </div>
    </div>

    <div class="content level2">
        <h1>Quiz History</h1>

        <p>
            <asp:DropDownList ID="gg" Font-Names="Courier" OnSelectedIndexChanged="CC" AutoPostBack="true" runat="server">
                <asp:ListItem Text="Num Right" Value="NumRight" />
                <asp:ListItem Text="Num Total" Value="NumTotal" />
                <asp:ListItem Text="Type" Value="Type" />
            </asp:DropDownList>

            <asp:DropDownList ID="hh" Visible="false" Font-Names="Courier" runat="server">
                <asp:ListItem Text="SC" Value="sc" />
                <asp:ListItem Text="CS" Value="cs" />
                <asp:ListItem Text="GC" Value="gc" />
                <asp:ListItem Text="CG" Value="cg" />
            </asp:DropDownList>

            <asp:Button ID="ii" Text="Update Filter" Font-Names="Courier" OnClick="DD" runat="server" />
        </p>

        <asp:Literal ID="jj" runat="server" />
    </div>

</asp:Content>