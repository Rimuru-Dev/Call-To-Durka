using System;
using System.IO;
using Plugins.Audio.Core;
using UnityEditor;
using UnityEngine;
using AudioConfiguration = Plugins.Audio.Core.AudioConfiguration;

namespace Plugins.Audio.Editor
{
    public class AudioManagementEditorWindow : EditorWindow
    {
        private AudioConfiguration _audioConfiguration;

        private Vector2 _scrollPosition;
        private string _search;
        
        [MenuItem("Tools/Audio Management")]
        public static void Open()
        {
            AudioManagementEditorWindow window = GetWindow<AudioManagementEditorWindow>("Audio Editor");
        }

        private void OnGUI()
        {
            if (_audioConfiguration == null)
            {
                _audioConfiguration = AudioConfiguration.GetInstance();
            }

            if (_audioConfiguration.HasDatabase())
            {
                DrawMainScreen();
            }
            else
            {
                DrawBeginScreen();
            }
 
        }

        private void DrawMainScreen()
        {
            AudioDatabase database = _audioConfiguration.GetDatabase();
        
            Rect toolbarRect = Rect.zero;
            toolbarRect.size = new Vector2(position.size.x, EditorGUIUtility.singleLineHeight) - Vector2.right * 0;
            toolbarRect.position = new Vector2(position.size.x * 0.5f - toolbarRect.size.x * 0.5f, 0);
        
            GUILayout.BeginArea(toolbarRect);
            GUILayout.BeginHorizontal();
        
            if (GUILayout.Button("Database", EditorStyles.toolbarPopup, GUILayout.Width(100)))
            {
                Rect menuRect = Rect.zero;
                menuRect.y = toolbarRect.height;

                menuRect = GUIUtility.GUIToScreenRect(menuRect);
                MenuPopup menuPopup = EditorWindow.CreateInstance<MenuPopup>();
                menuPopup.OnCreateDatabase(CreateDatabase);
                menuPopup.OnOpenDatabase(OpenDatabase);
                
                menuPopup.position = menuRect;
                menuPopup.ShowAsDropDown(menuRect, new Vector2(120, 60));
            }


            if (GUILayout.Button("Add Clip", EditorStyles.toolbarButton, GUILayout.Width(100)))
            {
                AddData();
            }
            
            if (GUILayout.Button("Add All Clips", EditorStyles.toolbarButton, GUILayout.Width(100)))
            {
                AddAllClips();
            }

            EditorGUILayout.Separator();
            _search = EditorGUILayout.TextField(_search, EditorStyles.toolbarSearchField);

            GUILayout.EndHorizontal();
            GUILayout.EndArea();
            

            Rect listRECT = Rect.zero;
            listRECT.position = new Vector2(position.size.x * 0.5f - (position.size.x - 50) * 0.5f, toolbarRect.position.y + toolbarRect.size.y + 20);
            listRECT.size = new Vector2(position.size.x - 50, position.size.y - listRECT.position.y);

            GUILayout.BeginArea(listRECT);
        
            Rect boxRect = Rect.zero;
            boxRect.size = new Vector2(position.size.x - 100, 30);
            boxRect.position = new Vector2(position.size.x * 0.5f - boxRect.size.x * 0.5f, (boxRect.size.y + 10));
        
            GUILayout.BeginHorizontal();
        
            EditorGUILayout.LabelField("Key");
            EditorGUILayout.LabelField(EditorGUIUtility.IconContent("d_preaudioautoplayoff", "Preload Audio"), GUIStyle.none,  GUILayout.Width(20));

            EditorGUILayout.LabelField("Clip");
        
            GUILayout.Box(GUIContent.none, GUILayout.Width(30 + 13));
            GUILayout.EndHorizontal();
        
            _scrollPosition = GUILayout.BeginScrollView(_scrollPosition, false, true);

            for (int index = 0; index < database.Items.Count; index++)
            {
                AudioData data = database.Items[index];

                if (string.IsNullOrEmpty(_search) == false && data.Key.ToLower().Contains(_search.ToLower()) == false)
                {
                    continue;
                }
                
                GUILayout.BeginHorizontal();
            
                string key = EditorGUILayout.TextField(data.Key);
                if (data.Key != key)
                {
                    data.Key = key;
                    Save();
                }
                
                bool preload = EditorGUILayout.Toggle(data.Preload, GUILayout.Width(20));
                if (data.Preload != preload)
                {
                    data.Preload = preload;
                    Save();
                }
                
                
                AudioClip clip = EditorGUILayout.ObjectField( data.Clip, typeof(AudioClip), false) as AudioClip;
                if (data.Clip != clip)
                {
                    data.Clip = clip;
                    Save();
                }
                
                RefreshAudioDataInfo(data);

                if(GUILayout.Button(EditorGUIUtility.IconContent("Toolbar Minus"), GUILayout.Width(30)))
                {
                    if (EditorUtility.DisplayDialog("Delete Data", "Are you sure you want to delete the data?", "Delete", "Cancel"))
                    {
                        DeleteData(index);
                    }
                }

                GUILayout.EndHorizontal();
            
                if (data.Clip != null)
                {
                    string extension = Path.GetExtension(data.Name);

                    if (data.FolderPath.Contains("Resources"))
                    {
                        EditorGUILayout.HelpBox("The clip is in the Resources folder, move it", MessageType.Error);
                    }
                    else if (extension != ".mp3")
                    {
                        EditorGUILayout.HelpBox("Please use mp3 audio format", MessageType.Warning);
                    }
                }

                if (string.IsNullOrEmpty(data.Key))
                {
                    EditorGUILayout.HelpBox("Please fill in the key field", MessageType.Error);
                }
                else if (data.Clip == null)
                {
                    EditorGUILayout.HelpBox("Please fill in the clip field", MessageType.Error);
                }
            
                GUILayout.Space(EditorGUIUtility.singleLineHeight);
            }

            GUILayout.EndScrollView();

            GUILayout.EndArea();
        }

