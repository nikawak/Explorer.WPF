using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Explorer.ViewModels.Commands;
using Explorer.ViewModels.Entities;

namespace Explorer.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand OpenCommand { get; }
        public ICommand SearchCommand { get; }
        public ObservableCollection<EntityViewModel> DirectoriesAndFiles { get; set; } = new();
        public EntityViewModel SelectedEntity { get; set; }
        public string PathSearch { get; set; }
        public string Name { get; set; }
        public MainViewModel()
        {
            OpenCommand = new DelegateCommand(Open);
            SearchCommand = new DelegateCommand(Search);
            foreach(var driveName in Directory.GetLogicalDrives())
            {
                DirectoriesAndFiles.Add(new DirectoryViewModel(driveName));
            }
        }
        public void Open(object param)
        {
            if(param is DirectoryViewModel directoryVM)
            {
                PathSearch = directoryVM.FullPath;
                DirectoriesAndFiles.Clear();
                var dirInfo = new DirectoryInfo(PathSearch);
                foreach(var dir in dirInfo.GetDirectories())
                {
                    DirectoriesAndFiles.Add(new DirectoryViewModel(dir));
                }
                foreach (var file in dirInfo.GetFiles())
                {
                    DirectoriesAndFiles.Add(new FileViewModel(file));
                }
            }
        }
        public void Search(object param)
        {
            var searchStr = param.ToString();
            var dirInfo = new DirectoryViewModel(searchStr);
            Open(dirInfo);
        }
    }
}
