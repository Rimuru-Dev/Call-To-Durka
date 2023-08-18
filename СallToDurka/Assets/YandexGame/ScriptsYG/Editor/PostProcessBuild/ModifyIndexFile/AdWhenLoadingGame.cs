
using RimuruDev.YandexGame.ScriptsYG.Inside;

namespace RimuruDev.YandexGame.ScriptsYG.Editor.PostProcessBuild.ModifyIndexFile
{
    public static partial class ModifyIndexFile
    {
        static void SetAdWhenLoadGameValue(ref string fileText)
        {
            InfoYG infoYG = ConfigYG.GetInfoYG();

            if (infoYG.showFirstAd == false)
            {
                fileText = fileText.Replace("let firstAd = true;", "let firstAd = false;");
            }
        }
    }
}
