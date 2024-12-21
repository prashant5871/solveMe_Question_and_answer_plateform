<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="solveMe.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login - solveMe</title>
    <link href="css/auth.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auth-container">
        <h2>Login Now</h2>       
            <!-- Username -->
            <div class="form-group">
                <label for="username">Username:</label>
                <asp:TextBox ID="username" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="username" ErrorMessage="Username is required." CssClass="error-message" />
            </div>

            <!-- Password -->
            <div class="form-group">
                <label for="password">Password:</label>
                <asp:TextBox ID="password" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="password" ErrorMessage="Password is required." CssClass="error-message" />
                <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="password" ErrorMessage="Password must be at least 8 characters, contain uppercase, lowercase, and a number." 
                ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$" CssClass="error-message" />
            </div>

            <!-- Submit Button -->
            <div class="form-group">
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn-submit" OnClick="btnLogin_Click" />
            </div>
       
    </div>
</asp:Content>
