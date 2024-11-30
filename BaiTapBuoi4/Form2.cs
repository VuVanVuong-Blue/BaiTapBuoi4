using System.Windows.Forms;
using System;

namespace BaiTapBuoi4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public string MSNV
        {
            get { return txtMaNV.Text; }
            set { txtMaNV.Text = value; }
        }

        public string TenNV
        {
            get { return txtHoTen.Text; }
            set { txtHoTen.Text = value; }
        }

        public string LuongCB
        {
            get { return txtLuong.Text; }
            set { txtLuong.Text = value; }
        }

        private void bntDongy_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu trước khi đóng
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) ||
                string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtLuong.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo");
            }
            else
            {
                // Xác nhận trả dữ liệu về form chính
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void bntBoqua_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
