using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hukusyu0531
{
    public partial class Form1 : Form
    {
        int vx;
        int vy;
        int lcr = 255, lcg = 0, lcb = 0;//label1の文字の色、RGB
        int vlcc = 5;//色を変える速度　1か5か255のみ
        int score = 0;

        public Form1()
        {
            InitializeComponent();
            //Form1.DefaultBackColor=Color.FromArgb(100,100,100);
            Random rx = new Random();
            label1.Left = rx.Next(0,ClientSize.Width);
            Random ry = new Random();
            label1.Left = ry.Next(0, ClientSize.Height);

            //↑label1のスタート位置がForm1のサイズの中でランダム
            //↓label1のスタート向きが４方向の中でランダム

            Random ho = new Random();
            int hou = ho.Next(1, 4);

            switch(hou)
            {
                case 1:
                    vx = -10;
                    vy = -10;
                    break;
                case 2:
                    vx = 10;
                    vy = -10;
                    break;
                case 3:
                    vx = -10;
                    vy = 10;
                    break;
                case 4:
                    vx = 10;
                    vy = 10;
                    break;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Text = MousePosition.X + ", " + MousePosition.Y;
            Point p = PointToClient(MousePosition);

            label2.Left = p.X - label2.Width / 2;
            label2.Top = p.Y - label2.Height / 2;

            label1.Left += vx;
            label1.Top += vy;

            label3.Left = (ClientSize.Width) - (label3.Width);
            label3.Text = ("SCORE " + score);

            if(label1.Left <= 0)
            {
                vx = Math.Abs(vx);
            }
            if (label1.Top <= 0)
            {
                vy = Math.Abs(vy);
            }
            if (label1.Left >= (ClientSize.Width)-(label1.Width))
            {
                vx = -Math.Abs(vx);
            }
            if (label1.Top >= (ClientSize.Height)-(label1.Height))
            {
                vy = -Math.Abs(vy);
            }

            //label1の動きの向きになる矢印
            if (vx < 0 && vy < 0)
            {
                label1.Text = ("↖");
            }
            if (vx < 0 && vy > 0)
            {
                label1.Text = ("↙");
            }
            if (vx > 0 && vy < 0)
            {
                label1.Text = ("↗");
            }
            if (vx > 0 && vy > 0)
            {
                label1.Text = ("↘");
            }

            //label1が虹色
            label1.ForeColor = Color.FromArgb(lcr, lcg, lcb);
            if (lcr == 255 && lcg < 255 && lcb == 0)
            {
                lcg += vlcc;//赤～黄色でGを増やす
            }
            if (lcr > 0 && lcg == 255 && lcb == 0)
            {
                lcr -= vlcc;//黄色～緑でRを減らす
            }
            if (lcr == 0 && lcg == 255 && lcb < 255)
            {
                lcb += vlcc;//緑～水色でBを増やす
            }
            if (lcr == 0 && lcg > 0 && lcb == 255)
            {
                lcg -= vlcc;//水色～青でGを減らす
            }
            if (lcr < 255 && lcg == 0 && lcb == 255)
            {
                lcr += vlcc;//青～紫でRを増やす
            }
            if (lcr == 255 && lcg == 0 && lcb > 0)
            {
                lcb -= vlcc;//紫～赤でBを減らす
            }

            if (p.X >= label1.Left && p.X <= (label1.Left+label1.Width) && p.Y >= label1.Top && p.Y <= (label1.Top+label1.Height))
            {
                //label2.Visible=false;
                label2.Text = ("(´∀`)");
                label2.ForeColor = Color.FromArgb(255, 255, 255);
                score = score + 100;
            }
            else
            {
                //label2.Visible = true;
                label2.Text = ("(´Д`)");
                label2.ForeColor = Color.FromArgb(0, 0, 0);
                score = score;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("" + ClientSize.Width + ", " + ClientSize.Height);
            MessageBox.Show("" + label1.Width + ", " + label1.Height);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
