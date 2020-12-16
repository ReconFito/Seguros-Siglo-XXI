<%@ Page Title="Mantenimiento Clientes" Language="C#" MasterPageFile="~/Plantilla.Master" AutoEventWireup="true" CodeBehind="frmMantenimientoCliente.aspx.cs" Inherits="SegurosSigloXXI.Formularios.MantenimientoCliente" %>

<%@ MasterType VirtualPath="~/Plantilla.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/GeneralStyles.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <form runat="server" method="post">
        <p class="btn btn-outline-success btnRegistrar" id="btnRegistrar" runat="server">Registar Cliente</p>
        <div class="modal">
            <%-- Formulario insertar mantenimiento cliente --%>
            <div class="frm-insertar bg-light p-2">
                <div class="d-flex border-bottom justify-content-between align-items-baseline">
                    <h4 class="pt-3 pb-3" id="tituloFormulario">Registrar Cliente</h4>
                    <span class="fas fa-times p-0 mr-2 btn" id="cerrar" style="color: dimgray"></span>
                </div>
                <div class="form-row">
                    <div class="col-12 col-sm-6">
                        <div class="form-group">
                            <label for="txtCedula">Cédula</label>
                            <asp:RequiredFieldValidator
                                ValidationGroup="insert"
                                ForeColor="Red"
                                ErrorMessage="*"
                                ControlToValidate="txtCedula"
                                Display="Dynamic"
                                runat="server"
                                SetFocusOnError="true" />
                            <input type="text" name="txtCedula" class="form-control" id="txtCedula" runat="server" />
                            <asp:RegularExpressionValidator
                                ValidationGroup="insert"
                                ForeColor="Red"
                                ErrorMessage="* Solo se permiten números"
                                Display="Dynamic"
                                ValidationExpression="[0-9]+"
                                ControlToValidate="txtCedula"
                                runat="server" />
                        </div>
                        <div class="form-group">
                            <label for="txtGenero">Género</label>
                            <asp:RequiredFieldValidator
                                ValidationGroup="insert"
                                ForeColor="Red"
                                ErrorMessage="*"
                                ControlToValidate="txtGenero"
                                runat="server" />
                            <select runat="server" id="txtGenero" class="form-control">
                                <option value="m">Hombre</option>
                                <option value="f">Mujer</option>
                            </select>
                        </div>
                        <div class="form-group">
                            <label for="txtNombre">Nombre</label>
                            <asp:RequiredFieldValidator
                                ValidationGroup="insert"
                                ForeColor="Red"
                                ErrorMessage="*"
                                ControlToValidate="txtNombre"
                                runat="server" />
                            <input type="text" name="txtNombre"
                                id="txtNombre" class="form-control" runat="server" />
                        </div>
                        <div class="form-group">
                            <label for="txtPrimerApellido">Primer Apellido</label>
                            <asp:RequiredFieldValidator
                                ValidationGroup="insert"
                                ForeColor="Red"
                                ErrorMessage="*"
                                ControlToValidate="txtPrimerApellido"
                                runat="server" />
                            <input type="text" name="txtPrimerApellido" id="txtPrimerApellido" class="form-control" runat="server" />
                        </div>
                        <div class="form-group">
                            <label for="txtSegundoApellido">Segundo Apellido</label>
                            <asp:RequiredFieldValidator ErrorMessage="*"
                                ValidationGroup="insert"
                                ForeColor="Red"
                                ControlToValidate="txtSegundoApellido"
                                runat="server" />
                            <input type="text" name="txtSegundoApellido" id="txtSegundoApellido"
                                class="form-control" runat="server" />
                        </div>
                    </div>
                    <div class="col-12 col-sm-6">
                        <div class="form-group">
                            <label for="txtDireccion">Dirección</label>
                            <asp:RequiredFieldValidator
                                ValidationGroup="insert"
                                ForeColor="Red"
                                ErrorMessage="*"
                                ControlToValidate="txtDireccion"
                                runat="server" />
                            <input type="text" name="txtDireccion" id="txtDireccion" class="form-control" runat="server" />
                        </div>
                        <div class="form-group">
                            <label for="txtTelefonoPrincipal">Teléfono Principal</label>
                            <asp:RequiredFieldValidator
                                ValidationGroup="insert"
                                ForeColor="Red"
                                ErrorMessage="*"
                                ControlToValidate="txtTelefonoPrincipal"
                                runat="server" />
                            <input type="text" name="txtTelefonoPrincipal"
                                id="txtTelefonoPrincipal" class="form-control" runat="server" />
                            <div>
                                <asp:RegularExpressionValidator
                                    ValidationGroup="insert"
                                    Display="Dynamic"
                                    ForeColor="Red"
                                    ErrorMessage="* Solo se permiten números"
                                    ControlToValidate="txtTelefonoPrincipal"
                                    ValidationExpression="[0-9]+"
                                    runat="server" />
                                <asp:RegularExpressionValidator
                                    ValidationGroup="insert"
                                    Display="Dynamic"
                                    ForeColor="Red"
                                    ErrorMessage="* Longitud minima de 8 digitos"
                                    ControlToValidate="txtTelefonoPrincipal"
                                    ValidationExpression="([0-9]{8})"
                                    runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="txtTelefonoSecundario">Teléfono Secundario</label>
                            <input type="text" name="txtTelefonoSecundario"
                                id="txtTelefonoSecundario" class="form-control"
                                runat="server" placeholder="Opcional" />
                        </div>
                        <div class="form-group">
                            <label for="txtEmail">E-mail</label>
                            <asp:RequiredFieldValidator
                                ValidationGroup="insert"
                                ForeColor="Red"
                                ErrorMessage="*"
                                ControlToValidate="txtEmail"
                                runat="server" />
                            <input type="email" name="txtEmail" id="txtEmail"
                                class="form-control" runat="server" />
                        </div>
                        <div class="form-group">
                            <label for="txtFechaNacimiento">Fecha de Nacimiento</label>
                            <asp:RequiredFieldValidator
                                ValidationGroup="insert"
                                ForeColor="Red"
                                ErrorMessage="*"
                                ControlToValidate="txtFechaNacimiento"
                                runat="server" />
                            <input type="date" name="txtFechaNacimiento"
                                id="txtFechaNacimiento" class="form-control" runat="server" />
                        </div>
                    </div>
                </div>
                <asp:Button CssClass="btn btn-success" Text="Registrar" CausesValidation="true"
                    runat="server" OnClick="InsertaCliente_Click" ValidationGroup="insert" />
            </div>
        </div>

        <asp:GridView runat="server"
            ID="tablaMantenimientoCliente"
            OnRowEditing="onRowEditing"
            OnRowUpdating="onRowUpdating"
            OnRowCancelingEdit="onCancelEditing"
            OnRowCommand="ComandoAdiccion"
            AllowPaging="true"
            AutoGenerateColumns="false"
            PageSize="10"
            CssClass="table table-bordered table-sm table-responsive"
            OnPageIndexChanging="Paginacion">
            <Columns>
                <%-- Columnas de datos --%>
                <asp:BoundField DataField="id_Cliente" HeaderText="ID" ReadOnly="true" />
                <asp:BoundField DataField="Cedula" HeaderText="Cédula" ReadOnly="true" />
                <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate>
                        <%#Eval("Nombre") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <input type="text" name="txt_Nombre" id="txt_Nombre" runat="server" class="form-control-sm" />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Primer Apellido">
                    <ItemTemplate>
                        <%#Eval("Primer_Apellido") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <input type="text" name="txt_Apellido1" id="txt_Apellido1" runat="server" class="form-control-sm" />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Segundo Apellido">
                    <ItemTemplate>
                        <%#Eval("Segundo_Apellido") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <input type="text" name="txt_Apellido2" id="txt_Apellido2" runat="server" class="form-control-sm" />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Género">
                    <ItemTemplate>
                        <%#Eval("Genero") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <select runat="server" id="slGenero" class="form-control-sm">
                            <option value="h">Hombre</option>
                            <option value="m">Mujer</option>
                        </select>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Fecha de nacimiento">
                    <ItemTemplate>
                        <asp:Label Text='<%#Eval("Fecha_Nacimiento", "{0:dd/MM/yyyy}") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <input type="date" name="txt_Nacimiento" id="txt_Nacimiento" runat="server" class="form-control-sm" />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Teléfono Principal">
                    <ItemTemplate>
                        <%#Eval("Telefono_Principal") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <input type="text" name="txt_Telefono1" id="txt_Telefono1" runat="server" class="form-control-sm" />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Teléfono Secundario">
                    <ItemTemplate>
                        <%#Eval("Telefono_Secundario") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <input type="text" name="txt_Telefono2" id="txt_Telefono2" runat="server" class="form-control-sm" />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Dirección">
                    <ItemTemplate>
                        <%#Eval("Direccion_Fisica") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <input type="text" name="txt_Direccion" id="txt_Direccion" runat="server" class="form-control-sm" />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="E-Mail">
                    <ItemTemplate>
                        <%#Eval("Correo_Electronico") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <input type="text" name="txt_Email" id="txt_Email" runat="server" class="form-control-sm" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <%-- Columna Acciones --%>
                <asp:TemplateField HeaderText="Acción" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton Text="Adicción" CommandName="nuevaAdiccion" CommandArgument="<%# (Container as GridViewRow).RowIndex %>" runat="server" />
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
