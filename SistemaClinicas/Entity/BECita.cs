using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Serializable]
    public class BECita
    {
        public int id { get; set; }
        public BEPaciente paciente { get; set; }
        public BEMedico medico { get; set; }
        public DateTime fecha { get; set; }
        public TimeSpan hora { get; set; }
        public int estado { get; set; }



        public BECita()
        {

        }
    }
}
