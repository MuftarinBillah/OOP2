using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Operation
{
    public class OProduct
    {


        SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-SON4VV34;Initial Catalog=Inventorydb;Integrated Security=True");
        // Database connecting string.



        public SqlDataAdapter View(Eproduct eproduct)
        {
            connection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * From ProdTbl Where ProdCat Like '"+ eproduct.ProdCat + "%'", connection);
            connection.Close();

            return sqlDataAdapter;
        }

        public SqlDataAdapter getAllProduct()
        {
            connection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from ProdTbl ", connection);
            connection.Close();
            return sqlDataAdapter;
        }
        public SqlDataAdapter getAllSale()
        {
            connection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from SaleTbl ", connection);
            connection.Close();
            return sqlDataAdapter;
        }
        public SqlDataAdapter getAllReturn()
        {
            connection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from ReturnTbl ", connection);
            connection.Close();
            return sqlDataAdapter;
        }
        public SqlDataAdapter getProductStock(Eproduct eproduct)
        {
            //connection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select ProdQty from  ProdTbl Where ProdId = '" + eproduct.ProdId + "'", connection);
            connection.Close();
            return sqlDataAdapter;
        }


        public int insert(Eproduct eproduct)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("insert into ProdTbl(ProdId ,ProdNam ,ProdQty ,ProdPrice ,ProdCat ) values('" + eproduct.ProdId + "','" + eproduct.ProdNam + "','" + eproduct.ProdQty + "','" + eproduct.ProdPrice + "','" + eproduct.ProdCat+ "')", connection);
            int number = command.ExecuteNonQuery();
            connection.Close();

            return number;
        }

        public int deleteProduct(string ProdId)
        {
            //sql to delete user
            connection.Open();
            SqlCommand command = new SqlCommand("Delete from  ProdTbl Where ProdId = '" + ProdId + "'", connection);
            int number = command.ExecuteNonQuery();
            connection.Close();

            return number;
        }

        public int sellinsert(Eproduct eproduct)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("insert into SaleTbl(ProdId ,ProdNam ,Quantity ) values('" + eproduct.ProdId + "','" + eproduct.ProdNam + "','" + eproduct.ProdQty + "')", connection);
            int number = command.ExecuteNonQuery();
            connection.Close();

            return number;
        }

        public int updatestock(Eproduct eproduct)
        {
            connection.Open();
            /*var value = getProductStock(eproduct);
            int sold = Convert.ToInt32(eproduct.ProdQty);
            int currQty = Convert.ToInt32(value) - sold;
            */
            //  SqlCommand command = new SqlCommand("insert into ProdTbl(ProdQty) values('"+ currQty +"') where ProdId='"+eproduct.ProdId+"'",connection);
            // command.Parameters.AddWithValue("@value", eproduct.ProdQty);
            SqlCommand command = new SqlCommand("update ProdTbl Set ProdQty = ProdQty - '"+ eproduct.ProdQty + "' where ProdId = '"+ eproduct.ProdId + "'", connection);

            int number = command.ExecuteNonQuery();
            connection.Close();

            return number;

        }
        public int returninsert(Eproduct eproduct)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("insert into ReturnTbl(ProductId ,ProdNam ,Quantity ) values('" + eproduct.ProdId + "','" + eproduct.ProdNam + "','" + eproduct.ProdQty + "')", connection);
            int number = command.ExecuteNonQuery();
            connection.Close();

            return number;
        }



    }

}
