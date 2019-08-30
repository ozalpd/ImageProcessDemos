using ImageDemo.Commands;
using ImageDemo.Models;
using ImageDemoWPF.ViewModels;
using ImageResizer;
using System;
using System.ComponentModel;
using System.IO;

namespace ImageDemoWPF.Commands
{
    public class MakeThumbCommand : AbstractImageCommand
    {
        public MakeThumbCommand(ImageDemoVM viewModel) : base(viewModel) { }


        public override void Execute(object parameter)
        {
            DateTime startTime = DateTime.Now;

            var job = GetImageJob();
            job.CreateParentDirectory = true;
            job.Build();

            ViewModel.ElapsedTime = DateTime.Now.Subtract(startTime);
        }


        private ImageJob GetImageJob()
        {
            var instructions = new Instructions()
            {
                Format = ViewModel.TargetExtension,
                Height = ViewModel.TargetHeight,
                Width = ViewModel.TargetWidth,
                JpegQuality = ViewModel.TargetJpegQuality,
                Mode = FitMode.Crop
            };

            return new ImageJob(source: ImageFile.FullName,
                                dest: ViewModel.TargetResizeFileName,
                                instructions: instructions);
        }
    }
}
