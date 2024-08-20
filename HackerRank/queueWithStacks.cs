using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    internal class queueWithStacks
    {
        private Stack<int> stack1 = new Stack<int>();
        private Stack<int> stack2 = new Stack<int>();

        public void enqueue(int num)
        {
            stack1.Push(num);
        }

        public void dequeue()
        {
            if (stack2.Count == 0)
            {
                while (stack1.TryPop(out int result))
                {
                    stack2.Push(result);
                }
            }
            stack2.Pop();
        }

        public int peek()
        {
            if (stack2.Count == 0)
            {
                while (stack1.TryPop(out int result))
                {
                    stack2.Push(result);
                }
            }
            return stack2.Peek();
        }
    }
}
