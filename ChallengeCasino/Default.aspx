<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChallengeCasino.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Image ID="displayImage1" runat="server" Height="120px" Width="120px" />
&nbsp;<asp:Image ID="displayImage2" runat="server" Height="120px" Width="120px" />
&nbsp;<asp:Image ID="displayImage3" runat="server" Height="120px" Width="120px" />
    
        <br />
        <br />
        You Bet : <asp:TextBox ID="betBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="leverButton" runat="server" OnClick="Button1_Click" Text="Pull the lever!" />
        <br />
        <br />
        <asp:Label ID="testLabel" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="coinLabel" runat="server"></asp:Label>
        <br />
        <br />
        Player&#39;s money : <asp:Label ID="playersMoneyLabel" runat="server"></asp:Label>
&nbsp;<br />
        <br />
        1 x cherry&nbsp; - x2 Your Bet<br />
        2 x cherries - x3 Your Bet<br />
        3 cherries - x4 Your Bet<br />
        <br />
        3 7&#39;s -JackPot -x100 Your Bet<br />
        <br />
        HOWEVER
        <br />
        if there is one BAR you win nothing
    
    </div>
    </form>
</body>
</html>
