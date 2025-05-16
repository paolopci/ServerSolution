using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared
{
    public class Server
    {
        public int ServerId { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public bool IsOnline { get; set; }
    }

}
