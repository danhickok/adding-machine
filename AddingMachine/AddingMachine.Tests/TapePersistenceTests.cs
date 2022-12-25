using AddingMachine.Core;
using System.Reflection.Metadata;

namespace AddingMachine.Tests
{
    public class TapePersistenceTests
    {
        const string TestFilePath = @"C:\temp\TestTape.amt";
        const string TestDefaultPath = @"C:\temp\DefaultTape.amt";

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

        [Test]
        public void TapePersistenceLoadTest()
        {
            var tp = new TapePersistence(TestDefaultPath);

            var result = tp.Load();
            Assert.That(result, Is.Not.Null, "Initial load of nonexistent default tape resulted in a null value");
            Assert.That(result.Count, Is.EqualTo(0), "Initial load of nonexistent default tape resulted in a non-empty list");
        }

        [Test]
        public void TapePersistenceSaveTest()
        {
            var tp = new TapePersistence();
            tp.Save();
        }
    }
}
