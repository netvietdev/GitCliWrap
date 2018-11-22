using NetVietDev.GitCliWrap;
using System;
using System.IO;

namespace GitExeWrap
{
    class Program
    {
        static void Main(string[] args)
        {
            const string repository = @"E:\Github\testgit";
            CreateFileAndCommit(repository);
            Console.ReadLine();
        }

        private static void CreateFileAndCommit(string repositoryFolder)
        {
            var guid = Guid.NewGuid().ToString();
            var dirPath = Path.Combine(repositoryFolder, guid);
            Directory.CreateDirectory(dirPath);

            var filePath = Path.Combine(dirPath, guid + ".txt");
            File.WriteAllText(filePath, "Time is " + DateTime.Now);

            var result = new GitManager(repositoryFolder).Pull().AddFile(filePath).Commit("Commit at " + DateTime.Now).Push();
        }
    }
}
