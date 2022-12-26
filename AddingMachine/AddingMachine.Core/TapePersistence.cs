namespace AddingMachine.Core
{
    public class TapePersistence
    {
        public const string VersionCode = "ver1";

        private readonly string _path;

        public TapePersistence(string path)
        {
            _path = path;
        }

        public List<TapeEntry> Load()
        {
            var data = new List<TapeEntry>();

            try
            {
                using (var sr = new StreamReader(_path))
                {
                    var firstLine = sr.ReadLine();
                    if (firstLine != VersionCode)
                        throw new InvalidTapeFileFormatException();

                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        data.Add(new TapeEntry(line ?? ""));
                    }
                }
            }
            catch (FileNotFoundException)
            {
                // ignore file not found errors - just return the empty list
            }
            catch(Exception)
            {
                throw;
            }

            return data;
        }

        public void Save(List<TapeEntry> data)
        {
            using (var sw = new StreamWriter(_path, false))
            {
                sw.WriteLine(VersionCode);
                foreach (var entry in data)
                    sw.WriteLine(entry.ToString());
            }
        }
    }
}
