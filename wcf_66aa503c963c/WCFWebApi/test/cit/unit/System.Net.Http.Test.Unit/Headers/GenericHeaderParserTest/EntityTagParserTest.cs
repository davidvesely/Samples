﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http.Headers;

namespace Microsoft.Net.Http.Test.Headers.GenericHeaderParserTest
{
    [TestClass]
    public class EntityTagParserTest
    {
        [TestMethod]
        public void Properties_ReadValues_MatchExpectation()
        {
            HttpHeaderParser parser = GenericHeaderParser.MultipleValueEntityTagParser;
            Assert.IsTrue(parser.SupportsMultipleValues, "SupportsMultipleValues");
            Assert.IsNull(parser.Comparer, "Comparer");

            parser = GenericHeaderParser.SingleValueEntityTagParser;
            Assert.IsFalse(parser.SupportsMultipleValues, "SupportsMultipleValues");
            Assert.IsNull(parser.Comparer, "Comparer");
        }

        [TestMethod]
        public void TryParse_SetOfValidValueStrings_ParsedCorrectly()
        {
            CheckValidParsedValue("\"tag\"", 0, new EntityTagHeaderValue("\"tag\""), 5, true);
            CheckValidParsedValue("\"tag\"", 0, new EntityTagHeaderValue("\"tag\""), 5, false);
            CheckValidParsedValue("*", 0, EntityTagHeaderValue.Any, 1, true);
            CheckValidParsedValue(" *  ,", 1, EntityTagHeaderValue.Any, 5, true);
            CheckValidParsedValue(" \"tag\" ", 0, new EntityTagHeaderValue("\"tag\""), 7, false);
            CheckValidParsedValue(" \"tag\" ,", 0, new EntityTagHeaderValue("\"tag\""), 8, true);
            CheckValidParsedValue("\r\n \"tag\"\r\n ", 0, new EntityTagHeaderValue("\"tag\""), 11, false);
            CheckValidParsedValue("\r\n \"tag\"\r\n ,  ", 0, new EntityTagHeaderValue("\"tag\""), 14, true);
            CheckValidParsedValue("!\"tag\"", 1, new EntityTagHeaderValue("\"tag\""), 6, false);
            CheckValidParsedValue("!\"tag\"", 1, new EntityTagHeaderValue("\"tag\""), 6, true);
            CheckValidParsedValue("//\"tag会\"", 2, new EntityTagHeaderValue("\"tag会\""), 8, false);
            CheckValidParsedValue("//\"tag会\"", 2, new EntityTagHeaderValue("\"tag会\""), 8, true);
            CheckValidParsedValue("!W/\"tag\"", 1, new EntityTagHeaderValue("\"tag\"", true), 8, false);
            CheckValidParsedValue("!W/\"tag\",", 1, new EntityTagHeaderValue("\"tag\"", true), 9, true);

            CheckValidParsedValue(null, 0, null, 0, true);
            CheckValidParsedValue(string.Empty, 0, null, 0, true);
            CheckValidParsedValue("   ", 0, null, 3, true);
            CheckValidParsedValue("  ,,", 0, null, 4, true);
        }

        [TestMethod]
        public void TryParse_SetOfInvalidValueStrings_ReturnsFalse()
        {
            CheckInvalidParsedValue(null, 0, false);
            CheckInvalidParsedValue(string.Empty, 0, false);
            CheckInvalidParsedValue("  ", 0, false);
            CheckInvalidParsedValue(" *  !", 2, false);
            CheckInvalidParsedValue(" \"tag\"  !", 2, false);
            CheckInvalidParsedValue("!\"tag\"", 0, false);
            CheckInvalidParsedValue("\"tag\",", 0, false);
            CheckInvalidParsedValue("\"tag\" \"tag2\"", 0, false);
            CheckInvalidParsedValue("W/\"tag\"", 1, false);
            CheckInvalidParsedValue("*", 0, false); // "any" is not allowed as ETag value.
        }

        #region Helper methods

        private void CheckValidParsedValue(string input, int startIndex, EntityTagHeaderValue expectedResult,
            int expectedIndex, bool supportsMultipleValues)
        {
            HttpHeaderParser parser = null;
            if (supportsMultipleValues)
            {
                parser = GenericHeaderParser.MultipleValueEntityTagParser;
            }
            else
            {
                parser = GenericHeaderParser.SingleValueEntityTagParser;
            }

            object result = null;
            Assert.IsTrue(parser.TryParseValue(input, null, ref startIndex, out result),
                "TryParse returned false. Input: '{0}', AllowMultipleValues/Any: {1}", input,
                supportsMultipleValues);
            Assert.AreEqual(expectedIndex, startIndex, "Returned index.");
            Assert.AreEqual(result, expectedResult, "Result doesn't match expected object. Input: '{0}'", input);
        }

        private void CheckInvalidParsedValue(string input, int startIndex, bool supportsMultipleValues)
        {
            HttpHeaderParser parser = null;
            if (supportsMultipleValues)
            {
                parser = GenericHeaderParser.MultipleValueEntityTagParser;
            }
            else
            {
                parser = GenericHeaderParser.SingleValueEntityTagParser;
            }

            object result = null;
            int newIndex = startIndex;
            Assert.IsFalse(parser.TryParseValue(input, null, ref newIndex, out result),
                "TryParse returned true. Input: '{0}', AllowMultipleValues/Any: {1}", input,
                supportsMultipleValues);
            Assert.AreEqual(null, result, "Parsed value");
            Assert.AreEqual(startIndex, newIndex, "Returned index");
        }

        #endregion
    }
}
