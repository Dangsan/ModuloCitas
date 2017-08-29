using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Serializable]
    public class BEPaciente
    {
        public int codigo { get; set; }
        public BEPersona persona { get; set; }
        public int codtipo { get; set; }
        public BEPaciente()
        {

        }
    }
}
