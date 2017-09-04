using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Serializable]
    public class BECitaAdicional
    {
        public int id { get; set; }
        public BECita cita { get; set; }
        public BELista especialidad { get; set; }
        public BELista sede { get; set; }
        public BELista prestacion { get; set; }
        public string descripcion { get; set; }

        public BECitaAdicional()
        {
           

        }
    }
}
