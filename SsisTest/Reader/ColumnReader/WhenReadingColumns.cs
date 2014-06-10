using NUnit.Framework;

namespace SsisTest.Reader.ColumnReader
{
    public class WhenReadingColumns
    {
        private const string InputFilePath = @"input.csv";
        private const string OutputFilePath = @"output.csv";

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void ShouldTrimColumns()
        {
            var reader = new Scripts.Reader.ColumnReader(InputFilePath, OutputFilePath, 3);
            
            reader.Run();
        }
    }
}