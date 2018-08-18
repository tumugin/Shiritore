using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings;

namespace Shiritore.GameSystem
{
    public class GameData
    {
        public ReactiveCollection<Genre> Genres { get; set; } = new ReactiveCollection<Genre>();
    }
}
