using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    internal class Prep3MonthsWk10
    {
        /*****Problem: Lego Blocks*****/
        public static int legoBlocks(int n, int m)
        {
            if (n == 1)
            {
                return m < 5 ? 1 : 0;
            }

            long MOD = 1000000007;
            //Create list with 4 types of blocks
            List<long> f = new List<long> { 0, 1, 2, 4, 8 };

            //Add block combinations to list greater than 4 up to width
            for (int i = 5; i < m + 1; i++)
            {
                f.Add((long)((f[i - 4] + f[i - 3] + f[i - 2] + f[i - 1]) % MOD));
            }

            //Store total permutations in list (num of blocks in row ^ h % MOD)
            List<long> total = new List<long>();
            for (int i = 0; i < m + 1; i++)
            {
                total.Add(f[i]);
                for (int j = 0; j < n - 1; j++)
                {
                    //Must use modulo after each * operation
                    total[i] = (f[i] * total[i]) % MOD;
                }
                //total.Add((long)(Math.Pow(f[i], n) % MOD)); 
            }

            List<long> good = new List<long> { 0 };
            long bad;
            for (int i = 1; i < m + 1; i++)
            {
                good.Add(total[i]);
                bad = 0;
                for (int j = 1; j < i; j++)
                {
                    bad += ((good[j] * total[i - j]) % MOD);
                    //good[i] = (good[i] - (good[j] * total[i - j]) % MOD + MOD) % MOD;
                }
                //Add modulus to prevent int overflow
                good[i] = ((good[i] - bad) % MOD + MOD) % MOD;
            }

            return (int)good[m];
            //return (int)(good[m] % MOD);
        }

        /*****Problem: Weighted Uniform Strings*****/
        public static List<string> weightedUniformStrings(string s, List<int> queries)
        {
            Dictionary<char, int> keyValuePairs = new Dictionary<char, int>
            {
                { 'a', 1 },
                { 'b', 2 },
                { 'c', 3 },
                { 'd', 4 },
                { 'e', 5 },
                { 'f', 6 },
                { 'g', 7 },
                { 'h', 8 },
                { 'i', 9 },
                { 'j', 10 },
                { 'k', 11 },
                { 'l', 12 },
                { 'm', 13 },
                { 'n', 14 },
                { 'o', 15 },
                { 'p', 16 },
                { 'q', 17 },
                { 'r', 18 },
                { 's', 19 },
                { 't', 20 },
                { 'u', 21 },
                { 'v', 22 },
                { 'w', 23 },
                { 'x', 24 },
                { 'y', 25 },
                { 'z', 26 }
            };

            StringBuilder sb = new StringBuilder();
            sb.Append(s[0]);
            int w = keyValuePairs[s[0]];
            List<int> wghts = new List<int> { w };
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] != sb[0])
                {
                    sb.Clear();
                    w = 0;
                }

                sb.Append(s[i]);
                w += keyValuePairs[s[i]];
                if (!wghts.Contains(w))
                {
                    wghts.Add(w);
                }
            }

            List<string> retVals = new List<string>();
            foreach (int q in queries)
            {
                if (wghts.Contains(q))
                {
                    retVals.Add("Yes");
                }
                else
                {
                    retVals.Add("No");
                }
            }

            return retVals;
        }

        /*****Problem: Permutation game*****/
        public static Dictionary<string, bool> memo = new Dictionary<string, bool>();
        public static bool findWinner(List<int> arr)
        {
            string key = string.Join("|", arr);
            if (memo.ContainsKey(key))
            {
                return memo[key];
            }

            bool isIncreasing = true;
            for (int i = 0; i < arr.Count - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    isIncreasing = false;
                    break;
                    //return false;
                }
            }
            if (isIncreasing)
            {
                memo.Add(key, true);
                return true;
            }

            for (int i = 0; i < arr.Count; i++)
            {
                List<int> newArr = arr.Where((val, ind) => ind != i).ToList();
                if (findWinner(newArr))
                {
                    memo.Add(key, false);
                    return false;
                }
            }

            memo.Add(key, true);
            return true;

        }
        public static string permutationGame(List<int> arr)
        {
            memo.Clear(); // Clear the memo dictionary for each test case
            return findWinner(arr) ? "Bob" : "Alice";
        }

        /*****Problem: QHEAP1*****/
        public static void minHeapSwitch(string line, MinHeap minHeap)
        {
            string[] inLine = line.Split();
            switch (Convert.ToInt32(inLine[0]))
            {
                case 1:
                    minHeap.Insert(Convert.ToInt32(inLine[1]));
                    break;
                case 2:
                    minHeap.Delete(Convert.ToInt32(inLine[1]));
                    break;
                case 3:
                    Console.WriteLine(minHeap.heap[0]);
                    break;
            }
        }

        /*****Problem: Largest Rectangle*****/
        public static long largestRectangle(List<int> h)
        {
            Stack<int> stack = new Stack<int>();
            int maxArea = 0;
            int height;
            int width;

            int i = 0; 
            while (i < h.Count) 
            {
                if (stack.Count == 0 || h[stack.Peek()] <= h[i])
                {
                    stack.Push(i);
                    i++;
                }
                else
                {
                    height = h[stack.Pop()];
                    width = stack.Count == 0 ? i : i - stack.Peek() - 1;
                    maxArea = Math.Max(maxArea, height*width);
                }
            }

            while(stack.Count > 0)
            {
                height = h[stack.Pop()];
                width = stack.Count == 0 ? h.Count : h.Count - stack.Peek() - 1;
                maxArea = Math.Max(maxArea, height * width);
            }

            return maxArea;                        
        }

        /*****Problem: Jesse and Cookies*****/
        public static int cookies(int k, List<int> A)
        {
            PriorityQueue<int, int> heap = new PriorityQueue<int, int>();
            foreach(int i in A)
            {
                heap.Enqueue(i, i);
            }

            int cnt = 0;
            while (heap.Count > 1 && heap.Peek() < k)
            {
                int min1 = heap.Dequeue();
                int min2 = heap.Dequeue();

                int newC = min1 + (2 * min2);
                heap.Enqueue(newC, newC);
                cnt++;
            }

            return heap.Peek() >= k ?  cnt : -1 ;
        }

        /*****Problem: Hackerland Radio Transmitters*****/
        public static int hackerlandRadioTransmitters(List<int> x, int k)
        {            
            x.Sort();           
            int tCnt = 0;
            int i = 0;           
            while (i < x.Count)
            {
                tCnt++;
                //Get location of first trans (left range of trans)
                int range = x[i] + k;
                while (i < x.Count && x[i] <= range)
                {
                    i++;
                }
                //Move index back to last element in range
                i--;

                //Move to range of next transmitter (right range of trans) <k--t--k--next-->
                range = x[i] + k;
                while(i< x.Count && x[i] <= range)
                {
                    i++;
                }
            }
            return tCnt;
        }

        public static int pairs(int k, List<int> arr)
        {
            arr.Sort();
            int cnt = 0;
            for (int i = arr.Count - 1; i >= 0 && arr[i] > k; i--)
            { 
                for (int j = i - 1; j >= 0; j--)
                {
                    int x = arr[i] - arr[j];
                    if (x == k)
                    {
                        cnt++;
                    }
                    else if(x < k)
                    { 
                        break;
                    }
                }
            }
        
            return cnt;
        }

        public static int pairs2(int k, List<int> arr)
        {
            HashSet<int> hashSet = new HashSet<int>(arr);
            return arr.Count(a => hashSet.Contains(a + k));
        }

        public static void almostSorted2(List<int> arr)
        {
            List<int> sorted = arr.Order().ToList();
            List<int> mismatched = new List<int>();
            for(int i = 0; i < arr.Count; i++)
            {
                if (arr[i] != sorted[i])
                {
                    mismatched.Add(i);
                }
            }
            int l = mismatched[0];
            int r = mismatched.Last();
            bool reversed = true; ;
            if (mismatched.Count > 2)
            {
                for (int i = r; i > l; i--)
                {
                    if (arr[i] > arr[i - 1])
                    {
                        reversed = false;
                    }
                }
                if (reversed)
                {
                    Console.WriteLine("yes");
                    Console.WriteLine($"reverse {l + 1} {r + 1}");
                    return;
                }                
            }
            else
            {
                (arr[l], arr[r]) = (arr[r], arr[l]);
                if (arr.SequenceEqual(sorted))
                {
                    Console.WriteLine("yes");
                    Console.WriteLine($"swap {l + 1} {r + 1}");
                    return;
                }                
            }

            Console.WriteLine("no");
        }

        public static void almostSorted(List<int> arr)
        {
            int lInd = 0;
            int rInd = 0;
            int ops = 0;
            bool reverse = true;
            for(int i = 0; i < arr.Count-1 && ops < 2; i++)
            {               
                if (arr[i] > arr[i + 1])
                {
                    ops++;
                    lInd = i+1;
                    int j = i + 1;
                    while (j < arr.Count && arr[i] > arr[j]){
                        j++;
                    }

                    rInd = j;
                    j--;
                    if(rInd-lInd < 3)
                    {
                        reverse = false;
                    }
                    while (j > i + 1 && reverse)
                    {
                        if (arr[j] > arr[j - 1])
                        {
                            reverse = false;
                        }
                        j--;
                    }
                    if (!reverse)
                    {
                        (arr[lInd-1], arr[rInd-1]) = (arr[rInd-1], arr[lInd-1]);
                        if (arr[lInd-1] > arr[lInd])
                        {
                            Console.WriteLine("no");
                            return;
                        }
                    }
                    else
                    {
                        i = rInd;
                    }
                    //while (i < arr.Count-1 && arr[i] > arr[i + 1])
                    //{
                    //    i++;
                    //}                                                          
                }
            }
            if (ops > 1 )
                //|| (rInd - 1 != arr.Count - 1 && arr[lInd - 1] > arr[rInd]))
            {
                Console.WriteLine("no");
            }
            //else if (rInd-lInd > 1)
            else if (reverse)
                {
                Console.WriteLine("yes");
                Console.WriteLine("reverse " + lInd + " " + rInd);
            }
            else
            {
                Console.WriteLine("yes");
                Console.WriteLine("swap " + lInd + " " + rInd);
            }
        }
    }    
}
