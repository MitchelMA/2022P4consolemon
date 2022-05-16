using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleMon.Monsters;

namespace ConsoleMon.Tools
{
    internal static class PathHelper
    {
        private static readonly DirectoryInfo execDir = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory;
        internal static string ReadFromFile(string filePath)
        {
            return File.ReadAllText(execDir.FullName + filePath);
        }
        internal static string[] ReadAsLines(string filePath)
        {
            return File.ReadAllLines(execDir.FullName + filePath);
        }
        internal static FileInfo GetFileInfo(string filePath)
        {
            return new FileInfo(execDir.FullName + filePath);
        }
    }
}
