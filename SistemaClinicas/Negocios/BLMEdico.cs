using DAO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class BLMEdico : Exceptions
    {
        DAMedico medicoDAO = new DAMedico();

        public BEMedico GetMedicoxId(int id)
        {
            return medicoDAO.GetMedicoxId(id);
        }
    }
}
