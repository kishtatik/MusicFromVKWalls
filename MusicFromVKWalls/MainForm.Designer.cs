namespace MusicFromVKWalls
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
            this.urlBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.getAudioListButton = new System.Windows.Forms.Button();
            this.audioListBox = new System.Windows.Forms.CheckedListBox();
            this.listMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectNoAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadButton = new System.Windows.Forms.Button();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.persentStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.songProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.songPersentStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proxyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.listMenuStrip.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // urlBox
            // 
            this.urlBox.Location = new System.Drawing.Point(46, 31);
            this.urlBox.Margin = new System.Windows.Forms.Padding(2);
            this.urlBox.Name = "urlBox";
            this.urlBox.Size = new System.Drawing.Size(230, 20);
            this.urlBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Url:";
            // 
            // getAudioListButton
            // 
            this.getAudioListButton.Location = new System.Drawing.Point(279, 31);
            this.getAudioListButton.Margin = new System.Windows.Forms.Padding(2);
            this.getAudioListButton.Name = "getAudioListButton";
            this.getAudioListButton.Size = new System.Drawing.Size(68, 21);
            this.getAudioListButton.TabIndex = 2;
            this.getAudioListButton.Text = "Получить";
            this.getAudioListButton.UseVisualStyleBackColor = true;
            this.getAudioListButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // audioListBox
            // 
            this.audioListBox.ContextMenuStrip = this.listMenuStrip;
            this.audioListBox.FormattingEnabled = true;
            this.audioListBox.Location = new System.Drawing.Point(9, 55);
            this.audioListBox.Margin = new System.Windows.Forms.Padding(2);
            this.audioListBox.Name = "audioListBox";
            this.audioListBox.ScrollAlwaysVisible = true;
            this.audioListBox.Size = new System.Drawing.Size(339, 184);
            this.audioListBox.TabIndex = 3;
            // 
            // listMenuStrip
            // 
            this.listMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllStripMenuItem,
            this.selectNoAllToolStripMenuItem,
            this.clearListToolStripMenuItem});
            this.listMenuStrip.Name = "listMenuStrip";
            this.listMenuStrip.Size = new System.Drawing.Size(174, 70);
            // 
            // selectAllStripMenuItem
            // 
            this.selectAllStripMenuItem.Name = "selectAllStripMenuItem";
            this.selectAllStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.selectAllStripMenuItem.Text = "Выбрать все";
            this.selectAllStripMenuItem.Click += new System.EventHandler(this.selectAllStripMenuItem_Click);
            // 
            // selectNoAllToolStripMenuItem
            // 
            this.selectNoAllToolStripMenuItem.Name = "selectNoAllToolStripMenuItem";
            this.selectNoAllToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.selectNoAllToolStripMenuItem.Text = "Снять выбор";
            this.selectNoAllToolStripMenuItem.Click += new System.EventHandler(this.selectNoAllToolStripMenuItem_Click);
            // 
            // clearListToolStripMenuItem
            // 
            this.clearListToolStripMenuItem.Name = "clearListToolStripMenuItem";
            this.clearListToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.clearListToolStripMenuItem.Text = "Очитстить список";
            this.clearListToolStripMenuItem.Click += new System.EventHandler(this.clearListToolStripMenuItem_Click);
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(9, 245);
            this.downloadButton.Margin = new System.Windows.Forms.Padding(2);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(74, 21);
            this.downloadButton.TabIndex = 4;
            this.downloadButton.Text = "Загрузить";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusProgress,
            this.persentStatus,
            this.songProgress,
            this.songPersentStatus});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 268);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.mainStatusStrip.Size = new System.Drawing.Size(356, 22);
            this.mainStatusStrip.TabIndex = 5;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // StatusProgress
            // 
            this.StatusProgress.Name = "StatusProgress";
            this.StatusProgress.Size = new System.Drawing.Size(75, 16);
            // 
            // persentStatus
            // 
            this.persentStatus.Name = "persentStatus";
            this.persentStatus.Size = new System.Drawing.Size(17, 17);
            this.persentStatus.Text = "%";
            // 
            // songProgress
            // 
            this.songProgress.Name = "songProgress";
            this.songProgress.Size = new System.Drawing.Size(75, 16);
            // 
            // songPersentStatus
            // 
            this.songPersentStatus.Name = "songPersentStatus";
            this.songPersentStatus.Size = new System.Drawing.Size(17, 17);
            this.songPersentStatus.Text = "%";
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.MainMenu.Size = new System.Drawing.Size(356, 24);
            this.MainMenu.TabIndex = 6;
            this.MainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proxyToolStripMenuItem,
            this.pathToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.settingsToolStripMenuItem.Text = "Настройки";
            // 
            // proxyToolStripMenuItem
            // 
            this.proxyToolStripMenuItem.Name = "proxyToolStripMenuItem";
            this.proxyToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.proxyToolStripMenuItem.Text = "Proxy...";
            this.proxyToolStripMenuItem.Click += new System.EventHandler(this.proxyToolStripMenuItem_Click);
            // 
            // pathToolStripMenuItem
            // 
            this.pathToolStripMenuItem.Name = "pathToolStripMenuItem";
            this.pathToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.pathToolStripMenuItem.Text = "Путь сохранения...";
            this.pathToolStripMenuItem.Click += new System.EventHandler(this.pathToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.helpToolStripMenuItem.Text = "Помощь";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.aboutToolStripMenuItem.Text = "О программе...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // myBackgroundWorker
            // 
            this.myBackgroundWorker.WorkerReportsProgress = true;
            this.myBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.myBackgroundWorker_DoWork);
            this.myBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.myBackgroundWorker_ProgressChanged);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(88, 249);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(63, 13);
            this.StatusLabel.TabIndex = 7;
            this.StatusLabel.Text = "StatusLabel";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 290);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.audioListBox);
            this.Controls.Add(this.getAudioListButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.urlBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MusicFromVKWalls";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.listMenuStrip.ResumeLayout(false);
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox urlBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button getAudioListButton;
        private System.Windows.Forms.CheckedListBox audioListBox;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripProgressBar StatusProgress;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proxyToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker myBackgroundWorker;
        private System.Windows.Forms.ToolStripMenuItem pathToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip listMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem selectAllStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectNoAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar songProgress;
        private System.Windows.Forms.ToolStripStatusLabel persentStatus;
        private System.Windows.Forms.ToolStripStatusLabel songPersentStatus;
        private System.Windows.Forms.Label StatusLabel;

    }
}

