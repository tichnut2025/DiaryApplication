using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public  class EmployeeDTO
    {
        public int Empid { get; set; }

        public string Emptz { get; set; } = null!;
        public string FullName
        {
            get
            {
                return $"{LastName} {FirstName}";
            }
        }

        public string LastName { get; set; } = null!;

        public string? FirstName { get; set; }

        public string? Zip { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public int? Position { get; set; }

        public DateOnly? DateHire { get; set; }

        public DateOnly? Birthdate { get; set; }

        public string? ManagerId { get; set; }

    }
}
