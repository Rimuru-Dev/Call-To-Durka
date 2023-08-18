using System;
using Plugins.Audio.Core;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using AudioConfiguration = Plugins.Audio.Core.AudioConfiguration;
using Directory = UnityEngine.Windows.Directory;

namespace Plugins.Audio.Editor
{
    public class AudioBuildProcess
    {
        [PostProcessBuild(0)]
        public static void OnPostBuild(BuildTarget target, string pathToBuildProject)
        {
            if (target != BuildTarget.WebGL)
            {
                return;
            }
            
            AudioConfiguration audioConfiguration = AudioConfiguration.GetInstance();
            AudioDatabase database = audioConfiguration.GetDatabase();
            
            string audioFolder = "StreamingAssets/Audio";
            CreateFolder(pathToBuildProject, audioFolder);
            
            string rootPath = pathToBuildProject + "/" + audioFolder;

            foreach (AudioData data in database.Items)
            {
                if (string.IsNullOrEmpty(data.Key) || string.IsNullOrEmpty(data.Name))
                {
                    continue;
                }

                CreateFolder(rootPath, data.FolderPath);

                string assetDataPath = "Assets/" + data.FolderPath + "/" + data.Name;
                string newDataPath = rootPath + "/" + data.FolderPath + "/" + data.Name;
                
                assetDataPath = assetDataPath.Replace(@"\", "/");
                newDataPath = newDataPath.Replace(@"\", "/");
                
                AssetDatabase.CopyAsset(assetDataPath , newDataPath);
                FileUtil.DeleteFileOrDirectory(newDataPath + ".meta");
            }
        }

        private static void CreateFolder(string root, string path)
        {
            char separator = Char.Parse("/");

            path = path.Replace(@"\", "/");
            string[] directory = path.Split(separator);
            string directoryPath = root;
            
            Debug.Log("CREATE FOLDER root: " + root + " path:" + path);

            for (int index = 0; index < directory.Length; index++)
            {
                string newDirectoryPath = directoryPath + "/" + directory[index];
                
                if (Directory.Exists(newDirectoryPath) == false)
                {
                    Directory.CreateDirectory(newDirectoryPath);
                    
                    Debug.Log("NOT Exists FOLDER: " + newDirectoryPath);
                    Debug.Log("CREATE FOLDER: " + newDirectoryPath);
                }

                directoryPath = newDirectoryPath;
            }
        }
    }
}