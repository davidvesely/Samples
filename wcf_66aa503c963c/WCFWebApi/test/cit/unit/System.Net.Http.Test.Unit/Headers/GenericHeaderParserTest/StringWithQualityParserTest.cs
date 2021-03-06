﻿using System.Net.Http.Headers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Net.Http.Test.Headers.GenericHeaderParserTest
{
    [TestClass]
    public class StringWithQualityParserTest
    {
        [TestMethod]
        public void Properties_ReadValues_MatchExpectation()
        {
            HttpHeaderParser parser = GenericHeaderParser.MultipleValueStringWithQualityParser;
            Assert.IsTrue(parser.SupportsMultipleValues, "SupportsMultipleValues");
            Assert.IsNull(parser.Comparer, "Comparer");

            parser = GenericHeaderParser.SingleValueStringWithQualityParser;
            Assert.IsFalse(parser.SupportsMultipleValues, "SupportsMultipleValues");
            Assert.IsNull(parser.Comparer, "Comparer");
        }

        [TestMethod]
        public void TryParse_SetOfValidValueStrings_ParsedCorrectly()
        {
            CheckValidParsedValue("text", 0, new StringWithQualityHeaderValue("text"), 4);
            CheckValidParsedValue("text,", 0, new StringWithQualityHeaderValue("text"), 5);
            CheckValidParsedValue("\r\n text ; q = 0.5, next_text  ", 0, new StringWithQualityHeaderValue("text", 0.5), 19);
            CheckValidParsedValue("  text,next_text  ", 2, new StringWithQualityHeaderValue("text"), 7);
            CheckValidParsedValue(" ,, text, , ,next", 0, new StringWithQualityHeaderValue("text"), 13);
            CheckValidParsedValue(" ,, text, , ,", 0, new StringWithQualityHeaderValue("text"), 13);
            CheckValidParsedValue(", \r\n text \r\n ; \r\n q = 0.123", 0,
                new StringWithQualityHeaderValue("text", 0.123), 27);

            CheckValidParsedValue(null, 0, null, 0);
            CheckValidParsedValue(string.Empty, 0, null, 0);
            CheckValidParsedValue("  ", 0, null, 2);
            CheckValidParsedValue("  ,,", 0, null, 4);
        }

        [TestMethod]
        public void TryParse_SetOfInvalidValueStrings_ReturnsFalse()
        {
            CheckInvalidParsedValue("teäxt", 0);
            CheckInvalidParsedValue("text会", 0);
            CheckInvalidParsedValue("会", 0);
            CheckInvalidParsedValue("t;q=会", 0);
            CheckInvalidParsedValue("t;q=", 0);
            CheckInvalidParsedValue("t;q", 0);
            CheckInvalidParsedValue("t;会=1", 0);
            CheckInvalidParsedValue("t;q会=1", 0);
            CheckInvalidParsedValue("t y", 0);
            CheckInvalidParsedValue("t;q=1 y", 0);
        }

        #region Helper methods

        private void CheckValidParsedValue(string input, int startIndex, StringWithQualityHeaderValue expectedResult,
            int expectedIndex)
        {
            HttpHeaderParser parser = GenericHeaderParser.MultipleValueStringWithQualityParser;
            object result = null;
            Assert.IsTrue(parser.TryParseValue(input, null, ref startIndex, out result), "TryParse returned false: {0}",
                input);
            Assert.AreEqual(expectedIndex, startIndex, "Returned index. Input: '{0}'", input);
            Assert.AreEqual(result, expectedResult, "Result doesn't match expected object. Input: '{0}'", input);
        }

        private void CheckInvalidParsedValue(string input, int startIndex)
        {
            HttpHeaderParser parser = GenericHeaderParser.MultipleValueStringWithQualityParser;
            object result = null;
            int newIndex = startIndex;
            Assert.IsFalse(parser.TryParseValue(input, null, ref newIndex, out result), "TryParse returned true: {0}",
                input);
            Assert.AreEqual(null, result, "Parsed value");
            Assert.AreEqual(startIndex, newIndex, "Returned index");
        }

        #endregion
    }
}
