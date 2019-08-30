using ImageDemo.Models;
using ImageMagick;
using MagickDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace MagickDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(string startupFile) : this()
        {
            StartupFile = startupFile;
        }

        public string StartupFile { get; private set; }
        public MagickDemoVM ViewModel { get { return (MagickDemoVM)DataContext; } }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(StartupFile))
            {
                ViewModel.ImageFile = new ImageFileInfo(StartupFile);
            }
        }
    }
}
