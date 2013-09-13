using System.Collections.Generic;

namespace Scripts.Validators
{
    public class Validator : IValidator
    {
        //// private const char Delimiter = ',';
        
        private readonly IHeaderValidator _headerValidator;
        
        public Validator()
        {
            _headerValidator = new HeaderValidator();    
        }

        public IEnumerable<string> Validate(ISsisFileRequest request)
        {
            var result = _headerValidator.Validate(request);

            //// http://blogs.msdn.com/b/ericlippert/archive/2008/09/10/vexing-exceptions.aspx
           
            /**
             * File validation.
             **/
            
            return result;
        }
    }
}