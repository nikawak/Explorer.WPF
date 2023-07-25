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
        }
        public FileViewModel(FileInfo fileInfo) : base(fileInfo.Name) 
        {
            FullPath = fileInfo.FullName;
        }
    }
}
