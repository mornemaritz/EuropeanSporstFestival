using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESF.Commons.Exceptions
{
    public class AssertionFailedException : Exception
    {
        public AssertionFailedException(string message)
            : base(message)
        { }
    }
}
