using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    internal class Prep3MonthsWk13
    {
        /*****Problem: Tree: Find the Running Median*****/
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
    }
}
