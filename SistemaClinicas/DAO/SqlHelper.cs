using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;
using System.Threading.Tasks;

namespace DAO
{
    public class SqlHelper : Conexion
    {
        
            int _lastID = 0; long _lastBigID = 0; string _lastCod = "";

            public SqlHelper()
            {
                //
                // TODO: agregar aquí la lógica del constructor
                //
            }
            public int InsertCommand(SqlCommand cmd, bool retID,int tipo_valor)
            {
                int nErr = 0;
                SqlConnection conn = OpenDB(tipo_valor);
                cmd.Connection = conn;
                SqlParameter pReturn = new SqlParameter("@IdNew", SqlDbType.Int);
                pReturn.Direction = ParameterDirection.ReturnValue;

                if (retID)
                    cmd.Parameters.Add(pReturn);

                try
                {
                    conn.Open();
                    cmd.Prepare();
                    if (cmd.ExecuteNonQuery() == 0)
                        nErr = 101;
                    else if (retID)
                        lastID = Convert.ToInt32(pReturn.Value);
                }
                catch (SqlException ex)
                {
                    nErr = ex.Number;
                    System.Web.HttpContext.Current.Trace.Warn(ex.Message + " (Error:" + ex.Number.ToString() + ")");
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
                return nErr;
            }

            public int UpdateCommand(SqlCommand cmd, int tipo_valor)
            {
                int nErr = 0;
                SqlConnection conn = OpenDB(tipo_valor);
                cmd.Connection = conn;

                try
                {
                    conn.Open();
                    cmd.Prepare();
                    if (cmd.ExecuteNonQuery() == 0) nErr = 102;
                }
                catch (SqlException ex)
                {
                    nErr = ex.Number;
                    System.Web.HttpContext.Current.Trace.Warn(ex.Message + " (Error:" + ex.Number.ToString() + ")");
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }

                return nErr;
            }

            public int DeleteCommand(SqlCommand cmd, int tipo_valor)
            {
                int nErr = 0;
                SqlConnection conn = OpenDB(tipo_valor);
                cmd.Connection = conn;

                try
                {
                    conn.Open();
                    cmd.Prepare();
                    if (cmd.ExecuteNonQuery() == 0) nErr = 103;
                }
                catch (SqlException ex)
                {
                    nErr = ex.Number;
                    System.Web.HttpContext.Current.Trace.Warn(ex.Message + " (Error:" + ex.Number.ToString() + ")");
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }

                return nErr;
            }


            public SqlDataReader ExecuteReader(SqlCommand cmd,int tipo_valor)
            {
                SqlConnection conn = OpenDB(tipo_valor);
                SqlDataReader rdr = null;

                try
                {
                    conn.Open();
                    cmd.Connection = conn;
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    cmd.Parameters.Clear();
                }
                catch (SqlException e)
                {
                    System.Web.HttpContext.Current.Trace.Write(e.Message);
                    conn.Close();
                }
                finally
                {
                    cmd.Dispose();
                }

                return rdr;
            }

            public int getLastID
            {
                get
                {
                    return _lastID;
                }
            }

            internal int lastID
            {
                set
                {
                    _lastID = value;
                }
            }

            public long getLastBigID
            {
                get
                {
                    return _lastBigID;
                }
            }

            internal long lastBigID
            {
                set
                {
                    _lastBigID = value;
                }
            }

            public string getLastCod
            {
                get
                {
                    return _lastCod;
                }
            }

            public DateTime DefaultDateTime
            {
                get
                {
                    return DateTime.Parse(SqlDateTime.MinValue.ToString());
                }
            }

            internal string lastCod
            {
                set
                {
                    _lastCod = value;
                }
            }
        }
    }
