using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.ViewModels
{
    public class FileViewModel : EntityViewModel
    {
        public FileViewModel(string name) : base(name) { }
        public FileViewModel(DirectoryInfo dirInfo) : base(dirInfo.Name) { }
    }
}
