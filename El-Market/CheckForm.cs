using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace El_Market
{
    public partial class CheckForm : Form
    {
        public CheckForm()
        {
            InitializeComponent();
        }
        int Grdtotal = 0, n = 0;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\OfficeTracker\El-Market\OfficeDB.mdf;Integrated Security=True");
        private void populate()
        {
            con.Open();
            string query = "select ItemName,ItemCond from ItemsTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ItemDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void populatebills()
        {
            con.Open();
            string query = "select * from BillsTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BillsDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void FillCategory()
        {
            //This Method will bind the Combobox with the Database
            con.Open();
            SqlCommand cmd = new SqlCommand("select CatName from CategoriesTbl", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CatName", typeof(string));
            dt.Load(rdr);
            //cbSearchCategory.ValueMember = "CatName";
            //cbSearchCategory.DataSource = dt;
            cbSelectCategory.ValueMember = "CatName";
            cbSelectCategory.DataSource = dt;
            con.Close();
        }
        private void Selling_Form_Load(object sender, EventArgs e)
        {
            populate();
            populatebills();
            FillCategory();
            lblStaffName.Text = Login.StaffUsername;
        }

        private void ItemDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtItemName.Text = ItemDGV.SelectedRows[0].Cells[0].Value.ToString();
            txtItemQuantity.Text = ItemDGV.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            lblDate.Text = DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtBillID.Text == "")
            {
                MessageBox.Show("Missing Bill Id");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into BillsTbl values(" + txtBillID.Text + ",'" + lblStaffName.Text + "','" + lblDate.Text + "'," + lblAmount.Text + ")";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Order Added Successfully");
                    con.Close();
                    populatebills();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("El-Market", new Font("Century Gothic", 25, FontStyle.Bold), Brushes.Red, new Point(230));
            e.Graphics.DrawString("Bill ID:" + BillsDGV.SelectedRows[0].Cells[0].Value.ToString(), new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Blue, new Point(100, 70));
            e.Graphics.DrawString("Staff Name:" + BillsDGV.SelectedRows[0].Cells[1].Value.ToString(), new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Blue, new Point(100, 100));
            e.Graphics.DrawString("Bill Date:" + BillsDGV.SelectedRows[0].Cells[2].Value.ToString(), new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Blue, new Point(100, 130));
            e.Graphics.DrawString("Total Amount:" + BillsDGV.SelectedRows[0].Cells[3].Value.ToString(), new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Blue, new Point(100, 160));
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (PrintPreviewDialog.ShowDialog() == DialogResult.OK)
            {
                PrintDocument.Print();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void cbSelectCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            con.Open();
            string query = "select ItemName,ItemQty from ItemsTbl where ItemCategory='" + cbSelectCategory.SelectedValue.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ItemDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            StaffForm Sell = new StaffForm();
            Sell.Show();
            this.Hide();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            CategoriesForm Cat = new CategoriesForm();
            Cat.Show();
            this.Hide();
        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            InventoryForm Prod = new InventoryForm();
            Prod.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (txtItemName.Text == "" || txtItemQuantity.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                int total = Convert.ToInt32(txtItemPrice.Text) * Convert.ToInt32(txtItemQuantity.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(OrdersDGV);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = txtItemName.Text;
                newRow.Cells[2].Value = txtItemQuantity.Text;
                newRow.Cells[3].Value = txtItemPrice.Text;
                newRow.Cells[4].Value = Convert.ToInt32(txtItemPrice.Text) * Convert.ToInt32(txtItemQuantity.Text);
                OrdersDGV.Rows.Add(newRow);
                n++;
                Grdtotal = Grdtotal + total;
                lblAmount.Text = "" + Grdtotal;
            }
        }
    }
}
