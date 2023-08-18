using Plugins.NaughtyAttributes.Scripts.Core.DrawerAttributes;
using UnityEngine;

namespace Plugins.NaughtyAttributes.Scripts.Test
{
    //[CreateAssetMenu(fileName = "TestScriptableObjectB", menuName = "NaughtyAttributes/TestScriptableObjectB")]
    public class _TestScriptableObjectB : ScriptableObject
    {
        [MinMaxSlider(0, 10)]
        public Vector2Int slider;
    }
}