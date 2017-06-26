<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormAmbiente.aspx.cs" Inherits="HorarioCtgi.FormAmbiente" %>

<!DOCTYPE html lang="es">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="Sena" />
    <meta name="author" content="Sena" />
    <link rel="icon" href="css/tiempo-pasando.png" />

    <title>Ambientes</title>

    <!-- Style Core CSS -->
    <link href="css/estilo.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            height: 22px;
        }
    </style>
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
                        <li class="NavPrimary-item is-active">
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

                                <h5 class="Post-title Post-title--lg">Ambiente de Aprendizaje</h5>
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
                                            <label for="txtcod_ambiente">Código del ambiente: <br></label></td>
                                        <td class="auto-style1">
                                            <asp:TextBox ID="txtcod_ambiente" runat="server" class="validate" Width="268px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="txtnombre_ambiente">Nombre del ambiente:</label></td>
                                        <td>
                                            <asp:TextBox ID="txtnombre_ambiente" runat="server" class="validate" Width="267px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="txtcapacidad_personas">Capacidad de personas:</label></td>
                                        <td>
                                            <asp:TextBox ID="txtcapacidad_personas" runat="server" class="validate" Width="266px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="txtestado_ambiente">Estado del ambiente:</label></td>
                                        <td>
                                            <asp:TextBox ID="txtestado_ambiente" runat="server" class="validate" Width="267px"></asp:TextBox></td>
                                    </tr>
                                </table>

                                <!--Botones-->
                                <br /><br />
                                <p class="text-align--center">
                                    <asp:Button class="button button--inline-block button--medium" ID="btnInsertar" runat="server" Text="Insertar" OnClick="btnInsertar_Click" />                                
                                    <asp:Button class="button button--inline-block button--medium" ID="btnConsultar" runat="server" Text="Consultar" OnClick="btnConsultar_Click" />
                                    <asp:Button class="button button--inline-block button--medium" ID="btnListar" runat="server" Text="Listar" OnClick="btnListar_Click" />
                                </p>

                                <!-- Lista -->

                        
                                 <div>  
                <asp:GridView ID="grvAmbientes" runat="server" AutoGenerateColumns="false" DataKeyNames="codigo_amb" OnPageIndexChanging="grvAmbientes_PageIndexChanging" OnRowCancelingEdit="grvAmbientes_RowCancelingEdit" OnRowDeleting="grvAmbientes_RowDeleting" OnRowEditing="grvAmbientes_RowEditing" OnRowUpdating="grvAmbientes_RowUpdating">  
                    <Columns>  
                       <asp:BoundField DataField="codigo_amb" ReadOnly="true" HeaderText="Codigo del ambiente" SortExpression="codigo_amb" />
                                        <asp:BoundField DataField="nombre_amb" HeaderText="Nombre del ambiente" SortExpression="nombre_amb" />
                                        <asp:BoundField DataField="capacidad_amb" HeaderText="Capacidad del ambiente" SortExpression="capacidad_amb" />
                                        <asp:BoundField DataField="estado_amb" HeaderText="Estado del ambiente" SortExpression="estado_amb" />
                        <asp:CommandField ShowEditButton="true" />  
                        <asp:CommandField ShowDeleteButton="true" /> </Columns>  
                 
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
