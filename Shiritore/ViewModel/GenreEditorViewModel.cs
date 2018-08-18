using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings;
using Shiritore.GameSystem;
using Shiritore.Util;

namespace Shiritore.ViewModel
{
    public class GenreEditorViewModel
    {
        public Genre BaseGenre { get; set; }
        public ReactiveProperty<string> GenreCaption => BaseGenre.GenreCaption;
        public ReactiveCollection<Problem> Problems => BaseGenre.Problems;

        public void ApplyStringToProblems(string text)
        {
            Problems.Clear();
            foreach (string t in new TextElementEnumerable(text))
            {
                var p = new Problem();
                p.ProblemText.Value = t;
                Problems.Add(p);
            }
        }
    }
}
