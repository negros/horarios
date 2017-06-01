<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormPrograma.aspx.cs" Inherits="HorarioCtgi.FormPrograma" %>

<!DOCTYPE html lang="es">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="Sena" />
    <meta name="author" content="Sena" />
    <link rel="icon" href="css/tiempo-pasando.png" />

    <title>Programa</title>

    <!-- Style Core CSS -->
    <link href="css/estilo.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="Wrapper js-wrapper">

            <!-- Header -->
            <div class="Header">
                <div class="Header-logo">
                    <a href="FormHorarios.aspx">
                        <img class="Header-logo-img" src="css/tiempo-pasando.png" /></a>
                </div>
                <div class="Header-navPrimry NavPrimary">
                    <ul class="NavPrimary-items">
                        <li class="NavPrimary-item">
                            <a href="FormHorarios.aspx" class="NavPrimary-link">Horarios</a>
                        </li>
                        <li class="NavPrimary-item">
                            <a href="FormAmbiente.aspx" class="NavPrimary-link">Ambientes</a>
                        </li>
                        <li class="NavPrimary-item">
                            <a href="FormCohorte.aspx" class="NavPrimary-link">Cohorte</a>
                        </li>
                        <li class="NavPrimary-item">
                            <a href="FormCompetencia.aspx" class="NavPrimary-link">Competencia</a>
                        </li>
                        <li class="NavPrimary-item">
                            <a href="FormFicha.aspx" class="NavPrimary-link">Ficha</a>
                        </li>
                        <li class="NavPrimary-item">
                            <a href="FormInstructores.aspx" class="NavPrimary-link">Instructores</a>
                        </li>
                        <li class="NavPrimary-item">
                            <a href="FormLineaTecno.aspx" class="NavPrimary-link">Línea Tecnológica</a>
                        </li>
                        <li class="NavPrimary-item">
                            <a href="FormTema.aspx" class="NavPrimary-link">Tema</a>
                        </li>
                        <li class="NavPrimary-item  is-active">
                            <a href="FormPrograma.aspx" class="NavPrimary-link">Programa</a>
                        </li>
                        <li class="NavPrimary-item">
                            <a href="FormResultado.aspx" class="NavPrimary-link">Resultados</a>
                        </li>
                        <li class="NavPrimary-item is-active">
                            <br />
                            <a href="#" class="NavPrimary-link">Rubén Darío Cano Betancur</a>
                        </li>
                    </ul>
                </div>
            </div>

            <!-- Contenido -->
            <div class="Main">
                <section class="Section">
                    <div class="Container Container--wide">
                        <nav class="NavPage">
                            <ul class="NavPage-items">
                                <li class="NavPage-item is-active">
                                    <a href="FormHorarios.aspx" class="NavPage-link">Inicio</a>
                                </li>
                                <li class="NavPage-item">
                                    <a href="#" class="NavPage-link">Another thing</a>
                                </li>
                            </ul>
                        </nav>
                    </div>
                </section>

                <section class="Section">
                    <div class="Container Container--narrow">
                        <article class="Post">
                            <div class="Post-header">
                                <h1 class="Post-title Post-title--lg">Programas</h1>
                                <ul class="Post-meta Post-meta--single">
                                    <li class="Post-meta-item date">
                                        <span class="Post-meta-desc">
                                            <asp:Label ID="chafe1" runat="server"></asp:Label></span>
                                    </li>
                                </ul>

                                <!--Formulario-->

                                <table>
                                    <tr>
                                        <td>
                                            <label for="cod_programa">Código Programa:</label></td>
                                        <td>
                                            <asp:TextBox ID="cod_programa" runat="server" CssClass="validate"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="nombre_prog">Nombre Programa:</label></td>
                                        <td>
                                            <asp:TextBox ID="nombre_prog" runat="server" CssClass="validate"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="version_prog">Versión Programa:</label></td>
                                        <td>
                                            <asp:TextBox ID="version_prog" runat="server" CssClass="validate"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="descripcion_prog">Descripción Programa:</label></td>
                                        <td>
                                            <asp:TextBox ID="descripcion_prog" runat="server" CssClass="validate"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="SqlDataSource1">Línea:</label>
                                            <asp:SqlDataSource
                                                ID="SqlDataSource1"
                                                runat="server"
                                                DataSourceMode="DataReader"
                                                ConnectionString="<%$ConnectionStrings:conSQLServer%>"
                                                SelectCommand="SELECT id_linea_tecno, nombre_linea_tecno FROM linea_tecno"></asp:SqlDataSource>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="lintec" runat="server"
                                                DataTextField="nombre_linea_tecno"
                                                DataValueField="id_linea_tecno"
                                                DataSourceID="SqlDataSource1">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>

                                <!--Botones-->
                                <br />
                                <br />
                                <p class="text-align--center">
                                    <asp:Button ID="Ingresar" runat="server" Text="Ingresar" CssClass="button button--inline-block button--medium" OnClick="Ingresar_Click" />
                                    <asp:Button ID="Buscar" runat="server" Text="Buscar" CssClass="button button--inline-block button--medium" OnClick="Buscar_Click" OnClientClick="return validar_consultar()" />
                                    <asp:Button ID="Modificar" runat="server" Text="Modificar" CssClass="button button--inline-block button--medium" OnClick="Modificar_Click" />
                                    <asp:Button ID="Eliminar" runat="server" Text="Eliminar" CssClass="button button--inline-block button--medium" OnClick="Eliminar_Click" OnClientClick="return validar_eliminar()" />
                                    <asp:Button ID="Listar" runat="server" Text="Listar" CssClass="button button--inline-block button--medium" OnClick="Listar_Click" />
                                </p>

                                <!-- Lista -->

                                <asp:GridView ID="DTVListar" AutoGenerateColumns="false" runat="server">
                                    <Columns>
                                        <asp:BoundField HeaderText="Id" DataField="id_prog" />
                                        <asp:BoundField HeaderText="Código Programa" DataField="codigo_prog" />
                                        <asp:BoundField HeaderText="Nombre Programa" DataField="nombre_prog" />
                                        <asp:BoundField HeaderText="Descripción" DataField="descripcion_prog" />
                                        <asp:BoundField HeaderText="Version Programa" DataField="version_prog" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </article>
                    </div>
                </section>

            </div>

        </div>
    </form>
</body>
</html>

