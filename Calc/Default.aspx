<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Calc._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Calculator</h1>
    </div>

    <div class="row">
        <div class="col-md-4">
            <label>Liczba A </label><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <label>Liczba B</label><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-4">
                <label>Kliknij aby wykonać działanie:</label><asp:Button ID="Button1" runat="server" Text="+" Width="30px" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="-" Width="27px" OnClick="Button2_Click" />
                <asp:Button ID="Button3" runat="server" Text="*" Width="29px" OnClick="Button3_Click" />
                <asp:Button ID="Button4" runat="server" Text="/" Width="27px" OnClick="Button4_Click" />
        </div>
        <div class="col-md-4">
            <label>Wynik</label><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-4">
             <label>Ostatnie działania:</label></br>
             <label>Data operacji</label><label>Działanie</label></br>
             <% foreach(var item in Enumerable.Reverse(dataList).Take(10)) { %> <!-- Iterating 10 last rows -->
                <label> <%= item.DateTime %></label>
                <label> <%= item.Calc %></label>
            <% } %>
        </div>
    </div>

</asp:Content>
