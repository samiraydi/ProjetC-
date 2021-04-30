using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace mini_projet.PL
{
    public partial class USER_Liste_Produit : UserControl
    {
        private static USER_Liste_Produit Userclient;
        public Produit dx = new Produit();
        public static int a;
        public Produit p = new Produit();
        public static USER_Liste_Produit Instance
        {
            get
            {
                if (Userclient == null)
                {
                    Userclient = new USER_Liste_Produit();
                }
                return Userclient;
            }
        }


        public USER_Liste_Produit()
        {
            InitializeComponent();
        }

        public void Actualisedatagrid()
        {
            // dvgclient.Rows.Clear();
            //MessageBox.Show("samir");
            System.Data.DataTable d = new System.Data.DataTable();
            Produit c = new Produit();
            d = c.select();
            dvgclient.DataSource = d;

        }

        private void USER_Liste_Produit_Load(object sender, EventArgs e)
        {
            System.Data.DataTable d;
            d = p.select();
            dvgclient.DataSource = d;

        }
        public void Actualisedatagridx()
        {
            // dvgclient.Rows.Clear();
            //MessageBox.Show("samir");
            System.Data.DataTable d = new System.Data.DataTable();
            Client c = new Client();
            d = c.select();
            dvgclient.DataSource = d;

        }

        private void Txtrecherche_Enter(object sender, EventArgs e)
        {
            if (txtrecherche.Text == "Recherche")
            {
                txtrecherche.Text = "";
                txtrecherche.ForeColor = Color.Black;
            }
        }

        private void Btnajouter_Click(object sender, EventArgs e)
        {
            
            PL.FRM_Ajouter_Modifie_Produit frmProduit = new PL.FRM_Ajouter_Modifie_Produit(this);
            frmProduit.ShowDialog();
        }

        private void Btnmodifier_Click(object sender, EventArgs e)
        {
            PL.FRM_Ajouter_Modifie_Produit frmproduit = new PL.FRM_Ajouter_Modifie_Produit(this);
            frmproduit.lblTiTre.Text = "Modifier Produit";
            frmproduit.btnactualiser.Visible = false;
            frmproduit.txtNom.Text = dx.nom;
            frmproduit.txtquantite.Text = dx.qunte.ToString();
            frmproduit.txtprix.Text = dx.prix.ToString();
          //  frmproduit.p = dx.prix.ToString();
            frmproduit.ShowDialog();
        }

        private void Dvgclient_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        int row = e.RowIndex;


            dx.id = int.Parse(dvgclient.Rows[row].Cells[0].Value.ToString());
            USER_Liste_Produit.a = dx.id;
         //   MessageBox.Show(USER_Liste_Produit.a.ToString());
         //   MessageBox.Show(dx.id.ToString());
            dx.nom = dvgclient.Rows[row].Cells[1].Value.ToString();
            dx.qunte = int.Parse(dvgclient.Rows[row].Cells[2].Value.ToString());
            dx.prix = double.Parse(dvgclient.Rows[row].Cells[3].Value.ToString());
            //dx.image = byte.Parse(dvgclient.Rows[row].Cells[4].Value.ToString());
            dx.id_cat = int.Parse(dvgclient.Rows[row].Cells[5].Value.ToString());
        }

        private void Btnsuprimer_Click(object sender, EventArgs e)
        {
            if (dx == null)
            {
                MessageBox.Show("aucun client selectionner");
            }
            else
            {
                DialogResult r = MessageBox.Show("voulez vous supprimer", "Suppresion", MessageBoxButtons.YesNo, MessageBoxIcon.Question); ;
                if (r == DialogResult.Yes)
                {
                    Produit p = new Produit();
                    MessageBox.Show(dx.nom);
                    p.delete(dx);
                    Actualisedatagridx();

                    MessageBox.Show("suppresion avec succées ");
                }
                else
                {
                    MessageBox.Show("suppresion annuler ");
                }

            }
        }

        private void Txtrecherche_TextChanged(object sender, EventArgs e)
        {
            String ch = txtrecherche.Text;
            MySqlCommand cmd = new MySqlCommand();

            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;database=mohamedhedi;username=root;password=");
            // "select *  from  contact  WHERE Firstname like '%" + ch + "%' or Lastname like '%" + ch + "%' or Adresse like '%" + ch + "%' ";
            String sql = "select *  from  produit  WHERE nom like '%" + ch + "%' ";
            cmd.Connection = connection;
            cmd.CommandText = sql;
            MySqlDataAdapter d = new MySqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();
            d.Fill(dt);
            dvgclient.DataSource = dt;
        }

        private void Dvgclient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Btnexcel_Click(object sender, EventArgs e)
        {
            System.Data.DataTable db = new System.Data.DataTable();
            Produit p = new Produit();
            using (SaveFileDialog SFD=new SaveFileDialog() { Filter="Excel Workbook|*.xlsx", ValidateNames = true })
            {
                if (SFD.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                    Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet ws = (Worksheet)app.ActiveSheet;

                    app.Visible = false;
                    ws.Cells[1, 1] = "Id Produit";
                    ws.Cells[1, 2] = "Nom Produit";
                    ws.Cells[1, 3] = "Quantité";
                    ws.Cells[1, 4] = "Prix";
                    List<Produit> l = p.FindAll();
                    int i = 2;
                    
                    foreach (Produit le in l)
                    {
                        ws.Cells[i, 1] = le.id;
                        ws.Cells[i, 2] = le.nom;
                        ws.Cells[i, 3] = le.qunte;
                        ws.Cells[i, 4] = le.prix;
                    }
                    wb.SaveAs(SFD.FileName);
                    app.Quit();
                    MessageBox.Show("sauvgarde avec succees dans Excel", "Excel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
    }
}
