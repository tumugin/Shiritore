using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings;
using Shiritore.GameSystem;
using Shiritore.Setting;

namespace Shiritore.ViewModel
{
    public class MainWindowViewModel
    {
        public SettingStore Store => SettingStore.SingletonStore;
        public ReactiveCollection<Genre> Genres => Store.ShiritoreGameData.Genres;

        public Genre CreateNewGenreData()
        {
            var genre = new Genre();
            genre.GenreCaption.Value = "新しいジャンル";
            "テストデータ".ToCharArray().ToList().ForEach(s =>
            {
                var p = new Problem();
                p.ProblemText.Value = s.ToString();
                genre.Problems.Add(p);
            });
            Genres.Add(genre);
            return genre;
        }

        public void LoadConfig(string path)
        {
            var bary = System.IO.File.ReadAllBytes(path);
            var rawjson = Encoding.UTF8.GetString(bary);
            var config = SettingStore.loadSettingJSON(rawjson);
            SettingStore.SingletonStore = config;
        }

        public void SaveConfig(string path)
        {
            var json = SettingStore.getSettingJSON(SettingStore.SingletonStore);
            var bary = Encoding.UTF8.GetBytes(json);
            System.IO.File.WriteAllBytes(path, bary);
        }

        public void DeleteGenres(IEnumerable<Genre> list)
        {
            list.ToList().ForEach(x => { Genres.Remove(x); });
        }
    }
}