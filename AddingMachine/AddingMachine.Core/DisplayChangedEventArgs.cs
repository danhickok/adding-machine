namespace AddingMachine.Core
{
    public class DisplayChangedEventArgs : EventArgs
    {
        public readonly string Display;

        public DisplayChangedEventArgs(string display)
        {
            Display = display;
        }
    }
}
