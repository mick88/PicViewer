using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using Peter;
using BrendanGrant.Helpers.FileAssociation;
using System.Security.Permissions;
/*
 icon credits:
 * open folder: Pixel Mixer - http://www.pixel-mixer.com/
 */

namespace PicViewer
{
    public partial class MainForm : Form
    {
        bool fullscreen=false;
        FormWindowState savedWindowsState = FormWindowState.Normal;

        ImageFile currentImage = null;

        public static MainForm mainInstance;

        ImageManager imageManager = null;

        List<string> imageFiles = new List<string>();

        ShellContextMenu menu = new ShellContextMenu();

        void loadFileList()
        {
            List<string> tmpList = new List<string>();
            string[] list = Directory.GetFiles(CurrentFolder);

            foreach (string file in list)
            {
                if (ImageManager.isFileSupported(file.ToLower()))
                {
                    tmpList.Add(Path.GetFileName(file));
                }
            }

            imageFiles = tmpList;
        }

        public string CurrentFolder
        {
            get
            {
                return imageManager.CurrentDir;
            }
        }

        public MainForm(string [] args)
        {
            mainInstance = this;
            imageManager = new ImageManager(this);

            InitializeComponent();

            if (args.Length > 0)
            {
                string arg = String.Join(" ", args);
                if (imageManager.open(arg))
                {
                    FullScreen = true;
                }
            }

            associateFiles();

            /*foreach (string arg in args)
            {
                MessageBox.Show(arg);
                if (imageManager.open(arg)) break;
            }*/

            if (currentImage == null)
            {
                selectFolder();
            }
        }

        void programAssocInfo(FileAssociationInfo fai)
        {
            ProgramAssociationInfo pai = new ProgramAssociationInfo(fai.ProgID);
            bool assigned = false;

            foreach (ProgramVerb pv in pai.Verbs)
            {
                if (pv.Name == "View Image")
                {
                    assigned = true;
                    break;
                }
            }

            if (assigned == false)
            {
                pai.Create("Image file", new ProgramVerb("View Image", Application.ExecutablePath + " \"%1\""));
                
            }
        }

        void associateFiles(string extension)
        {
            FileAssociationInfo fai = new FileAssociationInfo(extension);

            if (fai.Exists == false)
            {
                fai.Create("Image file");
                fai.ContentType = "application/image";
            }

            /*
            string[] openWith = fai.OpenWithList;

            foreach(string program in openWith)
            {
                MessageBox.Show(program);
            }
            */
            programAssocInfo(fai);
        }

