namespace DataStrucutres.Tests
{
    public class MatrixQuestionsTests
    {


        // Data-driven test using [Theory] and [InlineData] to test multiple scenarios
        [Theory]
        [InlineData("ABCCED", true,
                new char[] { 'A', 'B', 'C', 'E' },
                new char[] { 'S', 'F', 'C', 'S' },
                new char[] { 'A', 'D', 'E', 'E' }
            )]
        public void SearchWordDFS_Test(string wordToSearch, bool expected, params char[][] board)
        {
            // Act: Call the method to search the word
            bool result = board.SearchWordDFS(wordToSearch);

            // Assert: Verify the result matches the expected output
            Assert.Equal(expected, result);
        }

    }
}