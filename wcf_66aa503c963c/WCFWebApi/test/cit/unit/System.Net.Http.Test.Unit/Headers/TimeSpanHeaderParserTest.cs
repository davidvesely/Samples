﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http.Headers;

namespace System.Net.Http.Test.Headers
{
    [TestClass]
    public class TimeSpanHeaderParserTest
    {
        [TestMethod]
        public void Properties_ReadValues_MatchExpectation()
        {
            TimeSpanHeaderParser parser = TimeSpanHeaderParser.Parser;
            Assert.IsFalse(parser.SupportsMultipleValues, "SupportsMultipleValues");
            Assert.IsNull(parser.Comparer, "Comparer");
        }

        [TestMethod]
        public void Parse_ValidValue_ReturnsLongValue()
        {
            // This test verifies that Parse() correctly calls TryParse().
            TimeSpanHeaderParser parser = TimeSpanHeaderParser.Parser;
            int index = 2;
            Assert.AreEqual(new TimeSpan(0, 0, 15), parser.ParseValue("  15", null, ref index), "Value length.");
            Assert.AreEqual(4, index, "Returned index (startIndex: 2).");

            index = 0;
            Assert.AreEqual(new TimeSpan(0, 0, 30), parser.ParseValue("  030", null, ref index), "Value length.");
            Assert.AreEqual(5, index, "Returned index (startIndex: 0).");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Parse_InvalidValue_Throw()
        {
            // This test verifies that Parse() correctly calls TryParse().
            TimeSpanHeaderParser parser = TimeSpanHeaderParser.Parser;
            int index = 0;
            parser.ParseValue("a", null, ref index);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Parse_NullValue_Throw()
        {
            TimeSpanHeaderParser parser = TimeSpanHeaderParser.Parser;
            int index = 0;
            parser.ParseValue(null, null, ref index);
        }

        [TestMethod]
        public void TryParse_SetOfValidValueStrings_ParsedCorrectly()
        {
            CheckValidParsedValue("1234567890", 0, new TimeSpan(0, 0, 1234567890), 10);
            CheckValidParsedValue("0", 0, new TimeSpan(0, 0, 0), 1);
            CheckValidParsedValue("000015", 0, new TimeSpan(0, 0, 15), 6);
            CheckValidParsedValue(" 123 \t\r\n ", 0, new TimeSpan(0, 0, 123), 9);
            CheckValidParsedValue("a 5 \r\n ", 1, new TimeSpan(0, 0, 5), 7);
            CheckValidParsedValue(" 987", 0, new TimeSpan(0, 0, 987), 4);
            CheckValidParsedValue("987 ", 0, new TimeSpan(0, 0, 987), 4);
            CheckValidParsedValue("a456", 1, new TimeSpan(0, 0, 456), 4);
            CheckValidParsedValue("a456 ", 1, new TimeSpan(0, 0, 456), 5);
            CheckValidParsedValue("2147483647", 0, new TimeSpan(0, 0, int.MaxValue), 10);
        }

        [TestMethod]
        public void TryParse_SetOfInvalidValueStrings_ReturnsFalse()
        {
            CheckInvalidParsedValue("", 0);
            CheckInvalidParsedValue("  ", 2);
            CheckInvalidParsedValue("a", 0);
            CheckInvalidParsedValue(".123", 0);
            CheckInvalidParsedValue(".", 0);
            CheckInvalidParsedValue("12a", 0);
            CheckInvalidParsedValue("a12b", 1);
            CheckInvalidParsedValue("123 1", 0);
            CheckInvalidParsedValue("123.1", 0);
            CheckInvalidParsedValue(" 123 1", 0);
            CheckInvalidParsedValue("a 123 1", 1);
            CheckInvalidParsedValue("a 123 1 ", 1);
            CheckInvalidParsedValue("-123.1", 0);
            CheckInvalidParsedValue("-123", 0);
            CheckInvalidParsedValue("123456789012345678901234567890", 0); // value >> Int32.MaxValue
            CheckInvalidParsedValue("2147483648", 0); // value = Int32.MaxValue + 1
        }

        [TestMethod]
        public void ToString_UseDifferentValues_MatchExpectation()
        {
            TimeSpanHeaderParser parser = TimeSpanHeaderParser.Parser;

            Assert.AreEqual("123", parser.ToString(new TimeSpan(0, 2, 3)));
            Assert.AreEqual("0", parser.ToString(new TimeSpan(0, 0, 0)));
        }

        #region Helper methods

        private void CheckValidParsedValue(string input, int startIndex, TimeSpan expectedResult, int expectedIndex)
        {
            TimeSpanHeaderParser parser = TimeSpanHeaderParser.Parser;
            object result = 0;
            Assert.IsTrue(parser.TryParseValue(input, null, ref startIndex, out result), "TryParse returned false: {0}",
                input);
            Assert.AreEqual(expectedResult, result, "Parsed value.");
            Assert.AreEqual(expectedIndex, startIndex, "Returned index.");
        }

        private void CheckInvalidParsedValue(string input, int startIndex)
        {
            TimeSpanHeaderParser parser = TimeSpanHeaderParser.Parser;
            object result = 0;
            int newIndex = startIndex;
            Assert.IsFalse(parser.TryParseValue(input, null, ref newIndex, out result), "TryParse returned true: {0}",
                input);
            Assert.AreEqual(null, result, "Parsed value.");
            Assert.AreEqual(startIndex, newIndex, "Returned index.");
        }

        #endregion
    }
}
