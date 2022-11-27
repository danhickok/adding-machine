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

            Assert.That(acc.Display, Is.EqualTo("0."),
                "Initial display value at zero decimals is not expected \"0.\"");
            
            for (int i = 0; i < maxDigits; i++)
            {
                acc.AddKey(testDigits[i]);
                Assert.That(acc.Display, Is.EqualTo(testDigits[..(i + 1)]),
                    $"Display value after {i + 1} digits is not what was expected");
            }

            for (int i = maxDigits; i < 17; i++)
            {
                acc.AddKey(testDigits[i]);
                Assert.That(acc.Display, Is.EqualTo(testDigits[..maxDigits]),
                    $"Display value after exceeding maximum with {i + 1} digits is not what was expected");
            }
        }

        [Test]
        public void AccumulatorValueTest()
        {
            var acc = new AMA.Accumulator(12, AMA.DecimalOptions.Float);
            Assert.That(acc.Value, Is.EqualTo(0M), "Initial value isn't zero");

            // test regular key entry

            AddKeys(acc, "123");
            Assert.That(acc.Value, Is.EqualTo(123M), "Regular key entry is not expected value");

            AddKeys(acc, "45");
            Assert.That(acc.Value, Is.EqualTo(12_345M), "Regular key entry is not expected value");
            
            AddKeys(acc, ".");
            Assert.That(acc.Value, Is.EqualTo(12_345M), "Regular key entry after decimal is not expected value");

            AddKeys(acc, "67");
            Assert.That(acc.Value, Is.EqualTo(12_345.67M), "Regular key entry is not expected value");

            // test leading zeros

            AddKeys(acc, "C");
            AddKeys(acc, "0");
            Assert.That(acc.Value, Is.EqualTo(0M), "One zero key is not expected value");

            AddKeys(acc, "0000");
            Assert.That(acc.Value, Is.EqualTo(0M), "five zero keys is not expected value");

            AddKeys(acc, "0288");
            Assert.That(acc.Value, Is.EqualTo(288M), "Keys with leading zeros is not expected value");
        }

        [Test]
        public void AccumulatorDecimalTest()
        {
            var acc = new AMA.Accumulator(12, AMA.DecimalOptions.Float);

            AddKeys(acc, "123");
            Assert.That(acc.Display, Does.Not.Contain("."), "Digit keys only should not yet contain a decimal");

            AddKeys(acc, ".");
            Assert.That(acc.Display.Count(c => c == '.'), Is.EqualTo(1), "Decimal not once after entered");

            AddKeys(acc, "45");
            Assert.That(acc.Display.Count(c => c == '.'), Is.EqualTo(1), "Decimal not once after additional digit keys");

            AddKeys(acc, ".");
            Assert.That(acc.Display.Count(c => c == '.'), Is.EqualTo(1), "Decimal not once after second decimal");

            AddKeys(acc, "67.89");
            Assert.That(acc.Display.Count(c => c == '.'), Is.EqualTo(1), "Decimal not once after additional digits");
        }

        [Test]
        public void AccumulatorChangeDecimalOptionTest()
        {
            AMA.Accumulator acc;

            acc = new AMA.Accumulator(12, AMA.DecimalOptions.Zero);
            Assert.That(acc.Display, Is.EqualTo("0."), "Decimal pattern not right at initial zeero");

            acc = new AMA.Accumulator(12, AMA.DecimalOptions.Two);
            Assert.That(acc.Display, Is.EqualTo("0.00"), "Decimal pattern not right at initial two");

            acc = new AMA.Accumulator(12, AMA.DecimalOptions.Four);
            Assert.That(acc.Display, Is.EqualTo("0.0000"), "Decimal pattern not right at initial four");

            acc = new AMA.Accumulator(12, AMA.DecimalOptions.Six);
            Assert.That(acc.Display, Is.EqualTo("0.000000"), "Decimal pattern not right at initial six");

            acc = new AMA.Accumulator(12, AMA.DecimalOptions.Float);
            Assert.That(acc.Display, Is.EqualTo("0."), "Decimal pattern not right at initial float");

            acc.Value = 123.45678901M;

            Assert.That(acc.Display, Is.EqualTo("123.45678901"), "Decimal pattern not right after value assignment");

            acc.DecimalOption = AMA.DecimalOptions.Six;
            Assert.That(acc.Display, Is.EqualTo("123.456789"), "Decimal pattern not right after option set to six");

            acc.DecimalOption = AMA.DecimalOptions.Four;
            Assert.That(acc.Display, Is.EqualTo("123.4568"), "Decimal pattern not right after option set to four");

            acc.DecimalOption = AMA.DecimalOptions.Two;
            Assert.That(acc.Display, Is.EqualTo("123.46"), "Decimal pattern not right after option set to two");

            acc.DecimalOption = AMA.DecimalOptions.Zero;
            Assert.That(acc.Display, Is.EqualTo("123."), "Decimal pattern not right after option set to zero");

            acc.DecimalOption = AMA.DecimalOptions.Float;
            Assert.That(acc.Display, Is.EqualTo("123.45678901"), "Decimal pattern not right after option set back to float");

            acc.DecimalOption = AMA.DecimalOptions.Two;
            Assert.That(acc.Display, Is.EqualTo("123.46"), "Decimal pattern not right after option set back to zero");
        }

        [Test]
        public void AccumulatorMathTest()
        {
            var acc = new AMA.Accumulator(12, AMA.DecimalOptions.Float);

            // addition and subtraction

            AddKeys(acc, "C");
            AddKeys(acc, "1000+");
            AddKeys(acc, "2000+");
            AddKeys(acc, "3000+");
            AddKeys(acc, "4000+");
            AddKeys(acc, "5000+");
            AddKeys(acc, "T");
            Assert.That(acc.Value, Is.EqualTo(15_000M), "Simple addition did not result in the correct total");

            AddKeys(acc, "C");
            AddKeys(acc, "1000-");
            AddKeys(acc, "2000-");
            AddKeys(acc, "3000-");
            AddKeys(acc, "4000-");
            AddKeys(acc, "5000-");
            AddKeys(acc, "T");
            Assert.That(acc.Value, Is.EqualTo(-15_000M), "Simple subtraction did not result in the correct total");

            AddKeys(acc, "C");
            AddKeys(acc, "1000+");
            AddKeys(acc, "2000-");
            AddKeys(acc, "3000+");
            AddKeys(acc, "4000-");
            AddKeys(acc, "5000+");
            AddKeys(acc, "T");
            Assert.That(acc.Value, Is.EqualTo(3_000M), "Mixture of addition and subtraction did not result in the correct total");

            AddKeys(acc, "C");
            AddKeys(acc, "1000+++++");
            AddKeys(acc, "T");
            Assert.That(acc.Value, Is.EqualTo(5_000M), "Totalling repeated additions did not result in the correct total");

            // total and grand total

            AddKeys(acc, "TTC");
            AddKeys(acc, "1000+");
            AddKeys(acc, "2000+");
            AddKeys(acc, "3000+T");
            Assert.That(acc.Value, Is.EqualTo(6_000M), "First total is incorrect");

            AddKeys(acc, "4000+");
            AddKeys(acc, "5000+T");
            Assert.That(acc.Value, Is.EqualTo(9_000M), "Second total is incorrect");

            AddKeys(acc, "T");
            Assert.That(acc.Value, Is.EqualTo(15_000M), "Grand total is incorrect");

            AddKeys(acc, "T");
            Assert.That(acc.Value, Is.EqualTo(0M), "Total after grand total is incorrect");

            // multiplication and division

            AddKeys(acc, "C");
            AddKeys(acc, "456*");
            AddKeys(acc, "123+");
            Assert.That(acc.Value, Is.EqualTo(56_088M), "Multiplication of two numbers is incorrect");

            AddKeys(acc, "C");
            AddKeys(acc, "12*");
            AddKeys(acc, "34*");
            AddKeys(acc, "56*");
            AddKeys(acc, "78*");
            AddKeys(acc, "90+");
            Assert.That(acc.Value, Is.EqualTo(160_392_960M), "Multiplication of five numbers is incorrect");

            AddKeys(acc, "C");
            AddKeys(acc, "500/");
            AddKeys(acc, "20+");
            Assert.That(acc.Value, Is.EqualTo(25M), "Division of two numbers is incorrect");

            AddKeys(acc, "C");
            AddKeys(acc, "1000/");
            AddKeys(acc, "10/");
            AddKeys(acc, "20+");
            Assert.That(acc.Value, Is.EqualTo(5M), "Division of three numbers is incorrect");

            AddKeys(acc, "C");
            AddKeys(acc, "100/");
            AddKeys(acc, "7+");
            Assert.That(acc.Value, Is.EqualTo(14.285714M).Within(0.0000003M), "Division resulting in fractional value is incorrect");

            AddKeys(acc, "TTC");
            AddKeys(acc, "100*");
            AddKeys(acc, "40++");
            AddKeys(acc, "50*");
            AddKeys(acc, "20++T");
            Assert.That(acc.Value, Is.EqualTo(5_000M), "Result of totalling two products is incorrect");

            AddKeys(acc, "TTC");
            AddKeys(acc, "1000/");
            AddKeys(acc, "4++");
            AddKeys(acc, "500/");
            AddKeys(acc, "2++T");
            Assert.That(acc.Value, Is.EqualTo(500M), "Result of totalling two quotients is incorrect");

            AddKeys(acc, "TTC");
            AddKeys(acc, "100*");
            AddKeys(acc, "40+");
            AddKeys(acc, "50*");
            AddKeys(acc, "20+T");
            Assert.That(acc.Value, Is.EqualTo(0M), "Total of mixture of products and quotients is incorrect");

            // identities

            AddKeys(acc, "C");
            AddKeys(acc, "12345+");
            AddKeys(acc, "0+T");
            Assert.That(acc.Value, Is.EqualTo(12_345M), "Addition identity is incorrect");

            AddKeys(acc, "C");
            AddKeys(acc, "12345+");
            AddKeys(acc, "0-T");
            Assert.That(acc.Value, Is.EqualTo(12_345M), "Subtraction identity is incorrect");

            AddKeys(acc, "C");
            AddKeys(acc, "0+");
            AddKeys(acc, "12345-T");
            Assert.That(acc.Value, Is.EqualTo(-12_345M), "Subtraction from zero is incorrect");

            AddKeys(acc, "C");
            AddKeys(acc, "12345*");
            AddKeys(acc, "1+");
            Assert.That(acc.Value, Is.EqualTo(12_345M), "Multiplication identity is incorrect");

            AddKeys(acc, "C");
            AddKeys(acc, "12345/");
            AddKeys(acc, "1+");
            Assert.That(acc.Value, Is.EqualTo(12_345M), "Division identity is incorrect");

            AddKeys(acc, "C");
            AddKeys(acc, "12345*");
            AddKeys(acc, "0+");
            Assert.That(acc.Value, Is.EqualTo(0M), "Multiplication by zero is incorrect");

            // reasonable complex calculation

            AddKeys(acc, "TTC");
            AddKeys(acc, "147.82+");
            AddKeys(acc, "11.95+");
            AddKeys(acc, "8.60+");
            AddKeys(acc, "38.92+-113.17+");
            AddKeys(acc, "67.36+");
            AddKeys(acc, "94.42+");
            AddKeys(acc, "107.34+");
            AddKeys(acc, "22.92+");
            AddKeys(acc, "147.57+");
            AddKeys(acc, "132.96+");
            AddKeys(acc, "4*25++");
            AddKeys(acc, "161.83+");
            AddKeys(acc, "111.74+");
            AddKeys(acc, "74.35+");
            AddKeys(acc, "12.33-");
            AddKeys(acc, "159.21+");
            AddKeys(acc, "121+");
            AddKeys(acc, "68.27+");
            AddKeys(acc, "168.03+T");
            Assert.That(acc.Value, Is.EqualTo(1_806.21M), "Reasonable complex calculation is incorrect");
        }

        [Test]
        public void AccumulatorClearTest()
        {
            var acc = new AMA.Accumulator(12, AMA.DecimalOptions.Float);

            acc.Value = 12_345.67M;
            acc.AddKey('C');
            Assert.That(acc.Value, Is.EqualTo(0M), "Clear did not reset assigned value to zero");

            AddKeys(acc, "C");
            AddKeys(acc, "12345");
            Assert.That(acc.Value, Is.EqualTo(12_345M), "Keyed value after clear is incorrect");

            AddKeys(acc, "C");
            Assert.That(acc.Value, Is.EqualTo(0M), "Clear did not reset keyed value to zero");

            AddKeys(acc, "TTC");
            AddKeys(acc, "12345+");
            AddKeys(acc, "23456");
            AddKeys(acc, "C");
            AddKeys(acc, "34567+T");
            Assert.That(acc.Value, Is.EqualTo(46_912M), "Clear entry during addition resulted in incorrect total");

            AddKeys(acc, "TTC");
            AddKeys(acc, "1000+");
            AddKeys(acc, "50*");
            AddKeys(acc, "20");
            AddKeys(acc, "C");
            AddKeys(acc, "50++T");
            Assert.That(acc.Value, Is.EqualTo(3_500M), "Clear entry during multiplication resulted in incorrect total");

            AddKeys(acc, "TTC");
            AddKeys(acc, "1000+");
            AddKeys(acc, "1000+");
            AddKeys(acc, "C");
            AddKeys(acc, "2000+");
            AddKeys(acc, "CC");
            Assert.That(acc.Value, Is.EqualTo(0M), "Full clear after addition is not zero");
        }

        [Test]
        public void AccumulatorErrorTest()
        {
            var acc = new AMA.Accumulator(12, AMA.DecimalOptions.Float);

            AddKeys(acc, "TTC");
            AddKeys(acc, "999999999999+");
            AddKeys(acc, "999999999999+");
            Assert.That(acc.Display, Is.EqualTo(AMA.Accumulator.ErrorDisplay), "Two maximum values totaled did not result in error display");

            AddKeys(acc, "TTC");
            AddKeys(acc, "42/");
            AddKeys(acc, "0+");
            Assert.That(acc.Display, Is.EqualTo(AMA.Accumulator.ErrorDisplay), "Division by zero did not result in error display");
        }

        [Test]
        [TestCase('0')]
        [TestCase('9')]
        [TestCase('.')]
        [TestCase('*')]
        [TestCase('/')]
        [TestCase('+')]
        [TestCase('T')]
        [TestCase('C')]
        public void AccumulatorAbuseTest(char testChar)
        {
            var acc = new AMA.Accumulator(12, AMA.DecimalOptions.Float);
            int timesToRepeat = 2000;

            Assert.That(() =>
            {
                AddKeys(acc, new string(testChar, timesToRepeat));
            }, Throws.Nothing, $"Repeatedly keying '{testChar}' {timesToRepeat} times threw an exception");
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