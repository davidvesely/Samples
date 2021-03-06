﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http.Headers;
using System.Net.Test.Common;

namespace System.Net.Http.Test.Headers
{
    [TestClass]
    public class TransferCodingHeaderValueTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Ctor_ValueNull_Throw()
        {
            new TransferCodingHeaderValue(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Ctor_ValueEmpty_Throw()
        {
            // null and empty should be treated the same. So we also throw for empty strings.
            new TransferCodingHeaderValue(string.Empty);
        }

        [TestMethod]
        public void Ctor_TransferCodingInvalidFormat_ThrowFormatException()
        {
            // When adding values using strongly typed objects, no leading/trailing LWS (whitespaces) are allowed.
            AssertFormatException(" custom ");
            AssertFormatException("custom;");
            AssertFormatException("chänked");
            AssertFormatException("\"chunked\"");
            AssertFormatException("custom; name=value");
        }

        [TestMethod]
        public void Ctor_TransferCodingValidFormat_SuccessfullyCreated()
        {
            TransferCodingHeaderValue transferCoding = new TransferCodingHeaderValue("custom");
            Assert.AreEqual("custom", transferCoding.Value, "Value");
            Assert.AreEqual(0, transferCoding.Parameters.Count, "Parameters.Count");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Parameters_AddNull_Throw()
        {
            TransferCodingHeaderValue transferCoding = new TransferCodingHeaderValue("custom");
            transferCoding.Parameters.Add(null);
        }

        [TestMethod]
        public void ToString_UseDifferentTransferCodings_AllSerializedCorrectly()
        {
            TransferCodingHeaderValue transferCoding = new TransferCodingHeaderValue("custom");
            Assert.AreEqual("custom", transferCoding.ToString());

            transferCoding.Parameters.Add(new NameValueHeaderValue("paramName", "\"param value\""));
            Assert.AreEqual("custom; paramName=\"param value\"", transferCoding.ToString());

            transferCoding.Parameters.Add(new NameValueHeaderValue("paramName2", "\"param value2\""));
            Assert.AreEqual("custom; paramName=\"param value\"; paramName2=\"param value2\"", 
                transferCoding.ToString());
        }

        [TestMethod]
        public void GetHashCode_UseTransferCodingWithAndWithoutParameters_SameOrDifferentHashCodes()
        {
            TransferCodingHeaderValue transferCoding1 = new TransferCodingHeaderValue("custom");
            TransferCodingHeaderValue transferCoding2 = new TransferCodingHeaderValue("CUSTOM");
            TransferCodingHeaderValue transferCoding3 = new TransferCodingHeaderValue("custom");
            transferCoding3.Parameters.Add(new NameValueHeaderValue("name", "value"));
            TransferCodingHeaderValue transferCoding4 = new TransferCodingHeaderValue("custom");
            transferCoding4.Parameters.Add(new NameValueHeaderValue("NAME", "VALUE"));
            TransferCodingHeaderValue transferCoding5 = new TransferCodingHeaderValue("custom");
            transferCoding5.Parameters.Add(new NameValueHeaderValue("name", "\"value\""));
            TransferCodingHeaderValue transferCoding6 = new TransferCodingHeaderValue("custom");
            transferCoding6.Parameters.Add(new NameValueHeaderValue("name", "\"VALUE\""));
            TransferCodingHeaderValue transferCoding7 = new TransferCodingHeaderValue("custom");
            transferCoding7.Parameters.Add(new NameValueHeaderValue("name", "\"VALUE\""));
            transferCoding7.Parameters.Clear();

            Assert.AreEqual(transferCoding1.GetHashCode(), transferCoding2.GetHashCode(), "Different casing.");
            Assert.AreNotEqual(transferCoding1.GetHashCode(), transferCoding3.GetHashCode(), 
                "No params vs. custom param.");
            Assert.AreEqual(transferCoding3.GetHashCode(), transferCoding4.GetHashCode(),
                "Params have different casing.");
            Assert.AreNotEqual(transferCoding5.GetHashCode(), transferCoding6.GetHashCode(),
                "Param value are quoted strings with different casing.");
            Assert.AreEqual(transferCoding1.GetHashCode(), transferCoding7.GetHashCode(),
                "no vs. empty parameters collection.");
        }

        [TestMethod]
        public void Equals_UseTransferCodingWithAndWithoutParameters_EqualOrNotEqualNoExceptions()
        {
            TransferCodingHeaderValue transferCoding1 = new TransferCodingHeaderValue("custom");
            TransferCodingHeaderValue transferCoding2 = new TransferCodingHeaderValue("CUSTOM");
            TransferCodingHeaderValue transferCoding3 = new TransferCodingHeaderValue("custom");
            transferCoding3.Parameters.Add(new NameValueHeaderValue("name", "value"));
            TransferCodingHeaderValue transferCoding4 = new TransferCodingHeaderValue("custom");
            transferCoding4.Parameters.Add(new NameValueHeaderValue("NAME", "VALUE"));
            TransferCodingHeaderValue transferCoding5 = new TransferCodingHeaderValue("custom");
            transferCoding5.Parameters.Add(new NameValueHeaderValue("name", "\"value\""));
            TransferCodingHeaderValue transferCoding6 = new TransferCodingHeaderValue("custom");
            transferCoding6.Parameters.Add(new NameValueHeaderValue("name", "\"VALUE\""));
            TransferCodingHeaderValue transferCoding7 = new TransferCodingHeaderValue("custom");
            transferCoding7.Parameters.Add(new NameValueHeaderValue("name", "\"VALUE\""));
            transferCoding7.Parameters.Clear();

            Assert.IsFalse(transferCoding1.Equals(null), "Compare to <null>.");
            Assert.IsTrue(transferCoding1.Equals(transferCoding2), "Different casing.");
            Assert.IsFalse(transferCoding1.Equals(transferCoding3), "No params vs. custom param.");
            Assert.IsTrue(transferCoding3.Equals(transferCoding4), "Params have different casing.");
            Assert.IsFalse(transferCoding5.Equals(transferCoding6),
                "Param value are quoted strings with different casing.");
            Assert.IsTrue(transferCoding1.Equals(transferCoding7), "no vs. empty parameters collection.");
        }

        [TestMethod]
        public void Clone_Call_CloneFieldsMatchSourceFields()
        {
            TransferCodingHeaderValue source = new TransferCodingHeaderValue("custom");
            TransferCodingHeaderValue clone = (TransferCodingHeaderValue)((ICloneable)source).Clone();
            Assert.AreEqual(source.Value, clone.Value, "Value");
            Assert.AreEqual(0, clone.Parameters.Count, "Parameters.Count");

            source.Parameters.Add(new NameValueHeaderValue("custom", "customValue"));
            clone = (TransferCodingHeaderValue)((ICloneable)source).Clone();
            Assert.AreEqual(source.Value, clone.Value, "Value");
            Assert.AreEqual(1, clone.Parameters.Count, "Parameters.Count");
            Assert.AreEqual("custom", clone.Parameters.ElementAt(0).Name, "Custom parameter name.");
            Assert.AreEqual("customValue", clone.Parameters.ElementAt(0).Value, "Custom parameter value.");
        }

        [TestMethod]
        public void GetTransferCodingLength_DifferentValidScenarios_AllReturnNonZero()
        {
            TransferCodingHeaderValue result = null;

            Assert.AreEqual(7, TransferCodingHeaderValue.GetTransferCodingLength("chunked", 0,
                DummyCreator, out result));
            Assert.AreEqual("chunked", result.Value, "Value");
            Assert.AreEqual(0, result.Parameters.Count, "Parameters.Count");

            Assert.AreEqual(5, TransferCodingHeaderValue.GetTransferCodingLength("gzip , chunked", 0,
                DummyCreator, out result));
            Assert.AreEqual("gzip", result.Value, "Value");
            Assert.AreEqual(0, result.Parameters.Count, "Parameters.Count");

            Assert.AreEqual(18, TransferCodingHeaderValue.GetTransferCodingLength("custom; name=value", 0,
                DummyCreator, out result));
            Assert.AreEqual("custom", result.Value, "Value");
            Assert.AreEqual(1, result.Parameters.Count, "Parameters.Count");
            Assert.AreEqual("name", result.Parameters.ElementAt(0).Name, "Parameters[0].Name");
            Assert.AreEqual("value", result.Parameters.ElementAt(0).Value, "Parameters[0].Value");

            // Note that TransferCodingHeaderValue recognizes the first transfer-coding as valid, even though it is
            // followed by an invalid character. The parser will call GetTransferCodingLength() starting at the invalid
            // character which will result in GetTransferCodingLength() returning 0 (see next test).
            Assert.AreEqual(26, TransferCodingHeaderValue.GetTransferCodingLength(
                " custom;name1=value1;name2 ,  会", 1, DummyCreator, out result));
            Assert.AreEqual("custom", result.Value, "Value");
            Assert.AreEqual(2, result.Parameters.Count, "Parameters.Count");
            Assert.AreEqual("name1", result.Parameters.ElementAt(0).Name, "Parameters[0].Name");
            Assert.AreEqual("value1", result.Parameters.ElementAt(0).Value, "Parameters[0].Value");
            Assert.AreEqual("name2", result.Parameters.ElementAt(1).Name, "Parameters[1].Name");
            Assert.IsNull(result.Parameters.ElementAt(1).Value, "Parameters[1].Value");

            // There will be no exception for invalid characters. GetTransferCodingLength() will just return a length
            // of 0. The caller needs to validate if that's OK or not.
            Assert.AreEqual(0, TransferCodingHeaderValue.GetTransferCodingLength("会", 0, DummyCreator, out result));

            Assert.AreEqual(45, TransferCodingHeaderValue.GetTransferCodingLength(
                "  custom ; name1 =\r\n \"value1\" ; name2 = value2 , next", 2, DummyCreator, out result));
            Assert.AreEqual("custom", result.Value, "Value");
            Assert.AreEqual(2, result.Parameters.Count, "Parameters.Count");
            Assert.AreEqual("name1", result.Parameters.ElementAt(0).Name, "Parameters[0].Name");
            Assert.AreEqual("\"value1\"", result.Parameters.ElementAt(0).Value, "Parameters[0].Value");
            Assert.AreEqual("name2", result.Parameters.ElementAt(1).Name, "Parameters[1].Name");
            Assert.AreEqual("value2", result.Parameters.ElementAt(1).Value, "Parameters[1].Value");

            Assert.AreEqual(32, TransferCodingHeaderValue.GetTransferCodingLength(
                " custom;name1=value1;name2=value2,next", 1, DummyCreator, out result));
            Assert.AreEqual("custom", result.Value, "TransferCoding");
            Assert.AreEqual(2, result.Parameters.Count, "Parameters.Count");
            Assert.AreEqual("name1", result.Parameters.ElementAt(0).Name, "Parameters[0].Name");
            Assert.AreEqual("value1", result.Parameters.ElementAt(0).Value, "Parameters[0].Value");
            Assert.AreEqual("name2", result.Parameters.ElementAt(1).Name, "Parameters[1].Name");
            Assert.AreEqual("value2", result.Parameters.ElementAt(1).Value, "Parameters[1].Value");
        }
        
        [TestMethod]
        public void GetTransferCodingLength_DifferentInvalidScenarios_AllReturnZero()
        {
            TransferCodingHeaderValue result = null;

            Assert.AreEqual(0, TransferCodingHeaderValue.GetTransferCodingLength(" custom", 0, DummyCreator,
                out result));
            Assert.IsNull(result);
            Assert.AreEqual(0, TransferCodingHeaderValue.GetTransferCodingLength("custom;", 0, DummyCreator, 
                out result));
            Assert.IsNull(result);
            Assert.AreEqual(0, TransferCodingHeaderValue.GetTransferCodingLength("custom;name=", 0, DummyCreator, 
                out result));
            Assert.IsNull(result);
            Assert.AreEqual(0, TransferCodingHeaderValue.GetTransferCodingLength("custom;name=value;", 0,
                DummyCreator, out result));
            Assert.IsNull(result);
            Assert.AreEqual(0, TransferCodingHeaderValue.GetTransferCodingLength("custom;name=,value;", 0, 
                DummyCreator, out result));
            Assert.IsNull(result);
            Assert.AreEqual(0, TransferCodingHeaderValue.GetTransferCodingLength("custom;", 0, DummyCreator, 
                out result));
            Assert.IsNull(result);
            Assert.AreEqual(0, TransferCodingHeaderValue.GetTransferCodingLength(null, 0, DummyCreator, out result));
            Assert.IsNull(result);
            Assert.AreEqual(0, TransferCodingHeaderValue.GetTransferCodingLength(string.Empty, 0, DummyCreator,
                out result));
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Parse_SetOfValidValueStrings_ParsedCorrectly()
        {
            TransferCodingHeaderValue expected = new TransferCodingHeaderValue("custom");
            CheckValidParse("\r\n custom  ", expected);
            CheckValidParse("custom", expected);

            // We don't have to test all possible input strings, since most of the pieces are handled by other parsers.
            // The purpose of this test is to verify that these other parsers are combined correctly to build a 
            // transfer-coding parser.
            expected.Parameters.Add(new NameValueHeaderValue("name", "value"));
            CheckValidParse("\r\n custom ;  name =   value ", expected);
            CheckValidParse("  custom;name=value", expected);
            CheckValidParse("  custom ; name=value", expected);
        }

        [TestMethod]
        public void Parse_SetOfInvalidValueStrings_Throws()
        {
            CheckInvalidParse("custom; name=value;");
            CheckInvalidParse("custom; name1=value1; name2=value2;");
            CheckInvalidParse(",,custom");
            CheckInvalidParse(" , , custom");
            CheckInvalidParse("\r\n custom  , chunked");
            CheckInvalidParse("\r\n custom  , , , chunked");
            CheckInvalidParse("custom , 会");
            CheckInvalidParse("\r\n , , custom ;  name =   value ");

            CheckInvalidParse(null);
            CheckInvalidParse(string.Empty);
            CheckInvalidParse("  ");
            CheckInvalidParse("  ,,");
        }

        [TestMethod]
        public void TryParse_SetOfValidValueStrings_ParsedCorrectly()
        {
            TransferCodingHeaderValue expected = new TransferCodingHeaderValue("custom");
            CheckValidTryParse("\r\n custom  ", expected);
            CheckValidTryParse("custom", expected);

            // We don't have to test all possible input strings, since most of the pieces are handled by other parsers.
            // The purpose of this test is to verify that these other parsers are combined correctly to build a 
            // transfer-coding parser.
            expected.Parameters.Add(new NameValueHeaderValue("name", "value"));
            CheckValidTryParse("\r\n custom ;  name =   value ", expected);
            CheckValidTryParse("  custom;name=value", expected);
            CheckValidTryParse("  custom ; name=value", expected);
        }

        [TestMethod]
        public void TryParse_SetOfInvalidValueStrings_ReturnsFalse()
        {
            CheckInvalidTryParse("custom; name=value;");
            CheckInvalidTryParse("custom; name1=value1; name2=value2;");
            CheckInvalidTryParse(",,custom");
            CheckInvalidTryParse(" , , custom");
            CheckInvalidTryParse("\r\n custom  , chunked");
            CheckInvalidTryParse("\r\n custom  , , , chunked");
            CheckInvalidTryParse("custom , 会");
            CheckInvalidTryParse("\r\n , , custom ;  name =   value ");

            CheckInvalidTryParse(null);
            CheckInvalidTryParse(string.Empty);
            CheckInvalidTryParse("  ");
            CheckInvalidTryParse("  ,,");
        }

        #region Helper methods

        private void CheckValidParse(string input, TransferCodingHeaderValue expectedResult)
        {
            TransferCodingHeaderValue result = TransferCodingHeaderValue.Parse(input);
            Assert.AreEqual(expectedResult, result);
        }

        private void CheckInvalidParse(string input)
        {
            ExceptionAssert.Throws<FormatException>(() => TransferCodingHeaderValue.Parse(input), input);
        }

        private void CheckValidTryParse(string input, TransferCodingHeaderValue expectedResult)
        {
            TransferCodingHeaderValue result = null;
            Assert.IsTrue(TransferCodingHeaderValue.TryParse(input, out result));
            Assert.AreEqual(expectedResult, result);
        }

        private void CheckInvalidTryParse(string input)
        {
            TransferCodingHeaderValue result = null;
            Assert.IsFalse(TransferCodingHeaderValue.TryParse(input, out result));
            Assert.IsNull(result);
        }

        private static void AssertFormatException(string transferCoding)
        {
            ExceptionAssert.ThrowsFormat(() => { new TransferCodingHeaderValue(transferCoding); },
                "name: '" + (transferCoding == null ? "<null>" : transferCoding) + "'");
        }

        private static TransferCodingHeaderValue DummyCreator()
        {
            return new TransferCodingHeaderValue();
        }

        #endregion
    }
}
