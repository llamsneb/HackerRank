using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    public class UnionFind
    {
        public int[] parent;
        public int[] size;
        public UnionFind(int n)
        {
            parent = new int[n+1];
            size = new int[n+1];
            for (int i = 1; i <= n; i++)
            {
                parent[i] = i;
                size[i] = 1;
            }
        }

        public int Find(int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]);
            }
            return parent[x];
        }

        public void Union(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);
            if (rootX != rootY)
            {
                if (size[rootX] > size[rootY])
                {
                    parent[rootY] = rootX;
                    size[rootX] += size[rootY];
                    size[rootY] = 0;
                }
                else
                {
                    parent[rootX] = rootY;
                    size[rootY] += size[rootX];
                    size[rootX] = 0;
                }                
            }
        }
    }
}
