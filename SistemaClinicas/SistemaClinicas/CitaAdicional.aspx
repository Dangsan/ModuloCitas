<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CitaAdicional.aspx.cs" Inherits="ComprobantesRetencion.CitaAdicional" MasterPageFile="~/Site1.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="formCitaAdicional" runat="server" class="form-horizontal">

        <div class="content row">
            <div class="col-md-12">
                <div class="tab-content">
                    <div class="tab-pane settings active">
                        <div class="box box-info">
                            <div class="box-header with-border">
                                <h3>Registrar Cita Adicional</h3>
                            </div>

                            <div class="box-body" id="bbCliente">
                                <div class="box-group">
                                    <div class="form-group">
                                        <asp:Label Text="" ID="lblMensaje" runat="server" CssClass="text-green col-sm-12"  />
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">Sede:</label>
                                        <div class="col-sm-4">
                                            <asp:Label name="lblSede" CssClass="form-control" ID="lblSede" runat="server" ></asp:Label>
                                        </div>
                                        <label class="col-sm-2 control-label">Especialidad:</label>
                                        <div class="col-sm-4">
                                            <asp:Label name="lblEspecialidad" CssClass="form-control" ID="lblEspecialidad" runat="server"></asp:Label>
                                        </div>
                                    </div>


                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">Médico:</label>
                                        <div class="col-sm-4">
                                            <asp:Label name="lblMedico" CssClass="form-control" ID="lblMedico" runat="server"></asp:Label>
                                        </div>
                                        <label class="col-sm-2 control-label">Fecha:</label>
                                        <div class="col-sm-4">
                                            <asp:Label name="lblFecha" CssClass="form-control" ID="lblFecha" runat="server"></asp:Label>
                                        </div>
                                    </div>


                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">Documento del Paciente:</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox name="txtPacienteDNI" CssClass="form-control" ID="txtPacienteDNI" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </div>
                                        <label class="col-sm-2 control-label">Prestación:</label>
                                        <div class="col-sm-4">
                                            <asp:DropDownList ID="ddlPrestación" CssClass="form-control" AutoPostBack="false" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>



                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">Hora:</label>
                                        <div class="col-sm-4">
                                            <asp:DropDownList ID="ddlHora" CssClass="form-control" AutoPostBack="false" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                        <label class="col-sm-2 control-label">Descripción:</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox name="txtDescripcion" CssClass="form-control" ID="txtDescripcion" runat="server" TextMode="MultiLine"></asp:TextBox>

                                        </div>
                                    </div>


                                </div>
                            </div>

                            <div class="box-body" id="bbBotones">
                                <div class="box-group">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label"></label>
                                        <div class="col-sm-4"></div>
                                        <label class="col-sm-2 control-label"></label>
                                        <div class="col-sm-4">
                                            <asp:Button type="submit" CssClass="btn btn-success" Text="Registrar"
                                                ID="btnRegistrar" runat="server"
                                                UseSubmitBehavior="false"
                                                OnClick="btnRegistrar_Click" Width="384px" />
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
        function validarCitAdic() {
            var pacienteDNI = $('#ContentPlaceHolder1_txtPacienteDNI').val(),
                lblError = $('#ContentPlaceHolder1_lblMensaje')




            if (pacienteDNI) {
                lblError.text('');

            } else {
                lblError.text('Debe ingresar un número de documento.');
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
