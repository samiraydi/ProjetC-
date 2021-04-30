using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mini_projet
{
    public class Produit
    {
        private int v1;
        private string v2;
        private int v3;
        private double v4;
        private string v5;
        private uint v6;

        public Produit(int v1, string v2, int v3, double v4, string v5, uint v6)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
            this.v6 = v6;
        }
        public Produit()
        {
           
        }

        public int id { get; set; }
        public String nom { get; set; }
        public int qunte { get; set; }
        public double prix { get; set; }
        public String image { get; set; }
        public int id_cat { get; set; }


        public List<Produit> FindAll()
        {
            List<Produit> res = new List<Produit>();

            try
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;database=mohamedhedi;username=root;password=");

                String sql = "select * from  produit";
                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = connection;
                cmd.CommandText = sql;
                connection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Produit m = new Produit(reader.GetInt32(0), reader.GetString(1),reader.GetInt32(2),reader.GetDouble(3),reader.GetString(4),reader.GetUInt32(5));
                    res.Add(m);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Produit : Pb de FindAll \n " + ex.Message, "Attention");
            }
            return res;
        }
        public DataTable select()
        {
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;database=mohamedhedi;username=root;password=");
            DataTable dt = new DataTable();
            try
            {
                String sql = "select * from produit";
                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = connection;
                cmd.CommandText = sql;
                MySqlDataAdapter d = new MySqlDataAdapter(cmd);
                connection.Open();
                d.Fill(dt);
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();

            }
            return dt;
        }
        public bool insert(Produit c)
        {
            bool test = false;
            //connection base de donnee
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;database=mohamedhedi;username=root;password=");
            try
            {
                String sql = "INSERT INTO produit(nom,qunte,prix,image,id_cat) VALUES(@nom,@qunte,@prix,@image,@id_cat)";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = sql;
                //cmd.Parameters.AddWithValue("@id",c.id);
                cmd.Parameters.AddWithValue("@nom", c.nom);
                cmd.Parameters.AddWithValue("@qunte", c.qunte);
                cmd.Parameters.AddWithValue("@prix", c.prix);
                cmd.Parameters.AddWithValue("@image", c.image);
                cmd.Parameters.AddWithValue("@id_cat", c.id_cat);
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    test = true;
                }
                else
                {
                    test = false;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
            return test;
        }
        public bool modifier(Produit c)
        {
            bool test = false;
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;database=mohamedhedi;username=root;password=");
            try
            {
                String sql = "UPDATE produit SET nom=@nom,qunte=@qunte,prix=@prix WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", c.id);
                cmd.Parameters.AddWithValue("@nom", c.nom);
                cmd.Parameters.AddWithValue("@qunte", c.qunte);
                cmd.Parameters.AddWithValue("@prix", c.prix);
                //cmd.Parameters.AddWithValue("@image", c.image);
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    test = true;
                }
                else
                {
                    test = false;
                }


            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return test;
        }

        public bool delete(Produit c)
        {
            bool test = false;
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;database=mohamedhedi;username=root;password=");
            try
            {
                String sql = "DELETE from  produit  WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", c.id);
                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    test = true;
                }
                else
                {
                    test = false;
                }


            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }

            return test;
        }
    }
}
