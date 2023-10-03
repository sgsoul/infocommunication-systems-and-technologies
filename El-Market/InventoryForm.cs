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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace El_Market
{
    public partial class InventoryForm : Form
    {
        public InventoryForm()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\OfficeTracker\El-Market\OfficeDB.mdf;Integrated Security=True");
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "insert into ItemsTbl values(" + txtItemID.Text + ",'" + txtItemName.Text + "'," + txtItemCond.Text + "," + txtItemQty.Text + ",'" + cbSelectCategory.SelectedValue.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Item Added Successfully");
                con.Close();
                populate();
                txtItemID.Text = "";
                txtItemName.Text = "";
                txtItemCond.Text = "";
                txtItemQty.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
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
            cbSearchCategory.ValueMember = "CatName";
            cbSearchCategory.DataSource = dt;
            cbSelectCategory.ValueMember = "CatName";
            cbSelectCategory.DataSource = dt;
            con.Close();
        }

        //private void FillStatus()
        //{
        //    //This Method will bind the Combobox with the Database
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("select StatusName from StatusTbl", con);
        //    SqlDataReader rdr;
        //    rdr = cmd.ExecuteReader();
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("StatusName", typeof(string));
        //    dt.Load(rdr);
        //    cbSelectStatus.ValueMember = "StatusName";
        //    cbSelectStatus.DataSource = dt;
        //    con.Close();
        //}
        private void populate()
        {
            con.Open();
            string query = "select * from ItemsTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ItemsDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void Item_Form_Load(object sender, EventArgs e)
        {
            FillCategory();
            //FillStatus();
            populate();
        }

        private void ItemsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtItemID.Text = ItemsDGV.SelectedRows[0].Cells[0].Value.ToString();
            txtItemName.Text = ItemsDGV.SelectedRows[0].Cells[1].Value.ToString();
            txtItemCond.Text = ItemsDGV.SelectedRows[0].Cells[2].Value.ToString();
            txtItemQty.Text = ItemsDGV.SelectedRows[0].Cells[3].Value.ToString();
            cbSelectCategory.SelectedValue = ItemsDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtItemID.Text == "" || txtItemName.Text == "" || txtItemCond.Text == "" || txtItemQty.Text == "")
                {
                    MessageBox.Show("Missing Information");

                }
                else
                {
                    con.Open();
                    string query = "update ItemsTbl set ItemName='" + txtItemName.Text + "',ItemCond=" + txtItemCond.Text + ",ItemQty=" + txtItemQty.Text + ",ItemCategory='" + cbSelectCategory.SelectedValue.ToString() + "' where ItemId=" + txtItemID.Text + "; ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item Successfully Updated");
                    con.Close();
                    populate();
                    txtItemID.Text = "";
                    txtItemName.Text = "";
                    txtItemCond.Text = "";
                    txtItemQty.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtItemID.Text == "")
                {
                    MessageBox.Show("Select the Item to Delete");
                }
                else
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "delete from ItemsTbl where ItemId=" + txtItemID.Text + "";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item deleted successfully");
                    con.Close();
                    populate();
                    txtItemID.Text = "";
                    txtItemName.Text = "";
                    txtItemCond.Text = "";
                    txtItemQty.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void cbSearchCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void btnSelling_Click(object sender, EventArgs e)
        {
            CheckForm sell = new CheckForm();
            sell.Show();
            this.Hide();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            CategoriesForm Cat = new CategoriesForm();
            Cat.Show();
            this.Hide();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            StaffForm Sell = new StaffForm();
            Sell.Show();
            this.Hide();
        }

        private void cbSearchCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string query = "select * from ItemsTbl where ItemCategory='" + cbSearchCategory.SelectedValue.ToString() + "'";
            //if (con.State == ConnectionState.Closed)
            //{  }
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ItemsDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
