using AddingMachine.Core;
using System.Reflection.Metadata;

namespace AddingMachine.Tests
{
    public class TapePersistenceTests
    {
        private const string _testFilePath = @"C:\temp\TestTape.amt";
        private const string _testAlternatePath = @"C:\temp\TestTapeAlternate.amt";

        private readonly List<TapeEntry> _testData = new()
        {
            new TapeEntry { Display = "833.719", Value = 833.719M, Operation = "+", IsError = false },
            new TapeEntry { Display = "265.381", Value = 265.381M, Operation = "-", IsError = false },
            new TapeEntry { Display = "568.338", Value = 568.338M, Operation = "T", IsError = false },
            new TapeEntry { Display = "", Value = 0M, Operation = "", IsError = false },
            new TapeEntry { Display = "568.338", Value = 568.338M, Operation = "GT", IsError = false },
            new TapeEntry { Display = "", Value = 0M, Operation = "", IsError = false },
            new TapeEntry { Display = "", Value = 0M, Operation = "", IsError = false },
            new TapeEntry { Display = "0.", Value = 0M, Operation = "GT", IsError = false },
            new TapeEntry { Display = "", Value = 0M, Operation = "", IsError = false },
            new TapeEntry { Display = "", Value = 0M, Operation = "", IsError = false },
            new TapeEntry { Display = "0.", Value = 0M, Operation = "C", IsError = false },
            new TapeEntry { Display = "", Value = 0M, Operation = "", IsError = false },
        };

        [SetUp]
        public void SetUp()
        {
            RemoveTestFiles();
        }

        [TearDown]
        public void TearDown()
        {
            RemoveTestFiles();
        }

        private void RemoveTestFiles()
        {
            try
            {
                File.Delete(_testFilePath);
            }
            catch
            {
                // ignore
            }

            try
            {
                File.Delete(_testAlternatePath);
            }
            catch
            {
                // ignore
            }
        }

        private void CreateTestDataFile(string filePath)
        {
            using (var sw = new StreamWriter(filePath))
            {
                sw.WriteLine(TapePersistence.VersionCode);
                foreach (var line in _testData)
                    sw.WriteLine(line.ToString());
            }
        }


        [Test]
        public void TapePersistenceLoadTest()
        {
            var tp = new TapePersistence(_testFilePath);

            var result = tp.Load();
            Assert.That(result, Is.Not.Null, "Initial load of nonexistent default tape resulted in a null value");
            Assert.That(result, Is.Empty, "Initial load of nonexistent default tape resulted in a non-empty list");

            CreateTestDataFile(_testFilePath);

            result = tp.Load();
            Assert.That(result.Count, Is.EqualTo(_testData.Count), "Load of default tape resulted in an incorrect count");
            for (var i = 0; i < _testData.Count; ++i)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(result[i].Display, Is.EqualTo(_testData[i].Display), $"Loaded item {i} Display does not match test data");
                    Assert.That(result[i].Value, Is.EqualTo(_testData[i].Value), $"Loaded item {i} Value does not match test data");
                    Assert.That(result[i].Operation, Is.EqualTo(_testData[i].Operation), $"Loaded item {i} Operation does not match test data");
                    Assert.That(result[i].IsError, Is.EqualTo(_testData[i].IsError), $"Loaded item {i} IsError does not match test data");
                });
            }

            RemoveTestFiles();

            using (var sw = new StreamWriter(_testFilePath))
            {
                sw.WriteLine("This is garbage data");
            }

            Assert.That(() => {
                result = tp.Load();
            }, Throws.Exception, "Loading garbage data did not throw an exception");
        }

        [Test]
        public void TapePersistenceSaveTest()
        {
            CreateTestDataFile(_testAlternatePath);

            var tp = new TapePersistence(_testFilePath);
            tp.Save(_testData);

            var testFile = new FileInfo(_testFilePath);
            var altFile = new FileInfo(_testAlternatePath);
            Assert.That(testFile.Exists, "Save operation did not create expected file");
            Assert.That(testFile.Length, Is.EqualTo(altFile.Length), "Save operation did not create file of expected size");
        }
    }
}
