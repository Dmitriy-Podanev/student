using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Newtonsoft.Json;
using System.IO;

namespace _1
{
    public partial class Form1 : Form
    {
        Graphics g;
        int x0, y0, x1, y1;
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            //Clear();
        }

        private void Clear()
        {
            x0 = -1; y0 = -1; x1 = -1; y1 = -1;
            label2.Text = " ";
            label3.Text = " ";
            label5.Text = " ";
            label7.Text = " ";
            g.Clear(Color.White);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g.FillRectangle(Brushes.Red, 100, 100, 1, 1);  //used 1,1 for a pixel only
        }

        

        private void DrawPoint(int x, int y)
        {
            g.FillRectangle(Brushes.Black, x, y, 1, 1);
        }
        private void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }
        void BresenhamLine(int x0, int y0, int x1, int y1)
        {
            var angle = Math.Abs(y1 - y0) > Math.Abs(x1 - x0); // Проверяем рост отрезка по оси икс и по оси игрек
                                                               //если угол наклона слишком большой, отражаем по диагонали
            if (angle)
            {
                Swap(ref x0, ref y0); // Перетасовка координат вынесена в отдельную функцию
                Swap(ref x1, ref y1);
            }
            // меняем начало и конец отрезка местами, если линия растет не слева направо
            if (x0 > x1)
            {
                Swap(ref x0, ref x1);
                Swap(ref y0, ref y1);
            }
            int dx = x1 - x0;
            int dy = Math.Abs(y1 - y0);
            int error = dx / 2; // Здесь используется оптимизация с умножением на dx, чтобы избавиться от лишних дробей
            int ystep = (y0 < y1) ? 1 : -1; // Выбираем направление роста координаты y
            int y = y0;
            for (int x = x0; x <= x1; x++)
            {
                DrawPoint(angle ? y : x, angle ? x : y); // Возвращаем координаты на место
                error -= dy;
                if (error < 0)
                {
                    y += ystep;
                    error += dx;
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Clear();
            
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Text = e.X.ToString() + ":" + e.Y.ToString();
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            BresenhamLine(x0, y0, x1, y1);
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (x0 == -1 || y0 == -1)
            {
                x0 = e.X; y0 = e.Y;
                label2.Text = x0.ToString();
                label3.Text = y0.ToString();
            }
            else if (x1 == -1 || y1 == -1)
            {
                x1 = e.X; y1 = e.Y;
                label7.Text = x1.ToString();
                label5.Text = y1.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
