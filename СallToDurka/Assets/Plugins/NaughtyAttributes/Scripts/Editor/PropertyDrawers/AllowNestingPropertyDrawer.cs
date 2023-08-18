using Plugins.NaughtyAttributes.Scripts.Core.DrawerAttributes;
using UnityEditor;
using UnityEngine;

namespace Plugins.NaughtyAttributes.Scripts.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(AllowNestingAttribute))]
    public class AllowNestingPropertyDrawer : PropertyDrawerBase
    {
        protected override void OnGUI_Internal(Rect rect, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(rect, label, property);
            EditorGUI.PropertyField(rect, property, label, true);
            EditorGUI.EndProperty();
        }
    }
}
