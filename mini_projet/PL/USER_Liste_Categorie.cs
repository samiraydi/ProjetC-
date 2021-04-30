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
    public partial class USER_Liste_Categorie : UserControl
    {
        private static USER_Liste_Categorie Userclient;
        private Categorie dx = new Categorie();
        public static int a;
        private Categorie p = new Categorie();
        public static USER_Liste_Categorie Instance
        {
            get
            {
                if (Userclient == null)
                {
                    Userclient = new USER_Liste_Categorie();
                }
                return Userclient;
            }
        }
        public USER_Liste_Categorie()
        {
            InitializeComponent();
        }

        public void Actualisedatagrid()
        {
            // dvgclient.Rows.Clear();
            //MessageBox.Show("samir");
            System.Data.DataTable d = new System.Data.DataTable();
            Categorie c = new Categorie();
            d = c.select();
            dvgclient.DataSource = d;

        }
        private void Txtrecherche_TextChanged(object sender, EventArgs e)
        {
            String ch = txtrecherche.Text;
            MySqlCommand cmd = new MySqlCommand();

            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;database=mohamedhedi;username=root;password=");
            // "select *  from  contact  WHERE Firstname like '%" + ch + "%' or Lastname like '%" + ch + "%' or Adresse like '%" + ch + "%' ";
            String sql = "select *  from  Categorie  WHERE nom_cat like '%" + ch + "%' ";
            cmd.Connection = connection;
            cmd.CommandText = sql;
            MySqlDataAdapter d = new MySqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable();
            d.Fill(dt);
            dvgclient.DataSource = dt;
        }

        private void USER_Liste_Categorie_Load(object sender, EventArgs e)
        {
            System.Data.DataTable d;
            d = p.select();
            dvgclient.DataSource = d;
        }

        private void Dvgclient_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            dx.id = int.Parse(dvgclient.Rows[row].Cells[0].Value.ToString());
            dx.nom_cat = dvgclient.Rows[row].Cells[1].Value.ToString();
            USER_Liste_Categorie.a = dx.id;

            /*  int row = e.RowIndex;


              dx.id = int.Parse(dvgclient.Rows[row].Cells[0].Value.ToString());
              USER_Liste_Categorie.a = dx.id;
              MessageBox.Show(USER_Liste_Categorie.a.ToString());
              MessageBox.Show(dx.id.ToString());
              dx.nom_cat = dvgclient.Rows[row].Cells[1].Value.ToString();*/

        }

        private void Btnexcel_Click(object sender, EventArgs e)
        {

            System.Data.DataTable db = new System.Data.DataTable();
            Categorie p = new Categorie();
            using (SaveFileDialog SFD = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", ValidateNames = true })
            {
                if (SFD.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                    Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet ws = (Worksheet)app.ActiveSheet;

                    app.Visible = false;
                    ws.Cells[1, 1] = "Id Categorie";
                    ws.Cells[1, 2] = "Nom Categoriet";

                    List<Categorie> l = p.FindAll();
                    int i = 2;

                    foreach (Categorie le in l)
                    {
                        ws.Cells[i, 1] = le.id;
                        ws.Cells[i, 2] = le.nom_cat;

                    }
                    wb.SaveAs(SFD.FileName);
                    app.Quit();
                    MessageBox.Show("sauvgarde avec succees dans Excel", "Excel", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void Btnajouter_Click(object sender, EventArgs e)
        {
            PL.FRM_Ajouter_Modifie_Categorie frmCat = new PL.FRM_Ajouter_Modifie_Categorie(this);
            frmCat.ShowDialog();
        }

        private void Btnsuprimer_Click(object sender, EventArgs e)
        {
            if (dx == null)
            {
                MessageBox.Show("aucun Categorie selectionner");
            }
            else
            {
                DialogResult r = MessageBox.Show("voulez vous supprimer", "Suppresion", MessageBoxButtons.YesNo, MessageBoxIcon.Question); ;
                if (r == DialogResult.Yes)
                {
                    Categorie p = new Categorie();
                    MessageBox.Show(dx.nom_cat);
                    p.delete(dx);
                    Actualisedatagrid();

                    MessageBox.Show("suppresion avec succées ");
                }
                else
                {
                    MessageBox.Show("suppresion annuler ");
                }

            }
        }

        private void Txtrecherche_Enter(object sender, EventArgs e)
        {
            if (txtrecherche.Text == "Recherche")
            {
                txtrecherche.Text = "";
                txtrecherche.ForeColor = Color.Black;
            }
        }

        private void Btnmodifier_Click(object sender, EventArgs e)
        {
            PL.FRM_Ajouter_Modifie_Categorie frmCat = new PL.FRM_Ajouter_Modifie_Categorie(this);
            frmCat.lblTiTre.Text = "Modifier Categorie";

            frmCat.txtNom.Text = dx.nom_cat;
            


            frmCat.ShowDialog();
        }
    }
}
