namespace athenaeum_webapi.Data
{
    public class UserCollection
    {
        public int UserCollectionId { get; set; }
        public int CollectionId { get; set; }
        public virtual Collection Collection { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
