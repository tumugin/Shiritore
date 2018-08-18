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
    }
}