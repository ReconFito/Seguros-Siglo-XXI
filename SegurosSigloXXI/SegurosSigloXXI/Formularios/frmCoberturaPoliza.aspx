<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.Master" AutoEventWireup="true" CodeBehind="frmCoberturaPoliza.aspx.cs" Inherits="SegurosSigloXXI.Formularios.frmCoberturaPolzia" %>

<%@ MasterType VirtualPath="~/Plantilla.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/GeneralStyles.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <form method="post" runat="server">
        <p class="btn btn-outline-success btnRegistrar"
            id="btnRegistrar" runat="server">
            Registar Cobertura de Poliza
        </p>
        <div class="modal">
            <%-- Formulario insertar Cobertura Poliza --%>
            <div class="frm-insertar bg-light p-2">
                <div class="d-flex border-bottom justify-content-between align-items-baseline">
                    <h4 class="pt-3 pb-3" id="tituloFormulario">Registrar Cobertura de Poliza</h4>
                    <span class="fas fa-times p-0 mr-2 btn" id="cerrar" style="color: dimgray"></span>
                </div>
                <div class="form-group">
                    <label for="txtNombre">Nombre de Cobertura Poliza</label>
                    <asp:RequiredFieldValidator
                        ValidationGroup="insert"
                        ForeColor="Red"
                        ErrorMessage="*"
                        ControlToValidate="txtNombre"
                        Display="Dynamic"
                        runat="server"
                        SetFocusOnError="true" />
                    <input type="text" name="txtNombre" maxlength="100" class="form-control" id="txtNombre" runat="server" />
                    <asp:RegularExpressionValidator
                        ValidationGroup="insert"
                        ForeColor="Red"
                        ErrorMessage="* Solo se permiten letras"
                        Display="Dynamic"
                        ValidationExpression="^([a-zA-Z]\s?)+$"
                        ControlToValidate="txtNombre"
                        runat="server" />
                </div>
                <div class="form-group">
                    <label for="txtDescripcion">Descripción</label>
                    <asp:RequiredFieldValidator
                        ValidationGroup="insert"
                        ForeColor="Red"
                        ErrorMessage="*"
                        ControlToValidate="txtDescripcion"
                        runat="server" />
                    <input type="text" class="form-control" name="txtDescripcion" runat="server" id="txtDescripcion" maxlength="100" />
                    <asp:RegularExpressionValidator
                        ValidationGroup="insert"
                        ForeColor="Red"
                        ErrorMessage="* Solo se permiten letras"
                        ValidationExpression="^([a-zA-Z]\s?)+$"
                        ControlToValidate="txtDescripcion"
                        runat="server" />
                </div>
                <div class="form-group">
                    <label for="txtPorcentaje">Porcetaje</label>
                    <asp:RequiredFieldValidator
                        ValidationGroup="insert"
                        ForeColor="Red"
                        ErrorMessage="*"
                        ControlToValidate="txtPorcentaje"
                        runat="server" />
                    <input type="text" name="txtPorcentaje"
                        id="txtPorcentaje" class="form-control" runat="server" />
                    <asp:RegularExpressionValidator
                        ValidationGroup="insert"
                        ForeColor="Red"
                        ErrorMessage="* Solo se permiten numeros"
                        Display="Dynamic"
                        ValidationExpression="^([0-9]+)([\.|,])?[0-9]+$"
                        ControlToValidate="txtPorcentaje"
                        runat="server" />
                </div>
                <asp:Button CssClass="btn btn-success" Text="Registrar" CausesValidation="true"
                    runat="server" ValidationGroup="insert" OnClick="InsertaRegistro_Click" />
            </div>
        </div>

        <asp:GridView runat="server"
            ID="tablaCoberturaPoliza"
            OnRowEditing="onRowEditing"
            OnRowUpdating="onRowUpdating"
            OnRowCancelingEdit="onCancelEditing"
            AllowPaging="true"
            AutoGenerateColumns="false"
            PageSize="10"
            CssClass="table table-bordered table-sm table-responsive"
            OnPageIndexChanging="Paginacion">
            <Columns>
                <%-- Columnas de datos --%>
                <asp:BoundField DataField="id_Cobertura_Poliza" HeaderText="ID" ReadOnly="true" />
                <asp:TemplateField HeaderText="Nombre">
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
                            ValidationExpression="^([a-zA-Z]\s?)+$"
                            runat="server" />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Descripción">
                    <ItemTemplate>
                        <%#Eval("Descripcion") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <input type="text"
                            value='<%#Eval("Descripcion") %>'
                            name="txt_Descripcion" id="txt_Descripcion"
                            runat="server" class="form-control-sm" />
                        <asp:RegularExpressionValidator
                            ForeColor="Red"
                            ErrorMessage="* Solo se permiten letras"
                            ControlToValidate="txt_Descripcion"
                            ValidationExpression="^([a-zA-Z]\s?)+$"
                            runat="server" />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Porcentaje">
                    <ItemTemplate>
                        <%#Eval("Porcentaje") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <input type="text"
                            value='<%#Eval("Porcentaje") %>'
                            name="txt_Porcentaje" id="txt_Porcentaje"
                            runat="server" class="form-control-sm" />
                        <asp:RegularExpressionValidator
                            ForeColor="Red"
                            ErrorMessage="* Solo se permiten números"
                            Display="Dynamic"
                            ControlToValidate="txt_Porcentaje"
                            ValidationExpression="^([0-9]+)([\.|,])?[0-9]+$"
                            runat="server" />
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
