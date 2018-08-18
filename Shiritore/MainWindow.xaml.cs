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
using Microsoft.Win32;
using Newtonsoft.Json;
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

        public void ResetBinding()
        {
            this.DataContext = null;
            this.DataContext = viewmodel;
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

        private async void SaveGameButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "JSONファイル(.json)|*.json";
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    await Task.Run(() => { viewmodel.SaveConfig(dialog.FileName); });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "正常に保存できませんでした", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void LoadGameButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "JSONファイル(.json)|*.json";
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    viewmodel.LoadConfig(dialog.FileName);
                    this.ResetBinding();
                    gameWindow.ResetBinding();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "正常に保存できませんでした", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ResetGameDataButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("本当にデータをクリアしますか？", "確認", MessageBoxButton.OKCancel, MessageBoxImage.Question) ==
                MessageBoxResult.OK)
            {
                SettingStore.SingletonStore.ShiritoreGameData.Genres.Clear();
            }
        }

        private void OpenHideGameWindowButton_Click(object sender, RoutedEventArgs e)
        {
            if (gameWindow.IsVisible)
            {
                gameWindow.Hide();
            }
            else
            {
                gameWindow.Show();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void DeleteSelectedGenreButton_Click(object sender, RoutedEventArgs e)
        {
            var removerlist = new List<Genre>();
            foreach (var selectedItem in GenreListView.SelectedItems)
            {
                removerlist.Add(selectedItem as Genre);
            }
            viewmodel.DeleteGenres(removerlist);
        }
    }
}