using System;
using System.IO;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace Scripts.Reader
{
    public class ColumnReader
    {
        private const string Delimiter = ",";
        private readonly string _input;
        private readonly string _output;
        private readonly int _take;
        private readonly int? _skip;

        public ColumnReader(string input, string output, int take, int? skip = null)
        {
            _input = input;
            _output = output;
            _take = take;
            _skip = skip;
        }

        public void Run()
        {
            if (!File.Exists(_input))
                throw new ArgumentException(string.Format("input file does not exist : {0} ", Path.GetFullPath(_input)));

            using (var writer = new StreamWriter(_output, false, Encoding.Default))
            {
                using (var parser = new TextFieldParser(_input, Encoding.Default)
                {
                    Delimiters = new[] { Delimiter },
                    TrimWhiteSpace = true,
                    HasFieldsEnclosedInQuotes = false,
                    TextFieldType = FieldType.Delimited,
                })
                {
                    while (!parser.EndOfData)
                    {
                        var fields = parser.ReadFields();

                        if (fields == null || fields.Length == 0) continue;
                        var row = new StringBuilder();

                        var counter = 0;
                        
                        foreach (var field in fields)
                        {
                            if (counter >= _take) break;

                            row.Append(field);

                            counter++;
                            
                            if (counter != _take)
                                row.Append(Delimiter);
                        }

                        writer.WriteLine(row);
                    }
                }
            }
        }
    }
}