using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Reactive.Bindings;

namespace Shiritore.GameSystem
{
    public class Problem
    {
        public Problem()
        {
            InputTextVertical = InputText.Select(MakeVerticalText).ToReadOnlyReactiveProperty();
            new[] {IsCorrect, IsBonus}.ToList().ForEach(x => x.PropertyChanged += (sender, args) =>
            {
                TextBrush.Value = GetBrush();
            });
        }

        public ReactiveProperty<string> ProblemText { get; set; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> InputText { get; set; } = new ReactiveProperty<string>();
        public ReactiveProperty<bool> IsCorrect { get; set; } = new ReactiveProperty<bool>(false);
        public ReactiveProperty<bool> IsBonus { get; set; } = new ReactiveProperty<bool>(false);

        public ReactiveProperty<Brush> TextBrush { get; } =
            new ReactiveProperty<Brush>(new SolidColorBrush(Colors.White));
        public ReadOnlyReactiveProperty<string> InputTextVertical { get; }

        private string MakeVerticalText(string s)
        {
            if (String.IsNullOrEmpty(s)) return "";
            var rstr = String.Join(Environment.NewLine, s.ToArray());
            return rstr.TrimEnd();
        }

        private Brush GetBrush()
        {
            if (!IsCorrect.Value) return new SolidColorBrush(Colors.White);
            if (IsCorrect.Value && IsBonus.Value) return new SolidColorBrush(Colors.Orange);
            if (IsCorrect.Value) return new SolidColorBrush(Colors.Gray);
            return new SolidColorBrush(Colors.White);
        }
    }
}