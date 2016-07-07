<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="MasterDemo.Index" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table table-striped" style="width:400px">
        <thead>
            <tr>
                <th style="width:30px">ID</th>
                <th style="width:125px">Firstname</th>
                <th style="width:125px">Lastname</th>
                <th style="width:60px">&nbsp</th>
                <th style="width:60px">&nbsp</th>
            </tr>
        </thead>
        <tbody>
            <asp:Literal ID="myLiteral" runat="server"></asp:Literal>
        </tbody>
    </table>
    
 </asp:Content>
