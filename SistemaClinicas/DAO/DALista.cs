﻿using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DALista : SqlHelper
    {
        public List<BELista> GetPrestaciones(int id)
        {
            BELista result = new BELista();
            List <BELista> results = new List <BELista>() ;

            SqlCommand cmd = new SqlCommand("dbo.get_prestaciones_especialidad");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idespecialidad", SqlDbType.Int, 14).Value = id;

            SqlDataReader reader = ExecuteReader(cmd, 1);
            while (reader.Read())
            {
                result.identificador = ((!reader[0].Equals(DBNull.Value)) ? reader.GetInt32(0) : -1);
                result.tipo = ((!reader[1].Equals(DBNull.Value)) ? reader.GetInt32(1) : -1);
                result.descripcion = ((!reader[2].Equals(DBNull.Value)) ? reader.GetString(2) : "-");
                results.Add(result);
            }
            return results;
        }

     





    }
}
