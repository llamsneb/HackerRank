using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
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

        /*****Problem: Cube Summation*****/   
        //Fenwick/Binary Indexed Tree
        public static void updateBIT(int n, int x, int y , int z, long val, long[,,] BITree)
        {
            // Traverse all ancestors and add 'val'  
            while (x <= n)
            {
                int yi = y;
                while(yi <= n)
                {
                    int zi = z;
                    while (zi <= n)
                    {
                        // Add 'val' to current node of BIT Tree  
                        BITree[x,yi,zi] += val;
                        // Update index to that of parent in update View
                        zi += zi & (-zi);
                    }
                    // Update index to that of parent in update View
                    yi += yi & (-yi);
                }
                // Update index to that of parent in update View  
                x += x & (-x);
            }
        }

        public static long getSum(int x, int y, int z, long[,,] BITree)
        {
            long sum = 0; // Initialize result              

            // Traverse ancestors of BITree[index]
            while (x > 0)
            {
                int yi = y;
                while (yi > 0)
                {
                    int zi = z;
                    while(zi > 0)
                    {
                        // Add current element of BITree to sum  
                        sum += BITree[x,yi,zi];
                        // Move index to parent node in getSum View  
                        zi -= zi & (-zi);
                    }
                    // Move index to parent node in getSum View  
                    yi -= yi & (-yi);
                }
                // Move index to parent node in getSum View  
                x -= x & (-x);
            }
            return sum;
        }

        public static List<long> cubeSum(int n, List<string> operations)
        {
            long[,,] cube = new long[n+1,n+1,n+1];
            long[,,] BITree = new long[n + 1, n + 1, n + 1];
            List<long> results = new List<long>();

            foreach(string op in operations)
            {
                string[] opList = op.Split();
                if (opList[0] == "UPDATE")
                {
                    int xi = Convert.ToInt32(opList[1]);
                    int yi = Convert.ToInt32(opList[2]);
                    int zi = Convert.ToInt32(opList[3]);
                    int val = Convert.ToInt32(opList[4]);
                    
                    updateBIT(n, xi, yi, zi, val - cube[xi, yi, zi], BITree);
                    cube[xi, yi, zi] = val;
                }
                else if(opList[0] == "QUERY")
                {
                    int x1 = Convert.ToInt32(opList[1]);
                    int y1 = Convert.ToInt32(opList[2]);
                    int z1 = Convert.ToInt32(opList[3]);
                    int x2 = Convert.ToInt32(opList[4]);
                    int y2 = Convert.ToInt32(opList[5]);
                    int z2 = Convert.ToInt32(opList[6]);                    

                    long num = getSum(x2, y2, z2, BITree) -
                            (getSum(x1-1, y2, z2, BITree) + getSum(x2, y1 - 1, z2, BITree) + getSum(x2, y2, z1-1, BITree)) +
                            (getSum(x1-1, y1-1, z2, BITree) + getSum(x1 - 1, y2, z1-1, BITree) + getSum(x2, y1 - 1, z1-1, BITree)) -
                            getSum(x1-1, y1-1, z1-1, BITree);

                    results.Add(num);
                }
            }

            return results;
        }

        /*****Problem: Jack goes to Rapture*****/        
        public static void getCost(int gNodes, List<int> gFrom, List<int> gTo, List<int> gWeight)
        {
            // Print your answer within the function and return nothing
            List<Tuple<int, int>>[] adj = new List<Tuple<int, int>>[gNodes+1];
            for (int i = 1; i <= gNodes; i++)
            {
                adj[i] = new List<Tuple<int, int>>();
            }

            for(int i = 0; i < gFrom.Count; i++)
            {
                int f = gFrom[i];
                int t = gTo[i];
                int w = gWeight[i];
                adj[f].Add(new Tuple<int, int>(w,t));
                adj[t].Add(new Tuple<int, int>(w,f));
            }

            PriorityQueue<Tuple<int, int>, Tuple<int, int>> pq = new PriorityQueue<Tuple<int, int>, Tuple<int, int>>();
            // Create a vector for distances and initialize all distances as infinite (INF)
            int[] dist = new int[gNodes+1];
            for (int i = 1; i <= gNodes; i++)
            {
                dist[i] = int.MaxValue;
            }
            // Insert source itself in the priority queue and initialize its distance as 0.
            Tuple<int, int> src = new Tuple<int, int>(0, gFrom[0]);
            pq.Enqueue(src,src);
            dist[gFrom[0]] = 0;

            while (pq.Count > 0)
            {
                // The first vertex in tuple is the minimum distance vertex,
                // extract it from the sorted set.
                // vertex label is stored in the second element of the tuple.
                // (it has to be done this way to keep the vertices sorted by distance,
                // where distance must be the first item in the tuple)
                Tuple<int, int> current = pq.Dequeue();
                int u = current.Item2;
                int currCost = current.Item1;

                if (currCost > dist[u]) continue;
                // 'i' is used to get all adjacent vertices of a vertex
                foreach (var i in adj[u])
                {
                    // Get vertex label and weight of the current adjacent vertex of u.
                    int v = i.Item2;
                    int cost = Math.Max(0, i.Item1-currCost);

                    // If there is a shorter path to v through u.
                    if (dist[v] > dist[u] + cost)
                    {
                        Tuple<int, int> vert = new Tuple<int, int>(dist[u] + cost, v);
                        // Updating distance of v
                        pq.Enqueue(vert, vert);
                        dist[v] = dist[u] + cost;
                    }
                }
            }

            if (dist[gNodes] == int.MaxValue)
            {
                Console.WriteLine("NO PATH EXISTS");
            }
            else
            {
                Console.WriteLine(dist[gNodes]);
            }
        }

        /*****Problem: Minimum Loss 1*****/
        public static int minimumLoss(List<long> price)
        {
            long min = long.MaxValue;
            Dictionary<long, int> dic = new Dictionary<long, int>();
            for(int i = 0; i < price.Count; i++)
            {
                dic.Add(price[i], i);
            }

            price = price.OrderByDescending(p => p).ToList();

            for (int i = 0; i < price.Count - 1; i++)
            {
                // If index is lower then get difference in price.
                if (dic[price[i]] < dic[price[i + 1]]) { 
                    long diff = price[i]-price[i + 1];
                    min = Math.Min(diff, min);
                }
            }

            return (int)min;
        }

        /*****Problem: Short Palindrome*****/
        public static int shortPalindrome(string s)
        {
            int mod = 1000000007;
            int[] freq = new int[26];
            int[,] pairFreq = new int[26,26];
            int[] tripletFreq = new int[26];

            int palinCnt = 0;

            foreach(char c in s)
            {
                int charIdx = c - 'a';
                palinCnt = (palinCnt + tripletFreq[charIdx]) % mod;

                for(int i = 0; i < 26; i++)
                {
                    tripletFreq[i] = (tripletFreq[i] + pairFreq[i, charIdx]) % mod;
                }

                for(int i = 0; i < 26; i++)
                {
                    pairFreq[i, charIdx] = (pairFreq[i, charIdx] + freq[i]) % mod;
                }

                freq[charIdx]++;
            }

            return palinCnt;
        }

        /*****Problem: Cut the Tree*****/
        /*Approach: 
         * 1. Calcualte sum of values at each vertex 
         * 2. Find minimum absolute value of sum at root - 2*sum at every vertex. 
         * This works because when you cut an edge, the sum at root reduces by that edge vertex's sum value 
         * and this also becomes the first tree. 
         * The cut vertex sum becomes the value of the second tree. 
         * The answer is the minimum absolute diff of these.
         * */
        public static int cutTheTree(List<int> data, List<List<int>> edges)
        {
            int[] subTree = new int[data.Count+1];

            List<List<int>> adj = new List<List<int>>(data.Count + 1);
            for(int i = 0; i < data.Count+1; i++)
            {
                adj.Add(new List<int>());
            }
            foreach(List<int> e in edges)
            {
                int u = e[0];
                int v = e[1];
                adj[u].Add(v);
                adj[v].Add(u);
            }

            dfsCutTree(adj, data, subTree , -1, 1);

            int minDiff = int.MaxValue;
            for (int i = 1; i < subTree.Length; i++)
            {
                minDiff = Math.Min(minDiff, Math.Abs(subTree[1] - subTree[i]*2));
            }

            return minDiff;            
        }

        public static void dfsCutTree(List<List<int>> adj, List<int> data, int[] subTree, int parent, int idx)
        {
            int sum = data[idx-1];

            foreach (int i in adj[idx])
            {
                if(i != parent)
                {
                    dfsCutTree(adj, data, subTree, idx, i);
                    sum += subTree[i];
                }
            }
            subTree[idx] = sum;
        }               
    }
}
