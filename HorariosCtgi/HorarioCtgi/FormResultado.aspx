<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormResultado.aspx.cs" Inherits="HorarioCtgi.FormResultado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="Sena" />
    <meta name="author" content="Sena" />
    <link rel="icon" href="css/tiempo-pasando.png" />

    <title>Resultados</title>

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
                        <li class="NavPrimary-item">
                            <a href="FormPrograma.aspx" class="NavPrimary-link">Programa</a>
                        </li>
                        <li class="NavPrimary-item is-active">
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
                                <h1 class="Post-title Post-title--lg">Resultado</h1>
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
                                            <label for="txtcodigo">Código Resultado:</label></td>
                                        <td>
                                            <asp:TextBox ID="txtcodigo" runat="server" class="validate"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="txtnombre">Nombre Resultado:</label></td>
                                        <td>
                                            <asp:TextBox ID="txtnombre" runat="server" class="validate" Width="458px"></asp:TextBox></td>
                                    </tr>
                                    <%--<tr>
                                        <td>
                                            <label for="txthorai">Hora Inicio:</label></td>
                                        <td>
                                            <asp:TextBox ID="txthorai" runat="server" TextMode="Time" placeholder="" CssClass="validate"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="txthoraf">Hora Finalización:</label></td>
                                        <td>
                                            <asp:TextBox ID="txthoraf" TextMode="Time" runat="server" placeholder="" CssClass="validate"></asp:TextBox></td>
                                    </tr>--%>
                                    <tr>
                                        <td>
                                            <label for="txtdescipcion">Descripción:</label></td>
                                        <td>
                                            <asp:TextBox ID="txtdescripcion" runat="server" class="validate" Width="458px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>Competencia</label></td>
                                        <td>
                                            <asp:SqlDataSource
                                                ID="SqlDataSource1"
                                                runat="server"
                                                DataSourceMode="DataReader"
                                                ConnectionString="<%$ ConnectionStrings:conSQLServer%>"
                                                SelectCommand="SELECT id_comp, nombre_comp FROM competencia"></asp:SqlDataSource>

                                            <asp:DropDownList ID="competencia" runat="server"
                                                DataTextField="nombre_comp"
                                                DataValueField="id_comp"
                                                DataSourceID="SqlDataSource1">
                                            </asp:DropDownList></td>
                                    </tr>
                                </table>

                                <!--Botones-->
                                <br />
                                <br />
                                <p class="text-align--center">
                                    <asp:Button ID="Button1" class="button button--inline-block button--medium" runat="server" Text="Insertar" OnClick="Insertar_Click" OnClientClick="validar" />
                                    <asp:Button ID="Button4" class="button button--inline-block button--medium" runat="server" Text="Consultar" OnClick="Consultar_Click" />
                                    <asp:Button ID="Button5" class="button button--inline-block button--medium" runat="server" Text="Listar" OnClick="Listar_Click" />
                                </p>

                                <!-- Lista -->

                          

                                      <asp:GridView ID="grvResultado" runat="server" AutoGenerateColumns="false" class="responsive-table striped" DataKeyNames="codigo_resu" OnPageIndexChanging="DTVListar_PageIndexChanging"
                                         OnRowCancelingEdit="DTVListar_RowCancelingEdit" OnRowDataBound="DTVListar_RowDataBound"  OnRowEditing="DTVListar_RowEditing" OnRowUpdating="DTVListar_RowUpdating" OnRowDeleting="DTVListar_RowDeleting" >
                                    <Columns>
                                      
                                        <asp:BoundField DataField="codigo_resu" ReadOnly="true" HeaderText="Código" SortExpression="codigo_resu" />
                                        <asp:BoundField DataField="nombre_resu" HeaderText="Nombre" SortExpression="nombre_resu" />
                                        <asp:BoundField DataField="descripcion_resu" HeaderText="Descripcion" SortExpression="descripcion_resu" />
                                        <asp:BoundField DataField="nombre_comp" HeaderText="Competencia" SortExpression="nombre_comp" />
                                         <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="competencia" runat="server"
                                                DataTextField="nombre_comp"
                                                DataValueField="id_comp"
                                                DataSourceID="SqlDataSource1">
                                            </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        <asp:BoundField  DataField="id_competencia" />
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
