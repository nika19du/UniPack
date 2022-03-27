using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeWinform
{
    public class Function
    {
        protected SqlConnection getConnection()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "data source=.\\SQLEXPRESS;database=Restro;integrated security=True";
            return connection;
        }

        public DataSet getData(String query)
        {
            SqlConnection connection = this.getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText =query;
            //stores data
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            return dataSet;//its gonna return after finding that query in database
        }
        public void setData(String query)
        {
            SqlConnection connection = getConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            connection.Open();
            command.CommandText = query;
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Data Processed Successfully","Success",MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
