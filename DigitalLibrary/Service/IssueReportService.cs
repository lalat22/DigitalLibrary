using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using DigitalLibrary.Models;

namespace DigitalLibrary.Service
{
    public class IssueReportService
    {
        string ConnectionString = string.Empty;
        private SqlCommand _sqlCommand;
        private SqlDataAdapter _sqlDataAdapter;
        private DataSet _dtSet;

        public IssueReportService()
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

        #region GetIssuedBookCountbyStudent
        public List<IssueBookModel> GetIssuedBookCountbyStudent(int studentId)
        {
            List<IssueBookModel> lstIssueBookModel = null;
            IssueBookModel obj = null;
            try
            {
                CreateConnection();
                OpenConnection();
                _sqlCommand.CommandText = "GetIssuedBookCountbyStudent";
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.AddWithValue("@StudentId", studentId);
                _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
                _dtSet = new DataSet();
                _sqlDataAdapter.Fill(_dtSet);
                DataTable dt = new DataTable();
                dt = _dtSet.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    lstIssueBookModel = new List<IssueBookModel>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        obj = new IssueBookModel();
                        obj.StudentId = Convert.ToInt32(dt.Rows[i]["StudentId"]);
                        obj.BookName = dt.Rows[i]["BookName"].ToString();
                        obj.IssueDate = Convert.ToDateTime( dt.Rows[i]["IssueDate"].ToString());
                        obj.Days = Convert.ToInt32(dt.Rows[i]["Days"]);
                        lstIssueBookModel.Add(obj);
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
                obj = null;
            }
            return lstIssueBookModel;
        }
        #endregion
    }
}