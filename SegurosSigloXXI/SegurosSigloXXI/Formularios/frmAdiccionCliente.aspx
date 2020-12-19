<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.Master" AutoEventWireup="true" CodeBehind="frmAdiccionCliente.aspx.cs" Inherits="SegurosSigloXXI.Formularios.frmAdiccionCliente" %>
<%@ Import Namespace="SegurosSigloXXI.BL" %>

<%@ MasterType VirtualPath="~/Plantilla.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/GeneralStyles.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <form method="post" runat="server">
        <p class="btn btn-outline-success btnRegistrar"
            id="btnRegistrar" runat="server">
            Registar Adicción
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
                    <input type="text" name="txtNombre" id="txtNombre" class="form-control" runat="server" disabled />
                </div>
                <div class="form-group">
                    <label for="slNombreAdiccion">Nombre de Adicción</label>
                    <asp:RequiredFieldValidator
                        ValidationGroup="insert"
                        ForeColor="Red"
                        ErrorMessage="*"
                        ControlToValidate="slNombreAdiccion"
                        runat="server" />
                    <select class="form-control" name="slNombreAdiccion" runat="server" id="slNombreAdiccion"></select>
                </div>
                <asp:Button CssClass="btn btn-success" Text="Registrar Nueva Adicción" CausesValidation="true"
                    runat="server" ValidationGroup="insert" OnClick="InsertarNuevaAdiccion_Click" />
            </div>
        </div>

        <asp:GridView runat="server"
            ID="tablaAdiccionCliente"
            OnRowEditing="onRowEditing"
            OnRowUpdating="onRowUpdating"
            OnRowCancelingEdit="onCancelEditing"
            OnRowDataBound="tablaAdiccionCliente_RowDataBound"
            AllowPaging="true"
            AutoGenerateColumns="false"
            PageSize="10"
            CssClass="table table-bordered table-sm table-responsive"
            OnPageIndexChanging="Paginacion">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="Id" ReadOnly="true" />
                <asp:BoundField HeaderText="Cedula Cliente" DataField="Cedula" ReadOnly="true" />
                <asp:TemplateField HeaderText="Nombre Cliente" >
                    <ItemTemplate>
                        <%#Eval("nombreCliente") + " " + Eval("Primer_Apellido") + " " + Eval("Segundo_Apellido") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Nombre Adicción">
                    <ItemTemplate>
                        <%#Eval("Nombre") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <select runat="server" id="sl_NombreAdiccion" class="form-control-sm"></select>
                    </EditItemTemplate>
                </asp:TemplateField>

                <%-- Columna Acciones --%>
                <asp:TemplateField HeaderText="Accción" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton CssClass="fas fa-edit" runat="server" CommandName="Edit" />
                        <p onclick="deleteRegister(this);" class="fas fa-user-minus" style="color: red;"></p>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ToolTip="Modificar" CssClass="fas fa-user-cog" CommandName="Update" runat="server" />
                        <asp:LinkButton ToolTip="Cancelar" CssClass="fas fa-times" ForeColor="Red" CommandName="Cancel" runat="server" />
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageScript" runat="server">
    <script src="../scripts/GeneralScripts.js"></script>
</asp:Content>
