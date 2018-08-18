using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings;
using Shiritore.GameSystem;

namespace Shiritore.ViewModel
{
    public class GenrePlayWindowViewModel
    {
        public Genre BaseGenre { get; set; }
        public ReactiveCollection<Problem> Problems => BaseGenre.Problems;
        public ReactiveProperty<string> GenreCaption => BaseGenre.GenreCaption;
        public ReactiveProperty<bool> IsPlayed => BaseGenre.IsPlayed;

        public GenrePlayWindowViewModel(Genre genre)
        {
            BaseGenre = genre;
        }
    }
}
