using ImageDemoWPF.ViewModels;
using System;
using System.Windows.Input;

namespace ImageDemoWPF.Commands
{
    public abstract class AbstractCommand : ICommand
    {
        public AbstractCommand(ImageDemoVM viewModel)
        {
            ViewModel = viewModel;
        }
        public ImageDemoVM ViewModel { get; private set; }

        public abstract void Execute(object parameter);

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        protected virtual void RaiseCanExecuteChanged(object sender = null, EventArgs e = null)
        {
            if (sender == null)
                sender = this;
            if (e == null)
                e = new EventArgs();

            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(sender, e);
            }
        }
        public event EventHandler CanExecuteChanged;
    }
}
