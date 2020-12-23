<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.Master" AutoEventWireup="true" CodeBehind="frmReporteAdiccionesCliente.aspx.cs" Inherits="SegurosSigloXXI.Formularios.frmReporteAdiccionesCliente" %>

<%@ MasterType VirtualPath="~/Plantilla.Master" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/GeneralStyles.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <form runat="server" method="post">
        <asp:ScriptManager ID="scmReporteAdiccionesClientes" runat="server"></asp:ScriptManager>
        <p class="btn btn-outline-success btnRegistrar"
            id="P1" runat="server">
            Aplicar Filtros
        </p>
        <div class="modal">
            <%-- Formulario insertar Adicción --%>
            <div class="frm-insertar bg-light p-2">
                <div class="d-flex border-bottom justify-content-between align-items-baseline">
                    <h4 class="pt-3 pb-3" id="tituloFormulario">Generar Reporte Por...</h4>
                    <span class="fas fa-times p-0 mr-2 btn" id="cerrar" style="color: dimgray"></span>
                </div>
                <div class="form-group">
                    <label for="sl_ListaClientes">Nombre del Cliente</label>
                    <select runat="server" id="sl_ListaClientes" class="form-control"></select>
                </div>
                <div class="form-group">
                    <label for="sl_ListaAdicciones">Nombre de la Adicción</label>
                    <select runat="server" id="sl_ListaAdicciones" class="form-control"></select>
                </div>
                <asp:Button CssClass="btn btn-success" Text="Generar" runat="server" OnClick="GenerarReporteFiltrado_Click" />
            </div>
        </div>

        <rsweb:ReportViewer ID="rpvAdiccionesCliente" runat="server" Width="100%"></rsweb:ReportViewer>
    </form>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="pageScript" runat="server">
    <script src="../scripts/GeneralScripts.js"></script>
</asp:Content>
