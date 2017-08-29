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

            SqlCommand cmd = new SqlCommand("dbo.uspGetMedicoxID");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int, 150).Value = id;
            
            SqlDataReader reader = ExecuteReader(cmd, 1);
            while (reader.Read())
            {
                result.id = ((!reader[0].Equals(DBNull.Value)) ? reader.GetInt32(0) : -1);
                result.colegiatura = ((!reader[1].Equals(DBNull.Value)) ? reader.GetString(1) : "-");
                result.persona.nombres = ((!reader[2].Equals(DBNull.Value)) ? reader.GetString(2) : "-");
                result.persona.apellidopaterno = ((!reader[3].Equals(DBNull.Value)) ? reader.GetString(3) : "-");
                result.persona.apellidomaterno = ((!reader[4].Equals(DBNull.Value)) ? reader.GetString(4) : "-");
                result.persona.fecha_nacimiento = reader.GetDateTime(4);
                result.persona.tipo_documento = ((!reader[5].Equals(DBNull.Value)) ? reader.GetString(5) : "-");
                result.persona.num_documento = ((!reader[6].Equals(DBNull.Value)) ? reader.GetString(6) : "-");
                result.persona.telefono = ((!reader[7].Equals(DBNull.Value)) ? reader.GetString(7) : "-");
                result.especialidad.identificador = ((!reader[8].Equals(DBNull.Value)) ? reader.GetInt32(8) : -1);
                result.especialidad.descripcion = ((!reader[9].Equals(DBNull.Value)) ? reader.GetString(9) : "-");
            }
            return result;
        }
    }
}
