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

            DateTime startTime = DateTime.Now;
            bool setElapsedTime = false;
            string targetFile;
            if (parameter is string && File.Exists((string)parameter))
            {
                targetFile = (string)parameter;
            }
            else if (!File.Exists(ViewModel.TargetFileName))
            {
                ViewModel.CreateTargetDirectory();
                targetFile = ViewModel.TargetFileName;
                setElapsedTime = true;
                if (ImageFile.Extension.Equals(ViewModel.TargetExtension, StringComparison.InvariantCultureIgnoreCase))
                {
                    File.Copy(ImageFile.FullName, targetFile);
                }
                else
                {
                    using (var image = new MagickImage(ImageFile.FullName))
                    {
                        image.Strip();
                        image.Write(targetFile);
                    }
                }
            }
            else
            {
                targetFile = ViewModel.TargetFileName;
                setElapsedTime = true;
            }

            var imageOptimizer = new ImageOptimizer
            {
                OptimalCompression = true
            };
            imageOptimizer.LosslessCompress(targetFile);

            if (setElapsedTime)
                ViewModel.ElapsedTime = DateTime.Now.Subtract(startTime);
        }
    }
}
