using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Archiver {
    internal sealed class BrowseWindowModel : INotifyPropertyChanged {
        private string currentDirectory;
        public event PropertyChangedEventHandler PropertyChanged;

        public string CurrentDirectory {
            get { return currentDirectory; }
            set {
                if(value == currentDirectory) return;
                currentDirectory = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<FileItem> Files { get; } = new ObservableCollection<FileItem>();

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
