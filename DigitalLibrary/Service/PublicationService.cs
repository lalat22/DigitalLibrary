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
    public class PublicationService
    {
        string ConnectionString = string.Empty;
        private SqlCommand _sqlCommand;
        private SqlDataAdapter _sqlDataAdapter;
        private DataSet _dtSet;

        public PublicationService()
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
        #region GetAllPublication
        public List<PublicationModel> GetAllPublication()
        {
            List<PublicationModel> lstPublication = null;
            PublicationModel obj = null;
            try
            {
                CreateConnection();
                OpenConnection();
                _sqlCommand.CommandText = "PUBLICATION_SELECT";
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
                _dtSet = new DataSet();
                _sqlDataAdapter.Fill(_dtSet);
                DataTable dt = new DataTable();
                dt = _dtSet.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    lstPublication = new List<PublicationModel>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        obj = new PublicationModel();
                        obj.PublicationId = Convert.ToInt32(dt.Rows[i]["PublicationId"]);
                        obj.PublicationName = dt.Rows[i]["PublicationName"].ToString();

                        lstPublication.Add(obj);
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
            return lstPublication;
        }
        #endregion

        #region InsertPublication
        public int InsertPublication(string PublicationName)
        {
            int i = 0;
            try
            {
                CreateConnection();
                OpenConnection();
                _sqlCommand.CommandText = "PUBLICATION_INSERT";
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.AddWithValue("@PublicationName", PublicationName);
                i = Convert.ToInt32(_sqlCommand.ExecuteNonQuery());
            }
            catch (Exception ex)
            {

            }
            return i;
        }

        #endregion

        #region DeletePublication
        public int DeletePublicationById(int PublicationId)
        {
            int i = 0;
            try
            {
                CreateConnection();
                OpenConnection();
                _sqlCommand.CommandText = "PUBLICATION_DELETE";
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.AddWithValue("@PublicationId", PublicationId);
                i = Convert.ToInt32(_sqlCommand.ExecuteNonQuery());
            }
            catch (Exception ex)
            {

            }
            return i;
        }
        #endregion

        #region GetPublicationById
        public PublicationModel GetPublicationById(int PublicationId)
        {
            PublicationModel objPublicationModel = null;
            try
            {
                CreateConnection();
                OpenConnection();
                _sqlCommand.CommandText = "PUBLICATION_SELECT_BY_PID";
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.AddWithValue("@PublicationId", PublicationId);

                _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
                _dtSet = new DataSet();
                _sqlDataAdapter.Fill(_dtSet);
                if ((_dtSet != null) && (_dtSet.Tables[0].Rows.Count > 0))
                {
                    objPublicationModel = new PublicationModel();
                    objPublicationModel.PublicationName = _dtSet.Tables[0].Rows[0]["PublicationName"].ToString();
                    objPublicationModel.PublicationId = Convert.ToInt32(_dtSet.Tables[0].Rows[0]["PublicationId"].ToString());

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return objPublicationModel;
        }
        #endregion

        #region UpdatePublication
        public int UpdatePublication(PublicationModel publicationModel)
        {
            int i = 0;
            try
            {
                CreateConnection();
                OpenConnection();
                _sqlCommand.CommandText = "PUBLICATION_UPDATE";
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.AddWithValue("@PublicationName", publicationModel.PublicationName);
                _sqlCommand.Parameters.AddWithValue("@PublicationId", publicationModel.PublicationId);
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