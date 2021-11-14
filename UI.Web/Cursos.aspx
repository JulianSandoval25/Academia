<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="Panel2" runat="server" style="margin-left: 64px" >
    <h1 align="center">Cursos</h1>
    <asp:Panel ID="gridPanel" runat="server" align="center">

        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black"
	    SelectedRowStyle-ForeColor="White"
	    DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="DescripcionMateria" HeaderText="Materia" />
                <asp:BoundField DataField="DescripcionComisiones" HeaderText="Comision" />
                <asp:BoundField DataField="AnioCalendario" HeaderText="Año Calendario" />
                <asp:BoundField DataField="Cupo" HeaderText="Cupo" />
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
    <asp:Panel ID="Panel1" runat="server" align="center">
        <asp:Label ID="lbPlanes" runat="server" Text="Planes"></asp:Label><asp:DropDownList ID="ddlPlanes" runat="server" ></asp:DropDownList><br />

    </asp:Panel>
    <asp:Panel ID="formPanel" Visible="false" runat="server" align="center">

        <asp:Label ID="lblID" runat="server" Text="ID"></asp:Label><asp:TextBox ID="txtID" Enabled="false" runat="server"></asp:TextBox><br />
        <asp:Label ID="lblMateria" runat="server" Text="Materia"></asp:Label><asp:DropDownList ID="ddlMateria" runat="server" ></asp:DropDownList><br />
        <asp:Label ID="lblCommision" runat="server" Text="Comision"></asp:Label><asp:DropDownList ID="ddlComision" runat="server" ></asp:DropDownList><br />
        <asp:Label ID="lblAnio" runat="server" Text="Año Calendario"></asp:Label><asp:TextBox ID="txtAnioCalendario" runat="server"></asp:TextBox>
        <asp:Label ID="lblAnio2" runat="server" Text="Anio invalido" Visible="false" ForeColor="#FF3300"></asp:Label>
        <br />
        <asp:Label ID="lblCupo" runat="server" Text="Cupo"></asp:Label><asp:TextBox ID="txtCupo" runat="server"></asp:TextBox>
        <asp:Label ID="lblCupo2" runat="server" Text="Cupo invalido" Visible="false" ForeColor="#FF3300"></asp:Label>
        <br />
        <asp:LinkButton ID="btnAceptar" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
	    <asp:LinkButton ID="btnCancelar" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
    </asp:Panel>
        </asp:Panel>
</asp:Content>
