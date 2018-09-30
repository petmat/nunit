// ***********************************************************************
// Copyright (c) 2014 Charlie Poole, Rob Prouse
// 
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************

#region Using Directives

using System;
using NUnit.Framework;

#endregion

namespace NUnit.Framework.Attributes
{
    public enum EnumValues
    {
        One,
        Two,
        Three,
        Four,
        Five
    }

    [TestFixture]
    public class ValuesAttributeEnumTests
    {
        private int _countEnums;
        private int _countBools;
        private int _countNullableEnums;
        private int _countNullableBools;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _countEnums = 0;
            _countBools = 0;
            _countNullableEnums = 0;
            _countNullableBools = 0;
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Assert.That(_countEnums, Is.EqualTo(5), "The TestEnumValues method should have been called 5 times");
            Assert.That(_countBools, Is.EqualTo(2), "The TestBoolValues method should have been called twice");
            Assert.That(_countNullableEnums, Is.EqualTo(6), "The TestNullableEnum method should have been called 6 times");
            Assert.That(_countNullableBools, Is.EqualTo(3), "The TestNullableBool method should have been called thrice");
        }

        [Test]
        public void TestEnumValues([Values]EnumValues value)
        {
            _countEnums++;
        }

        [Test]
        public void TestBoolValues([Values]bool value)
        {
            _countBools++;
        }

        [Test]
        public void TestNullableEnum([Values]EnumValues? enumValue)
        {
            /* runs with null and all enum values in no particular order */
            ++_countNullableEnums;
        }

        [Test]
        public void TestNullableBool([Values] bool? testInput)
        {
            /* runs with null, true, false in no particular order */
            ++_countNullableBools;
        }
    }
}
