﻿using System;
using System.ComponentModel.DataAnnotations;

namespace athenaeum_webapi.Data
{
    public class BookInCollection
    {
        public int BookInCollectionId { get; set; }
        public int BookId { get; set; }
        public int? PublisherId { get; set; }
        public DateTime? PublicationDate { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public int CollectionId { get; set; }
        [MaxLength(250)]
        public string PurchaseLocation { get; set; }
    }
}
