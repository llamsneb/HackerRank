using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    internal class Prep3MonthsWk04
    {
        /*****Problem: Picking Numbers*****/
        public static int pickingNumbers(List<int> a)
        {
            a.Sort();
            int l = 1;
            int max = 0;
            int x = a[0];
            for (int i = 1; i < a.Count; i++)
            {
                if (Math.Abs(a[i] - x) <= 1)
                {
                    l++;
                    if (max < l)
                    {
                        max = l;
                    }
                }
                else
                {
                    l = 1;
                    x = a[i];
                }
            }

            return max;
        }

        /*****Problem: Left Rotation*****/
        public static List<int> rotateLeft(int d, List<int> arr)
        {
            int n = arr.Count;
            List<int> retList = new List<int>();

            for (int i = 0; i < n; i++)
            {
                if (i < n - d)
                {
                    retList.Add(arr[i + d]);
                }
                else
                {
                    retList.Add(arr[i + d - n]);
                }
            }

            return retList;
        }

        /*****Problem: Number Line Jumps*****/
        public static string kangaroo(int x1, int v1, int x2, int v2)
        {
            if (x1 > x2 && v1 >= v2 || x2 > x1 && v2 >= v1)
            {
                return "NO";
            }
            //x1 + j*v1 == x2 + j*v2  
            //j*(v1-v2) == x2-x1      
            int j = Math.Abs(x1 - x2) / Math.Abs(v1 - v2);
            if (x1 + j * v1 == x2 + j * v2)
            {
                return "YES";
            }
            else
            {
                return "NO";
            }
        }

        /*****Problem: Separate the Numbers*****/
        public static void separateNumbers(string s)
        {
            // s.length/2 because if split after half then
            // the 2nd number can not be consecutive
            for (int i = 1; i < (s.Length / 2) + 1; i++)
            {
                //Substring(startIndex, length)
                var numStr = s.Substring(0, i);
                var num = long.Parse(numStr);

                while (numStr.Length < s.Length)
                {
                    num++;
                    numStr += num.ToString();
                }

                if (numStr == s)
                {
                    Console.WriteLine($"YES {s.Substring(0, i)}");
                    return;
                }
            }

            Console.WriteLine("NO");
        }

        /*****Problem: Closest Numbers*****/
        public static List<int> closestNumbers(List<int> arr)
        {
            arr.Sort();
            int diff = 0;
            int min = 0;
            List<int> retList = new List<int>();
            for (int i = 0; i < arr.Count - 1; i++)
            {
                diff = Math.Abs(arr[i] - arr[i + 1]);
                if (diff < min || min == 0)
                {
                    min = diff;
                }
            }

            for (int i = 0; i < arr.Count - 1; i++)
            {
                diff = Math.Abs(arr[i] - arr[i + 1]);
                if (diff == min)
                {
                    retList.Add(arr[i]);
                    retList.Add(arr[i + 1]);
                }
            }
            return retList;
        }

        /*****Problem: Tower Breakers*****/
        public static int towerBreakers(int n, int m)
        {
            return n % 2 == 0 || m == 1 ? 2 : 1;
        }

        public static int towerBreakersV2(int n, int m)
        {
            int cnt = 0;
            for (int i = 0; i < n; i++)
            {
                int t = m;
                while (t > 1)
                {
                    int x = t - 1;
                    t -= x;
                    cnt++;
                }
            }

            return cnt % 2 == 0 ? 2 : 1;
        }

        /*****Problem: Minimum Absolute Difference in an Array*****/
        public static int minimumAbsoluteDifference(List<int> arr)
        {
            int min = -1;
            arr.Sort();
            for (int i = 0; i < arr.Count - 1; i++)
            {
                int dif = Math.Abs(arr[i] - arr[i + 1]);

                if (min == -1 || dif < min)
                {
                    min = dif;
                }
            }

            return min;
        }

        /*****Problem: Caesar Cipher*****/
        public static string caesarCipher(string s, int k)
        {
            if (k > 26)
            {
                k = k % 26;
            }
            string encStr = "";
            char z = 'z';
            char begin = '`';
            foreach (char c in s)
            {
                if (char.IsLetter(c))
                {
                    if (char.IsUpper(c))
                    {
                        z = 'Z';
                        begin = '@';
                    }
                    else if (char.IsLower(c))
                    {
                        z = 'z';
                        begin = '`';
                    }

                    if (c + k > z)
                    {
                        var xtra = (c + k) - z;
                        encStr += Convert.ToChar(begin + xtra);
                    }
                    else
                    {
                        encStr += Convert.ToChar(c + k);
                    }
                }
                else
                {
                    encStr += c;
                }
            }
            return encStr;
        }

        /*****Problem: Anagram*****/
        public static int anagram(string s)
        {
            int n = s.Length;
            if (n % 2 != 0)
            {
                return -1;
            }
            string str1 = s.Substring(0, n / 2);
            string str2 = s.Substring(n / 2, n / 2);
            foreach (char c in str1)
            {
                int i = str2.IndexOf(c);
                if (i > -1)
                {
                    str2 = str2.Remove(i, 1);
                }
            }
            return str2.Count();
        }
    }
}
