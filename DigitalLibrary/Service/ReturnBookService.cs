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
    public class ReturnBookService
    {
        string ConnectionString = string.Empty;
        private SqlCommand _sqlCommand;
        private SqlDataAdapter _sqlDataAdapter;
        private DataSet _dtSet;

        public ReturnBookService()
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

        #region GetReturnBookDetails
        public ReturnBookModel GetReturnBookDetails(int studentId, int bookId)
        {
            ReturnBookModel returnBookModel = null;
            try
            {
                CreateConnection();
                OpenConnection();
                _sqlCommand.CommandText = "GetAllDetailForBookReturn";
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.AddWithValue("@StudentId", studentId);
                _sqlCommand.Parameters.AddWithValue("@BookId", bookId);
                _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
                _dtSet = new DataSet();
                _sqlDataAdapter.Fill(_dtSet);
                if ((_dtSet != null) && (_dtSet.Tables[0].Rows.Count > 0))
                {
                    returnBookModel = new ReturnBookModel();
                    returnBookModel.Author = _dtSet.Tables[0].Rows[0]["Author"].ToString();
                    returnBookModel.Publication = _dtSet.Tables[0].Rows[0]["Publication"].ToString();
                    returnBookModel.Branch = _dtSet.Tables[0].Rows[0]["Branch"].ToString();
                    returnBookModel.Price = Convert.ToDecimal(_dtSet.Tables[0].Rows[0]["Price"].ToString());
                    returnBookModel.StudentName = _dtSet.Tables[0].Rows[0]["StudentName"].ToString();
                    returnBookModel.Days = Convert.ToInt32(_dtSet.Tables[0].Rows[0]["Days"].ToString());
                    returnBookModel.IssueDate = Convert.ToDateTime(_dtSet.Tables[0].Rows[0]["IssueDate"].ToString());
                    returnBookModel.StudentId = Convert.ToInt32(_dtSet.Tables[0].Rows[0]["StudentId"].ToString());
                    returnBookModel.BookId = Convert.ToInt32(_dtSet.Tables[0].Rows[0]["BookId"].ToString());
                    returnBookModel.BookName = _dtSet.Tables[0].Rows[0]["BookName"].ToString();
                    returnBookModel.RentId = Convert.ToInt32(_dtSet.Tables[0].Rows[0]["RentId"].ToString());
                    returnBookModel.Images = _dtSet.Tables[0].Rows[0]["Images"].ToString();
                    // returnBookModel.PnalityStatus = _dtSet.Tables[0].Rows[0]["PnalityStatus"].ToString();

                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return returnBookModel;
        }
        #endregion
    }
}