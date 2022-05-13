using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafika_Komputerowa_Lab2
{
    public partial class Form1 : Form
    {
        DirectBitmap DrawArea;
        DirectBitmap Texture;
        DirectBitmap NormalMap;
        Timer mainTimer = new Timer();
        Timer timerForPit = new Timer();
        List<Vertice> vertices = new List<Vertice>();
        List<Triangle> triangles = new List<Triangle>();
        Vertice vertCenter;
        Vertice caughtVertice;
        Color colorOfObject = Color.Yellow;
        Color colorOfLight = Color.FromArgb(255, 255, 255);
        Point mouseToCaughtVertice;
        bool movingVertice;
        bool accurateColoring = true;
        bool drawingTexture;
        bool centerToPeriphery = true;
        bool standardNormalMap = true;
        int Radius;
        int xCenter; int yCenter; //zCenter=0
        int xLight; int yLight; int zLight;
        int xPit, yPit, pitRadius, pitDistance;
        int countCircles;
        int countVerticesInCircle;
        int heightOfCut;
        int xMinOfCut;
        double Kd; double Ks; int m;
        double a = 0.1; double b = 0.2;
        double minTheta; double dTheta; double theta;
        double sigma; double dSigma;
        double[,] NxTexture; double[,] NyTexture; double[,] NzTexture;
        double[,] NxCircle; double[,] NyCircle; double[,] NzCircle;
        double kTexture;
        string texture1 = "Landscape.jpg";
        string texture2 = "Wroclaw-central-market-square.jpg";
        string normalMap1 = "Bubbles.png";
        string normalMap2 = "normal_map-defaults.jpg";
        public Form1()
        {
            InitializeComponent();
            InitializeForm();
            xLight = pictureBox.Width / 2; yLight = pictureBox.Height / 2;
            zLight = zLightHScrollBar.Value;
            double ykr = Math.Log(0.2 / a);
            minTheta = Math.Log(0.2 / a) / b;
            dTheta = (15.0 * Math.PI / 180);
            theta = minTheta + 60 * dTheta;
            sigma = 0;
            dSigma = 5;
            pitRadius = 30;
            coloringComboBox.SelectedItem = "Accurate";
            mainTimer.Tick += new EventHandler(mainTimerEventProcessor);
            mainTimer.Interval = 50;
            mainTimer.Start();
            timerForPit.Tick += new EventHandler(pitTimerEventProcessor);
            timerForPit.Interval = 100;
            timerForPit.Start();
        }

        private void InitializeForm()
        {
            DrawArea = new DirectBitmap(pictureBox.Size.Width, pictureBox.Size.Height);
            pictureBox.Image = DrawArea.Bitmap;
            countCircles = triangulationAccuracyHScrollBar.Value;
            countVerticesInCircle = triangulationAccuracyHScrollBar.Value;
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            Triangulate();
            SetTexture(texture1);
            SetNormalMap(normalMap1);
            DrawScene();
        }
        private void DrawScene()
        {
            mainTimer.Stop();
            DrawArea.Dispose();
            DrawArea = new DirectBitmap(pictureBox.Size.Width, pictureBox.Size.Height);
            pictureBox.Image = DrawArea.Bitmap;
            FillPictureBox();
            NxCircle = new double[pictureBox.Width, pictureBox.Height];
            NyCircle = new double[pictureBox.Width, pictureBox.Height];
            NzCircle = new double[pictureBox.Width, pictureBox.Height];
            CountNCircle();
            CountPit();
            Task[] tasks = new Task[triangles.Count];
            int j = 0;
            int i;
            for (i = 0; i < tasks.Length; i++)
            {
                Triangle temp = triangles[i];
                tasks[i] = Task.Factory.StartNew(() => FillPolygon(temp, DrawArea, colorOfObject));
                j++;
            }
            j = 0;
            Task.WaitAll(tasks);
            mainTimer.Start();
        }


        private void FillPictureBox()
        {
            Graphics g = Graphics.FromImage(DrawArea.Bitmap);
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(Color.Black);
            g.FillRectangle(myBrush, 0, 0, pictureBox.Width, pictureBox.Height);
            myBrush.Dispose();
            g.Dispose();
        }
        private void Triangulate()
        {
            Radius = Math.Min(pictureBox.Image.Width / 2 - 50,
                                    pictureBox.Height / 2 - 50);
            xCenter = Radius + 50; yCenter = Radius + 50;
            xMinOfCut = xCenter;
            heightOfCut = heightOfCutHScrollBar.Value;
            vertices = new List<Vertice>();
            triangles = new List<Triangle>();
            countCircles = triangulationAccuracyHScrollBar.Value;
            countVerticesInCircle = triangulationAccuracyHScrollBar.Value;
            Ks = (double)ksHScrollBar.Value / 100; Kd = (double)kdHScrollBar.Value / 100;
            m = mHScrollBar.Value;
            kTexture = ((double)kHScrollBar.Value) / 100;
            vertCenter = new Vertice(xCenter, yCenter);
            int r = (Radius - 1) / countCircles;
            double alfa = 360 / countVerticesInCircle;
            int j; int i;

            //Creating of vertices
            for (j = 1; j < countCircles + 1; j++)
                for (i = 0; i < countVerticesInCircle; i++)
                {
                    vertices.Add(new Vertice((int)Math.Round(xCenter + j * r * Math.Sin((double)(i * alfa + j * alfa / 2) * Math.PI / 180)),
                                      (int)Math.Round(yCenter + j * r * Math.Cos((double)(i * alfa + j * alfa / 2) * Math.PI / 180))));
                }

            //Creating of Triangles
            int k;
            for (k = 0; k < countVerticesInCircle - 1; k++)
                triangles.Add(new Triangle(vertCenter, vertices[k], vertices[k + 1]));
            triangles.Add(new Triangle(vertCenter, vertices[k], vertices[0]));
            for (j = 0; j < countCircles; j++)
            {
                for (i = 0; i < countVerticesInCircle - 1; i++)
                {
                    if (j < countCircles - 1)
                    {
                        triangles.Add(new Triangle(vertices[j * countVerticesInCircle + i],
                                            vertices[j * countVerticesInCircle + i + 1],
                                            vertices[(j + 1) * countVerticesInCircle + i]));
                        triangles.Add(new Triangle(vertices[j * countVerticesInCircle + i + 1],
                                                vertices[(j + 1) * countVerticesInCircle + i + 1],
                                             vertices[(j + 1) * countVerticesInCircle + i]));
                    }
                }
                if (j < countCircles - 1)
                {
                    triangles.Add(new Triangle(vertices[j * countVerticesInCircle + i],
                                            vertices[j * countVerticesInCircle],
                                            vertices[(j + 1) * countVerticesInCircle + i]));
                    triangles.Add(new Triangle(vertices[j * countVerticesInCircle],
                                                vertices[(j + 1) * countVerticesInCircle],
                                             vertices[(j + 1) * countVerticesInCircle + i]));
                }
            }
        }
        private void triangulationAccuracyHScrollBar_ValueChanged(object sender, EventArgs e)
        {
            Triangulate();
            DrawScene();
        }
        private void kdHScrollBar_ValueChanged(object sender, EventArgs e)
        {
            Kd = (double)kdHScrollBar.Value / 100;
            DrawScene();
        }
        private void ksHScrollBar_ValueChanged(object sender, EventArgs e)
        {
            Ks = (double)ksHScrollBar.Value / 100;
            DrawScene();
        }
        private void mHScrollBar_ValueChanged(object sender, EventArgs e)
        {
            m = mHScrollBar.Value;
            DrawScene();
        }
        private void kHScrollBar_ValueChanged(object sender, EventArgs e)
        {
            kTexture = ((double)kHScrollBar.Value) / 100;
            DrawScene();
        }
        private void zLightHScrollBar_ValueChanged(object sender, EventArgs e)
        {
            zLight = zLightHScrollBar.Value;
            DrawScene();
        }
        private void changeObjectsColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                colorOfObject = colorDialog1.Color;
                //DrawScene();
            }
        }
        private void changeLightsColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                colorOfLight = colorDialog2.Color;
                // DrawScene();
            }
        }
        private void coloringComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void coloringComboBox_TextUpdate(object sender, EventArgs e)
        {
            //if (coloringComboBox.Text == "Interpolation")
            //    accurateColoring = false;
            //else
            //    accurateColoring = true;
            //DrawScene();
        }
        private void coloringComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (((string)coloringComboBox.SelectedItem).Contains("Interpolation"))
                accurateColoring = false;
            else
                accurateColoring = true;
            //DrawScene();
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Point mousePos = pictureBox.PointToClient(Control.MousePosition);
            foreach (var triangle in triangles)
            {
                Vertice vert = triangle.FindVertice(mousePos.X, mousePos.Y);
                if (vert != null)
                {
                    movingVertice = true;
                    caughtVertice = vert;
                    caughtVertice.color = Color.Green;
                    mouseToCaughtVertice = new Point(caughtVertice.x - mousePos.X,
                                                        caughtVertice.y - mousePos.Y);
                    return;
                }
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (movingVertice)
            {
                Point mousePos = pictureBox.PointToClient(Control.MousePosition);
                caughtVertice.x = mousePos.X + mouseToCaughtVertice.X;
                caughtVertice.y = mousePos.Y + mouseToCaughtVertice.Y;
                //DrawScene();
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (movingVertice)
            {
                movingVertice = false;
                caughtVertice.color = Color.Red;
                caughtVertice = null;
                //DrawScene();
            }
        }
        public void FillPolygon(Polygon polygon, DirectBitmap DrawArea, Color color)
        {
            List<Node> nodes = new List<Node>();
            List<Vertice> list = new List<Vertice>(polygon.vertices);
            double squareOfPolygon = polygon.Square();
            Color[] colorsOfVertices = new Color[list.Count];
            for (int i = 0; i < list.Count; i++)
                colorsOfVertices[i] = CountColorOfPixel(list[i].x, list[i].y);
            list.Sort(delegate (Vertice vert1, Vertice vert2)
            {
                return vert1.y.CompareTo(vert2.y);
            });
            int[] ind = new int[list.Count];
            for (int i = 0; i < list.Count; i++)
                ind[i] = polygon.vertices.IndexOf(list[i]);
            int yMin = polygon.vertices[ind[0]].y;
            int yMax = polygon.vertices[ind[ind.Count() - 1]].y;
            int k = 0;
            for (int y = yMin + 1; y < yMax; y++)
            {
                foreach (var vert in polygon.vertices)
                    if (polygon.vertices[ind[k]].y == y - 1)
                    {
                        if (ind[k] > 0 && ind[k] < list.Count - 1)
                        {
                            if (polygon.vertices[ind[k] - 1].y >= polygon.vertices[ind[k]].y)
                            {
                                AddNode(nodes, polygon.vertices[ind[k] - 1], polygon.vertices[ind[k]]);
                                //dodaj krawedz P(ind[k-1])P(ind[k]) do AET
                            }
                            else
                            {
                                RemoveNode(nodes, polygon.vertices[ind[k] - 1], polygon.vertices[ind[k]]);
                                //usun krawedz P(ind[k-1])P(ind[k]) z AET
                            }
                            if (polygon.vertices[ind[k] + 1].y >= polygon.vertices[ind[k]].y)
                            {
                                AddNode(nodes, polygon.vertices[ind[k] + 1], polygon.vertices[ind[k]]);
                                //dodaj krawedz P(ind[k+1])P(ind[k]) do AET
                            }
                            else
                            {
                                RemoveNode(nodes, polygon.vertices[ind[k] + 1], polygon.vertices[ind[k]]);
                                //usun krawedz P(ind[k+1])P(ind[k]) z AET
                            }
                        }
                        else
                        {
                            if (ind[k] == 0)
                            {
                                if (polygon.vertices[list.Count - 1].y >= polygon.vertices[ind[k]].y)
                                {
                                    AddNode(nodes, polygon.vertices[list.Count - 1],
                                                    polygon.vertices[ind[k]]);
                                    //dodaj krawedz P(ind[list.Count-1])P(ind[k]) do AET
                                }
                                else
                                {
                                    RemoveNode(nodes, polygon.vertices[list.Count - 1],
                                                    polygon.vertices[ind[k]]);
                                    //usun krawedz P(ind[list.Count-1])P(ind[k]) z AET
                                }
                                if (polygon.vertices[ind[k] + 1].y >= polygon.vertices[ind[k]].y)
                                {
                                    AddNode(nodes, polygon.vertices[ind[k] + 1], polygon.vertices[ind[k]]);
                                    //dodaj krawedz P(ind[k+1])P(ind[k]) do AET
                                }
                                else
                                {
                                    RemoveNode(nodes, polygon.vertices[ind[k] + 1], polygon.vertices[ind[k]]);
                                    //usun krawedz P(ind[k+1])P(ind[k]) z AET
                                }
                            }
                            else if (ind[k] == list.Count - 1)
                            {
                                if (polygon.vertices[ind[k] - 1].y >= polygon.vertices[ind[k]].y)
                                {
                                    AddNode(nodes, polygon.vertices[ind[k] - 1], polygon.vertices[ind[k]]);
                                    //dodaj krawedz P(ind[k-1])P(ind[k]) do AET
                                }
                                else
                                {
                                    RemoveNode(nodes, polygon.vertices[ind[k] - 1], polygon.vertices[ind[k]]);
                                    //usun krawedz P(ind[k-1])P(ind[k]) z AET
                                }
                                if (polygon.vertices[0].y >= polygon.vertices[ind[k]].y)
                                {
                                    AddNode(nodes, polygon.vertices[0], polygon.vertices[ind[k]]);
                                    //dodaj krawedz P(ind[0])P(ind[k]) do AET
                                }
                                else
                                {
                                    RemoveNode(nodes, polygon.vertices[0], polygon.vertices[ind[k]]);
                                    //usun krawedz P(ind[0])P(ind[k]) z AET
                                }
                            }
                        }
                        k++;
                    }
                nodes.Sort(delegate (Node node1, Node node2)
                {
                    return node1.x.CompareTo(node2.x);
                });
                for (int i = 0; i < nodes.Count; i += 2)
                {
                    for (int j = (int)nodes[i].x + 2; j < nodes[i + 1].x - 2; j++)
                    {
                        if (accurateColoring)
                            DrawArea.SetPixel(j, y, CountColorOfPixel(j, y));
                        else
                            DrawArea.SetPixel(j, y, CountInterpolationColor(squareOfPolygon,
                                polygon.vertices, colorsOfVertices, j, y));
                    }
                }
                foreach (var node in nodes)
                    node.IncreaseX();
            }
        }
        private void AddNode(List<Node> nodes, Vertice vert1, Vertice vert2)
        {
            if (vert1.y != vert2.y)
            {
                int yMax; double x; double a;
                yMax = vert1.y;
                a = ((double)(vert2.x - vert1.x)) / ((double)(vert2.y - vert1.y));
                x = (double)vert2.x + a;
                nodes.Add(new Node(yMax, x, a));
            }
        }
        private void RemoveNode(List<Node> nodes, Vertice vert1, Vertice vert2)
        {
            int yMax; double x; double a;
            yMax = vert2.y;
            a = ((double)(vert2.x - vert1.x)) / ((double)(vert2.y - vert1.y));
            x = (double)vert2.x + a;
            int ind = -1;
            foreach (var node in nodes)
                if (node.Compare(yMax, x, a))
                    ind = nodes.IndexOf(node);
            if (ind >= 0)
                nodes.RemoveAt(ind);
        }
        private Color CountColorOfPixel(int x, int y)
        {
            double z = Math.Sqrt(Math.Pow(Radius, 2) - Math.Pow(x - xCenter, 2) - Math.Pow(y - yCenter, 2));
            double Nx, Ny, Nz;
            double nxCircle = NxCircle[x, y];
            double nyCircle = NyCircle[x, y];
            double nzCircle = NzCircle[x, y];
            if (standardNormalMap)
            {
                Nx = nxCircle;
                Ny = nyCircle;
                Nz = nzCircle;
            }
            else
            {
                double Bx, By, Bz;
                if (nxCircle == 0 && nyCircle == 0 && nzCircle == 1)
                {
                    Bx = 0; By = 1; Bz = 0;
                }
                else
                {
                    (Bx, By, Bz) =
                        CrossProduct(nxCircle, nyCircle, nzCircle, 0, 0, 1);
                }
                double BLen = Math.Sqrt(Math.Pow(Bx, 2) + Math.Pow(By, 2) + Math.Pow(Bz, 2));
                if (BLen != 0)
                {
                    Bx /= BLen; By /= BLen; Bz /= BLen;
                }
                (double Tx, double Ty, double Tz) =
                     CrossProduct(Bx, By, Bz, nxCircle, nyCircle, nzCircle);
                double TLen = Math.Sqrt(Math.Pow(Tx, 2) + Math.Pow(Ty, 2) + Math.Pow(Tz, 2));
                if (TLen != 0)
                {
                    Tx /= TLen; Ty /= TLen; Tz /= TLen;
                }
                int q;
                if (kTexture > 0.9)
                    q = 5;
                Nx = kTexture * nxCircle + (1.00 - kTexture) *
                    (Tx * NxTexture[x, y] + Bx * NyTexture[x, y] + nxCircle * NzTexture[x, y]);
                Ny = kTexture * nyCircle + (1.00 - kTexture) *
                    (Ty * NxTexture[x, y] + By * NyTexture[x, y] + nyCircle * NzTexture[x, y]);
                Nz = kTexture * nzCircle + (1.00 - kTexture) *
                    (Tz * NxTexture[x, y] + Bz * NyTexture[x, y] + nzCircle * NzTexture[x, y]);
                double Len = Math.Sqrt(Math.Pow(Nx, 2) + Math.Pow(Ny, 2) + Math.Pow(Nz, 2));
                Nx /= Len; Ny /= Len; Nz /= Len;
            }
            double Lx = xLight - x; double Ly = yLight - y; double Lz = zLight - z;
            double Llength = Math.Sqrt(Math.Pow(Lx, 2) + Math.Pow(Ly, 2) + Math.Pow(Lz, 2));
            Lx /= Llength; Ly /= Llength; Lz /= Llength;
            double Rx = 2 * DotProduct(false, Nx, Ny, Nz, Lx, Ly, Lz) * Nx - Lx;
            double Ry = 2 * DotProduct(false, Nx, Ny, Nz, Lx, Ly, Lz) * Ny - Ly;
            double Rz = 2 * DotProduct(false, Nx, Ny, Nz, Lx, Ly, Lz) * Nz - Lz;
            double len = Math.Sqrt(Math.Pow(Rx, 2) + Math.Pow(Ry, 2) + Math.Pow(Rz, 2));
            Rx /= len; Ry /= len; Rz /= len;
            double Ir, Ig, Ib;
            if (drawingTexture)
            {
                Ir = Kd * (double)(Texture.GetPixel(x, y).R * colorOfLight.R) / Math.Pow(255, 2) * DotProduct(true, Nx, Ny, Nz, Lx, Ly, Lz) +
                     Ks * (double)(Texture.GetPixel(x, y).R * colorOfLight.R) / Math.Pow(255, 2) * Math.Pow(DotProduct(true, 0, 0, 1, Rx, Ry, Rz), m);

                Ig = Kd * (double)(Texture.GetPixel(x, y).G * colorOfLight.G) / Math.Pow(255, 2) * DotProduct(true, Nx, Ny, Nz, Lx, Ly, Lz) +
                   Ks * (double)(Texture.GetPixel(x, y).G * colorOfLight.G) / Math.Pow(255, 2) * Math.Pow(DotProduct(true, 0, 0, 1, Rx, Ry, Rz), m);

                Ib = Kd * (double)(Texture.GetPixel(x, y).B * colorOfLight.B) / Math.Pow(255, 2) * DotProduct(true, Nx, Ny, Nz, Lx, Ly, Lz) +
                   Ks * (double)(Texture.GetPixel(x, y).B * colorOfLight.B) / Math.Pow(255, 2) * Math.Pow(DotProduct(true, 0, 0, 1, Rx, Ry, Rz), m);
            }
            else
            {
                Ir = Kd * ((double)(colorOfObject.R * colorOfLight.R)) / Math.Pow(255, 2) * DotProduct(true, Nx, Ny, Nz, Lx, Ly, Lz) +
                   Ks * (double)(colorOfObject.R * colorOfLight.R) / Math.Pow(255, 2) * Math.Pow(DotProduct(true, 0, 0, 1, Rx, Ry, Rz), m);

                Ig = Kd * (double)(colorOfObject.G * colorOfLight.G) / Math.Pow(255, 2) * DotProduct(true, Nx, Ny, Nz, Lx, Ly, Lz) +
                   Ks * (double)(colorOfObject.G * colorOfLight.G) / Math.Pow(255, 2) * Math.Pow(DotProduct(true, 0, 0, 1, Rx, Ry, Rz), m);

                Ib = Kd * (double)(colorOfObject.B * colorOfLight.B) / Math.Pow(255, 2) * DotProduct(true, Nx, Ny, Nz, Lx, Ly, Lz) +
                   Ks * (double)(colorOfObject.B * colorOfLight.B) / Math.Pow(255, 2) * Math.Pow(DotProduct(true, 0, 0, 1, Rx, Ry, Rz), m);
            }
            return Color.FromArgb((int)(Ir > 1 ? 255 : Ir * 255), (int)(Ig > 1 ? 255 : Ig * 255), (int)(Ib > 1 ? 255 : Ib * 255));
        }

        private void CountNCircle()
        {
            for (int x = xCenter - Radius; x <= xCenter + Radius; x++)
                for (int y = yCenter - Radius; y <= yCenter + Radius; y++)
                {
                    double z = Math.Sqrt(Math.Pow(Radius, 2) - Math.Pow(x - xCenter, 2) - Math.Pow(y - yCenter, 2));
                    if (z > heightOfCut)
                    {
                        NxCircle[x, y] = 0; NyCircle[x, y] = 0; NzCircle[x, y] = 1;
                        if (x < xMinOfCut && y == yCenter)
                            xMinOfCut = x;
                    }
                    else
                    {
                        NxCircle[x, y] = (double)(x - xCenter) / Radius;
                        NyCircle[x, y] = (double)(y - yCenter) / Radius;
                        NzCircle[x, y] = (double)z / Radius;
                    }
                }
        }
        private void CountPit()
        {
            int cutRadius = xCenter - xMinOfCut;
            pitDistance = cutRadius / 2;
            for (int x = xCenter - cutRadius; x <= xCenter + cutRadius; x++)
                for (int y = yCenter - cutRadius; y <= yCenter + cutRadius; y++)
                {
                    //double z = Math.Sqrt(Math.Pow(pitRadius, 2) - Math.Pow(x - xPit, 2) - Math.Pow(y - yPit, 2));
                    //double distance = Math.Sqrt(Math.Pow(x - xPit, 2) + Math.Pow(y - yPit, 2)+Math.Pow(heightOfCut-z,2));
                    double distance = Math.Sqrt(Math.Pow(x - xPit, 2) + Math.Pow(y - yPit, 2));
                    if (distance < pitRadius)
                    {
                        double z = Math.Sqrt(Math.Pow(pitRadius, 2) - Math.Pow(x - xPit, 2) - Math.Pow(y - yPit, 2));
                        NxCircle[x, y] = (double)(xPit - x) / pitRadius;
                        NyCircle[x, y] = (double)(yPit - y) / pitRadius;
                        NzCircle[x, y] = z / pitRadius;
                    }
                }
        }

        private Color CountInterpolationColor(double Square, List<Vertice> vertices,
                                        Color[] colors, int x, int y)
        {
            Vertice vertP = new Vertice(x, y);
            int l;
            if (y == 410)
                l = 0;
            double a = SquareOfTriangle(vertices[1], vertP, vertices[2]) / Square;
            double temp = SquareOfTriangle(vertices[0], vertP, vertices[2]);
            double b = SquareOfTriangle(vertices[0], vertP, vertices[2]) / Square;
            double c = SquareOfTriangle(vertices[0], vertP, vertices[1]) / Square;
            return Color.FromArgb((int)(a * colors[0].R + b * colors[1].R + c * colors[2].R),
                               (int)(a * colors[0].G + b * colors[1].G + c * colors[2].G),
                               (int)(a * colors[0].B + b * colors[1].B + c * colors[2].B));

        }
        private double DotProduct(bool flag, double Vx, double Vy, double Vz, double Ux, double Uy, double Uz)
        {
            double product = Vx * Ux + Vy * Uy + Vz * Uz;
            if (flag)
            {
                if (product < 0)
                    return 0;
                else
                    return product;
            }
            else
            {
                return product;
            }
        }
        private (double, double, double) CrossProduct(double Vx, double Vy, double Vz, double Ux, double Uy, double Uz)
        {
            return (Vy * Uz - Uy * Vz, Vx * Uz - Ux * Vz, Vx * Uy - Ux * Vy);
        }
        private double SquareOfTriangle(Vertice vert1, Vertice vert2, Vertice vert3)
        {
            double edge1X = vert2.x - vert1.x;
            double edge1Y = vert2.y - vert1.y;
            double len1 = Math.Sqrt(Math.Pow(edge1X, 2) + Math.Pow(edge1Y, 2));
            edge1X /= len1; edge1Y /= len1;

            double edge2X = vert2.x - vert3.x;
            double edge2Y = vert2.y - vert3.y;
            double len2 = Math.Sqrt(Math.Pow(edge2X, 2) + Math.Pow(edge2Y, 2));
            edge2X /= len2; edge2Y /= len2;
            double cos = edge1X * edge2X + edge1Y * edge2Y;
            double sin = Math.Sqrt(1 - Math.Pow(cos, 2));
            return 0.5 * len1 * len2 * sin;
        }
        private void mainTimerEventProcessor(Object myObject,
                                            EventArgs myEventArgs)
        {
            if (centerToPeriphery)
            {
                double len = Math.Sqrt(Math.Pow(xLight - xCenter, 2) + Math.Pow(yLight - yCenter, 2));
                if (len <= Radius + 100)
                {
                    theta += dTheta;
                    xLight = xCenter + (int)(a * Math.Exp(b * theta) * Math.Cos(theta));
                    yLight = yCenter + (int)(a * Math.Exp(b * theta) * Math.Sin(theta));
                }
                else
                {
                    centerToPeriphery = false;
                }
            }
            else
            {
                double len = Math.Sqrt(Math.Pow(xLight - xCenter, 2) + Math.Pow(yLight - yCenter, 2));
                if (len >= 20)
                {
                    theta -= dTheta;
                    xLight = xCenter + (int)(a * Math.Exp(b * theta) * Math.Cos(theta));
                    yLight = yCenter + (int)(a * Math.Exp(b * theta) * Math.Sin(theta));
                }
                else
                    centerToPeriphery = true;
            }
            DrawScene();
        }

        private void pitTimerEventProcessor(object sender, EventArgs e)
        {
            sigma += dSigma;
            xPit = (int)Math.Round(xCenter + pitDistance * Math.Sin((double)(sigma) * Math.PI / 180));
            yPit = (int)Math.Round(yCenter + pitDistance * Math.Cos((double)(sigma) * Math.PI / 180));
        }

        private void NullifyLightsMovingButton_Click(object sender, EventArgs e)
        {
            theta = minTheta;
            xLight = xCenter;
            yLight = yCenter;
        }
        private void setStaticColorButton_Click(object sender, EventArgs e)
        {
            drawingTexture = false;
            //DrawScene();
        }
        private void setTextureButton_Click(object sender, EventArgs e)
        {
            mainTimer.Stop();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.JFIF;*.JPG;*.PNG)|*.JFIF;*.JPG;*.PNG";
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SetTexture(openFileDialog.FileName);
            }
            mainTimer.Start();
        }
        private void predefinedTexture1Button_Click(object sender, EventArgs e)
        {
            mainTimer.Stop();
            SetTexture(texture1);
            mainTimer.Start();
        }
        private void predefinedTexture2Button_Click(object sender, EventArgs e)
        {
            mainTimer.Stop();
            SetTexture(texture2);
            mainTimer.Start();
        }
        private void SetTexture(string fileName)
        {
            Image image = Image.FromFile(fileName);
            if (Texture != null)
                Texture.Dispose();
            Texture = new DirectBitmap(pictureBox.Width, pictureBox.Height);
            Graphics g = Graphics.FromImage(Texture.Bitmap);
            GraphicsUnit units = GraphicsUnit.Pixel;
            g.DrawImage(image,
                     new Rectangle(0, 0, Texture.Bitmap.Width, Texture.Bitmap.Height),
                     new Rectangle(0, 0, image.Width, image.Height),
                     units);
            g.Dispose();
            drawingTexture = true;
            //DrawScene();
        }
        private void setNormalMapButton_Click(object sender, EventArgs e)
        {
            mainTimer.Stop();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.JFIF;*.JPG;*.PNG)|*.JFIF;*.JPG;*.PNG";
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SetNormalMap(openFileDialog.FileName);
            }
            mainTimer.Start();
        }
        private void predefinedNormalMap1Button_Click(object sender, EventArgs e)
        {
            mainTimer.Stop();
            SetNormalMap(normalMap1);
            mainTimer.Start();
        }
        private void predefinedNormalMap2Button_Click(object sender, EventArgs e)
        {
            mainTimer.Stop();
            SetNormalMap(normalMap2);
            mainTimer.Start();
        }
        private void SetNormalMap(string fileName)
        {
            Image image = Image.FromFile(fileName);
            if (NormalMap != null)
                NormalMap.Dispose();
            NormalMap = new DirectBitmap(pictureBox.Width, pictureBox.Height);
            Graphics g = Graphics.FromImage(NormalMap.Bitmap);
            GraphicsUnit units = GraphicsUnit.Pixel;
            g.DrawImage(image,
                    new Rectangle(0, 0, NormalMap.Bitmap.Width, NormalMap.Bitmap.Height),
                    new Rectangle(0, 0, image.Width, image.Height),
                    units);
            g.Dispose();
            standardNormalMap = false;
            NxTexture = new double[pictureBox.Width, pictureBox.Height];
            NyTexture = new double[pictureBox.Width, pictureBox.Height];
            NzTexture = new double[pictureBox.Width, pictureBox.Height];

            Task[] tasks = new Task[pictureBox.Width * pictureBox.Height];
            int i;
            int k, l;
            for (int x = 0; x < pictureBox.Width; x++)
                for (int y = 0; y < pictureBox.Height; y++)
                {
                    i = x * y + y;
                    k = x;
                    l = y;
                    DecodeColorToNormal(k, l);
                }
            i = 0;
            //DrawScene();
        }
        private void DecodeColorToNormal(int x, int y)
        {
            NxTexture[x, y] = ((double)NormalMap.GetPixel(x, y).R - 127.5) / 127.5;
            NyTexture[x, y] = ((double)NormalMap.GetPixel(x, y).G - 127.5) / 127.5;
            NzTexture[x, y] = ((double)NormalMap.GetPixel(x, y).B - 127.5) / 127.5;
            if (NzTexture[x, y] < 0)
                NzTexture[x, y] = 0.0;
            double Length = Math.Sqrt(Math.Pow(NxTexture[x, y], 2)
                + Math.Pow(NyTexture[x, y], 2) + Math.Pow(NzTexture[x, y], 2));
            NxTexture[x, y] /= Length; NyTexture[x, y] /= Length; NzTexture[x, y] /= Length;
        }
        private void setStandardNormalMap_Click(object sender, EventArgs e)
        {
            standardNormalMap = true;
        }

        private void heightOfCutHScrollBar_ValueChanged(object sender, EventArgs e)
        {
            xMinOfCut = xCenter;
            heightOfCut = heightOfCutHScrollBar.Value;
            DrawScene();
        }
    }
    class Node
    {
        int ymax;
        public double x;
        double a; //1/m
        public Node(int yMax, double X, double A)
        {
            ymax = yMax;
            x = X;
            a = A;
        }
        public bool Compare(int yMax, double X, double A)
        {
            return ymax == yMax && Math.Round(x) == Math.Round(X) && a == A;
        }
        public void IncreaseX()
        {
            x += a;
        }
    }
}
