using ImageMagick;
using MagickDemo.ViewModels;

namespace MagickDemo.Commands
{
    public class MakeWin32Icon : OptimizeTargetCommand
    {
        public MakeWin32Icon(MagickDemoVM viewModel) : base(viewModel) { }


        public override void Execute(object parameter)
        {
            ViewModel.CreateTargetDirectory();

            string targetExt = ViewModel.TargetExtension;
            ViewModel.TargetExtension = ".ico";

            using (var image = new MagickImage(ImageFile.FullName))
            {
                if (ImageFile.Width > ImageFile.Height)
                {
                    image.Crop(ImageFile.Height, ImageFile.Height, Gravity.Center);
                }
                else if (ImageFile.Height > ImageFile.Width)
                {
                    image.Crop(ImageFile.Width, ImageFile.Width, Gravity.Center);
                }


                image.Settings.SetDefine(MagickFormat.Icon, "auto-resize", "256,128,64,48,32,16");
                image.Write(ViewModel.TargetFileName);
            }

            if (ViewModel.OptimizeTarget)
                base.Execute(parameter);


            ViewModel.TargetExtension = targetExt;
        }
    }
}
