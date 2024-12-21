<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AboutPage.aspx.cs" Inherits="solveMe.AboutPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/about_page.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="about-container">
        <h1>About solveMe</h1>
        <div class="about-section">
            <img src="https://t3.ftcdn.net/jpg/01/28/44/76/360_F_128447604_6deYSrg6bgH2F3YaoU0icdhvxNu4ReDN.jpg" alt="About solveMe" class="about-image"/>
            <div class="about-text">
                <p>Welcome to <span class="brand-name">solveMe</span>, a platform designed to connect curious minds with expert solutions. Our mission is to build a community where users can ask questions and receive well-thought-out answers from skilled experts in various fields. We foster learning, creativity, and problem-solving through collaboration and shared knowledge.</p>
                
                <p>Founded in 2024, <span class="brand-name">solveMe</span> aims to be the go-to platform for people seeking clear, concise, and actionable answers to their questions. Whether you're a developer, a student, or just someone seeking guidance, we've got experts ready to help!</p>

                <p>Join our community today and become part of something bigger—where knowledge flows freely and solutions are just one question away.</p>
            </div>
        </div>

        <div class="team-section">
            <h2>Meet Our Team</h2>
            <div class="team-grid">
                <div class="team-card">
                    <img src="images/default_user.png" alt="Prashant Kalsariya" class="team-photo"/>
                    <h3>Prashant Kalsariya</h3>
                    <p>Founder & CEO</p>
                </div>
                <div class="team-card">
                    <img src="images/default_user.png" alt="Mihir Karangiya" class="team-photo"/>
                    <h3>Mihir Karangiya</h3>
                    <p>Chief Technical Officer</p>
                </div>
                
            </div>
        </div>
    </div>
</asp:Content>
