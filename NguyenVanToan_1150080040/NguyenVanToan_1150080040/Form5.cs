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
    public class Form5 : Form
    {
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblUsername;
        private Label lblPassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnDangNhap;
        private Button btnThoat;
        private CheckBox chkShowPassword;
        private PictureBox picUser;
        private PictureBox picLock;

        // Thông tin đăng nhập mẫu (có thể thay đổi)
        private Dictionary<string, string> accounts;

        public Form5()
        {
            InitializeComponent();
            InitializeAccounts();
        }

        private void InitializeAccounts()
        {
            // Tạo một số tài khoản mẫu
            accounts = new Dictionary<string, string>
            {
                {"admin", "admin123"},
                {"user", "user123"},
                {"vantoan", "vantoan@123"}
            };
        }

        private void InitializeComponent()
        {
            // Khởi tạo controls
            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.lblUsername = new Label();
            this.lblPassword = new Label();
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.btnDangNhap = new Button();
            this.btnThoat = new Button();
            this.chkShowPassword = new CheckBox();
            this.picUser = new PictureBox();
            this.picLock = new PictureBox();

            this.SuspendLayout();

            // Thiết lập Form
            this.Text = "Đăng nhập";
            this.ClientSize = new Size(450, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.White;

            // Panel Header
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Size = new Size(450, 100);
            this.pnlHeader.BackColor = Color.FromArgb(41, 128, 185);

            // Label Title
            this.lblTitle.Text = "ĐĂNG NHẬP HỆ THỐNG";
            this.lblTitle.Font = new Font("Arial", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(90, 35);

            this.pnlHeader.Controls.Add(this.lblTitle);

            // PictureBox User Icon
            this.picUser.Location = new Point(50, 145);
            this.picUser.Size = new Size(30, 30);
            this.picUser.BackColor = Color.FromArgb(52, 152, 219);

            // Label Username
            this.lblUsername.Text = "Tên đăng nhập:";
            this.lblUsername.Font = new Font("Arial", 11F, FontStyle.Bold);
            this.lblUsername.Location = new Point(90, 130);
            this.lblUsername.AutoSize = true;
            this.lblUsername.ForeColor = Color.FromArgb(52, 73, 94);

            // TextBox Username
            this.txtUsername.Location = new Point(90, 155);
            this.txtUsername.Size = new Size(300, 25);
            this.txtUsername.Font = new Font("Arial", 11F);
            this.txtUsername.BorderStyle = BorderStyle.FixedSingle;

            // PictureBox Lock Icon
            this.picLock.Location = new Point(50, 215);
            this.picLock.Size = new Size(30, 30);
            this.picLock.BackColor = Color.FromArgb(231, 76, 60);

            // Label Password
            this.lblPassword.Text = "Mật khẩu:";
            this.lblPassword.Font = new Font("Arial", 11F, FontStyle.Bold);
            this.lblPassword.Location = new Point(90, 200);
            this.lblPassword.AutoSize = true;
            this.lblPassword.ForeColor = Color.FromArgb(52, 73, 94);

            // TextBox Password
            this.txtPassword.Location = new Point(90, 225);
            this.txtPassword.Size = new Size(300, 25);
            this.txtPassword.Font = new Font("Arial", 11F);
            this.txtPassword.BorderStyle = BorderStyle.FixedSingle;
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.KeyPress += new KeyPressEventHandler(this.txtPassword_KeyPress);

            // CheckBox Show Password
            this.chkShowPassword.Text = "Hiển thị mật khẩu";
            this.chkShowPassword.Font = new Font("Arial", 9F);
            this.chkShowPassword.Location = new Point(90, 260);
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.ForeColor = Color.FromArgb(127, 140, 141);
            this.chkShowPassword.CheckedChanged += new EventHandler(this.chkShowPassword_CheckedChanged);

            // Button Đăng nhập
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.Font = new Font("Arial", 11F, FontStyle.Bold);
            this.btnDangNhap.Location = new Point(90, 305);
            this.btnDangNhap.Size = new Size(140, 40);
            this.btnDangNhap.BackColor = Color.FromArgb(46, 204, 113);
            this.btnDangNhap.ForeColor = Color.White;
            this.btnDangNhap.FlatStyle = FlatStyle.Flat;
            this.btnDangNhap.FlatAppearance.BorderSize = 0;
            this.btnDangNhap.Cursor = Cursors.Hand;
            this.btnDangNhap.Click += new EventHandler(this.btnDangNhap_Click);

            // Button Thoát
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Font = new Font("Arial", 11F, FontStyle.Bold);
            this.btnThoat.Location = new Point(250, 305);
            this.btnThoat.Size = new Size(140, 40);
            this.btnThoat.BackColor = Color.FromArgb(231, 76, 60);
            this.btnThoat.ForeColor = Color.White;
            this.btnThoat.FlatStyle = FlatStyle.Flat;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.Cursor = Cursors.Hand;
            this.btnThoat.Click += new EventHandler(this.btnThoat_Click);

            // Thêm tất cả controls vào form
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.picUser);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.picLock);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.chkShowPassword);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.btnThoat);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Xử lý hiển thị/ẩn mật khẩu
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0'; // Hiển thị mật khẩu
            }
            else
            {
                txtPassword.PasswordChar = '●'; // Ẩn mật khẩu
            }
        }

        // Xử lý nhấn Enter ở ô password
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }

        // Hàm kiểm tra validation
        private bool KiemTraDuLieu()
        {
            // Kiểm tra username trống
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Cảnh báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            // Kiểm tra password trống
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Cảnh báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            // Kiểm tra độ dài username
            if (txtUsername.Text.Trim().Length < 3)
            {
                MessageBox.Show("Tên đăng nhập phải có ít nhất 3 ký tự!", "Cảnh báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            // Kiểm tra độ dài password
            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", "Cảnh báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            return true;
        }

        // Xử lý sự kiện đăng nhập
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // Kiểm tra validation
            if (!KiemTraDuLieu())
            {
                return;
            }

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Kiểm tra thông tin đăng nhập
            if (accounts.ContainsKey(username) && accounts[username] == password)
            {
                MessageBox.Show($"Đăng nhập thành công!\nChào mừng {username}!", "Thành công",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ở đây có thể mở form chính của ứng dụng
                // Form mainForm = new MainForm();
                // mainForm.Show();
                // this.Hide();

                // Hoặc đóng form login
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Đăng nhập thất bại",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Xóa mật khẩu và focus lại
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        // Xử lý sự kiện thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // Focus vào ô username khi form load
            txtUsername.Focus();

            // Hiển thị thông tin tài khoản mẫu (chỉ để test, xóa khi deploy thật)
            StringBuilder info = new StringBuilder();
            info.AppendLine("Tài khoản mẫu để test:");
            info.AppendLine();
            foreach (var account in accounts)
            {
                info.AppendLine($"Username: {account.Key}");
                info.AppendLine($"Password: {account.Value}");
                info.AppendLine();
            }

            // Có thể hiển thị hoặc comment dòng này khi không cần
            // MessageBox.Show(info.ToString(), "Thông tin test", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}