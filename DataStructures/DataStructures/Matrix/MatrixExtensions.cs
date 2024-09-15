using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresExercises.Matrix
{
    internal static class MatrixExtensions
    {
        internal record Point(int x,int y);
        internal static bool SearchWordDFS(this char[][] board, string word)
        {
            bool result = false;
            Stack<List<Point>> stack = new Stack<List<Point>>();
            for (int i=0; i < board.GetLength(1); i++)
            {
                var str = board[i];
                int fromIndex = Array.IndexOf(str, word[0], 0);
                while (fromIndex!=-1)
                {
                    stack.Push(new List<Point>() { new Point(fromIndex,i)});
                    fromIndex = Array.IndexOf(str, word[0], fromIndex);
                }
            }
                        
            int matchWordPosition = 1;
            while (stack.TryPop(out List<Point> trackPositions))
            {
                var adjacentPositions = board.GetAdjacentNeighbor(trackPositions[trackPositions.Count-1]);
                foreach (var position in adjacentPositions)
                {
                    if (board[position.x][position.y] == word[matchWordPosition] && !trackPositions.Contains(position))
                    {
                        trackPositions.Add(position);
                        stack.Push(trackPositions);
                    }
                }
                if (trackPositions.Count == word.Length)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        internal static IEnumerable<Point> GetAdjacentNeighbor(this char[][] board, Point fromPoition)
        {            
            if (fromPoition.x >= 1 )
            {
                yield return new Point(fromPoition.x - 1, fromPoition.y);
            }
            if (fromPoition.y >= 1)
            {
                yield return new Point(fromPoition.x, fromPoition.y-1);
            }
            if (fromPoition.x <= board.GetLength(0) - 1)
            {
                yield return new Point(fromPoition.x + 1, fromPoition.y);
            }
            if (fromPoition.y >= board.GetLength(1) - 1)
            {
                yield return new Point(fromPoition.x, fromPoition.y + 1);
            }            
        }
    }
}
