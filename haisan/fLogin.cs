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

namespace haisan
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }
        
        SqlConnection Conn = new SqlConnection(@"Data Source=HUNG123;Initial Catalog=QuanLyQuanHaiSan;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void fLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtTK.Text;
            string password = txtMK.Text;

            try
            {
                string query = "SELECT * FROM Account where UserName = '"+ txtTK.Text + "' and PassWord = '"+ txtMK.Text + "'";
                Conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, Conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if(dt.Rows.Count > 0)
                {
                    username = txtTK.Text.Trim();
                    password = txtMK.Text.Trim();

                    //fTableManager f = new fTableManager();
                    //f.Show();
                    //this.Hide();

                    SqlCommand cmd = new SqlCommand(query, Conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int Type = Convert.ToInt32(reader["Type"]);

                        if (Type == 1)
                        {
                            fTableManager f = new fTableManager();
                            f.Show();
                            this.Hide();
                        }
                        else if (Type == 2)
                        {
                            fQuanlithongtin f = new fQuanlithongtin();
                            f.Show();
                            this.Hide();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Sai thông tin đăng nhập!!!", "Err", MessageBoxButtons.OK, MessageBoxIcon.Error );

                    txtTK.Clear();
                    txtMK.Clear();

                    txtTK.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Đăng nhập thất bại!!!" + ex.Message);
            }
            finally
            {
                Conn.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtTK_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
//TULAHOÀNG\SQLEXPRESS