using Directory_Bomb.Forms;

namespace Directory_Bomb
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new BombForm());
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
    }
}