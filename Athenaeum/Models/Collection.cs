using System;
using System.ComponentModel.DataAnnotations;

namespace Athenaeum.Models
{
    public class Collection
    {
        public int CollectionId { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
    }
}
