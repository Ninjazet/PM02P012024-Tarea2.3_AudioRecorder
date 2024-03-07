using AudioRecorder.Controllers;

internal static class AppHelpers
{
    static AudioDB basedatos;
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