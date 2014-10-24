namespace PicViewer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nextPictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previousPictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.explorerContextMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.rotateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clockwise90DegreesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.counterclockwise90DegreesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.degreesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.slideshowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stayOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.helpInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopSlideshowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.interval2secToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.secToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.slideshowTimer = new System.Windows.Forms.Timer(this.components);
            this.toastText = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.fullscreenBtn = new System.Windows.Forms.Button();
            this.slideshowBtn = new System.Windows.Forms.Button();
            this.rotate90btn = new System.Windows.Forms.Button();
            this.rotate180btn = new System.Windows.Forms.Button();
            this.rotate270btn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.prevBtn = new System.Windows.Forms.Button();
            this.toastHideTimer = new System.Windows.Forms.Timer(this.components);
            this.controlPanel = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip.SuspendLayout();
            this.controlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nextPictureToolStripMenuItem,
            this.previousPictureToolStripMenuItem,
            this.toolStripSeparator1,
            this.openFolderToolStripMenuItem,
            this.openInExplorerToolStripMenuItem,
            this.explorerContextMenuToolStripMenuItem,
            this.toolStripSeparator5,
            this.rotateToolStripMenuItem,
            this.deleteFileToolStripMenuItem,
            this.toolStripSeparator3,
            this.slideshowToolStripMenuItem,
            this.fullScreenToolStripMenuItem,
            this.stayOnTopToolStripMenuItem,
            this.toolStripSeparator2,
            this.helpInfoToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip.Name = "contextMenuStrip1";
            this.menuStrip.Size = new System.Drawing.Size(193, 314);
            this.menuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // nextPictureToolStripMenuItem
            // 
            this.nextPictureToolStripMenuItem.Image = global::PicViewer.Properties.Resources.right;
            this.nextPictureToolStripMenuItem.Name = "nextPictureToolStripMenuItem";
            this.nextPictureToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.nextPictureToolStripMenuItem.Text = "Next picture";
            this.nextPictureToolStripMenuItem.Click += new System.EventHandler(this.nextPictureToolStripMenuItem_Click);
            // 
            // previousPictureToolStripMenuItem
            // 
            this.previousPictureToolStripMenuItem.Image = global::PicViewer.Properties.Resources.left;
            this.previousPictureToolStripMenuItem.Name = "previousPictureToolStripMenuItem";
            this.previousPictureToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.previousPictureToolStripMenuItem.Text = "Previous picture";
            this.previousPictureToolStripMenuItem.Click += new System.EventHandler(this.previousPictureToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(189, 6);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Image = global::PicViewer.Properties.Resources._1348733289_folder_16;
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.openFolderToolStripMenuItem.Text = "Open folder...";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
            // 
            // openInExplorerToolStripMenuItem
            // 
            this.openInExplorerToolStripMenuItem.Image = global::PicViewer.Properties.Resources.folder_image;
            this.openInExplorerToolStripMenuItem.Name = "openInExplorerToolStripMenuItem";
            this.openInExplorerToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.openInExplorerToolStripMenuItem.Text = "Open in Explorer";
            this.openInExplorerToolStripMenuItem.Click += new System.EventHandler(this.openInExplorerToolStripMenuItem_Click);
            // 
            // explorerContextMenuToolStripMenuItem
            // 
            this.explorerContextMenuToolStripMenuItem.Enabled = false;
            this.explorerContextMenuToolStripMenuItem.Image = global::PicViewer.Properties.Resources.menu_blue;
            this.explorerContextMenuToolStripMenuItem.Name = "explorerContextMenuToolStripMenuItem";
            this.explorerContextMenuToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.explorerContextMenuToolStripMenuItem.Text = "Explorer context menu";
            this.explorerContextMenuToolStripMenuItem.Click += new System.EventHandler(this.explorerContextMenuToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(189, 6);
            // 
            // rotateToolStripMenuItem
            // 
            this.rotateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clockwise90DegreesToolStripMenuItem,
            this.counterclockwise90DegreesToolStripMenuItem,
            this.degreesToolStripMenuItem});
            this.rotateToolStripMenuItem.Name = "rotateToolStripMenuItem";
            this.rotateToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.rotateToolStripMenuItem.Text = "Rotate";
            // 
            // clockwise90DegreesToolStripMenuItem
            // 
            this.clockwise90DegreesToolStripMenuItem.Image = global::PicViewer.Properties.Resources.rotate90;
            this.clockwise90DegreesToolStripMenuItem.Name = "clockwise90DegreesToolStripMenuItem";
            this.clockwise90DegreesToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.clockwise90DegreesToolStripMenuItem.Text = "Right 90 degrees";
            this.clockwise90DegreesToolStripMenuItem.Click += new System.EventHandler(this.clockwise90DegreesToolStripMenuItem_Click);
            // 
            // counterclockwise90DegreesToolStripMenuItem
            // 
            this.counterclockwise90DegreesToolStripMenuItem.Image = global::PicViewer.Properties.Resources.rotate270;
            this.counterclockwise90DegreesToolStripMenuItem.Name = "counterclockwise90DegreesToolStripMenuItem";
            this.counterclockwise90DegreesToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.counterclockwise90DegreesToolStripMenuItem.Text = "Left 90 degrees";
            this.counterclockwise90DegreesToolStripMenuItem.Click += new System.EventHandler(this.counterclockwise90DegreesToolStripMenuItem_Click);
            // 
            // degreesToolStripMenuItem
            // 
            this.degreesToolStripMenuItem.Image = global::PicViewer.Properties.Resources.rotate180;
            this.degreesToolStripMenuItem.Name = "degreesToolStripMenuItem";
            this.degreesToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.degreesToolStripMenuItem.Text = "180 degrees";
            this.degreesToolStripMenuItem.Click += new System.EventHandler(this.degreesToolStripMenuItem_Click);
            // 
            // deleteFileToolStripMenuItem
            // 
            this.deleteFileToolStripMenuItem.Name = "deleteFileToolStripMenuItem";
            this.deleteFileToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.deleteFileToolStripMenuItem.Text = "Delete file";
            this.deleteFileToolStripMenuItem.Visible = false;
            this.deleteFileToolStripMenuItem.Click += new System.EventHandler(this.deleteFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(189, 6);
            // 
            // slideshowToolStripMenuItem
            // 
            this.slideshowToolStripMenuItem.Image = global::PicViewer.Properties.Resources.Slideshow_icon;
            this.slideshowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stopSlideshowToolStripMenuItem,
            this.toolStripSeparator4,
            this.interval2secToolStripMenuItem,
            this.secToolStripMenuItem,
            this.secToolStripMenuItem1,
            this.secToolStripMenuItem2});
            this.slideshowToolStripMenuItem.Name = "slideshowToolStripMenuItem";
            this.slideshowToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.slideshowToolStripMenuItem.Text = "Slideshow";
            this.slideshowToolStripMenuItem.Click += new System.EventHandler(this.slideshowToolStripMenuItem_Click);
            // 
            // fullScreenToolStripMenuItem
            // 
            this.fullScreenToolStripMenuItem.Image = global::PicViewer.Properties.Resources.full_screen_16;
            this.fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
            this.fullScreenToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.fullScreenToolStripMenuItem.Text = "Full screen";
            this.fullScreenToolStripMenuItem.Click += new System.EventHandler(this.fullScreenToolStripMenuItem_Click);
            // 
            // stayOnTopToolStripMenuItem
            // 
            this.stayOnTopToolStripMenuItem.Image = global::PicViewer.Properties.Resources.top_window;
            this.stayOnTopToolStripMenuItem.Name = "stayOnTopToolStripMenuItem";
            this.stayOnTopToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.stayOnTopToolStripMenuItem.Text = "Stay on top";
            this.stayOnTopToolStripMenuItem.Click += new System.EventHandler(this.stayOnTopToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(189, 6);
            // 
            // helpInfoToolStripMenuItem
            // 
            this.helpInfoToolStripMenuItem.Name = "helpInfoToolStripMenuItem";
            this.helpInfoToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.helpInfoToolStripMenuItem.Text = "Help / info";
            this.helpInfoToolStripMenuItem.Click += new System.EventHandler(this.helpInfoToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // stopSlideshowToolStripMenuItem
            // 
            this.stopSlideshowToolStripMenuItem.Name = "stopSlideshowToolStripMenuItem";
            this.stopSlideshowToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.stopSlideshowToolStripMenuItem.Text = "Disabled";
            this.stopSlideshowToolStripMenuItem.Click += new System.EventHandler(this.stopSlideshowToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
            // 
            // interval2secToolStripMenuItem
            // 
            this.interval2secToolStripMenuItem.Name = "interval2secToolStripMenuItem";
            this.interval2secToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.interval2secToolStripMenuItem.Text = "2 sec";
            this.interval2secToolStripMenuItem.Click += new System.EventHandler(this.interval2secToolStripMenuItem_Click);
            // 
            // secToolStripMenuItem
            // 
            this.secToolStripMenuItem.Checked = true;
            this.secToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.secToolStripMenuItem.Name = "secToolStripMenuItem";
            this.secToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.secToolStripMenuItem.Text = "3 sec";
            this.secToolStripMenuItem.Click += new System.EventHandler(this.secToolStripMenuItem_Click);
            // 
            // secToolStripMenuItem1
            // 
            this.secToolStripMenuItem1.Name = "secToolStripMenuItem1";
            this.secToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.secToolStripMenuItem1.Text = "4 sec";
            this.secToolStripMenuItem1.Click += new System.EventHandler(this.secToolStripMenuItem1_Click);
            // 
            // secToolStripMenuItem2
            // 
            this.secToolStripMenuItem2.Name = "secToolStripMenuItem2";
            this.secToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.secToolStripMenuItem2.Text = "5 sec";
            this.secToolStripMenuItem2.Click += new System.EventHandler(this.secToolStripMenuItem2_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Open photo folder";
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // slideshowTimer
            // 
            this.slideshowTimer.Interval = 3000;
            this.slideshowTimer.Tick += new System.EventHandler(this.slideshowTimer_Tick);
            // 
            // toastText
            // 
            this.toastText.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.toastText.AutoSize = true;
            this.toastText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.toastText.ForeColor = System.Drawing.Color.White;
            this.toastText.Location = new System.Drawing.Point(315, 491);
            this.toastText.Name = "toastText";
            this.toastText.Size = new System.Drawing.Size(108, 24);
            this.toastText.TabIndex = 1;
            this.toastText.Text = "Toast Text";
            this.toastText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toastText.Visible = false;
            this.toastText.Click += new System.EventHandler(this.toastText_Click);
            // 
            // fullscreenBtn
            // 
            this.fullscreenBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.fullscreenBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.fullscreenBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.fullscreenBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fullscreenBtn.ForeColor = System.Drawing.Color.White;
            this.fullscreenBtn.Image = global::PicViewer.Properties.Resources.full_screen_16;
            this.fullscreenBtn.Location = new System.Drawing.Point(41, 3);
            this.fullscreenBtn.Name = "fullscreenBtn";
            this.fullscreenBtn.Size = new System.Drawing.Size(23, 23);
            this.fullscreenBtn.TabIndex = 6;
            this.fullscreenBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.fullscreenBtn, "Full Screen");
            this.fullscreenBtn.UseVisualStyleBackColor = true;
            this.fullscreenBtn.Click += new System.EventHandler(this.button1_Click_1);
            this.fullscreenBtn.Enter += new System.EventHandler(this.nextBtn_Enter);
            // 
            // slideshowBtn
            // 
            this.slideshowBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.slideshowBtn.Enabled = false;
            this.slideshowBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.slideshowBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.slideshowBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.slideshowBtn.ForeColor = System.Drawing.Color.White;
            this.slideshowBtn.Image = ((System.Drawing.Image)(resources.GetObject("slideshowBtn.Image")));
            this.slideshowBtn.Location = new System.Drawing.Point(12, 3);
            this.slideshowBtn.Name = "slideshowBtn";
            this.slideshowBtn.Size = new System.Drawing.Size(23, 23);
            this.slideshowBtn.TabIndex = 5;
            this.slideshowBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.slideshowBtn, "Slideshow:\r\nHold shift to toggle Full Screen on.");
            this.slideshowBtn.UseVisualStyleBackColor = true;
            this.slideshowBtn.Click += new System.EventHandler(this.button1_Click);
            this.slideshowBtn.Enter += new System.EventHandler(this.nextBtn_Enter);
            // 
            // rotate90btn
            // 
            this.rotate90btn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rotate90btn.Enabled = false;
            this.rotate90btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.rotate90btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rotate90btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rotate90btn.ForeColor = System.Drawing.Color.White;
            this.rotate90btn.Image = global::PicViewer.Properties.Resources.rotate90;
            this.rotate90btn.Location = new System.Drawing.Point(699, 3);
            this.rotate90btn.Name = "rotate90btn";
            this.rotate90btn.Size = new System.Drawing.Size(23, 23);
            this.rotate90btn.TabIndex = 4;
            this.rotate90btn.TabStop = false;
            this.toolTip1.SetToolTip(this.rotate90btn, "Rotate image clockwise");
            this.rotate90btn.UseVisualStyleBackColor = true;
            this.rotate90btn.Click += new System.EventHandler(this.rotate90btn_Click);
            this.rotate90btn.Enter += new System.EventHandler(this.nextBtn_Enter);
            // 
            // rotate180btn
            // 
            this.rotate180btn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rotate180btn.Enabled = false;
            this.rotate180btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.rotate180btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rotate180btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rotate180btn.ForeColor = System.Drawing.Color.White;
            this.rotate180btn.Image = global::PicViewer.Properties.Resources.rotate180;
            this.rotate180btn.Location = new System.Drawing.Point(728, 3);
            this.rotate180btn.Name = "rotate180btn";
            this.rotate180btn.Size = new System.Drawing.Size(23, 23);
            this.rotate180btn.TabIndex = 3;
            this.rotate180btn.TabStop = false;
            this.toolTip1.SetToolTip(this.rotate180btn, "Rotate image 180 degrees");
            this.rotate180btn.UseVisualStyleBackColor = true;
            this.rotate180btn.Click += new System.EventHandler(this.rotate180btn_Click);
            this.rotate180btn.Enter += new System.EventHandler(this.nextBtn_Enter);
            // 
            // rotate270btn
            // 
            this.rotate270btn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rotate270btn.Enabled = false;
            this.rotate270btn.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.rotate270btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rotate270btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rotate270btn.ForeColor = System.Drawing.Color.White;
            this.rotate270btn.Image = global::PicViewer.Properties.Resources.rotate270;
            this.rotate270btn.Location = new System.Drawing.Point(757, 3);
            this.rotate270btn.Name = "rotate270btn";
            this.rotate270btn.Size = new System.Drawing.Size(23, 23);
            this.rotate270btn.TabIndex = 2;
            this.rotate270btn.TabStop = false;
            this.toolTip1.SetToolTip(this.rotate270btn, "Rotate image counter-clockwise");
            this.rotate270btn.UseVisualStyleBackColor = true;
            this.rotate270btn.Click += new System.EventHandler(this.rotate270btn_Click);
            this.rotate270btn.Enter += new System.EventHandler(this.nextBtn_Enter);
            // 
            // nextBtn
            // 
            this.nextBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nextBtn.Enabled = false;
            this.nextBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.nextBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.nextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextBtn.ForeColor = System.Drawing.Color.White;
            this.nextBtn.Image = global::PicViewer.Properties.Resources.right;
            this.nextBtn.Location = new System.Drawing.Point(382, 3);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(75, 23);
            this.nextBtn.TabIndex = 1;
            this.nextBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.nextBtn, "Hold shift to jump to the last image");
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            this.nextBtn.Enter += new System.EventHandler(this.nextBtn_Enter);
            // 
            // prevBtn
            // 
            this.prevBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.prevBtn.Enabled = false;
            this.prevBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.prevBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.prevBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prevBtn.ForeColor = System.Drawing.Color.White;
            this.prevBtn.Image = global::PicViewer.Properties.Resources.left;
            this.prevBtn.Location = new System.Drawing.Point(301, 3);
            this.prevBtn.Name = "prevBtn";
            this.prevBtn.Size = new System.Drawing.Size(75, 23);
            this.prevBtn.TabIndex = 0;
            this.prevBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.prevBtn, "Hold shift to jump to the first  image");
            this.prevBtn.UseVisualStyleBackColor = true;
            this.prevBtn.Click += new System.EventHandler(this.prevBtn_Click);
            this.prevBtn.Enter += new System.EventHandler(this.nextBtn_Enter);
            // 
            // toastHideTimer
            // 
            this.toastHideTimer.Interval = 2000;
            this.toastHideTimer.Tick += new System.EventHandler(this.toastHideTimer_Tick);
            // 
            // controlPanel
            // 
            this.controlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlPanel.BackColor = System.Drawing.Color.Black;
            this.controlPanel.Controls.Add(this.fullscreenBtn);
            this.controlPanel.Controls.Add(this.slideshowBtn);
            this.controlPanel.Controls.Add(this.rotate90btn);
            this.controlPanel.Controls.Add(this.rotate180btn);
            this.controlPanel.Controls.Add(this.rotate270btn);
            this.controlPanel.Controls.Add(this.nextBtn);
            this.controlPanel.Controls.Add(this.prevBtn);
            this.controlPanel.Location = new System.Drawing.Point(0, 533);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(792, 33);
            this.controlPanel.TabIndex = 2;
            this.controlPanel.Visible = false;
            this.controlPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.controlPanel_Paint_1);
            this.controlPanel.MouseEnter += new System.EventHandler(this.controlPanel_MouseEnter_1);
            this.controlPanel.MouseLeave += new System.EventHandler(this.controlPanel_MouseLeave);
            this.controlPanel.MouseHover += new System.EventHandler(this.controlPanel_MouseHover);
            // 
            // pictureBox
            // 
            this.pictureBox.ContextMenuStrip = this.menuStrip;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.InitialImage = null;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(792, 566);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            this.pictureBox.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.toastText);
            this.Controls.Add(this.pictureBox);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PicViewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.MainForm_Scroll);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.menuStrip.ResumeLayout(false);
            this.controlPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ContextMenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextPictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previousPictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem stayOnTopToolStripMenuItem;
        private System.Windows.Forms.Timer slideshowTimer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem slideshowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopSlideshowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem interval2secToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem secToolStripMenuItem2;
        private System.Windows.Forms.Label toastText;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer toastHideTimer;
        private System.Windows.Forms.ToolStripMenuItem rotateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clockwise90DegreesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem counterclockwise90DegreesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem degreesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem deleteFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openInExplorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem explorerContextMenuToolStripMenuItem;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Button prevBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Button rotate270btn;
        private System.Windows.Forms.Button rotate90btn;
        private System.Windows.Forms.Button rotate180btn;
        private System.Windows.Forms.Button slideshowBtn;
        private System.Windows.Forms.Button fullscreenBtn;
    }
}

