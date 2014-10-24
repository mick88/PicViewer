using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Threading;

namespace PicViewer
{
    public class ImageFile
    {
        //todo: load image in separate thread
        volatile Image vImage;
        string filename;
        string folder;
        string fullPath;
        bool readOnly=false;

        public enum ImageState
        {
            empty,
            loaded,
            loading,
            error
        }

        public volatile ImageState imageState = ImageState.empty;

        public ImageFile(string filepath, bool cacheImage=true)
        {
            filename = Path.GetFileName(filepath);
            folder = Path.GetDirectoryName(filepath);
            fullPath = filepath;
            if (cacheImage) loadImage(true);
        }

        public Image image
        {
            get
            {
                if (imageState == ImageState.empty)
                {
                    loadImage(false);
                }

                while (imageState == ImageState.loading);

                if (vImage == null)
                {
                    //MainForm.mainInstance.setToastText("Image is null!");
                    loadImage(false);
                }

                return vImage;
            }
            set
            {
                vImage = value;
            }
        }

        public void disposeImage()
        {
            imageState = ImageState.empty;
            if (vImage != null)
            {                
                vImage.Dispose();
                vImage = null;                
            }
        }

        public bool ReadOnly
        {
            get
            {
                return readOnly;
            }
        }

        public ImageFormat Format
        {
            get
            {
                if (string.IsNullOrEmpty(filename)) return null;
                switch (Path.GetExtension(filename.ToLower()))
                {
                    case ".jpg":
                    case ".jpeg":
                        return ImageFormat.Jpeg;
                    case ".gif":
                        return ImageFormat.Gif;
                    case ".png":
                        return ImageFormat.Png;
                    case ".tiff":
                        return ImageFormat.Tiff;
                    case ".ico":
                        return ImageFormat.Icon;
                    case ".bmp":
                        return ImageFormat.Bmp;
                    default:
                        return null;
                }
            }
        }

        void loadImageFromFile()
        {
            try
            {
                FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
                vImage = Image.FromStream(fs, true);
                fs.Close();
                imageState = ImageState.loaded;
            }
            catch
            {
                vImage = new Bitmap(640, 480);
                readOnly = true;
                imageState = ImageState.error;
            }
        }

        public void loadImage(bool threaded)
        {
            imageState = ImageState.loading;

            if (threaded == true)
            {
                Thread loadThread = new Thread(new ThreadStart(loadImageFromFile));
                loadThread.Start();
                /*if (vImage == null) imageState = ImageState.empty;
                else imageState = ImageState.loaded;*/
            }
            else loadImageFromFile();            
        }

        public enum RotationAngle
        {   
            Clockwise=90,
            UpsideDown=180,
            Counterclockwise = -90,
        }

        public void Rotate(RotationAngle angle)
        {
            if (image == null) return;

            switch(angle)
            {
                case RotationAngle.Clockwise:
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case RotationAngle.Counterclockwise:
                    image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
                case RotationAngle.UpsideDown:
                    image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                default:
                    return;
            }
            if (MessageBox.Show("Do you want to save change to the original file?", "Save changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                saveChanges();
            }
        }

        ~ImageFile()
        {
            disposeImage();
        }

        void saveChanges()
        {
            if (readOnly)
            {
                MainForm.mainInstance.ToastText = "File is read-only";
                return;
            }

            ImageFormat f = Format;
            if (f == null)
            {
                MainForm.mainInstance.ToastText = "Cannot save file: unknown format";
                return;
            }

            MemoryStream ms = new MemoryStream();
            
            FileStream fs = new FileStream(fullPath, FileMode.Create, FileAccess.ReadWrite);
           
            image.Save(ms, f);

            byte[] data = ms.ToArray();

            fs.Write(data, 0, data.Length);

            ms.Close();
            fs.Close();
        }

        public string FileName
        {
            get
            {
                return filename;
            }
        }

        public string FolderPath
        {
            get
            {
                return folder;
            }
        }

        public string FullPath
        {
            get
            {
                return fullPath;
            }
        }
    }
}
