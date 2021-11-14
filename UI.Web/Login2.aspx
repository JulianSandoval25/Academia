<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login2.aspx.cs" Inherits="UI.Web.Login2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="Panel2" runat="server" align="center" class="login-centro" >

   
        <asp:Panel ID="Panel1" runat="server">
        <asp:Label ID="lblBienvenido" runat="server" Font-Bold="True" Text="¡Bienvenido al Sistema!"></asp:Label><br />
           
        <asp:Label ID="lblUsuario" runat="server" Font-Bold="True" Text="Usuario"></asp:Label>
        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUsuario" ErrorMessage="Ingrese un Usuario por favor" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        <br />
            
            <asp:Label ID="lblClave" runat="server" Font-Bold="True" ForeColor="Black" Text="Clave"></asp:Label>
        <asp:TextBox ID="txtClave" runat="server" TextMode="Password"></asp:TextBox>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtClave" ErrorMessage="Ingrese una clave por favor" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            <br />
            <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" />
            <br />
            <asp:Label ID="lblMensage" runat="server" ForeColor="#FF3300" Text="Usuario o Contraseña incorrectas!" Visible="False"></asp:Label>
            <br />
            <asp:Label ID="lblMensage2" runat="server" ForeColor="#FF3300" Text="Usuario inhabilitado!" Visible="False"></asp:Label>
            <br />
            <asp:LinkButton ID="lnkRecordarClave" runat="server" OnClick="lnkRecordarClave_Click">Olvidé mi Clave</asp:LinkButton>

        </asp:Panel>
        </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <meta charset="UTF-8">
    <link rel='stylesheet' href='http://codepen.io/assets/libs/fullpage/jquery-ui.css'>
    <link href="Styles/login.css" rel="stylesheet" media="screen" type="text/css"/>
</asp:Content>

