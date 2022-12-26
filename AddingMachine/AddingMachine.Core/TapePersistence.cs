namespace AddingMachine.Core
{
    public class TapePersistence
    {
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
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        var entry = new TapeEntry();
                        entry.FromString(line ?? "");
                        data.Add(entry);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                // ignore file not found errors
            }
            catch(Exception)
            {
                throw;
            }

            return data;
        }

        public void Save(List<TapeEntry> data)
        {
            using (var sw = new StreamWriter(_path))
            {
                foreach (var entry in data)
                    sw.WriteLine(entry.ToString());
            }
        }
    }
}
