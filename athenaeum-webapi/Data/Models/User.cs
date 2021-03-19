using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace athenaeum_webapi.Data
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

        public List<UserCollection> Collections { get; set; }

        [NotMapped]
        public string FullName => FirstName + " " + LastName;
    }
}
