using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions.Medium.SkynetRevolution
{
    // the class used to keep (where i'm coming from) and (how much until here)
    public class PathNode
    {
        public int From;
        public int Current;
        public int Distance;

        public PathNode(int current, int from = -1, int distance = 0)
        {
            Current = current;
            From = from;
            Distance = distance;
        }
    }

    public class Solution
    {
        // the logic is to find the shortest path to each of the gates
        // and cut the shortest from these
        public static PathNode Custom_BFS(bool[,] G, int start, int[] gates)
        {
            var N = G.GetLength(0);
            var discovered = new bool[N];
            var q = new Queue<PathNode>();
            var pathsToGates = new List<PathNode>();

            discovered[start] = true;
            q.Enqueue(new PathNode(start));

            while(q.Count != 0)
            {
                var v = q.Dequeue();
                if (gates.Contains(v.Current))
                    pathsToGates.Add(v);

                // visit neigh
                for(var i = 0; i < N; i++)
                {
                    if (G[v.Current, i] == false 
                        || v.Current == i 
                        || discovered[i] == true) continue;

                    discovered[i] = true;
                    q.Enqueue(new PathNode(i, v.Current, v.Distance + 1));
                }
            }

            pathsToGates.Sort((x, y) => x.Distance.CompareTo(y.Distance));
            return pathsToGates.FirstOrDefault();
        }

        public static void Main(string[] args)
        {
            string[] inputs;
            inputs = Console.ReadLine().Split(' ');
            int N = int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
            var G = new bool[N, N];
            int L = int.Parse(inputs[1]); // the number of links
            int E = int.Parse(inputs[2]); // the number of exit gateways

            // read nodes
            for (int i = 0; i < L; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int N1 = int.Parse(inputs[0]); // N1 and N2 defines a link between these nodes
                int N2 = int.Parse(inputs[1]);
                G[N1, N2] = G[N2, N1] = true;
            }

            // read gateway nodes
            var gatewayNodes = new int[E];
            for (int i = 0; i < E; i++)
            {
                int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
                gatewayNodes[i] = EI;
            }

            // game loop
            while (true)
            {
                int SI = int.Parse(Console.ReadLine()); // The index of the node on which the Skynet agent is positioned this turn
                var cut = Custom_BFS(G, SI, gatewayNodes);
                G[cut.From, cut.Current] = G[cut.Current, cut.From] = false;

                if (cut == null) return;

                Console.WriteLine($"{cut.From} {cut.Current}");
            }
        }
    }
}
