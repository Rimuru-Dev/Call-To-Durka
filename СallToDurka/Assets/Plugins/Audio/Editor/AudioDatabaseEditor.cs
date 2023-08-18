using RimuruDev.Plugins.Audio.Core;
using UnityEditor;
using UnityEngine;

namespace RimuruDev.Plugins.Audio.Editor
{
    [CustomEditor(typeof(AudioDatabase))]
    public class AudioDatabaseEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            GUI.enabled = false;
            
            base.OnInspectorGUI();

            GUI.enabled = true;
            
            if (GUILayout.Button("Open Audio Editor"))
            {
                AudioManagementEditorWindow.Open();
            }
        }
    }
}
