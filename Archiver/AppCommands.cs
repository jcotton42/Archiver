using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;

namespace Archiver {
    public static class AppCommands {
        public static ICommand CloseCommand { get; } = new DelegateCommand<Window>(window => window.Close());
    }
}
