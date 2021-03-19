namespace athenaeum_webapi.Data
{
    public class UserCollection
    {
        public int UserCollectionId { get; set; }
        public int CollectionId { get; set; }
        public int UserId { get; set; }

        public Collection Collection { get; set; }
        public User User { get; set; }
    }
}
