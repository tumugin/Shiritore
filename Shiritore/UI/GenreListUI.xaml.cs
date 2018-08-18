using System;
using System.Collections.Generic;
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
using Shiritore.Util;

namespace Shiritore.UI
{
    /// <summary>
    /// GenreListUI.xaml の相互作用ロジック
    /// </summary>
    public partial class GenreListUI : GridView
    {
        public GenreListUI()
        {
            InitializeComponent();
        }

        private void PlayGenreButton_Click(object sender, RoutedEventArgs e)
        {
            var mainwindow = SeaSlug.GetAncestorOfType<MainWindow>(sender as Button);
            var lviewitem = SeaSlug.GetAncestorOfType<ListViewItem>(sender as Button);
            mainwindow.OnPlayGenre(lviewitem.DataContext as Genre);
        }

        private void EditGenreButton_Click(object sender, RoutedEventArgs e)
        {
            var mainwindow = SeaSlug.GetAncestorOfType<MainWindow>(sender as Button);
            var lviewitem = SeaSlug.GetAncestorOfType<ListViewItem>(sender as Button);
            mainwindow.OnEditGenre(lviewitem.DataContext as Genre);
        }
    }
}