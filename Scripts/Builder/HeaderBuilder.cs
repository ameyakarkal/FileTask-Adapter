using System.Linq;

namespace Scripts.Builder
{
    public class HeaderBuilder : IHeaderBuilder
    {
        public HeaderRecord Build(ISsisFileRequest request)
        {
            var definedHeader = request.GetFileHeader();

            var headerTokens = definedHeader.Split(request.GetHeaderDelimiter());

            var head = headerTokens.ToList();

            return new HeaderRecord(head);
        }
    }
}