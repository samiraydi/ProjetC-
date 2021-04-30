using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using MySql.Data.MySqlClient;

namespace mini_projet.PL
{
    public partial class FRM_Ajoute_Modifier_Client : Form
    {
        private USER_Liste_Client d ;
        private UserControl usclient;
        private object dvgclient;
        private object dx;

        public FRM_Ajoute_Modifier_Client(UserControl userC)
        {
            InitializeComponent();
            this.usclient = userC;
        }

        string testobligatoire()
        {
            if (txtNom.Text==""|| txtNom.Text== "Nom de Client")
            {
                return "Entre le Nom de Client";
            }
            if (txtPrenom.Text == "" || txtPrenom.Text == "Prenom de Client")
            {
                return "Entre le Prenom de Client";
            }
            if (txtadresse.Text == "" || txtadresse.Text == "Adresse Client")
            {
                return "Entre le Adresse de Client";
            }
            if (txtTelephone.Text == "" || txtTelephone.Text == "Telephone Client")
            {
                return "Entre le Telephone de Client";
            }
            if (txtEmail.Text == "" || txtEmail.Text == "Email Client")
            {
                return "Entre le Email de Client";
            }
            if (txtPays.Text == "" || txtPays.Text == "Pays Client")
            {
                return "Entre le Pays de Client";
            }
            if (txtVille.Text == "" || txtVille.Text == "Ville Client")
            {
                return "Entre le Ville de Client";
            }
            if (txtEmail.Text!=""||txtEmail.Text!= "Email Client")
            {
                try
                {
                    new MailAddress(txtEmail.Text);
                }catch(Exception e)
                {
                    return "Email Invalide";
                }
            }
            return null;
        }

        private void TxtNom_Enter(object sender, EventArgs e)
        {
            if(txtNom.Text=="Nom de Client")
            {
                txtNom.Text = "";
                txtNom.ForeColor = Color.White;
            }
        }

        private void TxtNom_Leave(object sender, EventArgs e)
        {
            if (txtNom.Text == "")
            {
                txtNom.Text = "Nom de Client";
                txtNom.ForeColor = Color.Silver;
            }
        }

        private void TxtPrenom_Enter(object sender, EventArgs e)
        {
            if (txtPrenom.Text == "Prenom de Client")
            {
                txtPrenom.Text = "";
                txtPrenom.ForeColor = Color.White;
            }
        }

        private void TxtPrenom_Leave(object sender, EventArgs e)
        {
            if (txtPrenom.Text == "")
            {
                txtPrenom.Text = "Prenom de Client";
                txtPrenom.ForeColor = Color.Silver;
            }
        }

        private void Txtadresse_Enter(object sender, EventArgs e)
        {
            
            if (txtadresse.Text == "Adresse Client")
            {
                txtadresse.Text = "";
                txtadresse.ForeColor = Color.White;
            }
        }

        private void Txtadresse_Leave(object sender, EventArgs e)
        {
            if (txtadresse.Text == "")
            {
                txtadresse.Text = "Adresse Client";
                txtadresse.ForeColor = Color.Silver;
            }
        }

        private void TxtTelephone_Enter(object sender, EventArgs e)
        {
            
                if (txtTelephone.Text == "Telephone Client")
            {
                txtTelephone.Text = "";
                txtTelephone.ForeColor = Color.White;
            }
        }

        private void TxtTelephone_Leave(object sender, EventArgs e)
        {
            if (txtTelephone.Text == "")
            {
                txtTelephone.Text = "Telephone Client";
                txtTelephone.ForeColor = Color.Silver;
            }
        }

        private void TxtEmail_Enter(object sender, EventArgs e)
        {
            
            if (txtEmail.Text == "Email Client")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.White;
            }
        }

