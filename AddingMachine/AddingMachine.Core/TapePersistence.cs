using System.Diagnostics;

namespace AddingMachine.Core
{
    public class TapePersistence
    {
        private readonly string _defaultTapePath;

        public TapePersistence() : this(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
            @"\AddingMachine\DefaultTape.amt")
        {
        }

        public TapePersistence(string defaultTapePath)
        {
            _defaultTapePath = defaultTapePath;
        }

        public List<TapeEntry> Load(string? tapePath = null)
        {
            Debug.Print(_defaultTapePath);
            throw new NotImplementedException();
        }

        public void Save(string? tapePath = null)
        {
            throw new NotImplementedException();
        }
    }
}
