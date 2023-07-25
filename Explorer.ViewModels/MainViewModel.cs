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
        public ObservableCollection<EntityViewModel> DirectoriesAndFiles { get; set; } = new();
        public string CurrentPath { get; set; }
        public MainViewModel()
        {
            OpenCommand = new DelegateCommand(Open);
            foreach(var driveName in Directory.GetLogicalDrives())
            {
                DirectoriesAndFiles.Add(new DirectoryViewModel(driveName));
            }
        }
        public void Open(object param)
        {
            if(param is DirectoryViewModel directoryVM)
            {
                CurrentPath = directoryVM.FullPath;
                DirectoriesAndFiles.Clear();
                var dirInfo = new DirectoryInfo(CurrentPath);
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
    }
}
