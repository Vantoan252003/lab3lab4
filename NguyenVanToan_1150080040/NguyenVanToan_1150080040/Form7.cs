using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NguyenVanToan_1150080040
{
    public partial class Form7 : Form
    {
        private ListBox listBox1;
        private ListBox listBox2;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label1;
        private Label label2;

        public Form7()
        {
            InitializeComponent();

            // Thêm dữ liệu mẫu vào listBox1 (Danh sách các mặt hàng)
            listBox1.Items.AddRange(new object[]
            {
                "CPU", "MainBoard", "RAM", "Keyboard", "Mouse", "NIC", "FAN"
            });

            // Gắn sự kiện cho các nút
            button1.Click += button1_Click; // >
            button2.Click += button2_Click; // >>
            button3.Click += button3_Click; // <
            button4.Click += button4_Click; // <<
        }

        private void InitializeComponent()
        {
            this.listBox1 = new ListBox();
            this.listBox2 = new ListBox();
            this.button1 = new Button();
            this.button2 = new Button();
            this.button3 = new Button();
            this.button4 = new Button();
            this.label1 = new Label();
            this.label2 = new Label();
            this.SuspendLayout();

            // Form
            this.ClientSize = new Size(600, 350);
            this.Text = "Bài tập 7";

            // Label1
            this.label1.Text = "Danh sách các mặt hàng";
            this.label1.Location = new Point(20, 20);
            this.label1.Size = new Size(200, 20);

            // Label2
            this.label2.Text = "Các mặt hàng lựa chọn";
            this.label2.Location = new Point(380, 20);
            this.label2.Size = new Size(200, 20);

            // ListBox1
            this.listBox1.Location = new Point(20, 50);
            this.listBox1.Size = new Size(200, 220);
            this.listBox1.SelectionMode = SelectionMode.MultiExtended;

            // ListBox2
            this.listBox2.Location = new Point(380, 50);
            this.listBox2.Size = new Size(200, 220);
            this.listBox2.SelectionMode = SelectionMode.MultiExtended;

            // Button1 >
            this.button1.Text = ">";
            this.button1.Location = new Point(260, 80);
            this.button1.Size = new Size(60, 30);

            // Button2 >>
            this.button2.Text = ">>";
            this.button2.Location = new Point(260, 120);
            this.button2.Size = new Size(60, 30);

            // Button3 <
            this.button3.Text = "<";
            this.button3.Location = new Point(260, 160);
            this.button3.Size = new Size(60, 30);

            // Button4 <<
            this.button4.Text = "<<";
            this.button4.Location = new Point(260, 200);
            this.button4.Size = new Size(60, 30);

            // Add controls vào form
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);

            this.ResumeLayout(false);
        }

        // Nút >
        private void button1_Click(object sender, EventArgs e)
        {
            var items = listBox1.SelectedItems.Cast<object>().ToList();
            foreach (var item in items)
            {
                listBox2.Items.Add(item);
            }
            foreach (var item in items)
            {
                listBox1.Items.Remove(item);
            }
        }

        // Nút >>
        private void button2_Click(object sender, EventArgs e)
        {
            var items = listBox1.Items.Cast<object>().ToList();
            foreach (var item in items)
            {
                listBox2.Items.Add(item);
            }
            listBox1.Items.Clear();
        }

        // Nút <
        private void button3_Click(object sender, EventArgs e)
        {
            var items = listBox2.SelectedItems.Cast<object>().ToList();
            foreach (var item in items)
            {
                listBox1.Items.Add(item);
            }
            foreach (var item in items)
            {
                listBox2.Items.Remove(item);
            }
        }

        // Nút <<
        private void button4_Click(object sender, EventArgs e)
        {
            var items = listBox2.Items.Cast<object>().ToList();
            foreach (var item in items)
            {
                listBox1.Items.Add(item);
            }
            listBox2.Items.Clear();
        }
    }
}
