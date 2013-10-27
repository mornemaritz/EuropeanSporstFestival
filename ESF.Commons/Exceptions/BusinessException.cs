using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESF.Commons.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message)
            : base(message)
        { }
    }
}
