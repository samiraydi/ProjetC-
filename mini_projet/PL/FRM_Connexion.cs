using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mini_projet.PL
{
    //public  List<Client> util = new List<Client>(); // création de la liste.
    //Client c = new Client();
    public partial class FRM_Connexion : Form
    {
        public  List<Utilisateur> util = new List<Utilisateur>(); // création de la liste.
       // Client c = new Client();
        //private DbStockContext db;
        private Form frmmenu;
        //classe connexion
        //BL.CLS_Connexion C = new BL.CLS_Connexion();
        public FRM_Connexion( Form Menu)
        {
            InitializeComponent();
            this.frmmenu = Menu;
            //initialiser base de donné
           // db = new DbStockContext();
            //Console.WriteLine(db);
        }
        //pour verifier les camp obligatoires
        string testobligatoire()
        {
            if(txtNom.Text=="" || txtNom.Text== "Nom d'utilisateur")
            {
                return "Entrer votre Nom";
            }
            if (txtmotdepasse.Text=="" || txtmotdepasse.Text== "Mot de Passe")
            {
                return "Entrer votre Mot De Passe";
            }
            return null; 
        }
        private void Ctnquitter_Click(object sender, EventArgs e)
        {
            // quitter la formulaire
            this.Close();
        }

        private void TxtNom_Enter(object sender, EventArgs e)
        {
            // pour vider le textBox
            if (txtNom.Text== "Nom d'utilisateur")
            {
                txtNom.Text = "";
                txtNom.ForeColor = Color.WhiteSmoke;
            }
        }

        private void Txtmotdepasse_Enter(object sender, EventArgs e)
        {
          
            if (txtmotdepasse.Text == "Mot de Passe")
            {
                txtmotdepasse.Text = "";
                txtmotdepasse.UseSystemPasswordChar = false;
                txtmotdepasse.PasswordChar = '*';
                txtmotdepasse.ForeColor = Color.WhiteSmoke;
            }
        }

        private void TxtNom_Leave(object sender, EventArgs e)
        {
            if (txtNom.Text=="")
            {
                txtNom.Text = "Nom d'utilisateur";
                txtNom.ForeColor = Color.Silver;
            }
        }

        private void Txtmotdepasse_Leave(object sender, EventArgs e)
        {
            if (txtmotdepasse.Text == "")
            {
                txtmotdepasse.Text = "Mot de Passe";
                txtmotdepasse.UseSystemPasswordChar = true;
                txtmotdepasse.ForeColor = Color.Silver;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            Utilisateur c = new Utilisateur();
            c.nom = txtNom.Text;
            c.motdepasse = txtmotdepasse.Text;
            DataTable d=new DataTable();
            d = c.verif(c);
            if (testobligatoire() == null)
            {


                if (d.Rows.Count == 0)
                {
                    MessageBox.Show("Connexion a échoué", "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {



                    MessageBox.Show("Connexion a réussi", "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    (frmmenu as FRM_Menu).activerForm();
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show(testobligatoire(), "obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /* if (testobligatoire()==null)
             {



                 {

                     MessageBox.Show("Connexion a réussi", "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                     (frmmenu as FRM_Menu).activerForm();
                     this.Close();
                 }
                 else
                 {

                     MessageBox.Show("Connexion a échoué", "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);

                 }
             }
             else
             {
                 MessageBox.Show(testobligatoire(), "obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }*/
        }

        private void Txtmotdepasse_TextChanged(object sender, EventArgs e)
        {

        }

        private void FRM_Connexion_Load(object sender, EventArgs e)
        {

        }
    }
}
