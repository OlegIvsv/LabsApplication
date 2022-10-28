using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsApplication.DTOModels
{ 
    public class CustomerDTO
    {
        public int Id { get; set; }

        public string Firstname { get; set; } = null!;

        public string Lastname { get; set; } = null!;

        public int Age { get; set; }

        public string Country { get; set; } = null!;

        public bool? Gender { get; set; }

        public string EmailAddress { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? ProfilePicture { get; set; }


        public static CustomerDTO FromDataRecord(IDataRecord row)
        {
            return new CustomerDTO
            {
                Id = (int)row["Id"],
                Firstname = (string)row["Firstname"],
                Lastname = (string)row["Lastname"],
                Age = (int)row["Age"],
                Country = (string)row["Country"],
                Gender = (bool)row["Gender"],
                EmailAddress = (string)row["EmailAddress"],
                Password = (string)row["Password"],
                ProfilePicture = (row["ProfilePicture"] == DBNull.Value ? null : (string)row["ProfilePicture"])
            };
        } 
    }
}
