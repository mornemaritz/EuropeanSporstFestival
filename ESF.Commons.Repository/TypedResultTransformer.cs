using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Transform;
using System.Collections;

namespace ESF.Commons.Repository
{
    public class TypedResultTransformer<T1> : IResultTransformer
    {
        public object TransformTuple(object[] tuple, string[] aliases)
        {
            if (tuple.Length == 1)
            {
                return tuple[0];
            }

            return Activator.CreateInstance(typeof(T1), tuple);
        }

        IList IResultTransformer.TransformList(IList collection)
        {
            return collection;
        }
    }
}
