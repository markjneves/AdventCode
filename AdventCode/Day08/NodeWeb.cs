using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode
{
    internal class NodeWeb : IComparable<NodeWeb>
    {
        List<NodeConnection> connections;
        List<NodeHandler> nodes;

        internal NodeWeb(NodeConnection connection)
        {
            connections = new List<NodeConnection>();
            connections.Add(connection);
            nodes = new List<NodeHandler>();
            nodes.Add(connection.A);
            nodes.Add(connection.B);
        }

        internal List<NodeConnection> Connections
            { get { return connections; } }
        internal List<NodeHandler> Nodes
            { get { return nodes; } }
        internal bool IsConnected(NodeHandler a)
        {
            foreach (NodeHandler n in nodes)
            {
                if(n == a)
                    return true;
            }
            return false;
        }
        internal void AddNode(NodeHandler a)
        {
            nodes.Add(a);
        }
        internal void AddConnection(NodeConnection a)
        {
            connections.Add(a);
        }

        internal void Merge(NodeWeb input)
        {
            connections.AddRange(input.Connections);
            nodes.AddRange(input.Nodes);
        }
        public int CompareTo(NodeWeb? other)
        {
            if (other == null)
                return -1;
            return nodes.Count.CompareTo(other.Nodes.Count);
        }
    }
}
