using System.ComponentModel.DataAnnotations;

namespace athenaeum_webapi.Data
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
    }
}
