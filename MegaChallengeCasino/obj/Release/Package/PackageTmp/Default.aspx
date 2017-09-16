﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MegaChallengeCasino.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="leftImage" runat="server" Height="170px" Width="170px" />
            <asp:Image ID="middleImage" runat="server" Height="170px" Width="170px" />
            <asp:Image ID="rightImage" runat="server" Height="170px" Width="170px" />
            <br />
            <br />
            Your Bet:
            <asp:TextBox ID="betTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="leverButton" runat="server" OnClick="leverButton_Click" Text="Pull The Lever!" />
            <br />
            <br />
        </div>
        <asp:Label ID="resultLabel" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="moneyLabel" runat="server"></asp:Label>
        <br />
        <br />
        1 Cherry - x2 Your Bet<br />
        2 Cherries - x3 Your Bet<br />
        3 Cherries - x4 Your Bet<br />
        <br />
        3 7&#39;s Jackpit - x100 Your Bet<br />
        <br />
        HOWEVER
        <br />
        <br />
        If there&#39;s even one BAR you win nothing</form>
</body>
</html>
