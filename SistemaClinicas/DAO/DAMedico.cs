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
    public class DAMedico: SqlHelper
    {
        public BEMedico GetMedicoxId(int id)
        {

            BEMedico result = new BEMedico();
            result.persona = new BEPersona();
            result.especialidad = new BELista();
            result.sede = new BELista();


            SqlCommand cmd = new SqlCommand("dbo.spu_get_datos_medico");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int, 150).Value = id;
            
            SqlDataReader reader = ExecuteReader(cmd, 1);
            while (reader.Read())
            {
                result.id = ((!reader[0].Equals(DBNull.Value)) ? reader.GetInt32(0) : -1);
                result.persona.codigo = ((!reader[1].Equals(DBNull.Value)) ? reader.GetInt32(1) : -1);
                result.colegiatura = ((!reader[2].Equals(DBNull.Value)) ? reader.GetString(2) : "-");
                result.persona.nombres = ((!reader[3].Equals(DBNull.Value)) ? reader.GetString(3) : "-");
                result.persona.apellidopaterno = ((!reader[4].Equals(DBNull.Value)) ? reader.GetString(4) : "-");
                result.persona.apellidomaterno = ((!reader[5].Equals(DBNull.Value)) ? reader.GetString(5) : "-");
                result.persona.fecha_nacimiento = reader.GetDateTime(6);
                result.persona.tipo_documento = ((!reader[7].Equals(DBNull.Value)) ? reader.GetString(7) : "-");
                result.persona.num_documento = ((!reader[8].Equals(DBNull.Value)) ? reader.GetString(8) : "-");
                result.persona.telefono = ((!reader[9].Equals(DBNull.Value)) ? reader.GetString(9) : "-");
                result.especialidad.identificador = ((!reader[10].Equals(DBNull.Value)) ? reader.GetInt32(10) : -1);
                result.especialidad.descripcion = ((!reader[11].Equals(DBNull.Value)) ? reader.GetString(11) : "-");
                result.sede.identificador = ((!reader[12].Equals(DBNull.Value)) ? reader.GetInt32(12) : -1);
                result.sede.descripcion = ((!reader[13].Equals(DBNull.Value)) ? reader.GetString(13) : "-");

            }
            return result;
        }

    }
}
