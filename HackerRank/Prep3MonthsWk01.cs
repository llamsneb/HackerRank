using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    internal class Prep3MonthsWk01
    {
        /*****Problem: Plus Minus*****/
        public static void plusMinus(List<int> arr)
        {
            int posCnt = 0;
            int negCnt = 0;
            int zerCnt = 0;

            foreach (int i in arr)
            {
                if (i > 0)
                {
                    posCnt++;
                }
                else if (i < 0)
                {
                    negCnt++;
                }
                else
                {
                    zerCnt++;
                }
            }

            decimal pRat = (decimal)posCnt / arr.Count;
            decimal nRat = (decimal)negCnt / arr.Count;
            decimal zRat = (decimal)zerCnt / arr.Count;

            Console.WriteLine($"{pRat.ToString("0.000000")}");
            Console.WriteLine($"{nRat.ToString("0.000000")}");
            Console.WriteLine($"{zRat.ToString("0.000000")}");
        }

        /*****Problem: Mini-Max Sum*****/
        public static void miniMaxSum(List<int> arr)
        {
            long max = arr[0];
            long min = arr[0];
            long sum = arr[0];
            for (int i = 1; i < arr.Count; i++)
            {
                if (max < arr[i])
                {
                    max = arr[i];
                }

                if (min > arr[i])
                {
                    min = arr[i];
                }

                sum += arr[i];
            }

            max = sum - max;
            min = sum - min;

            Console.Write(max.ToString() + " " + min.ToString());
        }

        /*****Problem: Time Conversion*****/
        public static string timeConversion(string s)
        {
            DateTime dt = DateTime.Parse(s);
            return dt.ToString("HH:mm:ss");
        }

        /*****Problem: Breaking the Records*****/
        public static List<int> breakingRecords(List<int> scores)
        {
            List<int> rcds = new List<int>();
            rcds.Add(0);
            rcds.Add(0);

            int max = scores[0];
            int min = scores[0];
            for (int i = 1; i < scores.Count; i++)
            {
                if (scores[i] > max)
                {
                    max = scores[i];
                    rcds[0]++;
                }

                if (scores[i] < min)
                {
                    min = scores[i];
                    rcds[1]++;
                }
            }

            return rcds;
        }

        /*****Problem: Camel Case 4*****/
        public static void camelCase4(string[] inLines)
        {
            string outLine;
            //while ((inLine = Console.ReadLine()) != null)
            foreach (string inLine in inLines)
            {
                outLine = inLine.Substring(4);
                if (inLine[0] == 'S')
                {
                    for (int i = 1; i < outLine.Length; i++)
                    {
                        if (Char.IsUpper(outLine[i]))
                        {
                            outLine = outLine.Insert(i, " ");
                            i++;
                        }
                    }
                    char[] charsToTrim = { '(', ')' };
                    outLine = outLine.ToLower().Trim(charsToTrim);
                }
                else if (inLine[0] == 'C')
                {
                    string[] splits = outLine.Split(' ');

                    if (inLine[2] == 'M' || inLine[2] == 'V')
                    {
                        splits[0] = splits[0].ToLower();
                        for (int i = 1; i < splits.Length; i++)
                        {
                            splits[i] = string.Concat(
                                splits[i][0].ToString().ToUpper(),
                                splits[i].AsSpan(1));

                            if (inLine[2] == 'M' && i == splits.Length - 1)
                            {
                                splits[i] = string.Concat(
                                    splits[i],
                                    "()");
                            }
                        }

                        outLine = string.Concat(splits);
                    }
                    else if (inLine[2] == 'C')
                    {
                        for (int i = 0; i < splits.Length; i++)
                        {
                            splits[i] = string.Concat(
                                splits[i][0].ToString().ToUpper(),
                                splits[i].AsSpan(1));
                        }

                        outLine = string.Concat(splits);
                    }
                }

                Console.WriteLine(outLine);
            }
        }

        /*****Problem: Divisible Sum Pairs*****/
        public static int divisibleSumPairs(int n, int k, List<int> ar)
        {
            int cnt = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if ((ar[i] + ar[j]) % k == 0)
                    {
                        cnt++;
                    }
                }
            }
            return cnt;
        }

        /*****Problem: Sparse Arrays*****/

        public static List<int> matchingStrings(List<string> strings, List<string> queries)
        {
            int count;
            List<int> result = new List<int>();
            foreach (string q in queries)
            {
                count = strings.Count(str => str == q);
                result.Add(count);
            }
            return result;
        }

        public static List<int> matchingStringsV2(List<string> strings, List<string> queries)
        {
            List<int> cnts = new List<int>();
            for (int i = 0; i < queries.Count; i++)
            {
                cnts.Add(0);
                for (int j = 0; j < strings.Count; j++)
                {
                    if (queries[i] == strings[j])
                    {
                        cnts[i]++;
                    }
                }
            }
            return cnts;
        }

        /*****Problem: Find the Median*****/
        public static int findMedian(List<int> arr)
        {
            int n = arr.Count;
            sort(arr, 0, n - 1);
            int med = n / 2;
            return arr[med];
        }        

        static void swap(List<int> arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        // This function takes last element as pivot,
        // places the pivot element at its correct position
        // in sorted array, and places all smaller to left
        // of pivot and all greater elements to right of pivot
        static int partition(List<int> arr, int low, int high)
        {
            // Choosing the pivot
            int pivot = arr[high];

            // Index of smaller element and indicates
            // the right position of pivot found so far
            int i = (low - 1);

            for (int j = low; j <= high - 1; j++)
            {
                // If current element is smaller than the pivot
                if (arr[j] < pivot)
                {
                    // Increment index of smaller element
                    i++;
                    swap(arr, i, j);
                    //int temp = arr[i];
                    //arr[i] = arr[j];
                    //arr[j] = temp;
                }
            }
            swap(arr, i + 1, high);
            //int temp2 = arr[i+1];
            //arr[i+1] = arr[high];
            //arr[high] = temp2;
            return (i + 1);
        }

        // The main function that implements QuickSort
        // arr[] --> Array to be sorted,
        // low --> Starting index,
        // high --> Ending index
        public static void sort(List<int> arr, int low, int high)
        {
            if (low < high)
            {
                // pi is partitioning index, arr[p]
                // is now at right place
                int pi = partition(arr, low, high);

                // Separately sort elements before
                // and after partition index
                sort(arr, low, pi - 1);
                sort(arr, pi + 1, high);
            }
        }                
    }
}
