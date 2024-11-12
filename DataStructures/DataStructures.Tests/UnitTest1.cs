using Arrays.LinkedLists;

namespace DataStructures.Tests
{
    using DataStructuresExercises.Matrix;
    public class MatrixQuestionsTests
    {


        // Data-driven test using [Theory] and [InlineData] to test multiple scenarios
        [Theory]
        //[InlineData("ABCCED", true,
        //        new char[] { 'A', 'B', 'C', 'E' },
        //        new char[] { 'S', 'F', 'C', 'S' },
        //        new char[] { 'A', 'D', 'E', 'E' }
        //    )]
        [InlineData("aaaaaaaaaaab", false,
                new char[] { 'a', 'A', 'a', 'a' },//["a","a","a","a"],["a","a","a","a"],["a","a","a","a"]
                new char[] { 'a', 'a', 'a', 'a' },
                new char[] { 'a', 'a', 'a', 'a' }
            )]
        //[InlineData("a", true,
        //        new char[] { 'a', 'a' }
        //    )]
        public void SearchWordDFS_Test(string wordToSearch, bool expected, params char[][] board)
        {
            // Act: Call the method to search the word
            //bool result = board.SearchWordDFS(wordToSearch);
            bool result = new WordSearchSolution().Exist(board, wordToSearch);

            // Assert: Verify the result matches the expected output
            Assert.Equal(expected, result);
        }

         
        [Theory]
        //[InlineData(new[]{2,4,3},new[] {5,6,4})]
        [InlineData(new[]{9,9,9,9,9,9,9},new[] {9,9,9,9})]
        public void Add2Numers_Test(int[] l1, int[] l2)
        {
            ListNode ln1 = new ListNode(l1[0]);
            var ln1Root = ln1;
            ListNode ln2 = new ListNode(l2[0]);
            var ln2Root = ln2;
            for (int i = 1; i < l1.Length; i++)
            {
                ln1.next = new ListNode(l1[i]);
                ln1 = ln1.next;
            }
            for (int i = 1; i < l2.Length; i++)
            {
                ln2.next = new ListNode(l2[i]);
                ln2 = ln2.next;
            }
            var res = new GeneralLinkedListQuestions().AddTwoNumbers(ln1Root, ln2Root);
        }
        
        
        [Fact]
        //
        
        public void MeetingRoomsTest()
        {
            // int[][] intervals = new int[][]
            // {
            //     new int[] { 2, 15 },
            //     new int[] { 36, 45 },
            //     new int[] { 9, 29 },
            //     new int[] { 16, 23 },
            //     new int[] { 4, 9 }
            // };
            ;
            int[][] intervals = new[] { new[] { 5, 8 }, new[] { 6, 8 } };
            var res = new Arrays().MinMeetingRooms(intervals);
        }

        [Theory]
        //[InlineData(new[]{0,1,0,2,1,0,1,3,2,1,2,1},6)]
        //[InlineData(new[]{4,2,3},1)]
        [InlineData(new[]{5,4,1,2},1)]
        public void TrappingWaterTest(int[] height,int expected)
        {
            
            var res = new Arrays().Trap(height);
            Assert.Equal(expected, res);
        }
    }
}