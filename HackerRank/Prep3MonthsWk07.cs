using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    internal class Prep3MonthsWk07
    {
        /*****Problem: The Bomberman Game*****/
        public static List<string> bomberMan(int n, List<string> grid)
        {
            if (n == 1) return grid;

            // When n is 0, 2, 4, 6, 8...
            if (n % 2 == 0)
            {
                plantAll(grid);
            }
            else
            {
                // When n is 3, 7, 11, 15...
                List<string> bombMap = grid.ToList();
                plantAll(grid);
                detonate(grid, bombMap);

                // When n is 5, 9, 13, 17...
                if ((n - 1) % 4 == 0)
                {
                    bombMap = grid.ToList();
                    plantAll(grid);
                    detonate(grid, bombMap);
                }
            }

            return grid;
        }

        public static void detonate(List<string> grid, List<string> bombMap)
        {
            int rCnt = grid.Count;
            int cCnt = grid[0].Length;
            for (int r = 0; r < rCnt; r++)
            {
                for (int c = 0; c < cCnt; c++)
                {
                    if (bombMap[r][c] == 'O')
                    {
                        grid[r] = replaceCharAtIndex(grid[r], c, '.');
                        if (r - 1 >= 0) { grid[r - 1] = replaceCharAtIndex(grid[r - 1], c, '.'); }
                        if (r + 1 < rCnt) { grid[r + 1] = replaceCharAtIndex(grid[r + 1], c, '.'); }
                        if (c - 1 >= 0) { grid[r] = replaceCharAtIndex(grid[r], c - 1, '.'); }
                        if (c + 1 < cCnt) { grid[r] = replaceCharAtIndex(grid[r], c + 1, '.'); }
                    }
                }
            }
        }

        public static void plantAll(List<string> grid)
        {
            for (int i = 0; i < grid.Count; i++)
            {
                grid[i] = grid[i].Replace('.', 'O');
            }
        }

        public static string replaceCharAtIndex(string s, int i, char c)
        {
            StringBuilder sb = new StringBuilder(s);
            sb[i] = c;
            return sb.ToString();
        }

        /*****Problem: New Year Chaos*****/
        public static void minimumBribes(List<int> q)
        {
            int b = 0;
            for (int i = q.Count - 1; i > 0; i--)
            {
                for (int j = i; j > i - 2 && j > 0; j--)
                {
                    if (q[i] < q[j - 1])
                    {
                        (q[i], q[j - 1]) = (q[j - 1], q[i]);
                        b++;
                    }

                }
                if (q[i] != i + 1)
                {
                    Console.WriteLine("Too chaotic");
                    return;
                }
            }
            Console.WriteLine(b);
        }

        public static void minimumBribesV2(List<int> q)
        {
            int b = 0;
            for (int i = 0; i < q.Count; i++)
            {
                if (q[i] - (i + 1) > 2)
                {
                    Console.WriteLine("Too chaotic");
                    return;
                }
                for (int j = Math.Max(0, q[i] - 2); j < i; j++)
                {
                    if (q[j] > q[i])
                    {
                        b++;
                    }
                }
            }
            Console.WriteLine(b);
        }

        public static void minimumBribesV3(List<int> q)
        {
            int b = 0;
            int bTotal = 0;
            //var bribes = q.Any(x => x - q.IndexOf(x) > 3);
            //if (bribes)
            //{
            //    Console.WriteLine("Too chaotic");
            //    return;
            //}
            bool swapped = false;
            int endInx = q.Count - 1;
            

            //for (int i = 0; i <= endInx; i++)
            //{
            //    //if (q[i] - i -1 > 0)
            //    //{

            //        b = 0;
            //        for (int j = i + 1; j <= endInx; j++)
            //        {
            //            if (q[i] > q[j])
            //            {
            //                b++;
            //            }
            //        }
            //        if (b > 2)
            //        {
            //            Console.WriteLine("Too chaotic");
            //            return;
            //        }
            //        bTotal += b;
            //}

            for (int i = endInx; i > 0; i--)
            {
                for (int j = i; j > i - 2 && j > 0; j--)
                {
                    if (q[i] < q[j - 1])
                    {
                        (q[i], q[j - 1]) = (q[j - 1], q[i]);
                        b++;
                    }

                }
                if (q[i] != i + 1)
                {
                    Console.WriteLine("Too chaotic");
                    return;
                }
            }
            //q.ForEach(x => Console.WriteLine(x));
            Console.WriteLine(b);
        }

        /*****Problem: Goodland Electricity*****/
        public static int pylons(int k, List<int> arr)
        {
            int minNum = 0;
            int i = k - 1;
            int n = arr.Count;
            while (i < n)
            {
                if (arr[i] == 1)
                {
                    i += (2 * k) - 1;
                    minNum++;
                }
                else
                {
                    i--;
                    if (i < minNum * k)
                    {
                        return -1;
                    }
                }
            }

            if (i < n + k - 1)
            {
                minNum++;
            }

            return minNum;
        }

        /*****Problem: Sherlock and the Valid String*****/
        public static string isValid(string s)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (dic.ContainsKey(s[i]))
                {
                    dic[s[i]]++;
                }
                else
                {
                    dic.Add(s[i], 1);
                }
            }

            int n = dic.Count;
            int max = dic.Values.Max();
            int mVals = dic.Where(i => i.Value == max).Count();
            int lessOne = dic.Where(i => i.Value == max - 1).Count();
            int sVal = dic.Where(i => i.Value == 1).Count();
            if (mVals == 1 && lessOne == n - 1
                || sVal == 1 && mVals == n - 1
                || mVals == n)
            {
                return "YES";
            }

            return "NO";
        }
        public static string isValidV2(string s)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            Dictionary<char, int> dic2 = s.Distinct().ToDictionary(c => c, c => s.Count(t => t == c));
            int n = dic.Count;

            for (int i = 0; i < s.Length; i++)
            {
                if (dic.ContainsKey(s[i]))
                {
                    dic[s[i]]++;
                }
                else
                {
                    dic.Add(s[i], 1);
                }
            }

            //var freqs = dic.Values.GroupBy(f => f).Select(g => g.Count()).ToList();
            //if (freqs.Count == 1
            //    || freqs.Count == 2
            //    && freqs.Contains(1) && dic.Values.Max())
            //{ 

            //        return "YES";
            //}


            //if(freqs.Count == 2) 
            //{
            //    if (Math.Abs(freqs[0] - freqs[1]) == 1
            //        || freqs.Contains(1))
            //    {
            //        return "YES";
            //    }
            //}
            //else if(freqs.Count == 1)
            //{
            //    return "YES";
            //}

            return "NO";            
        }

        /*****Problem: Climbing the Leaderboard*****/
        public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
        {
            var scores = ranked.Distinct().ToList();
            int nPlayers = player.Count;
            List<int> newRanks = new List<int>();
            int j = 0;
            int i = scores.Count - 1;
            while (j < nPlayers)
            {
                if (player[j] < scores[i])
                {
                    newRanks.Add(i + 2);
                    j++;
                }
                else if (player[j] == scores[i])
                {
                    newRanks.Add(i + 1);
                    j++;
                }
                else if (i > 0)
                {
                    i--;
                }
                else if (i == 0 && player[j] > scores[i])
                {
                    newRanks.Add(i + 1);
                    j++;
                }
            }

            return newRanks;
        }
        public static List<int> climbingLeaderboardV2(List<int> ranked, List<int> player)
        {
            var scores = ranked.Distinct().ToList();
            int nPlayers = player.Count;
            List<int> newRanks = new List<int>();

            int j = 0;
            int i = scores.Count - 1;
            while (j < nPlayers)
            {
                if (player[j] < scores[i])
                {
                    newRanks.Add(i + 2);
                    j++;
                }
                else if (player[j] == scores[i])
                {
                    newRanks.Add(i + 1);
                    j++;
                }
                else if (i > 0)
                {
                    i--;
                }
                else if (i == 0 && player[j] > scores[i])
                {
                    newRanks.Add(i + 1);
                    j++;
                }
            }
            //for(int i = scores.Count - 1; i >= 0 && j < player.Count; i--)
            //{
            //    if (player[j] < scores[i])
            //    {
            //        newRanks.Add(i + 2);
            //        j++;
            //    }
            //    else if (player[j] == scores[i])
            //    {
            //        newRanks.Add(i + 1);
            //        j++;
            //    }
            //    else if (i == 0 && player[j] > scores[i])
            //    {
            //        newRanks.Add(i+1);
            //        //j++;
            //    }
            //}

            //for(int i = 0; i < player.Count; i++)
            //{
            //    //int j = 0;
            //    //for ( j < scores.Count/2; j++)
            //    //{
            //    //    if (player[j] == scores[scoreCnt / 2])
            //    //    {

            //    //    }
            //    //    else if (player[j] < scores[scoreCnt / 2])
            //    //    {
            //    //        j = (scoreCnt / 2) - 1;
            //    //    }
            //    //    else if(player[j] > scores[scoreCnt / 2])
            //    //    {
            //    //        j = (scoreCnt / 2) + 1;
            //    //    }
            //    //}

            //    var ind = scores.FindIndex(x => x <= player[i]);
            //    if (ind  == -1)
            //    {
            //        newRanks.Add(scoreCnt);
            //        scoreCnt++;
            //        scores.Add(scoreCnt);

            //    }
            //    else if (scores[ind] == player[i])
            //    {
            //        newRanks.Add(ind+1);
            //    }
            //    else
            //    {
            //        scores.Insert(ind, player[i]);
            //        newRanks.Add(ind+1);
            //    }
            //}

            return newRanks;
        }

        /*****Problem: Reverse a linked list*****/
        public static SinglyLinkedListNode reverse(SinglyLinkedListNode llist)
        {
            SinglyLinkedListNode current = llist;
            SinglyLinkedListNode prev = null;
            SinglyLinkedListNode temp = null;

            while (current != null)
            {
                temp = current.next;
                current.next = prev;
                prev = current;
                current = temp;
            }

            return prev;
        }

        /*****Problem: Reverse a doubly linked list*****/
        static DoublyLinkedListNode reverse(DoublyLinkedListNode llist)
        {
            DoublyLinkedListNode current = llist;
            DoublyLinkedListNode prev = llist.prev;
            DoublyLinkedListNode temp = null;
            while (current != null)
            {
                temp = current.next;
                current.next = current.prev;
                prev = current;
                current = temp;
            }

            return prev;
        }

        /*****Problem: Insert a node at a specific position in a linked list*****/
        static SinglyLinkedListNode insertNodeAtPosition(SinglyLinkedListNode llist, int data, int position)
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(data);
            SinglyLinkedListNode temp = llist;
            SinglyLinkedListNode head = llist;
            for (int i = 0; i < position - 1; i++)
            {
                llist = llist.next;
            }
            temp = llist.next;
            llist.next = newNode;
            newNode.next = temp;

            return head;
        }

        /*****Problem: Big Sorting*****/
        public static List<string> bigSorting(List<string> unsorted)
        {
            var sorted = unsorted.OrderBy(a => a.Length).ThenBy(a => a).ToList();
            return sorted;
        }

        public static List<string> bigSortingV2(List<string> unsorted)
        {
            var sorted = unsorted.OrderBy(s => s.Length).GroupBy(g => g.Length).Select(g => g.Order()).SelectMany(g => g).ToList();
            return sorted;
        }
    }
}
