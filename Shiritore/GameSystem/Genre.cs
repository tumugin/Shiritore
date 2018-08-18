using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Reactive.Bindings;

namespace Shiritore.GameSystem
{
    public class Genre : INotifyPropertyChanged
    {
        public ReactiveCollection<Problem> Problems { get; set; } = new ReactiveCollection<Problem>();
        public ReactiveProperty<string> GenreCaption { get; set; } = new ReactiveProperty<string>();
        public ReactiveProperty<bool> IsPlayed { get; set; } = new ReactiveProperty<bool>(false);

        public ReactiveProperty<string> GenreListCaption { get; } = new ReactiveProperty<string>();

        public int TimerTime { get; set; }
        public bool IsTimerRunning => timertask?.Status == TaskStatus.Running;

        private Task timertask;
        private CancellationTokenSource cts = new CancellationTokenSource();

        public Genre()
        {
            Problems.CollectionChanged += (sender, args) =>
            {
                OnPropertyChanged("Problems");
            };
            GenreCaption.PropertyChanged += (sender, args) =>
                {
                    GenreListCaption.Value = IsPlayed.Value ? "済" : GenreCaption.Value;
                };
            IsPlayed.PropertyChanged += (sender, args) =>
            {
                GenreListCaption.Value = IsPlayed.Value ? "済" : GenreCaption.Value;
            };
        }

        public void StartTimer()
        {
            if (!(timertask?.IsCanceled ?? true)) return;
            cts = new CancellationTokenSource();
            timertask = Task.Run(async () =>
            {
                if (cts.Token.IsCancellationRequested) return;
                TimerTime -= 1;
                await Task.Delay(1000, cts.Token);
            }, cts.Token);
        }

        public void StopTimer()
        {
            try
            {
                cts.Cancel();
                timertask?.Wait();
            }
            catch (OperationCanceledException)
            {
                //Wait()すると必ず例外が発生するので握りつぶす(仕方ないね)
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}