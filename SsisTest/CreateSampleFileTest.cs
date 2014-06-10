using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace Ssistest
{
    [TestFixture]
    public class CreateSampleFileTest
    {
        public const string SampleFileName = "FileWithLineEndings.csv";

        public const string SampleTemporaryFileName = "FileWithLineEndings-temp.csv";
        
        public void ShouldCreateFile()
        {
            if (File.Exists(SampleFileName))
                File.Delete(SampleFileName);

            using (var filewriter = new StreamWriter(new FileStream(SampleFileName, FileMode.OpenOrCreate)))
            {
                var rowGenerator = new RowGenerator(2);
                foreach (var row in rowGenerator)
                    filewriter.Write(row);
            }
        }

        [Test]
        public void ShouldReadFile()
        {
            using (var reader = new StreamReader(new FileStream(SampleFileName, FileMode.Open)))
            {
                var count = 0;
                string line;
                
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    count++;
                }

                Console.Write(count);
            }
        }

        [Test]
        public void ShouldConvertFile()
        {
            using (var reader = new StreamReader(new FileStream(SampleFileName, FileMode.Open)))
            {
                if (File.Exists(SampleTemporaryFileName))
                    File.Delete(SampleTemporaryFileName);

                using (var writer = new StreamWriter(new FileStream(SampleTemporaryFileName, FileMode.Create)))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                        writer.WriteLine(line);
                }
            }

            if (File.Exists(SampleFileName))
                File.Delete(SampleFileName);

            File.Copy(SampleTemporaryFileName, SampleFileName);
            File.Delete(SampleTemporaryFileName);
        }

        [Test]
        public void ShouldGetFileDetails()
        {
            var filePath = Path.GetFullPath(SampleFileName);

            var fileName = Path.GetFileNameWithoutExtension(filePath);

            var extension = Path.GetExtension(filePath);

            var folder = Path.GetDirectoryName(filePath);

            Console.WriteLine(@"folder :{0}", folder);
            Console.WriteLine(@"fileName :{0}", fileName);
            Console.WriteLine(@"extension :{0}", extension);
            Console.WriteLine(@"filePath :{0}", filePath);
        }

        [Test]
        public void RowGeneratorTest()
        {
            var rowGenerator = new RowGenerator(2);
            foreach (var item in rowGenerator)
                Console.Write(item);
        }

        internal class RowGenerator : IEnumerator, IEnumerable
        {
            private readonly int _rows;

            private int _walker;
            
            private string _current;

            public RowGenerator(int rows)
            {
                _rows = rows;
            }

            public object Current
            {
                get { return _current; }
            }

            public bool MoveNext()
            {
                if (_walker == _rows) return false;

                _walker++;

                _current = string.Format("{0},data01,data02,data03\n", _walker);

                return true;
            }

            public void Reset()
            {
                _walker = 1;
            }

            public IEnumerator GetEnumerator()
            {
                return this;
            }
        }
    }
}
