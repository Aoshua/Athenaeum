﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace athenaeum_webapi.Data
{
    public class Book
    {
        public int BookId { get; set; }
        [MaxLength(250)]
        public string SeriesTitle { get; set; }
        public short? SeriesOrder { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        public int? PageCount { get; set; }
        public DateTime? PublicationDate { get; set; }

        public List<BookPublisher> BookPublishers { get; set; }
        public List<BookInCollection> BooksInCollection { get; set; }
        public List<UserBook> UserBooks { get; set; }
    }
}
