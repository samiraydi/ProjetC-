using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace mini_projet
{
    class Categorie
    {
        public Categorie(int v1, string v2)
        {
            this.id = v1;
            this.nom_cat = v2;
        }

        public Categorie()
        {
        }

        public int id { get; set; }
        public String nom_cat { get; set; }



        public List<Categorie> FindAll()
        {
            List<Categorie> res = new List<Categorie>();

            try
            {
                MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;database=mohamedhedi;username=root;password=");
   
                String sql = "select * from  categorie";
                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = connection;
                cmd.CommandText = sql;
                connection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Categorie m = new Categorie(reader.GetInt32(0), reader.GetString(1));
                    res.Add(m);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("categorie : Pb de FindAll \n " + ex.Message, "Attention");
            }
            return res;
        }
        ///methode selection de database
        public DataTable select()
        {
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;database=mohamedhedi;username=root;password=");
            DataTable dt = new DataTable();
            try
            {
                String sql = "select * from  categorie";
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

        //insertion 
        public bool insert(Categorie c)
        {
            bool test = false;
            //connection base de donnee
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;database=mohamedhedi;username=root;password=");
            try
            {
                String sql = "INSERT INTO categorie(nom_cat) VALUES(@nom_cat)";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = sql;
                //cmd.Parameters.AddWithValue("@id",c.id);
                cmd.Parameters.AddWithValue("@nom_cat", c.nom_cat);
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
        //modification 
        public bool modifier(Categorie c)
        {
            bool test = false;
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;database=mohamedhedi;username=root;password=");
            try
            {
                String sql = "UPDATE categorie SET nom_cat=@nom_cat  WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", c.id);
                cmd.Parameters.AddWithValue("@nom_cat", c.nom_cat);
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

        public bool delete(Categorie c)
        {
            bool test = false;
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;database=mohamedhedi;username=root;password=");
            try
            {
                String sql = "DELETE from  categorie  WHERE id=@id";
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

        public static explicit operator Categorie(DataRow v)
        {
            throw new NotImplementedException();
        }
        public override String ToString()
        {
            return id + " | " + nom_cat;
        }
    }
}
