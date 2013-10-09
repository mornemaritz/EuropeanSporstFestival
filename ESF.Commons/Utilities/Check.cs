using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESF.Commons.Exceptions;

namespace ESF.Commons.Utilities
{
    public class Check
    {
        public static void IsNotNull(object objectToCheck, string failureMessage)
        {
            if (objectToCheck == null)
                throw new AssertionFailedException(failureMessage);
        }

        public static void IsTrue(bool valueToCheck, string failureMessage)
        {
            if (!valueToCheck)
                throw new AssertionFailedException(failureMessage);
        }
    }
}
