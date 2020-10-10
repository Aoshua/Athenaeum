using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Athenaeum.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        [MaxLength(250)]
        public string FirstName { get; set; }
        [MaxLength(250)]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DeathDate { get; set; }
        public bool IsLiving { get; set; }

        [NotMapped]
        public string FullName => FirstName + " " + LastName;
    }
}
