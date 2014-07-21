namespace DichMusicHelper
{
    partial class PathSettingForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.createFolderBox = new System.Windows.Forms.CheckBox();
            this.brouseButton = new System.Windows.Forms.Button();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.createFolderBox);
            this.groupBox1.Controls.Add(this.brouseButton);
            this.groupBox1.Controls.Add(this.pathTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Путь сохранения";
            // 
            // createFolderBox
            // 
            this.createFolderBox.AutoSize = true;
            this.createFolderBox.Location = new System.Drawing.Point(6, 73);
            this.createFolderBox.Name = "createFolderBox";
            this.createFolderBox.Size = new System.Drawing.Size(259, 21);
            this.createFolderBox.TabIndex = 1;
            this.createFolderBox.Text = "Создавать папку для исполнителя";
            this.createFolderBox.UseVisualStyleBackColor = true;
            // 
            // brouseButton
            // 
            this.brouseButton.Location = new System.Drawing.Point(277, 33);
            this.brouseButton.Name = "brouseButton";
            this.brouseButton.Size = new System.Drawing.Size(45, 23);
            this.brouseButton.TabIndex = 2;
            this.brouseButton.Text = "...";
            this.brouseButton.UseVisualStyleBackColor = true;
            this.brouseButton.Click += new System.EventHandler(this.brouseButton_Click);
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(6, 34);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(265, 22);
            this.pathTextBox.TabIndex = 1;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(169, 122);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(89, 30);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Ок";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(264, 122);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(84, 30);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Отмена";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // PathSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 164);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PathSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройка сохранения композиций";
            this.Load += new System.EventHandler(this.PathSettingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox createFolderBox;
        private System.Windows.Forms.Button brouseButton;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button closeButton;

    }
}