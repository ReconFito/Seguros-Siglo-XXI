<%@ Page Title="" Language="C#" MasterPageFile="~/Plantilla.Master" AutoEventWireup="true" CodeBehind="frmAdiccion.aspx.cs" Inherits="SegurosSigloXXI.Formularios.frmAdiccion" %>

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
                    <label for="txtNombre">Nombre de la Adicción</label>
                    <asp:RequiredFieldValidator
                        ValidationGroup="insert"
                        ForeColor="Red"
                        ErrorMessage="*"
                        ControlToValidate="txtNombre"
                        Display="Dynamic"
                        runat="server"
                        SetFocusOnError="true" />
                    <input type="text" name="txtNombre" maxlength="50" class="form-control" id="txtNombre" runat="server" />
                    <asp:RegularExpressionValidator
                        ValidationGroup="insert"
                        ForeColor="Red"
                        ErrorMessage="* Solo se permiten letras"
                        Display="Dynamic"
                        ValidationExpression="([a-zA-Z]+)\s?"
                        ControlToValidate="txtNombre"
                        runat="server" />
                </div>
                <div class="form-group">
                    <label for="txtDescripcion">Código</label>
                    <asp:RequiredFieldValidator
                        ValidationGroup="insert"
                        ForeColor="Red"
                        ErrorMessage="*"
                        ControlToValidate="txtCodigo"
                        runat="server" />
                    <input type="text" class="form-control" name="txtCodigo" runat="server" id="txtCodigo" maxlength="60" />
                </div>
                <asp:Button CssClass="btn btn-success" Text="Registrar" CausesValidation="true"
                    runat="server" ValidationGroup="insert" OnClick="InsertaRegistro_Click" />
            </div>
        </div>

        <asp:GridView runat="server"
            ID="tablaAdiccion"
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
                <asp:BoundField DataField="ID_ADICCION" HeaderText="ID" ReadOnly="true" />
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
