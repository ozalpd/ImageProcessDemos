using ImageDemoWPF.Models;
using ImageDemoWPF.ViewModels;
using ImageResizer;
using System;
using System.ComponentModel;
using System.IO;

namespace ImageDemoWPF.Commands
{
    public class MakeThumbCommand : AbstractCommand
    {
        public MakeThumbCommand(ImageDemoVM viewModel) : base(viewModel)
        {
            viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private ImageFileInfo ImageFile { get { return ViewModel.ImageFile; } }

        public override bool CanExecute(object parameter)
        {
            return ImageFile != null && ImageFile.Exists;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("ImageFile"))
                RaiseCanExecuteChanged();
        }

        public override void Execute(object parameter)
        {
            var job = GetImageJob();
            job.CreateParentDirectory = true;
            job.Build();
        }


        private ImageJob GetImageJob()
        {
            var instructions = new Instructions()
            {
                Format = ViewModel.TargetExtension,
                Height = ViewModel.ThumbHeight,
                Width = ViewModel.ThumbWidth,
                JpegQuality = ViewModel.TargetJpegQuality,
                Mode = FitMode.Crop
            };

            return new ImageJob(source: ImageFile.FullName,
                                dest: ViewModel.FullTargetName,
                                instructions: instructions);
        }
    }
}
