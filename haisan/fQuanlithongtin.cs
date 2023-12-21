﻿using System;
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
using haisan.DAO;
using haisan.DTO;

namespace haisan
{
    public partial class fQuanlithongtin : Form
    {
        public fQuanlithongtin()
        {
            InitializeComponent();
        }
        private string ConnStr = "Data Source=HUNG123;Initial Catalog=QuanLyQuanHaiSan;Integrated Security=True";
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
            // Đặt Items cho ComboBoxQuyenHan
            cboQuyen.Items.Add(new Tuple<string>("Admin"));
            cboQuyen.Items.Add(new Tuple<string>("User"));

            // Thiết lập thuộc tính ValueMember và DisplayMember
            cboQuyen.ValueMember = "Value";
            cboQuyen.DisplayMember = "Key";

            lsvDanhSachNhanVien.SelectedIndexChanged += new EventHandler(lsvDanhSachNhanVien_SelectedIndexChanged);


            // Đặt Items cho ComboBoxDanhMuc
            cbDanhmuc.Items.Add("1");
            cbDanhmuc.Items.Add("2");
            cbDanhmuc.Items.Add("3");

            LoadDateTimePickerBill();
            LoadListBillByDate(dtpFromDate.Value, dtpToDate.Value);
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

        //Hàm xóa dữ liệu
        private void XoaDuLieu()
        {
            //Nhân viên
            txtTenNV.Text = string.Empty;
            txtTaikhoan.Text = string.Empty;
            txtMatkhau.Text = string.Empty;
            rdbtnNam.Checked = false;
            rdbtnNu.Checked = false;
            dateTimePicker1.Value = DateTime.Now;
            txtSDT.Text = string.Empty;
            cboQuyen.SelectedIndex = -1;

            //Món ăn
            txtMonAn.Clear();
            cbDanhmuc.SelectedIndex = -1;
            txtGia.Clear();
        }


        //======================Quản lý món ăn======================================
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

        private void btnThemMonAn_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các controls trên giao diện
                string tenMonAn = txtMonAn.Text;
                int categoryId = Convert.ToInt32(cbDanhmuc.SelectedItem);
                string price = txtGia.Text;

                // Kiểm tra xem có thông tin đầy đủ không
                if (string.IsNullOrEmpty(tenMonAn) || categoryId <= 0 || string.IsNullOrEmpty(price))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin món ăn, danh mục và giá.", "Thông báo");
                    return;
                }
                MoKetNoi();

                // Chuẩn bị câu truy vấn SQL INSERT
                string query = "INSERT INTO Food (name, idCategory, price) VALUES (@tenMonAn, @categoryId, @price)";

