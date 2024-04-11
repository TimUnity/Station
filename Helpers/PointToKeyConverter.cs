using Consola;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola.Helpers
{
    internal class PointToKeyConverter
    {
        public static int PointToKey(Point point) 
        {
            return point.X * 1000 + point.Y;
        }

        public static Point KeyToPoint(int key) 
        {
            int x = key / 1000;
            int y = key % 1000;
            return new Point(x, y);
        }
    }
}
