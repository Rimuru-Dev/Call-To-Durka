using System;

namespace Plugins.NaughtyAttributes.Scripts.Core.DrawerAttributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ResizableTextAreaAttribute : DrawerAttribute
    {
    }
}
