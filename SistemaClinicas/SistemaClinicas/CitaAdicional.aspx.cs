using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using Negocios;

namespace ComprobantesRetencion
{
    public partial class CitaAdicional : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string eTarget = "";
            try { 
            eTarget = Request.Params["__EVENTTARGET"].ToString();
            }
            catch (Exception ex)
            {
                eTarget = "";
            }

            if (eTarget != "ctl00$ContentPlaceHolder1$btnRegistrar")
            {
            DatosMedico();
            }
        }

        public void LlenarPrestaciones()
        {
            BLLista BLprestacion = new BLLista();
            BELista prestacion = new BELista();

            int especialidad = Convert.ToInt32(Session["especialidad"]);
            ddlPrestación.DataSource = BLprestacion.GetListaxId(especialidad);
            ddlPrestación.DataValueField = "identificador";
            ddlPrestación.DataTextField = "descripcion";
            ddlPrestación.DataBind();
            ddlPrestación.Items.Insert(0, new ListItem("--Seleccione--"));

        }

        public void DatosMedico()
        {
            BLMEdico blMedico = new BLMEdico();
            BEMedico medico = new BEMedico();
            int idusuario = 0;
            idusuario = 1; //Convert.ToInt32(Session["codUser"]);

            medico = blMedico.GetMedicoxId(idusuario);
            lblEspecialidad.Text = medico.especialidad.descripcion.ToString();
            lblSede.Text = medico.sede.descripcion.ToString();
            lblMedico.Text = medico.persona.nombres + " " + medico.persona.apellidopaterno + " " + medico.persona.apellidomaterno;
            Session["especialidad"] = medico.especialidad.identificador;
            Session["sede"] = medico.sede.identificador;
            Session["medico"] = medico.id;
            lblFecha.Text = DateTime.Today.ToString("dd-MM-yyyy");
            LlenarHoras();
            LlenarPrestaciones();
        }
        public void LlenarHoras()
        {
            DateTime Fecha = DateTime.Now;
            string hora = "";
            ddlHora.Items.Clear();
            ddlHora.Items.Insert(0, new ListItem("--Seleccione--"));
            double ac = 0.5;
            int puntero = 1;
            string diaactual = Fecha.DayOfWeek.ToString();
            string dianuevo = Fecha.DayOfWeek.ToString();


            while (diaactual == dianuevo)
            {
                hora = Fecha.AddHours(ac).Hour.ToString() + ":" + Fecha.AddHours(ac).Minute.ToString().PadLeft(2, '0');
                ddlHora.Items.Insert(puntero, new ListItem(hora));
                ac = ac + 0.5;
                puntero++;
                dianuevo = Fecha.AddHours(ac).DayOfWeek.ToString();
            }


        }


        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            BECitaAdicional citaadicional = new BECitaAdicional();
            citaadicional.cita = new BECita();
            citaadicional.cita.paciente = new BEPaciente();
            citaadicional.cita.medico = new BEMedico();
            citaadicional.especialidad = new BELista();
            citaadicional.prestacion = new BELista();
            citaadicional.sede = new BELista();
 
            BLCitaAdicional blReserva = new BLCitaAdicional();
            lblMensaje.Text = "";
            if (txtPacienteDNI.Text == String.Empty || txtPacienteDNI.Text.Length != 8 )
            {

                lblMensaje.Text = "Ingrese un número de DNI valido";
            
            }
            else
            {
                citaadicional.cita.paciente.codigo = Convert.ToInt32(txtPacienteDNI.Text); 
                citaadicional.sede.identificador = Convert.ToInt32(Session["sede"]);
                citaadicional.cita.medico.id = Convert.ToInt32(Session["medico"]);
                citaadicional.especialidad.identificador = Convert.ToInt32(Session["especialidad"]);
                citaadicional.cita.fecha = Convert.ToDateTime(lblFecha.Text) ;
                citaadicional.descripcion = txtDescripcion.Text;
                string sel = ddlHora.SelectedValue.ToString();
                if (ddlHora.SelectedItem.Text != "--Seleccione--")
                {
                    if (ddlPrestación.SelectedIndex != 0)
                    {
                        citaadicional.cita.hora = TimeSpan.Parse(ddlHora.SelectedItem.Text);
                        
                        citaadicional.prestacion.identificador = Convert.ToInt32(ddlPrestación.SelectedValue);

                        string[] resultado = new string[2];

                        lblMensaje.Text = "";
                        resultado = blReserva.Graba_CitaAdicional(citaadicional);

                        if (resultado[0] != "000")
                        {
                            lblMensaje.Text = resultado[0] + " - " + resultado[1];
                        }
                        else
                        {
                            lblMensaje.Text = resultado[1];


                        }
                    }
                    else
                    {
                        lblMensaje.Text = "Elija una prestación";
                    }
                }
                else
                {
                    lblMensaje.Text = "Elija una Hora";
                }
            }
        }


    }
}