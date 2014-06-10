using System;
using System.Configuration;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace SsisTest.Files
{
    public class Generate
    {
        private string _baseDirectory;
        private const string Delimiter = ",";

        [SetUp]
        public void SetUp()
        {
            var directory = ConfigurationManager.AppSettings.Get("BaseDirectory");

            if (string.IsNullOrEmpty(directory))
                throw new Exception("please provide the base directory to create files");

            _baseDirectory = directory;
        }

        [Test]
        public void CreateSimpleFile()
        {
            var input = Path.Combine(_baseDirectory, "simple.csv");
            Write(input, 2, 12);
        }

        [Test]
        public void CreateBulkFile()
        {
            var input = Path.Combine(_baseDirectory, "bulk.csv");
            Write(input, 50000, 70);
        }

        protected void Write(string input, int rows, int columns)
        {
            using (var writer = new StreamWriter(input, append: false))
            {
                var currentRow = 0;
                while (currentRow < rows)
                {
                    var currentColumn = 0;

                    var rowBuffer = new StringBuilder();
                    
                    while (currentColumn < columns)
                    {
                        rowBuffer.AppendFormat("cell-{0}{1}", currentRow, currentColumn);
                        currentColumn++;
                        rowBuffer.AppendFormat("{0}", currentColumn == columns ? string.Empty : Delimiter);
                    }
                    
                    writer.WriteLine(rowBuffer);
                    
                    currentRow++;
                }
            }
        }

        protected void DeleteFile(string file)
        {
            File.SetAttributes(file, FileAttributes.Normal);
            File.Delete(file);
        }
    }
}
