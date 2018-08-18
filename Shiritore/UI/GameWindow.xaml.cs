using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Shiritore.GameSystem;
using Shiritore.ViewModel;

namespace Shiritore.UI
{
    public partial class GameWindow : Window
    {
        private GameWindowViewModel viewModel = new GameWindowViewModel();

        public GameWindow()
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }

        public void setGenre(Genre genre)
        {
            viewModel.PlayGenre.Value = genre;
        }

        public void setIsPlayingGame(bool isplaying)
        {
            viewModel.IsPlayingGame.Value = isplaying;
        }

        public void ResetBinding()
        {
            this.DataContext = null;
            this.DataContext = viewModel;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
