using System;
using System.Collections.Generic;

namespace Njoftime_API.Models
{
    public partial class Ministrite
    {
        public Ministrite()
        {
            Tags = new HashSet<Tags>();
        }

        public int Id { get; set; }
        public string Ministria { get; set; }

        public ICollection<Tags> Tags { get; set; }
    }
}
