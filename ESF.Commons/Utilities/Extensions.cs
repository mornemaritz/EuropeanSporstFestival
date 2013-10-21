using System;

namespace ESF.Commons.Utilities
{
    public static class Extensions
    {
        /// <summary>
        /// Gets the value that has been specified as the StringValue attribute of the current enum value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The value assigned to the StringValue attribute. If there is no value assigned, the enum value is returned as a string.</returns>
        public static string GetStringValue(this Enum value)
        {
            var stringValueAttributes = GetStringValueAttributes(value);

            return (stringValueAttributes != null && stringValueAttributes.Length > 0) 
                ? stringValueAttributes[0].StringValue 
                : value.ToString();
        }

        private static StringValueAttribute[] GetStringValueAttributes(object value)
        {
            var type = value.GetType();
            if (!type.IsEnum) return null;

            var fieldInfo = type.GetField(value.ToString());
            Check.IsNotNull(fieldInfo, string.Format("Cannot find enum value '{0}' in '{1}'", value, type.UnderlyingSystemType.Name));

            var customAttributes = fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false);

            if (customAttributes != null)
                return customAttributes as StringValueAttribute[];

            return null;
        }
    }

    /// <summary>
    /// Holds a string value for an enum can contain characters that are not allowed in the enum values themselves. (spaces and dashes for example)
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class StringValueAttribute : Attribute
    {
        public string StringValue { get; private set; }

        public StringValueAttribute(string stringValue)
        {
            StringValue = stringValue;
        }
    }
}
