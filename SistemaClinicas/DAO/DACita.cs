using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{

    public class DACita : SqlHelper
    {

        public string[] Graba_CitaAdicional(BECitaAdicional cita)
        {
            string[] resultado = new string[2];

            try
            {
                return GrabarCitaAdicional(cita);
            }
            catch (Exception ex)
            {
                resultado[0] = "001";
                resultado[1] = ex.Message;
                return resultado;
            }
        }

        public string[] GrabarCitaAdicional(BECitaAdicional citaadic)
        {
            SqlCommand cmd = new SqlCommand("dbo.registrar_cita_adicional");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@fecha", SqlDbType.Date, 14).Value = citaadic.cita.fecha;
            cmd.Parameters.Add("@hora", SqlDbType.Time, 14).Value = citaadic.cita.hora;
            cmd.Parameters.Add("@paciente", SqlDbType.Int, 14).Value = citaadic.cita.paciente.codigo;
            cmd.Parameters.Add("@profesional", SqlDbType.Int, 14).Value = citaadic.cita.medico.id;
            cmd.Parameters.Add("@ambiente", SqlDbType.Int, 14).Value = citaadic.sede.identificador;
            cmd.Parameters.Add("@especialidad", SqlDbType.Int, 14).Value = citaadic.especialidad.identificador;
            cmd.Parameters.Add("@prestacion", SqlDbType.Int, 14).Value = citaadic.prestacion.identificador;
            cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = citaadic.descripcion;
            SqlParameter codRetorno = new SqlParameter("@as_coderror", SqlDbType.Char, 5);
            codRetorno.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(codRetorno);

            SqlParameter desRetorno = new SqlParameter("@as_dscerror", SqlDbType.VarChar, 250);
            desRetorno.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(desRetorno);


            string[] resultado = new string[2];

            try
            {


              //  cmd.ExecuteNonQuery();
               InsertCommand(cmd, true, 1);

                resultado[0] = cmd.Parameters["@as_coderror"].Value.ToString();
                resultado[1] = cmd.Parameters["@as_dscerror"].Value.ToString();
                resultado[0] = resultado[0].Trim();

                /* if (resultado[0] != "000")
                 {
                     objTr.Rollback();
                 }
                 else
                 {
                     objTr.Commit();
                 }*/

            }
            catch (Exception ex)
            {
                resultado[0] = "001";
                resultado[1] = ex.Message;
            }
            finally
            {

            }

            return resultado;
        }

    }
}
