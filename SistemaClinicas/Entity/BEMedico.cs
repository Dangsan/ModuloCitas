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
        public BELista sede { get; set; }

        public BEMedico()
        {
            id = 0;
            colegiatura = "";
            BELista especialidad = new BELista();
            BELista sede = new BELista();
            BEPersona persona = new BEPersona();
        }
    }
}
