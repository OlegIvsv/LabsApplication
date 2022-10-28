using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsApplication.DTOModels
{
    public class ProducerDTO
    {
        public int Id { get; protected set; }

        public string Name { get; set; } = null!;

        public string? Country { get; set; }

        public string? Description { get; set; }

        public static ProducerDTO FromDataRecord(IDataRecord row)
        {
            return new ProducerDTO
            {
                Id = (int)row["Id"],
                Name = (string)row["Name"],
                Country = row["Country"] == DBNull.Value ? null : (string)row["Country"],
                Description = row["Description"] == DBNull.Value ? null : (string)row["Description"],
            };
        }
    }

}
