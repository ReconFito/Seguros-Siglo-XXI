<%@ Page Title="" EnableViewState="false" Language="C#" AutoEventWireup="true" CodeBehind="frmRegistroPrincipal.aspx.cs" Inherits="SegurosSigloXXI.RegistroPrincipal" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <script>
        if (window.history.replaceState) {
            window.history.replaceState(null, null, window.location.href)
        }
    </script>
    <%-- Boostrap --%>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" />
    <%-- Estilos personalizados --%>
    <link href="../styles/registoPrincipal.min.css" rel="stylesheet" />
    <title>Login</title>
</head>
<body>
    <div class="login-container bg-light">
        <div class="login-custom-form rounded shadow">
            <div class="login-logo">
                <h2>Equipo Siglo XXI</h2>
            </div>
            <div class="login-content">
                <form method="post" runat="server">
                    <div class="form-group">
                        <label for="txtEmail">E-mail</label>
                        <asp:RequiredFieldValidator
                            SetFocusOnError="true"
                            ForeColor="Red"
                            Display="Dynamic"
                            ErrorMessage="*"
                            ControlToValidate="txtEmail" runat="server" />
                        <input type="email" name="txtEmail" id="txtEmail" class="form-control" placeholder="example@example.com" runat="server" autofocus="autofocus" />
                        <asp:RegularExpressionValidator
                            ForeColor="Red"
                            Display="Dynamic"
                            ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"
                            ErrorMessage="* Introduce una dirección de correo valida."
                            ControlToValidate="txtEmail"
                            runat="server" />
                    </div>
                    <div class="form-group">
                        <label for="txtPassword">Contraseña</label>
                        <asp:RequiredFieldValidator
                            ForeColor="Red"
                            ErrorMessage="*"
                            ControlToValidate="txtPassword"
                            runat="server" />
                        <input type="password" name="txtPassword" id="txtPassword" class="form-control" runat="server" />
                    </div>
                    <asp:Button Text="Ingresar" runat="server"
                        OnClick="IniciarSesion"
                        CausesValidation="true"
                        CssClass="btn btn-primary" />
                </form>
            </div>
        </div>
    </div>
    <%-- SweetAlert --%>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@10"></script>
    <script type="text/javascript">
        document.documentElement.style.overflow = "hidden";
    </script>
    <script type="text/javascript">
        function mensaje() {
            Swal.fire(
                'Error',
                'Usuario o Contraseña incorrectos',
                'error');
        }

    </script>
</body>
</html>
