namespace Ambilight
{
    partial class Ambilight
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ambilight));
            this.notifyIconAmbilight = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.minimizeToolStripMenuIconItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startStopToolStripMenuIconItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuIconItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorkerDataSender = new System.ComponentModel.BackgroundWorker();
            this.labelSenderSpeed = new System.Windows.Forms.Label();
            this.menuStripAmbilight = new System.Windows.Forms.MenuStrip();
            this.videoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ambientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startStopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorkerVideo = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerColor = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStripIcon.SuspendLayout();
            this.menuStripAmbilight.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIconAmbilight
            // 
            this.notifyIconAmbilight.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIconAmbilight.ContextMenuStrip = this.contextMenuStripIcon;
            this.notifyIconAmbilight.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconAmbilight.Icon")));
            this.notifyIconAmbilight.Text = "Ambilight";
            this.notifyIconAmbilight.Visible = true;
            this.notifyIconAmbilight.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconAmbilight_MouseDoubleClick);
            // 
            // contextMenuStripIcon
            // 
            this.contextMenuStripIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minimizeToolStripMenuIconItem,
            this.startStopToolStripMenuIconItem,
            this.exitToolStripMenuIconItem});
            this.contextMenuStripIcon.Name = "contextMenuStripIcon";
            this.contextMenuStripIcon.Size = new System.Drawing.Size(124, 70);
            // 
            // minimizeToolStripMenuIconItem
            // 
            this.minimizeToolStripMenuIconItem.Name = "minimizeToolStripMenuIconItem";
            this.minimizeToolStripMenuIconItem.Size = new System.Drawing.Size(123, 22);
            this.minimizeToolStripMenuIconItem.Text = "Minimize";
            this.minimizeToolStripMenuIconItem.Click += new System.EventHandler(this.minimizeToolStripMenuItem_Click);
            // 
            // startStopToolStripMenuIconItem
            // 
            this.startStopToolStripMenuIconItem.Name = "startStopToolStripMenuIconItem";
            this.startStopToolStripMenuIconItem.Size = new System.Drawing.Size(123, 22);
            this.startStopToolStripMenuIconItem.Text = "Stop";
            this.startStopToolStripMenuIconItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // exitToolStripMenuIconItem
            // 
            this.exitToolStripMenuIconItem.Name = "exitToolStripMenuIconItem";
            this.exitToolStripMenuIconItem.Size = new System.Drawing.Size(123, 22);
            this.exitToolStripMenuIconItem.Text = "Exit";
            this.exitToolStripMenuIconItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // backgroundWorkerDataSender
            // 
            this.backgroundWorkerDataSender.WorkerSupportsCancellation = true;
            this.backgroundWorkerDataSender.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDataSender_DoWork);
            // 
            // labelSenderSpeed
            // 
            this.labelSenderSpeed.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelSenderSpeed.BackColor = System.Drawing.Color.Linen;
            this.labelSenderSpeed.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSenderSpeed.Location = new System.Drawing.Point(236, 30);
            this.labelSenderSpeed.Name = "labelSenderSpeed";
            this.labelSenderSpeed.Size = new System.Drawing.Size(48, 28);
            this.labelSenderSpeed.TabIndex = 0;
            this.labelSenderSpeed.Text = "0";
            this.labelSenderSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuStripAmbilight
            // 
            this.menuStripAmbilight.BackColor = System.Drawing.Color.Linen;
            this.menuStripAmbilight.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStripAmbilight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.videoToolStripMenuItem,
            this.audioToolStripMenuItem,
            this.colorToolStripMenuItem,
            this.ambientToolStripMenuItem,
            this.startStopToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStripAmbilight.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStripAmbilight.Location = new System.Drawing.Point(0, 0);
            this.menuStripAmbilight.Name = "menuStripAmbilight";
            this.menuStripAmbilight.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStripAmbilight.Size = new System.Drawing.Size(284, 58);
            this.menuStripAmbilight.TabIndex = 1;
            this.menuStripAmbilight.Text = "menuStripAmbilight";
            // 
            // videoToolStripMenuItem
            // 
            this.videoToolStripMenuItem.AutoSize = false;
            this.videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            this.videoToolStripMenuItem.Size = new System.Drawing.Size(67, 27);
            this.videoToolStripMenuItem.Text = "Video";
            this.videoToolStripMenuItem.Click += new System.EventHandler(this.videoToolStripMenuItem_Click);
            // 
            // audioToolStripMenuItem
            // 
            this.audioToolStripMenuItem.AutoSize = false;
            this.audioToolStripMenuItem.Name = "audioToolStripMenuItem";
            this.audioToolStripMenuItem.Size = new System.Drawing.Size(67, 27);
            this.audioToolStripMenuItem.Text = "Audio";
            this.audioToolStripMenuItem.Click += new System.EventHandler(this.audioToolStripMenuItem_Click);
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.AutoSize = false;
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(67, 27);
            this.colorToolStripMenuItem.Text = "Color";
            this.colorToolStripMenuItem.Click += new System.EventHandler(this.colorToolStripMenuItem_Click);
            // 
            // ambientToolStripMenuItem
            // 
            this.ambientToolStripMenuItem.AutoSize = false;
            this.ambientToolStripMenuItem.Name = "ambientToolStripMenuItem";
            this.ambientToolStripMenuItem.Size = new System.Drawing.Size(67, 27);
            this.ambientToolStripMenuItem.Text = "Ambient";
            this.ambientToolStripMenuItem.Click += new System.EventHandler(this.ambientToolStripMenuItem_Click);
            // 
            // startStopToolStripMenuItem
            // 
            this.startStopToolStripMenuItem.AutoSize = false;
            this.startStopToolStripMenuItem.Name = "startStopToolStripMenuItem";
            this.startStopToolStripMenuItem.Size = new System.Drawing.Size(67, 27);
            this.startStopToolStripMenuItem.Text = "Stop";
            this.startStopToolStripMenuItem.Click += new System.EventHandler(this.startStopToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.AutoSize = false;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(67, 27);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // backgroundWorkerVideo
            // 
            this.backgroundWorkerVideo.WorkerSupportsCancellation = true;
            this.backgroundWorkerVideo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerVideo_DoWork);
            // 
            // backgroundWorkerColor
            // 
            this.backgroundWorkerColor.WorkerSupportsCancellation = true;
            this.backgroundWorkerColor.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerColor_DoWork);
            // 
            // Ambilight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 38F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aquamarine;
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.labelSenderSpeed);
            this.Controls.Add(this.menuStripAmbilight);
            this.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStripAmbilight;
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.MaximizeBox = false;
            this.Name = "Ambilight";
            this.Text = "Ambilight";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Ambilight_FormClosing);
            this.Load += new System.EventHandler(this.Ambilight_Load);
            this.contextMenuStripIcon.ResumeLayout(false);
            this.menuStripAmbilight.ResumeLayout(false);
            this.menuStripAmbilight.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIconAmbilight;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDataSender;
        private System.Windows.Forms.Label labelSenderSpeed;
        private System.Windows.Forms.MenuStrip menuStripAmbilight;
        private System.Windows.Forms.ToolStripMenuItem videoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem audioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ambientToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerVideo;
        private System.Windows.Forms.ToolStripMenuItem startStopToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerColor;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripIcon;
        private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuIconItem;
        private System.Windows.Forms.ToolStripMenuItem startStopToolStripMenuIconItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuIconItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

