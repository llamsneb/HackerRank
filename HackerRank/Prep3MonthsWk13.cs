using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HackerRank.Prep3MonthsWk11;

namespace HackerRank
{
    internal class Prep3MonthsWk13
    {
        /*****Problem: Find the Running Median*****/
        public static List<double> runningMedian(List<int> a)
        {
            PriorityQueue<int, int> lower = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b - a));
            PriorityQueue<int, int> upper = new PriorityQueue<int, int>();
            List<double> med = new List<double>();

            foreach(int val in a)
            {
                //Enqueue and Dequeue new val to get the max once multiple values are in heap
                lower.Enqueue(val, val);
                int temp = lower.Dequeue();
                upper.Enqueue(temp, temp);

                if(upper.Count > lower.Count)
                {
                    temp = upper.Dequeue();
                    lower.Enqueue(temp, temp);
                }

                if(upper.Count != lower.Count)
                {
                    med.Add(lower.Peek());
                }
                else
                {
                    med.Add((lower.Peek() + upper.Peek()) / 2.0);
                }
            }

            return med;
        }

        /*****Problem: Contacts*****/
        public static List<int> contacts(List<List<string>> queries)
        {
            List<int> words = new List<int>();
            TrieNode root = new TrieNode();
            TrieNode curr;
            
            foreach (List<string> q in queries)
            {
                if (q[0] == "add")
                {
                    Trie.AddWord(root, q[1]);
                }
                else if (q[0] == "find")
                {
                    curr = root;
                    bool isMatch = true;
                    foreach (char c in q[1])
                    {
                        if (!curr.Children.ContainsKey(c))
                        {
                            words.Add(0);
                            isMatch = false;
                            break;
                        }
                        else
                        {
                            curr = curr.Children[c];
                        }
                    }

                    if (isMatch)
                    {
                        words.Add(curr.Count);
                    }
                }
            }
            return words;
        }

        /*****Problem: Roads and Libraries*****/
        public static long roadsAndLibraries(int n, int c_lib, int c_road, List<List<int>> cities)
        {
            if(c_lib <= c_road)
            {
                return (long)n * c_lib;
            }

            long cost = 0;
            List<List<int>> adj = new List<List<int>>(n);
            for (int i = 0; i <= n; i++)
            {
                adj.Add(new List<int>());
            }
            foreach (List<int> e in cities)
            {
                int a = e[0];
                int b = e[1];
                adj[a].Add(b);
                adj[b].Add(a);
            }

            bool[] visited = new bool[adj.Count+1];
            
            // Loop through all vertices to handle disconnected graph
            for (int i = 1; i < adj.Count; i++)
            {
                if (!visited[i])
                {
                    int size = 0;
                    // If vertex i has not been visited, perform DFS from it
                    size = dfs(adj, visited, i, size);
                    cost += c_lib + (size - 1) * c_road; 
                }
            }

            return cost;
        }

        static int dfs(List<List<int>> adj, bool[] visited, int s, int size)
        {
            // Mark the current vertex as visited
            visited[s] = true;
            size++;
            // Recursively visit all adjacent vertices that are not visited yet
            foreach(int i in adj[s])
            {
                if (!visited[i])
                {
                    size = dfs(adj, visited, i, size); // Recursive call
                }
            }

            return size;
        }

        /*****Problem: Journey to the Moon*****/
        public static long journeyToMoon(int n, List<List<int>> astronaut)
        {
            List<List<int>> adj = new List<List<int>>(n);
            for (int i = 0; i < n; i++)
            {
                adj.Add(new List<int>());
            }
            foreach (List<int> e in astronaut)
            {
                int a = e[0];
                int b = e[1];
                adj[a].Add(b);
                adj[b].Add(a);
            }

            bool[] visited = new bool[adj.Count];
            List<int> countries = new List<int>();

            // Loop through all vertices to handle disconnected graph
            for (int i = 0; i < adj.Count; i++)
            {
                if (!visited[i])
                {
                    int size = 0;
                    // If vertex i has not been visited, perform DFS from it
                    countries.Add(dfs(adj, visited, i, size));
                }
            }

            long totalPairs = (long)n*(n-1)/2;
            long samePairs = 0;
            foreach(int c in countries)
            {
                samePairs += c * (c - 1) / 2;
            }

            return totalPairs - samePairs;
        }
    }
}
