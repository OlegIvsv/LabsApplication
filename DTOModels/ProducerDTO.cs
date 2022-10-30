using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsApplication.DTOModels
{
    public class ProducerData
    {
        public int Id { get; protected set; }

        public string Name { get; set; } = null!;

        public string? Country { get; set; }

        public string? Description { get; set; }

        public static ProducerData FromDataRecord(IDataRecord row)
        {
            return new ProducerData
            {
                Id = (int)row["Id"],
                Name = (string)row["Name"],
                Country = row["Country"] == DBNull.Value ? null : (string)row["Country"],
                Description = row["Description"] == DBNull.Value ? null : (string)row["Description"],
            };
        }
    }

}
