using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Image
    {
        public string Id { get; set; }
        public string Path { get; set; } = string.Empty;
        public string Name_Old { get; set; } = string.Empty;
        public string Parent { get; set;} = string.Empty;
    }
}
