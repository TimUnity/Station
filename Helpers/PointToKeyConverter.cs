using Consola;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola.Helpers
{
    public class PointToKeyConverter
    {
        public static int PointToKey(Point point) 
        {
            int x = Math.Abs(point.X);
            int y = Math.Abs(point.Y);

            return x * 1000 + y;
        }

        public static Point KeyToPoint(int key) 
        {
            int x = key / 1000;
            int y = key % 1000;

            return new Point(x, y);
        }
    }
}
