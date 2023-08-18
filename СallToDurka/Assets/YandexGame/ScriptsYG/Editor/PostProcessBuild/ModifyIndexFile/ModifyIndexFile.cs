using System.IO;

namespace RimuruDev.YandexGame.ScriptsYG.Editor.PostProcessBuild.ModifyIndexFile
{
    public static partial class ModifyIndexFile
    {
        private static string BUILD_PATCH;

        public static void ModifyIndex(string buildPatch)
        {
            BUILD_PATCH = buildPatch;
            string filePath = Path.Combine(buildPatch, "index.html");
            string fileText = File.ReadAllText(filePath);

            // ������ ����������� index �����:
            SetBakcgroundFormat(ref fileText);
            SetAdWhenLoadGameValue(ref fileText);
            SetPixelRatioMobile(ref fileText);
            SetMetricaCounterID(ref fileText);

            File.WriteAllText(filePath, fileText);
        }
    }
}