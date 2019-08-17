using System;
using System.IO;
using System.Security;
using System.Windows.Media.Imaging;

namespace ImageDemoWPF.Models
{
    public class ImageFileInfo
    {
        [SecuritySafeCritical]
        public ImageFileInfo(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));

            fileInfo = new FileInfo(fileName);
        }
        private FileInfo fileInfo;


       
        public BitmapImage BitmapImage
        {
            get
            {
                if (bitmapImage == null)
                {
                    bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = fileInfo.OpenRead();
                    bitmapImage.EndInit();
                }
                return bitmapImage;
            }
        }
        private BitmapImage bitmapImage;

        /// <summary>Gets a string representing the directory's full path.</summary>
        /// <returns>A string representing the directory's full path.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// <see langword="null" /> was passed in for the directory name. </exception>
        /// <exception cref="T:System.IO.PathTooLongException">The fully qualified path is 260 or more characters.</exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        public string DirectoryName { get { return fileInfo.DirectoryName; } }

        /// <summary>Gets a value indicating whether a file exists.</summary>
        /// <returns>
        /// <see langword="true" /> if the file exists; <see langword="false" /> if the file does not exist or if the file is a directory.</returns>
        public bool Exists { get { return fileInfo.Exists; } }

        public string Extension { get { return fileInfo.Extension; } }

        /// <summary>Gets the full path of the directory or file.</summary>
        /// <returns>A string containing the full path.</returns>
        /// <exception cref="T:System.IO.PathTooLongException">The fully qualified path and file name is 260 or more characters.</exception>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        public virtual string FullName { get { return fileInfo.FullName; } }

        /// <summary>
        /// The image height
        /// </summary>
        public int Height { get { return BitmapImage.PixelHeight; } }

        /// <summary>
        /// The image width.
        /// </summary>
        public int Width { get { return BitmapImage.PixelWidth; } }

        /// <summary>Gets the size, in bytes, of the current file.</summary>
        /// <returns>The size of the current file in bytes.</returns>
        /// <exception cref="T:System.IO.IOException">
        /// <see cref="M:System.IO.FileSystemInfo.Refresh" /> cannot update the state of the file or directory. </exception>
        /// <exception cref="T:System.IO.FileNotFoundException">The file does not exist.-or- The <see langword="Length" /> property is called for a directory. </exception>
        public long Length { get { return fileInfo.Length; } }

        /// <summary>Gets the name of the image file.</summary>
        /// <returns>The name of the file.</returns>
        public string Name { get { return fileInfo.Name; } }

        /// <summary>Gets width and height of the current image a in proper string.</summary>
        /// <returns>Width and height of the current image.</returns>
        public string Size { get { return string.Format("{0}x{1} pixels", Width, Height); } }
    }
}
