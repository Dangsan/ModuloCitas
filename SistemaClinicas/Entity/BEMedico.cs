using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Serializable]
    public class BEMedico
    {
        public int id { get; set; }
        public BEPersona persona { get; set; }
        public string colegiatura { get; set; }
        public BELista especialidad { get; set; }

        public BEMedico()
        {

        }
    }
}
