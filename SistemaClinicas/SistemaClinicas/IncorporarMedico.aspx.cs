using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComprobantesRetencion
{
    public partial class IncorporarMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscarCliente_Click(object sender, EventArgs e)
        {

            GetEstado();

        }

        public void GetEstado()
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            string url = "http://200.48.13.46/cmp/php/detallecmp.php?id=" + txtCMP.Text;
            string webData = wc.DownloadString(url);
            int first = webData.IndexOf("estado");

            string str2 = webData.Substring(first + 49, 1);



            if (str2.Contains("\""))
            {
                lblMensaje.Text = "El CMP ingresado no existe";
                imgMedico.ImageUrl = "";

            }
            else if (str2.Contains("A"))
            {
                lblEstado.Text = "Activo";
                string srcimg = "http://200.48.13.46/cmp/fotos/" + txtCMP.Text.Substring(1, 5) + ".jpg";
                imgMedico.ImageUrl = srcimg;
                GetDatos(webData);
            }
            else
            {
                lblEstado.Text = "Inactivo";
                imgMedico.ImageUrl = "http://200.48.13.46/cmp/fotos/00000.jpg";
                GetDatos(webData);
            }


        }

        public void GetDatos(string webdata)
        {

            int primero = webdata.IndexOf("nombres");
            string str1 = webdata.Substring(primero + 50, 30);
            int segundo = str1.IndexOf("/td") - 3 ;
            string str2 = str1.Substring(0, str1.Length - str1.Length + segundo);
            lblNombres.Text = str2;
            //apPaterno
            primero = webdata.IndexOf("apellidos");
            str1 = webdata.Substring(primero + 52, 30);
            segundo = str1.IndexOf("/td") -3 ;
            str2 = str1.Substring(0, str1.Length - str1.Length + segundo );
            int tercero = str2.IndexOf(" ");
            string str3 = str2.Substring(0, str2.Length - str2.Length + tercero);
            string str4 = str2.Substring(tercero + 1);
            lblApPaterno.Text = str3;
            lblApMaterno.Text = str4;
            string value = "fila_0";

            List<int> indexes = AllIndexesOf(webdata,value);

            lblRNE.Text = webdata.Substring(indexes[1] + 9, indexes[2] - indexes[1] - 32);
            lblEspecialidad.Text = webdata.Substring(indexes[2] + 9, indexes[3] - indexes[2] - 32);
           
        }


        public  List<int> AllIndexesOf(string webdata, string value)
        {

            List<int> indexes = new List<int>();
            for (int index = 0; ; index += value.Length)
            {
                index = webdata.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }

        public void Limpiar() {

            lblRNE.Text = "";
            lblEspecialidad.Text = "";
            lblEstado.Text = "";

        }
    }
}