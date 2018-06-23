using System;
using System.Collections.Generic;

namespace Njoftime_API.Models
{
    public partial class Tags
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? MinistriaId { get; set; }

        public Ministrite Ministria { get; set; }
        public User User { get; set; }
    }
}
