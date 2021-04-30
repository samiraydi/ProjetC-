using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
namespace mini_projet.PL
{
    public partial class FRM_Ajouter_Modifie_Produit : Form
    {
        
        private DataTable dt;
        private List<Categorie> cat = new List<Categorie>();
        private Categorie c = new Categorie();
        private USER_Liste_Produit  samir;
        private UserControl usproduit;
        private Produit p = new Produit();
        //private USER_Liste_Client usclient;

        public FRM_Ajouter_Modifie_Produit(UserControl usproduit)
        {
            Categorie c = new Categorie();
            InitializeComponent();
            this.usproduit = usproduit;
            
        }

        public FRM_Ajouter_Modifie_Produit()
        {
        }

        private void PicProduit_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            DataTable d;
            d = p.select();
            (usproduit as USER_Liste_Produit).Actualisedatagrid();
            // dvgclient


            Close();
        }

        private void TxtTelephone_Enter(object sender, EventArgs e)
        {
            if (txtNom.Text == "Nom Produit")
            {
                txtNom.Text = "";
                txtNom.ForeColor = Color.White;
            }
        }

        private void Txtquantite_Enter(object sender, EventArgs e)
        {
            if (txtquantite.Text == "Quantité")
            {
                txtquantite.Text = "";
                txtquantite.ForeColor = Color.White;
            }
        }

        private void Txtprix_Enter(object sender, EventArgs e)
        {
            if (txtprix.Text == "Prix")
            {
                txtprix.Text = "";
                txtprix.ForeColor = Color.White;
            }
        }

        private void TxtNom_Leave(object sender, EventArgs e)
        {
            if (txtNom.Text == "")
            {
                txtNom.Text = "Nom Produit";
                txtNom.ForeColor = Color.Silver;
            }
        }

        private void Txtquantite_Leave(object sender, EventArgs e)
        {
            if (txtquantite.Text == "")
            {
                txtquantite.Text = "Quantité";
                txtquantite.ForeColor = Color.Silver;
            }
        }

        private void Txtprix_Leave(object sender, EventArgs e)
        {
            if (txtprix.Text == "")
            {
                txtprix.Text = "Prix";
                txtprix.ForeColor = Color.Silver;
            }
        }

        private void Btnparcourie_Click(object sender, EventArgs e)
        {
            OpenFileDialog OP = new OpenFileDialog();
            OP.Filter = "|*.JPG;*.PNG;*.GIF;*.BMP";
            if (OP.ShowDialog() == DialogResult.OK)
            {
                PicProduit.Image = Image.FromFile(OP.FileName);
            }
        }

        private void Btnactualiser_Click(object sender, EventArgs e)
        {
            txtNom.Text = "Nom Produit";
            txtNom.ForeColor = Color.Silver;
            txtquantite.Text = "Quantité";
            txtquantite.ForeColor = Color.Silver;
            txtprix.Text = "Prix";
            txtprix.ForeColor = Color.Silver;
            combocategorie.Text = "";
            PicProduit.Image = null;
        }

        private void Txtquantite_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 48 || e.KeyChar > 57)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
        }

        private void Txtprix_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 48 || e.KeyChar > 57)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
        }

        private void FRM_Ajouter_Modifie_Produit_Load(object sender, EventArgs e)
        {
            DataTable d;
            d = c.select();

            cat = c.FindAll();

            foreach (Categorie item in cat)
            {
               // MessageBox.Show(item.ToString());
            }
            combocategorie.Items.AddRange(cat.ToArray());



        }
        string testobligatoire()
        {
            if (txtNom.Text == "" || txtNom.Text == "Nom Produit ")
            {
                return "Entre le Nom Produit ";
            }
            if (txtquantite.Text == "" || txtquantite.Text == "Quantité")
            {
                return "Entre le Quantité";
            }
            if (txtprix.Text == "" || txtprix.Text == "Prix")
            {
                return "Entre le Prix";
            }
           /* if (PicProduit.Image==null)
            {
                return "Entre l'image de Produit";
            }*/
            if (combocategorie.Text==null)
            {
                return "Entre Categorie";
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
                if (lblTiTre.Text == "Ajouter Produit")
                {
                    Categorie m = (Categorie)combocategorie.SelectedItem;
                    // MessageBox.Show(m.id.ToString());
                    Produit p = new Produit();
                    //convertion de format image de type byte 

                    // p.image = PicProduit.ToString();
                    MessageBox.Show(PicProduit.Image.ToString());
                    p.nom = txtNom.Text;
                    p.id_cat = m.id;
                    MemoryStream mr = new MemoryStream();
                    PicProduit.Image.Save(mr, PicProduit.Image.RawFormat);
                    //byte[] byteimage = mr.ToArray();
                    p.qunte = int.Parse(txtquantite.Text);
                    p.prix = double.Parse(txtprix.Text);
                    p.image = "samir.png";
                    test = p.insert(p);
                    if (test == true)
                    {
                        MessageBox.Show("produit ajouter avec succée");
                    }
                    else
                    {
                        MessageBox.Show("produit n'est pas ajouter ");
                    }


                }
                else
                {
                    bool testmodif = false;
                  //  MessageBox.Show("hedi");
                    MessageBox.Show(USER_Liste_Produit.a.ToString());

                    Produit p = new Produit();
                    p.id = USER_Liste_Produit.a;
                    p.nom = txtNom.Text;
                    p.qunte = int.Parse(txtquantite.Text);
                    p.prix = double.Parse(txtprix.Text);
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

        private void Combocategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void TxtNom_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
