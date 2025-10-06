using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ApDung_HienThiSinhVienTheoLop
{
    public class Form2 : Form
    {
        // Chuỗi kết nối
        private string strCon = @"Data Source=VanToan;Initial Catalog=QuanLySinhVien;User ID=sa;Password=Vantoan@123";
        private SqlConnection sqlCon = null;

        // Controls
        private Label lblDanhSachLop, lblDanhSachSinhVien, lblTieuDe;
        private ListBox lsbDSLop, lsbDSSinhVien;

        public Form2()
        {
            KhoiTaoGiaoDien();
            LoadDanhSachLop();
        }

        private void KhoiTaoGiaoDien()
        {
            this.Text = "Ứng dụng";
            this.Size = new Size(650, 480);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Tiêu đề
            lblTieuDe = new Label
            {
                Text = "Ứng dụng",
                Location = new Point(250, 20),
                Size = new Size(150, 30),
                Font = new Font("Arial", 14, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Label Danh sách lớp
            lblDanhSachLop = new Label
            {
                Text = "Danh sách lớp:",
                Location = new Point(50, 70),
                Size = new Size(150, 20),
                Font = new Font("Arial", 10)
            };

            // ListBox Danh sách lớp
            lsbDSLop = new ListBox
            {
                Location = new Point(50, 95),
                Size = new Size(150, 300),
                Font = new Font("Arial", 9)
            };
            lsbDSLop.SelectedIndexChanged += LsbDSLop_SelectedIndexChanged;

            // Label Danh sách sinh viên
            lblDanhSachSinhVien = new Label
            {
                Text = "Danh sách sinh viên:",
                Location = new Point(220, 70),
                Size = new Size(180, 20),
                Font = new Font("Arial", 10)
            };

            // ListBox Danh sách sinh viên
            lsbDSSinhVien = new ListBox
            {
                Location = new Point(220, 95),
                Size = new Size(380, 300),
                Font = new Font("Arial", 9)
            };

            // Thêm controls vào form
            this.Controls.Add(lblTieuDe);
            this.Controls.Add(lblDanhSachLop);
            this.Controls.Add(lsbDSLop);
            this.Controls.Add(lblDanhSachSinhVien);
            this.Controls.Add(lsbDSSinhVien);
        }

        // Load danh sách lớp khi form khởi động
        private void LoadDanhSachLop()
        {
            try
            {
                // Mở kết nối
                if (sqlCon == null)
                {
                    sqlCon = new SqlConnection(strCon);
                }
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

                // Truy vấn lấy danh sách lớp
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "select MaLop, TenLop from Lop";
                sqlCmd.Connection = sqlCon;

                SqlDataReader reader = sqlCmd.ExecuteReader();

                lsbDSLop.Items.Clear();

                while (reader.Read())
                {
                    string maLop = reader.GetString(0).Trim();
                    string tenLop = reader.GetString(1).Trim();

                    // Tạo item hiển thị tên lớp, lưu mã lớp làm tag
                    LopItem item = new LopItem
                    {
                        MaLop = maLop,
                        TenLop = tenLop
                    };
                    lsbDSLop.Items.Add(item);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh sách lớp: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện khi chọn lớp
        private void LsbDSLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbDSLop.SelectedItem == null)
                return;

            LopItem selectedLop = (LopItem)lsbDSLop.SelectedItem;
            string maLop = selectedLop.MaLop;

            LoadDanhSachSinhVienTheoLop(maLop);
        }

        // Load danh sách sinh viên theo mã lớp (sử dụng Parameter)
        private void LoadDanhSachSinhVienTheoLop(string maLop)
        {
            try
            {
                // Mở kết nối
                if (sqlCon == null)
                {
                    sqlCon = new SqlConnection(strCon);
                }
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

                // Truy vấn với Parameter
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "select MaSV, TenSV, GioiTinh, NgaySinh from SinhVien where MaLop=@maLop";

                // Tạo parameter để tránh SQL Injection
                SqlParameter parMaLop = new SqlParameter("@maLop", SqlDbType.NVarChar);
                parMaLop.Value = maLop;
                sqlCmd.Parameters.Add(parMaLop);

                sqlCmd.Connection = sqlCon;

                SqlDataReader reader = sqlCmd.ExecuteReader();

                lsbDSSinhVien.Items.Clear();

                while (reader.Read())
                {
                    string maSV = reader.GetString(0).Trim();
                    string tenSV = reader.GetString(1).Trim();
                    bool gioiTinhBool = reader.GetBoolean(2);
                    string gioiTinh = gioiTinhBool ? "Nam" : "Nữ";
                    string ngaySinh = reader.GetDateTime(3).ToString("dd/MM/yyyy");

                    // Hiển thị thông tin sinh viên
                    string displayText = $"{maSV} - {tenSV} - {gioiTinh} - {ngaySinh}";
                    lsbDSSinhVien.Items.Add(displayText);
                }

                reader.Close();

                // Hiển thị số lượng sinh viên
                lblDanhSachSinhVien.Text = $"Danh sách sinh viên: ({lsbDSSinhVien.Items.Count} sinh viên)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh sách sinh viên: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Đóng kết nối khi thoát
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
            base.OnFormClosing(e);
        }

        // Class hỗ trợ để lưu thông tin lớp
        private class LopItem
        {
            public string MaLop { get; set; }
            public string TenLop { get; set; }

            public override string ToString()
            {
                return TenLop; // Hiển thị tên lớp trong ListBox
            }
        }
    }
}