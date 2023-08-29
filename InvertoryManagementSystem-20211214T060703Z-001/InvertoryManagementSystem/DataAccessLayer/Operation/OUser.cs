using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Operation
{
    public class OUser
    {
        SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-SON4VV34;Initial Catalog=Inventorydb;Integrated Security=True");
        // Database connecting string.

        public SqlDataAdapter login(string username, string password)

        {

            connection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from UserTbl where Upassword = '" +
                password +
                "' and Uname = '" +
                username +
                "';", connection);
            connection.Close();

            return sqlDataAdapter;

        }

        public int insert(EUser eUser)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("insert into UserTbl(Uname ,Ufullname ,Upassword ,Uphone ) values('" + eUser.Uname + "','" + eUser.Ufullname + "','" + eUser.Upassword + "','" + eUser.Uphone + "')", connection);
            int number = command.ExecuteNonQuery();
            connection.Close();

            return number;
        }


        public SqlDataAdapter getAllUser()
        {
            connection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from UserTbl ", connection);
            connection.Close();
            return sqlDataAdapter;
        }
        public int deleteUser(string Uphone)
        {
            //sql to delete user
            connection.Open();
            SqlCommand command = new SqlCommand("Delete from  UserTbl Where Uphone = '" + Uphone + "'", connection);
            int number = command.ExecuteNonQuery();
            connection.Close();

            return number;
        }

    }
}

