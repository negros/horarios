<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormCohorte.aspx.cs" Inherits="HorarioCtgi.FormCohorte" %>

<!DOCTYPE html lang="es">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="Sena" />
    <meta name="author" content="Sena" />
    <link rel="icon" href="css/tiempo-pasando.png" />

    <title>Cohortes</title>

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
                        <li class="NavPrimary-item is-active">
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
                                <h1 class="Post-title Post-title--lg">Cohortes</h1>
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
                                            <label for="txtcodigo">Código:</label></td>
                                        <td>
                                            <asp:TextBox ID="txtcodigo" runat="server" CssClass="validate"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="txtnombre">Nombre:</label></td>
                                        <td>
                                            <asp:TextBox ID="txtnombre" runat="server" CssClass="validate"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="txtfecha_inicio">Fecha Inicio:</label></td>
                                        <td>
                                            <asp:TextBox ID="txtfecha_inicio" runat="server" TextMode="Date" CssClass="validate"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="txtfecha_fin">Fecha Fin:</label></td>
                                        <td>
                                            <asp:TextBox ID="txtfecha_fin" runat="server" TextMode="Date" CssClass="validate"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="txtano">Año:</label></td>
                                        <td>
                                            <asp:TextBox ID="txtano" runat="server" CssClass="validate"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddltrimestre" runat="server" CssClass="browser-default">
                                                <asp:ListItem Value="" disabled Selected> Trimestre </asp:ListItem>
                                                <asp:ListItem Value="1"> 1° Trimestre </asp:ListItem>
                                                <asp:ListItem Value="2"> 2° Trimestre </asp:ListItem>
                                                <asp:ListItem Value="3"> 3° Trimestre </asp:ListItem>
                                                <asp:ListItem Value="4">4° Trimestre</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>

                                <!--Botones-->
                                <br />
                                <br />
                                <p class="text-align--center">
                                    <asp:Button ID="GuardarCohorte" runat="server" Text="Guardar" CssClass="button button--inline-block button--medium" OnClick="GuardarCohorte_Click" />
                                  
                                    <asp:Button ID="ListarCohorte" runat="server" Text="Listar" CssClass="button button--inline-block button--medium" OnClick="ListarCohorte_Click" />
                                </p>

                                <!-- Lista -->

                           
                                <div> 
                                        <asp:GridView ID="DTVListar" runat="server" AutoGenerateColumns="false" DataKeyNames="codigo_coho" OnPageIndexChanging="DTVListar_PageIndexChanging"
                                         OnRowCancelingEdit="DTVListar_RowCancelingEdit"  OnRowEditing="DTVListar_RowEditing" OnRowUpdating="DTVListar_RowUpdating">  
                    <Columns>  
                       <asp:BoundField HeaderText="Codigo" ReadOnly="true" DataField="codigo_coho" />
                                        <asp:BoundField HeaderText="Nombre" DataField="nombre_coho" />
                                        <asp:BoundField HeaderText="Fecha inicio" DataField="fechainicio_coho" />
                                        <asp:BoundField HeaderText="Fecha fin" DataField="fechafin_coho" />
                                        <asp:BoundField HeaderText="Año" DataField="año_coho" />
                                        <asp:BoundField HeaderText="Trimestre" DataField="trimestre_coho"/>
                        <asp:CommandField ShowEditButton="true" />  
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
