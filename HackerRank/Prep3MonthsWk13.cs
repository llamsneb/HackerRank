using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HackerRank.Prep3MonthsWk11;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            foreach (int val in a)
            {
                //Enqueue and Dequeue new val to get the max once multiple values are in heap
                lower.Enqueue(val, val);
                int temp = lower.Dequeue();
                upper.Enqueue(temp, temp);

                if (upper.Count > lower.Count)
                {
                    temp = upper.Dequeue();
                    lower.Enqueue(temp, temp);
                }

                if (upper.Count != lower.Count)
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
            if (c_lib <= c_road)
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

            bool[] visited = new bool[adj.Count + 1];

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
            foreach (int i in adj[s])
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

            long totalPairs = (long)n * (n - 1) / 2;
            long samePairs = 0;
            foreach (int c in countries)
            {
                samePairs += c * (c - 1) / 2;
            }

            return totalPairs - samePairs;
        }

        /*****Problem: Gena Playing Hanoi*****/
        /*Imagine a rod is a binary number, each disc on the rod is a bit. So the discs are 1, 2, 4, 8, 16, 32 ... 2 ** (n - 1). 
        The smaller disc is 1, the biggest disc is 2 ** (n - 1).

        What is the largest total number on a rod? It is 1 + 2 + 4 + 8 + ... + 2 ** (n - 1), which equals to 2 ** n - 1. 
        Imagine the four rods is a four bits base = 2 ** n number, and the value of the number will be 
        rod[0] * (base ** 3) + rod[1] * (base ** 2) + rod[2] * base + rod[3].

        With imaginations above, we are able to represent the whole game state using a single number! 
        The winning number is (2 ** n - 1) * (base ** 3) which equals to (base - 1) * (base ** 3).

        Given a state number representing the game state, we are able to figure out the four numbers on the four rods, they are 
        [(state // base ** 3) % base, (state // base ** 2) % base, (state // base) % base, state % base].

        Given a number on a rod, we are able to figure out the number for the top disc: math.inf if n == 0 else n ^ (n & (n - 1)). 
        If number is 0, there is no disc, we set the top disc number to infinity. Else the top disc number is n ^ (n & (n - 1)). 
        Because in binary operations, n & (n - 1) changes the last 1 in n to 0.

        Given top discs on four rods, we will know all the possible ways to move discs. 
        Because we can only move a top disc to a rod with a larger top disc. 
        Use the BFS algorithm to move until we encounter the wining state number.
        */
        public static int hanoi(List<int> posts)
        {
            int numOfRods = 4;
            int n = posts.Count;
            long baseNum = (long)Math.Pow(2, n);
            int INF = (int)Math.Pow(2, n);
            int[] rods = [0, 0, 0, 0];
            for (int i = 0; i < n; i++)
            { // asign discs to rods                
                rods[posts[i] - 1] += (int)Math.Pow(2, i); ; // assign 1, 2, 4, 8, 16 ... etc to discs
            }
            long startState = 0;
            for (int i = 0; i < numOfRods; i++)
            {
                startState += rods[i] * (long)Math.Pow(baseNum, numOfRods - i - 1);
            }
            //long startState = rods[0] * (long)Math.Pow(baseNum, 3) + rods[1] * (long)Math.Pow(baseNum, 2) + rods[2] * baseNum + rods[3];
            long goalState = (baseNum - 1) * (long)Math.Pow(baseNum, numOfRods - 1);
            HashSet<long> visited = new HashSet<long>();
            List<long> current = [startState];
            long newState;
            int moves = 0;
            int[] curRods = new int[numOfRods];
            int[] topDiscs = new int[numOfRods];
            List<long> next = new List<long>();
            while (current.Count > 0)
            {
                next.Clear();
                foreach (long state in current)
                {
                    if (state == goalState)
                    {
                        return moves;
                    }

                    if (visited.Contains(state))
                    {
                        continue;
                    }
                    visited.Add(state);

                    //fromStateToRods
                    for (int i = 0; i < numOfRods; i++)
                    {
                        curRods[i] = (int)((state / Math.Pow(baseNum, numOfRods - i - 1)) % baseNum);
                    }

                    //findTopDisks
                    for (int i = 0; i < numOfRods; i++)
                    {
                        if (curRods[i] == 0)
                        {
                            topDiscs[i] = INF;
                        }
                        else
                        {
                            topDiscs[i] = curRods[i] ^ (curRods[i] & (curRods[i] - 1));
                        }
                    }

                    //Get all the states that could occur for the next move.
                    for (int i = 0; i < numOfRods; i++)
                    {
                        for (int j = i + 1; j < numOfRods; j++)
                        {
                            newState = 0;
                            if(topDiscs[i] == INF && topDiscs[j] == INF)
                            {
                                continue;
                            }
                            else if (topDiscs[i] < topDiscs[j])
                            {
                                newState = state - topDiscs[i] * (long)Math.Pow(baseNum, numOfRods - i - 1) + topDiscs[i] * (long)Math.Pow(baseNum, numOfRods - j - 1);
                            }
                            else if (topDiscs[i] > topDiscs[j])
                            {
                                newState = state + topDiscs[j] * (long)Math.Pow(baseNum, numOfRods - i - 1) - topDiscs[j] * (long)Math.Pow(baseNum, numOfRods - j - 1);
                            }

                            if (!visited.Contains(newState))
                            {
                                next.Add(newState);
                            }
                        }
                    }
                }                

                current = next.ToList();
                moves += 1;
            }
            return moves;
        }

            
    }
}
