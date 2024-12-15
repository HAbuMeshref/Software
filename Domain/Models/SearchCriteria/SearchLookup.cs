using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.SearchCriteria
{
    public class SearchLookup
    {
        public long? Code { get; set; }
        public string Name { get; set; }

    }
    public class SearchLookupDetails
    {
        public string SourceValue { get; set; }
        public string SourceName { get; set; }
        public string DestinationName { get; set; }
        public string DestinationValue { get; set; }
        public long? LookupCode { get; set; }

    }
}
