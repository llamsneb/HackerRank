using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.ComponentModel;

namespace HackerRank
{
    internal class Prep3MonthsWk11
    {
        /*****Problem: Queries with Fixed Length*****/
        public static List<int> solve(List<int> arr, List<int> queries)
        {                       
            List<int> minArr = new List<int>();
            int subMax = 0;
            //PriorityQueue<int, int> maxQueue = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b - a));
            //PriorityQueue<int, int> minQueue = new PriorityQueue<int, int>();
            foreach (int q in queries)
            {
                int min = -1;
                //minQueue.Clear();
                //List<int> maxArr = new List<int>();              
                for (int i = 0; i <= arr.Count-q; i++)
                {
                    //maxQueue.Clear();
                    
                    
                    subMax = arr.Skip(i).Take(q).Max();
                    //subMax = arr.GetRange(i, q).Max();                    
                    //for (int j = i; j < q + i; j++)
                    //{

                    //    //maxQueue.Enqueue(arr[j],arr[j]);
                    //    //subMax = arr[j] > subMax ? arr[j] : subMax;
                    //}
                    //subMax = maxQueue.Dequeue();
                    //minQueue.Enqueue(subMax,subMax);
                    //min = Math.Min(subMax, min);
                    min = min == -1 || subMax < min ? subMax : min;
                    //maxArr.Add(subMax);
                }
                //List<int> maxArr = new List<int>();
                //foreach (List<int> s in subs)
                //{
                //    maxArr.Add(s.Max());
                //}
                //minArr.Add(minQueue.Dequeue());
                minArr.Add(min);
            }            
            
            return minArr;
        }

        public static List<int> solve2(List<int> arr, List<int> queries)
        {
            List<int> minArr = new List<int>();
            foreach (int q in queries)
            {
                // Get max for first q window
                int max = arr.GetRange(0, q).Max();
                int min = max;
                for (int i = q; i < arr.Count; i++)
                {
                    // Compare to max from prev window.
                    // Windows overlap each other.
                    // If new element is not greater, and max is not equal to first element in prev window,
                    // then get max for new window and compare.
                    if (arr[i] > max)
                    {
                        max = arr[i];
                    }
                    else if (arr[i - q] == max)
                    {
                        max = arr.GetRange(i - q + 1, q).Max();
                    }

                    min = Math.Min(min, max);
                }
                minArr.Add(min);
            }
            return minArr;
        }

        public static List<int> solve3(List<int> arr, List<int> queries)
        {
            List<int> minArr = new List<int>();            
            
            foreach(int q in queries)
            {
                int min = int.MaxValue;
                List<int> window = new List<int>();
                //Process first q (or first window) elements of array
                for (int i = 0; i < q; i++)
                {
                    // Get max for first q window.
                    // For every element, the previous smaller
                    // elements are useless so remove them from window
                    while (window.Count != 0 && arr[i] >= arr[window.Last()]) 
                    {
                        window.RemoveAt(window.Count-1);
                    }
                    window.Add(i);
                }

                // Process rest of the elements,
                // i.e., from arr[q] to arr[n-1]
                for (int i = q; i <= arr.Count; i++)
                {
                    // The element at the front of the window is
                    // the largest element of previous window
                    min = Math.Min(min, arr[window[0]]);

                    // Remove the elements which are out of this window
                    while (window.Count != 0 && window[0] <= i-q)
                    {
                        window.RemoveAt(0);
                    }

                    if (i < arr.Count)
                    {
                        // Remove all elements smaller than the currently
                        // being added element (remove useless elements)
                        while (window.Count != 0 && arr[i] >= arr[window.Last()])
                        {
                            window.RemoveAt(window.Count - 1);
                        }

                        window.Add(i);
                    }
                }

                minArr.Add(min);
            }            

            return minArr;
        }

        //TLE
        public static List<int> solve4(List<int> arr, List<int> queries)
        {
            List<int> minArr = new List<int>();
            foreach (int q in queries)
            {
                // Get max for first q window
                int subMax = arr.GetRange(0, q).Max();
                int min = subMax;
                for (int i = q; i < arr.Count; i++)
                {
                    subMax = arr.GetRange(i - q+1, q).Max();
                    min = Math.Min(min, subMax);
                }
                minArr.Add(min);
            }

            return minArr;
        }

