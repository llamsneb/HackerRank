using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    internal class Prep3MonthsWk08
    {
        /*****Problem: Merge two sorted linked lists*****/
        static SinglyLinkedListNode mergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            SinglyLinkedListNode retList = null;
            SinglyLinkedListNode head = null;
            if (head1.data <= head2.data)
            {
                retList = head1;
                head1 = head1.next;
            }
            else
            {
                retList = head2;
                head2 = head2.next;
            }
            head = retList;

            while (head1 != null && head2 != null)
            {
                if (head1.data <= head2.data)
                {
                    retList.next = head1;
                    head1 = head1.next;
                }
                else
                {
                    retList.next = head2;
                    head2 = head2.next;
                }
                retList = retList.next;
            }
            retList.next = (head1 != null) ? head1 : head2;
            return head;
        }

        static bool hasCycle(SinglyLinkedListNode head)
        {
            SinglyLinkedListNode slow = head;
            SinglyLinkedListNode fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                {
                    return true;
                }
            }
            return false;
        }

        static bool hasCycleV2(SinglyLinkedListNode head)
        {
            if (head == null || head.next == null)
            { return false; }

            SinglyLinkedListNode slow = head;
            SinglyLinkedListNode fast = head.next;
            while (fast != null && fast.next != null)
            {
                if (slow == fast)
                {
                    return true;
                }
                slow = slow.next;
                fast = fast.next.next;

            }
            return false;
        }

        static bool hasCycleV3(SinglyLinkedListNode head)
        {
            SinglyLinkedListNode slow = head;
            SinglyLinkedListNode fast = head;
            bool hasCycle = false;
            while (head != null || !hasCycle)
            {
                slow.next = head.next;
                fast.next = head.next.next;
                if (slow == fast)
                {
                    hasCycle = true;
                }

                head = head.next;
            }
            return hasCycle;
        }


        /*****Problem: Ice Cream Parlor*****/
        public static List<int> icecreamParlor(int m, List<int> arr)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            List<int> retList = new List<int>();

            for (int i = 0; i < arr.Count; i++)
            {
                int searchKey = m - arr[i];
                if (dic.ContainsKey(searchKey))
                {
                    retList.AddRange(new List<int> { dic[searchKey] + 1, i + 1 });
                    break;
                }

                dic[arr[i]] = i;
            }
            return retList;
        }

        public static List<int> icecreamParlorV2(int m, List<int> arr)
        {
            List<int> retList = new List<int>();

            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = i + 1; j < arr.Count; j++)
                {
                    if (arr[i] + arr[j] == m)
                    {
                        retList.AddRange(new List<int> { i + 1, j + 1 });
                        break;
                    }
                }
            }
            return retList;
        }

        public static List<int> icecreamParlorV3(int m, List<int> arr)
        {
            //Dictionary<int, int> dic = arr.Where(a => a < m).ToDictionary(d => d, t => arr.IndexOf(t));
            Dictionary<int, int> dic = new Dictionary<int, int>();
            //Hashtable dic = new Hashtable();
            List<int> retList = new List<int>();
            //foreach (var item in dic)
            //{
            //    int searchKey = m - item.Key;
            //    if(dic.TryGetValue(searchKey, out keyVal)) {
            //        retList.AddRange(new List<int> { dic[searchKey], item.Value });
            //        break;
            //    }                
            //}

            for (int i = 0; i < arr.Count; i++)
            {
                int searchKey = m - arr[i];
                //if (dic.TryGetValue(searchKey, out keyVal))
                if (dic.ContainsKey(searchKey))
                {
                    //retList.AddRange(new List<int> { dic[searchKey]+1, i+1 });
                    return new List<int> { dic[searchKey] + 1, i + 1 };
                    //break;
                }
                dic[arr[i]] = i;
                //dic.Add(arr[i], i);
            }
            return null;//retList;            
        }

        /*****Problem: Inserting a Node Into a Sorted Doubly Linked List*****/
        static DoublyLinkedListNode sortedInsert(DoublyLinkedListNode llist, int data)
        {
            DoublyLinkedListNode head = llist;
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(data);

            if (llist.data >= data)
            {
                newNode.next = llist;
                llist.prev = newNode;
                return newNode;
            }

            while (llist.next != null && llist.data < data)
            {
                llist = llist.next;
            }

            if (llist.data < data)
            {
                newNode.prev = llist;
                llist.next = newNode;
                return head;
            }
            else
            {
                llist.prev.next = newNode;
                newNode.prev = llist.prev.next;
                newNode.next = llist;
                llist.prev = newNode;
            }

            return head;
        }

        /*****Problem: Sherlock and Anagrams*****/
        public static int sherlockAndAnagrams(string s)
        {
            int cnt = 0;
            Dictionary<string, int> map = new Dictionary<string, int>();
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i + 1; j <= s.Length; j++)
                {
                    char[] charArr = s.Substring(i, j - i).ToCharArray();
                    Array.Sort(charArr);
                    string subStr = new string(charArr);

                    if (map.ContainsKey(subStr))
                    {
                        cnt += map[subStr];
                        map[subStr]++;
                    }
                    else
                    {
                        map.Add(subStr, 1);
                    }
                }
            }
            return cnt;
        }

        /*****Problem: Super Reduced String*****/
        public static string superReducedString(string s)
        {
            Stack<char> charStk = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (charStk.Count > 0 && charStk.Peek() == s[i])
                {
                    charStk.Pop();
                }
                else
                {
                    charStk.Push(s[i]);
                }
            }

            //StringBuilder sb = new StringBuilder();
            //while (charStk.Count > 0)
            //{
            //    sb.Append(charStk.Pop());
            //}            

            s = string.Concat(charStk.Reverse());            

            return s.Length > 0 ? s : "Empty String";
        }

        public static string superReducedStringV2(string s)
        {
            int i = 0;
            while (s.Length > 0 && i < s.Length - 1)
            {
                if (s[i] == s[i + 1])
                {
                    s = s.Remove(i, 2);
                    i = 0;
                    continue;
                }
                i++;
            }

            return s.Length > 0 ? s : "Empty String";
        }

        /*****Problem: Balanced Brackets*****/
        public static string isBalanced(string s)
        {
            if (s.Length % 2 > 0)
            {
                return "NO";
            }
            Dictionary<char, char> keyValues = new Dictionary<char, char>
            {
                { '{', '}' },
                { '[', ']' },
                { '(', ')' }
            };

            Stack<char> charStk = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (charStk.Count > 0 && keyValues[charStk.Peek()] == s[i])
                {
                    charStk.Pop();
                }
                else if (keyValues.ContainsKey(s[i]))
                {
                    charStk.Push(s[i]);
                }
                else
                {
                    return "NO";
                }
            }

            return charStk.Count > 0 ? "NO" : "YES";
        }

        /*****Problem: Delete duplicate-value nodes from a sorted linked list*****/
        public static SinglyLinkedListNode removeDuplicates(SinglyLinkedListNode llist)
        {
            SinglyLinkedListNode head = llist;
            while (llist != null && llist.next != null)
            {
                if (llist.next.data == llist.data)
                {
                    llist.next = llist.next.next;
                }
                else
                {
                    llist = llist.next;
                }
            }
            return head;
        }

    }
}
