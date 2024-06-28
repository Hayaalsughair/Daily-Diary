using Daily_Diary;
using System.Text;
using Xunit;

namespace Daily_DiaryTest
{
    public class UnitTest1
    {
        private string testFilePath = @"..\..\..\testdata.txt";

        public UnitTest1()
        {
            //test file is empty
            File.WriteAllText(testFilePath, "");
        }

        [Fact]
        public void ReadDiaryFile_ShouldReadContent()
        {
            // Arrange
            File.WriteAllText(testFilePath, "2024-06-28\nTestTessstst.\n");

            // Act
           var result = DailyDiary.ReadDiaryFile(testFilePath);

            // Assert
            Assert.Equal("2024-06-28\nTestTessstst.\n", result);
        }

        [Fact]
        public void AddEntry_ShouldIncreaseEntryCount()
        {
            // Arrange
            File.WriteAllText(testFilePath, "2024-06-28\nTestTessstst.\n");

            // Act
            int initialCount = DailyDiary.CountEntries(testFilePath);

            // Assert
            Assert.Equal(initialCount , 1);
        }

    }
}