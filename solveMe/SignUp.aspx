<%@ Page Title="Sign Up" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="solveMe.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Sign Up - solveMe</title>
    <link href="css/auth.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auth-container">
        <h2>Create Your Account</h2>
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

            <!-- Email -->
            <div class="form-group">
                <label for="email">Email:</label>
                <asp:TextBox ID="email" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="email" ErrorMessage="Email is required." CssClass="error-message" />
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="email" ErrorMessage="Please enter a valid email address." ValidationExpression="^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$" CssClass="error-message" />
            </div>

            <!-- First Name -->
            <div class="form-group">
                <label for="firstName">First Name:</label>
                <asp:TextBox ID="firstName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="firstName" ErrorMessage="First Name is required." CssClass="error-message" />
            </div>

            <!-- Last Name -->
            <div class="form-group">
                <label for="lastName">Last Name:</label>
                <asp:TextBox ID="lastName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="lastName" ErrorMessage="Last Name is required." CssClass="error-message" />
            </div>

            <!-- Submit Button -->
            <div class="form-group">
                <asp:Button ID="btnSubmit" runat="server" Text="Sign Up" CssClass="btn-submit" OnClick="btnSubmit_Click" />
            </div>
       
    </div>
</asp:Content>
