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

        private List<Point> GetNeighbours(Point point)
        {
            var neighbours = new List<Point>();
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

        private void DFS(Point point, List<int> visited, Dictionary<string, List<int>> found, string prefix)
        {
            visited.Add(Board.PointToInt(point));
            prefix += _board[point.row, point.col];
            if (_trie.ContainsPrefix(prefix))
            {
                if (_trie.ContainsWord(prefix))
                {
                    found[prefix] = visited.Take(visited.Count).ToList();
                }
                List<Point> neighbours = GetNeighbours(point);
                foreach (Point neigh in neighbours)
                {
                    if (!visited.Contains(Board.PointToInt(neigh)))
                    {
                        DFS(neigh, visited, found, prefix);
                    }
                }
            }
            visited.Remove(Board.PointToInt(point));
        }

        public Dictionary<string, List<int>> FindWordsWithPath()
        {
            var found = new Dictionary<string, List<int>>();
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    DFS(new Point(row, col), new List<int>(), found, "");
                }
            }
            var orderedFound = found.OrderBy(i => i.Key.Length);
            return orderedFound.ToDictionary(i => i.Key, i => i.Value);
        }
    }
}
