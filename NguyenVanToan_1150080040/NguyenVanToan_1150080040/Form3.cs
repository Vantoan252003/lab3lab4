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
    public class Form3 : Form
    {
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblKeyboard;
        private Button btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9;
        private Button btnClear, btnEnter, btnRing;
        private Label lblLoginLog;
        private ListView listViewLog;

        // Dictionary chứa password và tên nhóm
        private Dictionary<string, string> validPasswords;

        public Form3()
        {
            InitializeComponent();
            InitializePasswords();
        }

        private void InitializePasswords()
        {
            validPasswords = new Dictionary<string, string>
            {
                {"1496", "Phát triển công nghệ"},
                {"2673", "Phát triển công nghệ"},
                {"7462", "Nghiên cứu viên"},
                {"8884", "Thiết kế mô hình"},
                {"3842", "Thiết kế mô hình"},
                {"3383", "Thiết kế mô hình"}
            };
        }

        private void InitializeComponent()
        {
            // Khởi tạo controls
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            this.lblKeyboard = new Label();
            this.btn1 = new Button();
            this.btn2 = new Button();
            this.btn3 = new Button();
            this.btn4 = new Button();
            this.btn5 = new Button();
            this.btn6 = new Button();
            this.btn7 = new Button();
            this.btn8 = new Button();
            this.btn9 = new Button();
            this.btnClear = new Button();
            this.btnEnter = new Button();
            this.btnRing = new Button();
            this.lblLoginLog = new Label();
            this.listViewLog = new ListView();

            this.SuspendLayout();

            // Thiết lập Form
            this.Text = "Form1";
            this.ClientSize = new Size(520, 480);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(240, 240, 240);

            // Label Password
            this.lblPassword.Text = "Password:";
            this.lblPassword.Font = new Font("Arial", 12F, FontStyle.Bold);
            this.lblPassword.Location = new Point(20, 30);
            this.lblPassword.AutoSize = true;

            // TextBox Password
            this.txtPassword.Location = new Point(170, 60);
            this.txtPassword.Size = new Size(250, 23);
            this.txtPassword.Font = new Font("Arial", 12F);
            this.txtPassword.BorderStyle = BorderStyle.Fixed3D;
            this.txtPassword.ReadOnly = true;
            this.txtPassword.BackColor = Color.White;

            // Label Keyboard
            this.lblKeyboard.Text = "Keyboard:";
            this.lblKeyboard.Font = new Font("Arial", 12F, FontStyle.Bold);
            this.lblKeyboard.Location = new Point(20, 100);
            this.lblKeyboard.AutoSize = true;

            // Tạo bàn phím số (3x3)
            int startX = 180;
            int startY = 130;
            int buttonSize = 40;
            int spacing = 10;

            // Hàng 1: 1, 2, 3
            this.btn1.Text = "1";
            this.btn1.Size = new Size(buttonSize, buttonSize);
            this.btn1.Location = new Point(startX, startY);
            this.btn1.Click += (s, e) => AddDigit("1");

            this.btn2.Text = "2";
            this.btn2.Size = new Size(buttonSize, buttonSize);
            this.btn2.Location = new Point(startX + buttonSize + spacing, startY);
            this.btn2.Click += (s, e) => AddDigit("2");

            this.btn3.Text = "3";
            this.btn3.Size = new Size(buttonSize, buttonSize);
            this.btn3.Location = new Point(startX + 2 * (buttonSize + spacing), startY);
            this.btn3.Click += (s, e) => AddDigit("3");

            // Hàng 2: 4, 5, 6
            this.btn4.Text = "4";
            this.btn4.Size = new Size(buttonSize, buttonSize);
            this.btn4.Location = new Point(startX, startY + buttonSize + spacing);
            this.btn4.Click += (s, e) => AddDigit("4");

            this.btn5.Text = "5";
            this.btn5.Size = new Size(buttonSize, buttonSize);
            this.btn5.Location = new Point(startX + buttonSize + spacing, startY + buttonSize + spacing);
            this.btn5.Click += (s, e) => AddDigit("5");

            this.btn6.Text = "6";
            this.btn6.Size = new Size(buttonSize, buttonSize);
            this.btn6.Location = new Point(startX + 2 * (buttonSize + spacing), startY + buttonSize + spacing);
            this.btn6.Click += (s, e) => AddDigit("6");

            // Hàng 3: 7, 8, 9
            this.btn7.Text = "7";
            this.btn7.Size = new Size(buttonSize, buttonSize);
            this.btn7.Location = new Point(startX, startY + 2 * (buttonSize + spacing));
            this.btn7.Click += (s, e) => AddDigit("7");

            this.btn8.Text = "8";
            this.btn8.Size = new Size(buttonSize, buttonSize);
            this.btn8.Location = new Point(startX + buttonSize + spacing, startY + 2 * (buttonSize + spacing));
            this.btn8.Click += (s, e) => AddDigit("8");

            this.btn9.Text = "9";
            this.btn9.Size = new Size(buttonSize, buttonSize);
            this.btn9.Location = new Point(startX + 2 * (buttonSize + spacing), startY + 2 * (buttonSize + spacing));
            this.btn9.Click += (s, e) => AddDigit("9");

            // Các button chức năng bên phải
            int funcButtonX = startX + 3 * (buttonSize + spacing) + 20;

            // Button Clear (màu vàng)
            this.btnClear.Text = "Clear";
            this.btnClear.Size = new Size(70, 35);
            this.btnClear.Location = new Point(funcButtonX, startY);
            this.btnClear.BackColor = Color.Yellow;
            this.btnClear.Font = new Font("Arial", 10F, FontStyle.Bold);
            this.btnClear.FlatStyle = FlatStyle.Popup;
            this.btnClear.Click += new EventHandler(this.btnClear_Click);

            // Button Enter (màu xanh lá)
            this.btnEnter.Text = "Enter";
            this.btnEnter.Size = new Size(70, 35);
            this.btnEnter.Location = new Point(funcButtonX, startY + 50);
            this.btnEnter.BackColor = Color.Lime;
            this.btnEnter.Font = new Font("Arial", 10F, FontStyle.Bold);
            this.btnEnter.FlatStyle = FlatStyle.Popup;
            this.btnEnter.Click += new EventHandler(this.btnEnter_Click);

            // Button Ring (màu đỏ)
            this.btnRing.Text = "RING";
            this.btnRing.Size = new Size(70, 35);
            this.btnRing.Location = new Point(funcButtonX, startY + 100);
            this.btnRing.BackColor = Color.Red;
            this.btnRing.ForeColor = Color.White;
            this.btnRing.Font = new Font("Arial", 10F, FontStyle.Bold);
            this.btnRing.FlatStyle = FlatStyle.Popup;
            this.btnRing.Click += new EventHandler(this.btnRing_Click);

            // Thiết lập style chung cho tất cả button số
            Button[] numberButtons = { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
            foreach (Button btn in numberButtons)
            {
                btn.Font = new Font("Arial", 12F, FontStyle.Bold);
                btn.BackColor = Color.FromArgb(230, 230, 230);
                btn.FlatStyle = FlatStyle.Popup;
                btn.Cursor = Cursors.Hand;
            }

            // Label Login Log
            this.lblLoginLog.Text = "Login Log:";
            this.lblLoginLog.Font = new Font("Arial", 12F, FontStyle.Bold);
            this.lblLoginLog.Location = new Point(20, 280);
            this.lblLoginLog.AutoSize = true;

            // ListView cho log
            this.listViewLog.Location = new Point(20, 310);
            this.listViewLog.Size = new Size(480, 150);
            this.listViewLog.View = View.Details;
            this.listViewLog.FullRowSelect = true;
            this.listViewLog.GridLines = true;
            this.listViewLog.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            // Thêm columns cho ListView
            this.listViewLog.Columns.Add("Ngày giờ", 150);
            this.listViewLog.Columns.Add("Nhóm", 200);
            this.listViewLog.Columns.Add("Kết quả", 120);

            // Thêm tất cả controls vào form
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblKeyboard);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.btnRing);
            this.Controls.Add(this.lblLoginLog);
            this.Controls.Add(this.listViewLog);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Thêm số vào password
        private void AddDigit(string digit)
        {
            if (txtPassword.Text.Length < 10) // Giới hạn độ dài password
            {
                txtPassword.Text += digit;
            }
        }

        // Xóa password
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
        }

        // Kiểm tra password và thêm log
        private void btnEnter_Click(object sender, EventArgs e)
        {
            string password = txtPassword.Text.Trim();
            string currentTime = DateTime.Now.ToString("M/d/yyyy h:mm:ss tt");

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập password!", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem item = new ListViewItem(currentTime);

            if (validPasswords.ContainsKey(password))
            {
                // Password đúng
                string groupName = validPasswords[password];
                item.SubItems.Add(groupName);
                item.SubItems.Add("Chấp nhận");
                item.BackColor = Color.LightGreen;

                MessageBox.Show($"Chào mừng {groupName}!\nTruy cập được chấp nhận.", "Truy cập thành công",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Password sai
                item.SubItems.Add("Không có");
                item.SubItems.Add("Từ chối!");
                item.BackColor = Color.LightPink;

                MessageBox.Show("Password không đúng!\nTruy cập bị từ chối.", "Truy cập thất bại",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Thêm vào đầu danh sách (mới nhất ở trên)
            listViewLog.Items.Insert(0, item);

            // Xóa password sau khi kiểm tra
            txtPassword.Clear();
        }

        // Button Ring - có thể dùng để gọi chuông hoặc báo động
        private void btnRing_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CHUÔNG BÁO ĐỘNG!\nĐã gửi tín hiệu báo động đến bảo vệ.", "Ring Alert",
                           MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            // Thêm log cho việc nhấn Ring
            string currentTime = DateTime.Now.ToString("M/d/yyyy h:mm:ss tt");
            ListViewItem item = new ListViewItem(currentTime);
            item.SubItems.Add("Thiết kế mô hình!");
            item.SubItems.Add("Chấp nhận...");
            item.BackColor = Color.LightYellow;

            listViewLog.Items.Insert(0, item);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Focus vào form khi load
            this.Focus();
        }
    }
}