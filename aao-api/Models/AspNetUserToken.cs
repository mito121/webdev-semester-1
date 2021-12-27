using System;
using System.Collections.Generic;

#nullable disable

namespace aao_api.Models
{
    public partial class AspNetUserToken
    {
        public int UserId { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual User User { get; set; }
    }
}
