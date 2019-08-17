using ImageDemoWPF.Commands;
using ImageDemoWPF.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDemoWPF.ViewModels
{
    public class ImageDemoVM : AbstractViewModel
    {
        //default thumb width or height
        private const int defaultThumbSize = 128;
        private const int defaultJpegQuality = 90;


        public ImageFileInfo ImageFile
        {
            get { return _imageFile; }
            set
            {
                _imageFile = value;
                RaisePropertyChanged("ImageFile");
            }
        }
        private ImageFileInfo _imageFile;


        public string TargetFolder
        {
            get
            {
                if (string.IsNullOrEmpty(_targetFolder))
                    _targetFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                return _targetFolder;
            }
            set
            {
                _targetFolder = value;
                RaisePropertyChanged("TargetFolder");
            }
        }
        private string _targetFolder;


        public int ThumbJpegQuality
        {
            get { return _thumbJpegQuality ?? defaultJpegQuality; }
            set
            {
                _thumbJpegQuality = value;
                RaisePropertyChanged("ThumbJpegQuality");
            }
        }
        private int? _thumbJpegQuality;


        public int ThumbHeight
        {
            get { return _thumbHeight ?? defaultThumbSize; }
            set
            {
                _thumbHeight = value;
                RaisePropertyChanged("ThumbHeight");
            }
        }
        private int? _thumbHeight;


        public int ThumbWidth
        {
            get { return _thumbWidth ?? defaultThumbSize; }
            set
            {
                _thumbWidth = value;
                RaisePropertyChanged("ThumbWidth");
            }
        }
        private int? _thumbWidth;




        public OpenCommand OpenCommand
        {
            set { _openCommand = value; }
            get
            {
                if (_openCommand == null)
                    _openCommand = new OpenCommand(this);
                return _openCommand;
            }
        }
        private OpenCommand _openCommand;


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
