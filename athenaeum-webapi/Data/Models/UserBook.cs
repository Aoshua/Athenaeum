using System;

namespace athenaeum_webapi.Data
{
    public class UserBook
    {
        public int UserBookId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public DateTime? StartedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string Note { get; set; }
    }
}
