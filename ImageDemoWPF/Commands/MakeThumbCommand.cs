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
            return ImageFile != null;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("ImageFile"))
                RaiseCanExecuteChanged();
        }

        public override void Execute(object parameter)
        {
            var job = GetImageJob(ImageFile.Extension);
            job.Build();
        }


        protected ImageJob GetImageJob(string format)
        {
            var instructions = new Instructions()
            {
                Format = format,
                Height = ViewModel.ThumbHeight,
                Width = ViewModel.ThumbWidth,
                JpegQuality = ViewModel.ThumbJpegQuality,
                Mode = FitMode.Crop
            };

            return new ImageJob(source: ImageFile.FullName,
                                dest: Path.Combine(ViewModel.TargetFolder, ImageFile.Name),
                                instructions: instructions);
        }
    }
}
