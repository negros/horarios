<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormHorarios.aspx.cs" Inherits="HorarioCtgi.Home" %>

<!DOCTYPE html lang="es">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="Sena" />
    <meta name="author" content="Sena" />
    <link rel="icon" href="css/ajustes.png" />

    <title>Horarios Ctgi</title>

    <!-- Style Core CSS -->
    <link href="css/estilo.css" rel="stylesheet" />
</head>
<body>
    <form id="form4" runat="server">
        <div class="Wrapper js-wrapper">

            <!-- Header -->
            <div class="Header">
                <div class="Header-logo">
                    <a href="FormHorarios.aspx">
                        <img class="Header-logo-img" src="css/tiempo-pasando.png" /></a>
                </div>
                <div class="Header-navPrimry NavPrimary">
                    <ul class="NavPrimary-items">
                        <li class="NavPrimary-item is-active">
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
                                <h1 class="Post-title Post-title--lg">Inicio</h1>
                                <ul class="Post-meta Post-meta--single">
                                    <li class="Post-meta-item date">
                                        <span class="Post-meta-desc">
                                            <asp:Label ID="chafe1" runat="server"></asp:Label></span>
                                    </li>
                                </ul>

                                <!--Formulario-->

                                <table>
                                    <tr>
                                        <td class="auto-style1">
                                            <label for="txtcod_asig">Código Asignación</label>
                                        </td>
                                        <td class="auto-style1">
                                            <asp:TextBox ID="txtcod_asig" runat="server" class="validate" Width="300px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="txtfecha_ini">Fecha Inicio Asignación</label></td>
                                        <td>
                                            <asp:TextBox ID="txtfecha_ini" runat="server" TextMode="Date" class="validate"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="txtfecha_fin">Fecha Fin Asignación</label></td>
                                        <td>
                                            <asp:TextBox ID="txtfecha_fin" runat="server" TextMode="Date" class="validate"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="txthora_ini">Hora Inicio Asignación</label></td>
                                        <td>
                                            <asp:TextBox ID="txthora_ini" runat="server" TextMode="Time" class="validate"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="txthora_fin">Hora Fin Asignación</label></td>
                                        <td>
                                            <asp:TextBox ID="txthora_fin" runat="server" TextMode="Time" class="validate"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="txtdia_asig">Día Asignación</label></td>
                                        <td>
                                            <asp:TextBox ID="txtdia_asig" runat="server" class="validate"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="txtdescripcion_asig">Descripción Asignación</label></td>
                                        <td>
                                            <asp:TextBox ID="txtdescripcion_asig" runat="server" class="validate" TextMode="multiline" Columns="50" Rows="5"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>Ambiente</label></td>
                                        <td>
                                            <asp:SqlDataSource
                                                ID="SqlDataSource1"
                                                runat="server"
                                                DataSourceMode="DataReader"
                                                ConnectionString="<%$ ConnectionStrings:conSQLServer%>"
                                                SelectCommand="SELECT id_amb, nombre_amb FROM ambiente"></asp:SqlDataSource>

                                            <asp:DropDownList ID="ambiente" runat="server"
                                                DataTextField="nombre_amb"
                                                DataValueField="id_amb"
                                                DataSourceID="SqlDataSource1">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>Ficha</label></td>
                                        <td>
                                            <asp:SqlDataSource
                                                ID="SqlDataSource2"
                                                runat="server"
                                                DataSourceMode="DataReader"
                                                ConnectionString="<%$ ConnectionStrings:conSQLServer%>"
                                                SelectCommand="SELECT id_ficha, codigo_ficha FROM ficha"></asp:SqlDataSource>

                                            <asp:DropDownList ID="ficha" runat="server"
                                                DataTextField="codigo_ficha"
                                                DataValueField="id_ficha"
                                                DataSourceID="SqlDataSource2">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>Resultado Aprendizaje</label></td>
                                        <td>
                                            <asp:SqlDataSource
                                                ID="resultadoslista"
                                                runat="server"
                                                DataSourceMode="DataReader"
                                                ConnectionString="<%$ ConnectionStrings:conSQLServer%>"
                                                SelectCommand="SELECT id_resu, nombre_resu FROM resultado"></asp:SqlDataSource>

                                            <asp:DropDownList ID="resultado" runat="server"
                                                DataTextField="nombre_resu"
                                                DataValueField="id_resu"
                                                DataSourceID="resultadoslista">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>Instructor</label></td>
                                        <td>
                                            <asp:SqlDataSource
                                                ID="SqlDataSource4"
                                                runat="server"
                                                DataSourceMode="DataReader"
                                                ConnectionString="<%$ ConnectionStrings:conSQLServer%>"
                                                SelectCommand="SELECT [id_instructor], [nombre_instructor], [apellido_instructor], CONCAT (nombre_instructor,' ',apellido_instructor) AS [nombreins] FROM [tbl_instructor]"></asp:SqlDataSource>

                                            <asp:DropDownList ID="instructor" runat="server"
                                                DataTextField="nombreins"
                                                DataValueField="id_instructor"
                                                DataSourceID="SqlDataSource4">
                                            </asp:DropDownList></td>
                                    </tr>
                                </table>

                                <!--Botones-->
                                <br />
                                <br />
                                <p class="text-align--center">
                                    <asp:Button class="button button--inline-block button--medium" ID="btnInsertar" runat="server" Text="Insertar" OnClick="btnInsertar_Click" />
                                    <asp:Button class="button button--inline-block button--medium" ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
                                    <asp:Button class="button button--inline-block button--medium" ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                                    <asp:Button class="button button--inline-block button--medium" ID="btnConsultar" runat="server" Text="Consultar" OnClick="btnConsultar_Click" />
                                    <asp:Button class="button button--inline-block button--medium" ID="btnListar" runat="server" Text="Listar" OnClick="btnListar_Click" />
                                </p>

                                <!-- Lista -->

                                <asp:GridView ID="listaAsig" runat="server" AutoGenerateColumns="false" class="responsive-table striped">
                                    <Columns>
                                        <asp:BoundField DataField="cod_asig" HeaderText="Codigo Asignación" SortExpression="cod_asig" />
                                        <asp:BoundField DataField="fechainicio_asig" HeaderText="Fecha Asignación" SortExpression="fechainicio_asig" />
                                        <asp:BoundField DataField="fechafin_asig" HeaderText="Fecha Fin Asignación" SortExpression="fechafin_asig" />
                                        <asp:BoundField DataField="horainicio_asig" HeaderText="Hora Inicio Asignación" SortExpression="horainicio_asig" />
                                        <asp:BoundField DataField="horafin_asig" HeaderText="Hora Fin Asignación" SortExpression="horafin_asig" />
                                        <asp:BoundField DataField="dia_asig" HeaderText="Día Asignación" SortExpression="dia_asig" />
                                        <asp:BoundField DataField="descripcion_asig" HeaderText="Descripción Asignación" SortExpression="descripcion_asig" />
                                        <asp:BoundField DataField="nombre_amb" HeaderText="Nombre Ambiente" SortExpression="nombre_amb" />
                                        <asp:BoundField DataField="codigo_ficha" HeaderText="Codigo Ficha" SortExpression="codigo_ficha" />
                                        <asp:BoundField DataField="nombre_instructor" HeaderText="Nombre Ins" SortExpression="nombre_instructor" />
                                        <asp:BoundField DataField="nombre_resu" HeaderText="Resultado Apren" SortExpression="nombre_resu" />
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
