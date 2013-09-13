using System.Collections.Generic;

namespace Scripts.Validators
{
    public interface IValidator
    {
        IEnumerable<string> Validate(ISsisFileRequest request);
    }
}