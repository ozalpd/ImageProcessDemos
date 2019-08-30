﻿using ImageDemo.Models;
using ImageDemo.ViewModels;
using System.ComponentModel;

namespace ImageDemo.Commands
{
    public abstract class AbstractImageCommand : AbstractCommand
    {
        public AbstractImageCommand(AbstractViewModel viewModel) : base(viewModel)
        {
            viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        protected ImageFileInfo ImageFile { get { return ViewModel.ImageFile; } }

        public override bool CanExecute(object parameter)
        {
            return ImageFile != null && ImageFile.Exists;
        }

        protected virtual void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("ImageFile"))
                RaiseCanExecuteChanged();
        }
    }
}
