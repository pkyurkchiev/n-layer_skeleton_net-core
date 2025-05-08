namespace NTS.Utils.Extensions
{
    using System;
    using System.ComponentModel;
    using System.Reflection;

    public static class EnumUtils
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            if (fieldInfo == null) return null;
            var attribute = fieldInfo.GetCustomAttribute<DescriptionAttribute>();
            return attribute.Description;
        }
    }
}