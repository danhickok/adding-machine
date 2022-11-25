using AMA = AddingMachine.Accumulator;

namespace AddingMachine.Tests
{
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
            AddKeys(acc, "7");


            // test clear function
            acc.AddKey('C');
            Assert.That(acc.CurrentValue, Is.EqualTo(0M), "Clear did not reset value to zero");
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