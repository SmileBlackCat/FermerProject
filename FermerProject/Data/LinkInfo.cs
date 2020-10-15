using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FermerProject.Data
{
    public class LinkInfo
    {
        public string Img { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public List<string> MainWords { get; set; }
        public string Info { get; set; }
    }
}
