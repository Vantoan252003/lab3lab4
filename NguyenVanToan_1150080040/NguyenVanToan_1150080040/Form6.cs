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
    public class Form6 : Form
    {
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblNhapSo;
        private TextBox txtNhapSo;
        private Button btnNhapSo;
        private ListBox lstDaySo;
        private Label lblChucNang;
        private Button btnTangMoi2;
        private Button btnChonChanDau;
        private Button btnChonLeCuoi;
        private Button btnXoaDangChon;
        private Button btnXoaDau;
        private Button btnXoaCuoi;
        private Button btnKetThuc;
        private Button btnXoaDaySo;

        public Form6()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Khởi tạo controls
            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.lblNhapSo = new Label();
            this.txtNhapSo = new TextBox();
            this.btnNhapSo = new Button();
            this.lstDaySo = new ListBox();
            this.lblChucNang = new Label();
            this.btnTangMoi2 = new Button();
            this.btnChonChanDau = new Button();
            this.btnChonLeCuoi = new Button();
            this.btnXoaDangChon = new Button();
            this.btnXoaDau = new Button();
            this.btnXoaCuoi = new Button();
            this.btnKetThuc = new Button();
            this.btnXoaDaySo = new Button();

            this.SuspendLayout();

            // Thiết lập Form
            this.Text = "Form1";
            this.ClientSize = new Size(550, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(240, 248, 245);

            // Panel Header
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Size = new Size(550, 90);
            this.pnlHeader.BackColor = Color.FromArgb(0, 206, 209);

            // Label Title
            this.lblTitle.Text = "Ứng dụng xử lý dãy số";
            this.lblTitle.Font = new Font("Arial", 22F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(100, 30);

            this.pnlHeader.Controls.Add(this.lblTitle);

            // Label Nhập số nguyên
            this.lblNhapSo.Text = "Nhập số nguyên:";
            this.lblNhapSo.Font = new Font("Arial", 10F);
            this.lblNhapSo.Location = new Point(10, 115);
            this.lblNhapSo.AutoSize = true;

            // TextBox Nhập số
            this.txtNhapSo.Location = new Point(125, 112);
            this.txtNhapSo.Size = new Size(145, 23);
            this.txtNhapSo.Font = new Font("Arial", 10F);
            this.txtNhapSo.KeyPress += new KeyPressEventHandler(this.txtNhapSo_KeyPress);

            // Button Nhập số
            this.btnNhapSo.Text = "Nhập số";
            this.btnNhapSo.Font = new Font("Arial", 10F, FontStyle.Bold);
            this.btnNhapSo.Location = new Point(320, 108);
            this.btnNhapSo.Size = new Size(120, 32);
            this.btnNhapSo.BackColor = Color.FromArgb(135, 206, 250);
            this.btnNhapSo.FlatStyle = FlatStyle.Popup;
            this.btnNhapSo.Cursor = Cursors.Hand;
            this.btnNhapSo.Click += new EventHandler(this.btnNhapSo_Click);

            // ListBox Dãy số
            this.lstDaySo.Location = new Point(20, 155);
            this.lstDaySo.Size = new Size(230, 370);
            this.lstDaySo.Font = new Font("Arial", 11F);
            this.lstDaySo.SelectionMode = SelectionMode.MultiExtended;

            // Label Chức năng
            this.lblChucNang.Text = "Chức năng:";
            this.lblChucNang.Font = new Font("Arial", 10F, FontStyle.Bold);
            this.lblChucNang.Location = new Point(290, 155);
            this.lblChucNang.AutoSize = true;

            // Các button chức năng
            int btnX = 290;
            int btnY = 185;
            int btnWidth = 200;
            int btnHeight = 35;
            int btnSpacing = 45;

            // Button Tăng mỗi phần tử lên 2
            this.btnTangMoi2.Text = "Tăng mỗi phần tử lên 2";
            this.btnTangMoi2.Location = new Point(btnX, btnY);
            this.btnTangMoi2.Size = new Size(btnWidth, btnHeight);
            this.btnTangMoi2.Click += new EventHandler(this.btnTangMoi2_Click);

            // Button Chọn số chẵn đầu
            this.btnChonChanDau.Text = "Chọn số chẵn đầu";
            this.btnChonChanDau.Location = new Point(btnX, btnY + btnSpacing);
            this.btnChonChanDau.Size = new Size(btnWidth, btnHeight);
            this.btnChonChanDau.Click += new EventHandler(this.btnChonChanDau_Click);

            // Button Chọn số lẻ cuối
            this.btnChonLeCuoi.Text = "Chọn số lẻ cuối";
            this.btnChonLeCuoi.Location = new Point(btnX, btnY + btnSpacing * 2);
            this.btnChonLeCuoi.Size = new Size(btnWidth, btnHeight);
            this.btnChonLeCuoi.Click += new EventHandler(this.btnChonLeCuoi_Click);

            // Button Xóa phần tử đang chọn
            this.btnXoaDangChon.Text = "Xóa phần tử đang chọn";
            this.btnXoaDangChon.Location = new Point(btnX, btnY + btnSpacing * 3);
            this.btnXoaDangChon.Size = new Size(btnWidth, btnHeight);
            this.btnXoaDangChon.Click += new EventHandler(this.btnXoaDangChon_Click);

            // Button Xóa phần tử đầu
            this.btnXoaDau.Text = "Xóa phần tử đầu";
            this.btnXoaDau.Location = new Point(btnX, btnY + btnSpacing * 4);
            this.btnXoaDau.Size = new Size(btnWidth, btnHeight);
            this.btnXoaDau.Click += new EventHandler(this.btnXoaDau_Click);

            // Button Xóa phần tử cuối
            this.btnXoaCuoi.Text = "Xóa phần tử cuối";
            this.btnXoaCuoi.Location = new Point(btnX, btnY + btnSpacing * 5);
            this.btnXoaCuoi.Size = new Size(btnWidth, btnHeight);
            this.btnXoaCuoi.Click += new EventHandler(this.btnXoaCuoi_Click);

            // Thiết lập style chung cho các button chức năng
            Button[] funcButtons = { btnTangMoi2, btnChonChanDau, btnChonLeCuoi,
                                     btnXoaDangChon, btnXoaDau, btnXoaCuoi };
            foreach (Button btn in funcButtons)
            {
                btn.Font = new Font("Arial", 10F);
                btn.BackColor = Color.FromArgb(220, 220, 220);
                btn.FlatStyle = FlatStyle.Popup;
                btn.Cursor = Cursors.Hand;
            }

            // Button Kết thúc ứng dụng
            this.btnKetThuc.Text = "Kết thúc ứng dụng";
            this.btnKetThuc.Font = new Font("Arial", 10F, FontStyle.Bold);
            this.btnKetThuc.Location = new Point(50, 545);
            this.btnKetThuc.Size = new Size(180, 35);
            this.btnKetThuc.BackColor = Color.FromArgb(220, 53, 69);
            this.btnKetThuc.ForeColor = Color.White;
            this.btnKetThuc.FlatStyle = FlatStyle.Popup;
            this.btnKetThuc.Cursor = Cursors.Hand;
            this.btnKetThuc.Click += new EventHandler(this.btnKetThuc_Click);

            // Button Xóa dãy số
            this.btnXoaDaySo.Text = "Xóa dãy số";
            this.btnXoaDaySo.Font = new Font("Arial", 10F, FontStyle.Bold);
            this.btnXoaDaySo.Location = new Point(320, 545);
            this.btnXoaDaySo.Size = new Size(180, 35);
            this.btnXoaDaySo.BackColor = Color.FromArgb(52, 58, 64);
            this.btnXoaDaySo.ForeColor = Color.White;
            this.btnXoaDaySo.FlatStyle = FlatStyle.Popup;
            this.btnXoaDaySo.Cursor = Cursors.Hand;
            this.btnXoaDaySo.Click += new EventHandler(this.btnXoaDaySo_Click);

            // Thêm tất cả controls vào form
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblNhapSo);
            this.Controls.Add(this.txtNhapSo);
            this.Controls.Add(this.btnNhapSo);
            this.Controls.Add(this.lstDaySo);
            this.Controls.Add(this.lblChucNang);
            this.Controls.Add(this.btnTangMoi2);
            this.Controls.Add(this.btnChonChanDau);
            this.Controls.Add(this.btnChonLeCuoi);
            this.Controls.Add(this.btnXoaDangChon);
            this.Controls.Add(this.btnXoaDau);
            this.Controls.Add(this.btnXoaCuoi);
            this.Controls.Add(this.btnKetThuc);
            this.Controls.Add(this.btnXoaDaySo);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Chỉ cho nhập số và Enter
        private void txtNhapSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép: số, dấu trừ (ở đầu), Backspace, Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnNhapSo_Click(sender, e);
                e.Handled = true;
                return;
            }

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }

            // Dấu trừ chỉ được ở đầu
            if (e.KeyChar == '-' && txtNhapSo.SelectionStart != 0)
            {
                e.Handled = true;
            }
        }

        // Thêm số vào ListBox
        private void btnNhapSo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNhapSo.Text))
            {
                MessageBox.Show("Vui lòng nhập số nguyên!", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNhapSo.Focus();
                return;
            }

            if (int.TryParse(txtNhapSo.Text, out int number))
            {
                lstDaySo.Items.Add(number);
                txtNhapSo.Clear();
                txtNhapSo.Focus();
            }
            else
            {
                MessageBox.Show("Số nhập vào không hợp lệ!", "Lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNhapSo.Focus();
            }
        }

        // Tăng mỗi phần tử lên 2
        private void btnTangMoi2_Click(object sender, EventArgs e)
        {
            if (lstDaySo.Items.Count == 0)
            {
                MessageBox.Show("Danh sách rỗng!", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            for (int i = 0; i < lstDaySo.Items.Count; i++)
            {
                int value = (int)lstDaySo.Items[i];
                lstDaySo.Items[i] = value + 2;
            }

            MessageBox.Show("Đã tăng tất cả phần tử lên 2!", "Thành công",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Chọn số chẵn đầu tiên
        private void btnChonChanDau_Click(object sender, EventArgs e)
        {
            lstDaySo.ClearSelected();

            for (int i = 0; i < lstDaySo.Items.Count; i++)
            {
                int value = (int)lstDaySo.Items[i];
                if (value % 2 == 0)
                {
                    lstDaySo.SetSelected(i, true);
                    MessageBox.Show($"Đã chọn số chẵn đầu tiên: {value}", "Thông báo",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            MessageBox.Show("Không tìm thấy số chẵn trong danh sách!", "Thông báo",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Chọn số lẻ cuối cùng
        private void btnChonLeCuoi_Click(object sender, EventArgs e)
        {
            lstDaySo.ClearSelected();

            for (int i = lstDaySo.Items.Count - 1; i >= 0; i--)
            {
                int value = (int)lstDaySo.Items[i];
                if (value % 2 != 0)
                {
                    lstDaySo.SetSelected(i, true);
                    MessageBox.Show($"Đã chọn số lẻ cuối cùng: {value}", "Thông báo",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            MessageBox.Show("Không tìm thấy số lẻ trong danh sách!", "Thông báo",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Xóa phần tử đang chọn
        private void btnXoaDangChon_Click(object sender, EventArgs e)
        {
            if (lstDaySo.SelectedItems.Count == 0)
            {
                MessageBox.Show("Chưa chọn phần tử nào để xóa!", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xóa từ cuối lên đầu để tránh lỗi index
            for (int i = lstDaySo.SelectedIndices.Count - 1; i >= 0; i--)
            {
                lstDaySo.Items.RemoveAt(lstDaySo.SelectedIndices[i]);
            }

            MessageBox.Show("Đã xóa các phần tử đã chọn!", "Thành công",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Xóa phần tử đầu
        private void btnXoaDau_Click(object sender, EventArgs e)
        {
            if (lstDaySo.Items.Count == 0)
            {
                MessageBox.Show("Danh sách rỗng!", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int value = (int)lstDaySo.Items[0];
            lstDaySo.Items.RemoveAt(0);
            MessageBox.Show($"Đã xóa phần tử đầu: {value}", "Thành công",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Xóa phần tử cuối
        private void btnXoaCuoi_Click(object sender, EventArgs e)
        {
            if (lstDaySo.Items.Count == 0)
            {
                MessageBox.Show("Danh sách rỗng!", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int lastIndex = lstDaySo.Items.Count - 1;
            int value = (int)lstDaySo.Items[lastIndex];
            lstDaySo.Items.RemoveAt(lastIndex);
            MessageBox.Show($"Đã xóa phần tử cuối: {value}", "Thành công",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Xóa toàn bộ dãy số
        private void btnXoaDaySo_Click(object sender, EventArgs e)
        {
            if (lstDaySo.Items.Count == 0)
            {
                MessageBox.Show("Danh sách đã rỗng!", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa toàn bộ dãy số?", "Xác nhận",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                lstDaySo.Items.Clear();
                MessageBox.Show("Đã xóa toàn bộ dãy số!", "Thành công",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Kết thúc ứng dụng
        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            txtNhapSo.Focus();
        }
    }
}