using System.Collections.Generic;
using Scripts;

namespace Scripts.Validators
{
    public interface IHeaderValidator
    {
        IEnumerable<string> Validate(ISsisFileRequest request);
    }
}
