using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using Scripts.Builder;
using Scripts.Validators;

namespace Scripts.Reader
{
    public class SsisSsisCsvReader : ISsisCsvReader
    {
        private readonly IValidator _validator;

        private readonly IHeaderBuilder _builder;

        private readonly string ColumnDelimiter = ",";
 
        public SsisSsisCsvReader(IValidator validator, IHeaderBuilder builder)
        {
            _validator = validator;
            _builder = builder;
        }

        public void Read(ISsisFileRequest request)
        {
            _validator.Validate(request);

            var header = _builder.Build(request);
            
            var reader = new CsvReader(
                new StreamReader(request.GetInputFile()),
                new CsvConfiguration
                    {
                        Delimiter = ColumnDelimiter, 
                        HasHeaderRecord = true
                    });
            
        }
    }
}
