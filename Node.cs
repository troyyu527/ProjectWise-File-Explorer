using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWiseApp
{
    public class Node
    {
        public string Name { get; set; }
        public List<Node> Children { get; set; } = new List<Node>();
        public bool IsDocument { get; set; }
        public bool HasChildren { get; set; }
        public int ProjectId { get; set; }
        public int ObjectId { get; set; }
    }
}
