<%@ Page Title="Upload Answer" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UploadAnswer.aspx.cs" Inherits="solveMe.UploadAnswer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Upload Answer - solveMe</title>
    <link href="css/upload_answer.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="upload-answer-container">
        <h2>Upload Your Answer</h2>

        <asp:Label ID="lblQuestion" runat="server" CssClass="question-label"></asp:Label>
        <br />

        <!-- Form for uploading answer -->
        <asp:TextBox ID="txtAnswer" runat="server" TextMode="MultiLine" CssClass="answer-input"></asp:TextBox>
        <br />
        <asp:Button ID="btnUpload" runat="server" Text="Upload Answer" CssClass="btn-upload" OnClick="btnUpload_Click" />

        <!-- Success message -->
        <asp:Label ID="lblMessage" runat="server" CssClass="success-message" Visible="false"></asp:Label>
    </div>
</asp:Content>
