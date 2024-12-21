<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="solveMe.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Questions - solveMe</title>
    <link href="css/index.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="question-container">
        <h2>Available Questions</h2>
        
        <!-- Search Box -->
        <input type="text" id="searchBox" placeholder="Search questions..." onkeyup="filterQuestions()" />

        <!-- Filter by categories -->
        <div class="filter-container">
            <h3>Filter by Category:</h3>
            <asp:CheckBoxList ID="chkCategories" runat="server"></asp:CheckBoxList>
            <asp:Button ID="btnFilter" runat="server" Text="Filter" OnClick="btnFilter_Click" CssClass="btn-filter" />
        </div>

        <!-- Repeater for dynamic questions -->
        <asp:Repeater ID="rptQuestions" runat="server">
            <ItemTemplate>
                <div class="question-card">
                    <label class="question-label"><%# Eval("statement") %></label>
                    <p class="posted-by">Posted by: <%# Eval("username") %></p>

                    <% if (Session["CurrUser"] != null && (((solveMe.User)Session["CurrUser"]).isExpert || ((solveMe.User)Session["CurrUser"]).isAdmin)) { %>
                        <a href="UploadAnswer.aspx?QuestionID=<%# Eval("Id") %>" class="btn-answer">Answer this question</a>
                    <% } %>

                    <a href="ViewAnswers.aspx?QuestionID=<%# Eval("Id") %>" class="btn-view-answers">View All Answers</a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <script>
        function filterQuestions() {
            const searchBox = document.getElementById("searchBox");
            const filter = searchBox.value.toLowerCase();
            const questionCards = document.getElementsByClassName("question-card");

            for (let i = 0; i < questionCards.length; i++) {
                const questionText = questionCards[i].getElementsByClassName("question-label")[0].innerText.toLowerCase();
                if (questionText.includes(filter)) {
                    questionCards[i].style.display = "";
                } else {
                    questionCards[i].style.display = "none";
                }
            }
        }
    </script>
</asp:Content>
