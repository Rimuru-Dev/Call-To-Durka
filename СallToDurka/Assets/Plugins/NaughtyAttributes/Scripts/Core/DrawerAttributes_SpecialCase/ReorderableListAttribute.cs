using System;

namespace Plugins.NaughtyAttributes.Scripts.Core.DrawerAttributes_SpecialCase
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ReorderableListAttribute : SpecialCaseDrawerAttribute
    {
    }
}
