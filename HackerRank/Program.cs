using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Quic;
using System.Numerics;
using System.Text;
using System.Xml.Linq;
using static HackerRank.Prep3MonthsWk11;
using static System.Net.Mime.MediaTypeNames;

namespace HackerRank
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> arr = new List<int>();
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);
            arr.Add(4);
            arr.Add(3);
            arr.Add(2);
            arr.Add(1);

            int res = lonelyinteger(arr);
            Console.WriteLine(res);

            List<int> result = countingSort(arr);
            foreach (int i in result) { Console.WriteLine(i); }

            separateNumbers("99100");

            caesarCipher("Always-Look-on-the-Bright-Side-of-Life", 5);

            anagram("xaxbbbxx");

            Console.WriteLine(minimumNumber(5, "2bbbb"));

            List<List<int>> queries =
            [
                new List<int> { 1, 0, 5 },
                new List<int> { 1, 1, 7 },
                new List<int> { 1, 0, 3 },
                new List<int> { 2, 1, 0 },
                new List<int> { 2, 1, 1 },
            ];

            dynamicArray(2, queries);

            List<string> grid = new List<string> { "mpxz", "abcd", "wlmf" };

            gridChallenge(grid);

            Console.WriteLine(fibonacciModified(0, 1, 10));

            Console.WriteLine(palindromeIndex("hgygsvlfwcwnswtuhmyaljkqlqjjqlqkjlaymhutwsnwcflvsgygh"));


            List<int> bribes = new List<int>() { 1, 2, 5, 3, 7, 8, 6, 4 };
            //List<int> bribes = new List<int>() { 5, 1, 2, 3, 7, 8, 6, 4 };

            minimumBribes(bribes);

            List<int> cities = new List<int> { 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0 };
            List<int> cities2 = new List<int> { 0, 1, 1, 1, 1, 0 };
            List<int> cities3 = new List<int> { 0, 1, 0, 0, 0, 1, 0 };
            List<int> cities4 = new List<int> { 0, 1, 0, 0, 0, 1, 1, 1, 1, 1 };
            List<int> cities5 = new List<int> { 0, 1, 0, 0, 0, 1, 1, 1, 1, 1 };

            //Console.WriteLine(pylons(20, cities));
            //Console.WriteLine(pylons(20, cities));
            //Console.WriteLine(isValid("aaaabbcc"));


            List<int> ranked = new List<int> { 100, 100, 50, 40, 40, 20, 10 };
            List<int> player = new List<int> { 5, 25, 50, 100, 120, 130 };
            //List<int> ranked = new List<int> { 997,981,957,933,930,927,926,920,916,896,887,874,863,863,858,847,815,809,803,794,789,785,783,778,764,755,751,740,737,730,691,677,652,650,587,585,583,568,546,541,540,538,531,527,506,493,457,435,430,427,422,422,414,404,400,394,387,384,374,371,369,369,368,365,363,337,336,328,325,316,314,306,282,277,230,227,212,199,179,173,171,168,136,125,124,95,92,88,85,70,68,61,60,59,44,43,28,23,13,12
            //};
            //List<int> player = new List<int> { 12,20,30,32,35,37,63,72,83,85,96,98,98,118,122,125,129,132,140,144,150,164,184,191,194,198,200,220,228,229,229,236,238,246,259,271,276,281,283,287,300,302,306,307,312,318,321,325,341,341,341,344,349,351,354,356,366,369,370,379,380,380,396,405,408,417,423,429,433,435,438,441,442,444,445,445,452,453,465,466,467,468,469,471,475,482,489,491,492,493,498,500,501,504,506,508,523,529,530,539,543,551,552,556,568,569,571,587,591,601,602,606,607,612,614,619,620,623,625,625,627,638,645,653,661,662,669,670,676,684,689,690,709,709,710,716,724,726,730,731,733,737,744,744,747,757,764,765,765,772,773,774,777,787,794,796,797,802,805,811,814,819,819,829,830,841,842,847,857,857,859,860,866,872,879,882,895,900,900,903,905,915,918,918,922,925,927,928,929,931,934,937,955,960,966,974,982,988,996,996 };
            List<int> leaders = climbingLeaderboard(ranked, player);
            foreach (int i in leaders) { Console.WriteLine(i); }

            List<string> bigSort = new List<string>() { "31415926535897932384626433832795", "1", "3", "10", "3", "5" };
            var bigSorted = bigSorting(bigSort);
            foreach (string i in bigSorted) { Console.WriteLine(i); }



            //string line;
            //string[] inLine;
            //queueWithStacks qws = new queueWithStacks();
            //while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            //{
            //    inLine = line.Split();
            //    if (inLine[0] == "1")
            //    {
            //        qws.enqueue(Convert.ToInt32(inLine[1]));
            //    }
            //    else if (inLine[0] == "2")
            //    {
            //        qws.dequeue();
            //    }
            //    else if (inLine[0] == "3")
            //    {
            //        Console.WriteLine(qws.peek());
            //    }
            //}

            Console.WriteLine(sherlockAndAnagrams("cdcd"));
            Console.WriteLine(superReducedString("aaabccddd"));
            Console.WriteLine(isBalanced("{(([])[])[]}"));
            Console.WriteLine(nextPrime(2));
            Console.WriteLine(nextPrime(6));
            Console.WriteLine(nextPrime(5));
            Console.WriteLine(nextPrime(11));
            Console.WriteLine(nextPrime(23));
            Console.WriteLine(nextPrime(4));

            var waiterList = waiter(new List<int> { 80, 37, 86, 79, 8, 39, 43, 41, 15, 33, 30, 15, 45, 55, 61, 74, 49, 49, 20, 66, 77, 19, 85, 44, 81, 82, 27, 5, 36, 83, 91, 45, 39, 44, 19, 44, 71, 49, 8, 66, 81, 40, 29, 60, 35, 31, 44 }, 21);
            foreach (int i in waiterList) { Console.WriteLine(i); }

            //Console.WriteLine(stockmax(new List<int> { 1,2,100 }));
            //Console.WriteLine(stockmax(new List<int> { 1, 3, 1, 2 }));
            //Console.WriteLine(stockmax(new List<int> { 6,7,10,7,8,9,8,9,8 }));
            //var allLinesText = File.ReadAllLines("C:\\Users\\Ben\\Documents\\hackerrank2-input00.txt").Select(x => x.Split(' ').Select(y => Convert.ToInt32(y)).ToList()).First();
            //Console.WriteLine(stockmax(allLinesText));

            //string line;
            //string[] inLine;
            //string initial = "";
            //Stack<string> undoStk = new Stack<string>();
            //while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            //{
            //    initial = txtOpsSwitch(line, initial, undoStk);
            //}

            //List<string> stringOps = new List<string>();
            //stringOps.Add("1 abc");
            //stringOps.Add("3 3");
            //stringOps.Add("2 3");
            //stringOps.Add("1 xy");
            //stringOps.Add("3 2");
            //stringOps.Add("4");
            //stringOps.Add("4");
            //stringOps.Add("3 1");

            //foreach(string line in stringOps)
            //{
            //    initial = txtOpsSwitch(line, initial, undoStk);
            //}


            //List<int> h1 = new List<int> { 3, 2, 1, 1, 1 };
            //List<int> h2 = new List<int> { 4,3,2 };
            //List<int> h3 = new List<int> { 1,1,4, 1 };
            //equalStacks(h1, h2, h3);

            int coinN = 10;
            List<long> coins = new List<long> { 2, 5, 10 };
            //Console.WriteLine(getWays(coinN, coins));

            Console.WriteLine(alternate("asdcbsdcagfsdbgdfanfghbsfdab"));
            maxSubarray(new List<int> { 1, -1, -1, -1, -1, 5 });

            List<List<int>> pList = new List<List<int>> {
                new List<int>{ 1,5 },
                new List<int>{ 10,3 },
                new List<int>{ 3,4 }
            };
            truckTour(pList);

            //Console.WriteLine(legoBlocks(4, 4));
            Console.WriteLine(Prep3MonthsWk10.legoBlocks(8,10));

            Prep3MonthsWk10.weightedUniformStrings("abccddde",new List<int> { 6,1,3,12,5,9,10 });
            
            //Console.WriteLine(permutationGame(new List<int> { 1,2,3 }));
            Console.WriteLine(Prep3MonthsWk10.permutationGame(new List<int> { 1, 3, 2 }));
            Console.WriteLine(Prep3MonthsWk10.permutationGame(new List<int> { 5, 3, 2, 1, 4 }));
            //Console.WriteLine(permutationGame(new List<int> { 10, 7, 9, 2, 5, 8, 4, 1, 3, 6 }));

            //string line;
            //MinHeap minHeap = new MinHeap();

            //while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            //{
            //    initial = minHeapSwitch(line, initial, minHeap);
            //}
            //List<string> heapOps = new List<string>();
            //heapOps.Add("1 4");
            //heapOps.Add("1 9");
            //heapOps.Add("3");
            //heapOps.Add("2 4");
            //heapOps.Add("3");

            //foreach (string line in heapOps)
            //{
            //    Prep3MonthsWk10.minHeapSwitch(line, minHeap);
            //}

            //Prep3MonthsWk10.largestRectangle(new List<int> { 3,4,2,7,5,6,9 });
            //Prep3MonthsWk10.cookies(7, new List<int> { 1,2,3,9,10,12 });
            //Prep3MonthsWk10.cookies(10, new List<int> { 1,1,1 });
            //Prep3MonthsWk10.cookies(90, new List<int> { 13, 47, 74, 12, 89, 74, 18, 38 });
            //Prep3MonthsWk10.cookies(9, new List<int> { 1,62,14 });
            //Prep3MonthsWk10.cookies(3581, new List<int> { 6214, 8543, 9266, 1150, 7498, 7209, 9398, 1529, 1032, 7384, 6784, 34, 1449, 7598, 8795, 756, 7803, 4112, 298, 4967, 1261, 1724, 4272, 1100, 9373 });
            //Prep3MonthsWk10.cookies(10, new List<int> { 1, 1, 1,1,1,1,1,1,1,1,1 });
            //Prep3MonthsWk10.hackerlandRadioTransmitters(new List<int> { 7, 2, 4, 6, 5, 9, 12, 11 }, 2);
            //Prep3MonthsWk10.hackerlandRadioTransmitters(new List<int> { 2, 2, 2, 2, 1, 1, 1, 1 }, 2);
            //Prep3MonthsWk10.hackerlandRadioTransmitters(new List<int> { 10,10 }, 3);
            //Prep3MonthsWk10.pairs2(2,new List<int> { 1,5,3,4,2 });
            //Prep3MonthsWk10.almostSorted2(new List<int> { 3,1, 2 });
            //Prep3MonthsWk10.almostSorted2(new List<int> { 4, 2 });
            //Prep3MonthsWk10.almostSorted2(new List<int> { 10, 15, 14, 13, 10, 6, 16, 20, 30 });
            //Prep3MonthsWk10.almostSorted(new List<int> { 4104,8529,49984,54956,63034,82534,84473,86411,92941,95929,108831,894947,125082,137123,137276,142534,149840,154703,174744,180537,207563,221088,223069,231982,249517,252211,255192,260283,261543,262406,270616,274600,274709,283838,289532,295589,310856,314991,322201,339198,343271,383392,385869,389367,403468,441925,444543,454300,455366,469896,478627,479055,484516,499114,512738,543943,552836,560153,578730,579688,591631,594436,606033,613146,621500,627475,631582,643754,658309,666435,667186,671190,674741,685292,702340,705383,722375,722776,726812,748441,790023,795574,797416,813164,813248,827778,839998,843708,851728,857147,860454,861956,864994,868755,116375,911042,912634,914500,920825,979477 });
            //Prep3MonthsWk11.solve2(new List<int> { 33, 11, 44, 11, 55 }, new List<int> { 1, 2, 3, 4, 5 });
            //Prep3MonthsWk11.solve2(new List<int> { 2,3,4,5,6 }, new List<int> { 2, 3 });
            //Prep3MonthsWk11.solve4(new List<int> { 33, 11, 44, 11, 55 }, new List<int> { 1,2,3,4,5 });
            //Prep3MonthsWk11.commonChild("SHINCHAN", "NOHARAAA");
            //Prep3MonthsWk11.commonChild("HARRY", "SALLY");
            //Prep3MonthsWk11.commonChild("WEWOUCUIDGCGTRMEZEPXZFEJWISRSBBSYXAYDFEJJDLEBVHHKS", "FDAGCXGKCTKWNECHMRXZWMLRYUCOCZHJRRJBOAJOQJZZVUYXIC");
            //Prep3MonthsWk11.arrayManipulation(5, new List<List<int>>
            //{
            //    new List<int>{ 1,2,100 },
            //    new List<int>{ 2,5,100 },
            //    new List<int>{ 3,4,100 }

            //});
            //Prep3MonthsWk11.highestValuePalindrome("12321", 5, 1);
            //Prep3MonthsWk11.highestValuePalindrome("092282", 6, 3);
            //Prep3MonthsWk11.highestValuePalindrome("3943", 4, 1);
            //Prep3MonthsWk11.highestValuePalindrome("3943", 4, 4);
            //Prep3MonthsWk11.highestValuePalindrome("932239", 6, 2);
            //Prep3MonthsWk11.highestValuePalindrome("11331", 5, 4);
            //Prep3MonthsWk11.lilysHomework(new List<int> { 2, 5, 3, 1 });
            //Prep3MonthsWk11.lilysHomework(new List<int> { 3,4,2,5,1 });

            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.right.right = new TreeNode(6);

            Prep3MonthsWk11.postOrder(root);
            Prep3MonthsWk11.preOrder(root);


            /*****Problem: Tree: Postorder Traversal*****/
            int[] charFreqs = new int[256];
            string test = "Rumpelstiltskin";
            foreach(char c in test.ToCharArray())
            {
                charFreqs[c]++;
            }
            //for(int i = 0; i < test.Length; i++)
            //{
            //    charFreqs[i] = test[i];
            //}
            //foreach (char c in test)
            //{
            //    charFreqs(c) ;
            //}

            // build tree
            Node tree = buildTree(charFreqs);

            // print out results
            printCodes(tree, new StringBuilder());
            StringBuilder s = new StringBuilder();

            for (int i = 0; i < test.Length; i++)
            {
                char c = test[i];
                s.Append(Prep3MonthsWk11.mapA[c]);
            }

            //Decoding d = new Decoding();
            //d.decode(s.toString(), tree);
            Prep3MonthsWk11.decode(s.ToString(), tree);

            /*****END Problem: Tree: Postorder Traversal *****/

            List<List<int>> matrix = new List<List<int>>
            {
                new List<int>{1, 1, 0, 0 },
                new List<int>{0, 1, 1, 0 },
                new List<int>{0, 0, 1, 0 },
                new List<int>{1, 0, 0, 0 }
            };

            List<List<int>> matrix2 = new List<List<int>>
            {
                new List<int>{ 0, 1, 0, 0, 0, 0, 1, 1, 0},
                new List<int>{ 1, 1, 0, 0, 1, 0, 0, 0, 1 },
                new List<int>{ 0, 0, 0, 0, 1, 0, 1, 0, 0 },
                new List<int>{ 0, 1, 1, 1, 0, 1, 0, 1, 1 },
                new List<int>{ 0, 1, 1, 1, 0, 0, 1, 1, 0 },
                new List<int>{ 0, 1, 0, 1, 1, 0, 1, 1, 0 },
                new List<int>{ 0, 1, 0, 0, 1, 1, 0, 1, 1 },
                new List<int>{ 1, 0, 1, 1, 1, 1, 0, 0, 0 }
            };

            Prep3MonthsWk11.connectedCell(matrix2);

            List<List<int>> edges = new List<List<int>>
            {
                new List<int> {1, 2, 3 },
                new List<int> {1, 3, 4 },
                new List<int> {4, 2, 6 },
                new List<int> {5, 2, 2 },
                new List<int> {2, 3, 5 },
                new List<int> {3, 5, 7 },
            };
            //Prep3MonthsWk12.prims(5, edges, 1);

            //Console.WriteLine(Prep3MonthsWk12.beadOrnaments(new List<int> { 2, 1 }));
            //Console.WriteLine(Prep3MonthsWk12.beadOrnaments(new List<int> { 2, 2 }));
            //Console.WriteLine(Prep3MonthsWk12.beadOrnaments(new List<int> { 4 }));
            //Console.WriteLine(Prep3MonthsWk12.beadOrnaments(new List<int> { 3, 1 }));
            //Console.WriteLine(Prep3MonthsWk12.beadOrnaments(new List<int> { 1, 1, 1, 1, 1}));
            //Console.WriteLine(Prep3MonthsWk12.beadOrnaments(new List<int> { 9,10,8 }));
            //Console.WriteLine(Prep3MonthsWk12.beadOrnaments(new List<int> { 30, 28, 22, 27, 22, 30, 26, 30, 21 }));

            List<List<int>> graph = new List<List<int>>
            {
                new List<int>{1, 2, 20},
                new List<int>{1, 3, 50},
                new List<int>{1, 4, 70},
                new List<int>{1, 5, 90},
                new List<int>{2, 3, 30},
                new List<int>{3, 4, 40},
                new List<int>{4, 5, 60}
            };
            //Prep3MonthsWk12.shortestPath(5, graph, new List<List<int>> { new List<int> { 5, 1 } });
            //Prep3MonthsWk12.shortestPath(5, graph, new List<int> { 2, 5 });

            //List<string> words = new List<string> {
            //    "aab",
            //    "defgab",
            //    "abcde",
            //    "aabcde",
            //    "cedaaa",
            //    "bbbbbbbbbb",
            //    "jabjjjad"
            //};
            //Prep3MonthsWk12.noPrefix(words);

            //List<string> words2 = new List<string> {
            //    "aab",
            //    "aac",
            //    "aacghgh",
            //    "aabghgh",
            //};
            //Prep3MonthsWk12.noPrefix(words2);
            List<string> words3 = new List<string> {
                "aab",
                "defgab",
                "abcde",
                "aabcde",
                "cedaaa",
                "bbbbbbbbbb",
                "jabjjjad"
            };
            Prep3MonthsWk12.noPrefix(words3);
            //List<string> words4 = new List<string> {
            //    "aab",
            //    "defgab",
            //    "abcde",
            //    "cedaaa",
            //    "bbbbbbbbbb",
            //    "jabjjjad"
            //};
            //Prep3MonthsWk12.noPrefix(words4);

            /*****Problem: Merging Communities*****/
            //string line = Console.ReadLine();
            //string[] inLine = line.Split();
            //int n = Convert.ToInt32(inLine[0]);
            //UnionFind uf = new UnionFind(n);
            //while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            //{
            //    inLine = line.Split();
            //    if (inLine[0] == "M")
            //    {
            //        int c1 = Convert.ToInt32(inLine[1]);
            //        int c2 = Convert.ToInt32(inLine[2]);

            //        uf.Union(c1, c2);
            //    }
            //    else if (inLine[0] == "Q")
            //    {
            //        int c = Convert.ToInt32(inLine[1]);
            //        int cInd = uf.Find(c);
            //        Console.WriteLine(uf.size[cInd]);
            //    }
            //}
            /*****END Problem: Merging Communities*****/


            //List<List<int>> edges2 = new List<List<int>>
            //{
            //    new List<int> {1, 6 },
            //    new List<int> {2, 7 },
            //    new List<int> {3, 8 },
            //    new List<int> {4, 9 },
            //    new List<int> {2, 6 },
            //};
            //Prep3MonthsWk12.componentsInGraph(edges2);
            //List<List<int>> edges2 = new List<List<int>>
            //{
            //    new List<int> {1, 17 },
            //    new List<int> {5, 13 },
            //    new List<int> {7, 12 },
            //    new List<int> {5, 17 },
            //    new List<int> {5, 12 },
            //    new List<int> {2, 17 },
            //    new List<int> {1, 18 },
            //    new List<int> {8, 13 },
            //    new List<int> {2, 15 },
            //    new List<int> {5, 20 },
            //};
            //Prep3MonthsWk12.componentsInGraph(edges2);

            List<List<int>> edges2 = new List<List<int>>
            {
                new List<int> {1, 2 },
                new List<int> {1, 3 },
            };
            Prep3MonthsWk12.bfs(4, 2, edges2, 1);
            List<List<int>> edges3 = new List<List<int>>
            {
                new List<int> {2, 3 },
            };
            Prep3MonthsWk12.bfs(3, 1, edges3, 2);


            








            Console.WriteLine("Hello, World!");
        }                    
               
               
        public static int truckTour(List<List<int>> petrolpumps)
        {
            int fuel = 0;
            int pump = 0;

            for(int i  = 0; i <  petrolpumps.Count; i++)
            {
                fuel += petrolpumps[i][0] - petrolpumps[i][1];
                if(fuel <= 0)
                {
                    fuel = 0;
                    pump = i + 1;
                }
            }

            return pump;

            //int cnt = 0;
            //int i = 0;
            //while (cnt <= petrolpumps.Count)
            //{
            //    fuel = fuel + petrolpumps[i][0] - petrolpumps[i][1];
            //    if (fuel < 0)
            //    {
            //        fuel = 0;
            //        cnt = 0;
            //    }
            //    else
            //    {
            //        cnt++;
            //    }

            //    if (i < petrolpumps.Count-1)
            //    {
            //        i++;
            //    }
            //    else 
            //    { 
            //        i = 0;
            //    }
            //}

            //return i-1;            
        }

        public static int chiefHopper(List<int> arr)
        {
            int energy = 0;
            for (int i = arr.Count - 1; i >= 0; i--)
            {
                energy = (energy + arr[i] + 1) / 2;

            }
            return energy;
        }

        public static List<int> maxSubarray(List<int> arr)
        {
            int max = arr.Max();
            List<int> retVal = new List<int> { max, max };
            int sumSub = 0;
            foreach(int a in arr)
            {
                sumSub = Math.Max(a, sumSub + a);                
                max = Math.Max(sumSub, max);                
            }

            retVal[0] = max;

            int sum = 0;
            List<int> subSeq = arr.Where(n => n > 0).ToList();
            if(subSeq.Count > 0)
            {
                max = subSeq.Sum();
            }
            else
            {
                max = arr.Max();
            }

            retVal[1] = max;
            return retVal;
        }

        public static int alternate(string s)
        {
            char[] chars = s.Distinct().ToArray();
            char[] charStr = s.ToCharArray();
            
            int max = 0;
            bool isAlternating = true;
            char[] tst;
            for (int i = 0; i < chars.Length; i++)
            {
                for(int j = i+1; j < chars.Length; j++)
                {
                    tst = charStr.Where(c => c == chars[i] || c == chars[j]).ToArray();
                    isAlternating = true;
                    int k = 0;
                    while (isAlternating && k < tst.Length-1)
                    {                        
                        if (tst[k] == tst[k + 1])
                        {
                            isAlternating = false;
                        }
                        k++;                        
                    }

                    if (isAlternating && max < tst.Length)
                    {
                        max = tst.Length;
                    };
                }                
            }
            return max;
        }

        public static long getWays(int n, List<long> c)
        {
            long[] ways = new long[n+1];
            ways[0] = 1;

            for (int i = 0; i < c.Count; i++)
            { 
                for(int j = 0; j < n+1; j++)
                {
                    if (c[i] <= j)
                    {
                        ways[j] += ways[(int)(j - c[i])];
                    }
                }
            }

            return ways[n];            
        }

        public static int equalStacks(List<int> h1, List<int> h2, List<int> h3)
        {
            Stack<int> Stk1 = new Stack<int>();
            Stack<int> Stk2 = new Stack<int>();
            Stack<int> Stk3 = new Stack<int>();
            int sum1 = 0;
            int sum2 = 0;
            int sum3 = 0;
            for (int i = h1.Count-1; i >= 0; i--)
            {
                Stk1.Push(h1[i]);
                sum1 += h1[i];
            }

            for (int i = h2.Count - 1; i >= 0; i--)
            {
                Stk2.Push(h2[i]);
                sum2 += h2[i];
            }

            for (int i = h3.Count - 1; i >= 0; i--)
            {
                Stk3.Push(h3[i]);
                sum3 += h3[i];
            }

            
            while (Stk1.Count > 0 && Stk2.Count > 0 && Stk3.Count > 0)
            {
                int minSum = Math.Min(sum1, Math.Min(sum2, sum3));
                while (sum1 > minSum)
                {
                    sum1 -= Stk1.Pop();
                }

                while (sum2 > minSum)
                {
                    sum2 -= Stk2.Pop();
                }

                while (sum3 > minSum)
                {
                    sum3 -= Stk3.Pop();
                }

                if (sum1 == sum2 && sum2 == sum3)
                {
                    return sum1;
                }
            }

            return 0;
        }


        public static string txtOpsSwitch(string line, string initial, Stack<string> undoStk)
        {
            StringBuilder sb = new StringBuilder(initial);
            string[] inLine = line.Split();
            switch (Convert.ToInt32(inLine[0]))
            {
                case 1:
                    undoStk.Push(sb.ToString());
                    sb.Append(inLine[1]);   
                    break;
                case 2:
                    undoStk.Push(sb.ToString());
                    int remLength = Convert.ToInt32(inLine[1]);
                    sb.Remove(sb.Length - remLength, remLength);                    
                    break;
                case 3:
                    Console.WriteLine(sb[Convert.ToInt32(inLine[1])-1]);
                    break;
                case 4:
                    sb = new StringBuilder(undoStk.Pop());
                    break;
            }
            return sb.ToString();
        }

        public static long stockmax(List<int> prices)
        {          
            long maxProfit = 0;
            int maxIdx = 0;
            while (prices.Count > 0 ) 
            {                 
                int max = prices.Max();
                maxIdx = prices.IndexOf(max);
                int shareCnt = 0;
                for (int i = 0; i < maxIdx; i++)
                {
                    maxProfit -= prices[i];
                    shareCnt++;
                }
                maxProfit += shareCnt * (long)prices[maxIdx];
                
                prices = prices.Slice(maxIdx + 1, prices.Count-1 - maxIdx);                               
            }          

            //long maxProfit = 0;
            //int maxFuturePrice = 0;

            //for (int i = prices.Count - 1; i >= 0; i--)
            //{
            //    if (prices[i] > maxFuturePrice)
            //    {
            //        maxFuturePrice = prices[i];
            //    }
            //    maxProfit += maxFuturePrice - prices[i];
            //}

                return maxProfit;
        }

        public static int nextPrime(int n)
        {
            if (n < 2) 
            { 
                return 2;
            }

            if (n == 2)
            {
                return 3;
            }

            bool found = false;            
            while (!found && n < 2*n) 
            {
                if(isPrime(n += 1))
                {
                    found = true;
                }
            }             
            
            return n;
        }

        public static bool isPrime(int n)
        {
            if (n % 2 == 0 || n % 3 == 0)
            { 
                return false;
            }

            // To check through all numbers of the form 6k ± 1 
            for (int i = 5; i * i <= n; i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                { 
                    return false;
                }
            }

            return true;
        }        

        public static List<int> waiter(List<int> number, int q)
        {
            List<int> primes = [2];
            for (int i = 1; i < q; i++)
            {                
                primes.Add(nextPrime(primes[i - 1]));                
            }

            Stack<int> numStk = new Stack<int>();
            foreach (int n in number)
            {
                numStk.Push(n);
            }
            
            List<int> aLst = new List<int>();
            Stack<int> bStk = new Stack<int>();
            List<int> answers = new List<int>() { };
            int cnt = numStk.Count;
            for (int i = 0; i < q; i++) 
            {                
                for (int j = 0; j < cnt; j++)
                {
                    if (numStk.Peek() % primes[i] == 0)
                    {
                        bStk.Push(numStk.Pop());
                    }
                    else 
                    {
                        aLst.Add(numStk.Pop());
                    }                    
                }
                while (bStk.Count > 0)
                {
                    answers.Add(bStk.Pop());
                }
                for(int k = 0; k < aLst.Count; k++) 
                {
                    numStk.Push(aLst[k]);
                }
                aLst.Clear();
                cnt = numStk.Count;
            }

            while (numStk.Count > 0)
            {
                answers.Add(numStk.Pop());
            }

            return answers;
        }

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

        public static string isBalanced(string s)
        {
            if(s.Length % 2 > 0)
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
                if(charStk.Count > 0 && keyValues[charStk.Peek()] == s[i])
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

            //int i = 0;
            //while (s.Length > 0 && i < s.Length-1)
            //{
            //    if (s[i] == s[i + 1])
            //    {
            //        s = s.Remove(i, 2);
            //        i = 0;
            //        continue;
            //    }
            //    i++;
            //}

            return s.Length > 0 ? s : "Empty String";
        }

        public static int sherlockAndAnagrams(string s)
        {
            int cnt = 0;
            Dictionary<string, int> map = new Dictionary<string, int>();
            for(int i = 0; i < s.Length; i++)
            {
                for(int j = i+1; j <= s.Length; j++)
                {
                    char[] charArr = s.Substring(i, j-i).ToCharArray();
                    Array.Sort(charArr);
                    string subStr = new string(charArr);

                    if (map.ContainsKey(subStr)){
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

        public static List<int> icecreamParlor(int m, List<int> arr)
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
            for (int i = 0; i < dic.Count; i++)
            {
                for(int j = i+1; j < dic.Count; j++)
                {
                    if (dic[i] + dic[j] == m)
                    {
                        retList.AddRange(new List<int>{ dic[i] +1, j+1 });
                        break;
                    }
                }
            }
            return retList;
        }

        static bool hasCycle(SinglyLinkedListNode head)
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

        static SinglyLinkedListNode mergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            SinglyLinkedListNode retList = null;
            SinglyLinkedListNode head = null;
            if (head1.data <= head2.data)
            {
                retList = head1;
            }
            else
            {
                retList = head2;
            }
            head = retList;

            while (head1 != null && head2 != null)
            {
                if(head1.data < head2.data)
                {
                    retList.next = head1;
                    retList = head1;
                    head1 = head1.next;
                }
                else if(head1.data == head2.data)
                {
                    retList.next = head1;
                    retList = head1;
                    retList.next = head2;
                    retList = head2;
                    head1 = head1.next;
                    head2 = head2.next;
                }
                else
                {
                    retList = head2;
                    head2 = head2.next;
                }
            }            
            return head;
        }

        public static List<string> bigSorting(List<string> unsorted)
        {
            var sorted = unsorted.OrderBy(s => s.Length).GroupBy(g => g.Length).Select(g => g.Order()).SelectMany(g => g).ToList();
            return sorted;
        }

        static SinglyLinkedListNode insertNodeAtPosition(SinglyLinkedListNode llist, int data, int position)
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(data);
            SinglyLinkedListNode temp = llist;
            SinglyLinkedListNode head = llist;
            for(int i = 0; i < position-1; i++)
            {                
                llist = llist.next;
            }
            temp = llist.next;
            llist.next = newNode;
            newNode.next = temp;

            return head;
        }
        
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
        
        public static SinglyLinkedListNode reverse(SinglyLinkedListNode llist)
        {
            SinglyLinkedListNode current = llist;
            SinglyLinkedListNode prev = null;
            SinglyLinkedListNode next = null;

            while(current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
            }
            Console.WriteLine(current.data);
            return llist;
        }

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
                else if(i > 0)
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

        public static string isValid(string s)
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
            else
            {
                return "NO";
            }
        }


        public static int pylons(int k, List<int> arr)
        {
            int minNum = 0;
            int i = k - 1;                       
            
            while (i < arr.Count)
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

            if (i < arr.Count + k - 1)
            {
                minNum++;
            }

            return minNum;
        }

        public static int getNextCity(List<int> arr, int start, int k)
        {
            return 0;
        }


        public static void minimumBribes(List<int> q)
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
            //bool chaotic = false;
            //for (int i = 0; i < q.Count; i++)
            //{
            //    if (q[i] - (i + 1) > 2)
            //    {
            //        chaotic = true;
            //    }
            //    for (int j = Math.Max(0,q[i]-2); j < i; j++)
            //    {                   
            //        if (q[j] > q[i])
            //        {
            //            b++;
            //        }
            //    }
            //}
            //if (chaotic)
            //{
            //    Console.WriteLine("Too chaotic");
            //    return;
            //}
            //else
            //{
            //    Console.WriteLine(b);
            //}

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
                if (q[i] != i+1)
                {
                    Console.WriteLine("Too chaotic");
                    return;
                }
            }
            //q.ForEach(x => Console.WriteLine(x));
            Console.WriteLine(b);
        }

        public static List<int> swap(List<int> q, int x, int y)
        {
            int temp = q[x];
            q[x] = q[y];
            q[y] = temp;
            return q;
        }

        public static int palindromeIndex(string s)
        {
            int b = s.Count() - 1;
            int retVal = -1;
            for (int f = 0; f < s.Count() / 2; f++)
            {
                if (s[f] == s[b])
                {
                    b--;
                }
                else
                {
                    if (s[f] == s[b - 1])
                    {
                        retVal = b;
                    }
                    else
                    {
                        retVal = f;
                    }
                }
            }
            return retVal;
        }

        public static int superDigit(string n, int k)
        {
            if (n.Length == 1)
            {
                return Convert.ToInt32(n);
            }

            int p = 0;
            for (int i = 0; i < n.Length; i++)
            {
                p += Convert.ToInt32(n[i]);
            }
            p *= k;

            string pStr = p.ToString();
            int sup = 0;
            ////while(sup.ToString().Length > 1){
            for (int i = 0; i < pStr.Length; i++)
            {
                sup += Convert.ToInt32(pStr[i]);
            }
            //}



            return sup;
        }

        public static BigInteger fibonacciModified(int t1, int t2, int n)
        {
            BigInteger p1 = (BigInteger)t1;
            BigInteger p2 = (BigInteger)t2;
            BigInteger c = p1 + (p2 * p2);           

            for (int i = 3; i < n; i++)
            {
                c = p2 + (c * c);
                p2 = c;                
            }

            return c;
        }

        public static int sansaXor(List<int> arr)
        {
            if(arr.Count%2 == 0)
            {
                return 0;
            }
            int retVal = arr[0] ^ arr[1];
            for (int i = 1; i < arr.Count; i++)
            {
                if (i % 2 == 0)
                {
                    retVal ^= arr[i];
                }
                
            }
            return retVal;
        }


        public static string gridChallenge(List<string> grid)
        {
            var sGrid = new List<List<char>>();
            foreach(string s in grid)
            {
                sGrid.Add(new List<char>(s.Order()));
            }

            for(int i = 0; i < sGrid.Count; i++)
            {
                for(int j = 0; j < sGrid.Count-1 ; j++)
                {                    
                    if (sGrid[i][j] > sGrid[i+1][j]){
                        return "NO";
                    }
                }               
            }
            return "YES";
        }

        public static void countSort(List<List<string>> arr)
        {
            int n = arr.Count;
            int max = 0;
            for (int i = 0; i < n; i++)
            {
                if (i < n / 2)
                {
                    arr[i][1] = "-";
                }
                if (max < Convert.ToInt32(arr[i][0]))
                {
                    max = Convert.ToInt32(arr[i][0]);
                }
            }

            List<List<string>> retList = new List<List<string>>();
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < max + 1; j++)
            {
                IEnumerable<List<string>> l = arr.Where(a => a[0] == j.ToString());
                foreach (var item in arr.Where(a => a[0] == j.ToString()))
                {
                    sb.Append(item[0] + " ");
                    Console.Write("{0} ", item[0]);
                }
                ////retList.Add(new List<string>());
                //for (int k = 0; k < arr.Count; k++)
                //{
                //    if (Convert.ToInt32(arr[k][0]) == j)
                //    {
                //        //retList[j].Add(arr[k][1]);
                //        Console.Write(arr[k][1] + " ");
                //    }
                //}
            }
        }

        public static List<int> missingNumbers(List<int> arr, List<int> brr)
        {
            arr.Sort();
            brr.Sort();
            //int m = brr.Count() - arr.Count;
            int dif = 0;
            List<int> result = new List<int>();
            int j = 0;

            for(int i = 0; i < brr.Count; i++)
            {
                if (arr[j] == brr[i])
                {
                    j++; 
                }
                else
                {
                    result.Add(brr[i]);
                }
            }



            Dictionary<int, int> dic1 = new Dictionary<int, int>();
            Dictionary<int, int> dic2 = new Dictionary<int, int>();            

            foreach (int b in brr.Distinct())
            {
                dic2.Add(b, brr.Where(r => r == b).Count());
                dic1.Add(b, arr.Where(r => r == b).Count());
            }


            for(int i = 0; i < dic2.Count(); i++)
            {
                dif = dic2.ElementAt(i).Value - dic1.ElementAt(i).Value;
                if (dif > 0)
                {
                    result.Add(dic1.ElementAt(i).Key);
                }
            }
            

            //foreach (int b in brr) {
            //    dif = brr.Where(br => br == b).Count() - arr.Where(ar => ar == b).Count();
            //    if (dif > 0 && !result.Contains(b)) {
            //        for(int i = 0; i < dif; i++) {
            //            result.Add(b);
            //        }
            //        cnt++;
            //    }
            //    if(cnt == m)
            //    {
            //        break;
            //    }
            //}

            return result; 

        }


        public static List<int> dynamicArray(int n, List<List<int>> queries)
        {
            int lastAnswer = 0;
            List<int> answers = new List<int>();
            var arr = Enumerable.Range(0, n).Select(_ => new List<int>()).ToList();

            //List<List<int>> arr = new List<List<int>>(new List<int>[n]);
            int idx = 0;
            foreach (List<int> q in queries)
            {
                idx = (q[1] ^ lastAnswer) % 2;
                if (q[0] == 1)
                {
                    //arr[idx] = new List<int> { q[2] };
                    arr[idx].Add(q[2]);
                }
                else if (q[0] == 2)
                {
                    lastAnswer = arr[idx][q[2] % arr[idx].Count()];
                    answers.Add(lastAnswer);
                }
            }
            return answers;
        }

        public static int minimumNumber(int n, string password)
        {
            // Return the minimum number of characters to make the password strong
            //int chars = 0;
            //if (n < 6)
            //{
            //    chars = 6 - n;
            //}

            //if (password.Any(c => char.IsUpper(c)))
            //{
            //    chars++;
            //}

            //if (password.Any(c => char.IsLower(c)))
            //{
            //    chars++;
            //}

            //if (password.Any(c => !char.IsLetterOrDigit(c)))
            //{
            //    chars++;
            //}

            //bool hasUpper = false;
            //bool hasLower = false;
            //bool hasSpecial = password.Any(c => !char.IsLetterOrDigit(c));
            //foreach (char c in password)
            //{
            //    if (char.IsUpper(c))
            //    {
            //        hasUpper = true;
            //    }

            //    if (char.IsLower(c))
            //    {
            //        hasLower = true;
            //    }
            //    if (char.IsDigit(c))
            //    {
            //        hasLower = true;
            //    }
            //}

            //if (hasUpper) { chars++; }
            //if (hasLower) { chars++; }

            //return chars;

            int chars = 0;
            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;
            bool hasSpecial = false;
            string spChars = "!@#$%^&*()-+";

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    hasUpper = true;
                }

                if (char.IsLower(c))
                {
                    hasLower = true;
                }

                if (char.IsDigit(c))
                {
                    hasDigit = true;
                }

                if (spChars.Contains(c))
                {
                    hasSpecial = true;
                }
            }

            if (!hasUpper) { chars++; }
            if (!hasLower) { chars++; }
            if (!hasSpecial) { chars++; }
            if (!hasDigit) { chars++; }

            if (n + chars < 6)
            {
                chars = 6 - n;
            }
            return chars;


        }

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

        public static string caesarCipher(string s, int k)
        {
            string encStr = "";
            foreach (char c in s)
            {
                if (char.IsLetter(c))
                {
                    if (c + k > 'z')
                    {
                        //char x = 'z' - (c + k);
                        var xtra = 'z' - c + k;
                        encStr += Convert.ToChar('`' + xtra);
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

        public static void separateNumbers(string s)
        {
            // s.length/2 because if split after half then
            // the 2nd number can not be consecutive
            for (int i = 1; i < (s.Length+1 / 2)+1; i++)
            {
                //Substring(startIndex, length)
                var numStr = s.Substring(0, i);
                var num = long.Parse(numStr);

                while (numStr.Length < s.Length)
                {
                    num++;
                    numStr += num.ToString();
                }

                //Console.WriteLine(numStr);
                if (numStr == s)
                {
                    Console.WriteLine($"YES {s.Substring(0, i)}");
                    return;
                }
            }

            Console.WriteLine("NO");
        }

        public static int lonelyinteger(List<int> a)
        {
            // Write your code here
            int x = 0;
            for (int i = 0; i < a.Count; i++)
            {
                x = x ^ a[i];
            }
            return x;
        }

        public static List<int> countingSort(List<int> arr)
        {
            List<int> freqs = new List<int>(new int[100]);
            for (int i = 0; i < arr.Count; i++)
            {
                freqs[arr[i]] += 1;
            }
            return freqs;
        }
    }
}
