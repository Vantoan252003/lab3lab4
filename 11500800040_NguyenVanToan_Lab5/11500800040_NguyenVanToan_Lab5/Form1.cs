using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class Form1 : Form
    {

        string strCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\VanToan123\source\repos\11500800040_NguyenVanToan_Lab5\11500800040_NguyenVanToan_Lab5\Lab5DB.mdf;Integrated Security=True";


        SqlConnection sqlCon = null;


        private ComboBox cbMaLop;
        private ListView lsvDanhSach;
        private TextBox txtMaSV;
        private TextBox txtTenSV;
        private ComboBox cbGioiTinh;
        private DateTimePicker dtpNgaySinh;
        private TextBox txtQueQuan;
        private TextBox txtMaLop;
        private Button btnSuaThongTin;
        private Label lblChonLop;
        private Label lblMaSV;
        private Label lblTenSV;
        private Label lblGioiTinh;
        private Label lblNgaySinh;
        private Label lblQueQuan;
        private Label lblMaLop;
        private Label lblTitle;
        private Label lblDanhSach;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Sửa Thông Tin Sinh Viên";
            this.Size = new Size(1100, 650);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Title
            lblTitle = new Label();
            lblTitle.Text = "SỬA THÔNG TIN SINH VIÊN";
            lblTitle.Font = new Font("Arial", 16, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(400, 10);
            lblTitle.Size = new Size(400, 30);
            this.Controls.Add(lblTitle);

            // Label Chọn lớp
            lblChonLop = new Label();
            lblChonLop.Text = "Chọn lớp:";
            lblChonLop.Location = new Point(20, 60);
            lblChonLop.Size = new Size(80, 20);
            lblChonLop.Font = new Font("Arial", 9, FontStyle.Bold);
            this.Controls.Add(lblChonLop);

            // ComboBox Chọn lớp
            cbMaLop = new ComboBox();
            cbMaLop.Location = new Point(110, 58);
            cbMaLop.Size = new Size(250, 25);
            cbMaLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMaLop.SelectedIndexChanged += new EventHandler(cbMaLop_SelectedIndexChanged);
            this.Controls.Add(cbMaLop);

            // Label Danh sách
            lblDanhSach = new Label();
            lblDanhSach.Text = "DANH SÁCH SINH VIÊN";
            lblDanhSach.Location = new Point(20, 100);
            lblDanhSach.Size = new Size(300, 20);
            lblDanhSach.Font = new Font("Arial", 10, FontStyle.Bold);
            lblDanhSach.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblDanhSach);

            // ListView Danh sách sinh viên
            lsvDanhSach = new ListView();
            lsvDanhSach.Location = new Point(20, 130);
            lsvDanhSach.Size = new Size(650, 280);
            lsvDanhSach.View = View.Details;
            lsvDanhSach.FullRowSelect = true;
            lsvDanhSach.GridLines = true;

            lsvDanhSach.Columns.Add("Mã SV", 90);
            lsvDanhSach.Columns.Add("Tên SV", 150);
            lsvDanhSach.Columns.Add("Giới tính", 80);
            lsvDanhSach.Columns.Add("Ngày sinh", 100);
            lsvDanhSach.Columns.Add("Quê quán", 130);
            lsvDanhSach.Columns.Add("Mã lớp", 90);

            lsvDanhSach.SelectedIndexChanged += new EventHandler(lsvDanhSach_SelectedIndexChanged);
            this.Controls.Add(lsvDanhSach);

            // Panel chứa form sửa thông tin
            Panel panelSua = new Panel();
            panelSua.Location = new Point(690, 100);
            panelSua.Size = new Size(380, 450);
            panelSua.BorderStyle = BorderStyle.FixedSingle;
            panelSua.BackColor = Color.LightYellow;

            // Labels trong panel
            lblMaSV = new Label() { Text = "Mã SV:", Location = new Point(20, 30), Size = new Size(80, 20) };
            lblTenSV = new Label() { Text = "Tên SV:", Location = new Point(20, 70), Size = new Size(80, 20) };
            lblGioiTinh = new Label() { Text = "Giới tính:", Location = new Point(20, 110), Size = new Size(80, 20) };
            lblNgaySinh = new Label() { Text = "Ngày sinh:", Location = new Point(20, 150), Size = new Size(80, 20) };
            lblQueQuan = new Label() { Text = "Quê quán:", Location = new Point(20, 190), Size = new Size(80, 20) };
            lblMaLop = new Label() { Text = "Mã lớp:", Location = new Point(20, 230), Size = new Size(80, 20) };

            panelSua.Controls.Add(lblMaSV);
            panelSua.Controls.Add(lblTenSV);
            panelSua.Controls.Add(lblGioiTinh);
            panelSua.Controls.Add(lblNgaySinh);
            panelSua.Controls.Add(lblQueQuan);
            panelSua.Controls.Add(lblMaLop);

            // TextBoxes trong panel
            txtMaSV = new TextBox() { Location = new Point(110, 28), Size = new Size(240, 25), ReadOnly = true, BackColor = Color.LightGray };
            txtTenSV = new TextBox() { Location = new Point(110, 68), Size = new Size(240, 25) };
            txtQueQuan = new TextBox() { Location = new Point(110, 188), Size = new Size(240, 25) };
            txtMaLop = new TextBox() { Location = new Point(110, 228), Size = new Size(240, 25) };

            panelSua.Controls.Add(txtMaSV);
            panelSua.Controls.Add(txtTenSV);
            panelSua.Controls.Add(txtQueQuan);
            panelSua.Controls.Add(txtMaLop);

            // ComboBox Giới tính trong panel
            cbGioiTinh = new ComboBox();
            cbGioiTinh.Location = new Point(110, 108);
            cbGioiTinh.Size = new Size(240, 25);
            cbGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");
            panelSua.Controls.Add(cbGioiTinh);

            // DateTimePicker trong panel
            dtpNgaySinh = new DateTimePicker();
            dtpNgaySinh.Location = new Point(110, 148);
            dtpNgaySinh.Size = new Size(240, 25);
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            panelSua.Controls.Add(dtpNgaySinh);

            // Button Sửa trong panel
            btnSuaThongTin = new Button();
            btnSuaThongTin.Text = "CẬP NHẬT THÔNG TIN";
            btnSuaThongTin.Location = new Point(110, 280);
            btnSuaThongTin.Size = new Size(240, 40);
            btnSuaThongTin.BackColor = Color.Orange;
            btnSuaThongTin.Font = new Font("Arial", 10, FontStyle.Bold);
            btnSuaThongTin.ForeColor = Color.White;
            btnSuaThongTin.Click += new EventHandler(btnSuaThongTin_Click);
            panelSua.Controls.Add(btnSuaThongTin);

            this.Controls.Add(panelSua);

            // Load event
            this.Load += new EventHandler(Form1_Load);
        }

        // Hàm mở kết nối
        private void MoKetNoi()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
        }

        // Hàm đóng kết nối
        private void DongKetNoi()
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }

        // Hàm hiển thị danh sách mã lớp
        private void HienThiDSMaLop()
        {
            try
            {
                MoKetNoi();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "select * from Lop";
                sqlCmd.Connection = sqlCon;

                SqlDataReader reader = sqlCmd.ExecuteReader();
                cbMaLop.Items.Clear();

                while (reader.Read())
                {
                    string maLop = reader.GetString(0);
                    string tenLop = reader.GetString(1);
                    cbMaLop.Items.Add(maLop + " - " + tenLop);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị danh sách lớp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm hiển thị danh sách sinh viên theo lớp đã chọn
        private void HienThiDSinhVienTheoLop(string maLop)
        {
            try
            {
                MoKetNoi();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "select * from SinhVien where MaLop='" + maLop + "'";
                sqlCmd.Connection = sqlCon;

                lsvDanhSach.Items.Clear();
                SqlDataReader reader = sqlCmd.ExecuteReader();

                while (reader.Read())
                {
                    string maSV = reader.GetString(0);
                    string tenSV = reader.GetString(1);
                    string gioiTinh = reader.GetString(2);
                    string ngaySinh = reader.GetDateTime(3).ToString("dd/MM/yyyy");
                    string queQuan = reader.GetString(4);
                    string maLopSV = reader.GetString(5);

                    ListViewItem lvi = new ListViewItem(maSV);
                    lvi.SubItems.Add(tenSV);
                    lvi.SubItems.Add(gioiTinh);
                    lvi.SubItems.Add(ngaySinh);
                    lvi.SubItems.Add(queQuan);
                    lvi.SubItems.Add(maLopSV);

                    lsvDanhSach.Items.Add(lvi);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị danh sách sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện Load form
        private void Form1_Load(object sender, EventArgs e)
        {
            HienThiDSMaLop();
        }

        // Sự kiện khi chọn lớp
        private void cbMaLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Nếu chưa chọn lớp nào
            if (cbMaLop.SelectedIndex == -1) return;

            // Nếu đã chọn 1 lớp
            string[] line = cbMaLop.SelectedItem.ToString().Split('-');
            string maLop = line[0].Trim();

            // Hiển thị thông tin sinh viên theo mã lớp đã chọn
            HienThiDSinhVienTheoLop(maLop);
        }

        // Sự kiện khi chọn sinh viên trong ListView
        private void lsvDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Nếu chưa chọn sinh viên nào
            if (lsvDanhSach.SelectedItems.Count == 0) return;

            // Nếu đã chọn 1 sinh viên
            ListViewItem lvi = lsvDanhSach.SelectedItems[0];

            // Hiển thị thông tin lên các control
            txtMaSV.Text = lvi.SubItems[0].Text;
            txtTenSV.Text = lvi.SubItems[1].Text;

            string gioiTinh = lvi.SubItems[2].Text;
            cbGioiTinh.SelectedIndex = (gioiTinh == "Nam") ? 0 : 1;

            string[] dt = lvi.SubItems[3].Text.Split('/');
            dtpNgaySinh.Value = new DateTime(
                int.Parse(dt[2].Trim()),
                int.Parse(dt[1].Trim()),
                int.Parse(dt[0].Trim())
            );

            txtQueQuan.Text = lvi.SubItems[4].Text;
            txtMaLop.Text = lvi.SubItems[5].Text;
        }

        // Sự kiện sửa thông tin sinh viên
        private void btnSuaThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem đã chọn sinh viên chưa
                if (string.IsNullOrEmpty(txtMaSV.Text))
                {
                    MessageBox.Show("Vui lòng chọn sinh viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MoKetNoi();

                // Lấy dữ liệu từ control
                string maSV = txtMaSV.Text.Trim();
                string tenSV = txtTenSV.Text.Trim();
                string gioiTinh = cbGioiTinh.Text.Trim();
                DateTime ngaySinh = dtpNgaySinh.Value;
                string queQuan = txtQueQuan.Text.Trim();
                string maLop = txtMaLop.Text.Trim();

                // Kiểm tra dữ liệu
                if (string.IsNullOrEmpty(tenSV) || string.IsNullOrEmpty(gioiTinh) ||
                    string.IsNullOrEmpty(queQuan) || string.IsNullOrEmpty(maLop))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Sử dụng Parameter để tránh SQL Injection
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = @"
            UPDATE SinhVien 
            SET TenSV = @TenSV, 
                GioiTinh = @GioiTinh, 
                NgaySinh = @NgaySinh, 
                QueQuan = @QueQuan, 
                MaLop = @MaLop 
            WHERE MaSV = @MaSV";

                sqlCmd.Connection = sqlCon;

                // Thêm các parameter vào lệnh SQL
                sqlCmd.Parameters.AddWithValue("@MaSV", maSV);
                sqlCmd.Parameters.AddWithValue("@TenSV", tenSV);
                sqlCmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                sqlCmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                sqlCmd.Parameters.AddWithValue("@QueQuan", queQuan);
                sqlCmd.Parameters.AddWithValue("@MaLop", maLop);

                int kq = sqlCmd.ExecuteNonQuery();

                if (kq > 0)
                {
                    MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDSinhVienTheoLop(maLop);
                }
                else
                {
                    MessageBox.Show("Không có bản ghi nào được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Xóa dữ liệu trên form
                txtMaSV.Clear();
                txtTenSV.Clear();
                txtQueQuan.Clear();
                txtMaLop.Clear();
                cbGioiTinh.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DongKetNoi();
            }
        }

    }
}