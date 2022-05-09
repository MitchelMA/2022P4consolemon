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
        private static readonly string pathToBase = @"..\..\..\";
        private static readonly DirectoryInfo baseDir = new DirectoryInfo(Path.Combine(execDir.ToString(), pathToBase));
        internal static string ReadFromFile(string filePath) 
        {
            return File.ReadAllText(baseDir.FullName + filePath);
        }
        internal static string[] ReadAsLines(string filePath)
        {
            return File.ReadAllLines(baseDir.FullName + filePath);
        }
        internal static FileInfo GetFileInfo(string filePath)
        {
            return new FileInfo(baseDir.FullName + filePath);
        }
    }
}
