using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageMagick;
using MagickDemo.ViewModels;

namespace MagickDemo.Commands
{
    public class ResizeCommand : OptimizeTargetCommand
    {
        public ResizeCommand(MagickDemoVM viewModel) : base(viewModel) { }

        public override void Execute(object parameter)
        {
            DateTime startTime = DateTime.Now;
            ViewModel.CreateTargetDirectory();

            using (var image = new MagickImage(ImageFile.FullName))
            {
                MagickGeometry size;
                bool cropIt = false;
                if (ViewModel.KeepAspectRatio) //Keep Aspect Ratio by cropping
                {
                    double rateW = (double)ViewModel.TargetWidth / ImageFile.Width;
                    double rateH = (double)ViewModel.TargetHeight / ImageFile.Height;

                    size = rateH > rateW
                         ? new MagickGeometry((int)(ImageFile.Width * rateH), ViewModel.TargetHeight)
                         : rateH < rateW
                         ? new MagickGeometry(ViewModel.TargetWidth, (int)(ImageFile.Height * rateW))
                         : new MagickGeometry(ViewModel.TargetWidth, ViewModel.TargetHeight);

                    cropIt = (rateH < rateW) || (rateH > rateW);
                }
                else
                {
                    size = new MagickGeometry(ViewModel.TargetWidth, ViewModel.TargetHeight);
                }

                size.IgnoreAspectRatio = !ViewModel.KeepAspectRatio;
                image.Resize(size);

                if (cropIt)
                {
                    image.Crop(ViewModel.TargetWidth, ViewModel.TargetHeight, Gravity.Center);
                }

                image.Write(ViewModel.TargetResizeFileName);
            }

            if (ViewModel.OptimizeTarget)
                base.Execute(ViewModel.TargetResizeFileName);

            ViewModel.ElapsedTime = DateTime.Now.Subtract(startTime);
        }
    }
}
