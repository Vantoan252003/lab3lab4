using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace _11500800040_NguyenVanToan_Lab5
{
    public partial class Form3 : Form
    {
        // Chuỗi kết nối
        string strCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\VanToan123\source\repos\11500800040_NguyenVanToan_Lab5\11500800040_NguyenVanToan_Lab5\Lab5DB.mdf;Integrated Security=True";

        // Đối tượng kết nối
        SqlConnection sqlCon = null;

        // Khai báo controls
        private ListView lsvDanhSach;
        private Button btnXoaSV;
        private Button btnLamMoi;
        private Label lblTitle;
        private Label lblDanhSach;
        private Label lblHuongDan;
        private Panel panelThongTin;
        private Label lblMaSV;
        private Label lblTenSV;
        private Label lblGioiTinh;
        private Label lblNgaySinh;
        private Label lblQueQuan;
        private Label lblMaLop;
        private Label lblValueMaSV;
        private Label lblValueTenSV;
        private Label lblValueGioiTinh;
        private Label lblValueNgaySinh;
        private Label lblValueQueQuan;
        private Label lblValueMaLop;

        // Biến lưu mã sinh viên được chọn
        string maSV = "";

        public Form3()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Xóa Sinh Viên";
            this.Size = new Size(1100, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;

            // Title
            lblTitle = new Label();
            lblTitle.Text = "XÓA THÔNG TIN SINH VIÊN";
            lblTitle.Font = new Font("Arial", 18, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkRed;
            lblTitle.Location = new Point(350, 15);
            lblTitle.Size = new Size(450, 35);
            this.Controls.Add(lblTitle);

            // Hướng dẫn
            lblHuongDan = new Label();
            lblHuongDan.Text = "Chọn sinh viên trong danh sách bên dưới, sau đó nhấn nút XÓA";
            lblHuongDan.Font = new Font("Arial", 10);
            lblHuongDan.ForeColor = Color.Blue;
            lblHuongDan.Location = new Point(20, 60);
            lblHuongDan.Size = new Size(650, 25);
            this.Controls.Add(lblHuongDan);

            // Label Danh sách
            lblDanhSach = new Label();
            lblDanhSach.Text = "DANH SÁCH SINH VIÊN";
            lblDanhSach.Location = new Point(20, 95);
            lblDanhSach.Size = new Size(300, 25);
            lblDanhSach.Font = new Font("Arial", 11, FontStyle.Bold);
            lblDanhSach.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblDanhSach);

            // ListView Danh sách sinh viên
            lsvDanhSach = new ListView();
            lsvDanhSach.Location = new Point(20, 125);
            lsvDanhSach.Size = new Size(650, 420);
            lsvDanhSach.View = View.Details;
            lsvDanhSach.FullRowSelect = true;
            lsvDanhSach.GridLines = true;
            lsvDanhSach.BackColor = Color.White;

            lsvDanhSach.Columns.Add("Mã SV", 90);
            lsvDanhSach.Columns.Add("Tên SV", 150);
            lsvDanhSach.Columns.Add("Giới tính", 80);
            lsvDanhSach.Columns.Add("Ngày sinh", 100);
            lsvDanhSach.Columns.Add("Quê quán", 130);
            lsvDanhSach.Columns.Add("Mã lớp", 90);

            lsvDanhSach.SelectedIndexChanged += new EventHandler(lsvDanhSach_SelectedIndexChanged);
            this.Controls.Add(lsvDanhSach);

            // Button Làm mới
            btnLamMoi = new Button();
            btnLamMoi.Text = "🔄 LÀM MỚI";
            btnLamMoi.Location = new Point(20, 555);
            btnLamMoi.Size = new Size(150, 40);
            btnLamMoi.BackColor = Color.LightBlue;
            btnLamMoi.Font = new Font("Arial", 10, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.DarkBlue;
            btnLamMoi.Cursor = Cursors.Hand;
            btnLamMoi.Click += new EventHandler(btnLamMoi_Click);
            this.Controls.Add(btnLamMoi);

            // Panel Thông tin sinh viên được chọn
            panelThongTin = new Panel();
            panelThongTin.Location = new Point(690, 95);
            panelThongTin.Size = new Size(380, 500);
            panelThongTin.BorderStyle = BorderStyle.FixedSingle;
            panelThongTin.BackColor = Color.LightYellow;

            // Title Panel
            Label lblPanelTitle = new Label();
            lblPanelTitle.Text = "THÔNG TIN SINH VIÊN ĐƯỢC CHỌN";
            lblPanelTitle.Font = new Font("Arial", 11, FontStyle.Bold);
            lblPanelTitle.ForeColor = Color.DarkRed;
            lblPanelTitle.Location = new Point(20, 15);
            lblPanelTitle.Size = new Size(340, 25);
            panelThongTin.Controls.Add(lblPanelTitle);

            // Labels trong panel
            int startY = 60;
            int spacing = 50;

            lblMaSV = new Label() { Text = "Mã SV:", Location = new Point(20, startY), Size = new Size(100, 20), Font = new Font("Arial", 9, FontStyle.Bold) };
            lblValueMaSV = new Label() { Text = "---", Location = new Point(130, startY), Size = new Size(230, 20), ForeColor = Color.DarkBlue };

            lblTenSV = new Label() { Text = "Tên SV:", Location = new Point(20, startY + spacing), Size = new Size(100, 20), Font = new Font("Arial", 9, FontStyle.Bold) };
            lblValueTenSV = new Label() { Text = "---", Location = new Point(130, startY + spacing), Size = new Size(230, 20), ForeColor = Color.DarkBlue };

            lblGioiTinh = new Label() { Text = "Giới tính:", Location = new Point(20, startY + spacing * 2), Size = new Size(100, 20), Font = new Font("Arial", 9, FontStyle.Bold) };
            lblValueGioiTinh = new Label() { Text = "---", Location = new Point(130, startY + spacing * 2), Size = new Size(230, 20), ForeColor = Color.DarkBlue };

            lblNgaySinh = new Label() { Text = "Ngày sinh:", Location = new Point(20, startY + spacing * 3), Size = new Size(100, 20), Font = new Font("Arial", 9, FontStyle.Bold) };
            lblValueNgaySinh = new Label() { Text = "---", Location = new Point(130, startY + spacing * 3), Size = new Size(230, 20), ForeColor = Color.DarkBlue };

            lblQueQuan = new Label() { Text = "Quê quán:", Location = new Point(20, startY + spacing * 4), Size = new Size(100, 20), Font = new Font("Arial", 9, FontStyle.Bold) };
            lblValueQueQuan = new Label() { Text = "---", Location = new Point(130, startY + spacing * 4), Size = new Size(230, 20), ForeColor = Color.DarkBlue };

            lblMaLop = new Label() { Text = "Mã lớp:", Location = new Point(20, startY + spacing * 5), Size = new Size(100, 20), Font = new Font("Arial", 9, FontStyle.Bold) };
            lblValueMaLop = new Label() { Text = "---", Location = new Point(130, startY + spacing * 5), Size = new Size(230, 20), ForeColor = Color.DarkBlue };

            panelThongTin.Controls.Add(lblMaSV);
            panelThongTin.Controls.Add(lblValueMaSV);
            panelThongTin.Controls.Add(lblTenSV);
            panelThongTin.Controls.Add(lblValueTenSV);
            panelThongTin.Controls.Add(lblGioiTinh);
            panelThongTin.Controls.Add(lblValueGioiTinh);
            panelThongTin.Controls.Add(lblNgaySinh);
            panelThongTin.Controls.Add(lblValueNgaySinh);
            panelThongTin.Controls.Add(lblQueQuan);
            panelThongTin.Controls.Add(lblValueQueQuan);
            panelThongTin.Controls.Add(lblMaLop);
            panelThongTin.Controls.Add(lblValueMaLop);

            // Button Xóa trong panel
            btnXoaSV = new Button();
            btnXoaSV.Text = "❌ XÓA SINH VIÊN";
            btnXoaSV.Location = new Point(70, 420);
            btnXoaSV.Size = new Size(240, 50);
            btnXoaSV.BackColor = Color.Red;
            btnXoaSV.Font = new Font("Arial", 12, FontStyle.Bold);
            btnXoaSV.ForeColor = Color.White;
            btnXoaSV.Cursor = Cursors.Hand;
            btnXoaSV.Click += new EventHandler(btnXoaSV_Click);
            panelThongTin.Controls.Add(btnXoaSV);

            this.Controls.Add(panelThongTin);

            // Load event
            this.Load += new EventHandler(Form3_Load);
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

        // Hàm hiển thị danh sách sinh viên
        private void HienThiDSSinhVien()
        {
            try
            {
                MoKetNoi();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "select * from SinhVien";
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
                    string maLop = reader.GetString(5);

                    ListViewItem lvi = new ListViewItem(maSV);
                    lvi.SubItems.Add(tenSV);
                    lvi.SubItems.Add(gioiTinh);
                    lvi.SubItems.Add(ngaySinh);
                    lvi.SubItems.Add(queQuan);
                    lvi.SubItems.Add(maLop);

                    lsvDanhSach.Items.Add(lvi);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện Load form
        private void Form3_Load(object sender, EventArgs e)
        {
            HienThiDSSinhVien();
        }

        // Sự kiện khi chọn sinh viên trong ListView
        private void lsvDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Nếu chưa chọn sinh viên nào để xóa
            if (lsvDanhSach.SelectedItems.Count == 0)
            {
                maSV = "";
                // Reset thông tin hiển thị
                lblValueMaSV.Text = "---";
                lblValueTenSV.Text = "---";
                lblValueGioiTinh.Text = "---";
                lblValueNgaySinh.Text = "---";
                lblValueQueQuan.Text = "---";
                lblValueMaLop.Text = "---";
                return;
            }

            // Nếu đã chọn 1 sinh viên
            ListViewItem lvi = lsvDanhSach.SelectedItems[0];
            maSV = lvi.SubItems[0].Text.Trim();

            // Hiển thị thông tin sinh viên được chọn
            lblValueMaSV.Text = lvi.SubItems[0].Text;
            lblValueTenSV.Text = lvi.SubItems[1].Text;
            lblValueGioiTinh.Text = lvi.SubItems[2].Text;
            lblValueNgaySinh.Text = lvi.SubItems[3].Text;
            lblValueQueQuan.Text = lvi.SubItems[4].Text;
            lblValueMaLop.Text = lvi.SubItems[5].Text;
        }

        // Sự kiện nút Xóa
        private void btnXoaSV_Click(object sender, EventArgs e)
        {
            if (maSV == "")
            {
                MessageBox.Show("Bạn chưa chọn sinh viên nào để xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có thực sự muốn xóa sinh viên này không?\n\n" +
                    "Mã SV: " + lblValueMaSV.Text + "\n" +
                    "Tên SV: " + lblValueTenSV.Text,
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    XoaSV(maSV);
                }
            }
        }

        // Hàm xóa sinh viên
        // Hàm xóa sinh viên (dùng Parameter)
        private void XoaSV(string maSV)
        {
            try
            {
                MoKetNoi();

               
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "DELETE FROM SinhVien WHERE MaSV = @MaSV";
                sqlCmd.Connection = sqlCon;

    
                sqlCmd.Parameters.AddWithValue("@MaSV", maSV);

                int kq = sqlCmd.ExecuteNonQuery();

                if (kq > 0)
                {
                    MessageBox.Show("✅ Xóa sinh viên thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

      
                    this.maSV = "";
                    lblValueMaSV.Text = "---";
                    lblValueTenSV.Text = "---";
                    lblValueGioiTinh.Text = "---";
                    lblValueNgaySinh.Text = "---";
                    lblValueQueQuan.Text = "---";
                    lblValueMaLop.Text = "---";

                    HienThiDSSinhVien();
                }
                else
                {
                    MessageBox.Show("Không có sinh viên nào bị xóa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DongKetNoi();
            }
        }


        // Sự kiện nút Làm mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            HienThiDSSinhVien();
            maSV = "";
            lblValueMaSV.Text = "---";
            lblValueTenSV.Text = "---";
            lblValueGioiTinh.Text = "---";
            lblValueNgaySinh.Text = "---";
            lblValueQueQuan.Text = "---";
            lblValueMaLop.Text = "---";

            MessageBox.Show("Đã làm mới danh sách!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}