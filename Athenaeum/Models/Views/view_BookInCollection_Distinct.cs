using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Athenaeum.Models.Views
{
    public class view_BookInCollection_Publisher
    {
        [Key]
        public int BookInCollectionId { get; set; }
        public int BookId { get; set; }
        public int? PublisherId { get; set; }
        public string PublisherName { get; set; }
        public DateTime? PublicationDate { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public int CollectionId { get; set; }
        public string PurchaseLocation { get; set; }
        public string SeriesTitle { get; set; }
        public int? SeriesOrder { get; set; }
        public string Title { get; set; }
        public int? PageCount { get; set; }
    }
}
