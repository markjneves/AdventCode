using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode
{
    public static class Day08
    {
        public static void Run()
        {
            Logger.SetFile("C:\\Users\\Mark\\source\\repos\\AdventCode\\AdventCode\\Day08\\output.txt");
            //Logger.WriteLevel = LogLevel.Info;
            //Logger.ConsoleLevel = LogLevel.Info;
            string input = File.ReadAllText("C:\\Users\\Mark\\source\\repos\\AdventCode\\AdventCode\\Day08\\input.txt").Trim();
            string[] arry_input = input.Split("\n");
            List<NodeHandler> nodes = new List<NodeHandler>();
            foreach (string line in arry_input)
            {
                string[] locs = line.Split(",");
                int x = int.Parse(locs[0]);
                int y = int.Parse(locs[1]);
                int z = int.Parse(locs[2]);
                nodes.Add(new NodeHandler(x, y, z));
            }
            List<NodeConnection> connections;
            List<NodeWeb> webs;
            /*connections = GetConnections(nodes, 1000);
            webs = new List<NodeWeb>();
            foreach (NodeConnection conn in connections)
            {
                NodeWeb? a_web = null;
                NodeWeb? b_web = null;
                foreach (NodeWeb web in webs)
                {
                    if (web.IsConnected(conn.A))
                        a_web = web;
                    if (web.IsConnected(conn.B))
                        b_web = web;
                }
                if (a_web != b_web && a_web != null && b_web != null)
                {
                    a_web.Merge(b_web);
                    webs.Remove(b_web);
                }
                else if (a_web == b_web && a_web != null && b_web != null)
                {
                    a_web.AddConnection(conn);
                }
                else if (a_web != null)
                {
                    a_web.AddConnection(conn);
                    a_web.AddNode(conn.B);
                }
                else if (b_web != null)
                {
                    b_web.AddConnection(conn);
                    b_web.AddNode(conn.A);
                }
                else
                {
                    webs.Add(new NodeWeb(conn));
                }
            }
            long total = 1;
            webs.Sort();
            webs.Reverse();
            foreach (NodeWeb web in webs)
            {
                Logger.Log(web.Nodes.Count.ToString(), LogLevel.Trace);
            }
            for (int i = 0; i < webs.Count && i < 3; i++)
            {
                total *= webs[i].Nodes.Count;
            }
            Logger.Log($"Part 1 Total: {total.ToString()}", LogLevel.Info);*/
            connections = GetConnections(nodes, 10000);
            webs = new List<NodeWeb>();
            int i = 0;
            do
            {
                NodeWeb? a_web = null;
                NodeWeb? b_web = null;
                foreach (NodeWeb web in webs)
                {
                    if (web.IsConnected(connections[i].A))
                        a_web = web;
                    if (web.IsConnected(connections[i].B))
                        b_web = web;
                }
                if (a_web != b_web && a_web != null && b_web != null)
                {
                    a_web.Merge(b_web);
                    webs.Remove(b_web);
                }
                else if (a_web == b_web && a_web != null && b_web != null)
                {
                    a_web.AddConnection(connections[i]);
                }
                else if (a_web != null)
                {
                    a_web.AddConnection(connections[i]);
                    a_web.AddNode(connections[i].B);
                }
                else if (b_web != null)
                {
                    b_web.AddConnection(connections[i]);
                    b_web.AddNode(connections[i].A);
                }
                else
                {
                    webs.Add(new NodeWeb(connections[i]));
                }
                i++;
            } while (webs[0].Nodes.Count < nodes.Count && i < connections.Count);

            Logger.Log($"Last connection # {i-1} with x: {connections[i - 1].A.x} - {connections[i - 1].B.x}", LogLevel.Info);
            Logger.Log($"Part 2 Total: {(Convert.ToUInt64(connections[i-1].A.x) * Convert.ToUInt64(connections[i-1].B.x)).ToString()}", LogLevel.Info);


        }
        private static List<NodeConnection> GetConnections(List<NodeHandler> nodes, int max)
        {
            LinkedList<NodeConnection> connections = new LinkedList<NodeConnection>();
            for (int i = 0; i < nodes.Count - 1; i++)
            {
                Logger.Log($"Connecting node {i}", LogLevel.Trace);
                for (int j = i+1; j < nodes.Count; j++)
                {
                    NodeConnection test = new NodeConnection(nodes[i], nodes[j]);
                    bool inserted = false;
                    if(connections.Count == 0)
                    {
                        inserted = true;
                        connections.AddFirst(test);
                        continue;
                    }
                    LinkedListNode<NodeConnection>? current = connections.First;
                    while (current != null)
                    {
                        if (test.Distance < current.Value.Distance)
                        {
                            connections.AddBefore(current, test);
                            inserted = true;
                            break;
                        }
                        current = current.Next;
                        
                    }
                    if (!inserted)
                        connections.AddLast(test);

                    if (connections.Count > max)
                        connections.RemoveLast();
                }
            }
            return connections.ToList();
        }
    }
}
