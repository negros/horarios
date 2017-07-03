<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormFicha.aspx.cs" Inherits="HorarioCtgi.FormFicha" %>

<!DOCTYPE html lang="es">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="Sena" />
    <meta name="author" content="Sena" />
    <link rel="icon" href="css/tiempo-pasando.png" />

    <title>Fichas</title>

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
                        <li class="NavPrimary-item is-active">
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
                                <h1 class="Post-title Post-title--lg">Fichas</h1>
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
                                            <label for="llenarprograma">Programa:</label></td>
                                        <td>
                                            <asp:DropDownList ID="ddlnombre_programa" runat="server" CssClass="browser-default" DataSourceID="llenarprograma" DataTextField="nombre_prog" DataValueField="id_prog"></asp:DropDownList>
                                            <asp:SqlDataSource ID="llenarprograma" runat="server" ConnectionString="<%$ ConnectionStrings:conSQLServer %>" SelectCommand="SELECT id_prog,nombre_prog FROM programa ORDER BY nombre_prog"></asp:SqlDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="txtnintegrante">Número de integrantes:</label></td>
                                        <td>
                                            <asp:TextBox ID="txtnintegrante" runat="server" TextMode="Number" CssClass="validate"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="txtjornada">Jornada</label></td>
                                        <td>
                                            <asp:DropDownList ID="ddljornada" runat="server" CssClass="browser-default">
                                                <asp:ListItem Value="" Enabled="true" Selected="True"> Jornada </asp:ListItem>
                                                <asp:ListItem Value="Diurna"> Diurna </asp:ListItem>
                                                <asp:ListItem Value="Nocturna"> Nocturna </asp:ListItem>
                                                <asp:ListItem Value="Mixta"> Mixta </asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Cohorte</td>
                                        <td>
                                            <asp:SqlDataSource
                                                ID="LlenarDDLCohorte"
                                                runat="server"
                                                DataSourceMode="DataReader"
                                                ConnectionString="<%$ ConnectionStrings:conSQLServer%>"
                                                SelectCommand="SELECT [id_coho], [nombre_coho] FROM [cohorte]"></asp:SqlDataSource>

                                            <asp:DropDownList ID="ddlcohorte" runat="server"
                                                DataTextField="nombre_coho"
                                                DataValueField="id_coho"
                                                DataSourceID="LlenarDDLCohorte">
                                            </asp:DropDownList></td>
                                    </tr>
                                </table>

                                <!--Botones-->
                                <br />
                                <br />
                                <p class="text-align--center">
                                    <asp:Button ID="GuardarFicha" runat="server" Text="Guardar" CssClass="button button--inline-block button--medium" OnClick="GuardarFicha_Click" />
                                 
                                    <asp:Button ID="BuscarFicha" runat="server" Text="Buscar" CssClass="waves-effect waves-light text-black btn white" OnClick="BuscarFicha_Click" />
                                    <asp:Button ID="ListarFicha" runat="server" Text="Listar" CssClass="waves-effect waves-light text-black btn white" OnClick="ListarFicha_Click" />
                                </p>

                                <!-- Lista -->





                                <div>
                                    <asp:GridView ID="DTVListar" runat="server" AutoGenerateColumns="false" DataKeyNames="codigo_ficha" OnPageIndexChanging="DTVListar_PageIndexChanging" OnRowDeleting="DTVListar_RowDeleting"
                                         OnRowCancelingEdit="DTVListar_RowCancelingEdit"  OnRowEditing="DTVListar_RowEditing" OnRowUpdating="DTVListar_RowUpdating"  OnRowDataBound="GridView_RowDataBound">  
                                        <Columns>
                                        
                                        <asp:BoundField HeaderText="Codigo" ReadOnly="true" DataField="codigo_ficha" />
                                        <asp:BoundField HeaderText="Integrantes" DataField="nintegrantes_ficha" />
                                       
                                        

                                             <asp:BoundField HeaderText="Nombre" DataField="nombre_prog" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="DropDownList2" runat="server" 
                                                        DataSourceID="llenarprograma" 
                                                        DataTextField="nombre_prog" 
                                                        DataValueField="id_prog"></asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:BoundField HeaderText="Jornada" DataField="jornada_ficha" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="browser-default">
                                                        <asp:ListItem Value="Diurna"> Diurna </asp:ListItem>
                                                        <asp:ListItem Value="Nocturna"> Nocturna </asp:ListItem>
                                                        <asp:ListItem Value="Mixta"> Mixta </asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField HeaderText="Cohorte" DataField="nombre_coho" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlcohorte" runat="server"
                                                        DataTextField="nombre_coho"
                                                        DataValueField="id_coho"
                                                        DataSourceID="LlenarDDLCohorte">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                             <asp:BoundField HeaderText="id_program" DataField="id_program" />
                                        <asp:BoundField HeaderText="id_cohorte" DataField="id_cohorte" />
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

