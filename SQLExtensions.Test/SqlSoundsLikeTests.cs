using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SQLExtensions.Test
{
    [TestFixture]
    public class SqlSoundsLikeTests
    {
        /// <remarks>
        /// Ideally, we would be checking the metaphone algorithm, but this is a good start.
        /// </remarks>
        [Test]
        public void MetaPhone_Primary_Key_For_Data_Returns()
        {
            Assert.AreEqual("JNTR",SqlSoundsLike.Metaphone("janitor"));
        }

        [Test]
        public void MetaPhone_Primary_Key_Returns_Null_On_Null_Input()
        {
            Assert.AreEqual(null, SqlSoundsLike.Metaphone(null));
        }

        [Test]
        public void MetaPhone_Alternate_Key_For_Data_Returns()
        {
           //should probably figure out what should return here (not all works have an alternate key).
        }

        [Test]
        public void MetaPhone_ShortKey_Returns_Zero_For_Null_Or_Empty_Data()    
        {
            Assert.AreEqual(0, SqlSoundsLike.ShortMetaphone(null));
            Assert.AreEqual(0, SqlSoundsLike.ShortMetaphone(""));
        }

        [Test]
        public void MetaPhone_AlternateShortKey_Returns_Zero_For_Null_Or_Empty_Data()
        {
            Assert.AreEqual(0, SqlSoundsLike.ShortMetaphoneAlternate(null));
            Assert.AreEqual(0, SqlSoundsLike.ShortMetaphoneAlternate(""));
        }

    }
}
