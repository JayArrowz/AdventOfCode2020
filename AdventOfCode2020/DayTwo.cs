using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class DayTwo
    {
        public static int GetValidPasswords(List<PasswordInput> passwordInput)
        {
            return passwordInput.Count(IsValid);
        }

        public static int GetValidPasswordsPartTwo(List<PasswordInput> passwordInput)
        {
            return passwordInput.Count(IsValidPartTwo);
        }

        private static bool IsValidPartTwo(PasswordInput input)
        {
            return input.Password.Where((c, index) => c == input.Letter &&
            (index + 1 == input.MinRange || index + 1 == input.MaxRange))
                .Count() == 1;
        }

        private static bool IsValid(PasswordInput input)
        {
            var letterOccurances = input.Password.Count(pwChar => pwChar.Equals(input.Letter));
            return letterOccurances >= input.MinRange && letterOccurances <= input.MaxRange;
        }

        public class PasswordInput
        {
            private readonly int _minRange;
            private readonly int _maxRange;
            private readonly char _letter;
            private readonly string _password;

            public PasswordInput(char letter, string password, int minRange, int maxRange)
            {
                _letter = letter;
                _password = password;
                _minRange = minRange;
                _maxRange = maxRange;
            }

            public int MaxRange { get => _maxRange; }
            public int MinRange { get => _minRange; }
            public string Password { get => _password; }
            public char Letter { get => _letter; }
        }
    }
}
