using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace athenaeum_webapi.Data
{
    public class Collection
    {
        public int CollectionId { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
    }
}
