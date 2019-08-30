using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagickDemo.ViewModels;

namespace MagickDemo.Commands
{
    public class ResizeCommand : OptimizeTargetCommand
    {
        public ResizeCommand(MagickDemoVM viewModel) : base(viewModel) { }

        public override void Execute(object parameter)
        {
            //TODO:resize image
            throw new NotImplementedException();

            if (ViewModel.OptimizeTarget)
                base.Execute(parameter);
        }
    }
}