        //[PrincipalPermission(SecurityAction.Demand, Role = @"BUILTIN\Administrators")]
        public void associateFiles()
        {
#if !DEBUG
            try
            {
                foreach (string ex in ImageManager.supportedFormats)
                {
                    associateFiles(ex);
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
#endif
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SlideShowInterval = 3;
        }

        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            FullScreen = !FullScreen;
            controlPanel.Visible = !controlPanel.Visible;
        }

        public string Title
        {
            get { return this.Text; }
            set 
            {
                if (value == null ||string.IsNullOrEmpty(value)) this.Text = "PicViewer";
                else this.Text = string.Format("PicViewer - {0}", value); 
            }
        }

        delegate void d_showImage(ImageFile im);
        public void showImage(ImageFile im)
        {
            if (this.InvokeRequired == true)
            {
                d_showImage method = new d_showImage(showImage);
                Invoke(method, new Object[] { im });
            }
            else
            {
                currentImage = im;
                bool readOnly = true;
                if (im == null)
                {
                    pictureBox.Image = null;
                    Title = null;
                    rotateToolStripMenuItem.Enabled = false;
                    explorerContextMenuToolStripMenuItem.Enabled = false;
                }
                else
                {
                    Image image = im.image;
                    pictureBox.Image = image;
                    string format = "{0} - {1} x {2} ({3:0.} MP) {4} of {5}";
                    float resolution = (float)(image.Width * image.Height) / 1000000;
                    if (resolution < 1) format = "{0} - {1} x {2} ({3:0.#} MP) {4} of {5}";
                    Title = string.Format(format, im.FileName, im.image.Width, im.image.Height, resolution, imageManager.CurrentImageID+1, imageManager.TotalImagesInFolder);
                    readOnly = im.ReadOnly;
                    explorerContextMenuToolStripMenuItem.Enabled = true;
                }

                rotateToolStripMenuItem.Enabled = !readOnly;
                deleteFileToolStripMenuItem.Enabled = !readOnly;

                nextBtn.Enabled = !(im == null) && !imageManager.IsLastImage;
                prevBtn.Enabled = !(im == null) && !imageManager.IsFirstImage;

                rotate180btn.Enabled = !(im == null);
                rotate270btn.Enabled = !(im == null);
                rotate90btn.Enabled = !(im == null);

                slideshowBtn.Enabled = !(im == null);
            }
        }
        
        public bool FullScreen
        {
            get
            {
                return fullscreen;
            }
            set
            {
                if (value == true)
                {
                    savedWindowsState = this.WindowState;
                    if (savedWindowsState == FormWindowState.Maximized) this.WindowState = FormWindowState.Normal;
                    
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;

                    fullscreenBtn.Image.Dispose();
                    fullscreenBtn.Image = new Bitmap(PicViewer.Properties.Resources.full_screen_off);
                }
                else
                {
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                    this.WindowState = savedWindowsState;

                    fullscreenBtn.Image.Dispose();
                    fullscreenBtn.Image = new Bitmap(PicViewer.Properties.Resources.full_screen_16);
                }
                fullscreen = value;
                fullScreenToolStripMenuItem.Checked = value;
                updateMouseCursor();
                //fullScreenToolStripMenuItem.Image = fullscreenBtn.Image;
            }
        }

        public bool StayOnTop
        {
            get 
            {
                return this.TopMost;
            }
            set
            {
                this.TopMost = value;
                stayOnTopToolStripMenuItem.Checked = value;
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                case Keys.Right:
                    if (imageManager.nextImage())
                    {
                        resetShideshowTimer();
                        showImage(imageManager.CurrentImageFile);
                    }
                    break;

                case Keys.Back:
                case Keys.Left:
                    if (imageManager.prevImage())
                    {
                        resetShideshowTimer();
                        showImage(imageManager.CurrentImageFile);
                    }
                    break;

                case Keys.Home:
                    if (imageManager.firstImage())
                    {
                        SlideShow = false;
                        showImage(imageManager.CurrentImageFile);
                    }
                    break;

                case Keys.End:
                    if (imageManager.lastImage())
                    {
                        SlideShow = false;
                        showImage(imageManager.CurrentImageFile);
                    }
                    break;

                case Keys.Escape:
                    imageManager.disposeImages();
                    Close();
                    break;

                case Keys.F11:
                    FullScreen = !FullScreen;
                    break;

                case Keys.O:
                    if (isCtrlPressed()) selectFolder();
                    break;

                    //temporarily removed
                /*case Keys.Delete:
                    imageManager.deleteCurrentFile();
                    break;*/

                case Keys.Pause:
                    SlideShow = !SlideShow;
                    break;

                case Keys.Up:
                    if (SlideShow == true)
                    {
                        SlideShowInterval = SlideShowInterval + 1;
                        ToastText = string.Format("Slideshow interval set to: {0}", SlideShowInterval);
                    }
                    break;
                case Keys.Down:
                    if (SlideShow == true && SlideShowInterval > 1)
                    {
                        SlideShowInterval = SlideShowInterval - 1;
                        ToastText = string.Format("Slideshow interval set to: {0}", SlideShowInterval);
                    }
                    break;
                /*case Keys.O:
                    if (e.Control) 
                    {
                        selectFolder();
                    }
                    break;*/
            }
        }

        void updateMouseCursor()
        {
            //hide mouse pointer when fullscreen and menu is hidden
            /*
            if (FullScreen && controlPanel.Visible == false)
            {
                Cursor.Hide();
            }
            else
            {
                Cursor.Show();
            }*/
        }

        void showFileExplorerMenu(ImageFile file)
        {
            if (file == null) return;
            FileInfo[] f = new FileInfo[1];
            f[0] = new FileInfo(file.FullPath);

            menu.ShowContextMenu(f, System.Windows.Forms.Cursor.Position);
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                Array a = (Array)e.Data.GetData(DataFormats.FileDrop);
                string path = a.GetValue(0).ToString();

                if (imageManager.open(path)) this.Activate();
            }
            catch
            {
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        bool isShiftPressed()
        {
            return (Control.ModifierKeys & Keys.Shift) == Keys.Shift;
        }

        bool isCtrlPressed()
        {
            return (Control.ModifierKeys & Keys.Control) == Keys.Control;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

            if (isShiftPressed())
            {
                e.Cancel = true;
                showFileExplorerMenu(currentImage);
            }
            else
            {
                bool empty = string.IsNullOrEmpty(CurrentFolder);
                openInExplorerToolStripMenuItem.Enabled = !empty;
                nextPictureToolStripMenuItem.Enabled = !empty && !imageManager.IsLastImage;
                previousPictureToolStripMenuItem.Enabled = !empty && !imageManager.IsFirstImage;

            }
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FullScreen = !FullScreen;
        }

        void nextImage()
        {
            if (imageManager.nextImage())
            {
                resetShideshowTimer();
                showImage(imageManager.CurrentImageFile);
            }
        }

        private void nextPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nextImage();
        }

        void prevImage()
        {
            if (imageManager.prevImage())
            {
                resetShideshowTimer();
                showImage(imageManager.CurrentImageFile);
            }
        }

        private void previousPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prevImage();
        }

