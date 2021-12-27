using System;
using System.Collections.Generic;

#nullable disable

namespace aao_api.Models
{
    public partial class AspNetUserLogin
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
