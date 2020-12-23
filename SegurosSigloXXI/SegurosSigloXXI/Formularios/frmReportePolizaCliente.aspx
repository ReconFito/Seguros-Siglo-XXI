<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.Master" AutoEventWireup="true" CodeBehind="frmReportePolizaCliente.aspx.cs" Inherits="SegurosSigloXXI.Formularios.frmReportePolizaCliente" %>

<%@ MasterType VirtualPath="~/Plantilla.Master" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/GeneralStyles.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <form runat="server" method="post">
        <asp:ScriptManager ID="scmReporteRegistroPolizas" runat="server"></asp:ScriptManager>
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
                    <label for="sl_ListaClientes">Nombre Cliente</label>
                    <select runat="server" id="sl_ListaClientes" class="form-control"></select>
                </div>
                <div class="form-group">
                    <label for="sl_ListaCoberturas">Nombre de Cobertua de Póliza</label>
                    <select runat="server" id="sl_ListaCoberturas" class="form-control"></select>
                </div>
                <div class="form-group">
                    <label for="txtMontoAsegurado">Monto Asegurado</label>
                    <input type="number" runat="server" id="txtMontoAsegurado" class="form-control" />
                </div>
                <div class="form-group">
                    <label for="txtNumeroAdicciones">Monto Asegurado</label>
                    <input type="number" runat="server" id="txtNumeroAdicciones" class="form-control" />
                </div>
                <asp:Button CssClass="btn btn-success" Text="Generar" runat="server" OnClick="GenerarReporteFiltrado_Click" />
            </div>
        </div>
        <rsweb:ReportViewer ID="rpvRegistroPolizas" runat="server" Width="100%"></rsweb:ReportViewer>
    </form>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="pageScript" runat="server">
    <script src="../scripts/GeneralScripts.js"></script>
</asp:Content>
