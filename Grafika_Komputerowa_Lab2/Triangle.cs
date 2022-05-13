using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_Komputerowa_Lab2
{
    class Triangle: Polygon
    {
        public Triangle(Vertice vert1, Vertice vert2, Vertice vert3)
        {
            vertices = new List<Vertice>();
            vertices.Add(vert1);
            vertices.Add(vert2);
            vertices.Add(vert3);
        }
        public Vertice FindVertice(int x, int y)
        {
            foreach (Vertice vert in vertices)
                if (vert.ContainPixel(x, y))
                    return vert;
            return null;
        }
        public void Draw(Bitmap DrawArea)
        {
            Graphics g = Graphics.FromImage(DrawArea);
            Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 2);
            g.DrawLine(blackPen, vertices[0].x, vertices[0].y, vertices[1].x, vertices[1].y);
            g.DrawLine(blackPen, vertices[0].x, vertices[0].y, vertices[2].x, vertices[2].y);
            g.DrawLine(blackPen, vertices[1].x, vertices[1].y, vertices[2].x, vertices[2].y);
            foreach (var vert in vertices)
                vert.Draw(DrawArea);
            blackPen.Dispose();
            g.Dispose();
        }

        public override double Square()
        {
            double edge1X = vertices[1].x - vertices[0].x;
            double edge1Y = vertices[1].y - vertices[0].y;
            double len1 = Math.Sqrt(Math.Pow(edge1X, 2) + Math.Pow(edge1Y, 2));
            edge1X /= len1; edge1Y /= len1;

            double edge2X = vertices[1].x - vertices[2].x;
            double edge2Y = vertices[1].y - vertices[2].y;
            double len2 = Math.Sqrt(Math.Pow(edge2X, 2) + Math.Pow(edge2Y, 2));
            edge2X /= len2; edge2Y /= len2;
            double cos = edge1X * edge2X + edge1Y * edge2Y;
            double sin = Math.Sqrt(1 - Math.Pow(cos, 2));
            return 0.5*len1*len2*sin;
        }
    }
}