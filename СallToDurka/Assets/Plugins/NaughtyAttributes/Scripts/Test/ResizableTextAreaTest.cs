using Plugins.NaughtyAttributes.Scripts.Core.DrawerAttributes;
using UnityEngine;

namespace Plugins.NaughtyAttributes.Scripts.Test
{
    public class ResizableTextAreaTest : MonoBehaviour
    {
        [ResizableTextArea]
        public string text0;

        public ResizableTextAreaNest1 nest1;
    }

    [System.Serializable]
    public class ResizableTextAreaNest1
    {
        [ResizableTextArea]
        public string text1;

        public ResizableTextAreaNest2 nest2;
    }

    [System.Serializable]
    public class ResizableTextAreaNest2
    {
        [ResizableTextArea]
        public string text2;
    }
}
