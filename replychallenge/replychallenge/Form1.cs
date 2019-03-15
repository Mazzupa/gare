using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace replychallenge
{
    public partial class Form1 : Form
    {
        Point previousCoordinates = new Point(0, 0);
        class COxyp
        {
            public int x, y, p;

            public COxyp(int x, int y, int p)
            {
                this.x = x;
                this.y = y;
                this.p = p;
            }
        }
        COxyp[] coxyp;
        bool found = false;
        int width, height, coNum, roNum;
        char[,] matrix;

        public Form1()
        {
            InitializeComponent();
        }

        static int charToValue(char c)
        {
            switch (c)
            {
                case '#':
                    return int.MaxValue;
                case '~':
                    return 800;
                case '*':
                    return 200;
                case '+':
                    return 150;
                case 'X':
                    return 120;
                case '_':
                    return 100;
                case 'H':
                    return 70;
                case 'T':
                    return 50;
                default:
                    return int.MaxValue;    //lancia errore
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        Color convertChar(char character)
        {
            switch(character)
            {
                case '#':
                    return Color.SaddleBrown;
                case '~':
                    return Color.LightBlue;
                case '*':
                    return Color.Red;
                case '+':
                    return Color.SandyBrown;
                case 'X':
                    return Color.LightSlateGray;
                case '_':
                    return Color.Green;
                case 'H':
                    return Color.DarkGray;
                case 'T':
                    return Color.LightGray;

            }
            return Color.Black;
        }

        void GraphicsOver(Bitmap baseImage, int x, int y, Bitmap bitmap)
        {
            using (Graphics g = Graphics.FromImage(baseImage))
            {
                g.CompositingMode = CompositingMode.SourceOver;
                g.DrawImage(bitmap, x, y);
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            label4.Text = "-";
            label6.Text = "-";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string jobString="";
            if (saveFileDialog2.ShowDialog() == DialogResult.OK)
            {
                for (int y=0; y<height; y++)
                {
                    for (int x=0; x<width; x++)
                    {
                        jobString += charToValue(matrix[x, y]) + "; ";
                    }
                    jobString += "\r\n";
                }
                File.WriteAllText(saveFileDialog2.FileName, jobString);
            }
        }

        Bitmap Color16(Color color)
        {
            Bitmap temp = new Bitmap(16, 16);
            using (Graphics gfx = Graphics.FromImage(temp))
            using (SolidBrush brush = new SolidBrush(color))
            {
                gfx.FillRectangle(brush, 0, 0, 16, 16);
            }
            return temp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string directory = openFileDialog1.FileName;

                StreamReader sr = new StreamReader(directory);

                string firstLine = sr.ReadLine();   //customer office, reply office
                string[] flArray = new string[4];
                flArray = firstLine.Split(' ');
                int.TryParse(flArray[0], out width);
                int.TryParse(flArray[1], out height);
                int.TryParse(flArray[2], out coNum);
                int.TryParse(flArray[3], out roNum);
                matrix = new char[width, height];   //mondo
                
                coxyp = new COxyp[coNum];
                string line = "";
                string[] coArray = new string[3];
                coArray = line.Split(' ');
                for (int i = 0; i < coNum; i++)
                {
                    int x, y, p;
                    line = sr.ReadLine();
                    coArray = line.Split(' ');
                    int.TryParse(coArray[0], out x);
                    int.TryParse(coArray[1], out y);
                    int.TryParse(coArray[2], out p);
                    coxyp[i] = new COxyp(x, y, p);
                }
                
                char casella;
                for (int ln = 0; ln < height; ln++)
                {
                    line = sr.ReadLine();
                    for (int cl = 0; cl < width; cl++)
                    {
                        casella = line[cl];
                        matrix[cl, ln] = casella;
                    }
                }
                
                Bitmap map = new Bitmap(width * 16, height * 16);
                
                for (int y = 0; y < height; y ++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        GraphicsOver(map, x * 16, y * 16, Color16(convertChar(matrix[x, y])));
                    }
                }

                foreach (COxyp coordinate in coxyp)
                {
                    GraphicsOver(map, coordinate.x * 16, coordinate.y * 16, Properties.Resources.office2);
                }

                pictureBox1.Image = map;

            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (coxyp != null)
            {
                int x = e.X / 16;
                int y = e.Y / 16;
                
                if ((previousCoordinates.X != x || previousCoordinates.Y != y))
                {
                    label4.Text = x + ", " + y;

                    string value = charToValue(matrix[x, y]).ToString();
                    if (value == int.MaxValue.ToString())
                    {
                        value = "-";
                    }
                    label6.Text = value;
                }

                foreach (COxyp coordinate in coxyp)
                {
                    if ((previousCoordinates.X != x || previousCoordinates.Y != y))
                    {
                        if (!found)
                        {
                            if (coordinate.x == x && coordinate.y == y)
                            {
                                label2.Text = coordinate.p.ToString();
                                found = true;
                            }
                            else
                            {
                                label2.Text = "-";
                            }
                        }
                    }
                    else
                    {
                        found = false;
                    }
                }
                previousCoordinates = new Point(x, y);
            }
        }
    }
}
