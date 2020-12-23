<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.Master" AutoEventWireup="true" CodeBehind="frmRegistroPoliza.aspx.cs" Inherits="SegurosSigloXXI.Formularios.frmRegistroPoliza" %>

<%@ MasterType VirtualPath="~/Plantilla.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/GeneralStyles.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <form method="post" runat="server">
        <p class="btn btn-outline-success btnRegistrar"
            id="btnRegistrar" runat="server">
            Registar Póliza
        </p>
        <div class="modal">
            <%-- Formulario insertar Poliza --%>
            <div class="frm-insertar bg-light p-2">
                <div class="d-flex border-bottom justify-content-between align-items-baseline">
                    <h4 class="pt-3 pb-3" id="tituloFormulario">Registrar Póliza</h4>
                    <span class="fas fa-times p-0 mr-2 btn" id="cerrar" style="color: dimgray"></span>
                </div>
                <div class="form-row">
                    <div class="col-12 col-sm-6">
                        <div class="form-group">
                            <label for="txtNombre">Nombre del Cliente</label>
                            <select runat="server" id="slIdCliente" class="form-control"></select>
                        </div>
                        <div class="form-group">
                            <label for="txtIdCoberturaPoliza">Cobertura de Póliza</label>
                            <asp:RequiredFieldValidator
                                ValidationGroup="insert"
                                ForeColor="Red"
                                ErrorMessage="*"
                                ControlToValidate="slIdCoberturaPoliza"
                                Display="Dynamic"
                                runat="server"
                                SetFocusOnError="true" />
                            <select runat="server" id="slIdCoberturaPoliza" class="form-control"></select>
                        </div>
                        <div class="form-group">
                            <label for="txtMontoAsegurado">Monto Asegurado</label>
                            <asp:RequiredFieldValidator
                                ValidationGroup="insert"
                                ForeColor="Red"
                                ErrorMessage="*"
                                ControlToValidate="txtMontoAsegurado"
                                runat="server" />
                            <input type="number" class="form-control" name="txtMontoAsegurado" runat="server" id="txtMontoAsegurado" />
                        </div>
                        <div class="form-group">
                            <label for="slPorcentajes">Porcentaje de Cobertura por Póliza</label>
                            <input type="text" runat="server" id="txtPorcentaje" class="form-control" disabled />
                        </div>
                    </div>
                    <div class="col col-sm-6">
                        <div class="form-group">
                            <label for="txtNumeroAdicciones">Número de Adicciones</label>
                            <input type="text" class="form-control" name="txtNumeroAdicciones" runat="server"
                                id="txtNumeroAdicciones" disabled />
                        </div>
                        <div class="form-group">
                            <label for="txtMontoAdicciones">Monto de Adicciones</label>
                            <input type="text" class="form-control" name="txtMontoAdicciones" runat="server"
                                id="txtMontoAdicciones" disabled />
                        </div>
                        <div class="form-group">
                            <label for="txtPrimaAntesImpuesto">Prima antes de Impuestos</label>
                            <input type="text" class="form-control" name="txtPrimaAntesImpuesto" runat="server"
                                id="txtPrimaAntesImpuesto" disabled />
                        </div>
                        <div class="form-group">
                            <label for="txtImpuesto">Impuesto</label>
                            <input type="text" class="form-control" name="txtImpuesto" runat="server"
                                id="txtImpuesto" disabled />
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtPrimaFinal">Prima Final</label>
                    <input type="text" class="form-control" name="txtPrimaFinal" runat="server"
                        id="txtPrimaFinal" disabled />
                </div>
                <asp:Button CssClass="btn btn-success" ID="btnIngresar" Text="Registrar"
                    CausesValidation="true" runat="server" ValidationGroup="insert"
                    OnClick="InsertaRegistro_Click" Visible="false" />

                <asp:Button Text="Calcular" ID="btnGenerar" runat="server"
                    OnClick="GeneraPoliza_Click" Visible="true" CssClass="btn btn-info"
                    ValidationGroup="insert"
                    CausesValidation="true" />
            </div>
        </div>
        <asp:GridView runat="server"
            ID="tablaRegistroPolizas"
            OnRowEditing="onRowEditing"
            OnRowUpdating="onRowUpdating"
            OnRowDeleting="onRowDeleting"
            OnRowCancelingEdit="onCancelEditing"
            OnRowDataBound="tablaRegistroPolizas_RowDataBound"
            AllowPaging="true"
            AutoGenerateColumns="false"
            PageSize="10"
            PagerStyle-CssClass="pagination"
            PagerStyle-HorizontalAlign="Center"
            CssClass="table table-bordered table-sm table-responsive"
            OnPageIndexChanging="Paginacion">
            <Columns>
                <%-- Columnas de datos --%>
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="true" />
                <asp:TemplateField HeaderText="Nombre del Cliente">
                    <ItemTemplate>
                        <%#Eval("Nombre_Cliente") + " " + 
                                Eval("Primer_Apellido") + " " + 
                                Eval("Segundo_Apellido") %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Nombre de Cobertura de Póliza">
                    <ItemTemplate>
                        <%#Eval("Nombre_Cobertura") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <select runat="server" id="sl_IdCobertura" class="form-control-sm"
                            onchange="enviarCobertura(this);">
                        </select>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Monto Asegurado">
                    <ItemTemplate>
                        <%#Eval("Monto_Asegurado") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <input type="text"
                            value='<%#Eval("Monto_Asegurado") %>'
                            name="txt_MontoAsegurado" id="txt_MontoAsegurado"
                            runat="server" class="form-control-sm" />
                        <asp:RegularExpressionValidator
                            ForeColor="Red"
                            ErrorMessage="* Solo se permiten números"
                            Display="Dynamic"
                            ControlToValidate="txt_MontoAsegurado"
                            ValidationExpression="^([0-9]+)?([\.|,])[0-9]+$"
                            runat="server" />
                    </EditItemTemplate>
                </asp:TemplateField>

                <%-- NO MODIFICAR --%>
                <asp:TemplateField HeaderText="Porcentaje de Cobertura">
                    <ItemTemplate>
                        <%#Eval("Porcentaje_Cobertura") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <select value='<%#Eval("Porcentaje_Cobertura") %>'
                            name="sl_PorcentajeCobertura" id="sl_PorcentajeCobertura"
                            runat="server" class="form-control-sm" disabled></select>
                    </EditItemTemplate>
                </asp:TemplateField>


                <asp:BoundField DataField="Numero_Adicciones" HeaderText="Número de Adicciones" ReadOnly="true" />
                <%-- indice 6 --%>
                <asp:BoundField DataField="Monto_Adicciones" HeaderText="Monto de Adicciones" ReadOnly="true" />
                <asp:BoundField DataField="Prima_Antes_Impuestos" HeaderText="Prima antes de Impuestos" ReadOnly="true" />
                <asp:BoundField DataField="Impuestos" HeaderText="Impuestos" ReadOnly="true" />
                <asp:BoundField DataField="Prima_Final" HeaderText="Impuestos" ReadOnly="true" />

                <%-- Columna Acciones --%>
                <asp:TemplateField HeaderText="Accción" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton CssClass="fas fa-edit" runat="server" CommandName="Edit" />
                        <asp:LinkButton CssClass="fas fa-user-minus" CommandName="Delete" ForeColor="Red" runat="server" />
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
    <script type="text/javascript">
        const sls = document.querySelectorAll("td > select");
        function enviarCobertura(e) {
            const slPorcentajes = sls[1];
            const slOptions = slPorcentajes.options;
            for (var op of slOptions) {
                if (e.value == op.value) {
                    slPorcentajes.selectedIndex = op.index;
                }
                continue
            }
        }
    </script>
</asp:Content>
