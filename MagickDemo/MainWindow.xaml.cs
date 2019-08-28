using ImageMagick;
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
            StartupFile = new FileInfo(startupFile);
        }

        public FileInfo StartupFile { get; private set; }

        private void SaveICO(FileInfo inputFile)
        {
            using (MagickImage image = new MagickImage(inputFile))
            {
                image.Settings.SetDefine(MagickFormat.Icon, "auto-resize", "256,128,64,48,32,16");
                image.Write(inputFile.Replace(inputFile.Extension, ".ico"));
            }
        }
    }
}
