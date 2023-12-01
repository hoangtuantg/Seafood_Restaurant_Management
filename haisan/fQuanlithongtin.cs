using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace haisan
{
    public partial class fQuanlithongtin : Form
    {
        public fQuanlithongtin()
        {
            InitializeComponent();
        }
        string ConnStr = "Data Source=HUNG123;Initial Catalog=QuanLyQuanHaiSan;Integrated Security=True";
        SqlConnection Conn = new SqlConnection("Data Source=HUNG123;Initial Catalog=QuanLyQuanHaiSan;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        private string username;
        public fQuanlithongtin(string username)
        {
            InitializeComponent();
            this.username = username;
            HienThiXinChao();
        }

        private void HienThiXinChao()
        {
            lblXinChao.Text = $"Xin chào, {username}!";
        }
        private void mnQuanlibanan_Click(object sender, EventArgs e)
        {
            fTableManager f = new fTableManager();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có thực sự muốn thoát không???", "Hộp thoại", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void fQuanlithongtin_Load(object sender, EventArgs e)
        {
            HienThiDanhSachNhanVien();
            HienThiDanhSachMonAn();
        }

        // Ham mo ket noi
        private void MoKetNoi()
        {
            if (Conn == null)
            {
                Conn = new SqlConnection(ConnStr);
            }
            if (Conn.State == ConnectionState.Closed)
            {
                Conn.Open();
            }
        }
        // Ham dong ket noi
        private void DongKetNoi()
        {
            if (Conn != null && Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
        }


        private void HienThiDanhSachNhanVien()
        {
            MoKetNoi();
            string query = "select * from Staff";

            using (SqlCommand cmd = new SqlCommand(query, Conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Xóa dữ liệu cũ trong ListView
                    lsvDanhSachNhanVien.Items.Clear();

                    // Duyệt qua dữ liệu và thêm vào ListView
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["id"].ToString());
                        item.SubItems.Add(reader["name"].ToString());
                        item.SubItems.Add(reader["UserName"].ToString());
                        item.SubItems.Add(reader["PassWord"].ToString());
                        item.SubItems.Add(reader["Gender"].ToString());
                        item.SubItems.Add(reader["Dob"].ToString());
                        item.SubItems.Add(reader["Phone"].ToString());
                        item.SubItems.Add(reader["Role"].ToString());

                        lsvDanhSachNhanVien.Items.Add(item);
                    }
                }
            }
        }
        private void HienThiDanhSachMonAn()
        {
            MoKetNoi();
            string query = "select * from Food";

            using (SqlCommand cmd = new SqlCommand(query, Conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Xóa dữ liệu cũ trong ListView
                    lsvDanhSachMonAn.Items.Clear();

                    // Duyệt qua dữ liệu và thêm vào ListView
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["id"].ToString());
                        item.SubItems.Add(reader["name"].ToString());
                        item.SubItems.Add(reader["idCategory"].ToString());
                        item.SubItems.Add(reader["price"].ToString());

                        lsvDanhSachMonAn.Items.Add(item);
                    }
                }
            }
        }



        private void btnThemNV_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {

        }



        private void btnXoaNV_Click(object sender, EventArgs e)
        {

        }

        private void btnTimkiemMonAn_Click(object sender, EventArgs e)
        {
            try
            {
                // Chuỗi truy vấn SQL SELECT với điều kiện WHERE
                string query = "SELECT * FROM Food WHERE name LIKE @timMon";
                MoKetNoi();

                // Tạo đối tượng SqlCommand
                using (SqlCommand cmd = new SqlCommand(query, Conn))
                {

                    // Thêm tham số cho truy vấn SQL để tránh SQL Injection
                    cmd.Parameters.AddWithValue("@timMon", "%" + txtTimKiemMonAn.Text + "%");

                    // Sử dụng SqlDataReader để đọc dữ liệu từ cơ sở dữ liệu
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Xóa dữ liệu cũ trong ListView
                        lsvDanhSachMonAn.Items.Clear();

                        // Duyệt qua dữ liệu và thêm vào ListView
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["id"].ToString());
                            item.SubItems.Add(reader["name"].ToString());
                            item.SubItems.Add(reader["idCategory"].ToString());
                            item.SubItems.Add(reader["price"].ToString());

                            lsvDanhSachMonAn.Items.Add(item);

                        }
                    }
                }
            }
            catch 
            {
                if(txtTimKiemMonAn.Text == "")
                {
                    MessageBox.Show("Trường nhập thông tin tìm kiếm bị trống!!!");
                }
            }

 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tpNhanvien_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtTenNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void lsvDanhSachMonAn_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