                // Tạo đối tượng SqlCommand
                using (SqlCommand cmd = new SqlCommand(query, Conn))
                {
                    // Thêm tham số cho truy vấn SQL để tránh SQL Injection
                    cmd.Parameters.Add("@tenMonAn", SqlDbType.NVarChar).Value = tenMonAn;
                    cmd.Parameters.Add("@categoryId", SqlDbType.Int).Value = categoryId;
                    cmd.Parameters.Add("@price", SqlDbType.Float).Value = price;

                    // Thực thi câu truy vấn và lấy ID của món ăn vừa thêm
                    cmd.ExecuteNonQuery();

                    // Hiển thị thông báo thành công
                    MessageBox.Show("Thêm món ăn thành công.", "Thông báo");

                    // Sau khi thêm, làm mới danh sách món ăn
                    HienThiDanhSachMonAn();
                }
                XoaDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi");
            }
            finally
            {
                // Đóng kết nối
                DongKetNoi();
            }
        }

        private void lsvDanhSachMonAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvDanhSachMonAn.SelectedItems.Count > 0)
            {
                // Lấy thông tin của món ăn được chọn
                ListViewItem selectedItem = lsvDanhSachMonAn.SelectedItems[0];
                string idMonAn = selectedItem.SubItems[0].Text; 
                string tenMonAn = selectedItem.SubItems[1].Text; 
                string idCategory = selectedItem.SubItems[2].Text; 
                string gia = selectedItem.SubItems[3].Text; 

                // Hiển thị thông tin món ăn trong các controls trên giao diện
                txtMonAn.Text = tenMonAn;
                cbDanhmuc.SelectedItem = idCategory; 
                txtGia.Text = gia;
            }
        }

        private void btnSuaMonAn_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có món ăn được chọn hay không
                if (lsvDanhSachMonAn.SelectedItems.Count > 0)
                {
                    // Lấy thông tin của món ăn được chọn
                    ListViewItem selectedItem = lsvDanhSachMonAn.SelectedItems[0];
                    int idMonAn = int.Parse(selectedItem.SubItems[0].Text); 

                    // Lấy thông tin mới từ các controls trên giao diện
                    string tenMonAnMoi = txtMonAn.Text;
                    int categoryIdMoi = Convert.ToInt32(cbDanhmuc.SelectedItem); 
                    string giaMoi = txtGia.Text;

                    // Mở kết nối đến cơ sở dữ liệu
                    MoKetNoi();

                    // Chuẩn bị câu truy vấn SQL UPDATE
                    string query = "UPDATE Food SET name = @tenMonAn, idCategory = @categoryId, price = @gia WHERE id = @idMonAn";

                    // Tạo đối tượng SqlCommand
                    using (SqlCommand cmd = new SqlCommand(query, Conn))
                    {
                        // Thêm tham số cho truy vấn SQL để tránh SQL Injection
                        cmd.Parameters.Add("@tenMonAn", SqlDbType.NVarChar).Value = tenMonAnMoi;
                        cmd.Parameters.Add("@categoryId", SqlDbType.Int).Value = categoryIdMoi;
                        cmd.Parameters.Add("@gia", SqlDbType.Decimal).Value = giaMoi;
                        cmd.Parameters.Add("@idMonAn", SqlDbType.Int).Value = idMonAn;

                        // Thực thi câu truy vấn
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Kiểm tra xem có dòng nào được cập nhật không
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật món ăn thành công.", "Thông báo");
                            // Sau khi cập nhật, làm mới danh sách món ăn
                            HienThiDanhSachMonAn();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật món ăn không thành công.", "Thông báo");
                        }
                    }
                    XoaDuLieu();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một món ăn để sửa.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi");
            }
            finally
            {
                DongKetNoi();
            }
        }

        private void btnXoaMonAn_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn nhân viên để xóa chưa
            if (lsvDanhSachMonAn.SelectedItems.Count > 0)
            {
                // Lấy ID của nhân viên được chọn
                string idMonAn = lsvDanhSachMonAn.SelectedItems[0].SubItems[0].Text;

                // Hiển thị hộp thoại xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa món ăn này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Mở kết nối đến cơ sở dữ liệu
                        MoKetNoi();

                        // Thực hiện truy vấn xóa nhân viên từ cơ sở dữ liệu
                        string query = "DELETE FROM Food WHERE id = @idNhanVien";

                        using (SqlCommand cmd = new SqlCommand(query, Conn))
                        {
                            cmd.Parameters.AddWithValue("@idNhanVien", idMonAn);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Hiển thị thông báo xóa thành công
                                MessageBox.Show("Xóa món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Làm mới danh sách nhân viên
                                HienThiDanhSachMonAn();

                                // Làm mới các trường nhập thông tin
                                XoaDuLieu();
                            }
                            else
                            {
                                // Hiển thị thông báo lỗi nếu có vấn đề khi xóa nhân viên
                                MessageBox.Show("Có lỗi xảy ra khi xóa món ăn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        DongKetNoi();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món ăn cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimkiemMonAn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtTimKiemMonAn.Text))
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
                            if (lsvDanhSachMonAn.Items.Count == 0)
                            {
                                MessageBox.Show("Thông tin bạn đang tìm kiếm không tồn tại!!!", "Hộp thoại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                else
                {
                    HienThiDanhSachMonAn();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        //===============Quản lý nhân viên==================================
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
        private bool KiemTraSDT(string phoneNumber)
        {
            return phoneNumber.Length == 10 && phoneNumber.All(char.IsDigit);
        }
        //Thêm nhân viên
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenNV.Text) ||
                    string.IsNullOrWhiteSpace(txtTaikhoan.Text) ||
                    string.IsNullOrWhiteSpace(txtMatkhau.Text) ||
                    string.IsNullOrWhiteSpace(txtSDT.Text) ||
                    (!rdbtnNam.Checked && !rdbtnNu.Checked))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin vào các trường yêu cầu.", "Lỗi Kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MoKetNoi();

                    // Lấy thông tin nhân viên từ form
                    string tenNV = txtTenNV.Text;
                    string tenDangNhap = txtTaikhoan.Text;
                    string matKhau = txtMatkhau.Text;
                    string gioiTinh = rdbtnNam.Checked ? "Nam" : "Nữ";
                    DateTime ngaySinh = dateTimePicker1.Value;
                    string soDienThoai = txtSDT.Text;

                    if (KiemTraSDT(soDienThoai))
                    {
                        // Kiểm tra giá trị của ComboBox
                        if (cboQuyen.SelectedItem != null && cboQuyen.SelectedItem is Tuple<string> selectedQuyen)
                        {
                            string quyenHan = selectedQuyen.Item1;

                            // Thực hiện thêm nhân viên vào cơ sở dữ liệu
                            string query = "INSERT INTO Staff (name, UserName, PassWord, Gender, Dob, Phone, Role) VALUES (@tenNV, @tenDangNhap, @matKhau, @gioiTinh, @ngaySinh, @soDienThoai, @quyenHan)";

                            using (SqlCommand cmd = new SqlCommand(query, Conn))
                            {
                                cmd.Parameters.AddWithValue("@tenNV", tenNV);
                                cmd.Parameters.AddWithValue("@tenDangNhap", tenDangNhap);
                                cmd.Parameters.AddWithValue("@matKhau", matKhau);
                                cmd.Parameters.AddWithValue("@gioiTinh", gioiTinh);
                                cmd.Parameters.AddWithValue("@ngaySinh", ngaySinh);
                                cmd.Parameters.AddWithValue("@soDienThoai", soDienThoai);
                                cmd.Parameters.AddWithValue("@quyenHan", quyenHan);

                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    HienThiDanhSachNhanVien();
                                    XoaDuLieu();
                                }
                                else
                                {
                                    MessageBox.Show("Có lỗi xảy ra khi thêm nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng chọn quyền hạn cho nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập số điện thoại có 10 chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DongKetNoi();
            }
        }

        private void lsvDanhSachNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (lsvDanhSachNhanVien.SelectedItems.Count > 0)
            {
                // Lấy thông tin từ hàng đã chọn
                ListViewItem selectedRow = lsvDanhSachNhanVien.SelectedItems[0];

                // Lấy giá trị từ các cột của hàng
                string id = selectedRow.SubItems[0].Text;
                string tenNV = selectedRow.SubItems[1].Text;
                string tenDangNhap = selectedRow.SubItems[2].Text;
                string matKhau = selectedRow.SubItems[3].Text;
                string gioiTinh = selectedRow.SubItems[4].Text;
                string ngaySinh = selectedRow.SubItems[5].Text; 
                string soDienThoai = selectedRow.SubItems[6].Text;
                string quyenHan = selectedRow.SubItems[7].Text;

                // Hiển thị thông tin trong các trường nhập thông tin
                txtTenNV.Text = tenNV;
                txtTaikhoan.Text = tenDangNhap;
                txtMatkhau.Text = matKhau;
                txtSDT.Text = soDienThoai;
                // ... hiển thị các thông tin khác

                // Chọn giới tính dựa trên giá trị của cột giới tính
                if (gioiTinh == "Nam")
                {
                    rdbtnNam.Checked = true;
                    rdbtnNu.Checked = false;
                }
                else
                {
                    rdbtnNam.Checked = false;
                    rdbtnNu.Checked = true;
                }

                // Chọn quyền hạn trong ComboBox
                cboQuyen.SelectedItem = cboQuyen.Items.Cast<Tuple<string>>().FirstOrDefault(item => item.Item1 == quyenHan);

                // Chuyển đổi ngày sinh từ string sang DateTime và hiển thị nó trong DateTimePicker
                if (DateTime.TryParse(ngaySinh, out DateTime ngaySinhValue))
                {
                    dateTimePicker1.Value = ngaySinhValue;
                }
                else
                {
                    // Xử lý nếu có lỗi chuyển đổi ngày sinh
                }
            }
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvDanhSachNhanVien.SelectedItems.Count > 0)
                {
                    MoKetNoi();
                    string idNhanVien = lsvDanhSachNhanVien.SelectedItems[0].SubItems[0].Text;
                    // Lấy thông tin nhân viên từ TextBox
                    string tenNV = txtTenNV.Text;
                    string tenDangNhap = txtTaikhoan.Text;
                    string matKhau = txtMatkhau.Text;
                    string gioiTinh = rdbtnNam.Checked ? "Nam" : "Nữ";
                    DateTime ngaySinh = dateTimePicker1.Value;
                    string soDienThoai = txtSDT.Text;
                    if (KiemTraSDT(soDienThoai))
                    {
                        // Kiểm tra giá trị của ComboBox
                        if (cboQuyen.SelectedItem != null && cboQuyen.SelectedItem is Tuple<string> selectedQuyen)
                        {
                            string quyenHan = selectedQuyen.Item1;

                            // Thực hiện cập nhật thông tin nhân viên vào cơ sở dữ liệu
                            string query = "UPDATE Staff SET name = @tenNV, UserName = @tenDangNhap, PassWord = @matKhau, Gender = @gioiTinh, Dob = @ngaySinh, Phone = @soDienThoai, Role = @quyenHan WHERE id = @idNhanVien";

                            using (SqlCommand cmd = new SqlCommand(query, Conn))
                            {
                                cmd.Parameters.AddWithValue("@idNhanVien", idNhanVien);
                                cmd.Parameters.AddWithValue("@tenNV", tenNV);
                                cmd.Parameters.AddWithValue("@tenDangNhap", tenDangNhap);
                                cmd.Parameters.AddWithValue("@matKhau", matKhau);
                                cmd.Parameters.AddWithValue("@gioiTinh", gioiTinh);
                                cmd.Parameters.AddWithValue("@ngaySinh", ngaySinh);
                                cmd.Parameters.AddWithValue("@soDienThoai", soDienThoai);
                                cmd.Parameters.AddWithValue("@quyenHan", quyenHan);

                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Sửa thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Làm mới danh sách nhân viên
                                    HienThiDanhSachNhanVien();
                                    XoaDuLieu();
                                }
                                else
                                {
                                    MessageBox.Show("Có lỗi xảy ra khi sửa thông tin nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng chọn quyền hạn cho nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập số điện thoại có 10 chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DongKetNoi();
            }
        }



        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn nhân viên để xóa chưa
            if (lsvDanhSachNhanVien.SelectedItems.Count > 0)
            {
                // Lấy ID của nhân viên được chọn
                string idNhanVien = lsvDanhSachNhanVien.SelectedItems[0].SubItems[0].Text;

                // Hiển thị hộp thoại xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Mở kết nối đến cơ sở dữ liệu
                        MoKetNoi();

                        // Thực hiện truy vấn xóa nhân viên từ cơ sở dữ liệu
                        string query = "DELETE FROM Staff WHERE id = @idNhanVien";

                        using (SqlCommand cmd = new SqlCommand(query, Conn))
                        {
                            cmd.Parameters.AddWithValue("@idNhanVien", idNhanVien);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Hiển thị thông báo xóa thành công
                                MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Làm mới danh sách nhân viên
                                HienThiDanhSachNhanVien();

                                // Làm mới các trường nhập thông tin
                                XoaDuLieu();
                            }
                            else
                            {
                                // Hiển thị thông báo lỗi nếu có vấn đề khi xóa nhân viên
                                MessageBox.Show("Có lỗi xảy ra khi xóa nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        DongKetNoi();
                    }
                }
            }
            else
            {
                // Hiển thị thông báo nếu chưa chọn nhân viên để xóa
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtTimKiemNhanVien.Text))
                {
                    // Chuỗi truy vấn SQL SELECT với điều kiện WHERE
                    string query = "SELECT * FROM Staff WHERE name LIKE @timNV";
                    MoKetNoi();

                    // Tạo đối tượng SqlCommand
                    using (SqlCommand cmd = new SqlCommand(query, Conn))
                    {

                        // Thêm tham số cho truy vấn SQL để tránh SQL Injection
                        cmd.Parameters.AddWithValue("@timNV", "%" + txtTimKiemNhanVien.Text + "%");

                        // Sử dụng SqlDataReader để đọc dữ liệu từ cơ sở dữ liệu
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

                            if (lsvDanhSachNhanVien.Items.Count == 0)
                            {
                                MessageBox.Show("Thông tin bạn đang tìm kiếm không tồn tại!!!", "Hộp thoại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                else
                {
                    HienThiDanhSachNhanVien();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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


        //============Danh sách hóa đơn=============================
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpToDate.Value = dtpFromDate.Value.AddMonths(1).AddDays(-1);
        }
        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dgvBill.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
        }
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpFromDate.Value, dtpToDate.Value);
        }

    }
}
