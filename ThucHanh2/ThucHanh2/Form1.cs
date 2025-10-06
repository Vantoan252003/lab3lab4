using System;
using System.Drawing;
using System.Windows.Forms;

namespace ThucHanh2
{
    public class Form1 : Form
    {
  
        private TextBox txtMSSV, txtHoTen, txtDiaChi, txtDienThoai;
        private DateTimePicker dtpNgaySinh;
        private RadioButton radNam, radNu;
        private ComboBox cmbLop;

    
        private Button btnThem, btnXoa, btnSua, btnThoat;

 
        private ListView lvSinhVien;

        public Form1()
        {
            KhoiTaoGiaoDien();
        }

        private void KhoiTaoGiaoDien()
        {
            this.Text = "Quản lý sinh viên";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;


            GroupBox grpThongTin = new GroupBox
            {
                Text = "Thông tin sinh viên",
                Location = new Point(20, 20),
                Size = new Size(850, 200),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            Label lblMSSV = new Label
            {
                Text = "MSSV:",
                Location = new Point(20, 35),
                Size = new Size(100, 20),
                Font = new Font("Arial", 9)
            };
            txtMSSV = new TextBox
            {
                Location = new Point(130, 32),
                Size = new Size(200, 25)
            };

            // Họ tên
            Label lblHoTen = new Label
            {
                Text = "Họ tên:",
                Location = new Point(20, 70),
                Size = new Size(100, 20),
                Font = new Font("Arial", 9)
            };
            txtHoTen = new TextBox
            {
                Location = new Point(130, 67),
                Size = new Size(200, 25)
            };

            // Ngày sinh
            Label lblNgaySinh = new Label
            {
                Text = "Ngày sinh:",
                Location = new Point(20, 105),
                Size = new Size(100, 20),
                Font = new Font("Arial", 9)
            };
            dtpNgaySinh = new DateTimePicker
            {
                Location = new Point(130, 102),
                Size = new Size(200, 25),
                Format = DateTimePickerFormat.Short
            };

            // Địa chỉ
            Label lblDiaChi = new Label
            {
                Text = "Địa chỉ:",
                Location = new Point(20, 140),
                Size = new Size(100, 20),
                Font = new Font("Arial", 9)
            };
            txtDiaChi = new TextBox
            {
                Location = new Point(130, 137),
                Size = new Size(200, 25)
            };

            // Lớp
            Label lblLop = new Label
            {
                Text = "Lớp:",
                Location = new Point(450, 35),
                Size = new Size(80, 20),
                Font = new Font("Arial", 9)
            };
            cmbLop = new ComboBox
            {
                Location = new Point(540, 32),
                Size = new Size(200, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbLop.Items.AddRange(new string[] {
                "11_CNPM1", "11_CNPM2", "11_TNMT"
            });
            cmbLop.SelectedIndex = 0;

            // Giới tính
            Label lblGioiTinh = new Label
            {
                Text = "Giới tính:",
                Location = new Point(450, 70),
                Size = new Size(80, 20),
                Font = new Font("Arial", 9)
            };
            radNam = new RadioButton
            {
                Text = "Nam",
                Location = new Point(540, 68),
                Size = new Size(80, 25),
                Checked = true
            };
            radNu = new RadioButton
            {
                Text = "Nữ",
                Location = new Point(640, 68),
                Size = new Size(80, 25)
            };

            // Điện thoại
            Label lblDienThoai = new Label
            {
                Text = "Điện thoại:",
                Location = new Point(450, 105),
                Size = new Size(80, 20),
                Font = new Font("Arial", 9)
            };
            txtDienThoai = new TextBox
            {
                Location = new Point(540, 102),
                Size = new Size(200, 25)
            };

       
            grpThongTin.Controls.Add(lblMSSV);
            grpThongTin.Controls.Add(txtMSSV);
            grpThongTin.Controls.Add(lblHoTen);
            grpThongTin.Controls.Add(txtHoTen);
            grpThongTin.Controls.Add(lblNgaySinh);
            grpThongTin.Controls.Add(dtpNgaySinh);
            grpThongTin.Controls.Add(lblDiaChi);
            grpThongTin.Controls.Add(txtDiaChi);
            grpThongTin.Controls.Add(lblLop);
            grpThongTin.Controls.Add(cmbLop);
            grpThongTin.Controls.Add(lblGioiTinh);
            grpThongTin.Controls.Add(radNam);
            grpThongTin.Controls.Add(radNu);
            grpThongTin.Controls.Add(lblDienThoai);
            grpThongTin.Controls.Add(txtDienThoai);

            btnThem = new Button
            {
                Text = "Thêm",
                Location = new Point(200, 240),
                Size = new Size(100, 35),
                Font = new Font("Arial", 10)
            };
            btnThem.Click += BtnThem_Click;

            btnXoa = new Button
            {
                Text = "Xóa",
                Location = new Point(320, 240),
                Size = new Size(100, 35),
                Font = new Font("Arial", 10)
            };
            btnXoa.Click += BtnXoa_Click;

            btnSua = new Button
            {
                Text = "Sửa",
                Location = new Point(440, 240),
                Size = new Size(100, 35),
                Font = new Font("Arial", 10)
            };
            btnSua.Click += BtnSua_Click;

            btnThoat = new Button
            {
                Text = "Thoát",
                Location = new Point(560, 240),
                Size = new Size(100, 35),
                Font = new Font("Arial", 10)
            };
            btnThoat.Click += BtnThoat_Click;

    
            lvSinhVien = new ListView
            {
                Location = new Point(20, 290),
                Size = new Size(850, 250),
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                MultiSelect = false
            };

    
            lvSinhVien.Columns.Add("MSSV", 100);
            lvSinhVien.Columns.Add("Họ tên", 150);
            lvSinhVien.Columns.Add("Ngày sinh", 100);
            lvSinhVien.Columns.Add("Lớp", 100);
            lvSinhVien.Columns.Add("Giới tính", 80);
            lvSinhVien.Columns.Add("Điện thoại", 120);
            lvSinhVien.Columns.Add("Địa chỉ", 190);


            lvSinhVien.SelectedIndexChanged += LvSinhVien_SelectedIndexChanged;

            this.Controls.Add(grpThongTin);
            this.Controls.Add(btnThem);
            this.Controls.Add(btnXoa);
            this.Controls.Add(btnSua);
            this.Controls.Add(btnThoat);
            this.Controls.Add(lvSinhVien);
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên sinh viên không được để trống!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

  
            ListViewItem item = new ListViewItem(txtMSSV.Text);
            item.SubItems.Add(txtHoTen.Text);
            item.SubItems.Add(dtpNgaySinh.Value.ToString("dd/MM/yyyy"));
            item.SubItems.Add(cmbLop.SelectedItem.ToString());
            item.SubItems.Add(radNam.Checked ? "Nam" : "Nữ");
            item.SubItems.Add(txtDienThoai.Text);
            item.SubItems.Add(txtDiaChi.Text);

            // Thêm vào ListView
            lvSinhVien.Items.Add(item);

            // Xóa trắng các ô nhập
            XoaTrangForm();

            MessageBox.Show("Thêm sinh viên thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn dòng chưa
            if (lvSinhVien.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận xóa
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa sinh viên này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                lvSinhVien.Items.Remove(lvSinhVien.SelectedItems[0]);
                XoaTrangForm();
                MessageBox.Show("Xóa sinh viên thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn dòng chưa
            if (lvSinhVien.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra họ tên không được rỗng
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên sinh viên không được để trống!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            // Cập nhật thông tin
            ListViewItem item = lvSinhVien.SelectedItems[0];
            item.SubItems[0].Text = txtMSSV.Text;
            item.SubItems[1].Text = txtHoTen.Text;
            item.SubItems[2].Text = dtpNgaySinh.Value.ToString("dd/MM/yyyy");
            item.SubItems[3].Text = cmbLop.SelectedItem.ToString();
            item.SubItems[4].Text = radNam.Checked ? "Nam" : "Nữ";
            item.SubItems[5].Text = txtDienThoai.Text;
            item.SubItems[6].Text = txtDiaChi.Text;

            MessageBox.Show("Cập nhật sinh viên thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void LvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
 
            if (lvSinhVien.SelectedItems.Count > 0)
            {
                ListViewItem item = lvSinhVien.SelectedItems[0];

                txtMSSV.Text = item.SubItems[0].Text;
                txtHoTen.Text = item.SubItems[1].Text;
                dtpNgaySinh.Value = DateTime.ParseExact(item.SubItems[2].Text,
                    "dd/MM/yyyy", null);
                cmbLop.SelectedItem = item.SubItems[3].Text;

                if (item.SubItems[4].Text == "Nam")
                    radNam.Checked = true;
                else
                    radNu.Checked = true;

                txtDienThoai.Text = item.SubItems[5].Text;
                txtDiaChi.Text = item.SubItems[6].Text;
            }
        }

        private void XoaTrangForm()
        {
            txtMSSV.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtDienThoai.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            radNam.Checked = true;
            cmbLop.SelectedIndex = 0;
            txtMSSV.Focus();
        }
    }
}