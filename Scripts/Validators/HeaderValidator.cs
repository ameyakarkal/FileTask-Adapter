using System.Collections.Generic;
using System.Linq;
using scripts;

namespace Scripts.Validators
{
    public class HeaderValidator : IHeaderValidator
    {
        public const char HeaderDelimiter = ',';

        public IEnumerable<string> Validate(ISsisFileRequest request)
        {
            var header = request.GetFileHeader();

            if (string.IsNullOrEmpty(header))
                return new List<string> { ValidationMessages.NullHeader };

            var columns = header.Split(HeaderDelimiter);

            if (columns.Length == 0)
                return new List<string> { ValidationMessages.InvalidHeader };

            var correctedColumns = columns.Where(string.IsNullOrEmpty).Select(x => x.Trim()).ToList();

            var distinctCount = correctedColumns.Distinct().Count();

            var length = correctedColumns.Count();

            if (distinctCount != length)
                return new List<string> {ValidationMessages.DuplicateTokensInHeader};

            return Validation.Success;
        }
    }
}