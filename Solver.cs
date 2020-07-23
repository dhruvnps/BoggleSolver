using System;
using System.Collections.Generic;
using System.Linq;

namespace BoggleSolver
{
    public class Solver
    {
        public readonly char[,] _board;
        public readonly Trie _trie;

        public Solver(char[,] board, Trie trie)
        {
            _board = board;
            _trie = trie;
        }

        private readonly List<Point> _neighboursDelta = new List<Point>
        {
            new Point(-1, -1),  new Point(-1, 0),   new Point(-1, 1),
            new Point(0,  -1),  /*   origin   */    new Point(0,  1),
            new Point(1,  -1),  new Point(1,  0),   new Point(1,  1),
        };

        public List<Point> GetNeighbours(Point point)
        {
            List<Point> neighbours = new List<Point>();
            foreach (Point delta in _neighboursDelta)
            {
                Point neigh = new Point(
                    delta.row + point.row,
                    delta.col + point.col
                );
                if (neigh.row < 4 && neigh.col < 4 && neigh.row >= 0 && neigh.col >= 0)
                {
                    neighbours.Add(neigh);
                }
            }
            return neighbours;
        }

        private void DFS(Point point, HashSet<int> visited, HashSet<string> wordsFound, string prefix)
        {
            if (visited.Contains(Board.PointToInt(point)))
            {
                return;
            }
            visited.Add(Board.PointToInt(point));
            prefix += _board[point.row, point.col];
            if (_trie.ContainsPrefix(prefix))
            {
                if (_trie.ContainsWord(prefix))
                {
                    wordsFound.Add(prefix);
                }

                List<Point> neighbours = GetNeighbours(point);
                foreach (Point neigh in neighbours)
                {
                    DFS(neigh, visited, wordsFound, prefix);
                }
            }
            visited.Remove(Board.PointToInt(point));
        }

        public List<string> FindWords()
        {
            HashSet<string> wordsFound = new HashSet<string>();
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    DFS(new Point(row, col), new HashSet<int>(), wordsFound, "");
                }
            }
            return wordsFound.ToList();
        }
    }
}
