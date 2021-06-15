using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace CHM_laba_6
{
    public partial class Form1 : Form
    {
        List<List<double[]>> First_Point = new List<List<double[]>>();

        public Form1()
        {
            InitializeComponent();
        }

        private double F1(double t, double x, double y)
        {
            return (x + y) * (x + y) - 1;
        }

        private double F2(double t, double x, double y)
        {
            return ((-y) * y) - x + 1;
        }

        private void Method(double a, double b)
        {
            List<double[]> Up = new List<double[]>();
            List<double[]> Down = new List<double[]>();
            List<double[]> Left = new List<double[]>();
            List<double[]> Right = new List<double[]>();
            List<double[]> RU = new List<double[]>();
            List<double[]> RD = new List<double[]>();
            List<double[]> LD = new List<double[]>();
            List<double[]> LU = new List<double[]>();
            List<double[]> RU2 = new List<double[]>();
            List<double[]> RD2 = new List<double[]>();
            List<double[]> LD2 = new List<double[]>();
            List<double[]> LU2 = new List<double[]>();

            double xk, h = 0.05, yk;
            xk = a + 0.01; yk = b;
            for (double t = 0; /*xk != double.NaN &&*/ Math.Abs(yk) < 100 && Math.Abs(xk) < 100 &&/* !double.IsInfinity(yk) &&*/ t < 10; t += h)
            {
                Right.Add(new double[] { xk, yk });
                //xk = a + i * h;
                double[] Q1 = new double[] { h * F1(t, xk, yk), h * F2(t, xk, yk) };
                double[] Q2 = new double[] { h * F1(t+h/2, xk + Q1[0] / 2, yk + Q1[1] / 2), h * F2(t + h / 2, xk + Q1[0] / 2, yk + Q1[1] / 2) };
                double[] Q3 = new double[] { h * F1(t + h / 2, xk + Q2[0] / 2, yk + Q2[1] / 2), h * F2(t + h / 2, xk + Q2[0] / 2, yk + Q2[1] / 2) };
                double[] Q4 = new double[] { h * F1(t + h, xk + Q3[0], yk + Q3[1]), h * F2(t + h, xk + Q3[0], yk + Q3[1]) };
                xk += ((Q1[0] + 2 * Q2[0] + 2 * Q3[0] + Q4[0]) / 6);
                yk += ((Q1[1] + 2 * Q2[1] + 2 * Q3[1] + Q4[1]) / 6);
            }
            Draw_Line(Right);

            xk = a - 0.01; yk = b;
            for (double t = 0; /*xk != double.NaN &&*/ Math.Abs(yk) < 100 && Math.Abs(xk) < 100 &&/* !double.IsInfinity(yk) &&*/ t < 10; t += h)
            {
                Left.Add(new double[] { xk, yk });
                //xk = a + i * h;
                double[] Q1 = new double[] { h * F1(t, xk, yk), h * F2(t, xk, yk) };
                double[] Q2 = new double[] { h * F1(t + h / 2, xk + Q1[0] / 2, yk + Q1[1] / 2), h * F2(t + h / 2, xk + Q1[0] / 2, yk + Q1[1] / 2) };
                double[] Q3 = new double[] { h * F1(t + h / 2, xk + Q2[0] / 2, yk + Q2[1] / 2), h * F2(t + h / 2, xk + Q2[0] / 2, yk + Q2[1] / 2) };
                double[] Q4 = new double[] { h * F1(t + h, xk + Q3[0], yk + Q3[1]), h * F2(t + h, xk + Q3[0], yk + Q3[1]) };
                xk += ((Q1[0] + 2 * Q2[0] + 2 * Q3[0] + Q4[0]) / 6);
                yk += ((Q1[1] + 2 * Q2[1] + 2 * Q3[1] + Q4[1]) / 6);
            }
            Draw_Line(Left);

            xk = a; yk = b + 0.01;
            for (double t = 0; /*xk != double.NaN &&*/ Math.Abs(yk) < 100 && Math.Abs(xk) < 100 &&/* !double.IsInfinity(yk) &&*/ t < 10; t += h)
            {
                Up.Add(new double[] { xk, yk });
                //xk = a + i * h;
                double[] Q1 = new double[] { h * F1(t, xk, yk), h * F2(t, xk, yk) };
                double[] Q2 = new double[] { h * F1(t + h / 2, xk + Q1[0] / 2, yk + Q1[1] / 2), h * F2(t + h / 2, xk + Q1[0] / 2, yk + Q1[1] / 2) };
                double[] Q3 = new double[] { h * F1(t + h / 2, xk + Q2[0] / 2, yk + Q2[1] / 2), h * F2(t + h / 2, xk + Q2[0] / 2, yk + Q2[1] / 2) };
                double[] Q4 = new double[] { h * F1(t + h, xk + Q3[0], yk + Q3[1]), h * F2(t + h, xk + Q3[0], yk + Q3[1]) };
                xk += ((Q1[0] + 2 * Q2[0] + 2 * Q3[0] + Q4[0]) / 6);
                yk += ((Q1[1] + 2 * Q2[1] + 2 * Q3[1] + Q4[1]) / 6);
            }
            Draw_Line(Up);

            xk = a; yk = b - 0.01;
            for (double t = 0; /*xk != double.NaN &&*/ Math.Abs(yk) < 100 && Math.Abs(xk) < 100 &&/* !double.IsInfinity(yk) &&*/ t < 10; t += h)
            {
                Down.Add(new double[] { xk, yk });
                //xk = a + i * h;
                double[] Q1 = new double[] { h * F1(t, xk, yk), h * F2(t, xk, yk) };
                double[] Q2 = new double[] { h * F1(t + h / 2, xk + Q1[0] / 2, yk + Q1[1] / 2), h * F2(t + h / 2, xk + Q1[0] / 2, yk + Q1[1] / 2) };
                double[] Q3 = new double[] { h * F1(t + h / 2, xk + Q2[0] / 2, yk + Q2[1] / 2), h * F2(t + h / 2, xk + Q2[0] / 2, yk + Q2[1] / 2) };
                double[] Q4 = new double[] { h * F1(t + h, xk + Q3[0], yk + Q3[1]), h * F2(t + h, xk + Q3[0], yk + Q3[1]) };
                xk += ((Q1[0] + 2 * Q2[0] + 2 * Q3[0] + Q4[0]) / 6);
                yk += ((Q1[1] + 2 * Q2[1] + 2 * Q3[1] + Q4[1]) / 6);
            }
            Draw_Line(Down);

        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[] Q1 = new double[] { };
            double h = 0.05, xk = 0, yk = 0;
            //Q1 = new double[] { h * F1(xk, yk), h * F2(xk, yk) };
            //у нас есть 4 особые точки
            //1 0
            //0 1
            //0 -1
            //-3 2
            double a0 = 1, a1 = 0;
            double b0 = 0, b1 = 1;
            double c0 = 0, c1 = -1;
            double d0 = -3, d1 = 2;
            Draw_Point();

            Method(a0, a1);
            Method(b0, b1);
            Method(c0, c1);
            Method(d0, d1);


            //Method(0.8, 0);
            //Method(1.5, 0);


            //Method(0, 0.5);
            //Method(-1, 3);


            //Method(1, -0.5);
            //Method(-1, -1);


            //Method(-3, 5);
            //Method(-4.5, 1);
            //Method(-2, -1);
        }

        private void Draw_Line(List<double[]> Line)
        {
            //настройка области
            GraphPane pane = zgc.GraphPane;
            //pane.CurveList.Clear();
            pane.XAxis.Title.Text = "Ось X";
            pane.YAxis.Title.Text = "Ось Y";
            pane.XAxis.MajorGrid.IsZeroLine = true;

            //координаты отображаемой области
            pane.XAxis.Scale.Min = -5;
            pane.XAxis.Scale.Max = 5;
            pane.YAxis.Scale.Min = -5;
            pane.YAxis.Scale.Max = 5;
            zgc.AxisChange();

            //списки точек 
            //PointPairList list = new PointPairList();
            PointPairList list2 = new PointPairList();

            //list.Add(Line[0][0], Line[0][1]);
            //list.Add(Line[1][0], Line[1][1]);
            for (int i = 0; i < Line.Count; ++i)
            {
                list2.Add(Line[i][0], Line[i][1]);
            }
            //list2.Add(Figure[0][0], Figure[0][1]);
            Random random = new Random();
            LineItem line_ = pane.AddCurve("", list2, Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)), SymbolType.None);
            line_.Line.Width = 1;
            //LineItem myFig = pane.AddCurve("", list2, Color.Black, SymbolType.Circle);
            zgc.Invalidate();
            zgc.AxisChange();
        }

        private void Draw_Point()
        {
            //настройка области
            GraphPane pane = zgc.GraphPane;
            //pane.CurveList.Clear();
            pane.XAxis.Title.Text = "Ось X";
            pane.YAxis.Title.Text = "Ось Y";
            pane.XAxis.MajorGrid.IsZeroLine = true;

            //координаты отображаемой области
            pane.XAxis.Scale.Min = -5;
            pane.XAxis.Scale.Max = 5;
            pane.YAxis.Scale.Min = -5;
            pane.YAxis.Scale.Max = 5;
            zgc.AxisChange();

            //списки точек 
            //PointPairList list = new PointPairList();
            PointPairList list2 = new PointPairList();
            list2.Add(1, 0);
            list2.Add(0, 1);
            list2.Add(0, -1);
            list2.Add(-3, 2);
            //Random random = new Random();
            //LineItem line_ = pane.AddCurve("", list2, Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)), SymbolType.None);
            LineItem line_ = pane.AddCurve("", list2, Color.Red, SymbolType.Circle);
            line_.Line.IsVisible = false;
            line_.Symbol.Size = 10;
            //LineItem myFig = pane.AddCurve("", list2, Color.Black, SymbolType.Circle);
            zgc.Invalidate();
            zgc.AxisChange();
        }
    }
}
