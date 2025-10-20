using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyBanSach
{
    public class Form1 : Form
    {
        string strCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\VanToan123\source\repos\1150080040_NguyenVanToan_Lab6\1150080040_NguyenVanToan_Lab6\QuanLyBanSach.mdf"";Integrated Security=True";
        SqlConnection sqlCon = null;

        private ListView lsvDanhSach, lsvChiTiet;
        private TextBox txtMaXB, txtTenXB, txtDiaChi;
        private Button btnThem, btnSua, btnXoa;
        private Label lblMaXB, lblTenXB, lblDiaChi;
        private GroupBox grpList, grpInfo, grpChiTiet;

        public Form1()
        {
            this.Text = "Quản lý Nhà Xuất Bản";
            this.Size = new Size(950, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // --- Nhóm danh sách NXB ---
            grpList = new GroupBox()
            {
                Text = "Danh sách nhà xuất bản:",
                Location = new Point(10, 20),
                Size = new Size(450, 250)
            };
            this.Controls.Add(grpList);

            lsvDanhSach = new ListView()
            {
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Location = new Point(10, 25),
                Size = new Size(430, 210)
            };
            lsvDanhSach.Columns.Add("Mã NXB", 80);
            lsvDanhSach.Columns.Add("Tên NXB", 150);
            lsvDanhSach.Columns.Add("Địa chỉ", 180);
            lsvDanhSach.SelectedIndexChanged += lsvDanhSach_SelectedIndexChanged;
            grpList.Controls.Add(lsvDanhSach);

            // --- Nhóm nhập liệu ---
            grpInfo = new GroupBox()
            {
                Text = "Thông tin nhập liệu:",
                Location = new Point(480, 20),
                Size = new Size(430, 250)
            };
            this.Controls.Add(grpInfo);

            lblMaXB = new Label() { Text = "Mã NXB:", Location = new Point(20, 40), AutoSize = true };
            lblTenXB = new Label() { Text = "Tên NXB:", Location = new Point(20, 80), AutoSize = true };
            lblDiaChi = new Label() { Text = "Địa chỉ:", Location = new Point(20, 120), AutoSize = true };

            txtMaXB = new TextBox() { Location = new Point(100, 37), Width = 280 };
            txtTenXB = new TextBox() { Location = new Point(100, 77), Width = 280 };
            txtDiaChi = new TextBox() { Location = new Point(100, 117), Width = 280 };

            grpInfo.Controls.AddRange(new Control[] { lblMaXB, txtMaXB, lblTenXB, txtTenXB, lblDiaChi, txtDiaChi });

            btnThem = new Button() { Text = "Thêm", Location = new Point(60, 170), Size = new Size(80, 35), BackColor = Color.Honeydew };
            btnSua = new Button() { Text = "Sửa", Location = new Point(170, 170), Size = new Size(80, 35), BackColor = Color.LemonChiffon };
            btnXoa = new Button() { Text = "Xóa", Location = new Point(280, 170), Size = new Size(80, 35), BackColor = Color.MistyRose };

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;

            grpInfo.Controls.AddRange(new Control[] { btnThem, btnSua, btnXoa });

            // --- Nhóm chi tiết ---
            grpChiTiet = new GroupBox()
            {
                Text = "Chi tiết nhà xuất bản (Danh sách Sách):",
                Location = new Point(10, 290),
                Size = new Size(900, 250)
            };
            this.Controls.Add(grpChiTiet);

            lsvChiTiet = new ListView()
            {
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Location = new Point(10, 25),
                Size = new Size(880, 210)
            };
            lsvChiTiet.Columns.Add("Mã Sách", 100);
            lsvChiTiet.Columns.Add("Tên Sách", 250);
            lsvChiTiet.Columns.Add("Tác Giả", 200);
            lsvChiTiet.Columns.Add("Năm XB", 120);
            lsvChiTiet.Columns.Add("Ghi chú", 180);
            grpChiTiet.Controls.Add(lsvChiTiet);

            this.Load += Form1_Load;
        }

        private void MoKetNoi()
        {
            if (sqlCon == null)
                sqlCon = new SqlConnection(strCon);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
        }

        private void DongKetNoi()
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                sqlCon.Close();
        }

        // --- Hiển thị danh sách NXB ---
        private void HienThiDanhSachNXB()
        {
            try
            {
                MoKetNoi();
                SqlCommand cmd = new SqlCommand("HienThiNXB", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                lsvDanhSach.Items.Clear();

                while (reader.Read())
                {
                    string ma = reader.GetString(0);
                    string ten = reader.GetString(1);
                    string diaChi = reader.GetString(2);

                    ListViewItem lvi = new ListViewItem(ma);
                    lvi.SubItems.Add(ten);
                    lvi.SubItems.Add(diaChi);
                    lsvDanhSach.Items.Add(lvi);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị: " + ex.Message);
            }
            finally
            {
                DongKetNoi();
            }
        }

        // --- Hiển thị chi tiết NXB (sách thuộc NXB) ---
        private void HienThiChiTietNXB(string maNXB)
        {
            try
            {
                MoKetNoi();
                SqlCommand cmd = new SqlCommand("HienThiChiTietNXB", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaNXB", maNXB);
                SqlDataReader reader = cmd.ExecuteReader();

                lsvChiTiet.Items.Clear();
                while (reader.Read())
                {
                    string maSach = reader.GetString(0);
                    string tenSach = reader.GetString(1);
                    string tacGia = reader.GetString(2);
                    DateTime namXB = reader.GetDateTime(3);
                    string ghiChu = reader.IsDBNull(4) ? "" : reader.GetString(4);

                    ListViewItem item = new ListViewItem(maSach);
                    item.SubItems.Add(tenSach);
                    item.SubItems.Add(tacGia);
                    item.SubItems.Add(namXB.ToString("yyyy"));
                    item.SubItems.Add(ghiChu);
                    lsvChiTiet.Items.Add(item);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị chi tiết: " + ex.Message);
            }
            finally
            {
                DongKetNoi();
            }
        }

        // --- Thêm ---
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaXB.Text == "" || txtTenXB.Text == "" || txtDiaChi.Text == "")
            {
                MessageBox.Show("Nhập đầy đủ thông tin!");
                return;
            }

            try
            {
                MoKetNoi();
                SqlCommand cmd = new SqlCommand("ThemNXB", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaXB", txtMaXB.Text.Trim());
                cmd.Parameters.AddWithValue("@TenNXB", txtTenXB.Text.Trim());
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm thành công!");
                HienThiDanhSachNXB();
                ClearTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm: " + ex.Message);
            }
            finally
            {
                DongKetNoi();
            }
        }

        // --- Sửa ---
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaXB.Text == "")
            {
                MessageBox.Show("Chọn dòng để sửa!");
                return;
            }

            try
            {
                MoKetNoi();
                SqlCommand cmd = new SqlCommand("SuaNXB", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaXB", txtMaXB.Text.Trim());
                cmd.Parameters.AddWithValue("@TenNXB", txtTenXB.Text.Trim());
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                cmd.ExecuteNonQuery();

                MessageBox.Show("Sửa thành công!");
                HienThiDanhSachNXB();
                ClearTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa: " + ex.Message);
            }
            finally
            {
                DongKetNoi();
            }
        }

        // --- Xóa ---
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaXB.Text == "")
            {
                MessageBox.Show("Chọn dòng để xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                MoKetNoi();
                SqlCommand cmd = new SqlCommand("XoaNXB", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaXB", txtMaXB.Text.Trim());
                cmd.ExecuteNonQuery();

                MessageBox.Show("Xóa thành công!");
                HienThiDanhSachNXB();
                lsvChiTiet.Items.Clear();
                ClearTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message);
            }
            finally
            {
                DongKetNoi();
            }
        }

        // --- Khi chọn 1 dòng trong ListView NXB ---
        private void lsvDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvDanhSach.SelectedItems.Count == 0) return;
            ListViewItem lvi = lsvDanhSach.SelectedItems[0];
            txtMaXB.Text = lvi.SubItems[0].Text;
            txtTenXB.Text = lvi.SubItems[1].Text;
            txtDiaChi.Text = lvi.SubItems[2].Text;

            // Gọi hiển thị chi tiết sách
            HienThiChiTietNXB(txtMaXB.Text.Trim());
        }

        private void ClearTextBox()
        {
            txtMaXB.Clear();
            txtTenXB.Clear();
            txtDiaChi.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HienThiDanhSachNXB();
        }
    }
}
