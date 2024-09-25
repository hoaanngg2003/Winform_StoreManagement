using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLyCuaHang
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // khai bao mang doi tuong sp
        Sanpham[] listSanPham = new Sanpham[100];
        //khai bao luu thu tu sp
        int n = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        //su kien khi click vao nut add

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Tao moi mot doi tuong san pham
            Sanpham sanpham = new Sanpham();
            sanpham.Items = txtTensp.Text;
            sanpham.Origin = txtXuatxu.Text;
            sanpham.Price = txtGia.Text;
            sanpham.Quantity = txtSl.Text;
            sanpham.InputDay = txtNgaynhap.Text;
            sanpham.OutputDay = txtNgayxuat.Text;

            // dua lan luot doi tuong vao
            listSanPham[n] = sanpham;
            n++;
            txtTensp.Clear();
            txtXuatxu.Clear();
            txtGia.Clear();
            txtSl.Clear();
            display();
        }
        public void display()
        {
            dgvCuahang.DataSource = null;
            dgvCuahang.DataSource = listSanPham;
            dgvCuahang.Refresh();
        }
       
        int index;
        private void dgvCuahang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lay chi muc tung dong
            index = e.RowIndex;
            //Hien thi thong tin tung dong
            txtTensp.Text = listSanPham[index].Items.ToString();
            txtXuatxu.Text = listSanPham[index].Origin.ToString();
            txtGia.Text = listSanPham[index].Price.ToString();
            txtSl.Text = listSanPham[index].Quantity.ToString();
            txtNgaynhap.Text = listSanPham[index].InputDay.ToString();
            txtNgayxuat.Text = listSanPham[index].InputDay.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ textbox đưa vào  dgv
            listSanPham[index].Items = txtTensp.Text;
            listSanPham[index].Origin = txtXuatxu.Text;
            listSanPham[index].Price = txtGia.Text;
            listSanPham[index].Quantity = txtSl.Text;
            listSanPham[index].InputDay = txtNgaynhap.Text;
            listSanPham[index].OutputDay = txtNgayxuat.Text;
            dgvCuahang.DataSource = null;
            dgvCuahang.DataSource = listSanPham;
            dgvCuahang.Refresh();

        }
        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool alert;
            alert = MessageBox.Show("Do you want to Delete?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK;
            if (alert)
            {
                //Khi xóa thì phần tử vị trí thứ index sẽ bị thay thể bởi phần tử thứ index+1
                while (index < n)
                {
                    listSanPham[index] = listSanPham[index + 1];
                    index++;
                }
            }
            listSanPham[n - 1] = null;
            n = n - 1;

            dgvCuahang.DataSource = null;
            dgvCuahang.DataSource = listSanPham;
            dgvCuahang.Refresh();
        }
        private void btnLogout_Click_1(object sender, EventArgs e)
        {

            DialogResult l = DialogResult;
            l = MessageBox.Show("Do you want to log out?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (l == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


    }
}
