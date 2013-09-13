namespace Scripts.Builder
{
    public interface IHeaderBuilder
    {
        HeaderRecord Build(ISsisFileRequest request);
    }
}
