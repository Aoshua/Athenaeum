using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace athenaeum_webapi.Data
{
    public class BookPublisher
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set;}
        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
