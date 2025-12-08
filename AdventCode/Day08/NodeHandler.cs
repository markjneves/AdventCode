using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode
{
    internal class NodeHandler
    {
        int loc_x, loc_y, loc_z;
        internal NodeHandler(int x, int y, int z)
        {
            loc_x = x;
            loc_y = y;
            loc_z = z;
        }
        internal int x
            { get { return loc_x; } }
        internal int y
            { get { return loc_y; } }
        internal int z
            { get { return loc_z; } }

        internal static double GetDistance(NodeHandler a, NodeHandler b)
        {
            return Math.Pow(b.x - a.x, 2) + Math.Pow(b.y - a.y, 2) + Math.Pow(b.z - a.z, 2);
        }
    }
}
