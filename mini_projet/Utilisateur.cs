using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_projet
{
   public  class Utilisateur
    {
        public String nom { get; set; }
        public String motdepasse { get; set; }


        ///methode selection de database
        public DataTable verif(Utilisateur c)
        {
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;database=mohamedhedi;username=root;password=");
            DataTable dt = new DataTable();
            try
            {

                String sql = "select * from  utilisateur where nom=@nom and motdepasse=@motdepasse";
                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = connection;
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@nom", c.nom);
                cmd.Parameters.AddWithValue("@motdepasse", c.motdepasse);
                MySqlDataAdapter d = new MySqlDataAdapter(cmd);
                connection.Open();
                d.Fill(dt);
                if (d == null)
                {
                    Console.WriteLine("vide");
                }
                else
                {
                    Console.WriteLine("mrigel");
                }
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

        ///methode selection de database
        public DataTable select()
        {
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;database=mohamedhedi;username=root;password=");
            DataTable dt = new DataTable();
            try
            {
               
               String sql = "select * from  utilisateur";
                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = connection;
                cmd.CommandText = sql;
                MySqlDataAdapter d = new MySqlDataAdapter(cmd);
                connection.Open();
                d.Fill(dt);
                if(d==null)
                {
                    Console.WriteLine("vide");
                }
                else
                {
                    Console.WriteLine("mrigel");
                }
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
        public bool insert(Utilisateur c)
        {
            bool test = false;
            //connection base de donnee
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;database=mohamedhedi;username=root;password=");
            try
            {
                String sql = "INSERT INTO utilisateur(nom,motdepasse) VALUES(@nom,@motdepasse)";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = sql;
                //cmd.Parameters.AddWithValue("@id",c.id);
                cmd.Parameters.AddWithValue("@nom", c.nom);
                cmd.Parameters.AddWithValue("@motdepasse", c.motdepasse);

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
        public bool modifier(Utilisateur c)
        {
            bool test = false;
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;database=mohamedhedi;username=root;password=");
            try
            {
                String sql = "UPDATE utilisateur SET nom=@nom,motdepasse=@motdepasse  WHERE nom=@nom";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = sql; 
                cmd.Parameters.AddWithValue("@nom", c.nom);
                cmd.Parameters.AddWithValue("@motdepasse", c.motdepasse);
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

        public static explicit operator Utilisateur(DataRow v)
        {
            throw new NotImplementedException();
        }

        public bool delete(Utilisateur c)
        {
            bool test = false;
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;database=mohamedhedi;username=root;password=");
            try
            {
                String sql = "DELETE from  utilisateur  WHERE nom=@nom";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@nom", c.nom);
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
