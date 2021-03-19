using System.ComponentModel.DataAnnotations;

namespace athenaeum_webapi.Data
{
    public class Genre
    {
        public int GenreId { get; set; }
        [MaxLength(250)]
        public string GenreName { get; set; }
    }
}
