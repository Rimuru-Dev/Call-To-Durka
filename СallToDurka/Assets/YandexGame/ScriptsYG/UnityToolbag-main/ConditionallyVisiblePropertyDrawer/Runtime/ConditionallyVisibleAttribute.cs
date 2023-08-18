using UnityEngine;

namespace RimuruDev.YandexGame.ScriptsYG.UnityToolbag_main.ConditionallyVisiblePropertyDrawer.Runtime
{
    public sealed class ConditionallyVisibleAttribute : PropertyAttribute
    {
        public string propertyName { get; }
        
        public ConditionallyVisibleAttribute(string propName)
        {
            propertyName = propName;
        }
    }
}