        private void TxtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Email Client";
                txtEmail.ForeColor = Color.Silver;
            }
        }

        private void TxtPays_Enter(object sender, EventArgs e)
        {
            
            if (txtPays.Text == "Pays Client")
            {
                txtPays.Text = "";
                txtPays.ForeColor = Color.White;
            }
        }

        private void TxtPays_Leave(object sender, EventArgs e)
        {
            if (txtPays.Text == "")
            {
                txtPays.Text = "Pays Client";
                txtPays.ForeColor = Color.Silver;
            }
        }

        private void TxtVille_Enter(object sender, EventArgs e)
        {
            if (txtVille.Text == "Ville Client")
            {
                txtVille.Text = "";
                txtVille.ForeColor = Color.White;
            }
        }

        private void TxtVille_Leave(object sender, EventArgs e)
        {
            if (txtVille.Text == "")
            {
                txtVille.Text = "Ville Client";
                txtVille.ForeColor = Color.Silver;
            }
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            (usclient as USER_Liste_Client).Actualisedatagrid();
            Close();
        }

        private void TxtTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar<48 || e.KeyChar > 57)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
        }

        private void FRM_Ajoute_Modifier_Client_Load(object sender, EventArgs e)
        {

        }

        private void Btnenregistrer_Click(object sender, EventArgs e)
        {
            Client c = new Client();
            if (testobligatoire() != null)
            {
                MessageBox.Show(testobligatoire(),"Obligatoire",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if (lblTiTre.Text == "Ajouter Client")
                {


                    string connectionString = @"datasource = localhost; port = 3306; database = mohamedhedi;username=root;password=";

                    MySqlConnection connection = null;
                    try
                    {

                        connection = new MySqlConnection(connectionString);
                        connection.Open();
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = connection;
                        cmd.CommandText = "INSERT INTO client(nom,prenom,email,Adresse,telephone,pys,ville) VALUES(@nom,@prenom,@email,@Adresse,@telephone,@pys,@ville)";
                        cmd.Prepare();
                        //if (("@nom" == txtNom.Text) && ("@prenom" == txtPrenom.Text))
                        // {
                        //MessageBox.Show("Nom et Prenom d'éja existant", "ajouter", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        cmd.Parameters.AddWithValue("@nom", txtNom.Text);
                        cmd.Parameters.AddWithValue("@prenom", txtPrenom.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Adresse", txtadresse.Text);
                        cmd.Parameters.AddWithValue("@telephone", txtTelephone.Text);
                        cmd.Parameters.AddWithValue("@pys", txtPays.Text);
                        cmd.Parameters.AddWithValue("@ville", txtVille.Text);
                        MessageBox.Show("Client Ajouter avec succes", "ajouter", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        (usclient as USER_Liste_Client).Actualisedatagrid();
                        ////DataTable ah;
                        // ah= c.select();
                        // d.Actualisedatagrid();

                        //this.d.dvgclient.DataSource = ah;
                        // this.usclient.dv
                        //USER_Liste_Client.dvgclient.DataSource = ah;

                        //USER_Liste_Client.dvgclient.datasource = d;
                        // USER_Liste_Client
                        (usclient as USER_Liste_Client).Actualisedatagrid();
                        cmd.ExecuteNonQuery();

                        // }
                    }
                    finally
                    {
                        if (connection != null)
                            connection.Close();
                    }
                }
                else
                {
                  // MessageBox.Show("hello world");
                    MessageBox.Show(USER_Liste_Client.a.ToString());
                    
                    c.id = USER_Liste_Client.a;
                    c.nom = txtNom.Text;
                    c.prenom = txtPrenom.Text;
                    c.email = txtEmail.Text;
                    c.Adresse = txtadresse.Text;
                    c.telephone = txtTelephone.Text;
                    c.pys = txtPays.Text;
                    c.ville = txtVille.Text;
                    //MessageBox.Show(c.ville.ToString());
                   // MessageBox.Show(c.id.ToString());
                   // MessageBox.Show(c.ToString());
                    c.modifier(c);
                    MessageBox.Show("modifcation avec succées ");
                    //this.Close();

                }
            }
        }

        private void Btnactualiser_Click(object sender, EventArgs e)
        {
            txtNom.Text = "Nom de Client"; txtNom.ForeColor = Color.Silver;
            txtPrenom.Text = "Prenom de Client"; txtPrenom.ForeColor = Color.Silver;
            txtadresse.Text = "Adresse Client"; txtadresse.ForeColor = Color.Silver;
            txtTelephone.Text = "Telephone Client"; txtTelephone.ForeColor = Color.Silver;
            txtEmail.Text = "Email Client"; txtEmail.ForeColor = Color.Silver;
            txtPays.Text = "Pays Client"; txtPays.ForeColor = Color.Silver;
            txtVille.Text = "Ville Client"; txtVille.ForeColor = Color.Silver;

        }
    }
}
