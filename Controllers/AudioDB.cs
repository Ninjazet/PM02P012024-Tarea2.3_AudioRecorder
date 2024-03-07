using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using AudioRecorder.Models;

namespace AudioRecorder.Controllers
{
    public class AudioDB
    {
        readonly SQLiteAsyncConnection db;

        public AudioDB(string pathdb)
        {
            db = new SQLiteAsyncConnection(pathdb);
            db.CreateTableAsync<AudioModel>().Wait();
        }

        public Task<List<AudioModel>> ObtenerListaAudios()
        {
            return db.Table<AudioModel>().ToListAsync();
        }

        public Task<AudioModel> ObtenerAudio(int pcodigo)
        {
            return db.Table<AudioModel>()
                .Where(i => i.Id == pcodigo)
                .FirstOrDefaultAsync();
        }

        public Task<int> GrabarAudio(AudioModel audio)
        {
            if (audio.Id != 0)
            {
                return db.UpdateAsync(audio);
            }
            else
            {
                return db.InsertAsync(audio);
            }
        }

        public Task<int> EliminarAudio(AudioModel audio)
        {
            return db.DeleteAsync(audio);
        }


    }
}
