using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HackerRank.Prep3MonthsWk11;

namespace HackerRank
{
    internal class Prep3MonthsWk12
    {
        /*****Problem: Tree: Height of a Binary Tree*****/
        public static int height(TreeNode root)
        {
            if (root == null) return -1;

            return 1 + Math.Max(height(root.left), height(root.right));
        }

        /*****Problem: Binary Search Tree: Lowest Common Ancestor*****/
        public static TreeNode lca(TreeNode root, int v1, int v2)
        {
            if (root == null) return null;

            if (root.data < v1 && root.data < v2)
            {
                return lca(root.right, v1, v2);
            }

            if (root.data > v1 && root.data > v2)
            {
                return lca(root.left, v1, v2);
            }

            return root;
        }

        /*****Problem: Prim's (MST): Special Subtree*****/
        public static int prims(int n, List<List<int>> edges, int start)
        {
            edges = edges.OrderBy(e => e[2]).ToList();
            HashSet<int> visited = new HashSet<int>();
            visited.Add(start);            
            int minSum = 0;
            while (visited.Count < n) 
            {
                foreach(List<int> e in edges)
                {
                    if (visited.Contains(e[0]) && visited.Contains(e[1]))
                    {
                        continue;
                    }
                    else if (!visited.Contains(e[0]) && visited.Contains(e[1]))
                    {
                        visited.Add(e[0]);
                        minSum += e[2];
                        edges.Remove(e);
                        break;
                    }
                    else if(visited.Contains(e[0]) && !visited.Contains(e[1]))
                    {
                        visited.Add(e[1]);
                        minSum += e[2];
                        edges.Remove(e);
                        break;
                    }                    
                }
            }

            return minSum;
        }

        /*****Problem: Bead Ornaments*****/
        public static long MOD = 1000000007;
        public static int beadOrnaments(List<int> b)
        {
            long arrangements = 1;

            if (b.Count == 1)
            {
                arrangements = power(b[0], b[0] - 2);
            }
            else
            {
                int sum = 0;
                foreach(int v in b)
                {
                    arrangements = (arrangements * power(v, v - 1)) % MOD;
                    sum += v;
                }
                arrangements = (arrangements * power(sum, b.Count - 2)) % MOD;

            }
            return (int)(arrangements % MOD);
        }

        public static long power(long a, int pow)
        {
            if (pow == 0)
            {
                return 1;
            }

            long retVal = a % MOD;
            int cnt = 1;
            while(cnt < pow)
            {
                retVal = (retVal * a) % MOD ;
                cnt++;
            }            

            return retVal;
        }

        /*****Problem: Floyd: City of Blinding Lights*****/
        public static void shortestPath(int roadNodes, List<List<int>> graph, List<List<int>> queries)
        {
            int[,] matrix = new int[roadNodes + 1, roadNodes + 1];
            for (int i = 1; i < roadNodes + 1; i++)
            {
                for (int j = 1; j < roadNodes + 1; j++)
                {
                    if (i == j)
                    {
                        matrix[i, j] = 0;
                    }
                    else
                    {
                        matrix[i, j] = -1;
                    }
                }
            }

            foreach (List<int> p in graph)
            {
                int a = p[0];
                int b = p[1];
                int d = p[2];
                matrix[a, b] = d;
            }

            for (int k = 1; k < matrix.GetLength(0); k++)
            {
                for(int i = 1; i < matrix.GetLength(0); i++)
                {
                    for(int j = 1;  j < matrix.GetLength(0); j++)
                    {
                        if (i != j && matrix[i, k] != -1 && matrix[k,j] != -1 )
                        {
                            if (matrix[i,j] == -1 || matrix[i, j] > matrix[i, k] + matrix[k, j])
                            {
                                matrix[i, j] = matrix[i, k] + matrix[k, j];
                            }
                        }         
                    }
                }
            }

            foreach(List<int> q in queries)
            {
                Console.WriteLine(matrix[q[0], q[1]]);
            }
        }

