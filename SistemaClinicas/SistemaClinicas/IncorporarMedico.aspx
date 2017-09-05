<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IncorporarMedico.aspx.cs" Inherits="ComprobantesRetencion.IncorporarMedico" MasterPageFile="~/Site1.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="formCitaAdicional" runat="server" class="form-horizontal">

        <div class="content row">
            <div class="col-md-12">
                <div class="tab-content">
                    <div class="tab-pane settings active">
                        <div class="box box-info">
                            <div class="box-header with-border">
                                <h3>Incorporar Médico</h3>
                            </div>

                            <div class="box-body" id="bbBuscarCMP">
                                <div class="box-group">
                                    <div class="form-group">
                                        <asp:Label Text="" ID="lblMensaje" runat="server" CssClass="text-green col-sm-12" />
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">Nro de CMP:</label>
                                        <div class="col-sm-4 control-label">
                                            <asp:TextBox name="txtCMP" CssClass="form-control" ID="txtCMP" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </div>
                                        <label class="col-sm-2 control-label"></label>
                                        <div class="col-sm-4">
                                            <asp:Button type="submit" CssClass="btn btn-primary" Text="Buscar"
                                                ID="btnBuscar" runat="server"
                                                UseSubmitBehavior="false"
                                                OnClick="btnBuscarCliente_Click" Width="280px" />
                                        </div>
                                    </div>

                                    <div class="col-sm-4" style="padding-left:200px">
                                            <asp:Image name="imgMedico" ID="imgMedico" class="img-thumbnail"  runat="server" width="150" height="186" />
                                        </div>

                                    <div class="col-sm-2">
                                        </div>

                                    <div class="form-group">
                                                                              
                                        <label class="col-sm-2 control-label">Apellido Paterno:</label>
                                        <div class="col-sm-4 ">
                                            <asp:Label name="lblApPaterno" CssClass="form-control" ID="lblApPaterno" runat="server"></asp:Label>
                                        </div>
                                        
                                    </div>

                                    <div class="form-group">
                                        

                                        <label class="col-sm-2 control-label">Apellido Materno:</label>
                                        <div class="col-sm-4">
                                            <asp:Label name="lblApMaterno" CssClass="form-control" ID="lblApMaterno" runat="server"></asp:Label>
                                        </div>

                                        <label class="col-sm-2 control-label">Nombres:</label>
                                        <div class="col-sm-4 ">
                                            <asp:Label name="lblNombres" CssClass="form-control" ID="lblNombres" runat="server"></asp:Label>
                                        </div>
                                       
                                    </div>


                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">RNE:</label>
                                        <div class="col-sm-4 control-label">
                                            <asp:Label name="lblRNE" CssClass="form-control" ID="lblRNE" runat="server"></asp:Label>
                                        </div>
                                         <label class="col-sm-2 control-label">Especialidad:</label>
                                        <div class="col-sm-4">
                                            <asp:Label name="lblEspecialidad" CssClass="form-control" ID="lblEspecialidad" runat="server"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">Estado:</label>
                                        <div class="col-sm-4 ">
                                            <asp:Label name="lblEstado" CssClass="form-control" ID="lblEstado" runat="server"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">Observaciones:</label>
                                        <div class="col-sm-10 control-label">
                                            <asp:TextBox name="txtObervaciones" CssClass="form-control input-lg" ID="txtObervaciones" TextMode="MultiLine" Enabled="false" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>
                            </div>

                            <div class="box-body" id="bbBotones">
                                <div class="box-group">
                                    <div class="form-group">


                                        <label class="col-sm-4 control-label">Habilitación para la Clínica:</label>
                                        <div class="col-sm-4 ">
                                            <asp:CheckBox name="chkHabilitacion" ID="chkHabilitacion" runat="server"></asp:CheckBox>
                                        </div>



                                        <div class="col-sm-4">
                                            <asp:Button type="submit" CssClass="btn btn-success" Text="Guardar"
                                                ID="btnGuardar" runat="server"
                                                UseSubmitBehavior="false"
                                                OnClientClick="validarIncorporacion(); return false;" Width="350px" />
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


    </form>
    <script type="text/javascript">
        function validarBuscaCMP() {
            var CMP = $('#ContentPlaceHolder1_txtCMP').val(),
                lblError = $('#ContentPlaceHolder1_lblMensaje')




            if (CMP) {
                lblError.text('');

            } else {
                lblError.text('Debe ingresar un número de CMP.');
            }


        }
        function validarIncorporacion() {
            var CMP = $('#ContentPlaceHolder1_txtObervaciones').val(),
                lblError = $('#ContentPlaceHolder1_lblMensaje')




            if (CMP) {
                lblError.text('');

            } else {
                lblError.text('Antes de guardar debe primero buscar un médico.');
            }


        }

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

    </script>
</asp:Content>
