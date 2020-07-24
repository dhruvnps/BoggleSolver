using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace BoggleSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> wordlist = new List<string>();
            wordlist = File.ReadAllLines("wordlist.txt").ToList();
            var trie = Trie.BuildTrie(wordlist);

            /*char[,] board = {
                { 'A', 'N', 'T', 'Y' },
                { 'U', 'D', 'E', 'B' },
                { 'S', 'M', 'N', 'R' },
                { 'O', 'S', 'I', 'T' }
            };*/

            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 100; i++)
            {
                // sw.Restart();
                RunSolver(Board.RandomBoardArray(), trie);
                // sw.Stop();
                // Console.WriteLine(sw.Elapsed.Ticks / 10 + " μs");
            }
            Console.WriteLine(sw.Elapsed.Ticks / 1000 + " μs");
        }

        static void RunSolver(char[,] board, Trie trie)
        {
            var solver = new Solver(board, trie);
            var found = solver.FindWordsWithPath();
            var words = new List<string>(found.Keys);
            var paths = new List<List<int>>(found.Values);
            var scores = new List<int>(found.Keys.Select(i => (int)Math.Pow(2, i.Length - 2)));
            /*for (int i = 0; i < words.Count; i++)
            {
                Console.Write(words[i] + ", ");
                foreach (int node in paths[i])
                {
                    Console.Write(node.ToString("X"));
                }
                Console.WriteLine(", " + scores[i]);
            }
            Board.Print2DArray(solver._board);*/
            // Console.WriteLine(scores.Sum());
        }
    }
}