        bool selectFolder()
        {
            SlideShow = false;
            if (folderBrowserDialog1.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                string path = folderBrowserDialog1.SelectedPath;
                imageManager.open(path);
                return true;
            }
            else return false;
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectFolder();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void stayOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StayOnTop = !StayOnTop;
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
#if DEBUG
            
#endif
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                controlPanel.Visible = !controlPanel.Visible;
            }
            updateMouseCursor();
        }

        private void MainForm_Scroll(object sender, ScrollEventArgs e)
        {
            
            
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {

        }

        void resetShideshowTimer()
        {
            if (slideshowTimer.Enabled == true)
            {
                slideshowTimer.Enabled = false;
                slideshowTimer.Enabled = true;
            }
        }

        public bool SlideShow
        {
            get 
            {
                return slideshowTimer.Enabled;
            }
            set
            {
                if (value == true)
                {
                    ToastText = string.Format("Slideshow started: {0} sec", SlideShowInterval);
                }
                else
                {
                    if (slideshowTimer.Enabled == true) ToastText = "Slideshow stopped";
                }                

                slideshowTimer.Enabled = value;
                slideshowToolStripMenuItem.Checked = value;  

            }
        }

        public int SlideShowInterval
        {
            get
            {
                return slideshowTimer.Interval / 1000;
            }
            set
            {
                interval2secToolStripMenuItem.Checked = (value == 2 && SlideShow);
                secToolStripMenuItem.Checked = (value == 3 && SlideShow);
                secToolStripMenuItem1.Checked = (value == 4 && SlideShow);
                secToolStripMenuItem2.Checked = (value == 5 && SlideShow);
                stopSlideshowToolStripMenuItem.Checked = (SlideShow == false);
                slideshowTimer.Interval = value * 1000;
            }
        }

        private void slideshowTimer_Tick(object sender, EventArgs e)
        {
            if (menuStrip.Visible) return;
            if (imageManager.nextImage())
            {
                showImage(imageManager.CurrentImageFile);
            }
            else
            {
                SlideShow = false;
            }
        }

        private void slideshowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SlideShow = !SlideShow;
        }

