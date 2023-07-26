using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.ViewModels.Entities
{
    public class FileViewModel : EntityViewModel
    {
        public FileViewModel(string name) : base(name) 
        {
            FullPath = name;
            Icon = new Icon() { Name = "File", Color = "White" };
        }
        public FileViewModel(FileInfo fileInfo) : this(fileInfo.Name) 
        {
            FullPath = fileInfo.FullName;
        }
    }
}
