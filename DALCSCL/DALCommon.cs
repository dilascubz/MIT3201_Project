using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DALCSCL
{
    class DALCommon
    {
        internal SqlConnection conSQL = new SqlConnection();
        public SqlTransaction sqlTxn;
        private SqlTransaction TransNew;

        public SqlCommand cmd = new SqlCommand();
        public SqlDataAdapter sda;
        public SqlDataReader sdr;
        public DataSet ds = new DataSet();
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["StakeHolderManagmentConnectionString"].ToString());

        public Boolean ConnectToDB()
        {
            if (conSQL.ConnectionString == "")
            {
                conSQL.ConnectionString = ConfigurationManager.ConnectionStrings["StakeHolderManagmentConnectionString"].ConnectionString;

            }

            if (conSQL.State == ConnectionState.Closed)
            {
                conSQL.Open();
            }

            return true;
        }

        public DataSet ReturnDataSet(String strSqlCommand)
        {
            SqlCommand cmdSql = default(SqlCommand);
            SqlDataAdapter daCommen = new SqlDataAdapter();
            DataSet dsCommen = new DataSet();

            //---Open the connection before execute the quries---
            ConnectToDB();

            cmdSql = new SqlCommand(strSqlCommand, conSQL);
            daCommen.SelectCommand = cmdSql;

            //---Set the transaction property of the SQL Command---
            cmdSql.Transaction = sqlTxn;

            daCommen.Fill(dsCommen, "MyDataTable");

            //---Close the connection once executed the queries---
            DisconnectFromDB();

            return dsCommen;
        }

        public void DisconnectFromDB()
        {
            //---Open the connection, if the state of the connection is closed---
            if (conSQL.State == ConnectionState.Open)
            {
                //---Do not close the connection unless the conection does not have any active transaction block---
                if (sqlTxn == null)
                {
                    conSQL.Close();
                }
            }
        }

        public int ExecuteProcedure(string CommandText, CommandType CommandType, SqlParameter[] Parameters = null)
        {
            SqlCommand sqlComm = default(SqlCommand);
            int res = 0;

            //---Open the connection before execute the procedure---
            ConnectToDB();

            sqlComm = new SqlCommand(CommandText, conSQL);
            sqlComm.CommandType = CommandType;

            //---Set the transaction property of the SQL Command---
            sqlComm.Transaction = sqlTxn;

            if ((Parameters != null))
            {
                for (int i = 0; i <= Parameters.Length - 1; i++)
                {
                    if (Parameters[i].Value == null)
                    {
                        Parameters[i].Value = DBNull.Value;
                        sqlComm.Parameters.Add(Parameters[i]);
                    }
                    else
                    {
                        sqlComm.Parameters.Add(Parameters[i]);
                    }
                }
            }

            res = sqlComm.ExecuteNonQuery();

            //---Close the connection after executing the procedure---
            DisconnectFromDB();

            return res;
        }

        public void BeginTransaction()
        {
            ConnectToDB();
            sqlTxn = conSQL.BeginTransaction();
        }

        public void RollbackTransaction()
        {
            if (sqlTxn.Connection != null)
            {
                sqlTxn.Rollback();
            }
        }

        public void CommitTransaction()
        {
            if (sqlTxn.Connection != null)
            {
                sqlTxn.Commit();
            }
            sqlTxn = null;
            DisconnectFromDB();
        }

        public string GetServername()
        {
            return conSQL.DataSource.ToString();
        }

        public void BeginTransactionTrans(SqlTransaction Trans = null)
        {
            ConnectToDB();
            TransNew = conSQL.BeginTransaction();
        }

        public void CommitTransactionTrans(SqlTransaction Trans = null)
        {
            if ((TransNew.Connection != null))
            {
                TransNew.Commit();
            }

            //---Set the connection of the transaction to null, after committing the transaction---
            TransNew = null;

            DisconnectFromDBTrans();
        }

        public void DisconnectFromDBTrans()
        {
            //---Open the connection, if the state of the connection is closed---
            if (conSQL.State == ConnectionState.Open)
            {
                //---Do not close the connection unless the conection does not have any active transaction block---
                if (TransNew == null)
                {
                    conSQL.Close();
                }
            }
        }

        public void RollbackTransactionTrans(SqlTransaction Trans = null)
        {
            if ((TransNew.Connection != null))
            {
                TransNew.Rollback();
            }

            //---Set the connection of the transaction to null, after rolling back the transaction---
            TransNew = null;

            DisconnectFromDBTrans();
        }

        public int ExecuteProcedureWithTransaction(string CommandText, CommandType CommandType, SqlParameter[] Parameters = null, SqlTransaction Trans = null)
        {
            SqlCommand sqlComm = default(SqlCommand);
            int res = 0;

            //---Open the connection before execute the procedure---
            ConnectToDB();

            sqlComm = new SqlCommand(CommandText, conSQL);
            sqlComm.CommandType = CommandType;

            //---Set the transaction property of the SQL Command---
            sqlComm.Transaction = Trans;

            if ((Parameters != null))
            {
                for (int i = 0; i <= Parameters.Length - 1; i++)
                {
                    if (Parameters[i].Value == null)
                    {
                        Parameters[i].Value = DBNull.Value;
                        sqlComm.Parameters.Add(Parameters[i]);
                    }
                    else
                    {
                        sqlComm.Parameters.Add(Parameters[i]);
                    }
                }
            }

            res = sqlComm.ExecuteNonQuery();

            //---Close the connection after executing the procedure---
            DisconnectFromDB();

            return res;
        }

        public DataSet ExecuteProcedure_select(string CommandText, SqlParameter[] Parameters = null)
        {
            DataSet res = new DataSet();
            SqlCommand sqlComm = default(SqlCommand);

            //---Open the connection before execute the procedure---
            ConnectToDB();

            sqlComm = new SqlCommand(CommandText, conSQL);
            sqlComm.CommandType = CommandType.StoredProcedure;

            //---Set the transaction property of the SQL Command---
            sqlComm.Transaction = sqlTxn;

            if ((Parameters != null))
            {
                for (int i = 0; i <= Parameters.Length - 1; i++)
                {
                    if (Parameters[i].Value == null)
                    {
                        Parameters[i].Value = DBNull.Value;
                        sqlComm.Parameters.Add(Parameters[i]);
                    }
                    else
                    {
                        sqlComm.Parameters.Add(Parameters[i]);
                    }
                }
            }

            SqlDataAdapter da = new SqlDataAdapter(sqlComm);
            DataSet ds = new DataSet();
            da.Fill(ds);

            //---Close the connection after executing the procedure---
            DisconnectFromDB();

            return ds;
        }




        

        public bool IsExist(string Query)
        {
            bool check = false;
            using (cmd = new SqlCommand(Query, con))
            {
                con.Open();
                sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                    check = true;
            }
            sdr.Close();
            con.Close();
            return check;

        }

        public bool ExecuteQuery(string Query)
        {
            int j = 0;
            using (cmd = new SqlCommand(Query, con))
            {
                con.Open();
                j = cmd.ExecuteNonQuery();
                con.Close();
            }

            if (j > 0)
                return true;
            else
                return false;

        }

        public string GetColumnVal(string Query, string ColumnName)
        {
            string RetVal = "";
            using (cmd = new SqlCommand(Query, con))
            {
                con.Open();
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    RetVal = sdr[ColumnName].ToString();
                    break;
                }
                sdr.Close();
                con.Close();
            }

            return RetVal;
        }





    }
}
