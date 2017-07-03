<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormCompetencia.aspx.cs" Inherits="HorarioCtgi.FormCompetencia" %>

<!DOCTYPE html lang="es">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="Sena" />
    <meta name="author" content="Sena" />
    <link rel="icon" href="css/tiempo-pasando.png" />

    <title>Competencias</title>
   
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
                        <li class="NavPrimary-item is-active">
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
                                <h1 class="Post-title Post-title--lg">Competencias</h1>
                                <ul class="Post-meta Post-meta--single">
                                    <li class="Post-meta-item date">
                                        <span class="Post-meta-desc">
                                            <asp:Label ID="chafe1" runat="server"></asp:Label></span>
                                    </li>
                                </ul>

                                <!--Formulario-->

                                <table style="">
                                    <tr>
                                        <td>
                                            <label for="codigo_comp">Código Competencia:</label></td>
                                        <td>
                                            <asp:TextBox ID="codigo_comp" runat="server" CssClass="validate"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="nombre_comp">Nombre Competencia:</label></td>
                                        <td>
                                            <asp:TextBox ID="nombre_comp" runat="server" CssClass="validate"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="comments">Descripción Competencia:</label></td>
                                        <td>
                                            <asp:TextBox ID="descripcion_comp" runat="server" CssClass="validate" Width="469px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>Programa:</label></td>
                                        <td>
                                            <asp:SqlDataSource
                                                ID="SqlDataSource1"
                                                runat="server"
                                                DataSourceMode="DataReader"
                                                ConnectionString="<%$ ConnectionStrings:conSQLServer%>"
                                                SelectCommand="SELECT id_prog, nombre_prog FROM programa"></asp:SqlDataSource>

                                            <asp:DropDownList ID="programa" runat="server"
                                                DataTextField="nombre_prog"
                                                DataValueField="id_prog"
                                                DataSourceID="SqlDataSource1">
                                            </asp:DropDownList></td>
                                    </tr>
                                </table>

                                <!--Botones-->
                                <br />
                                <br />
                                <p class="text-align--center">
                                    <asp:Button ID="Ingresar" runat="server" Text="Ingresar" CssClass="button button--inline-block button--medium" OnClick="Ingresar_Click" OnClientClick="return validar_registrar()" />
                                    <asp:Button ID="Buscar" runat="server" Text="Buscar" CssClass="button button--inline-block button--medium" OnClick="Buscar_Click" OnClientClick="return validar_consultar()" />
                                    <asp:Button ID="Listar" runat="server" Text="Listar" CssClass="button button--inline-block button--medium" OnClick="Listar_Click" />
                                </p>

                                <!-- Lista -->





                                <div>
                                    <asp:GridView ID="grvCompetencia" runat="server" AutoGenerateColumns="false" DataKeyNames="codigo_comp" OnPageIndexChanging="grvCompetencia_PageIndexChanging" OnRowDataBound="GridView_RowDataBound" OnRowCancelingEdit="grvCompetencia_RowCancelingEdit" OnRowDeleting="grvCompetencia_RowDeleting" OnRowEditing="grvCompetencia_RowEditing" OnRowUpdating="grvCompetencia_RowUpdating">
                                        <Columns>
                                            <asp:BoundField DataField="codigo_comp" ReadOnly="true" HeaderText="Codigo Competencia" SortExpression="codigo_comp" />
                                            <asp:BoundField DataField="nombre_comp" HeaderText="Nombre Competencia" SortExpression="nombre_comp" />
                                            <asp:BoundField DataField="descripcion_comp" HeaderText="Descripción" SortExpression="descripcion_comp" />
                                            <asp:BoundField DataField="nombre_prog" HeaderText="Nombre Programa" SortExpression="nombre_prog" />
                                            <asp:BoundField DataField="id_prog" HeaderText="id Programa" SortExpression="id_prog" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="DropDownList1" runat="server"
                                                        DataTextField="nombre_prog"
                                                        DataValueField="id_prog"
                                                        DataSourceID="SqlDataSource1">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:CommandField ShowHeader="false" ShowEditButton="true" />
                                            <asp:CommandField ShowHeader="false" ShowDeleteButton="true" />
                                        </Columns>

                                    </asp:GridView>
                                </div>


                            </div>
                        </article>
                    </div>
                </section>

            </div>

        </div>
    </form>
</body>
</html>
