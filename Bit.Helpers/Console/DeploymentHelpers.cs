using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Bit.Helpers.Console
{
    public class DeploymentHelpers
    {
        public void RunDeploymentProfile(string project, string publishProfile, string username, string password, string compilerPath = "c:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\MSBuild.exe")
        {
            var path = GetSolutionDirectoryPath();

            if (string.IsNullOrEmpty(path))
            {
                throw new Exception("Could not find solution directory.");
            }

            var projectFilePath = GetProjectFilePath(path, project);
            RunHelpers run = new RunHelpers();

            var command = string.Format("{0} {1} /p:DeployOnBuild=true /p:PublishProfile=\"{2}\" /p:AllowUntrustedCertificate=True /p:username={3} /p:password={4}", compilerPath, projectFilePath, publishProfile, username, password);

            run.SyncProcess(command);
        }

        public void RunQloudDeployment(string project, string adjective, string openUrl = null)
        {
            var publishProfile = GetTemporaryQloudPublishProfile(adjective);

            RunDeploymentProfile(project, publishProfile, "WebDeployUser", "hattefar");

            File.Delete(publishProfile);

            if (openUrl != null)
            {
                LaunchUrl(string.Format("http://{0}.qloud.dk", adjective.ToLower()));
            }
        }

        public string QloudUrl(string adjective)
        {
            return string.Format("http://{0}.qloud.dk", adjective.ToLower());
        }

        private string GetTemporaryQloudPublishProfile(string adjective)
        {
            var tempPath = Path.GetTempFileName();

            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Bit.Helpers.Console.Qloud.pubxml"))
            using (StreamReader reader = new StreamReader(stream))
            {
                var content = reader
                    .ReadToEnd()
                    .Replace("{url}", string.Format("http://{0}.qloud.dk/", adjective.ToLower()))
                    .Replace("{app}", adjective);

                File.AppendAllText(tempPath, content);

                return tempPath;
            }
        }

        public void LaunchUrl(string url)
        {
            (new RunHelpers()).SyncProcess(string.Format("start {0}", url));
        }

        public string GetSolutionDirectoryPath()
        {
            var scriptPath = Assembly.GetEntryAssembly().Location;
            var scriptDirectory = Path.GetDirectoryName(scriptPath);

            while (!string.IsNullOrEmpty(scriptDirectory) && !Directory.GetFiles(scriptDirectory).Any(x => x.ToLower().EndsWith(".sln")))
            {
                scriptDirectory = Path.GetDirectoryName(scriptDirectory);
            }

            return scriptDirectory;
        }

        private string GetProjectFilePath(string solutionDirectory, string projectName)
        {
            var projectPath = Path.Combine(solutionDirectory, projectName);

            var csproj = Directory.GetFiles(projectPath).Single(x => x.ToLower().EndsWith(".csproj"));

            return Path.Combine(projectPath, csproj);
        }
    }
}