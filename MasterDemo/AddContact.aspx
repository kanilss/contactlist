<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AddContact.aspx.cs" Inherits="MasterDemo.AddContact" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Literal ID="LiteralAlert" runat="server"></asp:Literal>

    <form role="form" runat="server" style="width: 200px">

        <div class="form-group">
            <label for="firstname">Firstname:</label>
            <asp:TextBox ID="firstname" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFVFirstName" runat="server" ErrorMessage="Firstname is required!" ControlToValidate="firstname" EnableClientScript="False"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="lastname">Lastname:</label>
            <asp:TextBox ID="lastname" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFVLastName" runat="server" ErrorMessage="Lastname is required!" ControlToValidate="lastname" EnableClientScript="False"></asp:RequiredFieldValidator>
        </div>

        <asp:Button ID="Button1" runat="server" Text="Submit" />
        <asp:HiddenField ID="cid" runat="server" />
        <asp:HiddenField ID="myaction" runat="server" />
    </form>

</asp:Content>
