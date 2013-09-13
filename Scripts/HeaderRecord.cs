using System.Collections.Generic;

namespace Scripts
{
    public class HeaderRecord
    {
        private readonly IList<string> _tokens;

        public HeaderRecord(IList<string> tokens)
        {
            _tokens = tokens;
        }
    }
}
