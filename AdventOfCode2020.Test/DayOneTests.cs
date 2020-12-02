using FluentAssertions;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace AdventOfCode2020.Test
{
    public class DayOneTests
    {
        private static readonly string FilePath = "./TestData/DayOne.txt";

        [Theory]
        [InlineData(new int[] { 1721, 979, 366, 299, 675, 1456 }, 514579)]
        public void TestExampleOne(int[] data, int expectedProduct)
        {
            DayOne.GetListProduct(data, 2020).Should().Be(expectedProduct);
        } 
        
        [Theory]
        [InlineData(new int[] { 1721, 979, 366, 299, 675, 1456 }, 241861950)]
        public void TestExampleTwo(int[] data, int expectedProduct)
        {
            DayOne.GetListTriProduct(data, 2020).Should().Be(expectedProduct);
        }

        [Fact]
        public void TestPartOne()
        {
            var expenses = File.ReadAllLines(FilePath).Select(int.Parse).ToArray();
            var product = DayOne.GetListProduct(expenses, 2020);
            Console.WriteLine(product);
        }

        [Fact]
        public void TestPartTwo()
        {
            var expenses = File.ReadAllLines(FilePath).Select(int.Parse).ToArray();
            var product = DayOne.GetListTriProduct(expenses, 2020);
            Console.WriteLine(product);
        }
    }
}
