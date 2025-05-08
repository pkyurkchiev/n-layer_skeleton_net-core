namespace NTS.Utils.Extensions
{
    using System;
    using System.Linq;

    public static class IntegerExtensions
    {
        public static bool IsAnyNullOrEmpty(this object obj)
        {
            if (obj is null)
                return false;

            return obj.GetType().GetProperties()
                .Any(x => IsNullOrEmpty(x.GetValue(obj)));
        }

        private static bool IsNullOrEmpty(this object value)
        {
            if (value is null)
                return false;

            var type = value.GetType();
            return type.IsValueType
                && Object.Equals(value, Activator.CreateInstance(type));
        }
    }
}
