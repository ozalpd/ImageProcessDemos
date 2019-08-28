using ImageDemo.Models;
using System;
using System.ComponentModel;
using System.IO;

namespace ImageDemo.ViewModels
{
    public class AbstractViewModel : INotifyPropertyChanged
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


        public string FullTargetName
        {
            get
            {
                if (ImageFile == null)
                    return string.Empty;

                if (ThumbWidth == ThumbHeight)
                {
                    return Path.Combine(TargetFolder,
                            string.Format("{0}-{1}{2}",
                                       Path.GetFileNameWithoutExtension(ImageFile.Name),
                                       ThumbHeight,
                                       TargetExtension));
                }
                else
                {
                    return Path.Combine(TargetFolder,
                            string.Format("{0}-{1}x{2}{3}",
                                       Path.GetFileNameWithoutExtension(ImageFile.Name),
                                       ThumbWidth,
                                       ThumbHeight,
                                       TargetExtension));
                }
            }
        }

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

        public string TargetExtension
        {
            get
            {
                return ImageFile != null ? ImageFile.Extension : string.Empty;
            }
        }

        public int TargetJpegQuality
        {
            get { return _jpegQuality ?? defaultJpegQuality; }
            set
            {
                _jpegQuality = value;
                RaisePropertyChanged("ThumbJpegQuality");
            }
        }
        private int? _jpegQuality;


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



        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (!string.IsNullOrEmpty(propertyName) && PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
