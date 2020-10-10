using System.ComponentModel.DataAnnotations;

namespace Athenaeum.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
    }
}
