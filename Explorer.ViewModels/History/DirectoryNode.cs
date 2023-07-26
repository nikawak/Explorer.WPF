using Explorer.ViewModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.ViewModels.History
{
    public class DirectoryNode
    {
        public DirectoryNode Next { get; set; }
        public DirectoryNode Previous { get; set; }
        public DirectoryViewModel Current { get; set; }
    }
}
