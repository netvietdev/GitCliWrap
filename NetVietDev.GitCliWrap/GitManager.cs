using CliWrap;
using CliWrap.Models;

namespace NetVietDev.GitCliWrap
{
    public class GitManager
    {
        private readonly string _repositoryFolder;

        public GitManager(string repositoryFolder)
        {
            _repositoryFolder = repositoryFolder;
        }

        public GitManager Pull()
        {
            var result = InternalProceed("pull");

            return this;
        }

        public GitManager AddFile(string filePath)
        {
            var result = InternalProceed(
                "add",
                string.Format("\"{0}\"", filePath)
            );

            return this;
        }

        public GitManager AddAllFiles()
        {
            var result = InternalProceed(
                "add",
                "*.*"
            );

            return this;
        }

        public GitManager Commit(string message)
        {
            var result = InternalProceed(
                "commit",
                "-m",
                string.Format(" \"{0}\"", message)
            );

            return this;
        }

        public bool Push()
        {
            var result = InternalProceed("push");
            return result.ExitCode == 0;
        }

        protected ExecutionResult InternalProceed(params string[] arguments)
        {
            var argumentsFlat = string.Join(" ", arguments);

            return new Cli("git.exe")
                .EnableStandardErrorValidation(false)
                .EnableExitCodeValidation(true)
                .SetWorkingDirectory(_repositoryFolder)
                .SetArguments(argumentsFlat)
                .Execute();
        }
    }
}