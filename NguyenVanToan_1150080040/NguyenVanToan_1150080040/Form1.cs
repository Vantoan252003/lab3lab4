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
    public class Form1 : Form
    {
        private Label lblTitle;
        private Label lblA;
        private Label lblB;
        private Label lblKetQua;
        private TextBox txtA;
        private TextBox txtB;
        private TextBox txtKetQua;
        private Button btnCong;
        private Button btnTru;
        private Button btnNhan;
        private Button btnChia;
        private Button btnXoa;
        private Button btnThoat;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
        
            this.lblTitle = new Label();
            this.lblA = new Label();
            this.lblB = new Label();
            this.lblKetQua = new Label();
            this.txtA = new TextBox();
            this.txtB = new TextBox();
            this.txtKetQua = new TextBox();
            this.btnCong = new Button();
            this.btnTru = new Button();
            this.btnNhan = new Button();
            this.btnChia = new Button();
            this.btnXoa = new Button();
            this.btnThoat = new Button();

            this.SuspendLayout();

     
            this.Text = "Thực hành 1";
            this.ClientSize = new Size(460, 320);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(240, 240, 240);

  
            this.lblTitle.Text = "THỰC HIỆN CÁC PHÉP TÍNH SỐ HỌC";
            this.lblTitle.Font = new Font("Arial", 14F, FontStyle.Bold);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(70, 25);
            this.lblTitle.ForeColor = Color.FromArgb(51, 51, 51);

       
            this.lblA.Text = "Nhập số a:";
            this.lblA.Font = new Font("Arial", 10F);
            this.lblA.AutoSize = true;
            this.lblA.Location = new Point(50, 80);
            this.lblA.ForeColor = Color.FromArgb(51, 51, 51);

            this.txtA.Location = new Point(150, 77);
            this.txtA.Size = new Size(250, 23);
            this.txtA.Font = new Font("Arial", 10F);
            this.txtA.BorderStyle = BorderStyle.FixedSingle;

            this.lblB.Text = "Nhập số b:";
            this.lblB.Font = new Font("Arial", 10F);
            this.lblB.AutoSize = true;
            this.lblB.Location = new Point(50, 120);
            this.lblB.ForeColor = Color.FromArgb(51, 51, 51);


            this.txtB.Location = new Point(150, 117);
            this.txtB.Size = new Size(250, 23);
            this.txtB.Font = new Font("Arial", 10F);
            this.txtB.BorderStyle = BorderStyle.FixedSingle;


            this.btnCong.Text = "Cộng";
            this.btnCong.Font = new Font("Arial", 10F);
            this.btnCong.Location = new Point(50, 170);
            this.btnCong.Size = new Size(80, 35);
            this.btnCong.BackColor = Color.FromArgb(230, 230, 230);
            this.btnCong.FlatStyle = FlatStyle.Popup;
            this.btnCong.Cursor = Cursors.Hand;
            this.btnCong.Click += new EventHandler(this.btnCong_Click);

            this.btnTru.Text = "Trừ";
            this.btnTru.Font = new Font("Arial", 10F);
            this.btnTru.Location = new Point(150, 170);
            this.btnTru.Size = new Size(80, 35);
            this.btnTru.BackColor = Color.FromArgb(230, 230, 230);
            this.btnTru.FlatStyle = FlatStyle.Popup;
            this.btnTru.Cursor = Cursors.Hand;
            this.btnTru.Click += new EventHandler(this.btnTru_Click);


            this.btnNhan.Text = "Nhân";
            this.btnNhan.Font = new Font("Arial", 10F);
            this.btnNhan.Location = new Point(250, 170);
            this.btnNhan.Size = new Size(80, 35);
            this.btnNhan.BackColor = Color.FromArgb(230, 230, 230);
            this.btnNhan.FlatStyle = FlatStyle.Popup;
            this.btnNhan.Cursor = Cursors.Hand;
            this.btnNhan.Click += new EventHandler(this.btnNhan_Click);

 
            this.btnChia.Text = "Chia";
            this.btnChia.Font = new Font("Arial", 10F);
            this.btnChia.Location = new Point(350, 170);
            this.btnChia.Size = new Size(80, 35);
            this.btnChia.BackColor = Color.FromArgb(230, 230, 230);
            this.btnChia.FlatStyle = FlatStyle.Popup;
            this.btnChia.Cursor = Cursors.Hand;
            this.btnChia.Click += new EventHandler(this.btnChia_Click);

       
            this.lblKetQua.Text = "Kết quả:";
            this.lblKetQua.Font = new Font("Arial", 10F);
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Location = new Point(50, 230);
            this.lblKetQua.ForeColor = Color.FromArgb(51, 51, 51);


            this.txtKetQua.Location = new Point(150, 227);
            this.txtKetQua.Size = new Size(250, 23);
            this.txtKetQua.Font = new Font("Arial", 10F);
            this.txtKetQua.BorderStyle = BorderStyle.FixedSingle;
            this.txtKetQua.ReadOnly = true;
            this.txtKetQua.BackColor = Color.FromArgb(248, 248, 248);

            // Các button chức năng - hàng 2
            // btnXoa
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Font = new Font("Arial", 10F);
            this.btnXoa.Location = new Point(150, 270);
            this.btnXoa.Size = new Size(80, 35);
            this.btnXoa.BackColor = Color.FromArgb(255, 193, 7);
            this.btnXoa.FlatStyle = FlatStyle.Popup;
            this.btnXoa.Cursor = Cursors.Hand;
            this.btnXoa.ForeColor = Color.White;
            this.btnXoa.Click += new EventHandler(this.btnXoa_Click);

            // btnThoat
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Font = new Font("Arial", 10F);
            this.btnThoat.Location = new Point(250, 270);
            this.btnThoat.Size = new Size(80, 35);
            this.btnThoat.BackColor = Color.FromArgb(220, 53, 69);
            this.btnThoat.FlatStyle = FlatStyle.Popup;
            this.btnThoat.Cursor = Cursors.Hand;
            this.btnThoat.ForeColor = Color.White;
            this.btnThoat.Click += new EventHandler(this.btnThoat_Click);

            // Thêm tất cả controls vào form
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblA);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.btnCong);
            this.Controls.Add(this.btnTru);
            this.Controls.Add(this.btnNhan);
            this.Controls.Add(this.btnChia);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.txtKetQua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThoat);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Hàm kiểm tra và lấy số từ textbox
        private bool LayGiaTri(out double a, out double b)
        {
            bool hopLe1 = double.TryParse(txtA.Text.Trim(), out a);
            bool hopLe2 = double.TryParse(txtB.Text.Trim(), out b);

            if (!hopLe1 || !hopLe2)
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ!", "Lỗi nhập liệu",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // Event handler cho button Cộng
        private void btnCong_Click(object sender, EventArgs e)
        {
            if (LayGiaTri(out double a, out double b))
            {
                double ketQua = a + b;
                txtKetQua.Text = ketQua.ToString("0.####");
            }
        }

        // Event handler cho button Trừ
        private void btnTru_Click(object sender, EventArgs e)
        {
            if (LayGiaTri(out double a, out double b))
            {
                double ketQua = a - b;
                txtKetQua.Text = ketQua.ToString("0.####");
            }
        }

        // Event handler cho button Nhân
        private void btnNhan_Click(object sender, EventArgs e)
        {
            if (LayGiaTri(out double a, out double b))
            {
                double ketQua = a * b;
                txtKetQua.Text = ketQua.ToString("0.####");
            }
        }

        // Event handler cho button Chia
        private void btnChia_Click(object sender, EventArgs e)
        {
            if (LayGiaTri(out double a, out double b))
            {
                if (b == 0)
                {
                    MessageBox.Show("Không thể chia cho 0!", "Lỗi toán học",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                double ketQua = a / b;
                txtKetQua.Text = ketQua.ToString("0.####");
            }
        }

        // Event handler cho button Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtA.Clear();
            txtB.Clear();
            txtKetQua.Clear();
            txtA.Focus(); // Đặt con trở về ô nhập đầu tiên
        }

        // Event handler cho button Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Đặt focus vào textbox đầu tiên khi form load
            txtA.Focus();
        }
    }
}