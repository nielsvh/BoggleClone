namespace BoggleClone
{
    partial class GameStatus
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.ProgressBar();
            this.submitB = new System.Windows.Forms.Button();
            this.wordPad = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.currentWord = new System.Windows.Forms.TextBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.searchTime = new System.Windows.Forms.Label();
            this.wordPadTB = new System.Windows.Forms.RichTextBox();
            this.solveB = new System.Windows.Forms.Button();
            this.wordPad.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Location = new System.Drawing.Point(0, 170);
            this.timer.Name = "timer";
            this.timer.Size = new System.Drawing.Size(318, 23);
            this.timer.Step = 1;
            this.timer.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.timer.TabIndex = 5;
            this.timer.Value = 100;
            // 
            // submitB
            // 
            this.submitB.Location = new System.Drawing.Point(176, 19);
            this.submitB.Name = "submitB";
            this.submitB.Size = new System.Drawing.Size(129, 106);
            this.submitB.TabIndex = 4;
            this.submitB.Text = "Add to list";
            this.submitB.UseVisualStyleBackColor = true;
            // 
            // wordPad
            // 
            this.wordPad.Controls.Add(this.solveB);
            this.wordPad.Controls.Add(this.wordPadTB);
            this.wordPad.Controls.Add(this.searchTime);
            this.wordPad.Controls.Add(this.label1);
            this.wordPad.Controls.Add(this.currentWord);
            this.wordPad.Controls.Add(this.submitB);
            this.wordPad.Location = new System.Drawing.Point(3, 3);
            this.wordPad.Name = "wordPad";
            this.wordPad.Size = new System.Drawing.Size(315, 161);
            this.wordPad.TabIndex = 6;
            this.wordPad.TabStop = false;
            this.wordPad.Text = "Word Pad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Time to search:";
            // 
            // currentWord
            // 
            this.currentWord.Enabled = false;
            this.currentWord.Location = new System.Drawing.Point(6, 19);
            this.currentWord.Name = "currentWord";
            this.currentWord.Size = new System.Drawing.Size(164, 20);
            this.currentWord.TabIndex = 5;
            // 
            // gameTimer
            // 
            this.gameTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // searchTime
            // 
            this.searchTime.AutoSize = true;
            this.searchTime.Location = new System.Drawing.Point(254, 138);
            this.searchTime.Name = "searchTime";
            this.searchTime.Size = new System.Drawing.Size(61, 13);
            this.searchTime.TabIndex = 7;
            this.searchTime.Text = "search time";
            // 
            // wordPadTB
            // 
            this.wordPadTB.Location = new System.Drawing.Point(6, 45);
            this.wordPadTB.Name = "wordPadTB";
            this.wordPadTB.Size = new System.Drawing.Size(164, 80);
            this.wordPadTB.TabIndex = 8;
            this.wordPadTB.Text = "";
            // 
            // solveB
            // 
            this.solveB.Location = new System.Drawing.Point(6, 128);
            this.solveB.Name = "solveB";
            this.solveB.Size = new System.Drawing.Size(164, 23);
            this.solveB.TabIndex = 9;
            this.solveB.Text = "Solve Board";
            this.solveB.UseVisualStyleBackColor = true;
            // 
            // GameStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wordPad);
            this.Controls.Add(this.timer);
            this.Name = "GameStatus";
            this.Size = new System.Drawing.Size(327, 203);
            this.Resize += new System.EventHandler(this.GameStatus_Resize);
            this.wordPad.ResumeLayout(false);
            this.wordPad.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar timer;
        private System.Windows.Forms.GroupBox wordPad;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.TextBox currentWord;
        public System.Windows.Forms.Button submitB;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label searchTime;
        internal System.Windows.Forms.RichTextBox wordPadTB;
        internal System.Windows.Forms.Button solveB;

    }
}
