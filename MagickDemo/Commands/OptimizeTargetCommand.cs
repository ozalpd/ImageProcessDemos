using ImageDemo.Commands;
using ImageMagick;
using MagickDemo.ViewModels;
using System;
using System.IO;

namespace MagickDemo.Commands
{
    public class OptimizeTargetCommand : AbstractImageCommand
    {
        public OptimizeTargetCommand(MagickDemoVM viewModel) : base(viewModel) { }

        public new MagickDemoVM ViewModel { get => (MagickDemoVM)base.ViewModel; }

        public override void Execute(object parameter)
        {
            if (!File.Exists(ViewModel.TargetFileName))
            {
                ViewModel.CreateTargetDirectory();

                if (ImageFile.Extension.Equals(ViewModel.TargetExtension, StringComparison.InvariantCultureIgnoreCase))
                {
                    File.Copy(ImageFile.FullName, ViewModel.TargetFileName);
                }
                else
                {
                    using (var image = new MagickImage(ImageFile.FullName))
                    {
                        image.Strip();
                        image.Write(ViewModel.TargetFileName);
                    }
                }
            }

            var imageOptimizer = new ImageOptimizer
            {
                OptimalCompression = true
            };
            imageOptimizer.LosslessCompress(ViewModel.TargetFileName);
        }
    }
}
