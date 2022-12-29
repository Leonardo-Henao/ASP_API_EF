using System.ComponentModel.DataAnnotations;

namespace ASP_API_EF.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int CityId { get; set; }

        public Location City { get; set; }
    }
}
