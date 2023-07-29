using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.ViewModels.Extensions
{
    public static class DirectoryInfoExtension
    {
        public static void CopyTo(this DirectoryInfo dir, string destination, bool recursive)
        {
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            DirectoryInfo[] dirs = dir.GetDirectories();

            Directory.CreateDirectory(destination);

            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destination, file.Name);
                file.CopyTo(targetFilePath);
            }

            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destination, subDir.Name);
                    subDir.CopyTo(newDestinationDir, true);
                }
            }
        }
        public static long CalculateLength(this DirectoryInfo dir, bool recursive)
        {
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");
            long length = 0;

            foreach(var file in dir.GetFiles())
            {
                length += file.Length;
            }
            if (recursive)
            {
                foreach (var subDir in dir.GetDirectories())
                {
                    length += subDir.CalculateLength(true);
                }
            }
            return length;
        }
    }
}
