using DAO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class BLCitaAdicional : Exceptions
    {
        DACita dacita = new DACita();


        public string[] Graba_CitaAdicional(BECitaAdicional cita)
        {

            return dacita.Graba_CitaAdicional(cita);
        }
    }
}
