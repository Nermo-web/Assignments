using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            random = new Random();
            InitializeComponent();
        }
        int k = 6; // No of Workers
        int delay = 20; // Delay in Mili Seconds
        int NumberOfCircles = 1200;
        int i = 0;
        //Pen red = new Pen(Color.Red);
        //Pen green = new Pen(Color.Green);
        //Pen blue= new Pen(Color.Blue);
        //Pen Yellow = new Pen(Color.Yellow);
        //Pen Purple = new Pen(Color.Purple);
        int Coordinate1, Coordinate2;    
        //System.Drawing.SolidBrush filledred = new System.Drawing.SolidBrush(Color.Red);
        //System.Drawing.SolidBrush filledyellow = new System.Drawing.SolidBrush(Color.Yellow);
        //Rectangle rect = new Rectangle(20, 20, 220, 90);

        private Random random;
        private static readonly Random Random = new Random();
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            int Radius = 20;
            Random Cord = new Random();
            while (i < NumberOfCircles)
            {

                for(int j = 1; j<= k; j++)
                {
                    Coordinate1 = Cord.Next(0, 600);
                    Coordinate2 = Cord.Next(0, 800);
                    Graphics g = e.Graphics;
                    Pen RandomColor = new Pen(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)));
                    Rectangle circle = new Rectangle(Coordinate1, Coordinate2 , Radius*2, Radius*2);
                    g.DrawEllipse(RandomColor, circle);
                }
                i = i + k;
                System.Threading.Thread.Sleep(delay);
            }
            watch.Stop();
            if (i >= NumberOfCircles)
            {
                MessageBox.Show($"Execution of Program Completed, \n Execution Time: {watch.ElapsedMilliseconds} ms", "Execution Completed");
            }
            // g.DrawRectangle(red, rect);
        }
    }
}
