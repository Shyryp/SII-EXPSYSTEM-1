namespace SII_EXPSYSTEM_1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.openFile = new System.Windows.Forms.ToolStripMenuItem();
            this.playThisKB = new System.Windows.Forms.ToolStripMenuItem();
            this.closeThisFile = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox = new System.Windows.Forms.TextBox();
            this.inputQuestionsList = new System.Windows.Forms.ListBox();
            this.resultList = new System.Windows.Forms.ListBox();
            this.listAnswers = new System.Windows.Forms.ListBox();
            this.textBoxQuestion = new System.Windows.Forms.TextBox();
            this.enterButton = new System.Windows.Forms.Button();
            this.answerTextBox = new System.Windows.Forms.TextBox();
            this.stopThisKB = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFile,
            this.playThisKB,
            this.stopThisKB,
            this.closeThisFile});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(710, 33);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // openFile
            // 
            this.openFile.BackColor = System.Drawing.SystemColors.Menu;
            this.openFile.Image = ((System.Drawing.Image)(resources.GetObject("openFile.Image")));
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(167, 29);
            this.openFile.Text = "Загрузить базу знаний";
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // playThisKB
            // 
            this.playThisKB.AutoToolTip = true;
            this.playThisKB.BackColor = System.Drawing.SystemColors.Menu;
            this.playThisKB.Enabled = false;
            this.playThisKB.Image = ((System.Drawing.Image)(resources.GetObject("playThisKB.Image")));
            this.playThisKB.Name = "playThisKB";
            this.playThisKB.ShowShortcutKeys = false;
            this.playThisKB.Size = new System.Drawing.Size(120, 29);
            this.playThisKB.Text = "Начать опрос";
            this.playThisKB.ToolTipText = "Начать опрос";
            this.playThisKB.Click += new System.EventHandler(this.playThisKB_Click);
            // 
            // closeThisFile
            // 
            this.closeThisFile.Enabled = false;
            this.closeThisFile.Image = ((System.Drawing.Image)(resources.GetObject("closeThisFile.Image")));
            this.closeThisFile.Name = "closeThisFile";
            this.closeThisFile.Size = new System.Drawing.Size(159, 29);
            this.closeThisFile.Text = "Закрыть базу знаний";
            this.closeThisFile.Click += new System.EventHandler(this.closeThisFile_Click);
            // 
            // textBox
            // 
            this.textBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox.Location = new System.Drawing.Point(0, 33);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.Size = new System.Drawing.Size(710, 62);
            this.textBox.TabIndex = 1;
            // 
            // inputQuestionsList
            // 
            this.inputQuestionsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.inputQuestionsList.FormattingEnabled = true;
            this.inputQuestionsList.HorizontalScrollbar = true;
            this.inputQuestionsList.Location = new System.Drawing.Point(4, 100);
            this.inputQuestionsList.Name = "inputQuestionsList";
            this.inputQuestionsList.Size = new System.Drawing.Size(234, 290);
            this.inputQuestionsList.TabIndex = 2;
            // 
            // resultList
            // 
            this.resultList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultList.FormattingEnabled = true;
            this.resultList.HorizontalScrollbar = true;
            this.resultList.Location = new System.Drawing.Point(536, 100);
            this.resultList.Name = "resultList";
            this.resultList.Size = new System.Drawing.Size(170, 277);
            this.resultList.TabIndex = 4;
            // 
            // listAnswers
            // 
            this.listAnswers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listAnswers.FormattingEnabled = true;
            this.listAnswers.HorizontalScrollbar = true;
            this.listAnswers.Location = new System.Drawing.Point(244, 100);
            this.listAnswers.Name = "listAnswers";
            this.listAnswers.Size = new System.Drawing.Size(286, 160);
            this.listAnswers.TabIndex = 5;
            // 
            // textBoxQuestion
            // 
            this.textBoxQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxQuestion.Location = new System.Drawing.Point(244, 266);
            this.textBoxQuestion.Multiline = true;
            this.textBoxQuestion.Name = "textBoxQuestion";
            this.textBoxQuestion.ReadOnly = true;
            this.textBoxQuestion.Size = new System.Drawing.Size(286, 72);
            this.textBoxQuestion.TabIndex = 6;
            // 
            // enterButton
            // 
            this.enterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.enterButton.Enabled = false;
            this.enterButton.Location = new System.Drawing.Point(434, 345);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(96, 41);
            this.enterButton.TabIndex = 9;
            this.enterButton.Text = "Ввод";
            this.enterButton.UseVisualStyleBackColor = true;
            this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
            // 
            // answerTextBox
            // 
            this.answerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.answerTextBox.Enabled = false;
            this.answerTextBox.Location = new System.Drawing.Point(255, 356);
            this.answerTextBox.Name = "answerTextBox";
            this.answerTextBox.Size = new System.Drawing.Size(64, 20);
            this.answerTextBox.TabIndex = 10;
            this.answerTextBox.Text = "0.5";
            // 
            // stopThisKB
            // 
            this.stopThisKB.Enabled = false;
            this.stopThisKB.Image = ((System.Drawing.Image)(resources.GetObject("stopThisKB.Image")));
            this.stopThisKB.Name = "stopThisKB";
            this.stopThisKB.Size = new System.Drawing.Size(148, 29);
            this.stopThisKB.Text = " Остановить опрос";
            this.stopThisKB.Click += new System.EventHandler(this.stopThisKB_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 391);
            this.Controls.Add(this.answerTextBox);
            this.Controls.Add(this.enterButton);
            this.Controls.Add(this.textBoxQuestion);
            this.Controls.Add(this.listAnswers);
            this.Controls.Add(this.resultList);
            this.Controls.Add(this.inputQuestionsList);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(650, 300);
            this.Name = "Form1";
            this.Text = "Экспертная система";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem playThisKB;
        private System.Windows.Forms.ToolStripMenuItem openFile;
        private System.Windows.Forms.ToolStripMenuItem closeThisFile;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.ListBox inputQuestionsList;
        private System.Windows.Forms.ListBox resultList;
        private System.Windows.Forms.ListBox listAnswers;
        private System.Windows.Forms.TextBox textBoxQuestion;
        private System.Windows.Forms.Button enterButton;
        private System.Windows.Forms.TextBox answerTextBox;
        private System.Windows.Forms.ToolStripMenuItem stopThisKB;
    }
}

