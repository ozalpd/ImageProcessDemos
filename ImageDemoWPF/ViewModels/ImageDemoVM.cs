using ImageDemoWPF.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDemoWPF.ViewModels
{
    public class ImageDemoVM : AbstractViewModel
    {
        public ImageFileInfo ImageFile
        {
            get { return _imageFile; }
            set
            {
                _imageFile = value;
                RaisePropertyChanged("ImageFile");
            }
        }
        private ImageFileInfo _imageFile;


        public OpenCommand OpenCmd
        {
            set { _openCommand = value; }
            get
            {
                if (_openCommand == null)
                    _openCommand = new OpenCommand(this);
                return _openCommand;
            }
        }
        private OpenCommand _openCommand;



        public class OpenCommand : AbstractCommand
        {
            public OpenCommand(ImageDemoVM viewModel)
            {
                ViewModel = viewModel;
            }

            public ImageDemoVM ViewModel { get; private set; }

            public override void Execute(object parameter)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                                        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                                        "Portable Network Graphic (*.png)|*.png";

                if (openFileDialog.ShowDialog() != true)
                    return;

                ViewModel.ImageFile = new ImageFileInfo(openFileDialog.FileName);
            }
        }
    }
}
