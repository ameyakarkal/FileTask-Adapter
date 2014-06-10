namespace Scripts
{
    public interface ISsisFileRequest
    {
        string GetInputFilePath();
        
        string GetOutputFilePath();
        
        string GetFileHeader();

        char GetHeaderDelimiter();
    }
}