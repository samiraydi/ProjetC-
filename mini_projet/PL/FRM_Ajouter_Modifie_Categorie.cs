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
    public partial class FRM_Ajouter_Modifie_Categorie : Form
    {
        private DataTable dt;
        private List<Categorie> cat = new List<Categorie>();
        private Categorie c = new Categorie();
        private USER_Liste_Categorie samir;
        private UserControl usproduit;
        private Categorie p = new Categorie();
        public FRM_Ajouter_Modifie_Categorie(UserControl usproduit)
        {
            InitializeComponent();
            this.usproduit = usproduit;

        }

        private void TxtNom_Enter(object sender, EventArgs e)
        {
            
                if (txtNom.Text == "Nom de Categorie")
            {
                txtNom.Text = "";
                txtNom.ForeColor = Color.White;
            }
        }

        private void TxtNom_Leave(object sender, EventArgs e)
        {
            if (txtNom.Text == "")
            {
                txtNom.Text = "Nom de Categorie";
                txtNom.ForeColor = Color.Silver;
            }
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            DataTable d;
            d = p.select();
            (usproduit as USER_Liste_Categorie).Actualisedatagrid();
            // dvgclient


            Close();
        }
        string testobligatoire()
        {
            if (txtNom.Text == "" || txtNom.Text == "Nom de Categorie ")
            {
                return "Entre le Nom de Categorie ";
            }
           
            return null;
        }
        private void Btnenregistrer_Click(object sender, EventArgs e)
        {
            bool test = false;
            if (testobligatoire() != null)
            {
                MessageBox.Show(testobligatoire(), "Obliagtoire", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (lblTiTre.Text == "Ajouter Categorie")
                {
                    
                    // MessageBox.Show(m.id.ToString());
                    Categorie p = new Categorie();
                   
                    p.nom_cat = txtNom.Text;
                    
                    
                    test = p.insert(p);
                    if (test == true)
                    {
                        MessageBox.Show("Categorie ajouter avec succée");
                    }
                    else
                    {
                        MessageBox.Show("Categorie n'est pas ajouter ");
                    }


                }
                else
                {
                    bool testmodif = false;
                    //  MessageBox.Show("hedi");
                    MessageBox.Show(USER_Liste_Categorie.a.ToString());

                    Categorie p = new Categorie();
                    p.id = USER_Liste_Categorie.a;
                    p.nom_cat = txtNom.Text;
                    testmodif = p.modifier(p);
                    if (testmodif == true)
                    {
                        MessageBox.Show("modifcation avec succées");
                    }
                    else
                    {
                        MessageBox.Show("erreure de modification");
                    }


                }


            }

        }

        private void FRM_Ajouter_Modifie_Categorie_Load(object sender, EventArgs e)
        {
            DataTable d;
            d = c.select();

            cat = c.FindAll();

            foreach (Categorie item in cat)
            {
              //  MessageBox.Show(item.ToString());
            }
            
        }
    }
}
