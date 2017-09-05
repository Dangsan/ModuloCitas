<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteTiemposCita.aspx.cs" Inherits="ComprobantesRetencion.ReporteTiemposCita" MasterPageFile="~/Site1.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="formReporte" runat="server" class="form-horizontal">

        <div class="content row">
            <div class="col-md-12">
                <div class="tab-content">
                    <div class="tab-pane settings active">
                        <div class="box box-info">
                            <div class="box-header with-border">
                                <h3>Reporte</h3>
                            </div>

                            <div class="box-body" id="bbReporteCampos">
                                <div class="box-group">
                                    <div class="form-group">
                                        <asp:Label Text="" ID="lblMensaje" runat="server" CssClass="text-green col-sm-12" />
                                    </div>


                                    <div class="form-group">

                                        <label class="col-sm-2 control-label">Elegir:</label>
                                        <div class="col-sm-4 ">
                                            <asp:ListBox ID="lstFruits" name="lstFruits" runat="server" SelectionMode="Multiple">
                                                <asp:ListItem Text="Mango" Value="1" />
                                                <asp:ListItem Text="Apple" Value="2" />
                                                <asp:ListItem Text="Banana" Value="3" />
                                                <asp:ListItem Text="Guava" Value="4" />
                                                <asp:ListItem Text="Orange" Value="5" />
                                            </asp:ListBox>
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

<link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
<script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $('[id*=ContentPlaceHolder1_lstFruits]').multiselect({
            includeSelectAllOption: true
        });
    });
</script>
</asp:Content>
