using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Serializable]
    public class BEPersona
    {
        public int codigo { get; set; } 
        public string nombres { get; set; }
        public string apellidopaterno { get; set; }
        public string apellidomaterno { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string tipo_documento { get; set; }
        public string num_documento { get; set; }
        public string telefono { get; set; }

        public BEPersona()
        {
            codigo = 0;
            nombres = "";
            apellidopaterno = "";
            apellidomaterno = "";
            fecha_nacimiento = DateTime.Now;
            tipo_documento = "";
            num_documento = "";
            telefono = "";


        }
    }
}
