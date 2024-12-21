<%@ Page Title="Upload Question" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UploadQuestion.aspx.cs" Inherits="solveMe.UploadQuestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/upload_question.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="question-form-container">
         <asp:Panel ID="pnlSuccessMessage" runat="server" CssClass="success-panel" Visible="false">
        <asp:Label ID="lblSuccessMessage" runat="server" Text="Your question has been uploaded successfully!" CssClass="success-message"></asp:Label>
    </asp:Panel>
        <h2>Ask Your Question</h2>
        <div class="form-group">
            <label for="category">Select Category</label>
            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="category-dropdown">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvCategory" runat="server" 
                ControlToValidate="ddlCategory" 
                InitialValue="0" 
                ErrorMessage="Please select a category."
                CssClass="error-message" 
                Display="Dynamic" />
        </div>

        <div class="form-group">
            <label for="question">Your Question</label>
            <asp:TextBox ID="txtQuestion" runat="server" CssClass="question-textarea" TextMode="MultiLine" Rows="6" />
            <asp:RequiredFieldValidator ID="rfvQuestion" runat="server" 
                ControlToValidate="txtQuestion" 
                ErrorMessage="Please enter your question."
                CssClass="error-message" 
                Display="Dynamic" />
            <asp:RegularExpressionValidator ID="revQuestion" runat="server" 
                ControlToValidate="txtQuestion" 
                ErrorMessage="Question must be at least 10 characters long." 
                ValidationExpression="^.{10,}$" 
                CssClass="error-message" 
                Display="Dynamic" />
        </div>

        <div class="form-group">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit Question" CssClass="submit-btn" OnClick="btnSubmit_Click"/>
        </div>
    </div>
</asp:Content>
