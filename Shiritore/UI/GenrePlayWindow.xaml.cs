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
using System.Windows.Shapes;
using Shiritore.GameSystem;
using Shiritore.ViewModel;

namespace Shiritore.UI
{
    public partial class GenrePlayWindow : Window
    {
        private GenrePlayWindowViewModel viewModel;

        public GenrePlayWindow(Genre genre)
        {
            InitializeComponent();
            viewModel = new GenrePlayWindowViewModel(genre);
            this.DataContext = viewModel;
        }
    }
}
