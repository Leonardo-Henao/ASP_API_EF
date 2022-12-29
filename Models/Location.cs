using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_API_EF.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Capital { get; set; }
        [JsonIgnore]
        public List<Client> Clients { get; set; }
    }
}
