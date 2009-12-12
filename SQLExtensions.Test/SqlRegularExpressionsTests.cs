using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SQLExtensions.Test
{
    [TestFixture]
    public class SqlRegularExpressionsTests
    {
        [Test]
        public void IsMatch_ThrowsException_On_Null_Data()
        {
            bool test = false;
            try
            {
                SqlRegularExpressions.IsMatch(".", null);
                test = false;
            }
            catch
            {
                test = true;
            }
            Assert.IsTrue(test);
        }

        [Test]
        public void IsMatch_Doesnt_Match_Improperly()
        {
            //should match when there's a digit.
            Assert.IsTrue(SqlRegularExpressions.IsMatch(@"[\d]+","9"));
            //shouldn't match when there's no non-digits.
            Assert.IsFalse(SqlRegularExpressions.IsMatch(@"[\D]+","9"));
        }

        [Test]
        public void Match_Produces_Correct_Match_Value()
        {
            Assert.AreEqual("555", SqlRegularExpressions.Match(@"[\d]{3}","asd555-434-3ds"));
        }

        [Test]
        public void Match_Produces_Null_When_No_Match_Found()
        {
            Assert.AreEqual(null, SqlRegularExpressions.Match(@"[\a]+", "9"));
        }

        [Test]
        public void Match_Produces_Null_When_Data_Is_Null()
        {
            Assert.AreEqual(null, SqlRegularExpressions.Match(@"[\d]{3}", null));
        }

        [Test]
        public void GroupMatch_Selects_Proper_Group()
        {
            Assert.AreEqual("4343", SqlRegularExpressions.GroupMatch(@"([sd]{0,})([\d]+)(.{0,})", "sdsd4343dsds32", 2));
        }

        [Test]
        public void GroupMatch_Returns_Null_For_NonExistantGroup()
        {
            Assert.AreEqual(null, SqlRegularExpressions.GroupMatch(@"([sd]{0,})([\d]+)(.{0,})", "sdsd", 50));
        }

        [Test]
        public void GroupMatch_Returns_Null_For_EmptyGroup()
        {
            Assert.AreEqual(null, SqlRegularExpressions.GroupMatch(@"([sd]{0,})([\d]+)(.{0,})", "sdsd", 2));
        }

        [Test]
        public void RegexReplace_Replaces_All_Instances_Of_Match()
        {
            Assert.AreEqual("ab1234ab1234c",SqlRegularExpressions.RegexReplace(@"[\d]+","ab9ab9876c","1234"));
        }

        [Test]
        public void RegexReplace_Returns_Null_For_NullData()
        {
            Assert.AreEqual(null, SqlRegularExpressions.RegexReplace(@".", null, "test"));
        }
    }
}
