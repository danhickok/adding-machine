namespace AddingMachine.Core
{
    public class TapeEntry
    {
        public string Display { get; set; } = "";
        public decimal Value { get; set; } = 0M;
        public string Operation { get; set; } = "";
        public bool IsError { get; set; } = false;

        public TapeEntry Copy()
        {
            return new TapeEntry
            {
                Display = Display,
                Value = Value,
                Operation = Operation,
                IsError = IsError
            };
        }

        public override string ToString() => $"{Display}\t{Value}\t{Operation}\t{IsError}";

        public void FromString(string value)
        {
            var values = value.Split('\t');
            Display = values[0];
            Value = decimal.Parse(values[1]);
            Operation = values[2];
            IsError = bool.Parse(values[3]);
        }
    }
}
