using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;
using MySql.Data.MySqlClient;

namespace mini_projet
{
  public   class Client
    {
        public int id { get; set; }
        public String nom { get; set; }
        public String prenom { get; set; }
        public String email { get; set; }
        public String Adresse { get; set; }
        public String telephone { get; set; }
        public String pys { get; set; }
        public String ville { get; set; }
        ///methode selection de database
        public DataTable select()
        {
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;database=mohamedhedi;username=root;password=");
            DataTable dt = new DataTable();
            try
            {
                String sql = "select * from client";
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

        public bool insert(Client c)
        {
            bool test = false;
            //connection base de donnee
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;database=mohamedhedi;username=root;password=");
            try
            {
                String sql = "INSERT INTO client(nom,prenom,email,Adresse,telephone,pys,ville) VALUES(@nom,@prenom,@email,@Adresse,@telephone,@pys,@ville)";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = sql;
                //cmd.Parameters.AddWithValue("@id",c.id);
                cmd.Parameters.AddWithValue("@nom", c.nom);
                cmd.Parameters.AddWithValue("@prenom", c.prenom);
                cmd.Parameters.AddWithValue("@email", c.email);
                cmd.Parameters.AddWithValue("@Adresse", c.Adresse);
                cmd.Parameters.AddWithValue("@telephone", c.telephone);
                cmd.Parameters.AddWithValue("@pys", c.pys);
                cmd.Parameters.AddWithValue("@ville", c.ville);
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
        public bool modifier(Client c)
        {
            bool test = false;
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;database=mohamedhedi;username=root;password=");
            try
            {
                String sql = "UPDATE client SET nom=@nom,prenom=@prenom,email=@email,Adresse=@Adresse,telephone=@telephone,pys=@pys,ville=@ville WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", c.id);
                cmd.Parameters.AddWithValue("@nom", c.nom);
                cmd.Parameters.AddWithValue("@prenom", c.prenom); 
                cmd.Parameters.AddWithValue("@email", c.email);
                cmd.Parameters.AddWithValue("@Adresse", c.Adresse);
                cmd.Parameters.AddWithValue("@telephone", c.telephone);
                cmd.Parameters.AddWithValue("@pys", c.pys);
                cmd.Parameters.AddWithValue("@ville", c.ville);

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
        public bool delete(Client c)
        {
            bool test = false;
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;database=mohamedhedi;username=root;password=");
            try
            {
                String sql = "DELETE from  client  WHERE id=@id";
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
