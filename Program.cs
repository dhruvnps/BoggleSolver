using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace BoggleSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> words = new List<string>();
            words = File.ReadAllLines("words.txt").ToList();

            // char[,] board = Board.RandomBoardArray();
            char[,] board = {
                { 'A', 'N', 'T', 'Y' },
                { 'U', 'D', 'E', 'B' },
                { 'S', 'M', 'N', 'R' },
                { 'O', 'S', 'I', 'T' }
            };

            Trie trie = Trie.BuildTrie(words);
            Solver solver = new Solver(board, trie);

            int score = 0;
            List<string> wordsFound = solver.FindWords();
            wordsFound = wordsFound.OrderBy(i => i.Length).ToList();
            foreach (string word in wordsFound)
            {
                int scoreBonus = (int)Math.Pow(2, word.Length - 2);
                score += scoreBonus;
                Console.Write(scoreBonus + " --> ");
                Console.WriteLine(word);
            }
            Board.Print2DArray(solver._board);
            Console.WriteLine(score + "\n");
        }
    }
}
