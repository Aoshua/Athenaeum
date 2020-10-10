using System.ComponentModel.DataAnnotations;

namespace Athenaeum.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        [MaxLength(250)]
        public string GenreName { get; set; }
    }
}
