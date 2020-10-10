using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Athenaeum.Models
{
    public class User
    {
        public int UserId { get; set; }
        [MaxLength(250)]
        public string FirstName { get; set; }
        [MaxLength(250)]
        public string LastName { get; set; }
        public string Email { get; set; }
        [MaxLength(64)]
        public string Password { get; set; }
        [MaxLength(36)]
        public string Salt { get; set; }

        [NotMapped]
        public string FullName => FirstName + " " + LastName;
    }
}
