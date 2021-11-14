<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteCursos.aspx.cs" Inherits="UI.Web.ReporteCursos" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="Panel2" runat="server" style="margin-left: 64px" >
    <h1 align="center">Reporte Cursos</h1>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Panel ID="Panel1" runat="server" align="center">
    <rsweb:ReportViewer ID="ReportViewer1" Width="1080px" align="center" runat="server" zoommode="PageWidth" ></rsweb:ReportViewer>

        </asp:Panel>
           
        </asp:Panel>
</asp:Content>
