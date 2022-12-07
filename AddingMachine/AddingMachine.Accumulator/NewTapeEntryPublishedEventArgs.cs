namespace AddingMachine.Core
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
