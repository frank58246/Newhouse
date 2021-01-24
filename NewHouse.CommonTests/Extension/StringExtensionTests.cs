using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewHouse.Common.Extension;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewHouse.Common.Extension.Tests
{
    [TestClass()]
    public class StringExtensionTests
    {
        [TestMethod()]
        public void ToIntListTest_輸入單個數字_應輸出單筆數字()
        {
            // Arrange
            var input = "1000萬";
            var expected = new List<int>() { 1000 };

            // Act
            var actual = input.ToIntList();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod()]
        public void ToIntListTest_輸入多筆數字_使用dash分隔_應輸出多筆數字()
        {
            // Arrange
            var input = "1000-3000萬";
            var expected = new List<int>() { 1000, 3000 };

            // Act
            var actual = input.ToIntList();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod()]
        public void ToIntListTest_輸入多筆數字字串_使用波浪號分隔_應輸出多筆數字()
        {
            // Arrange
            var input = "1000~3000萬";
            var expected = new List<int>() { 1000, 3000 };

            // Act
            var actual = input.ToIntList();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void ToDoubleListTest_輸入單筆整數_應輸出單筆數字()
        {
            // Arrange
            var input = "24萬元/坪";
            var expected = new List<double>() { 24 };

            // Act
            var actual = input.ToDoubleList();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void ToDoubleListTest_輸入單筆小數_應輸出單筆數字()
        {
            // Arrange
            var input = "15~16.5萬元/坪";
            var expected = new List<double>() { 15, 16.5 };

            // Act
            var actual = input.ToDoubleList();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void ToDoubleListTest_輸入沒有數字_應輸出空陣列()
        {
            // Arrange
            var input = "待定";
            var expected = new List<double>() { };

            // Act
            var actual = input.ToDoubleList();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}