        private void RefreshAudioDataInfo(AudioData data)
        {
            if (data.Clip != null)
            {
                string assetPath = AssetDatabase.GetAssetPath(data.Clip);
                string dataName = Path.GetFileName(assetPath);
                
                string folderPath = Path.GetRelativePath("Assets", assetPath);
                folderPath = folderPath.Remove(folderPath.Length - dataName.Length, dataName.Length);

                data.Name = dataName;
                data.FolderPath = folderPath;

                if (string.IsNullOrEmpty(data.ID))
                {
                    data.GenerateID();
                }
            }
            else
            {
                data.FolderPath = String.Empty;
                data.Name = String.Empty;
            }
        }

        private void DrawBeginScreen()
        {
            Rect rect = Rect.zero;
            rect.size = new Vector2(300, 100);
            rect.position = position.size * 0.5f - rect.size * 0.5f;
        
            GUILayout.BeginArea(rect);
        
            GUILayout.BeginVertical();
            if (GUILayout.Button("Create Database", GUILayout.Height(40)))
            {
                CreateDatabase();
            }
        
            GUILayout.Space(EditorGUIUtility.singleLineHeight);
        
            if (GUILayout.Button("Open Database", GUILayout.Height(40)))
            {
                OpenDatabase();
            }
        
            GUILayout.EndVertical();
            GUILayout.EndArea();
        }

        private void AddData()
        {
            if (_audioConfiguration.HasDatabase() == false)
            {
                return;
            }

            AudioDatabase database = _audioConfiguration.GetDatabase();
            database.AddData();
                
            Save();
            AssetDatabase.SaveAssets();
        }

        private void DeleteData(int index)
        {
            if (_audioConfiguration.HasDatabase() == false)
            {
                return;
            }

            AudioDatabase database = _audioConfiguration.GetDatabase();
            database.DeleteDta(index);

            Save();
            AssetDatabase.SaveAssets();
        }

        private void CreateDatabase()
        {
            string path = EditorUtility.SaveFilePanelInProject("Save Audio Database", "Audio Database", "asset", "");

            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            AudioDatabase database = CreateInstance<AudioDatabase>();
            AssetDatabase.CreateAsset(database, path);
            
            _audioConfiguration.SetDatabase(database);
            
            Save();
            AssetDatabase.SaveAssets();
        }

        private void OpenDatabase()
        {
            string path = EditorUtility.OpenFilePanel("Select Audio Database", "Assets", "asset");
            
            if (string.IsNullOrEmpty(path) == false)
            {   
                path = "Assets/" + Path.GetRelativePath("Assets", path);
            
                AudioDatabase assetDatabase = AssetDatabase.LoadAssetAtPath<AudioDatabase>(path);
                if (assetDatabase != null)
                {
                    _audioConfiguration.SetDatabase(assetDatabase);
                
                    Save();
                    AssetDatabase.SaveAssets();
                }
                else
                {
                    EditorUtility.DisplayDialog("Error", "Asset is not an Audio database", "cancel");
                }
            }
        }

        private void AddAllClips()
        {
            if (EditorUtility.DisplayDialog("Get all clips", "Аll data will be deleted, continue?", "continue", "cancel") == false)
            {
                return;
            }
        
            AudioDatabase database = _audioConfiguration.GetDatabase();
            database.Clear();
            
            string[] allPaths = AssetDatabase.GetAllAssetPaths();

            foreach (string assetPath in allPaths)
            {
                AudioClip audioClip = AssetDatabase.LoadAssetAtPath<AudioClip>(assetPath);

                if (audioClip != null)
                {
                    database.AddData(assetPath, audioClip);
                }
            }

            Save();
            AssetDatabase.SaveAssets();
        }

        private void Save()
        {
            AudioDatabase database = _audioConfiguration.GetDatabase();

            EditorUtility.SetDirty(database);
            EditorUtility.SetDirty(_audioConfiguration);
        
            SaveChanges();
        }
    }
}
