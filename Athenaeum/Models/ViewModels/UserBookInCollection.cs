using System;

namespace Athenaeum.Models.ViewModels
{
    public class UserBookInCollection
    {
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
    }
}
