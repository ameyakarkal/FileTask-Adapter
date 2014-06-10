using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using Scripts.Builder;
using Scripts.Validators;

namespace Scripts.Reader
{
    public class SsisCsvReader : ISsisCsvReader
    {
        private const string ColumnDelimiter = ",";

        private readonly IValidator _validator;

        private readonly IHeaderBuilder _builder;
 
        public SsisCsvReader(IValidator validator, IHeaderBuilder builder)
        {
            _validator = validator;
            _builder = builder;
        }

        public void Read(ISsisFileRequest request)
        {
            _validator.Validate(request);

            var header = _builder.Build(request);
            
            var reader = new CsvReader(
                new StreamReader(request.GetInputFilePath()),
                new CsvConfiguration
                    {
                        Delimiter = ColumnDelimiter, 
                        HasHeaderRecord = true
                    });
            
        }
    }
}
