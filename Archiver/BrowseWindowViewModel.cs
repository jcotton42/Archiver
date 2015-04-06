using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using JetBrains.Annotations;
using Microsoft.Practices.Prism.Commands;

namespace Archiver {
    public sealed class BrowseWindowViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        private BrowseWindowModel model;

        private string titleComponent;

        public ICommand SelectAllCommand { get; private set; }
        public ICommand OpenItemCommand { get; private set; }
        public ICommand SortByOrSetColumnCommand { get; private set; }

        private void SelectAll() {
            throw new NotImplementedException();
        }

        public string TitleComponent {
            get { return titleComponent; }
            set {
                if(value == titleComponent) return;
                titleComponent = value;
                OnPropertyChanged();
            }
        }

        public ListCollectionView Files { get; private set; }

        public BrowseWindowViewModel() {
            model = new BrowseWindowModel();
            model.PropertyChanged += (sender, args) => {
                if(args.PropertyName == nameof(model.CurrentDirectory))
                    TitleComponent = model.CurrentDirectory;
            };
            model.CurrentDirectory = Environment.CurrentDirectory;
            SelectAllCommand = new DelegateCommand(SelectAll);
            Files = new ListCollectionView(model.Files);
        }

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
