<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="Panel2" runat="server" style="margin-left: 64px" >
    <h1 align="center">Materias</h1>
    <asp:Panel ID="gridPanel" runat="server" align="center">

        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black"
	    SelectedRowStyle-ForeColor="White"
	    DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="HSSemanales" HeaderText="HS Semanales" />
                <asp:BoundField DataField="HSTotales" HeaderText="HS Totales" />
                <asp:BoundField DataField="DescripcionPlan" HeaderText="Plan" />
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
        <asp:LinkButton ID="nuevoLinkLinkButton" runat="server" OnClick="nuevoLinkLinkButton_Click">Nuevo</asp:LinkButton>
	    <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
	    <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
	    
    </asp:Panel>

    <asp:Panel ID="formPanel" Visible="false" runat="server" align="center">

        <asp:Label ID="lblID" runat="server" Text="ID"></asp:Label><asp:TextBox ID="txtID" Enabled="false" runat="server"></asp:TextBox><br />
        <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion"></asp:Label><asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
        <asp:Label ID="lblDescripcion2" runat="server" Text="Descripcion invalido" Visible="false" ForeColor="#FF3300"></asp:Label>
        <br />
        <asp:Label ID="lblHSSemanales" runat="server" Text="HS Semanales"></asp:Label><asp:TextBox ID="txtHSSemanales" runat="server"></asp:TextBox>
        <asp:Label ID="lblHSSemanales2" runat="server" Text="HS Semanales Invalido invalido" Visible="false" ForeColor="#FF3300"></asp:Label>
        <br />
        <asp:Label ID="lblHSTotales" runat="server" Text="HS Totales"></asp:Label><asp:TextBox ID="txtHSTotales" runat="server"></asp:TextBox>
        <asp:Label ID="lblHSTotales2" runat="server" Text="HS Totales Invalido invalido" Visible="false" ForeColor="#FF3300"></asp:Label>
        <br />
        <asp:Label ID="lblPlan" runat="server" Text="Plan"></asp:Label><asp:DropDownList ID="ddlPlan" runat="server" ></asp:DropDownList><br />
        <asp:LinkButton ID="btnAceptar" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
	    <asp:LinkButton ID="btnCancelar" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
    </asp:Panel>
        </asp:Panel>
</asp:Content>
