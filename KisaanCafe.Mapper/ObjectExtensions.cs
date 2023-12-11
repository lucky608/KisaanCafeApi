using KisaanCafe.Mapper;
using System;

    public static class ObjectExtensions
    {
        public static T ThrowIfNull<T>(this T value, string parameterName) where T : class
        {
            if (value is null == false)
                return value;
            throw new ArgumentNullException(parameterName);
        }

        public static T ThrowIfArgumentNull<T>(this T value, string variableName) where T : class
        {
            if (value is null == false)
                return value;
            throw new ArgumentNullException(variableName);
        }

        public static string ThrowIfNullOrSpace(this string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(parameterName);
            return value;
        }
    }

