using CRUDApplication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;

namespace CRUDApplication.Service
{
    public class UserService : IUser
    {
        private  SqlConnection _connection;

        private void GetConnection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            _connection = new SqlConnection(constr);
        }
        public bool AddUser(UserModel user)
        {
            try
            {
                GetConnection();
                SqlCommand com = new SqlCommand("AddNewUser", _connection);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Name", user.Name);
                com.Parameters.AddWithValue("@Email", user.Email);
                com.Parameters.AddWithValue("@Address", user.Address);

                _connection.Open();
                int i = com.ExecuteNonQuery();
                _connection.Close();
                if (i >= 1)
                {

                    return true;

                }
                else
                {

                    return false;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public bool DeleteUser(int Id)
        {
            try
            {
                GetConnection();
                SqlCommand com = new SqlCommand("DeleteUserById", _connection);

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@UserId", Id);

                _connection.Open();
                int i = com.ExecuteNonQuery();
                _connection.Close();
                if (i >= 1)
                {
                    return true;
                }
                else
                {

                    return false;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<UserModel> GetAllUsers()
        {
            try
            {
                GetConnection();
                List<UserModel> users = new List<UserModel>();


                SqlCommand com = new SqlCommand("GetAllUsers", _connection);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();

                _connection.Open();
                da.Fill(dt);
                _connection.Close();
                //Bind EmpModel generic list using dataRow     
                foreach (DataRow dr in dt.Rows)
                {

                    users.Add(

                        new UserModel
                        {

                            UserId = Convert.ToInt32(dr["Id"]),
                            Name = Convert.ToString(dr["Name"]),
                            Email = Convert.ToString(dr["Email"]),
                            Address = Convert.ToString(dr["Address"])

                        }
                        );
                }

                return users;

            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public bool UpdateUser(UserModel user)
        {
            try
            {
                GetConnection();
                SqlCommand com = new SqlCommand("UpdateUserDetails", _connection);

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@UserId", user.UserId);
                com.Parameters.AddWithValue("@Name", user.Name);
                com.Parameters.AddWithValue("@Email", user.Email);
                com.Parameters.AddWithValue("@Address", user.Address);
                _connection.Open();
                int i = com.ExecuteNonQuery();
                _connection.Close();
                if (i >= 1)
                {

                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}