        /*****Problem: No Prefix Set*****/             
        public static void noPrefix(List<string> words)
        {
            TrieNode root = new TrieNode();
            TrieNode curr = root;
            for (int i = 0; i < words.Count; i++)
            {
                curr = root;
                for(int c = 0; c < words[i].Length; c++)
                {
                    if (curr.Children.ContainsKey(words[i][c]))
                    {
                        if (curr.Children[words[i][c]].WordEnd || (c == words[i].Length-1))
                        {
                            Console.WriteLine("BAD SET");
                            Console.WriteLine(words[i]);
                            return;
                        }
                        else
                        {
                            curr = curr.Children[words[i][c]];
                        }
                    }
                    else
                    {
                        break;
                    }                    
                }
                Trie.AddWord(root, words[i]);                
            }
            //for (int i = 1; i < words.Count;i++)
            //{                
            //    for(int j = 0; j < i; j++)
            //    {
            //        int length = Math.Min(words[i].Length, words[j].Length);                    
            //        if (words[j].Substring(0, length) == words[i].Substring(0, length))
            //        {
            //            Console.WriteLine("BAD SET");
            //            Console.WriteLine(words[i]);
            //            return;
            //        }
                    
            //    }                
            //}
            Console.WriteLine("GOOD SET");
        }

        /*****Problem: Castle on the Grid*****/
        public static int minimumMoves(List<string> grid, int startX, int startY, int goalX, int goalY)
        {
            Queue<int[]> queue = new Queue<int[]>();
            bool[,] visited = new bool[grid.Count,grid.Count];
            //[x,y,moves]
            queue.Enqueue([startX, startY, 0]);
            visited[startX, startY] = true;

            int[][] directions = [ [ 1, 0 ], [ -1, 0 ], [0, 1 ], [ 0, -1 ] ];

            while(queue.Count > 0 ) 
            {
                int[] node = queue.Dequeue();
                int x = node[0];
                int y = node[1];
                int moves = node[2];

                if(x == goalX && y == goalY )
                {
                    return moves;
                }

                foreach (int[] dir in directions ) 
                {
                    int newX = x + dir[0];
                    int newY = y + dir[1];  

                    //Iterate by one step to end of row or column or til block(X)
                    while(newX >= 0 && newX < grid.Count 
                        && newY >= 0 && newY < grid.Count 
                        && grid[newX][newY] == '.') 
                    {
                        if (!visited[newX,newY]) 
                        {
                            visited[newX,newY] = true;
                            queue.Enqueue([newX, newY, moves+1]);
                        }

                        newX = newX + dir[0];
                        newY = newY + dir[1];
                    }
                }
            }

            return -1;
        }

        /*****Problem: Components in a graph*****/
        public static List<int> componentsInGraph(List<List<int>> gb)
        {
            UnionFind uf = new UnionFind(gb.Count * 2);
            foreach(List<int> e in gb)
            {
                uf.Union(e[0], e[1]);                
            }

            return new List<int> { uf.size.Where(c => c > 1).Min(), uf.size.Max() };
        }

        /*****Problem: Breadth First Search: Shortest Reach*****/
        public static List<int> bfs(int n, int m, List<List<int>> edges, int s)
        {
            List<int> dist = Enumerable.Repeat(-1, n).ToList();
            Queue<int> queue = new Queue<int>();
            dist[s-1] = 0;
            queue.Enqueue(s);
            List<List<int>> adj = new List<List<int>>(n);
            for (int i = 0; i < n; i++)
            {
                adj.Add(new List<int>());
            }
            foreach (List<int> e in edges)
            {
                int a = e[0];
                int b = e[1];
                adj[a-1].Add(b);
                adj[b-1].Add(a);
            }

            while (queue.Count > 0) 
            {
                int node = queue.Dequeue();
                foreach (int neighbor in adj[node-1])
                {
                    if (dist[neighbor-1] == -1)
                    {
                        // Mark the distance of the neighboring node as the distance of the current node + 1
                        dist[neighbor-1] = dist[node-1] + 6;
                        // Insert the neighboring node to the queue
                        queue.Enqueue(neighbor);
                    }
                }
            }
            dist.RemoveAt(s-1);
            return dist;
        }
    }
}
