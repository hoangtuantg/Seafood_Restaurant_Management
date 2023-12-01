using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace haisan
{
    public partial class fTableManager : Form
    {
        public fTableManager()
        {
            InitializeComponent();

            LoadTable();
        }

        private void fTableManager_Load(object sender, EventArgs e)
        {

        }
        void LoadTable()
        {
            //List<Table> tableList = TableDAO.Instance.LoadTableList();

            //foreach (Table item in tableList)
            {
                //Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                //btn.Text = item.Name + Environment.NewLine + item.Status;

                //switch (item.Status)
                //{
                //    case "Trống":
                 //       //btn.BackColor = Color.Silver;
                 //       break;
                 //   default:
                       // btn.BackColor = Color.DarkRed;
                 //       break;
                //}

                //flpBanan.Controls.Add(btn);
            }
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {

        }

        private void btnInhoadon_Click(object sender, EventArgs e)
        {

        }

        private void mnQuanlithongtin_Click(object sender, EventArgs e)
        {
            fQuanlithongtin f = new fQuanlithongtin();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void mnQuanlibanan_Click(object sender, EventArgs e)
        {

        }

        private void fTableManager_Load_1(object sender, EventArgs e)
        {

        }

        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            this.Close();

            
        }

        private void btnThemmon_Click(object sender, EventArgs e)
        {

        }
    }
}
