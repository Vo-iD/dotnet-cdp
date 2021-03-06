﻿using System;
using NUnit.Framework;

namespace StringCalculatorKata
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Should_Return_Zero_If_Was_Empty_String()
        {
            Assert.AreEqual(0, _calculator.Add(string.Empty));
        }

        [Test]
        public void Should_Return_Number_If_Was_Single_Number()
        {
            Assert.AreEqual(5, _calculator.Add("5"));
        }

        [Test]
        public void Should_Return_Sum_Of_Two_Numbers()
        {
            Assert.AreEqual(6, _calculator.Add("5,1"));
        }

        [TestCase("1,2,3,4", 10)]
        [TestCase("0,0,0,0,0", 0)]
        [TestCase("0,0,0,5,0", 5)]
        [TestCase("0,0,0,5,0,1,1,1,1,1", 10)]
        public void Should_Return_Sum_Of_Unkown_Amount_Of_Numbers(string input, int expected)
        {
            Assert.AreEqual(expected, _calculator.Add(input));
        }

        [TestCase("1\n2,3", 6)]
        [TestCase("1\n2\n3", 6)]
        [TestCase("1,0\n0", 1)]
        public void Should_Handle_New_Lines_Between_Numbers(string input, int expected)
        {
            Assert.AreEqual(expected, _calculator.Add(input));
        }

        [TestCase("//;\n1;2;3", 6)]
        [TestCase("//*\n1*2*3", 6)]
        public void Should_Support_Different_Delimiters(string input, int expected)
        {
            Assert.AreEqual(expected, _calculator.Add(input));
        }

        [Test]
        public void Should_Not_Support_Negative_Numbers()
        {
            Assert.Throws<ArgumentException>(() => _calculator.Add("//*\n1*-2*3"));
        }

        [TestCase("1,1001,3,4", 8)]
        [TestCase("1,1000,3,4", 1008)]
        [TestCase("1,1002,1003,1004", 1)]
        public void Should_Ignore_Numbers_More_Than_Thousand(string input, int expected)
        {
            Assert.AreEqual(expected, _calculator.Add(input));
        }

        [TestCase("//[;;]\n1;;2;;3", 6)]
        [TestCase("//[*******]\n1*******2*******3", 6)]
        [TestCase("//[*;;*]\n1*;;*2*;;*3", 6)]
        public void Should_Support_Delimiters_With_Any_Length(string input, int expected)
        {
            Assert.AreEqual(expected, _calculator.Add(input));
        }

        [TestCase("//[;][*]\n1;2*3", 6)]
        [TestCase("//[**][;;][n]\n1**2;;3n1", 7)]
        public void Should_Allow_Multiple_Delimiters(string input, int expected)
        {
            Assert.AreEqual(expected, _calculator.Add(input));
        }
    }
}
