using AMA = AddingMachine.Accumulator;

namespace AddingMachine.Tests
{
    // Note: I don't have any internationalization tests here - all have hardcoded "." as decimal

    public class AccumulatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(4)]
        [TestCase(8)]
        [TestCase(12)]
        [TestCase(16)]
        public void AccumulatorMaxDigitsTest(int maxDigits)
        {
            var acc = new AMA.Accumulator(maxDigits, AMA.DecimalOptions.Zero);
            var testDigits = "12345678901234567";

            Assert.That(acc.CurrentDisplay, Is.EqualTo("0."),
                "Initial display value at zero decimals is not expected \"0.\"");
            
            for (int i = 0; i < maxDigits; i++)
            {
                acc.AddKey(testDigits[i]);
                Assert.That(acc.CurrentDisplay, Is.EqualTo(testDigits[..(i + 1)]),
                    $"Display value after {i + 1} digits is not what was expected");
            }

            for (int i = maxDigits; i < 17; i++)
            {
                acc.AddKey(testDigits[i]);
                Assert.That(acc.CurrentDisplay, Is.EqualTo(testDigits[..maxDigits]),
                    $"Display value after exceeding maximum with {i + 1} digits is not what was expected");
            }
        }

        [Test]
        public void AccumulatorValueTest()
        {
            var acc = new AMA.Accumulator(12, AMA.DecimalOptions.Float);
            Assert.That(acc.CurrentValue, Is.EqualTo(0M), "Initial value isn't zero");

            // test regular key entry
            AddKeys(acc, "123");
            Assert.That(acc.CurrentValue, Is.EqualTo(123M), "Regular key entry is not expected value");

            AddKeys(acc, "45");
            Assert.That(acc.CurrentValue, Is.EqualTo(12345M), "Regular key entry is not expected value");
            
            AddKeys(acc, ".");
            Assert.That(acc.CurrentValue, Is.EqualTo(12345M), "Regular key entry after decimal is not expected value");

            AddKeys(acc, "67");
            Assert.That(acc.CurrentValue, Is.EqualTo(12345.67M), "Regular key entry is not expected value");

            // test clear function
            acc.AddKey('C');
            Assert.That(acc.CurrentValue, Is.EqualTo(0M), "Clear did not reset value to zero");
        }

        [Test]
        public void AccumulatorDecimalTest()
        {
            var acc = new AMA.Accumulator(12, AMA.DecimalOptions.Float);

            AddKeys(acc, "123");
            Assert.That(acc.CurrentDisplay, Does.Not.Contain("."), "Digit keys only should not contain a decimal");

            AddKeys(acc, ".");
            Assert.That(acc.CurrentDisplay.Count(c => c == '.'), Is.EqualTo(1), "Decimal not once after entered");

            AddKeys(acc, "45");
            Assert.That(acc.CurrentDisplay.Count(c => c == '.'), Is.EqualTo(1), "Decimal not once after additional digit keys");

            AddKeys(acc, ".");
            Assert.That(acc.CurrentDisplay.Count(c => c == '.'), Is.EqualTo(1), "Decimal not once after second decimal");

            AddKeys(acc, "67.89");
            Assert.That(acc.CurrentDisplay.Count(c => c == '.'), Is.EqualTo(1), "Decimal not once after additional digits");
        }

        [Test]
        public void AccumulatorChangeDecimalOptionTest()
        {
            AMA.Accumulator acc;

            acc = new AMA.Accumulator(12, AMA.DecimalOptions.Zero);
            Assert.That(acc.CurrentDisplay, Is.EqualTo("0."), "Decimal pattern not right at initial zeero");

            acc = new AMA.Accumulator(12, AMA.DecimalOptions.Two);
            Assert.That(acc.CurrentDisplay, Is.EqualTo("0.00"), "Decimal pattern not right at initial two");

            acc = new AMA.Accumulator(12, AMA.DecimalOptions.Four);
            Assert.That(acc.CurrentDisplay, Is.EqualTo("0.0000"), "Decimal pattern not right at initial four");

            acc = new AMA.Accumulator(12, AMA.DecimalOptions.Six);
            Assert.That(acc.CurrentDisplay, Is.EqualTo("0.000000"), "Decimal pattern not right at initial six");

            acc = new AMA.Accumulator(12, AMA.DecimalOptions.Float);
            Assert.That(acc.CurrentDisplay, Is.EqualTo("0."), "Decimal pattern not right at initial float");

            acc.CurrentValue = 123.45678901M;

            Assert.That(acc.CurrentDisplay, Is.EqualTo("123.45678901"), "Decimal pattern not right after value assignment");

            acc.DecimalOption = AMA.DecimalOptions.Six;
            Assert.That(acc.CurrentDisplay, Is.EqualTo("123.456789"), "Decimal pattern not right after option set to six");

            acc.DecimalOption = AMA.DecimalOptions.Four;
            Assert.That(acc.CurrentDisplay, Is.EqualTo("123.4568"), "Decimal pattern not right after option set to four");

            acc.DecimalOption = AMA.DecimalOptions.Two;
            Assert.That(acc.CurrentDisplay, Is.EqualTo("123.46"), "Decimal pattern not right after option set to two");

            acc.DecimalOption = AMA.DecimalOptions.Zero;
            Assert.That(acc.CurrentDisplay, Is.EqualTo("123."), "Decimal pattern not right after option set to zero");

            acc.DecimalOption = AMA.DecimalOptions.Float;
            Assert.That(acc.CurrentDisplay, Is.EqualTo("123.45678901"), "Decimal pattern not right after option set back to float");

            acc.DecimalOption = AMA.DecimalOptions.Two;
            Assert.That(acc.CurrentDisplay, Is.EqualTo("123.46"), "Decimal pattern not right after option set back to zero");
        }

        [Test]
        public void AccumulatorMathTest()
        {
            //TODO: finish
        }

        private void AddKeys(AMA.Accumulator acc, string keys)
        {
            foreach (var key in keys)
            {
                acc.AddKey(key);
            }
        }

    }
}