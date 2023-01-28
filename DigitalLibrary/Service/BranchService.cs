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
    public class BranchService
    {
        string ConnectionString = string.Empty;
        private SqlCommand _sqlCommand;
        private SqlDataAdapter _sqlDataAdapter;
        private DataSet _dtSet;

        public BranchService()
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

        #region GetAllBranch
        public List<BranchModel> GetAllBranch()
        {
            List<BranchModel> lstBranch = null;
            BranchModel branchModel = null;
            try
            {
                CreateConnection();
                OpenConnection();
                _sqlCommand.CommandText = "[dbo].[BRANCH_SELECT]";
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
                _dtSet = new DataSet();
                _sqlDataAdapter.Fill(_dtSet);
                DataTable dt = new DataTable();
                dt = _dtSet.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    lstBranch = new List<BranchModel>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        BranchModel obj  = new BranchModel();
                        obj.BranchId = Convert.ToInt32(dt.Rows[i]["BranchId"]);
                        obj.BranchName = dt.Rows[i]["BranchName"].ToString();

                        lstBranch.Add(obj);
                    }
                }

            }
            catch (Exception ex)
            {


            }
            finally
            {
                CloseConnection();
                DisposeConnection();
                branchModel = null;
            }
            return lstBranch;
        }
        #endregion

        #region GetBranchById
        public BranchModel GetBranchById(int branchId)
        {
            BranchModel objBranchModel = null;
            try
            {
                CreateConnection();
                OpenConnection();
                _sqlCommand.CommandText = "BRANCH_SELECT_BY_BID";
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.AddWithValue("@BranchId", branchId);

                _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
                _dtSet = new DataSet();
                _sqlDataAdapter.Fill(_dtSet);
                if ((_dtSet != null) && (_dtSet.Tables[0].Rows.Count > 0))
                {
                    objBranchModel = new BranchModel();
                    objBranchModel.BranchName = _dtSet.Tables[0].Rows[0]["BranchName"].ToString();
                    objBranchModel.BranchId = Convert.ToInt32(_dtSet.Tables[0].Rows[0]["BranchId"].ToString());

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return objBranchModel;
        }
        #endregion

        #region InsertBranch
        public int InsertBranch(string branchName)
        {
            int i = 0;
            try
            {
                CreateConnection();
                OpenConnection();
                _sqlCommand.CommandText = "BRANCH_INSERT";
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.AddWithValue("@BranchName", branchName);
                i = Convert.ToInt32(_sqlCommand.ExecuteNonQuery());
            }
            catch (Exception ex)
            {

            }
            return i;
        }

        #endregion

        #region DeleteBranch
        public int DeleteBranchById(int branchId)
        {
            int i = 0;
            try
            {
                CreateConnection();
                OpenConnection();
                _sqlCommand.CommandText = "BRANCH_DELETE";
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.AddWithValue("@BranchId", branchId);
                i = Convert.ToInt32(_sqlCommand.ExecuteNonQuery());
            }
            catch (Exception ex)
            {

            }
            return i;
        }
        #endregion
    }
}