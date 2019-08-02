using Challenge.Api.Models;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Api.Mapping
{
    public sealed class RecordObjectModelMap : ClassMap<RecordObjectModel>
    {
        public RecordObjectModelMap()
        {
            Map(m => m.Id);
            Map(m => m.Name);

        }
    }
}
