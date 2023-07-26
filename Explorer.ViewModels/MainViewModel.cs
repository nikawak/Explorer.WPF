using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Explorer.ViewModels.Commands;
using Explorer.ViewModels.Entities;
using Explorer.ViewModels.History;

namespace Explorer.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private DirectoryHistory _history = new DirectoryHistory(null);

        public ICommand OpenCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand MoveForwardCommand { get; }
        public ICommand MoveBackCommand { get; }

        public ObservableCollection<EntityViewModel> DirectoriesAndFiles { get; set; } = new();
        public EntityViewModel SelectedEntity { get; set; }
        public string PathSearch { get; set; }
        public string Name { get; set; }
        public MainViewModel()
        {
            OpenCommand = new DelegateCommand(Open);
            SearchCommand = new DelegateCommand(Search);
            MoveForwardCommand = new DelegateCommand(MoveForward);
            MoveBackCommand = new DelegateCommand(MoveBack);

            foreach(var driveName in Directory.GetLogicalDrives())
            {
                DirectoriesAndFiles.Add(new DirectoryViewModel(driveName));
            }
        }
        public void Open(object param)
        {
            if (!(param is DirectoryViewModel directoryVM)) return;
            
            
            _history.AddNode(directoryVM);
            OpenDirectory(directoryVM);
        }
        public void OpenDirectory(DirectoryViewModel directoryVM)
        {
            PathSearch = directoryVM.FullPath;
            Name = directoryVM.Name;

            DirectoriesAndFiles.Clear();
            var dirInfo = new DirectoryInfo(PathSearch);

            foreach (var dir in dirInfo.GetDirectories())
            {
                DirectoriesAndFiles.Add(new DirectoryViewModel(dir));
            }
            foreach (var file in dirInfo.GetFiles())
            {
                DirectoriesAndFiles.Add(new FileViewModel(file));
            }
        }
        public void Search(object param)
        {
            var searchStr = param?.ToString();
            var dirInfo = new DirectoryViewModel(searchStr);
            Open(dirInfo);
        }
        public void MoveForward(object param)
        {
            _history.MoveNext();
            OpenDirectory(_history.Current);
        }
        public void MoveBack(object param)
        {
            _history.MovePrevious();
            OpenDirectory(_history.Current);
        }
    }
}
