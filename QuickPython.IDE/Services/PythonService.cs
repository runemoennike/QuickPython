using System.Diagnostics;
using System.IO;
using System.Linq;
using QuickPython.IDE.Exceptions;

namespace QuickPython.IDE.Services
{
    public class PythonService : IPythonService
    {
        private const string _pythonEnvFolderName = "PythonEnv";
        private const string _pythonExecutableFileName = "python.exe";
        private const string _temporaryCodeFileName = "quickpython-current.py";

        public void Execute(string pythonCode)
        {
            if (!TryFindPythonEnv(out var PythonEnvPath))
            {
                throw new PythonEnvironmentException("PythonEnv folder not found.");
            }

            var codeFilePath = PersistPythonCode(pythonCode);

            var processStartInfo = new ProcessStartInfo()
            {
                FileName = _pythonExecutableFileName,
                WorkingDirectory = PythonEnvPath,
                Arguments = codeFilePath
            };
        }

        private string PersistPythonCode(string pythonCode)
        {
            var path = Path.Combine(Path.GetTempPath(), _temporaryCodeFileName);
            File.WriteAllText(path, pythonCode);

            return path;
        }

        private bool TryFindPythonEnv(out string PythonEnvPath)
        {
            var searchDirectory = ".";

            while (Directory.Exists(searchDirectory))
            {
                var directoryMatches = Directory.GetDirectories(".", _pythonEnvFolderName);
                if (directoryMatches.Any())
                {
                    PythonEnvPath = directoryMatches.First();
                    return true;
                }
                else
                {
                    searchDirectory += "/..";
                }
            }

            PythonEnvPath = null;
            return false;
        }
    }
}
