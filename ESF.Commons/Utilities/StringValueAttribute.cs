using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESF.Commons.Utilities
{
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
