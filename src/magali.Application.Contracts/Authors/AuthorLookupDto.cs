using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magali.Authors
{
    public class AuthorLookupDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? ShortBio { get; set; }
    }
}
