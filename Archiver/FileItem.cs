using System;
using System.IO;
using System.Windows.Media;

namespace Archiver {
    public sealed class FileItem {
        public ImageSource Icon { get; private set; }
        public string DisplayName { get; private set; }
        public string Name { get; private set; }
        public long Size { get; private set; }
        public DateTime Modified { get; private set; }
        public DateTime Created { get; private set; }

        public FileItem(string path) {
        }
    }
}
