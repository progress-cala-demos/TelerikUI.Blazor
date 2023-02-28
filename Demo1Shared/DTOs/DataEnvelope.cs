using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.DataSource;

namespace Demo1Shared.DTOs
{
    public class DataEnvelope<T>
    {
        public List<AggregateFunctionsGroup> GroupedData { get; set; }
        public List<T> CurrentPageData { get; set; }
        public int TotalItemCount { get; set; }

        public DataEnvelope() { }
    }
}
