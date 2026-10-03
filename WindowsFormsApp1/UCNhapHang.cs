using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class UCNhapHang : UserControl
    {
        public UCNhapHang()
        {
            InitializeComponent();
        }private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDonNhap.Columns.Add("MaDon", "Mã Đơn");
            dgvDonNhap.Columns.Add("NgayNhap", "Ngày Nhập");
            dgvDonNhap.Columns.Add("NhaCungCap", "Nhà cung cấp");
            dgvDonNhap.Columns.Add("TongTien", "Tổng tiền (VND)");
            dgvDonNhap.Columns.Add("TrangThai", "Trạng thái");

            DataGridViewButtonColumn actionColumn =
                new DataGridViewButtonColumn();

            actionColumn.Name = "ThaoTac";
            actionColumn.HeaderText = "Thao tác";
            actionColumn.Text = "View/Edit";
            actionColumn.UseColumnTextForButtonValue = true;

            dgvDonNhap.Columns.Add(actionColumn);
        }
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Tìm kiếm đơn nhập, nhà cung cấp...")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Tìm kiếm đơn nhập, nhà cung cấp...";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
