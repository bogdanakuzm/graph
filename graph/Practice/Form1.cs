using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;




namespace Practice
{
    public partial class Form1 : Form
    {
        double ScaleX, ScaleY;
        int x0, y0;
        private Point start_point;
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawGraphics();
        }
        private void DrawGraphics()
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            //Graphics g = pictureBox1.CreateGraphics();
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            double step = 0.01;
            int Xpmax, Ypmax, /*x0, y0,*/ x1, y1, x2, y2, count;
            double Xmax, Xmin, Ymax, Ymin, x, y;
            Xpmax = pictureBox1.Width;
            Ypmax = pictureBox1.Height;
            Xmin = int.Parse(textBox2.Text);
            Xmax = int.Parse(textBox4.Text);
            Ymin = int.Parse(textBox1.Text);
            Ymax = int.Parse(textBox3.Text);
            ScaleX = (Math.Abs(Xmax) + Math.Abs(Xmin))/ Xpmax;
            ScaleY = (Math.Abs(Ymax) + Math.Abs(Ymin))/ Ypmax;
            y0 = (int)(Math.Abs(Ymax) / (Math.Abs(Ymax) + Math.Abs(Ymin)) * Ypmax);
            x0 = (int)(Math.Abs(Xmin) / (Math.Abs(Xmax) + Math.Abs(Xmin)) * Xpmax);
            DrawCoordinate(x0, y0, Xmax, Ymin, pictureBox1.Width, pictureBox1.Height, g);
            x = Xmin;
            y = 0;
            count = (int)((Math.Abs(Xmax) + Math.Abs(Xmin)) / step);
            if (radioButton1.Checked)
            {
                y = x3(x);
            }
            else if (radioButton2.Checked)
            {
                y = parabola(x);
            }
            else if (radioButton3.Checked)
            {
                y = sin(x);
            }
            else if (radioButton4.Checked)
            {
                y = cos(x);
            }
            else if (radioButton5.Checked)
            {
                y = line(x);
            }
            else if (radioButton7.Checked)
            {
                y = absline(x);
            }
            else if (radioButton8.Checked)
            {
                y = sqrtline(0);
                x = 0;
                count = (int)(Math.Abs(Xmax) / step);
            }
            else if (radioButton9.Checked)
            {
                y = Gsin(x);
            }
            else if (radioButton10.Checked)
            {
                y = Gcos(x);
            }
            else if (radioButton11.Checked)
            {
                y = tg(x);
            }
            x1 = x0 + (int)Math.Round(x / ScaleX);
            y1 = y0 - (int)Math.Round(y / ScaleY);
            for (int i = 1; i < count; i++)
            {
                x = x + step;
                if (radioButton1.Checked)
                {
                    y = x3(x);
                    x2 = x0 + (int)Math.Round(x / ScaleX);
                    y2 = y0 - (int)Math.Round(y / ScaleY);
                    g.DrawLine(Pens.Red, x1, y1, x2, y2);
                    x1 = x2;
                    y1 = y2;
                }
                else if (radioButton2.Checked)
                {
                    y = parabola(x);
                    x2 = x0 + (int)Math.Round(x / ScaleX);
                    y2 = y0 - (int)Math.Round(y / ScaleY);
                    g.DrawLine(Pens.Red, x1, y1, x2, y2);
                    x1 = x2;
                    y1 = y2;
                }
                else if (radioButton3.Checked)
                {
                    y = sin(x);
                    x2 = x0 + (int)Math.Round(x / ScaleX);
                    y2 = y0 - (int)Math.Round(y / ScaleY);
                    g.DrawLine(Pens.Red, x1, y1, x2, y2);
                    x1 = x2;
                    y1 = y2;
                }
                else if (radioButton4.Checked)
                {
                    y = cos(x);
                    x2 = x0 + (int)Math.Round(x / ScaleX);
                    y2 = y0 - (int)Math.Round(y / ScaleY);
                    g.DrawLine(Pens.Red, x1, y1, x2, y2);
                    x1 = x2;
                    y1 = y2;
                }
                else if (radioButton5.Checked)
                {
                    y = line(x);
                    x2 = x0 + (int)Math.Round(x / ScaleX);
                    y2 = y0 - (int)Math.Round(y / ScaleY);
                    g.DrawLine(Pens.Red, x1, y1, x2, y2);
                    x1 = x2;
                    y1 = y2;
                }
                else if (radioButton7.Checked)
                {
                    y = absline(x);
                    x2 = x0 + (int)Math.Round(x / ScaleX);
                    y2 = y0 - (int)Math.Round(y / ScaleY);
                    g.DrawLine(Pens.Red, x1, y1, x2, y2);
                    x1 = x2;
                    y1 = y2;
                }
                else if (radioButton8.Checked)
                {
                    y = sqrtline(x);
                    x2 = x0 + (int)Math.Round(x / ScaleX);
                    y2 = y0 - (int)Math.Round(y / ScaleY);
                    g.DrawLine(Pens.Red, x1, y1, x2, y2);
                    x1 = x2;
                    y1 = y2;
                }
                else if (radioButton9.Checked)
                {

                    y = Gsin(x);
                    x2 = x0 + (int)Math.Round(x / ScaleX);
                    y2 = y0 - (int)Math.Round(y / ScaleY);
                    g.DrawLine(Pens.Red, x1, y1, x2, y2);
                    x1 = x2;
                    y1 = y2;

                }
                else if (radioButton10.Checked)
                {

                    y = Gcos(x);
                    x2 = x0 + (int)Math.Round(x / ScaleX);
                    y2 = y0 - (int)Math.Round(y / ScaleY);
                    g.DrawLine(Pens.Red, x1, y1, x2, y2);
                    x1 = x2;
                    y1 = y2;

                }
                else if (radioButton11.Checked)
                {

                    y = tg(x);
                    x2 = x0 + (int)Math.Round(x / ScaleX);
                    y2 = y0 - (int)Math.Round(y / ScaleY);
                    g.DrawLine(Pens.Red, x1, y1, x2, y2);
                    x1 = x2;
                    y1 = y2;

                }
            }
            if (radioButton6.Checked)
            {
                int Xcircle = int.Parse(textBox18.Text);
                int Ycircle = int.Parse(textBox19.Text);
                int Radius = int.Parse(textBox20.Text);
                int x11 = x0 + (int)Math.Round(Xcircle / ScaleX) - (int)Math.Round(Radius / ScaleX);
                int y11 = y0 - (int)Math.Round(Ycircle / ScaleY) - (int)Math.Round(Radius / ScaleY);
                int width = (int)Math.Round(2 * Radius / ScaleX);
                int height = (int)Math.Round(2 * Radius / ScaleY);
                g.DrawEllipse(Pens.Red, x11, y11, width, height);
            }
            pictureBox1.Image = bmp;
        }

        private double x3(double x)
        {
            double A = double.Parse(textBox5.Text);
            double B = double.Parse(textBox10.Text);
            double C = double.Parse(textBox9.Text);
            double D = double.Parse(textBox11.Text);
            double y = A * Math.Pow(x, 3) + B * Math.Pow(x, 2) + C * x + D;
            return y;
        }

        private double parabola(double x)
        {
            double A = double.Parse(textBox6.Text);
            double B = double.Parse(textBox7.Text);
            double C = double.Parse(textBox8.Text);
            double y = A * Math.Pow(x, 2) + B * x + C;
            return y;
        }
        private double sin(double x)
        {
            double A = double.Parse(textBox12.Text);
            int B = int.Parse(textBox13.Text);
            double y = A * Math.Sin(B * x);
            return y;
        }
        private double cos(double x)
        {
            double A = double.Parse(textBox14.Text);
            double B = double.Parse(textBox15.Text);
            double y = A * Math.Cos(B * x);
            return y;
        }

        private double line(double x)
        {
            double k = double.Parse(textBox16.Text);
            double b = double.Parse(textBox17.Text);
            double y = k * x + b;
            return y;
        }
        private double absline(double x)
        {
            double k = double.Parse(textBox21.Text);
            double b = double.Parse(textBox22.Text);
            double p = double.Parse(textBox23.Text);
            double y = p * Math.Abs(k * x + b);
            return y;
        }
        private double sqrtline(double x)
        {
            double y = 0;
            double k = double.Parse(textBox24.Text);
            double b = double.Parse(textBox25.Text);
            double p = double.Parse(textBox26.Text);
            y = p * Math.Sqrt(k * x + b);
            return y;
        }
        private double Gsin(double x)
        {
            double y = 0;
            double A = double.Parse(textBox28.Text);
            y = A*Math.Sinh(x);
            return y;
        }
        private double Gcos(double x)
        {
            double y = 0;
            double A = double.Parse(textBox27.Text);
            y = A*Math.Cosh(x);
            return y;
        }
        private double tg(double x)
        {
            double y = 0;
            double A = double.Parse(textBox29.Text);
            double B = double.Parse(textBox30.Text);
            y = A * Math.Tan(B*x);
            return y;
        }
        private void DrawCoordinate(int x0, int y0, double Xmax, double Ymin, int width, int height, Graphics g)
        {
            int count = 0;
            Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 3);
            SolidBrush solBrush = new SolidBrush(Color.Black);
            Font f = new Font("Tahoma", 10, FontStyle.Bold);
            g.DrawLine(blackPen, x0, 0, x0, height);
            g.DrawLine(blackPen, 0, y0, width, y0);
            g.DrawString("0", f, solBrush, x0-15, y0);
            g.DrawString("Y", f, solBrush, x0 -15, 0);
            g.DrawString("X", f, solBrush, width-15, y0-15);
            solBrush = new SolidBrush(Color.Black);
            f = new Font("Arial", 8);
            float stepY = (float)((height - y0) / Math.Abs(Ymin));
            float stepX = (float)((width - x0) / Math.Abs(Xmax));
            for (float i = x0 - stepX; i > 0; i -= stepX)
            {
                count--;
                g.DrawLine(Pens.Gray, i, 0, i, height);
                g.DrawString(string.Format("{0}",count), f, solBrush, i-15, y0+2);
            }
            count = 0;
            for (float i = x0 + stepX; i < width; i += stepX)
            {
                count++;
                g.DrawLine(Pens.Gray, i, 0, i, height);
                g.DrawString(string.Format("{0}", count), f, solBrush, i-11, y0+2);
            }
            count = 0;
            for (float i = y0 - stepY; i > 0; i -= stepY)
            {
                count++;
                g.DrawLine(Pens.Gray, 0, i, width, i);
                g.DrawString(string.Format("{0}", count), f, solBrush, x0-11, i);
            }
            count = 0;
            for (float i = y0 + stepY; i < height; i += stepY)
            {
                count--;
                g.DrawLine(Pens.Gray, 0, i, width, i);
                g.DrawString(string.Format("{0}", count), f, solBrush, x0-15, i);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|PNG Image|*.png";
                sfd.Title = "Сохранение картинки в файл";
                sfd.ShowDialog();
                if (sfd.FileName != "")
                {
                    switch (Path.GetExtension(sfd.FileName).ToUpper())
                    {
                        case ".JPG":
                            pictureBox1.Image.Save(sfd.FileName, ImageFormat.Jpeg);
                            break;
                        case ".BMP":
                            pictureBox1.Image.Save(sfd.FileName, ImageFormat.Bmp);
                            break;
                        case ".PNG":
                            pictureBox1.Image.Save(sfd.FileName, ImageFormat.Png);
                            break;
                        case ".GIF":
                            pictureBox1.Image.Save(sfd.FileName, ImageFormat.Gif);
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Ни один график не был нарисован", "DrawGraphics", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            label32.Text = "X: ------";
            label33.Text = "Y: ------";
        }
        
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            label32.Text = "X: " + string.Format("{0:F3}", (e.X-x0) * ScaleX);
            label33.Text = "Y: " + string.Format("{0:F3}", (e.Y-y0) * ScaleY);
            Graphics g = pictureBox1.CreateGraphics();

            //pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //Bitmap bmp = new Bitmap(pictureBox1.Image);
            //Graphics g = Graphics.FromImage(bmp); 

            if (e.Button == MouseButtons.Left)
            {
                Pen p = new Pen(Color.Black, 1);
                g.DrawLine(p, start_point, e.Location);
                start_point = e.Location;

            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|PNG Image|*.png";
                sfd.Title = "Сохранение картинки в файл";
                sfd.ShowDialog();
                if (sfd.FileName != "")
                {
                    switch (Path.GetExtension(sfd.FileName).ToUpper())
                    {
                        case ".JPG":
                            pictureBox1.Image.Save(sfd.FileName, ImageFormat.Jpeg);
                            break;
                        case ".BMP":
                            pictureBox1.Image.Save(sfd.FileName, ImageFormat.Bmp);
                            break;
                        case ".PNG":
                            pictureBox1.Image.Save(sfd.FileName, ImageFormat.Png);
                            break;
                        case ".GIF":
                            pictureBox1.Image.Save(sfd.FileName, ImageFormat.Gif);
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Ни один график не был нарисован", "DrawGraphics", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DrawGraphics();
        }

        private void авторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Подолянский Дмитрий, группа 205(c)","Автор", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Построитель графиков функций:\nВы можете выбрать любой из предоставленных графиков и построить их.\nЕсть такие графики:\nКубическая парабола,\nКвадратичная парабола,\nСинус,\nКосинус,\nПрямая,\nОкружность,\nГрафик модуля,\nКорень из х,\nГиперболический синус,\nГиперболический косинус", 
                "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}