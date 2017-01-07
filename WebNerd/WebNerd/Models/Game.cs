using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebNerd.Models
{
    public class Game : ModelBase
    {
        public string Name { get; set; }
        public int Year { get; set; }
    }
}