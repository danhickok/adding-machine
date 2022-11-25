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
        public void AccumulatorTest()
        {
            var acc = new AMA.Accumulator(0, 0);
        }
    }
}