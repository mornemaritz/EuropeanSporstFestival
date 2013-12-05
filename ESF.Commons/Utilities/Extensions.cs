using System;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        /// Returns the date in a user friendly format of "DayOfWeek, dd month yyyy", i.e., "Friday, 18 April 2014".
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static string GetUserFriendlyDate(this DateTime date)
        {
            return string.Format("{0}, {1} {2} {3}", date.DayOfWeek, date.Day, (Month)date.Month, date.Year);
        }

        /// <summary>
        /// Determines if the current date and time falls between the specified min and max date and time
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="minDate">The min date.</param>
        /// <param name="maxDate">The max date.</param>
        /// <returns></returns>
        public static bool FallsBetween(this DateTime date, DateTime minDate, DateTime maxDate)
        {
            return date >= minDate && date <= maxDate;
        }

        /// <summary>
        /// Determines whether no elements of a sequence satisfy a condition
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public static bool None<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return !source.Any(predicate);
        }
    }
}
