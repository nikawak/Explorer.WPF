using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.ViewModels.Entities
{
    public class DirectoryViewModel : EntityViewModel
    {
        public DirectoryViewModel(string name) : base(name) 
        {
            FullPath = name;
        }
        public DirectoryViewModel(DirectoryInfo dirInfo) : base(dirInfo.FullName) 
        {
            FullPath = dirInfo.FullName;
        }
    }
}
