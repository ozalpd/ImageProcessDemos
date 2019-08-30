using ImageDemoWPF.Commands;
using ImageDemo.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageDemo.ViewModels;

namespace ImageDemoWPF.ViewModels
{
    public class ImageDemoVM : AbstractViewModel
    {
        public MakeThumbCommand MakeThumbCommand
        {
            set { _makeThumb = value; }
            get
            {
                if (_makeThumb == null)
                    _makeThumb = new MakeThumbCommand(this);
                return _makeThumb;
            }
        }
        private MakeThumbCommand _makeThumb;


    }
}
