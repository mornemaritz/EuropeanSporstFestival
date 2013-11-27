using System;
using ESF.Commons.Utilities;
using NUnit.Framework;

namespace ESF.Commons.Tests
{
    [TestFixture]
    public class ExtensionsTests
    {
        [Test]
        public void DateTimeBetweenReturnsTrueIfDateIsBetweenSpecifiedDates()
        {
            var minDate = new DateTime(2001, 01, 01, 12,00,00);
            var maxDate = new DateTime(2001, 02, 01, 12, 00, 00);
            var testDate = new DateTime(2001, 02, 01, 08, 00, 00);

            Assert.IsTrue(testDate.FallsBetween(minDate, maxDate));
        }

        [Test]
        public void DateTimeBetweenReturnsFalseIfDateIsNotBetweenSpecifiedDates()
        {
            var minDate = new DateTime(2001, 01, 01, 12, 00, 00);
            var maxDate = new DateTime(2001, 02, 01, 12, 00, 00);
            var testDate = new DateTime(2001, 03, 01, 08, 00, 00);

            Assert.IsFalse(testDate.FallsBetween(minDate, maxDate));
        }
    }
}
