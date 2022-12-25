using AddingMachine.Core;
using System.Reflection.Metadata;

namespace AddingMachine.Tests
{
    public class TapePersistenceTests
    {
        const string TestFilePath = @"C:\temp\TestTape.amt";
        const string TestDefaultPath = @"C:\temp\DefaultTape.amt";
        readonly List<TapeEntry> _testData = new()
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
                File.Delete(TestFilePath);
            }
            catch
            {
                // ignore
            }
            
            try
            {
                File.Delete(TestDefaultPath);
            }
            catch
            {
                // ignore
            }
        }

        private void SeedFile(string filePath)
        {
            using (var sw = new StreamWriter(filePath))
            {
                foreach (var line in _testData)
                sw.WriteLine(line.ToString());
            }
        }


        [Test]
        public void TapePersistenceLoadTest()
        {
            var tp = new TapePersistence(TestDefaultPath);

            var result = tp.Load();
            Assert.That(result, Is.Not.Null, "Initial load of nonexistent default tape resulted in a null value");
            Assert.That(result, Is.Empty, "Initial load of nonexistent default tape resulted in a non-empty list");

            SeedFile(TestDefaultPath);

            result = tp.Load();
            Assert.That(result.Count, Is.EqualTo(_testData.Count), "Load of default tape resulted in an incorrect count");
            for (var i = 0; i < _testData.Count; ++i)
            {
                //TODO: LEFT OFF HERE
            }
        }

        [Test]
        public void TapePersistenceSaveTest()
        {
            var tp = new TapePersistence();
            tp.Save();
        }
    }
}
