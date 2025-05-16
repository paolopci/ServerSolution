using System.ComponentModel.DataAnnotations;


namespace ServerApi.Models
{
    public class Server
    {
        [Key]
        public int ServerId { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public bool IsOnline { get; set; }
    }
}
