using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode
{
    internal class NodeConnection
    {
        NodeHandler a, b;
        double distance;
        internal NodeConnection(NodeHandler a, NodeHandler b)
        {
            this.a = a;
            this.b = b;
            this.distance = NodeHandler.GetDistance(a,b);
        }
        internal NodeHandler A
            { get { return a; } }
        internal NodeHandler B 
            { get { return b; } }
        internal double Distance
        { get { return this.distance; } }
        internal bool IsConnected(NodeHandler input)
        {
            return input == this.a || input == this.b;
        }
    }
}
