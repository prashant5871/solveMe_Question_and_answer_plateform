<%@ Page Title="My Questions" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MyQuestionsPage.aspx.cs" Inherits="solveMe.MyQuestionsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/my_questions_page.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="my-questions-container">
        <h1>My Uploaded Questions</h1>

        <!-- Repeater to display user questions -->
        <asp:Repeater ID="rptMyQuestions" runat="server">
            <ItemTemplate>
                <div class="question-card">
                    <h3><%# Eval("statement") %></h3>
                    <p>Category: <%# Eval("CategoryName") %></p>
                    <p>Posted on: <%# Eval("postedDate", "{0:MMMM dd, yyyy}") %></p>

                    <!-- Button to redirect to view answers of this question -->
                    <a href="ViewAnswers.aspx?QuestionID=<%# Eval("Id") %>" class="btn-view-answers">View All Answers</a>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <!-- If there are no questions uploaded -->
        <asp:Panel ID="pnlNoQuestions" runat="server" Visible="false">
            <p class="no-questions-msg">You have not uploaded any questions yet.</p>
        </asp:Panel>
    </div>
</asp:Content>
