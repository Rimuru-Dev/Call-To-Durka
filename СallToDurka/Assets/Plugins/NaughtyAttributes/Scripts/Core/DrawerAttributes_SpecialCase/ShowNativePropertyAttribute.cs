using System;

namespace Plugins.NaughtyAttributes.Scripts.Core.DrawerAttributes_SpecialCase
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ShowNativePropertyAttribute : SpecialCaseDrawerAttribute
    {
    }
}
