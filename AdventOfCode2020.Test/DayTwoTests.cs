using FluentAssertions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using static AdventOfCode2020.DayTwo;

namespace AdventOfCode2020.Test
{
    public class DayTwoTests
    {
        private readonly ITestOutputHelper _output;
        private static readonly List<PasswordInput> _exampleData = new List<PasswordInput>
        {
                new PasswordInput('a', "abcde", 1, 3),
                new PasswordInput('b', "cdefg", 1, 3),
                new PasswordInput('c', "ccccccccc", 2, 9)
        };

        public DayTwoTests(ITestOutputHelper output)
        {
            _output = output;
        }

        private static readonly string FilePath = "./TestData/DayTwo.txt";

        [Fact]
        public void TestExampleOne()
        {
            GetValidPasswords(_exampleData).Should().Be(2);
        }

        [Fact]
        public void TestExampleTwo()
        {
            GetValidPasswordsPartTwo(_exampleData).Should().Be(1);
        }

        [Fact]
        public void TestQuestionOne()
        {
            var passwordInputs = GetPasswordInputFromFile();
            _output.WriteLine("Day 2 Q1: {0}", GetValidPasswords(passwordInputs));
        }

        [Fact]
        public void TestQuestionTwo()
        {
            var passwordInputs = GetPasswordInputFromFile();
            _output.WriteLine("Day 2 Q2: {0}", GetValidPasswordsPartTwo(passwordInputs));
        }


        private List<PasswordInput> GetPasswordInputFromFile()
        {
            return File.ReadAllLines(FilePath).Select(t =>
            {
                var data = t.Replace(":", string.Empty).Split(" ");
                var ranges = data[0].Split("-");
                var minRange = int.Parse(ranges[0]);
                var maxRange = int.Parse(ranges[1]);
                var letter = data[1][0];
                var password = data[2];
                return new PasswordInput(letter, password, minRange, maxRange);
            }).ToList();
        }
    }
}
