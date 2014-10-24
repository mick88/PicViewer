using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace PicViewer
{
    class ImageManager
    {
        /*
            to do:
         *  efficiently reload file list
         *  detect changes in folder
         *  optional: show images in subfolders
         */
        string currentDir = null;
        int currentImageID = 0;
        MainForm mainForm = null;
        public static List<ImageFile> imageFiles = new List<ImageFile>();

        const int cachePrev = 3;
        const int cacheNext = 3;

        public int CurrentImageID
        {
            get
            {
                return currentImageID;
            }
            set
            {
                currentImageID = value;
                manageCache();
            }
        }

        void manageCache()
        {
            for (int i = 0; i < imageFiles.Count; i++)
            {
                if (i == CurrentImageID)
                {
                    if (imageFiles[i].imageState == ImageFile.ImageState.empty) imageFiles[i].loadImage(false);
                }
                else if ((i < CurrentImageID && i >= CurrentImageID - cachePrev) || (i > CurrentImageID && i <= CurrentImageID + cacheNext))
                {
                    if (imageFiles[i].imageState == ImageFile.ImageState.empty) imageFiles[i].loadImage(true);
                }
                else
                {
                    if (imageFiles[i].imageState == ImageFile.ImageState.loaded) imageFiles[i].disposeImage();
                }
            }
        }

        public int TotalImagesInFolder
        {
            get
            {
                return imageFiles.Count;
            }
        }

        public ImageManager(MainForm  form)
        {
            mainForm = form;
        }

        public bool open(string path)
        {
            string fileName = null;

            if (File.Exists(path))
            {
                if (isFileSupported(path))
                {
                    fileName = Path.GetFileName(path);                    
                }
                path = Path.GetDirectoryName(path);
            }

            if (Directory.Exists(path))
            {
                CurrentDir = path;
                if (fileName == null) showFile(0);
                else showFile(fileName);
                return true;
            }
            return false;
        }

        void showFile(string name)
        {
            for (int i=0; i < imageFiles.Count; i++)
            {
                if (imageFiles[i].FileName == name)
                {
                    showFile(i);
                    break;
                }
            }
        }

        void showFile(int id)
        {
            if (id < imageFiles.Count)
            {
                CurrentImageID = id;
                mainForm.showImage(imageFiles[id]);                
            }            
        }

        public string CurrentDir
        {
            get
            {
                return currentDir;
            }
            set
            {
                if (currentDir == value)
                {
                    refreshFileList();
                }
                else
                {
                    currentDir = value;
                    reloadFileList();
                }
            }
        }

        void refreshFileList()
        {
            /*
             * reload list of files
             */
            reloadFileList();
        }

        void reloadFileList()
        {
            if (currentDir == null) return;
            
            string[] list = Directory.GetFiles(currentDir);
            List<ImageFile> tmpList = new List<ImageFile>(list.Length);

            foreach (string name in list) if (isFileSupported(name))
            {
                tmpList.Add(new ImageFile(Path.Combine(currentDir, name), false));
            }

            disposeImages();
            imageFiles = tmpList;

            CurrentImageID = Math.Min(imageFiles.Count, currentImageID);
        }

        public void disposeImages()
        {
            foreach (ImageFile im in imageFiles)
            {
                im.disposeImage();
            }
        }

        public ImageFile CurrentImageFile
        {
            get
            {
                if (imageFiles.Count <= CurrentImageID) return null;
                return imageFiles[CurrentImageID];
            }
        }

        public Image CurrentImage
        {
            get
            {
                if (CurrentImageFile == null) return null;
                else return CurrentImageFile.image;
            }
        }

        public bool IsFirstImage
        {
            get
            {
                return currentImageID == 0;
            }
        }

        public bool IsLastImage
        {
            get
            {
                return (currentImageID == imageFiles.Count - 1) || (imageFiles.Count == 0);
            }
        }

        public bool nextImage()
        {
            if (CurrentImageID+1 == imageFiles.Count) return false;
            CurrentImageID++;
            return true;
        }

        public bool prevImage()
        {
            if (CurrentImageID == 0) return false;
            CurrentImageID--;
            return true;
        }

        public bool firstImage()
        {
            if (imageFiles.Count == 0) return false;
            CurrentImageID = 0;
            return true;
        }

        public bool lastImage()
        {
            if (imageFiles.Count == 0) return false;
            CurrentImageID = imageFiles.Count-1;
            return true;
        }

        public void deleteCurrentFile()
        {
            if (MessageBox.Show(string.Format("Are you sure you want to delete {0} permanently?", CurrentImageFile.FileName), "Delete file?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string path = CurrentImageFile.FullPath;
                File.Delete(path);
                reloadFileList();
                
                mainForm.showImage(CurrentImageFile);
            }
        }

        public static String[] supportedFormats = new String[4] { ".jpg", ".jpeg", ".png", ".bmp" };

        public static bool isFileSupported(string filename)
        {
            string e = Path.GetExtension(filename.ToLower());
            foreach (String ext in supportedFormats) if (ext == e) return true;
            return false;
            /*
            switch (Path.GetExtension(filename.ToLower()))
            {
                case ".jpg":
                case ".jpeg":
                case ".png":
                case ".bmp":
                    return true;

                default:
                    return false;
            }*/
        }
    }
}
