using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_Komputerowa_Lab2
{
    public class Vertice
    {
        public int x;
        public int y;
        public Color color;
        public Vertice(int X, int Y)
        {
            x = X;
            y = Y;
            color = Color.Red;
        }

        public bool ContainPixel(int X, int Y)
        {
            if (x - 2 <= X & X <= x + 2 & y - 2 <= Y & y + 2 >= Y)
                return true;
            return false;
        }

        public void Draw(Bitmap DrawArea)
        {
            Graphics g = Graphics.FromImage(DrawArea);
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(color);
            g.FillRectangle(myBrush, x - 2, y - 2, 5, 5);
            myBrush.Dispose();
            g.Dispose();
            return;
        }
    }
}
