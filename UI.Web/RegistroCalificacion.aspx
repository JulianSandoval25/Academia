<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroCalificacion.aspx.cs" Inherits="UI.Web.RegistroCalificacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="Panel2" runat="server" style="margin-left: 64px" >
    <h1 align="center">Registro de Calificaciones</h1>
        <asp:Panel ID="Panel1" runat="server" align="center">
    <asp:DropDownList ID="ddlCursos" runat="server"></asp:DropDownList>
    <asp:LinkButton ID="ActualizarLinkButton" OnClick="actualizarLinkLinkButton_Click" runat="server">Actualizar</asp:LinkButton>
            </asp:Panel>
     <asp:Panel ID="gridPanel" runat="server" align="center">

        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black"
	    SelectedRowStyle-ForeColor="White"
	    DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Condicion" HeaderText="Condicion" />
                <asp:BoundField DataField="Nota" HeaderText="Nota" />
                <asp:BoundField DataField="IDCurso" HeaderText="IDCurso" />
                <asp:CommandField ShowSelectButton="True" />
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


    </asp:Panel >
    <asp:Panel ID="gridActionsPanel" runat="server" align="center">
	    <asp:LinkButton ID="cargarNotaLinkLinkButton" runat="server" OnClick="cargarNotaLinkLinkButton_Click">Cargar Nota</asp:LinkButton>
    </asp:Panel>

    <asp:Panel ID="formPanel" Visible="false" runat="server" align="center">

        <asp:Label ID="lblID" runat="server" Text="ID"></asp:Label><asp:TextBox ID="txtID" Enabled="false" runat="server"></asp:TextBox><br />
        <asp:Label ID="lblCondicion" runat="server" Text="Condicion"></asp:Label><asp:TextBox ID="txtCondicion" runat="server"></asp:TextBox><br /><asp:Label ID="lblCondicion2" runat="server" Text="condicion invalido" Visible="false" ForeColor="#FF3300"></asp:Label>
        <asp:Label ID="lblNota" runat="server" Text="Nota"></asp:Label><asp:TextBox ID="txtNota" runat="server"></asp:TextBox><br /><asp:Label ID="lblNota2" runat="server" Text="Nota invalido" Visible="false" ForeColor="#FF3300"></asp:Label>
        <asp:LinkButton ID="btnAceptar" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
	    <asp:LinkButton ID="btnCancelar" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
    </asp:Panel>
        </asp:Panel>
</asp:Content>
