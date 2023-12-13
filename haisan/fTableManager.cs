using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using haisan.DAO;
using haisan.DTO;

namespace haisan
{
    public partial class fTableManager : Form
    {
        public fTableManager()
        {
            InitializeComponent();
            LoadTable();
            LoadCategory();
        }

        private string username;
        public fTableManager(string username)
        {
            InitializeComponent();
            this.username = username;
            HienThiXinChao();
        }

        private void HienThiXinChao()
        {
            lblXinChao.Text = $"Xin chào, {username}!";
        }

        private void fTableManager_Load(object sender, EventArgs e)
        {
            LoadTable();

        }
        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cbDanhmuc.DataSource = listCategory;
            cbDanhmuc.DisplayMember = "Name";
        }
        void LoadFoodListByCategoryID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryID(id);
            cbMonan.DataSource = listFood;
            cbMonan.DisplayMember = "Name";
        }
        void LoadTable()
        {
            flpBanan.Controls.Clear();
            List<Table> tableList = TableDAO.Instance.LoadTableList();

            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;

                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.LightBlue;
                        break;
                    default:
                        btn.BackColor = Color.DarkRed;
                        break;
                }

                flpBanan.Controls.Add(btn);
            }
        }
        void ShowBill(int id)
        {
            
            lsvBill.Items.Clear();
            List<haisan.DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            float totalPrice = 0;

            foreach (haisan.DTO.Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lsvBill.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");

            txbTotalPrice.Text = totalPrice.ToString("c", culture);
            
        }
        
        void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            string totalPriceText = txbTotalPrice.Text;

            // Sử dụng CultureInfo để chuyển đổi chuỗi định dạng tiền về số
            CultureInfo culture = new CultureInfo("vi-VN");
            double totalPrice;

            if (double.TryParse(totalPriceText, NumberStyles.Currency, culture, out totalPrice))
            {
                if (idBill != -1)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn thanh toán hóa đơn cho: " + table.Name, "Thông báo", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        BillDAO.Instance.CheckOut(idBill, (float)totalPrice);
                        ShowBill(table.ID);

                        LoadTable();
                    }
                }
            }
            else
            {
                MessageBox.Show("Giá trị không hợp lệ.");
            }
        }

        private void btnInhoadon_Click(object sender, EventArgs e)
        {

        }

        private void mnQuanlithongtin_Click(object sender, EventArgs e)
        {
            Close();

            fQuanlithongtin f = new fQuanlithongtin();
            Hide();
            f.ShowDialog();
            Show();
        }

        private void mnQuanlibanan_Click(object sender, EventArgs e)
        {

        }

        private void fTableManager_Load_1(object sender, EventArgs e)
        {
            LoadTable();
            LoadCategory();
        }

        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có thực sự muốn thoát không???", "Hộp thoại", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtTongtien_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbDanhmuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            Category selected = cb.SelectedItem as Category;
            id = selected.ID;

            LoadFoodListByCategoryID(id);
        }
        
        private void btnThemmon_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;

            if (table == null)
            {
                MessageBox.Show("Hãy chọn bàn");
                return;
            }

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int foodID = (cbMonan.SelectedItem as Food).ID;
            int count = (int)nmMonan.Value;

            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), foodID, count);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, count);
            }

            ShowBill(table.ID);

            LoadTable();
        }
        
    }
}
