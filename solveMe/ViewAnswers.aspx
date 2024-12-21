<%@ Page Title="View Answers" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewAnswers.aspx.cs" Inherits="solveMe.ViewAnswers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>View Answers</title>
    <link href="css/view_answers.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="answers-container">
        <h2><asp:Label ID="lblQuestion" runat="server" Text=""></asp:Label></h2>

        <!-- No Answers Label -->
        <asp:Label ID="lblNoAnswers" runat="server" CssClass="no-answers-message" Visible="false" Text="No answers available for this question." />

        <!-- Repeater to display all answers -->
        <asp:Repeater ID="rptAnswers" runat="server" OnItemCommand="rptAnswers_ItemCommand" OnItemDataBound="rptAnswers_ItemDataBound">
            <ItemTemplate>
                <div class="answer-card">
                    <p class="answer-text"><strong>Answer:</strong> <%# Eval("solution") %></p>
                    <p class="answered-by"><strong>Answered by:</strong> <%# Eval("username") %></p>

                    <!-- Button visible only to admins -->
                    <%if (Session["CurrUser"] != null && ((solveMe.User)(Session["CurrUser"])).isAdmin )
                        { %>
                    <asp:Button ID="btnDelete" runat="server" CommandName="DeleteAnswer" CommandArgument='<%# Eval("Id") %>' Text="Delete"/>
                    <%} %>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
