using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public sealed class Conector
    {
        public DataTable EjecutarSP(string spName, System.Collections.Hashtable sqlParametros)
        {
            return this.GetSp(spName, sqlParametros, null, null);
        }
        private DataTable GetSp(string spName, System.Collections.Hashtable sqlParametros, SqlParameter singleParameter, SqlTransaction transaccion)
        {
            var sqlCommand = new SqlCommand(spName);
            var adapter = new SqlDataAdapter();
            var aData = new DataTable();
            sqlCommand.CommandTimeout = 120000;
            if (sqlParametros != null && sqlParametros.Count > 0)
            {
                foreach (System.Collections.DictionaryEntry sqlParametro in sqlParametros)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParametro.Key.ToString(), sqlParametro.Value));
                }
            }
            else if (singleParameter != null)
            {
                sqlCommand.Parameters.Add(singleParameter);
            }
            try
            {
                sqlCommand.Connection = new SqlConnection(DataSource.coneccionPrimaria);
                sqlCommand.Connection.Open();
                if (transaccion != null)
                {
                    sqlCommand.Transaction = transaccion;
                }
                sqlCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand = sqlCommand;

                adapter.Fill(aData);
                return aData;
            }
            catch
            {
                try
                {
                    sqlCommand.Connection = new SqlConnection(DataSource.coneccionPrimaria);
                    sqlCommand.Connection.Open();
                    if (transaccion != null)
                    {
                        sqlCommand.Transaction = transaccion;
                    }
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand = sqlCommand;
                    adapter.Fill(aData);
                    return aData;
                }
                catch (SqlException e)
                {
                    throw (new CapturaExcepciones(e));
                }
                catch (Exception e)
                {
                    throw (new CapturaExcepciones(e));
                }
            }
            finally
            {
                adapter = null;
                aData = null;
                sqlCommand.Connection.Close();
                sqlCommand = null;
            }
        }
    }
}
