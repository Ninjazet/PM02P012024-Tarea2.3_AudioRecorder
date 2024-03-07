using AudioRecorder.Models;
using Plugin.AudioRecorder;
using Plugin.Maui.AudioRecorder.Abstractions;

namespace AudioRecorder.Views
{
  
    public partial class ListaAudioP : ContentPage
    {
        private readonly AudioPlayer audioPlayer = new AudioPlayer();
        Models.AudioModel audio;

        //public AudioModel audio { get; set; }
        public ListaAudioP()
        {
            InitializeComponent();
        }
        private void listaAudios_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            audio = (Models.AudioModel)e.Item;

        }

        private async void btndelete_Invoked(object sender, EventArgs e)
        {
            if (audio != null)
            {
                if (await DisplayAlert("Eliminar audio", $"¿Está seguro de eliminar el audio seleccionado: {audio.Descripcion} ?", "SI", "NO"))
                {
                    await App.Basedatos.EliminarAudio(audio);
                    await Navigation.PopAsync();
                }
            }
            else
            {
                await DisplayAlert("Notificación", "Haga clic sobre el elemento que desea reproducir o eliminar", "OK");
            }

        }
        private async void btnplay_Invoked(object sender, EventArgs e)
        {
            if (audio != null)
            {
                var ruta = await App.Basedatos.ObtenerAudio(audio.Id);
                audioPlayer.Play(ruta.Url);
            }
            else
            {
                await DisplayAlert("Notificación", "Haga clic sobre el elemento que desea reproducir o eliminar", "OK");
            }

        }
        
     
        protected override async void OnAppearing()
        {
            base.OnAppearing(); 
            listaAudios.ItemsSource = await App.Basedatos.ObtenerListaAudios();
        }
        
    }
   

}

