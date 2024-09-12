using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Quic;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
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
            //List<string> words3 = new List<string> {
            //    "aab",
            //    "defgab",
            //    "abcde",
            //    "aabcde",
            //    "cedaaa",
            //    "bbbbbbbbbb",
            //    "jabjjjad"
            //};
            //Prep3MonthsWk12.noPrefix(words3);
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

            //List<List<int>> edges2 = new List<List<int>>
            //{
            //    new List<int> {1, 2 },
            //    new List<int> {1, 3 },
            //};
            //Prep3MonthsWk12.bfs(4, 2, edges2, 1);
            //List<List<int>> edges3 = new List<List<int>>
            //{
            //    new List<int> {2, 3 },
            //};
            //Prep3MonthsWk12.bfs(3, 1, edges3, 2);


            //Prep3MonthsWk13.runningMedian(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });


            //List<List<string>> strList = new List<List<string>> {
            //    new List<string> { "add", "hack" },
            //    new List<string> { "add", "hackerrank" },
            //    new List<string> { "find", "hac" },
            //    new List<string> { "find", "hak" }
            //};

            //Prep3MonthsWk13.contacts(strList);
            //List<List<string>> strList2 = new List<List<string>> {
            //    new List<string> { "add", "s" },
            //    new List<string> { "add", "ss" },
            //    new List<string> { "add", "sss" },
            //    new List<string> { "add", "ssss" },
            //    new List<string> { "add", "sssss" },
            //    new List<string> { "find", "s" },
            //    new List<string> { "find", "ss" },
            //    new List<string> { "find", "sss" },
            //    new List<string> { "find", "ssss" },
            //    new List<string> { "find", "sssss" },
            //    new List<string> { "find", "ssssss" }
            //};
            //Prep3MonthsWk13.contacts(strList2);

            //List<List<int>> c2 = new List<List<int>>
            //{
            //    new List<int>{1,2 },
            //    new List<int>{3,1 },
            //    new List<int>{2,3 },
            //};
            //Prep3MonthsWk13.roadsAndLibraries(3, 2, 1, c2);
            //List<List<int>> c3 = new List<List<int>>
            //{
            //    new List<int>{1,2 },
            //    new List<int>{1,3 },
            //    new List<int>{1,4 },
            //};
            //Prep3MonthsWk13.roadsAndLibraries(5, 6, 1, c3);


            //List<List<int>> astros = new List<List<int>> {
            //    new List<int> {0,1},
            //    new List<int> {2,3},
            //    new List<int> {0,4},
            //};
            //Prep3MonthsWk13.journeyToMoon(5, astros);
            //List<List<int>> astros2 = new List<List<int>> {
            //    new List<int> {0,2},
            //};
            //Prep3MonthsWk13.journeyToMoon(4, astros2);
            //List<List<int>> astros3 = new List<List<int>> {
            //    new List<int> {1,2},
            //    new List<int> {3,4},
            //};
            //Prep3MonthsWk13.journeyToMoon(100000, astros3);


            //Prep3MonthsWk13.hanoi(new List<int> { 1, 4, 1 });
            //Prep3MonthsWk13.hanoi(new List<int> { 1, 3, 3 });

            //List<string> strList = new List<string>
            //{
            //    "UPDATE 2 2 2 4",
            //    "QUERY 1 1 1 3 3 3",
            //    "UPDATE 1 1 1 23",
            //    "QUERY 2 2 2 4 4 4",
            //    "QUERY 1 1 1 3 3 3"
            //};
            //Prep3MonthsWk13.cubeSum(4,strList);

            //List<int> trainT = new List<int>
            //{
            //    1,3,1,4,2
            //};
            //List<int> trainF = new List<int>
            //{
            //    2,5,4,5,3
            //};
            //List<int> trainW = new List<int>
            //{
            //    60,70,120,150,80
            //};
            //Prep3MonthsWk13.getCost(5, trainT, trainF, trainW);

            //List<int> trainT = new List<int>
            //{
            //    1,2,3,4,1,3
            //};
            //List<int> trainF = new List<int>
            //{
            //    2,3,4,5,3,5
            //};
            //List<int> trainW = new List<int>
            //{
            //    30,50,70,90,70,85
            //};
            //Prep3MonthsWk13.getCost(5, trainT, trainF, trainW);

            //Prep3MonthsWk13.shortPalindrome("ghhggh");

            List<int> ctData = new List<int>
            {
                100, 200, 100, 500, 100, 600
            };
            List<List<int>> ctEdges = new List<List<int>>
            {
                new List<int>{1,2},
                new List<int>{2,3},
                new List<int>{2,5},
                new List<int>{4,5},
                new List<int>{5,6},
            };
            Prep3MonthsWk13.cutTheTree(ctData, ctEdges);
            List<int> ctData2 = new List<int>
            {
                205, 573, 985, 242, 830, 514, 592, 263, 142, 915
            };
            List<List<int>> ctEdges2 = new List<List<int>>
            {
                new List<int>{2,8},
                new List<int>{10, 5},
                new List<int>{1, 7},
                new List<int>{6, 9},
                new List<int>{4, 3},
                new List<int>{8, 10},
                new List<int>{5, 1},
                new List<int>{7, 6},
                new List<int>{9, 4},
            };
            Prep3MonthsWk13.cutTheTree(ctData2, ctEdges2);

            Console.WriteLine("Hello, World!");
        }                    
        

        public static int getNextCity(List<int> arr, int start, int k)
        {
            return 0;
        }


        

        public static List<int> swap(List<int> q, int x, int y)
        {
            int temp = q[x];
            q[x] = q[y];
            q[y] = temp;
            return q;
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
