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
    public partial class CategoriesForm : Form
    {
        public CategoriesForm()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\OfficeTracker\El-Market\OfficeDB.mdf;Integrated Security=True"); 
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void populate()
        {
            con.Open();
            string query = "select * from CategoriesTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CategoriesDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "insert into CategoriesTbl values(" + txtCategoryID.Text + ",'" + txtCategoryName.Text + "','" + txtCategoryDesc.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category Added Successfully");
                con.Close();
                populate();
                txtCategoryID.Text = "";
                txtCategoryName.Text = "";
                txtCategoryDesc.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Category_Form_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void CategoriesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCategoryID.Text = CategoriesDGV.SelectedRows[0].Cells[0].Value.ToString();
            txtCategoryName.Text = CategoriesDGV.SelectedRows[0].Cells[1].Value.ToString();
            txtCategoryDesc.Text = CategoriesDGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCategoryID.Text == "" || txtCategoryName.Text == "" || txtCategoryDesc.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    con.Open();
                    string query = "update CategoriesTbl set CatName='" + txtCategoryName.Text + "',CatDesc='" + txtCategoryDesc.Text + "' where CatId=" + txtCategoryID.Text + "";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category has been updated Successfully");
                    con.Close();
                    populate();
                    txtCategoryID.Text = "";
                    txtCategoryName.Text = "";
                    txtCategoryDesc.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void btnSellers_Click(object sender, EventArgs e)
        {
            StaffForm Sell = new StaffForm();
            Sell.Show();
            this.Hide();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            InventoryForm Prod = new InventoryForm();
            Prod.Show();
            this.Hide();
        }

        private void btnSelling_Click(object sender, EventArgs e)
        {
            CheckForm sell = new CheckForm();
            sell.Show();
            this.Hide();
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtCategoryID.Text == "")
                {
                    MessageBox.Show("Select Category Id to Delete");
                }
                else
                {
                    con.Open();
                    string query = "delete from CategoriesTbl where CatId=" + txtCategoryID.Text + "";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category has been deleted successfully");
                    con.Close();
                    populate();
                    txtCategoryID.Text = "";
                    txtCategoryName.Text = "";
                    txtCategoryDesc.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
