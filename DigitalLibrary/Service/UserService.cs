using DigitalLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DigitalLibrary.Service
{
    public class UserService
    {
        string ConnectionString = string.Empty;
        private SqlCommand _sqlCommand;
        private SqlDataAdapter _sqlDataAdapter;
        private DataSet _dtSet;

        public UserService()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["myDbConnection"].ConnectionString;
        }
        public void CreateConnection()
        {
            SqlConnection _sqlConnection = new SqlConnection(ConnectionString);
            _sqlCommand = new SqlCommand();
            _sqlCommand.Connection = _sqlConnection;
        }
        public void OpenConnection()
        {
            _sqlCommand.Connection.Open();
        }
        public void CloseConnection()
        {
            _sqlCommand.Connection.Close();
        }
        public void DisposeConnection()
        {
            _sqlCommand.Connection.Dispose();
        }

        #region DoValidate
        public UserData DoValidate(UserData.UserLogs userLogs)
        {
            UserData userData = null;
            try
            {
                CreateConnection();
                OpenConnection();
                _sqlCommand.CommandText = "GetUserData";
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.AddWithValue("@UserName", userLogs.UserName);
                _sqlCommand.Parameters.AddWithValue("@Password", userLogs.Password);
                _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
                _dtSet = new DataSet();
                _sqlDataAdapter.Fill(_dtSet);
                
                DataTable dt = new DataTable();
               if((_dtSet != null) && (_dtSet.Tables[0].Rows.Count > 0))
                {
                    userData = new UserData();
                    userData.FirstName = _dtSet.Tables[0].Rows[0]["FirstName"].ToString();
                    userData.LastName = _dtSet.Tables[0].Rows[0]["FirstName"].ToString();
                    userData.RoleId = Convert.ToInt32(_dtSet.Tables[0].Rows[0]["RoleId"].ToString());
                    userData.Email = _dtSet.Tables[0].Rows[0]["Email"].ToString();
                }

            }
            catch (Exception ex)
            {
                
                
            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }
            return userData;
        }
        #endregion

        #region CheckRestictedIPAddress
        public bool CheckRestictedIPAddress(string ipAddress)
        {
            bool isRestricted = true;
            try
            {
                CreateConnection();
                OpenConnection();
                _sqlCommand.CommandText = "CheckRestictedIPAddress";
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.AddWithValue("@IPAddress", ipAddress);

                SqlParameter outputPara = new SqlParameter();
                outputPara.ParameterName = "@IsRestrictedIP";
                outputPara.Direction = System.Data.ParameterDirection.Output;
                outputPara.SqlDbType = System.Data.SqlDbType.Bit;
                _sqlCommand.Parameters.Add(outputPara);

                _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
                _dtSet = new DataSet();
                _sqlDataAdapter.Fill(_dtSet);

                DataTable dt = new DataTable();
                isRestricted = Convert.ToBoolean(outputPara.Value);

            }
            catch (Exception ex)
            {


            }
            finally
            {
                CloseConnection();
                DisposeConnection();
            }

            return isRestricted;
        }
        #endregion

    }
}