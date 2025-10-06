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
    public class Form2 : Form
    {
        private GroupBox grpNhapDuLieu;
        private GroupBox grpTuyChon;
        private Label lblA;
        private Label lblB;
        private Label lblKetQua;
        private TextBox txtA;
        private TextBox txtB;
        private TextBox txtKetQua;
        private RadioButton rdoUSCLN;
        private RadioButton rdoBSCNN;
        private Button btnTim;
        private Button btnThoat;

        public Form2()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Khởi tạo các controls
            this.grpNhapDuLieu = new GroupBox();
            this.grpTuyChon = new GroupBox();
            this.lblA = new Label();
            this.lblB = new Label();
            this.lblKetQua = new Label();
            this.txtA = new TextBox();
            this.txtB = new TextBox();
            this.txtKetQua = new TextBox();
            this.rdoUSCLN = new RadioButton();
            this.rdoBSCNN = new RadioButton();
            this.btnTim = new Button();
            this.btnThoat = new Button();

            this.SuspendLayout();

            // Thiết lập Form
            this.Text = "Tìm USCLN và BSCNN của số nguyên a và b";
            this.ClientSize = new Size(480, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(245, 245, 245);

            // GroupBox Nhập dữ liệu
            this.grpNhapDuLieu.Text = "Nhập dữ liệu:";
            this.grpNhapDuLieu.Font = new Font("Arial", 10F, FontStyle.Bold);
            this.grpNhapDuLieu.Location = new Point(20, 20);
            this.grpNhapDuLieu.Size = new Size(280, 120);
            this.grpNhapDuLieu.BackColor = Color.FromArgb(144, 238, 144); // Màu xanh lá nhạt

            // Label và TextBox cho số a
            this.lblA.Text = "Số nguyên a:";
            this.lblA.Font = new Font("Arial", 10F);
            this.lblA.Location = new Point(20, 35);
            this.lblA.AutoSize = true;
            this.lblA.BackColor = Color.Transparent;

            this.txtA.Location = new Point(120, 32);
            this.txtA.Size = new Size(140, 23);
            this.txtA.Font = new Font("Arial", 10F);

            // Label và TextBox cho số b
            this.lblB.Text = "Số nguyên b:";
            this.lblB.Font = new Font("Arial", 10F);
            this.lblB.Location = new Point(20, 70);
            this.lblB.AutoSize = true;
            this.lblB.BackColor = Color.Transparent;

            this.txtB.Location = new Point(120, 67);
            this.txtB.Size = new Size(140, 23);
            this.txtB.Font = new Font("Arial", 10F);

            // Thêm controls vào GroupBox Nhập dữ liệu
            this.grpNhapDuLieu.Controls.Add(this.lblA);
            this.grpNhapDuLieu.Controls.Add(this.txtA);
            this.grpNhapDuLieu.Controls.Add(this.lblB);
            this.grpNhapDuLieu.Controls.Add(this.txtB);

            // GroupBox Tùy chọn
            this.grpTuyChon.Text = "Tùy chọn:";
            this.grpTuyChon.Font = new Font("Arial", 10F, FontStyle.Bold);
            this.grpTuyChon.Location = new Point(320, 20);
            this.grpTuyChon.Size = new Size(140, 120);
            this.grpTuyChon.BackColor = Color.FromArgb(211, 211, 211); // Màu xám nhạt

            // RadioButton USCLN
            this.rdoUSCLN.Text = "USCLN";
            this.rdoUSCLN.Font = new Font("Arial", 10F);
            this.rdoUSCLN.Location = new Point(20, 35);
            this.rdoUSCLN.AutoSize = true;
            this.rdoUSCLN.BackColor = Color.Transparent;
            this.rdoUSCLN.Checked = true; // Mặc định chọn USCLN

            // RadioButton BSCNN
            this.rdoBSCNN.Text = "BSCNN";
            this.rdoBSCNN.Font = new Font("Arial", 10F);
            this.rdoBSCNN.Location = new Point(20, 70);
            this.rdoBSCNN.AutoSize = true;
            this.rdoBSCNN.BackColor = Color.Transparent;

            // Thêm RadioButton vào GroupBox Tùy chọn
            this.grpTuyChon.Controls.Add(this.rdoUSCLN);
            this.grpTuyChon.Controls.Add(this.rdoBSCNN);

            // Label Kết quả
            this.lblKetQua.Text = "Kết quả:";
            this.lblKetQua.Font = new Font("Arial", 10F, FontStyle.Bold);
            this.lblKetQua.Location = new Point(20, 160);
            this.lblKetQua.AutoSize = true;

            // TextBox Kết quả
            this.txtKetQua.Location = new Point(20, 185);
            this.txtKetQua.Size = new Size(280, 23);
            this.txtKetQua.Font = new Font("Arial", 10F);
            this.txtKetQua.ReadOnly = true;
            this.txtKetQua.BackColor = Color.White;

            // Button Tìm
            this.btnTim.Text = "Tìm";
            this.btnTim.Font = new Font("Arial", 10F, FontStyle.Bold);
            this.btnTim.Location = new Point(360, 185);
            this.btnTim.Size = new Size(80, 30);
            this.btnTim.BackColor = Color.FromArgb(173, 216, 230); // Màu xanh nhạt
            this.btnTim.FlatStyle = FlatStyle.Popup;
            this.btnTim.Cursor = Cursors.Hand;
            this.btnTim.Click += new EventHandler(this.btnTim_Click);

            // Button Thoát
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Font = new Font("Arial", 10F, FontStyle.Bold);
            this.btnThoat.Location = new Point(360, 230);
            this.btnThoat.Size = new Size(80, 30);
            this.btnThoat.BackColor = Color.FromArgb(255, 182, 193); // Màu hồng nhạt
            this.btnThoat.FlatStyle = FlatStyle.Popup;
            this.btnThoat.Cursor = Cursors.Hand;
            this.btnThoat.Click += new EventHandler(this.btnThoat_Click);

            // Thêm tất cả controls vào form
            this.Controls.Add(this.grpNhapDuLieu);
            this.Controls.Add(this.grpTuyChon);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.txtKetQua);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.btnThoat);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Hàm tính USCLN (Ước số chung lớn nhất)
        private int TinhUSCLN(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // Hàm tính BSCNN (Bội số chung nhỏ nhất)
        private int TinhBSCNN(int a, int b)
        {
            if (a == 0 || b == 0) return 0;

            int uscln = TinhUSCLN(a, b);
            return Math.Abs(a * b) / uscln;
        }

        // Hàm kiểm tra và lấy số nguyên từ textbox
        private bool LayGiaTri(out int a, out int b)
        {
            bool hopLe1 = int.TryParse(txtA.Text.Trim(), out a);
            bool hopLe2 = int.TryParse(txtB.Text.Trim(), out b);

            if (!hopLe1 || !hopLe2)
            {
                MessageBox.Show("Vui lòng nhập số nguyên hợp lệ!", "Lỗi nhập liệu",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (a == 0 && b == 0)
            {
                MessageBox.Show("Không thể tính USCLN và BSCNN khi cả hai số đều bằng 0!", "Lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // Event handler cho button Tìm
        private void btnTim_Click(object sender, EventArgs e)
        {
            if (LayGiaTri(out int a, out int b))
            {
                int ketQua;
                string loaiPhepTinh;

                if (rdoUSCLN.Checked)
                {
                    ketQua = TinhUSCLN(a, b);
                    loaiPhepTinh = "USCLN";
                }
                else
                {
                    ketQua = TinhBSCNN(a, b);
                    loaiPhepTinh = "BSCNN";
                }

                txtKetQua.Text = $"{loaiPhepTinh}({a}, {b}) = {ketQua}";
            }
        }

        // Event handler cho button Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            txtA.Focus();
        }
    }
}