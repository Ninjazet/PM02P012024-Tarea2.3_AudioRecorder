using AudioRecorder.Views;
using Microsoft.Maui.Controls;

namespace AudioRecorder
{
    public partial class AppShell : Microsoft.Maui.Controls.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(ListaAudioP), typeof(ListaAudioP));

            
        }
    }
}
