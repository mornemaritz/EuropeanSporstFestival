using System;
using NHibernate;
using NHibernate.Criterion;

namespace ESF.Commons.Repository
{
    public class BitwiseRestrictions : LogicalExpression
    {
        private BitwiseRestrictions(string propertyName, object value, string op) :
            base(new SimpleExpression(propertyName, value, op),
          Expression.Sql("?", value, NHibernateUtil.Enum(value.GetType())))
        {
        }

        protected override string Op
        {
            get { return "="; }
        }

        public static BitwiseRestrictions HasFlag(string propertyName, Enum flags)
        {
            return new BitwiseRestrictions(propertyName, flags, " & ");
        }
    }
}
