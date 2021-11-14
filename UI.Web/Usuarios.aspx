<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
<asp:Panel ID="Panel2" runat="server" style="margin-left: 64px" >

	<h1 align="center" >Usuarios</h1>

    <asp:Panel ID="gridPanel" runat="server" align="center">
	<asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
	SelectedRowStyle-BackColor="Black"
	SelectedRowStyle-ForeColor="White"
	DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
	    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
	<Columns>
		<asp:BoundField HeaderText="Nombre" DataField="Nombre"/>
		<asp:BoundField HeaderText="Apellido" DataField="Apellido"/>
		<asp:BoundField HeaderText="EMail" DataField="EMail"/>
		<asp:BoundField HeaderText="Usuario" DataField="NombreUsuario"/>
		<asp:BoundField HeaderText="Habilitado" DataField="Habilitado"/>
		<asp:BoundField DataField="TipoPersona" HeaderText="Tipo Persona"></asp:BoundField>
        <asp:BoundField DataField="Legajo" HeaderText="Legajo"></asp:BoundField>
        <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nac"></asp:BoundField>
        <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
	</Columns>
	    <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
	    <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True" />
	    <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
	</asp:GridView>
		</asp:Panel>
<asp:Panel ID="gridActionsPanel" runat="server" align="center">
	<asp:LinkButton ID="nuevoLinkLinkButton" runat="server" OnClick="nuevoLinkLinkButton_Click">Nuevo</asp:LinkButton>
	<asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
	<asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
	
</asp:Panel>

<asp:Panel ID="formPanel" Visible="false" runat="server"  align="center">

	<asp:Label ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
	<asp:TextBox ID="nombreTextBox" runat="server"></asp:TextBox>
	<asp:Label ID="lblNombre" runat="server" Text="Nombre invalido" Visible="false" ForeColor="#FF3300"></asp:Label>
	<br />
	<asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
	<asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
	<asp:Label ID="lblApellido" runat="server" Text="Apellido invalido" Visible="false" ForeColor="#FF3300"></asp:Label>
	<br />
	<asp:Label ID="emailLabel" runat="server" Text="EMail: "></asp:Label>
	<asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
	<asp:Label ID="lblemail" runat="server" Text="Email invalido" Visible="false" ForeColor="#FF3300"></asp:Label>
	<br />
	<asp:Label ID="Label2" runat="server" Text="Habilitado"></asp:Label>
	<asp:CheckBox ID="habilitadoCheckBox" runat="server"/><br />
	<asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
	<asp:TextBox ID="nombreUsuarioTextBox" runat="server"></asp:TextBox>
	<asp:Label ID="lblnombreUsuario" runat="server" Text="Usuario invalido" Visible="false" ForeColor="#FF3300"></asp:Label>
	<br />
	<asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
	<asp:TextBox ID="claveTextBox" runat="server"></asp:TextBox>
	<asp:Label ID="lblClave" runat="server" Text="Clave invalido" Visible="false" ForeColor="#FF3300"></asp:Label>
	<br />
	<asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir Clave: "></asp:Label>
	<asp:TextBox ID="repetirClaveTextBox"  runat="server"></asp:TextBox>
	<asp:Label ID="lblrepetirClave" runat="server" Text="Clave invalida" Visible="false" ForeColor="#FF3300"></asp:Label>
	<asp:Label ID="lblrepetirCoincidencia" runat="server" Text="Clave no coinciden" Visible="false" ForeColor="#FF3300"></asp:Label>
	<br />
	<asp:Label ID="tipoLabel" runat="server" Text="Tipo Persona"></asp:Label>
    <asp:DropDownList ID="ddlTipo" runat="server" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged">
        <asp:ListItem Value="0">Administrador</asp:ListItem>
        <asp:ListItem>Alumno</asp:ListItem>
        <asp:ListItem Value="2">Profesor</asp:ListItem>
    </asp:DropDownList>
    <asp:Label ID="lblTipo" runat="server" ForeColor="#FF3300" Text="Tipo invalido" Visible="false"></asp:Label>
	<br />
    <asp:Label ID="legajoLabel" runat="server" Text="Legajo"></asp:Label>
    <asp:TextBox ID="txtLegajo" runat="server"></asp:TextBox>
	<asp:Label ID="lblLegajo" runat="server" Text="Legajo invalido" Visible="false" ForeColor="#FF3300"></asp:Label>
	<br />
    <asp:Label ID="fechaNacLabel" runat="server" Text="Fecha Nacimiento"></asp:Label>
	
    <asp:TextBox ID="txtFecha" runat="server" textmode="Date"></asp:TextBox>
	
    <br />
	
    <asp:Label ID="Label1" runat="server" Text="Plan"></asp:Label>
    <asp:DropDownList ID="ddlPlan" runat="server">
    </asp:DropDownList>
	<br />	
	<asp:Panel ID="Panel1" runat="server" style="margin-left: 4px; margin-bottom: 16px" align="center">
	<asp:LinkButton ID="LinkButton1" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
	<asp:LinkButton ID="LinkButton2" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
</asp:Panel>
</asp:Panel>

</asp:Panel>

</asp:Content>
