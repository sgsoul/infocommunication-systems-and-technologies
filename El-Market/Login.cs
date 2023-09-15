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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public static string StaffUsername = "";
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\OfficeTracker\El-Market\OfficeDB.mdf;Integrated Security=True");
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please Enter the Username and Password");
            }
            else
            {
                if (cbSelectRole.SelectedIndex > -1)
                {
                    if (cbSelectRole.SelectedItem.ToString() == "Admin")
                    {
                        if (txtUsername.Text == "Admin" && txtPassword.Text == "Admin")
                        {
                            InventoryForm Prod = new InventoryForm();
                            Prod.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("If You are Admin, Enter the Correct Username and Password");
                        }
                    }
                    else
                    {
                        //MessageBox.Show("You are in the Staff Section");
                        con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter("select count(*) from StaffTbl where StaffUsername='" + txtUsername.Text + "' and StaffPassword='" + txtPassword.Text + "'", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            StaffUsername = txtUsername.Text;
                            CheckForm sell = new CheckForm();
                            sell.Show();
                            this.Hide();
                            con.Close();
                        }
                        else
                        {
                            MessageBox.Show("Wrong Username and Password");
                        }
                        con.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Select the Role to Login");
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }
    }
}
