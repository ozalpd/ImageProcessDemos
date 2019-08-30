﻿using ImageDemo.Models;
using ImageDemo.ViewModels;
using Microsoft.Win32;

namespace ImageDemo.Commands
{
    public class OpenCommand : AbstractCommand
    {
        public OpenCommand(AbstractViewModel viewModel) : base(viewModel) { }

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
