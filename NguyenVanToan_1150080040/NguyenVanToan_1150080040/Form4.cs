using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NguyenVanToan_1150080040
{
    public class Form4 : Form
    {
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblTenKhachHang;
        private TextBox txtTenKhachHang;
        private Label lblDichVu;
        private CheckBox chkLayCaoRang;
        private CheckBox chkTayTrangRang;
        private CheckBox chkHanRang;
        private CheckBox chkBeRang;
        private CheckBox chkBocRang;
        private Label lblGiaLayCao;
        private Label lblGiaTayTrang;
        private Label lblGiaHanRang;
        private Label lblGiaBeRang;
        private Label lblGiaBocRang;
        private NumericUpDown numHanRang;
        private NumericUpDown numBeRang;
        private NumericUpDown numBocRang;
        private Label lblChucNang;
        private Button btnTinhTien;
        private TextBox txtKetQua;
        private Button btnThoat;

        public Form4()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Khởi tạo controls
            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.lblTenKhachHang = new Label();
            this.txtTenKhachHang = new TextBox();
            this.lblDichVu = new Label();
            this.chkLayCaoRang = new CheckBox();
            this.chkTayTrangRang = new CheckBox();
            this.chkHanRang = new CheckBox();
            this.chkBeRang = new CheckBox();
            this.chkBocRang = new CheckBox();
            this.lblGiaLayCao = new Label();
            this.lblGiaTayTrang = new Label();
            this.lblGiaHanRang = new Label();
            this.lblGiaBeRang = new Label();
            this.lblGiaBocRang = new Label();
            this.numHanRang = new NumericUpDown();
            this.numBeRang = new NumericUpDown();
            this.numBocRang = new NumericUpDown();
            this.lblChucNang = new Label();
            this.btnTinhTien = new Button();
            this.txtKetQua = new TextBox();
            this.btnThoat = new Button();

            this.SuspendLayout();

            // Thiết lập Form
            this.Text = "Form1";
            this.ClientSize = new Size(600, 520);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.White;

            // Panel Header (màu xanh lá)
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Size = new Size(600, 80);
            this.pnlHeader.BackColor = Color.FromArgb(0, 180, 0);

            // Label Title
            this.lblTitle.Text = "PHÒNG KHÁM NHA KHOA HẢI ÂU";
            this.lblTitle.Font = new Font("Arial", 20F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(60, 25);

            this.pnlHeader.Controls.Add(this.lblTitle);

            // Label Tên khách hàng
            this.lblTenKhachHang.Text = "Tên khách hàng:";
            this.lblTenKhachHang.Font = new Font("Arial", 10F);
            this.lblTenKhachHang.Location = new Point(30, 100);
            this.lblTenKhachHang.AutoSize = true;

            // TextBox Tên khách hàng
            this.txtTenKhachHang.Location = new Point(165, 97);
            this.txtTenKhachHang.Size = new Size(300, 23);
            this.txtTenKhachHang.Font = new Font("Arial", 10F);

            // Label Dịch vụ tại phòng khám
            this.lblDichVu.Text = "Dịch vụ tại phòng khám:";
            this.lblDichVu.Font = new Font("Arial", 10F, FontStyle.Bold);
            this.lblDichVu.Location = new Point(30, 140);
            this.lblDichVu.AutoSize = true;

            // CheckBox Lấy cao răng
            this.chkLayCaoRang.Text = "Lấy cao răng";
            this.chkLayCaoRang.Font = new Font("Arial", 10F);
            this.chkLayCaoRang.Location = new Point(90, 175);
            this.chkLayCaoRang.AutoSize = true;

            this.lblGiaLayCao.Text = "50.000đ/2 hàm";
            this.lblGiaLayCao.Font = new Font("Arial", 10F);
            this.lblGiaLayCao.Location = new Point(310, 175);
            this.lblGiaLayCao.AutoSize = true;

            // CheckBox Tẩy trắng răng
            this.chkTayTrangRang.Text = "Tẩy trắng răng";
            this.chkTayTrangRang.Font = new Font("Arial", 10F);
            this.chkTayTrangRang.Location = new Point(90, 210);
            this.chkTayTrangRang.AutoSize = true;
            this.chkTayTrangRang.Checked = true; // Mặc định chọn

            this.lblGiaTayTrang.Text = "100.000đ/2 hàm";
            this.lblGiaTayTrang.Font = new Font("Arial", 10F);
            this.lblGiaTayTrang.Location = new Point(310, 210);
            this.lblGiaTayTrang.AutoSize = true;

            // CheckBox Hàn răng
            this.chkHanRang.Text = "Hàn răng";
            this.chkHanRang.Font = new Font("Arial", 10F);
            this.chkHanRang.Location = new Point(90, 245);
            this.chkHanRang.AutoSize = true;

            this.lblGiaHanRang.Text = "100.000đ/1 răng";
            this.lblGiaHanRang.Font = new Font("Arial", 10F);
            this.lblGiaHanRang.Location = new Point(310, 245);
            this.lblGiaHanRang.AutoSize = true;

            this.numHanRang.Location = new Point(480, 243);
            this.numHanRang.Size = new Size(60, 23);
            this.numHanRang.Font = new Font("Arial", 10F);
            this.numHanRang.Minimum = 1;
            this.numHanRang.Maximum = 32;
            this.numHanRang.Value = 1;

            // CheckBox Bẻ răng
            this.chkBeRang.Text = "Bẻ răng";
            this.chkBeRang.Font = new Font("Arial", 10F);
            this.chkBeRang.Location = new Point(90, 280);
            this.chkBeRang.AutoSize = true;

            this.lblGiaBeRang.Text = "10.000đ/1 răng";
            this.lblGiaBeRang.Font = new Font("Arial", 10F);
            this.lblGiaBeRang.Location = new Point(310, 280);
            this.lblGiaBeRang.AutoSize = true;

            this.numBeRang.Location = new Point(480, 278);
            this.numBeRang.Size = new Size(60, 23);
            this.numBeRang.Font = new Font("Arial", 10F);
            this.numBeRang.Minimum = 1;
            this.numBeRang.Maximum = 32;
            this.numBeRang.Value = 1;

            // CheckBox Bọc răng
            this.chkBocRang.Text = "Bọc răng";
            this.chkBocRang.Font = new Font("Arial", 10F);
            this.chkBocRang.Location = new Point(90, 315);
            this.chkBocRang.AutoSize = true;

            this.lblGiaBocRang.Text = "1.000.000đ/1 răng";
            this.lblGiaBocRang.Font = new Font("Arial", 10F);
            this.lblGiaBocRang.Location = new Point(310, 315);
            this.lblGiaBocRang.AutoSize = true;

            this.numBocRang.Location = new Point(480, 313);
            this.numBocRang.Size = new Size(60, 23);
            this.numBocRang.Font = new Font("Arial", 10F);
            this.numBocRang.Minimum = 1;
            this.numBocRang.Maximum = 32;
            this.numBocRang.Value = 1;

            // Label Chức năng
            this.lblChucNang.Text = "Chức năng:";
            this.lblChucNang.Font = new Font("Arial", 10F, FontStyle.Bold);
            this.lblChucNang.Location = new Point(30, 360);
            this.lblChucNang.AutoSize = true;

            // Button Tính tiền
            this.btnTinhTien.Text = "Tính tiền";
            this.btnTinhTien.Font = new Font("Arial", 10F, FontStyle.Bold);
            this.btnTinhTien.Location = new Point(90, 395);
            this.btnTinhTien.Size = new Size(100, 35);
            this.btnTinhTien.BackColor = Color.FromArgb(230, 230, 230);
            this.btnTinhTien.FlatStyle = FlatStyle.Popup;
            this.btnTinhTien.Cursor = Cursors.Hand;
            this.btnTinhTien.Click += new EventHandler(this.btnTinhTien_Click);

            // TextBox Kết quả
            this.txtKetQua.Location = new Point(240, 395);
            this.txtKetQua.Size = new Size(180, 35);
            this.txtKetQua.Font = new Font("Arial", 12F, FontStyle.Bold);
            this.txtKetQua.ReadOnly = true;
            this.txtKetQua.BackColor = Color.White;
            this.txtKetQua.TextAlign = HorizontalAlignment.Center;
            this.txtKetQua.Multiline = true;

            // Button Thoát
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Font = new Font("Arial", 10F, FontStyle.Bold);
            this.btnThoat.Location = new Point(470, 395);
            this.btnThoat.Size = new Size(100, 35);
            this.btnThoat.BackColor = Color.FromArgb(230, 230, 230);
            this.btnThoat.FlatStyle = FlatStyle.Popup;
            this.btnThoat.Cursor = Cursors.Hand;
            this.btnThoat.Click += new EventHandler(this.btnThoat_Click);

            // Thêm tất cả controls vào form
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblTenKhachHang);
            this.Controls.Add(this.txtTenKhachHang);
            this.Controls.Add(this.lblDichVu);
            this.Controls.Add(this.chkLayCaoRang);
            this.Controls.Add(this.lblGiaLayCao);
            this.Controls.Add(this.chkTayTrangRang);
            this.Controls.Add(this.lblGiaTayTrang);
            this.Controls.Add(this.chkHanRang);
            this.Controls.Add(this.lblGiaHanRang);
            this.Controls.Add(this.numHanRang);
            this.Controls.Add(this.chkBeRang);
            this.Controls.Add(this.lblGiaBeRang);
            this.Controls.Add(this.numBeRang);
            this.Controls.Add(this.chkBocRang);
            this.Controls.Add(this.lblGiaBocRang);
            this.Controls.Add(this.numBocRang);
            this.Controls.Add(this.lblChucNang);
            this.Controls.Add(this.btnTinhTien);
            this.Controls.Add(this.txtKetQua);
            this.Controls.Add(this.btnThoat);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Hàm tính tổng tiền
        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            // Kiểm tra tên khách hàng
            if (string.IsNullOrWhiteSpace(txtTenKhachHang.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!", "Cảnh báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKhachHang.Focus();
                return;
            }

            // Kiểm tra có chọn dịch vụ nào không
            if (!chkLayCaoRang.Checked && !chkTayTrangRang.Checked &&
                !chkHanRang.Checked && !chkBeRang.Checked && !chkBocRang.Checked)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một dịch vụ!", "Cảnh báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tính tổng tiền
            decimal tongTien = 0;

            if (chkLayCaoRang.Checked)
                tongTien += 50000;

            if (chkTayTrangRang.Checked)
                tongTien += 100000;

            if (chkHanRang.Checked)
                tongTien += 100000 * numHanRang.Value;

            if (chkBeRang.Checked)
                tongTien += 10000 * numBeRang.Value;

            if (chkBocRang.Checked)
                tongTien += 1000000 * numBocRang.Value;

            // Hiển thị kết quả
            txtKetQua.Text = string.Format("{0:N0} VNĐ", tongTien);

            // Hiển thị thông báo chi tiết
            StringBuilder chiTiet = new StringBuilder();
            chiTiet.AppendLine($"Khách hàng: {txtTenKhachHang.Text}");
            chiTiet.AppendLine("\nDịch vụ đã chọn:");

            if (chkLayCaoRang.Checked)
                chiTiet.AppendLine("• Lấy cao răng: 50,000đ");

            if (chkTayTrangRang.Checked)
                chiTiet.AppendLine("• Tẩy trắng răng: 100,000đ");

            if (chkHanRang.Checked)
                chiTiet.AppendLine($"• Hàn răng: 100,000đ x {numHanRang.Value} = {100000 * numHanRang.Value:N0}đ");

            if (chkBeRang.Checked)
                chiTiet.AppendLine($"• Bẻ răng: 10,000đ x {numBeRang.Value} = {10000 * numBeRang.Value:N0}đ");

            if (chkBocRang.Checked)
                chiTiet.AppendLine($"• Bọc răng: 1,000,000đ x {numBocRang.Value} = {1000000 * numBocRang.Value:N0}đ");

            chiTiet.AppendLine($"\nTổng cộng: {tongTien:N0} VNĐ");

            MessageBox.Show(chiTiet.ToString(), "Hóa đơn thanh toán",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Hàm thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            txtTenKhachHang.Focus();
        }
    }
}