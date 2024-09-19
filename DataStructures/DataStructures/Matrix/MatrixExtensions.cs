using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresExercises.Matrix
{
    public static class MatrixExtensions
    {
        internal record Point(int x,int y);
        public static bool SearchWordDFS(this char[][] board, string word)
        {
            bool result = false;
            Stack<List<Point>> stack = new Stack<List<Point>>();
            for (int i= board.Length-1; i >= 0; i--)
            {
                var str = board[i];
                int fromIndex = Array.IndexOf(str, word[0], 0);
                while (fromIndex!=-1)
                {
                    stack.Push(new List<Point>() { new Point(i,fromIndex)});
                    fromIndex = Array.IndexOf(str, word[0], fromIndex+1);
                }
            }
            result = word.Length == stack.Count;       
            
            while (!result && stack.TryPop(out List<Point> trackPositions))
            {
                var currentPosition = trackPositions[trackPositions.Count - 1];
                var adjacentPositions = board.GetAdjacentNeighbor(currentPosition);
                foreach (var position in adjacentPositions)
                {
                    if (board[position.x][position.y] == word[trackPositions.Count] && !trackPositions.Contains(position))
                    {
                        trackPositions.Add(position);
                        stack.Push(trackPositions);
                        if (trackPositions.Count == word.Length)
                        {
                            result = true;
                            break;
                        }
                        trackPositions = new List<Point>(trackPositions[..(trackPositions.Count-1)]);
                    }
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
            if (fromPoition.x < board.Length - 1)
            {
                yield return new Point(fromPoition.x + 1, fromPoition.y);
            }
            if (fromPoition.y < board[fromPoition.x].Length - 1)
            {
                yield return new Point(fromPoition.x, fromPoition.y + 1);
            }            
        }
    }
}
