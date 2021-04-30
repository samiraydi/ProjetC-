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
    public partial class FRM_Menu : Form
    {
        public FRM_Menu()
        {
            InitializeComponent();
            panel1.Size = new Size(219, 726);
            pnlParamettrer.Visible = false;
        }
        void desacriverForm()
        {
            btnclient.Enabled = false;
            btnproduit.Enabled = false;
            btncategorie.Enabled = false;
            btnutilisateur.Enabled = false;
          //  btncopie.Enabled = false;
           // btnrestaurer.Enabled = false;
            btndeconnecter.Enabled = false;
            btncommande.Enabled = false;
            pnlBut.Enabled = false;
            btnconnectrer.Enabled = true;
        }
        public void activerForm()
        {
            btnclient.Enabled = true;
            btnproduit.Enabled = true;
            btncategorie.Enabled = true;
            btnutilisateur.Enabled = true;
          //  btncopie.Enabled = true;
         //   btnrestaurer.Enabled = true;
            btndeconnecter.Enabled = true;
            btncommande.Enabled = true;
            pnlBut.Enabled = true;
            btnconnectrer.Enabled = false;
            pnlParamettrer.Visible = false;
        }
        private void FRM_Menu_Load(object sender, EventArgs e)
        {
            desacriverForm();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (panel1.Width==219)
            {
                panel1.Size = new Size(73, 726);
            }
            else
            {
                panel1.Size = new Size(219, 726);
            }
        }

        private void Btnproduit_Click(object sender, EventArgs e)
        {
            pnlBut.Top = btnproduit.Top;
            if (!pnlaficher.Controls.Contains(USER_Liste_Produit.Instance))
            {
                pnlaficher.Controls.Add(USER_Liste_Produit.Instance);
                USER_Liste_Produit.Instance.Dock = DockStyle.Fill;
                USER_Liste_Produit.Instance.BringToFront();
            }
            else
            {
                USER_Liste_Produit.Instance.BringToFront();
            }
        }

        private void Btnclient_Click(object sender, EventArgs e)
        {
            pnlBut.Top = btnclient.Top;
            if (!pnlaficher.Controls.Contains(USER_Liste_Client.Instance))
            {
                pnlaficher.Controls.Add(USER_Liste_Client.Instance);
                USER_Liste_Client.Instance.Dock = DockStyle.Fill;
                USER_Liste_Client.Instance.BringToFront();
            }
            else
            {
                USER_Liste_Client.Instance.BringToFront();
            }
        }

        private void Btncategorie_Click(object sender, EventArgs e)
        {
            pnlBut.Top = btncategorie.Top;
            if (!pnlaficher.Controls.Contains(USER_Liste_Categorie.Instance))
            {
                pnlaficher.Controls.Add(USER_Liste_Categorie.Instance);
                USER_Liste_Categorie.Instance.Dock = DockStyle.Fill;
                USER_Liste_Categorie.Instance.BringToFront();
            }
            else
            {
                USER_Liste_Categorie.Instance.BringToFront();
            }
        }

        private void Btncommande_Click(object sender, EventArgs e)
        {
            pnlBut.Top = btncommande.Top;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            pnlBut.Top = btnutilisateur.Top;
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btnparamettre_Click(object sender, EventArgs e)
        {
            pnlParamettrer.Size=new Size(309, 182);
            pnlParamettrer.Visible = !pnlParamettrer.Visible;
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            // aficher formulaire connexion
            FRM_Connexion frmC = new FRM_Connexion(this);//this FRM_Menu
            frmC.ShowDialog();
        }

        private void Btndeconnecter_Click(object sender, EventArgs e)
        {
            desacriverForm();
        }
    }
}
