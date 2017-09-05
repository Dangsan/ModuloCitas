using DAO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class BLLista : Exceptions
    {
        DAMaestro lista = new DAMaestro();

        public List<BELista> GetListaxId(int id)
        {
            return lista.GetPrestaciones(id);

        }

    }
}
