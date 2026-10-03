using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;   // Tự động lấp đầy Panel chính
            panel3.Controls.Clear();          // Xóa giao diện cũ
            panel3.Controls.Add(userControl); // Thêm UCNhapHang vào
            userControl.BringToFront();
        }
        // Hàm đổi màu cho nút được chọn
        private void SelectGunaButton(RoundedButton currentBtn)
        {
            RoundedButton[] menuButtons = { roundedButton1, roundedButton2 }; // Điền danh sách nút của bạn

            foreach (var btn in menuButtons)
            {
                btn.Checked = false;
                btn.BackColor = Color.White;                // Nền trắng khi không chọn
                btn.ForeColor = Color.FromArgb(30, 30, 30); // Chữ đen khi không chọn
                btn.Invalidate();
            }

            // Nút được chọn (Active)
            currentBtn.Checked = true;
            currentBtn.BackColor = Color.FromArgb(24, 32, 42); // Nền xanh đen
            currentBtn.ForeColor = Color.White;                // Chữ trắng tinh
            currentBtn.Invalidate();                           // Ép vẽ lại
        }
       

        // Sự kiện Click của từng nút
        private void roundedButton1_Click(object sender, EventArgs e)
        {
            SelectGunaButton(roundedButton1);
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            SelectGunaButton(roundedButton2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    // Class RoundedButton tự bo góc
    public class RoundedButton : Button
    {
        public int BorderRadius { get; set; } = 10;
        public bool Checked { get; set; } = false;

        public RoundedButton()
        {
            // Tắt viền Focus mặc định của Windows
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            // Bỏ base.OnPaint(pevent) để Windows không đè màu chữ nữa
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // 1. Tạo đường dẫn bo góc
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            using (GraphicsPath path = new GraphicsPath())
            {
                int r = BorderRadius;
                path.AddArc(0, 0, r, r, 180, 90);
                path.AddArc(this.Width - r, 0, r, r, 270, 90);
                path.AddArc(this.Width - r, this.Height - r, r, r, 0, 90);
                path.AddArc(0, this.Height - r, r, r, 90, 90);
                path.CloseAllFigures();

                // Cắt bo góc
                this.Region = new Region(path);

                // 2. Vẽ nền (BackColor)
                using (SolidBrush brushBg = new SolidBrush(this.BackColor))
                {
                    g.FillPath(brushBg, path);
                }
            }

            // 3. Tự vẽ chữ (Text) căn giữa mượt mà theo đúng màu ForeColor
            TextRenderer.DrawText(
                g,
                this.Text,
                this.Font,
                rect,
                this.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );
        }
    }
}