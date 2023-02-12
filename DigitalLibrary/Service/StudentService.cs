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
    public class StudentService
    {
        string ConnectionString = string.Empty;
        private SqlCommand _sqlCommand;
        private SqlDataAdapter _sqlDataAdapter;
        private DataSet _dtSet;

        public StudentService()
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
                        BranchModel obj = new BranchModel();
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

            }
            return lstBranch;
        }
        #endregion


        #region GetAllStudents
        public List<StudentModel> GetAllStudents()
        {
            List<StudentModel> lstStudentModel1 = null;
            StudentModel studentModel1 = null;
            try
            {
                CreateConnection();
                OpenConnection();
                _sqlCommand.CommandText = "[dbo].[STUDENT_SELECT]";
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
                _dtSet = new DataSet();
                _sqlDataAdapter.Fill(_dtSet);
                DataTable dt = new DataTable();
                dt = _dtSet.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    lstStudentModel1 = new List<StudentModel>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        StudentModel obj = new StudentModel();
                        obj.StudentId = Convert.ToInt32(dt.Rows[i]["StudentId"]);
                        obj.StudentName = dt.Rows[i]["StudentName"].ToString();
                        obj.BranchName = dt.Rows[i]["BranchName"].ToString();
                        obj.Mobile = dt.Rows[i]["Mobile"].ToString();

                        lstStudentModel1.Add(obj);
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
                studentModel1 = null;
            }
            return lstStudentModel1;
        }
        #endregion

        #region GetBookDetailsById
        public StudentModel GetStudentsDetailsById(int studentId)
        {
            StudentModel studentModel1 = null;
            try
            {
                CreateConnection();
                OpenConnection();
                _sqlCommand.CommandText = "STUDENT_SELECT_BY_SID";
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.AddWithValue("@StudentId", studentId);

                _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
                _dtSet = new DataSet();
                _sqlDataAdapter.Fill(_dtSet);
                if ((_dtSet != null) && (_dtSet.Tables[0].Rows.Count > 0))
                {
                    studentModel1 = new StudentModel();
                    studentModel1.StudentName = _dtSet.Tables[0].Rows[0]["StudentName"].ToString();
                    studentModel1.StudentId = Convert.ToInt32(_dtSet.Tables[0].Rows[0]["StudentId"].ToString());
                    studentModel1.Mobile = _dtSet.Tables[0].Rows[0]["Mobile"].ToString();
                    studentModel1.PinCode = _dtSet.Tables[0].Rows[0]["PinCode"].ToString();
                    studentModel1.BranchName = _dtSet.Tables[0].Rows[0]["BranchName"].ToString();
                    studentModel1.Address = _dtSet.Tables[0].Rows[0]["Address"].ToString();
                    studentModel1.DOB = Convert.ToDateTime(_dtSet.Tables[0].Rows[0]["DOB"].ToString());
                    studentModel1.Email = _dtSet.Tables[0].Rows[0]["Email"].ToString();
                    studentModel1.Images = _dtSet.Tables[0].Rows[0]["Images"].ToString();
                    studentModel1.Gender = _dtSet.Tables[0].Rows[0]["Gender"].ToString();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return studentModel1;
        }
        #endregion

        #region InsertStudent
        public int InsertStudent(StudentModel studentModel)
        {
            int i = 0;
            try
            {
                CreateConnection();
                OpenConnection();
                _sqlCommand.CommandText = "STUDENT_INSERT";
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.AddWithValue("@StudentName", studentModel.StudentName);
                _sqlCommand.Parameters.AddWithValue("@BranchName", studentModel.BranchName);
                _sqlCommand.Parameters.AddWithValue("@Mobile", studentModel.Mobile);
                _sqlCommand.Parameters.AddWithValue("@Address", studentModel.Address);
                _sqlCommand.Parameters.AddWithValue("@PinCode", studentModel.PinCode);
                _sqlCommand.Parameters.AddWithValue("@DOB", studentModel.DOB);
                _sqlCommand.Parameters.AddWithValue("@Gender", studentModel.Gender);
                _sqlCommand.Parameters.AddWithValue("@Email", studentModel.Email);
                _sqlCommand.Parameters.AddWithValue("@Images", studentModel.Images);
                i = Convert.ToInt32(_sqlCommand.ExecuteNonQuery());
            }
            catch (Exception ex)
            {

            }
            return i;
        }

        #endregion

        #region DeleteStudent()
        public int DeleteStudentById(int studentId)
        {
            int i = 0;
            try
            {
                CreateConnection();
                OpenConnection();
                _sqlCommand.CommandText = "STUDENT_DELETE";
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.AddWithValue("@StudentId", studentId);
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