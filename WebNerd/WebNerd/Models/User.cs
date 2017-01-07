using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebNerd.Models
{
    public class User : ModelBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public IList<Game> Games { get; set; }
    }
}