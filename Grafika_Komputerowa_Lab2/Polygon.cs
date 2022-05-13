using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafika_Komputerowa_Lab2
{
    public abstract class Polygon
    {
        public List<Vertice> vertices;
        public abstract double Square();
    }
}