        /*****Problem: Common Child*****/
        public static int commonChild(string s1, string s2)
        {
            int n = s1.Length;
            int m = s2.Length; 
            int[,] lcs = new int[n+1,m+1];            

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    if (s1[i] == s2[j])
                    {
                        lcs[i + 1,j + 1] = lcs[i, j] + 1;
                    }
                    else
                    {
                        lcs[i + 1, j + 1] = Math.Max(lcs[i, j + 1], lcs[i + 1, j]);
                    }
                }
            }
            return lcs[n, m]; ;
        }

        /*****Problem: Array Manipulation*****/

        public static long arrayManipulation(int n, List<List<int>> queries)
        {
            long[] pfArr = new long[n + 1];
            foreach (List<int> q in queries)
            {
                int a = q[0];
                int b = q[1];
                int k = q[2];
                pfArr[a-1] += k;
                pfArr[b] -= k;
            }

            long max = 0;
            long sum = 0;
            foreach(long pf in pfArr)
            {
                sum += pf;
                max = Math.Max(max, sum);
            }

            return max;

            //TLE below
            //List<long> retVal = new List<long>(new long[n]);
            //for (int i = 0; i < queries.Count; i++)
            //{
            //    for(int j = queries[i][0]-1; j <= queries[i][1]-1; j++)
            //    {
            //        retVal[j] += queries[i][2];
            //    }
            //}
            //return retVal.Max();
        }

        /*****Problem: Highest Value Palindrome*****/

        public static string highestValuePalindrome(string s, int n, int k)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(s);
            // Get indexes of different chars in left and right side of string
            List<int> idxList = new List<int>();
            for(int i = 0; i < n / 2; i++)
            {              
                if (sb[i] != sb[n-1-i])
                {
                    idxList.Add(i);
                }
            }

            if (idxList.Count > k)
            {
                return "-1";
            }

            // Change chars to 9 for extra k changes over idxList count
            for (int i = 0; i < n/2 && k >= 2 && k > idxList.Count; i++)
            {                
                if (sb[i] != '9')
                {
                    sb[i] = '9';
                    k--;
                }

                if (sb[n - 1 - i] != '9')
                {
                    sb[n - 1 - i] = '9';
                    k--;
                }
                idxList.Remove(i);
            }
            
            // Change idxList chars
            for(int i = 0; i < idxList.Count; i++)
            {
                if(k > idxList.Count)
                {
                    if (sb[idxList[i]] != '9')
                    {
                        sb[idxList[i]] = '9';
                        k--;
                    }                    
                    
                    if (sb[n - 1 - idxList[i]] != '9')
                    {
                        sb[n - 1 - idxList[i]] = '9';
                        k--;
                    }
                    idxList.Remove(sb[idxList[i]]);
                }
                else
                {
                    if (sb[idxList[i]] > sb[n - 1 - idxList[i]])
                    {
                        sb[n - 1 - idxList[i]] = sb[idxList[i]];
                    }
                    else
                    {
                        sb[idxList[i]] = sb[n - 1 - idxList[i]];
                    }
                    idxList.Remove(sb[idxList[i]]);
                    k--;
                }
            }

            // Change middle number if odd
            if (k > 0 && n % 2 != 0)
            {
                sb[n / 2] = '9';
            }

            return sb.ToString();
        }

        /*****Problem: Lily's Homework*****/        
        public static int lilysHomework(List<int> arr)
        {
            int minSwaps = arr.Count-1;
            Dictionary<int, int> map = new Dictionary<int, int>();
            for(int i = 0; i < arr.Count; i++)
            {
                map.Add(arr[i], i);
            }
            
            List<List<int>> sorted = [arr.Order().ToList(), arr.OrderDescending().ToList()];
            for (int c = 0; c < sorted.Count; c++)
            {
                int totalSwaps = 0;
                bool[] visited = new bool[sorted[c].Count];
                for (int i = 0; i < sorted[c].Count; i++)
                {
                    // already swapped and corrected or already present at correct pos
                    if (visited[i] || map[sorted[c][i]] == i)
                    {
                        continue;
                    }

                    int cycleSize = 0;
                    int j = i;
                    while (!visited[j])
                    {
                        visited[j] = true;
                        j = map[sorted[c][j]];
                        cycleSize++;
                    }

                    if (cycleSize > 0)
                    {
                        // Cycle size is number of nodes minus 1
                        totalSwaps += (cycleSize - 1);
                    }
                }
                minSwaps = Math.Min(minSwaps, totalSwaps);
            }
            return minSwaps;
        }

        /*****Problem: Tree: Postorder/Preorder Traversal*****/                   
        public static void postOrder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            postOrder(root.left);
            postOrder(root.right);
            Console.Write(root.data + " ");
        }

        public static void preOrder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            Console.Write(root.data + " ");
            preOrder(root.left);
            preOrder(root.right);                
        }
        

        /*****Problem: Tree: Huffman Decoding*****/
        public abstract class Node : IComparable<Node> {
            public int frequency; // the frequency of this tree
            public char data;
            public Node? left, right;
            public Node(int freq)
            {
                frequency = freq;
            }

            // compares on the frequency
            public int CompareTo(Node tree)
            {
                return frequency - tree.frequency;
            }
        }

        public class HuffmanLeaf : Node
        {
            public HuffmanLeaf(int freq, char val) : base (freq)
            {
                //frequency = freq;
                data = val;
            }
        }

        class HuffmanNode : Node
        {
            public HuffmanNode(Node l, Node r) : base(l.frequency + r.frequency)
            {
                //base(frequency = l.frequency + r.frequency);
                left = l;
                right = r;
            }
        }

        public static void decode(string s, Node root)
        {
            Node current = root;
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == '0')
                {
                    current = current.left;
                }
                else if (s[i] == '1')
                {
                    current = current.right;
                }

                if (current.data != 0)
                {
                    Console.Write(current.data);
                    current = root;
                }
            }  
        }

        // input is an array of frequencies, indexed by character code
        public static Node buildTree(int[] charFreqs)
        {

            PriorityQueue<Node,Node> trees = new PriorityQueue<Node, Node>();
            // initially, we have a forest of leaves
            // one for each non-empty character
            for (int i = 0; i < charFreqs.Length; i++)
                if (charFreqs[i] > 0) {
                    HuffmanLeaf HL = new HuffmanLeaf(charFreqs[i], (char)i);
                    trees.Enqueue(HL, HL);
                }

            //assert trees.size() > 0;

            // loop until there is only one tree left
            while (trees.Count > 1)
            {
                // two trees with least frequency
                Node a = trees.Dequeue();
                Node b = trees.Dequeue();

                // put into new node and re-insert into queue
                HuffmanNode HN = new HuffmanNode(a, b);
                trees.Enqueue(HN, HN);
            }

            return trees.Dequeue();
        }

        //public static Map<Character, String> mapA = new HashMap<Character, String>();
        public static Dictionary<char, string> mapA = new Dictionary<char, string>();

        public static void printCodes(Node tree, StringBuilder prefix)
        {

            //assert tree != null;

            if (tree is HuffmanLeaf) {
                HuffmanLeaf leaf = (HuffmanLeaf)tree;

                // print out character, frequency, and code for this leaf (which is just the prefix)
                //System.out.println(leaf.data + "\t" + leaf.frequency + "\t" + prefix);
                mapA.Add(leaf.data, prefix.ToString());

            } else if (tree is HuffmanNode) {
                HuffmanNode node = (HuffmanNode)tree;

                // traverse left
                prefix.Append('0');
                printCodes(node.left, prefix);
                prefix.Remove(prefix.Length - 1, 1);

                // traverse right
                prefix.Append('1');
                printCodes(node.right, prefix);
                prefix.Remove(prefix.Length - 1, 1);
            }
        }

        /*****Problem: Connected Cells in a Grid*****/
        public static int connectedCell(List<List<int>> matrix)
        {
            int maxRegion = 0;
            int size = 0;
            for (int r = 0; r < matrix.Count; r++)
            {
                for (int c = 0; c < matrix[r].Count; c++)
                {
                    if (matrix[r][c] == 1)
                    {
                        size = findRegion(matrix, r, c);
                        maxRegion = Math.Max(maxRegion, size);
                    }
                }
            }

            return maxRegion;            
        }

        public static int findRegion(List<List<int>> matrix, int r, int c)
        {
            if(r >= matrix.Count  || c >= matrix[0].Count
                || r < 0 || c < 0 
                || matrix[r][c] == 0) 
            {
                return 0;
            }
            matrix[r][c] = 0;

            int cnt = 1;
            cnt += findRegion(matrix, r-1, c-1);
            cnt += findRegion(matrix, r-1, c);
            cnt += findRegion(matrix, r-1, c+1);
            cnt += findRegion(matrix, r, c+1);
            cnt += findRegion(matrix, r+1, c+1);
            cnt += findRegion(matrix, r+1, c);
            cnt += findRegion(matrix, r+1, c-1);
            cnt += findRegion(matrix, r, c-1);

            return cnt;
        }


    }
}
