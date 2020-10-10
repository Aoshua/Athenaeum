using System;
using System.ComponentModel.DataAnnotations;

namespace Athenaeum.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [MaxLength(250)]
        public string SeriesTitle { get; set; }
        public short SeriesOrder { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        public int PageCount { get; set; }
        public int PublisherId { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
