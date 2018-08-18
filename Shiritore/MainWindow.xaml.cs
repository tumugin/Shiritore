using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Shiritore.GameSystem;
using Shiritore.Setting;
using Shiritore.UI;
using Shiritore.ViewModel;

namespace Shiritore
{
    public partial class MainWindow : Window
    {
        private MainWindowViewModel viewmodel = new MainWindowViewModel();
        private GameWindow gameWindow = new GameWindow();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = viewmodel;
            gameWindow.Show();
        }

        private void AddGenreButton_Click(object sender, RoutedEventArgs e)
        {
            var genre = viewmodel.CreateNewGenreData();
            (new GenreEditor(genre)).ShowDialog();
            gameWindow.setIsPlayingGame(false);
        }

        public void OnPlayGenre(Genre genre)
        {
            gameWindow.setGenre(genre);
            gameWindow.setIsPlayingGame(true);
            (new GenrePlayWindow(genre)).ShowDialog();
            gameWindow.setIsPlayingGame(false);
        }

        public void OnEditGenre(Genre genre)
        {
            (new GenreEditor(genre)).ShowDialog();
        }
    }
}
