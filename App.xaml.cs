using AudioRecorder.Controllers;
using AudioRecorder.Models;
namespace AudioRecorder
{
    public partial class App : Application
    {
        static AudioDB basedatos;
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
        public static AudioDB Basedatos
        {
            get
            {
                if (basedatos == null)
                {
                    basedatos = new AudioDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AudiosDB.db3"));
                }
                return basedatos;

            }
        }
    }
}
