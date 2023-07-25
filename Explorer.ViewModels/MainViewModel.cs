using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            foreach(var driveName in Directory.GetLogicalDrives())
            {
                DirectoriesAndFiles.Add(new DirectoryViewModel(driveName));
            }
        }
        public ObservableCollection<EntityViewModel> DirectoriesAndFiles { get; set; } = new ();
    }
}
