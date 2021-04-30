using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace mini_projet.PL
{
    
    public partial class USER_Liste_Client : UserControl
    {
        private static USER_Liste_Client Userclient;
         public Client dx = new Client();
        public static int a;
        public static USER_Liste_Client Instance
        {
            get
            {
                if (Userclient == null)
                {
                    Userclient = new USER_Liste_Client();
                }
                return Userclient;
            }
        }
      
        public USER_Liste_Client()
        {
            InitializeComponent();
            //Userclient= Userclient;
            this.dvgclient.Refresh();
        }

        private void USER_Liste_Client_Load(object sender, EventArgs e)
        {
            MySqlConnection connexion = new MySqlConnection();
            MySqlDataAdapter donnee = new MySqlDataAdapter();
            connexion.ConnectionString = @"datasource = localhost; port = 3306; database = mohamedhedi;username=root;password=";
            //connexion.ConnectionString = "SERVER=localhost;" + "DATABASE=mini_projet_c#;" + "UID=root;" + "PASSWORD=;";
            connexion.Open();
            MySqlCommand command = connexion.CreateCommand();
            command.CommandText = "select * from client";
            donnee.SelectCommand = command;
            DataSet dataset = new DataSet();
            donnee.Fill(dataset);
            dvgclient.DataSource = dataset.Tables[0];
            //Actualisedatagrid();
            connexion.Close();
        }
        public  void Actualisedatagrid()
        {
            // dvgclient.Rows.Clear();
            //MessageBox.Show("samir");
            DataTable d = new DataTable();
            Client c = new Client();
            d = c.select();
            dvgclient.DataSource = d;
           
        }
        private void TextBox1_Enter(object sender, EventArgs e)
        {
            if(txtrecherche.Text=="Recherche")
            {
                txtrecherche.Text = "";
                txtrecherche.ForeColor = Color.Black;
            }
        }

        private void Btnajouteclient_Click(object sender, EventArgs e)
        {
            PL.FRM_Ajoute_Modifier_Client frmclient = new FRM_Ajoute_Modifier_Client(this);
            frmclient.ShowDialog();
        }

        private void Btnmodifierclient_Click(object sender, EventArgs e)
        {
            PL.FRM_Ajoute_Modifier_Client frmclient = new PL.FRM_Ajoute_Modifier_Client(this);
            frmclient.lblTiTre.Text = "Modifier Client";
            frmclient.btnactualiser.Visible = false;
            frmclient.txtNom.Text =dx.nom;
            frmclient.txtPrenom.Text = dx.prenom;
            frmclient.txtadresse.Text = dx.Adresse;
            frmclient.txtEmail.Text = dx.email;
            frmclient.txtTelephone.Text = dx.telephone;
            frmclient.txtPays.Text = dx.pys;
            frmclient.txtVille.Text = dx.ville;
            frmclient.ShowDialog();
            //apres modification 
          

        }



        private void Btnsuprimerclient_Click(object sender, EventArgs e)
        {
        /*    Client c = new Client();
            int nb = 0;
            //pour supprimer tout les client 
            for (int i = 0; i < dvgclient.Rows.Count; i++)
            {
                //MessageBox.Show(dvgclient.Rows[i].Cells[0].c);
                //MessageBox.Show(dvgclient.Rows[i].Cells[0].Value.ToString());
            if(dvgclient.Rows[i].Cells[0].Value.ToString().Equals(true))
                {
                    nb++;
                }
            }*/
            
            if (dx == null)
            {
                MessageBox.Show("aucun client selectionner");
            }
            else
            {
                DialogResult r = MessageBox.Show("voulez vous supprimer", "Suppresion", MessageBoxButtons.YesNo, MessageBoxIcon.Question); ;
                if (r == DialogResult.Yes)
                {
                    MessageBox.Show(dx.nom);
                    dx.delete(dx);
                    Actualisedatagrid();
                
                MessageBox.Show("suppresion avec succées ");
            }
                else
                {
                    MessageBox.Show("suppresion annuler ");
                }
 
            }
        }

        private void Dvgclient_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Dvgclient_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;

            dx.nom = dvgclient.Rows[row].Cells[0].Value.ToString();
            dx.prenom = dvgclient.Rows[row].Cells[1].Value.ToString();
            dx.email = dvgclient.Rows[row].Cells[2].Value.ToString();
            dx.Adresse = dvgclient.Rows[row].Cells[3].Value.ToString();
            dx.telephone = dvgclient.Rows[row].Cells[4].Value.ToString();
            dx.pys = dvgclient.Rows[row].Cells[5].Value.ToString();
            dx.ville = dvgclient.Rows[row].Cells[6].Value.ToString();
        }

      
        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
           

            dx.id = int.Parse(dvgclient.Rows[row].Cells[0].Value.ToString());
            USER_Liste_Client.a = dx.id;
           // MessageBox.Show(USER_Liste_Client.a.ToString());
           // MessageBox.Show(dx.id.ToString());
            dx.nom = dvgclient.Rows[row].Cells[1].Value.ToString();
            dx.prenom = dvgclient.Rows[row].Cells[2].Value.ToString();
            dx.email = dvgclient.Rows[row].Cells[3].Value.ToString();
            dx.Adresse = dvgclient.Rows[row].Cells[4].Value.ToString();
            dx.telephone = dvgclient.Rows[row].Cells[5].Value.ToString();
            dx.pys = dvgclient.Rows[row].Cells[6].Value.ToString();
            dx.ville = dvgclient.Rows[row].Cells[7].Value.ToString();
        }

        private void Txtrecherche_TextChanged(object sender, EventArgs e)
        {
            String ch = txtrecherche.Text;
            MySqlCommand cmd = new MySqlCommand();

            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;database=mini_projet_c#;username=root;password=");
           // "select *  from  contact  WHERE Firstname like '%" + ch + "%' or Lastname like '%" + ch + "%' or Adresse like '%" + ch + "%' ";
            String sql = "select *  from  client  WHERE nom like '%" + ch + "%' or prenom like '%" + ch + "%' or Adresse like '%" + ch + "%'  or email like ' % "  + ch + "%'";
            cmd.Connection = connection;
            cmd.CommandText = sql;
            MySqlDataAdapter d = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            d.Fill(dt);
            dvgclient.DataSource = dt;
        }

        private void Dvgclient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
