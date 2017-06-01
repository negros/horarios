<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormLineaTecno.aspx.cs" Inherits="HorarioCtgi.FormLineaTecno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="Sena" />
    <meta name="author" content="Sena" />
    <link rel="icon" href="css/tiempo-pasando.png" />

    <title>Línea Tecnológica</title>

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
                        <li class="NavPrimary-item is-active">
                            <a href="FormLineaTecno.aspx" class="NavPrimary-link">Línea Tecnológica</a>
                        </li>
                        <li class="NavPrimary-item">
                            <a href="FormTema.aspx" class="NavPrimary-link">Tema</a>
                        </li>
                        <li class="NavPrimary-item">
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
                                <h1 class="Post-title Post-title--lg">Línea Tecnológica</h1>
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
                                            <label for="txtnombre_linea_tecno">Nombre de Linea Tecnologica</label></td>
                                        <td>
                                            <asp:TextBox ID="txtnombre_linea_tecno" runat="server" class="validate"></asp:TextBox></td>
                                    </tr>
                                </table>

                                <!--Botones-->
                                <br />
                                <br />
                                <p class="text-align--center">
                                    <asp:Button class="button button--inline-block button--medium" ID="btnInsertar" runat="server" Text="Insertar" OnClick="Insertar" />
                                    <asp:Button class="button button--inline-block button--medium" ID="Button1" runat="server" Text="Consultar" OnClick="Consultar" />
                                    <asp:Button class="button button--inline-block button--medium" ID="btnListar" runat="server" Text="Listar" OnClick="Listar" />
                                </p>

                                <!-- Lista -->

                                <asp:GridView ID="grvAmbientes" runat="server" AutoGenerateColumns="false" class="responsive-table striped">
                                    <Columns>
                                        <asp:BoundField DataField="nombre_linea_tecno" HeaderText="Nombre de Linea Tecnológica" SortExpression="nombre_linea_tecno" />
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
