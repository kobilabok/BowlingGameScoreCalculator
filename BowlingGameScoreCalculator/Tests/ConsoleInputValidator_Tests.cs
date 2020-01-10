﻿using BowlingGameScoreCalculator.Code;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGameScoreCalculator.Tests
{
    [TestClass]
    public class ConsoleInputValidator_Tests
    {
        private readonly ConsoleInputValidator consoleInput = new ConsoleInputValidator();

        [TestMethod]
        public void Validate_EmptyString_MessageExpected()
        {
            var input = "";

            consoleInput.ValidateStringFormat(input).Should().Be("Cannot be blank or have white spaces. Please try again.\n");
        }

        [TestMethod]
        public void Validate_WhiteSpacesString_MessageExpected()
        {
            var input = "                    ";

            consoleInput.ValidateStringFormat(input).Should().Be("Cannot be blank or have white spaces. Please try again.\n");
        }

        [TestMethod]
        public void Validate_LettersAndNumbersString_WithLessThan21Chars_MessageExpected()
        {
            var input = "1234567890qwert";

            consoleInput.ValidateStringFormat(input).Should().Be("Entered string is either too long or too short. Please try again.\n");
        }

        [TestMethod]
        public void Validate_LettersAndNumbersString_WithGreaterThan32Chars_MessageExpected()
        {
            var input = "1234567890qwert1234567890qawsedrf";

            consoleInput.ValidateStringFormat(input).Should().Be("Entered string is either too long or too short. Please try again.\n");
        }

        [TestMethod]
        public void Validate_LettersAndNumbersInAllowedRangeString_MessageExpected()
        {
            var input = "1234567890qwertyuiop1234567";

            consoleInput.ValidateStringFormat(input).Should().Be("Invalid input. Please Try again.\n");
        }

        [TestMethod]
        public void Validate_AllowedRangeWithBarSymbolString_MessageExpected()
        {
            var input = "1234567890123456789015||";

            consoleInput.ValidateStringFormat(input).Should().Be("Invalid input. Please Try again.\n");
        }

        [TestMethod]
        public void Validate_AllowedRangeWithBarSymbolsOnlyString_MessageExpected()
        {
            var input = "||||||||||||||||||||||";

            consoleInput.ValidateStringFormat(input).Should().Be("Invalid input. Please Try again.\n");
        }

        [TestMethod]
        public void Validate_AllowedRangeWithBarSymbolsAndInvalidCharacterString_MessageExpected()
        {
            var input = "X|X|A|A|A|A|A|A|A|A||";

            consoleInput.ValidateStringFormat(input).Should().Be("Entered string contains invalid characters.\n");
        }


        // TODO - need to update string validation to not validate for two 'X' after two pipes ('|')
        [TestMethod]
        public void Validate_ValidStringInLowerCase_NoMessageExpected()
        {
            var input = "x|x|x|x|x|x|x|x|x|x||xx";

            consoleInput.ValidateStringFormat(input).Should().Be(string.Empty);
        }

        [TestMethod]
        public void Validate_ValidString_NoMessageExpected()
        {
            var input = "5-|7/|9-|X|-8|8/|-6|X|X|5-||";

            consoleInput.ValidateStringFormat(input).Should().Be(string.Empty);
        }
    }
}