        private void interval2secToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SlideShowInterval = 2;
            SlideShow = true;
        }

        private void secToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SlideShowInterval = 3;
            SlideShow = true;
        }

        private void secToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SlideShowInterval = 4;
            SlideShow = true;
        }

        private void secToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SlideShowInterval = 5;
            SlideShow = true;
        }

        private void stopSlideshowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SlideShow = false;
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void toastText_Click(object sender, EventArgs e)
        {

        }

        delegate void stopSlideShowDelegate();
        void stopSlideShow()
        {
            if (menuStrip.InvokeRequired)
            {
                stopSlideShowDelegate d = new stopSlideShowDelegate(stopSlideShow);
                Invoke(d);
            }
            else
            {
                SlideShow = false;
            }
        }

        delegate void d_setToastText(string text);
        public void setToastText(string text) //safe cross-thread way to set toast
        {
            if (toastText.InvokeRequired == true)
            {
                d_setToastText method = new d_setToastText(setToastText);
                Invoke(method, new Object[] { text });
            }
            else
            {
                ToastText = text;
            }
        }

        public string ToastText
        {
            get
            {
                return toastText.Text;
            }
            set
            {
                if (toastText.InvokeRequired == false)
                {
                    toastHideTimer.Enabled = false;
                    toastText.Text = value;
                    toastText.Left = (this.Width / 2 - toastText.Width / 2);
                    toastText.Visible = true;
                    toastHideTimer.Enabled = true;
                }
            }
        }

        private void toastHideTimer_Tick(object sender, EventArgs e)
        {
            toastHideTimer.Enabled = false;
            toastText.Visible = false;
        }

        private void clockwise90DegreesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentImage.Rotate(ImageFile.RotationAngle.Clockwise);
            showImage(currentImage);
        }

        private void counterclockwise90DegreesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentImage.Rotate(ImageFile.RotationAngle.Counterclockwise);
            showImage(currentImage);
        }

        private void degreesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentImage.Rotate(ImageFile.RotationAngle.UpsideDown);
            showImage(currentImage);
        }

        private void adjustWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageManager.deleteCurrentFile();
        }

        private void openInExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentImage != null) Process.Start("explorer.exe", "/select, " + currentImage.FullPath);
                else Process.Start("explorer.exe", CurrentFolder);
            }
            catch
            {
            }
        }

        private void controlPanel_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void controlPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void helpInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new HelpForm()).Show(this);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void explorerContextMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showFileExplorerMenu(currentImage);
            
        }

        private void mouseTrackTimer_Tick(object sender, EventArgs e)
        {
            

        }

        private void controlPanel_MouseEnter_1(object sender, EventArgs e)
        {
            //controlPanel.Visible = true;
        }

        private void controlPanel_MouseHover(object sender, EventArgs e)
        {
            //controlPanel.Visible = true;
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (isShiftPressed())
            {
                if (imageManager.lastImage())
                {
                    showImage(imageManager.CurrentImageFile);
                    resetShideshowTimer();
                    ToastText = "Jumped to last image";
                }
            }
            else
            {
                nextImage();
            }
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (isShiftPressed())
            {
                if (imageManager.firstImage())
                {
                    showImage(imageManager.CurrentImageFile);
                    resetShideshowTimer();                    
                    ToastText = "Jumped to first image";
                }
            }
            else
            {
                prevImage();
            }
        }

        private void nextBtn_Enter(object sender, EventArgs e)
        {
            pictureBox.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SlideShow = !SlideShow;
            if (SlideShow && isShiftPressed())
            {
                if(FullScreen == false) FullScreen = true;
                controlPanel.Visible = false;
            }
        }

        private void controlPanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void rotate90btn_Click(object sender, EventArgs e)
        {
            currentImage.Rotate(ImageFile.RotationAngle.Clockwise);
            showImage(currentImage);
        }

        private void rotate180btn_Click(object sender, EventArgs e)
        {
            currentImage.Rotate(ImageFile.RotationAngle.UpsideDown);
            showImage(currentImage);
        }

        private void rotate270btn_Click(object sender, EventArgs e)
        {
            currentImage.Rotate(ImageFile.RotationAngle.Counterclockwise);
            showImage(currentImage);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FullScreen = !FullScreen;
        }

        private void controlPanel_MouseLeave(object sender, EventArgs e)
        {
            
        }
    }
}
