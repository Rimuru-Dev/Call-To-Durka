using System.IO;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.Callbacks;

namespace RimuruDev.YandexGame.ScriptsYG.Editor.PostProcessBuild
{
    public class PostProcessBuild : IPreprocessBuildWithReport
    {
        public int callbackOrder { get { return 0; } }
        public void OnPreprocessBuild(BuildReport report)
        {
            string buildPatch = report.summary.outputPath + "/index.html";

            if (File.Exists(buildPatch))
            {
                File.Delete(buildPatch);
            }
        }

        [PostProcessBuild]
        public static void ModifyIndex(BuildTarget target, string pathToBuiltProject)
        {
            ModifyIndexFile.ModifyIndexFile.ModifyIndex(pathToBuiltProject);
            ArchivingBuild.Archiving(pathToBuiltProject);
        }
    }
}