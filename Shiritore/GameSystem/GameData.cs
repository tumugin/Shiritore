using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shiritore.GameSystem
{
    public class GameData
    {
        public ObservableCollection<Genre> Genres { get; set; } = new ObservableCollection<Genre>();
    }
}
