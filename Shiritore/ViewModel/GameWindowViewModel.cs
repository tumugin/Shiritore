using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Reactive.Bindings;
using Shiritore.GameSystem;
using Shiritore.Setting;

namespace Shiritore.ViewModel
{
    public class GameWindowViewModel
    {
        public SettingStore Store => SettingStore.SingletonStore;

        public ReactiveCollection<Genre> Genres => Store.ShiritoreGameData.Genres;
        public ReactiveProperty<Genre> PlayGenre { get; } = new ReactiveProperty<Genre>();
        public ReactiveProperty<bool> IsPlayingGame { get; } = new ReactiveProperty<bool>(false);
        public ReadOnlyReactiveProperty<Visibility> IsShowingGenreUI { get; }
        public ReadOnlyReactiveProperty<Visibility> IsShowingShiritoreUI { get; }
        public ReactiveProperty<Visibility> hoge { get; } = new ReactiveProperty<Visibility>(Visibility.Collapsed);

        public GameWindowViewModel()
        {
            IsShowingGenreUI = IsPlayingGame.Select(x => x ? Visibility.Collapsed : Visibility.Visible)
                .ToReadOnlyReactiveProperty(Visibility.Visible);
            IsShowingShiritoreUI = IsPlayingGame.Select(x => x ? Visibility.Visible : Visibility.Collapsed)
                .ToReadOnlyReactiveProperty(Visibility.Collapsed);
        }
    }
}