using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shiritore.GameSystem
{
    public class Genre : INotifyPropertyChanged
    {
        public ObservableCollection<Problem> Problems { get; set; } = new ObservableCollection<Problem>();

        private string genreCaption;
        public string GenreCaption
        {
            get => genreCaption;
            set
            {
                genreCaption = value;
                OnPropertyChanged();
            }
        }

        public int TimerTime { get; set; }
        public bool IsTimerRunning => timertask?.Status == TaskStatus.Running;

        private Task timertask;
        private CancellationTokenSource cts = new CancellationTokenSource();

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

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // Raise the PropertyChanged event, passing the name of the property whose value has changed.
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}