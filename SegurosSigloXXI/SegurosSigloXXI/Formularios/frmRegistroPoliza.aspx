<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.Master" AutoEventWireup="true" CodeBehind="frmRegistroPoliza.aspx.cs" Inherits="SegurosSigloXXI.Formularios.frmRegistroPoliza" %>

<<%@ MasterType VirtualPath="~/Plantilla.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                <div class="form-group">
                    <label for="txtIdCoberturaPoliza">ID Cobertura de Póliza</label>
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
                    <label for="txtNombre">Nombre del Cliente</label>
                    <input type="text" class="form-control" name="txtNombre" runat="server" id="txtNombre" />
                </div>
                <div class="form-group">
                    <label for="txtMontoAsegurado">Monto Asegurado</label>
                    <asp:RequiredFieldValidator
                        ValidationGroup="insert"
                        ForeColor="Red"
                        ErrorMessage="*"
                        ControlToValidate="txtMontoAsegurado"
                        runat="server"
                        SetFocusOnError="true" />
                    <input type="number" class="form-control" name="txtMontoAsegurado" runat="server" id="txtMontoAsegurado" />
                </div>
                <div class="form-group">
                    <label for="txtPorcentajeCobertura">Porcentaje de Cobertura de Póliza</label>
                    <asp:RequiredFieldValidator
                        ValidationGroup="insert"
                        ForeColor="Red"
                        ErrorMessage="*"
                        ControlToValidate="txtPorcentajeCobertura"
                        runat="server"
                        SetFocusOnError="true" />
                    <input type="text" class="form-control" name="txtPorcentajeCobertura" runat="server"
                        id="txtPorcentajeCobertura" disabled />
                </div>
                <div class="form-group">
                    <label for="txtNumeroAdicciones">Número de Adicciones</label>
                    <asp:RequiredFieldValidator
                        ValidationGroup="insert"
                        ForeColor="Red"
                        ErrorMessage="*"
                        ControlToValidate="txtNumeroAdicciones"
                        runat="server"
                        SetFocusOnError="true" />
                    <input type="text" class="form-control" name="txtNumeroAdicciones" runat="server"
                        id="txtNumeroAdicciones" disabled />
                </div>
                <div class="form-group">
                    <label for="txtMontoAdicciones">Monto de Adicciones</label>
                    <asp:RequiredFieldValidator
                        ValidationGroup="insert"
                        ForeColor="Red"
                        ErrorMessage="*"
                        ControlToValidate="txtMontoAdicciones"
                        runat="server"
                        SetFocusOnError="true" />
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
                <div class="form-group">
                    <label for="txtPrimaFinal">Prima Final</label>
                    <input type="text" class="form-control" name="txtPrimaFinal" runat="server"
                        id="txtPrimaFinal" disabled />
                </div>
                
                <asp:Button CssClass="btn btn-success" Text="Registrar" CausesValidation="true"
                    runat="server" ValidationGroup="insert" OnClick="InsertaRegistro_Click" />
            </div>
        </div>

        <asp:GridView runat="server"
            ID="tablaRegistroPolizas"
            OnRowEditing="onRowEditing"
            OnRowUpdating="onRowUpdating"
            OnRowDeleting="onRowDeleting"
            OnRowCancelingEdit="onCancelEditing"
            AllowPaging="true"
            AutoGenerateColumns="false"
            PageSize="10"
            CssClass="table table-bordered table-sm table-responsive"
            OnPageIndexChanging="Paginacion">
            <Columns>
                <%-- Columnas de datos --%>
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="true" />
                <asp:TemplateField HeaderText="Nombre Adicción">
                    <ItemTemplate>
                        <%#Eval("Nombre") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <input type="text"
                            value='<%#Eval("Nombre") %>'
                            name="txt_Nombre" id="txt_Nombre"
                            runat="server" class="form-control-sm" />
                        <asp:RegularExpressionValidator
                            ForeColor="Red"
                            ErrorMessage="* Solo se permiten letras"
                            Display="Dynamic"
                            ControlToValidate="txt_Nombre"
                            ValidationExpression="([a-zA-Z]+)"
                            runat="server" />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Código Adicción">
                    <ItemTemplate>
                        <%#Eval("Codigo") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <input type="text"
                            value='<%#Eval("Codigo") %>'
                            name="txt_Codigo" id="txt_Codigo"
                            runat="server" class="form-control-sm" />
                    </EditItemTemplate>
                </asp:TemplateField>


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
</asp:Content>
