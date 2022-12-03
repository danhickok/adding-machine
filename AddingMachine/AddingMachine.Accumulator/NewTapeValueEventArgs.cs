namespace AddingMachine.Accumulator
{
    public class NewTapeValueEventArgs
    {
        public readonly string Display;
        public readonly string Value;
        public readonly string Operation;

        public NewTapeValueEventArgs(string display, string value, string operation)
        {
            Display = display;
            Value = value;
            Operation = operation;
        }
    }
}
