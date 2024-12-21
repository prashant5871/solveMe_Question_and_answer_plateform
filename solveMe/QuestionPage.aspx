<%@ Page Title="Questions" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="QuestionPage.aspx.cs" Inherits="solveMe.QuestionPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Questions - solveMe</title>
    <link href="css/question_page.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="question-container">
        <h2>Available Questions</h2>

        <!-- Repeater for dynamic questions -->
        <asp:Repeater ID="rptQuestions" runat="server">
            <ItemTemplate>
                <div class="question-card">
                    <label><%# Eval("statement") %></label>
                    <p class="posted-by">Posted by: <%# Eval("username") %></p>

                    <!-- If user is an expert or admin, show 'Answer this question' button -->
                    <%if (Session["CurrUser"] != null && (((solveMe.User)Session["CurrUser"]).isExpert || ((solveMe.User)Session["CurrUser"]).isAdmin))
                    { %>
                        <a href="UploadAnswer.aspx?QuestionID=<%# Eval("Id") %>" class="btn-answer">Answer this question</a>
                    <%} %>

                    <!-- Link for viewing all answers for this question -->
                    <a href="ViewAnswers.aspx?QuestionID=<%# Eval("Id") %>" class="btn-view-answers">View All Answers</a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
