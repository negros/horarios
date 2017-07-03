<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormTema.aspx.cs" Inherits="HorarioCtgi.FormTema" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="Sena" />
    <meta name="author" content="Sena" />
    <link rel="icon" href="css/tiempo-pasando.png" />

    <title>Tema</title>

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
                        <li class="NavPrimary-item is-active">
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
                                <h1 class="Post-title Post-title--lg">Tema</h1>
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
                                            <label for="txtcod_tema">Codigo del Tema:</label></td>
                                        <td>
                                            <asp:TextBox ID="txtcod_tema" runat="server" class="validate"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="txtnombre_tema">Nombre del Tema:</label></td>
                                        <td>
                                            <asp:TextBox ID="txtnombre_tema" runat="server" class="validate"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="txtdescripcion_tema">Decripción del Tema:</label></td>
                                        <td>
                                            <asp:TextBox ID="txtdescripcion_tema" runat="server" class="validate"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>Resultado</label></td>
                                        <td>
                                            <asp:SqlDataSource
                                                ID="SqlDataSource1"
                                                runat="server"
                                                DataSourceMode="DataReader"
                                                ConnectionString="<%$ ConnectionStrings:conSQLServer%>"
                                                SelectCommand="SELECT id_resu, nombre_resu FROM resultado"></asp:SqlDataSource>

                                            <asp:DropDownList ID="resultado" runat="server"
                                                DataTextField="nombre_resu"
                                                DataValueField="id_resu"
                                                DataSourceID="SqlDataSource1">
                                            </asp:DropDownList></td>
                                    </tr>
                                </table>

                                <!--Botones-->
                                <br />
                                <br />
                                <p class="text-align--center">
                                    <asp:Button class="button button--inline-block button--medium" ID="btnInsertar" runat="server" Text="Insertar" OnClick="Insertar" />
                                    <asp:Button class="button button--inline-block button--medium" ID="btnConsultar" runat="server" Text="Consultar" OnClick="Consultar" />
                                    <asp:Button class="button button--inline-block button--medium" ID="btnListar" runat="server" Text="Listar" OnClick="btnListar_Click" />
                                </p>

                                <!-- Lista -->

                           



                                      <asp:GridView ID="DTVListar" runat="server" AutoGenerateColumns="false" class="responsive-table striped" DataKeyNames="codigo_tema" 
                                         OnRowCancelingEdit="DTVListar_RowCancelingEdit" OnRowDataBound="DTVListar_RowDataBound"  OnRowEditing="DTVListar_RowEditing" OnRowUpdating="DTVListar_RowUpdating" OnRowDeleting="DTVListar_RowDeleting" >
                                    <Columns>
                                      
                                          <asp:BoundField DataField="codigo_tema" ReadOnly="true" HeaderText="Codigo del Tema" SortExpression="codigo_tema" />
                                        <asp:BoundField DataField="nombre_tema" HeaderText="Nombre del Tema" SortExpression="nombre_tema" />
                                        <asp:BoundField DataField="descripcion_tema" HeaderText="Descripcion del Tema" SortExpression="descripcion_tema" />
                                        <asp:BoundField DataField="nombre_resu" HeaderText="Resultado" SortExpression="Resultado" />
                                         <asp:TemplateField>
                                                <ItemTemplate>
                                                     <asp:DropDownList ID="resultado" runat="server"
                                                DataTextField="nombre_resu"
                                                DataValueField="id_resu"
                                                DataSourceID="SqlDataSource1">
                                            </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        <asp:BoundField  DataField="id_resultado" />
                                        <asp:CommandField ShowHeader="false" ShowEditButton="true" />
                                        <asp:CommandField ShowHeader="false" ShowDeleteButton="true" />
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

