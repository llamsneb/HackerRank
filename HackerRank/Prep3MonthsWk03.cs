using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    internal class Prep3MonthsWk03
    {
        /*****Problem: Permuting Two Arrays*****/
        public static string twoArrays(int k, List<int> A, List<int> B)
        {
            A.Sort();
            B.Sort();
            B.Reverse();

            for (int i = 0; i < A.Count; i++)
            {
                if (A[i] + B[i] < k)
                {
                    return "NO";
                }
            }

            return "YES";
        }

        /*****Problem: Subarray Division 2*****/
        public static int birthday(List<int> s, int d, int m)
        {
            int cnt = 0;
            for (int i = 0; i <= s.Count - m; i++)
            {
                int sum = 0;
                for (int j = i; j < i + m; j++)
                {
                    sum += s[j];
                }
                if (sum == d)
                {
                    cnt++;
                }
            }
            return cnt;
        }

        /*****Problem: XOR Strings 3*****/
        string strings_xor(string s, string t)
        {

            string res = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == t[i])
                    res += '0';
                else
                    res += '1';
            }

            return res;
        }

        /*****Problem: Sales by Match*****/
        public static int sockMerchant(int n, List<int> ar)
        {
            int pairs = 0;
            var sList = ar.GroupBy(k => k).ToList();
            sList.ForEach(s => pairs += s.Count() / 2);
            return pairs;
        }

        /*****Problem: Migratory Birds*****/
        public static int migratoryBirds(List<int> arr)
        {
            return arr.GroupBy(b => b).OrderByDescending(g => g.Count()).ThenBy(t => t.Key).Select(s => s.Key).FirstOrDefault();
        }

        /*****Problem: Maximum Perimeter Triangle*****/
        public static List<int> maximumPerimeterTriangle(List<int> sticks)
        {
            var sorted = sticks.OrderByDescending(o => o).ToList();
            for (int i = 0; i < sorted.Count - 2; i++)
            {
                if (sorted[i] < sorted[i + 1] + sorted[i + 2])
                {
                    return new List<int>() { sorted[i + 2], sorted[i + 1], sorted[i] };
                }
            }

            return new List<int>() { -1 };
        }

        /*****Problem: Zig Zag Sequence*****/
        // C++
        //void findZigZagSequence(vector<int> a, int n)
        //{
        //    sort(a.begin(), a.end());
        //    int mid = (n) / 2;
        //    swap(a[mid], a[n - 1]);

        //    int st = mid + 1;
        //    int ed = n - 2;
        //    while (st <= ed)
        //    {
        //        swap(a[st], a[ed]);
        //        st = st + 1;
        //        ed = ed - 1;
        //    }
        //    for (int i = 0; i < n; i++)
        //    {
        //        if (i > 0) cout << " ";
        //        cout << a[i];
        //    }
        //    cout << endl;
        //}

        /*****Problem: Drawing Book*****/
        public static int pageCount(int n, int p)
        {
            int retVal = 0;
            if (n / p < 2)
            {
                if (n % 2 == 0)
                {
                    n++;
                }
                retVal = (n - p) / 2;
            }
            else
            {
                retVal = p / 2;
            }

            return retVal;
        }

        /*****Problem: Between Two Sets*****/
        public static int getTotalX(List<int> a, List<int> b)
        {
            int cnt = 0;
            bool isFactor = true;
            for (int i = a.Last(); i <= b.First(); i++)
            {
                isFactor = true;
                foreach (int y in a)
                {
                    if (i % y != 0)
                    {
                        isFactor = false;
                        break;
                    }
                }

                foreach (int x in b)
                {
                    if (x % i != 0)
                    {
                        isFactor = false;
                        break;
                    }
                }

                if (isFactor)
                {
                    cnt++;
                }
            }
            return cnt;
        }
    }    
}
