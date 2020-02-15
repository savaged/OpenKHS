using System;

namespace OpenKHS.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class HiddenAttribute : Attribute
    {
        public bool Value = true;
    }
}
