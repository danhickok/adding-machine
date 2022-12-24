namespace AddingMachine.Tests
{
    // Note: These tests assume US-English locale defaults for number format

    public class AccumulatorTests
    {
        Core.Accumulator? acc;

        [SetUp]
        public void Setup()
        {
            acc = null;
        }

        [TearDown]
        public void TearDown()
        {
            acc = null;
        }

        [Test]
        [TestCase(4)]
        [TestCase(8)]
        [TestCase(12)]
        [TestCase(16)]
        public void AccumulatorMaxDigitsTest(int maxDigits)
        {
            acc = new Core.Accumulator(maxDigits, Core.DecimalOptions.Zero);
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
            acc = new Core.Accumulator(12, Core.DecimalOptions.Float);
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
            acc = new Core.Accumulator(12, Core.DecimalOptions.Float);

            AddKeys(acc, "12345");
            Assert.That(acc.Display, Does.Not.Contain("."), "Digit keys only should not yet contain a decimal");

            AddKeys(acc, ".");
            Assert.That(acc.Display.Count(c => c == '.'), Is.EqualTo(1), "Decimal not occurring once after entered");

            AddKeys(acc, "67");
            Assert.That(acc.Display.Count(c => c == '.'), Is.EqualTo(1), "Decimal not occurring once after additional digit keys");

            AddKeys(acc, ".");
            Assert.That(acc.Display.Count(c => c == '.'), Is.EqualTo(1), "Decimal not occurring once after second decimal");

            AddKeys(acc, "89");
            Assert.That(acc.Display.Count(c => c == '.'), Is.EqualTo(1), "Decimal not occurring once after additional digits");

            // also test presence of comma separator after operation
            AddKeys(acc, "+");
            Assert.That(acc.Display, Is.EqualTo("12,345.6789"), "Format of number after addition is not as expected");
        }

        [Test]
        public void AccumulatorChangeDecimalOptionTest()
        {
            Core.Accumulator acc;

            acc = new Core.Accumulator(12, Core.DecimalOptions.Zero);
            Assert.That(acc.Display, Is.EqualTo("0."), "Decimal pattern not right at initial zeero");

            acc = new Core.Accumulator(12, Core.DecimalOptions.Two);
            Assert.That(acc.Display, Is.EqualTo("0.00"), "Decimal pattern not right at initial two");

            acc = new Core.Accumulator(12, Core.DecimalOptions.Four);
            Assert.That(acc.Display, Is.EqualTo("0.0000"), "Decimal pattern not right at initial four");

            acc = new Core.Accumulator(12, Core.DecimalOptions.Six);
            Assert.That(acc.Display, Is.EqualTo("0.000000"), "Decimal pattern not right at initial six");

            acc = new Core.Accumulator(12, Core.DecimalOptions.Float);
            Assert.That(acc.Display, Is.EqualTo("0."), "Decimal pattern not right at initial float");

            acc.Value = 123.45678901M;

            Assert.That(acc.Display, Is.EqualTo("123.45678901"), "Decimal pattern not right after value assignment");

            acc.DecimalOption = Core.DecimalOptions.Six;
            Assert.That(acc.Display, Is.EqualTo("123.456789"), "Decimal pattern not right after option set to six");

            acc.DecimalOption = Core.DecimalOptions.Four;
            Assert.That(acc.Display, Is.EqualTo("123.4568"), "Decimal pattern not right after option set to four");

            acc.DecimalOption = Core.DecimalOptions.Two;
            Assert.That(acc.Display, Is.EqualTo("123.46"), "Decimal pattern not right after option set to two");

            acc.DecimalOption = Core.DecimalOptions.Zero;
            Assert.That(acc.Display, Is.EqualTo("123."), "Decimal pattern not right after option set to zero");

            acc.DecimalOption = Core.DecimalOptions.Float;
            Assert.That(acc.Display, Is.EqualTo("123.45678901"), "Decimal pattern not right after option set back to float");

            acc.DecimalOption = Core.DecimalOptions.Two;
            Assert.That(acc.Display, Is.EqualTo("123.46"), "Decimal pattern not right after option set back to zero");
        }

        [Test]
        public void AccumulatorMathTest()
        {
            acc = new Core.Accumulator(12, Core.DecimalOptions.Float);

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
            acc = new Core.Accumulator(12, Core.DecimalOptions.Float);

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
            acc = new Core.Accumulator(12, Core.DecimalOptions.Float);

            AddKeys(acc, "TTC");
            AddKeys(acc, "42/");
            AddKeys(acc, "0+");
            Assert.That(acc.Display, Is.EqualTo(Core.Accumulator.ErrorDisplay), "Division by zero did not result in error display");

            AddKeys(acc, "012345");
            Assert.That(acc.Display, Is.EqualTo(Core.Accumulator.ErrorDisplay), "Error does not remain after digits");

            AddKeys(acc, "+");
            Assert.That(acc.Display, Is.EqualTo(Core.Accumulator.ErrorDisplay), "Error does not remain after operator");

            AddKeys(acc, "T");
            Assert.That(acc.Display, Is.EqualTo(Core.Accumulator.ErrorDisplay), "Error does not remain after total");

            AddKeys(acc, "T");
            Assert.That(acc.Display, Is.EqualTo(Core.Accumulator.ErrorDisplay), "Error does not remain after grand total");

            AddKeys(acc, "C");
            Assert.That(acc.Display, Is.Not.EqualTo(Core.Accumulator.ErrorDisplay), "Error is not cleared after clear");

            AddKeys(acc, "42+27+T");
            Assert.That(acc.Display, Is.EqualTo("69."), "Normal operation not restored after clearing error");

            AddKeys(acc, "TTC");
            AddKeys(acc, "999999999999");
            Assert.That(acc.Display, Is.Not.EqualTo(Core.Accumulator.ErrorDisplay), "Entering amount that is maximum value resulted in error display");
            
            AddKeys(acc, "+");
            Assert.That(acc.Display, Is.Not.EqualTo(Core.Accumulator.ErrorDisplay), "Adding amount that is maximum value resulted in error display");

            AddKeys(acc, "1+T");
            Assert.That(acc.Display, Is.EqualTo(Core.Accumulator.ErrorDisplay), "Sum exceeding maximum value did not result in error display");

            AddKeys(acc, "TTC");
            AddKeys(acc, "999999999999+T");
            AddKeys(acc, "999999999999+TT");
            Assert.That(acc.Display, Is.EqualTo(Core.Accumulator.ErrorDisplay), "Grand total did not result in error display");

            AddKeys(acc, "TTC");
            AddKeys(acc, "99999999999+T");
            AddKeys(acc, "1+TT");
            Assert.That(acc.Display, Is.Not.EqualTo(Core.Accumulator.ErrorDisplay), "Sum within maximum value result in error display");
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
        public void AccumulatorAbuseTest1(char testChar)
        {
            acc = new Core.Accumulator(12, Core.DecimalOptions.Float);
            int timesToRepeat = 2000;

            Assert.That(() =>
            {
                AddKeys(acc, new string(testChar, timesToRepeat));
            }, Throws.Nothing, $"Repeatedly keying '{testChar}' {timesToRepeat} times threw an exception");
        }

        [Test]
        public void AccumulatorAbuseTest2()
        {
            acc = new Core.Accumulator(12, Core.DecimalOptions.Float);

            Assert.That(() =>
            {
                AddKeys(acc, "36T/*.4+0640-2C3+408C8-*715C3C7C*99/990/95*/.18+.2");
                AddKeys(acc, "55061*+/85T90.23434-CT83989+/+806-/33-.C-2.8534-.0");
                AddKeys(acc, "T--33.97.-83143*382+45/9T152*5C*5.21T+*50-04871+58");
                AddKeys(acc, "C97-825+39C/*T6T-636-/78.+-C96628-C829*+6275-8+..2");
                AddKeys(acc, "9T4T*80973+.95T*/0/94-*C/.1T6T94+8.60*-8.7/56285++");
                AddKeys(acc, "2+45/72632**53T67467*C396*812*0/.1C4*8C638*5T*607T");
                AddKeys(acc, "38-C-/.83T.969*.+C0*0-45354.5.*-682T-+3186-5C69+2C");
                AddKeys(acc, "TT-4+1-T6408T765176+522+520/678/63/33C0*18.+5-4+92");
                AddKeys(acc, "-7-0283/48*-41+0/9.-T97.84/166+6.6*T11+545*5669T/0");
                AddKeys(acc, "+74T*48+5TT16*/-C1C98+03*65+T173-C.C+.*8.82T353439");
                AddKeys(acc, "*26072.4C45C*-/+2+*T0938377005/5+**3+C09*724*-+1.+");
                AddKeys(acc, "C3542863.7T9T*/5C+3+7492010968.2C+.6303940-+0C+-2/");
                AddKeys(acc, "3/296T34-7495/9T781674C*0TT86CT4+16-+6.+7C-46C44-0");
                AddKeys(acc, "892/1+-340T1524866C-./*+9.7**01.*9./68*+-1863.0-28");
                AddKeys(acc, "*86-/90.C589.739./-01+60/6.68/42-/7.-2C*+*7-2+-4T4");
                AddKeys(acc, "T1-/*7523*5T4157.50*98-238--3.4C46-CT74+843-C.++6+");
                AddKeys(acc, "+-64+15+8-9+.13819*./0.+*T-.5845C+8834.5T5T82*--.C");
                AddKeys(acc, "+3*2.1006-1T09/253-.55364/+476T34063-3014+5*C6*--4");
                AddKeys(acc, "1C+8901-/184T.*46+522*T78+44592+297/.2C4.82002*1C7");
                AddKeys(acc, "4+3TC0T..8485/20027T.858595-T2C84-22*01764007735.9");
            }, Throws.Nothing, "Random sequence of keys threw an exception");
        }

        [Test]
        public void AccumulatorAbuseTest3()
        {
            acc = new Core.Accumulator(12, Core.DecimalOptions.Float);

            Assert.That(() =>
            {
                for (char i = char.MinValue; i < char.MaxValue; ++i)
                {
                    acc.AddKey(i);
                }
            }, Throws.Nothing, "Full range of characters threw an exception");
        }

        [Test]
        public void AccumulatorEventsTest()
        {
            var currentDisplay = "not set";
            var tapeEntries = new List<Core.TapeEntry>();
            int ti = -1;
            int tiBefore;

            acc = new Core.Accumulator(12, Core.DecimalOptions.Two);
            
            EventHandler<Core.DisplayChangedEventArgs> displayChangedHandler = (sender, e) =>
            {
                currentDisplay = e.Display;
            };

            EventHandler<Core.NewTapeEntryPublishedEventArgs> newTapeEntryPublished = (sender, e) =>
            {
                tapeEntries.Add(e.NewTapeEntry.Copy());
                ti++;
            };

            var clearTape = () =>
            {
                tapeEntries.Clear();
                ti = -1;
            };

            acc.DisplayChanged += displayChangedHandler;
            acc.NewTapeEntryPublished += newTapeEntryPublished;

            // delay in milliseconds
            var timeDelay = 100;

            AddKeys(acc, "TTC");
            clearTape();
            
            // adding and totalling

            AddKeys(acc, "123");
            Assert.That(() => currentDisplay, Is.EqualTo("123").After(timeDelay), "Current display not updated after clear and three digits");
            Assert.That(() => ti, Is.EqualTo(-1).After(timeDelay), "Tape was populated after three digits and before operation");

            AddKeys(acc, "4.5");
            Assert.That(() => currentDisplay, Is.EqualTo("1234.5").After(timeDelay), "Current display not correct after additional digit, decimal, digit");
            Assert.That(() => ti, Is.EqualTo(-1).After(timeDelay), "Tape was populated after additional digit, decimal, digit and before operation");

            AddKeys(acc, "+");
            Assert.That(() => currentDisplay, Is.EqualTo("1,234.50").After(timeDelay), "Current display not correct after first addition operation");

            Assert.That(() => ti, Is.EqualTo(0).After(timeDelay), "Tape was not populated after first addition operation");
            Assert.Multiple(() =>
            {
                Assert.That(tapeEntries[ti].Display, Is.EqualTo("1,234.50"), "Tape display not correct first after addition operation");
                Assert.That(tapeEntries[ti].Value, Is.EqualTo(1_234.5M), "Tape value not correct after first addition operation");
                Assert.That(tapeEntries[ti].Operation, Is.EqualTo("+"), "Tape operation not correct after first addition operation");
                Assert.That(tapeEntries[ti].IsError, Is.EqualTo(false), "Tape error changed unexpectedly after first addition operation");
            });

            AddKeys(acc, "2345.6+");
            Assert.That(() => currentDisplay, Is.EqualTo("2,345.60").After(timeDelay), "Current display not correct after second addition operation");

            Assert.That(() => ti, Is.EqualTo(1).After(timeDelay), "Tape was not correctly populated after second addition operation");
            Assert.Multiple(() =>
            {
                Assert.That(tapeEntries[ti].Display, Is.EqualTo("2,345.60"), "Tape display not correct after second addition operation");
                Assert.That(tapeEntries[ti].Value, Is.EqualTo(2_345.6M), "Tape value not correct after second addition operation");
                Assert.That(tapeEntries[ti].Operation, Is.EqualTo("+"), "Tape operation not correct after second addition operation");
                Assert.That(tapeEntries[ti].IsError, Is.EqualTo(false), "Tape error changed unexpectedly after second addition operation");
            });

            AddKeys(acc, "9999.9-");
            Assert.That(() => currentDisplay, Is.EqualTo("9,999.90").After(timeDelay), "Current display not correct after third addition operation");

            Assert.That(() => ti, Is.EqualTo(2).After(timeDelay), "Tape was not correctly populated after third addition operation");
            Assert.Multiple(() =>
            {
                Assert.That(tapeEntries[ti].Display, Is.EqualTo("9,999.90"), "Tape display not correct after third addition operation");
                Assert.That(tapeEntries[ti].Value, Is.EqualTo(9_999.9M), "Tape value not correct after third addition operation");
                Assert.That(tapeEntries[ti].Operation, Is.EqualTo("-"), "Tape operation not correct after third addition operation");
                Assert.That(tapeEntries[ti].IsError, Is.EqualTo(false), "Tape error changed unexpectedly after third addition operation");
            });

            AddKeys(acc, "T");
            Assert.That(() => currentDisplay, Is.EqualTo("-6,419.80"), "Current display not correct after total operation");

            Assert.That(() => ti, Is.EqualTo(4), "Tape was not correctly populated after total operation");
            Assert.Multiple(() =>
            {
                // total line
                Assert.That(tapeEntries[ti - 1].Display, Is.EqualTo("-6,419.80"), "Tape display not correct after total operation");
                Assert.That(tapeEntries[ti - 1].Value, Is.EqualTo(-6_419.8M), "Tape value not correct after total operation");
                Assert.That(tapeEntries[ti - 1].Operation, Is.EqualTo("T"), "Tape operation not correct after total operation");
                Assert.That(tapeEntries[ti - 1].IsError, Is.EqualTo(false), "Tape error changed unexpectedly after total operation");
                // empty line
                Assert.That(tapeEntries[ti].Display, Is.EqualTo(""), "Tape has no empty line after total operation");
                Assert.That(tapeEntries[ti].Value, Is.EqualTo(0M), "Tape value not correct for empty line after total operation");
                Assert.That(tapeEntries[ti].Operation, Is.EqualTo(""), "Tape operation not empty for empty line after total operation");
                Assert.That(tapeEntries[ti].IsError, Is.EqualTo(false), "Tape error wrong in empty line after total operation");
            });

            AddKeys(acc, "T");
            Assert.That(() => currentDisplay, Is.EqualTo("-6,419.80").After(timeDelay), "Current display not correct after grand total operation");

            Assert.That(() => ti, Is.EqualTo(7).After(timeDelay), "Tape was not correctly populated after grand total operation");
            Assert.Multiple(() =>
            {
                // grand total line
                Assert.That(tapeEntries[ti - 2].Display, Is.EqualTo("-6,419.80"), "Tape display not correct after grand total operation");
                Assert.That(tapeEntries[ti - 2].Value, Is.EqualTo(-6_419.8M), "Tape value not correct after grand total operation");
                Assert.That(tapeEntries[ti - 2].Operation, Is.EqualTo("GT"), "Tape operation not correct after grand total operation");
                Assert.That(tapeEntries[ti - 2].IsError, Is.EqualTo(false), "Tape error changed unexpectedly after grand total operation");
                // empty line
                Assert.That(tapeEntries[ti - 1].Display, Is.EqualTo(""), "Tape has no empty line after grand total operation");
                Assert.That(tapeEntries[ti - 1].Value, Is.EqualTo(0M), "Tape value not correct for empty line after grand total operation");
                Assert.That(tapeEntries[ti - 1].Operation, Is.EqualTo(""), "Tape operation not empty for empty line after grand total operation");
                Assert.That(tapeEntries[ti - 1].IsError, Is.EqualTo(false), "Tape error wrong in empty line after grand total operation");
                // empty line
                Assert.That(tapeEntries[ti].Display, Is.EqualTo(""), "Tape has no second empty line after grand total operation");
                Assert.That(tapeEntries[ti].Value, Is.EqualTo(0M), "Tape value not correct for second empty line after grand total operation");
                Assert.That(tapeEntries[ti].Operation, Is.EqualTo(""), "Tape operation not empty for second empty line after grand total operation");
                Assert.That(tapeEntries[ti].IsError, Is.EqualTo(false), "Tape error wrong in second empty line after grand total operation");
            });

            AddKeys(acc, "TTC");
            clearTape();

            // clear entry and clear

            tiBefore = ti;

            AddKeys(acc, "123C");
            Assert.That(() => currentDisplay, Is.EqualTo("0.00").After(timeDelay), "Current display not correct after clear entry operation");
            Assert.That(() => ti, Is.EqualTo(tiBefore).After(timeDelay), "Tape should not be updated after clear entry operation");

            AddKeys(acc, ".C");
            Assert.That(() => currentDisplay, Is.EqualTo("0.00").After(timeDelay), "Current display not correct after second clear entry operation");
            Assert.That(() => ti, Is.EqualTo(tiBefore).After(timeDelay), "Tape should not be updated after second clear entry operation");

            AddKeys(acc, "C");
            Assert.That(() => currentDisplay, Is.EqualTo("0.00").After(timeDelay), "Current display not correct after clear operation");

            Assert.That(() => ti, Is.EqualTo(tiBefore + 2).After(timeDelay), "Tape was not correctly populated after clear operation");
            Assert.Multiple(() =>
            {
                // clear line
                Assert.That(tapeEntries[ti - 1].Display, Is.EqualTo("0.00"), "Tape has no empty line after clear operation");
                Assert.That(tapeEntries[ti - 1].Value, Is.EqualTo(0M), "Tape value not correct for empty line after clear operation");
                Assert.That(tapeEntries[ti - 1].Operation, Is.EqualTo("C"), "Tape operation not correct for empty line after clear operation");
                Assert.That(tapeEntries[ti - 1].IsError, Is.EqualTo(false), "Tape error wrong in empty line after clear operation");
                // empty line
                Assert.That(tapeEntries[ti].Display, Is.EqualTo(""), "Tape has no empty line after clear operation");
                Assert.That(tapeEntries[ti].Value, Is.EqualTo(0M), "Tape value not correct for empty line after clear operation");
                Assert.That(tapeEntries[ti].Operation, Is.EqualTo(""), "Tape operation not empty for empty line after clear operation");
                Assert.That(tapeEntries[ti].IsError, Is.EqualTo(false), "Tape error wrong in empty line after clear operation");
            });

            tiBefore = ti;

            AddKeys(acc, "456C");
            Assert.That(() => currentDisplay, Is.EqualTo("0.00").After(timeDelay), "Current display not correct after third clear entry operation");
            Assert.That(() => ti, Is.EqualTo(tiBefore).After(timeDelay), "Tape should not be updated after third clear entry operation");

            AddKeys(acc, "100+100+100+TC");
            Assert.That(() => currentDisplay, Is.EqualTo("0.00").After(timeDelay), "Current display not correct after clear after total");

            Assert.That(() => ti, Is.EqualTo(tiBefore + 7).After(timeDelay), "Unexpected number of tape entries after clear after total");
            Assert.Multiple(() =>
            {
                // clear line
                Assert.That(tapeEntries[ti - 1].Display, Is.EqualTo("0.00"), "Tape has incorrect display after clear after total");
                Assert.That(tapeEntries[ti - 1].Value, Is.EqualTo(0M), "Tape value not correct after clear after total");
                Assert.That(tapeEntries[ti - 1].Operation, Is.EqualTo("C"), "Tape operation not correct after clear after total");
                Assert.That(tapeEntries[ti - 1].IsError, Is.EqualTo(false), "Tape error wrong after clear after total");
                // empty line
                Assert.That(tapeEntries[ti].Display, Is.EqualTo(""), "Tape has no empty line after clear after total");
                Assert.That(tapeEntries[ti].Value, Is.EqualTo(0M), "Tape value not correct for empty line after clear after total");
                Assert.That(tapeEntries[ti].Operation, Is.EqualTo(""), "Tape operation not empty for empty line after clear after total");
                Assert.That(tapeEntries[ti].IsError, Is.EqualTo(false), "Tape error wrong in empty line after clear after total");
            });

            AddKeys(acc, "TTC");
            clearTape();

            // multiplication and division

            AddKeys(acc, "478*");
            Assert.That(() => currentDisplay, Is.EqualTo("478.00").After(timeDelay), "Current display not correct after multiply operation");

            Assert.That(() => ti, Is.EqualTo(0).After(timeDelay), "Tape was not correctly populated after multiply operation");
            Assert.Multiple(() =>
            {
                Assert.That(tapeEntries[ti].Display, Is.EqualTo("478.00"), "Tape display not correct after multiply operation");
                Assert.That(tapeEntries[ti].Value, Is.EqualTo(478M), "Tape value not correct after multiply operation");
                Assert.That(tapeEntries[ti].Operation, Is.EqualTo("*"), "Tape operation not correct after multiply operation");
                Assert.That(tapeEntries[ti].IsError, Is.EqualTo(false), "Tape error changed unexpectedly after multiply operation");
            });

            AddKeys(acc, "25+");
            Assert.That(() => currentDisplay, Is.EqualTo("11,950.00").After(timeDelay), "Current display not correct after equals operation");

            Assert.That(() => ti, Is.EqualTo(2).After(timeDelay), "Tape was not correctly populated after equals operation");
            Assert.Multiple(() =>
            {
                // operand line
                Assert.That(tapeEntries[ti - 1].Display, Is.EqualTo("25"), "Tape display not correct after equals operation");
                Assert.That(tapeEntries[ti - 1].Value, Is.EqualTo(25M), "Tape value not correct after equals operation");
                Assert.That(tapeEntries[ti - 1].Operation, Is.EqualTo(""), "Tape operation not correct after equals operation");
                Assert.That(tapeEntries[ti - 1].IsError, Is.EqualTo(false), "Tape error changed unexpectedly after equals operation");
                // result line
                Assert.That(tapeEntries[ti].Display, Is.EqualTo("11,950.00"), "Tape display not correct after equals operation");
                Assert.That(tapeEntries[ti].Value, Is.EqualTo(11_950M), "Tape value not correct after equals operation");
                Assert.That(tapeEntries[ti].Operation, Is.EqualTo("="), "Tape operation not correct after equals operation");
                Assert.That(tapeEntries[ti].IsError, Is.EqualTo(false), "Tape error changed unexpectedly after equals operation");
            });

            // error and recovery

            AddKeys(acc, "TTC");
            AddKeys(acc, "42/0+");
            Assert.That(() => currentDisplay, Is.EqualTo(Core.Accumulator.ErrorDisplay).After(timeDelay), "Current display not receiving error");
            Assert.That(tapeEntries[ti].Display, Is.EqualTo(Core.Accumulator.ErrorDisplay), "Tape display not receiving error");

            AddKeys(acc, "C");
            AddKeys(acc, "42/2+");
            Assert.That(() => currentDisplay, Is.EqualTo("21.00").After(timeDelay), "Current display not correct after recovery from error");
            Assert.That(tapeEntries[ti].Display, Is.EqualTo("21.00"), "Tape not correct after recovery from error");

            // cleanup
            Assert.That(() => {
                acc.DisplayChanged -= displayChangedHandler;
                acc.NewTapeEntryPublished -= newTapeEntryPublished;
            }, Throws.Nothing, "Received an exception when removing event handlers");
        }

        private void AddKeys(Core.Accumulator acc, string keys)
        {
            foreach (var key in keys)
            {
                acc.AddKey(key);
            }
        }

    }
}