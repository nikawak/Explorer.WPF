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
            Icon = new Icon() { Name = "Folder", Color = "Yellow" };
        }
        public DirectoryViewModel(DirectoryInfo dirInfo) :this(dirInfo.Name)
        {
            FullPath = dirInfo.FullName;
        }
    }
}
