using System;
using System.Collections.Generic;

namespace Njoftime_API.Models
{
    public partial class User
    {
        public User()
        {
            Tags = new HashSet<Tags>();
        }

        public int Id { get; set; }
        public string Emer { get; set; }
        public string Mbiemer { get; set; }
        public string Email { get; set; }
        public string Gjinia { get; set; }

        public ICollection<Tags> Tags { get; set; }
    }
}
