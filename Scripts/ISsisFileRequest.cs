namespace Scripts
{
    public interface ISsisFileRequest
    {
        string GetInputFile();
        
        string GetOutputFile();
        
        string GetFileHeader();

        char GetHeaderDelimiter();
    }
}