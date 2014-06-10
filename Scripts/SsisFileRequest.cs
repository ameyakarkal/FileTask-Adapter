namespace Scripts
{
    public class SsisFileRequest : ISsisFileRequest
    {
        public const char HeaderDelimiter = ',';

        private readonly string _input;
        private readonly string _output;
        private readonly string _fileHeader;
        
        public SsisFileRequest(string input, string output, string fileHeader)
        {
            _input = input;
            _output = output;
            _fileHeader = fileHeader;
        }

        public string GetInputFilePath()
        {
            return _input;
        }

        public string GetOutputFilePath()
        {
            return _output;
        }

        public string GetFileHeader()
        {
            return _fileHeader;
        }

        public char GetHeaderDelimiter()
        {
            return HeaderDelimiter;
        }
    }
}