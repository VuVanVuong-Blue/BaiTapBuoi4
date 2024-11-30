using System.Windows.Forms;
using System;

namespace BaiTapBuoi4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void bntThem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();

            // Truyền các giá trị rỗng nếu là thêm mới nhân viên
            form2.MSNV = "";
            form2.TenNV = "";
            form2.LuongCB = "";

            if (form2.ShowDialog() == DialogResult.OK)
            {
                // Khi nhấn OK, lấy các giá trị và thêm vào DataGridView
                string msnv = form2.MSNV;
                string tenNV = form2.TenNV;
                string luongCB = form2.LuongCB;

                // Thêm dòng vào DataGridView
                dataGridView1.Rows.Add(msnv, tenNV, luongCB);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // Đảm bảo rằng các cột được thêm vào DataGridView trước khi thêm dòng
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("MSNV", "Mã Số Nhân Viên");
                dataGridView1.Columns.Add("TenNV", "Tên Nhân Viên");
                dataGridView1.Columns.Add("LuongCB", "Lương Cơ Bản");
            }
        }
      
        private void bntXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn trong DataGridView không
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Hiển thị thông báo xác nhận khi xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Xóa dòng được chọn
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                }
            }
            else
            {
                // Nếu không có dòng nào được chọn, hiển thị thông báo yêu cầu chọn nhân viên
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa.", "Thông báo");
            }
        }

        private void bntDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bntSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                Form2 form2 = new Form2();

                // Gán giá trị của dòng được chọn vào Form2 để chỉnh sửa
                form2.MSNV = selectedRow.Cells[0].Value.ToString();
                form2.TenNV = selectedRow.Cells[1].Value.ToString();
                form2.LuongCB = selectedRow.Cells[2].Value.ToString();

                if (form2.ShowDialog() == DialogResult.OK)
                {
                    // Khi nhấn OK, cập nhật lại giá trị trong dòng được chọn
                    selectedRow.Cells[0].Value = form2.MSNV;
                    selectedRow.Cells[1].Value = form2.TenNV;
                    selectedRow.Cells[2].Value = form2.LuongCB;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để chỉnh sửa.", "Thông báo");
            }
        }
    }
}
