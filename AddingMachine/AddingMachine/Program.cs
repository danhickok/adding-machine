namespace AddingMachine
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            
            var mainForm = new MainForm();
            //TODO: instantiate Accumulator, AppConfig, NumericDisplayHandler, and TapeHandler, and pass them to mainForm

            Application.Run(mainForm);
        }
    }
}