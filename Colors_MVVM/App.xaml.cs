using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Colors_MVVM.ViewModels;
using Colors_MVVM.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace Colors_MVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            MainWindow view = new MainWindow();
            ColorViewModel color = new ColorViewModel();
            MainViewModel viewModel = new MainViewModel(color);
            view.DataContext = viewModel;
            view.Show();
        }
    }
}
