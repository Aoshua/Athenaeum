using System;
using System.ComponentModel.DataAnnotations;

namespace Athenaeum.Models.Views
{
    public class view_BookInCollection_UserBook
    {
        [Key]
        public int BookInCollectionId { get; set; }
        public int BookId { get; set; }
        public int? PublisherId { get; set; }
        public DateTime? PublicationDate { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public int CollectionId { get; set; }
        public string PurchaseLocation { get; set; }
        public int UserBookId { get; set; }
        public int UserId { get; set; }
        public DateTime? StartedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string Note { get; set; }
    }
}
