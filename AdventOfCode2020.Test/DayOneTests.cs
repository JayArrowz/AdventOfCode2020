using FluentAssertions;
using System;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Test
{
    public class DayOneTests
    {
        private readonly ITestOutputHelper _output;

        public DayOneTests(ITestOutputHelper output)
        {
            _output = output;
        }

        private static readonly string FilePath = "./TestData/DayOne.txt";

        [Theory]
        [InlineData(new int[] { 1721, 979, 366, 299, 675, 1456 }, 514579)]
        public void TestExampleOne(int[] data, int expectedProduct)
        {
            DayOne.GetListBiProduct(data, 2020).Should().Be(expectedProduct);
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
            var expenses = GetExpensesFromFile();
            var product = DayOne.GetListBiProduct(expenses, 2020);
            _output.WriteLine("Part One Answer: {0}", product);
        }

        [Fact]
        public void TestPartTwo()
        {
            var expenses = GetExpensesFromFile();
            var product = DayOne.GetListTriProduct(expenses, 2020);
            _output.WriteLine("Part Two Answer: {0}", product);
        }

        private int[] GetExpensesFromFile()
        {
            return File.ReadAllLines(FilePath).Select(int.Parse).ToArray();
        }
    }
}
