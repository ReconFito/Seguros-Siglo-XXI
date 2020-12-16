<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.Master" AutoEventWireup="true" CodeBehind="frmAdiccionCliente.aspx.cs" Inherits="SegurosSigloXXI.Formularios.frmAdiccionCliente" %>

<%@ MasterType VirtualPath="~/Plantilla.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <form method="post" runat="server">
        <p class="btn btn-outline-success btnRegistrar"
            id="btnRegistrar" runat="server">
            Registar 
        </p>
        <div class="modal">
            <%-- Formulario insertar Adicción --%>
            <div class="frm-insertar bg-light p-2">
                <div class="d-flex border-bottom justify-content-between align-items-baseline">
                    <h4 class="pt-3 pb-3" id="tituloFormulario">Registrar Adicción</h4>
                    <span class="fas fa-times p-0 mr-2 btn" id="cerrar" style="color: dimgray"></span>
                </div>
                <div class="form-group">
                    <label for="txtNombreCliente">Nombre del Cliente</label>
                    <asp:RequiredFieldValidator
                        ValidationGroup="insert"
                        ForeColor="Red"
                        ErrorMessage="*"
                        ControlToValidate="txtNombreCliente"
                        Display="Dynamic"
                        runat="server"
                        SetFocusOnError="true" />
                    <select name="txtNombreCliente" class="form-control" id="slNombreCliente" runat="server"></select>
                    <asp:RegularExpressionValidator
                        ValidationGroup="insert"
                        ForeColor="Red"
                        ErrorMessage="* Solo se permiten letras"
                        Display="Dynamic"
                        ValidationExpression="([a-zA-Z]+)"
                        ControlToValidate="txtNombreCliente"
                        runat="server" />
                </div>
                <div class="form-group">
                    <label for="txtDescripcion">Nombre de Adicción</label>
                    <asp:RequiredFieldValidator
                        ValidationGroup="insert"
                        ForeColor="Red"
                        ErrorMessage="*"
                        ControlToValidate="txtNombreAdiccion"
                        runat="server" />
                    <select class="form-control" name="txtNombreAdiccion" runat="server" id="slNombreAdiccion"></select>
                </div>
                <asp:Button CssClass="btn btn-success" Text="Registrar" CausesValidation="true"
                    runat="server" ValidationGroup="insert" OnClick="InsertaRegistro_Click" />
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageScript" runat="server">
</asp:Content>
