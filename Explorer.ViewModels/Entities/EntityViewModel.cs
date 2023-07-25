using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.ViewModels.Entities
{
    public class EntityViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string FullPath { get; set; }
        public EntityViewModel(string name)
        {
            Name = name;
        }
    }
}
