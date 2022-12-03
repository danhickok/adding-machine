namespace AddingMachine.Accumulator
{
    public class NewTapeEntryPublishedEventArgs : EventArgs
    {
        public readonly TapeEntry NewTapeEntry;

        public NewTapeEntryPublishedEventArgs(TapeEntry newTapeEntry)
        {
            NewTapeEntry = newTapeEntry;
        }
    }
}
