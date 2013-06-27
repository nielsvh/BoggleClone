namespace BoggleClone
{
    partial class BoggleClone
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
            this.beginB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // beginB
            // 
            this.beginB.BackColor = System.Drawing.Color.PaleGreen;
            this.beginB.Location = new System.Drawing.Point(209, 113);
            this.beginB.Name = "beginB";
            this.beginB.Size = new System.Drawing.Size(121, 79);
            this.beginB.TabIndex = 0;
            this.beginB.Text = "Start the Game";
            this.beginB.UseVisualStyleBackColor = false;
            this.beginB.Click += new System.EventHandler(this.beginB_Click);
            // 
            // BoggleClone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 526);
            this.Controls.Add(this.beginB);
            this.Name = "BoggleClone";
            this.Text = "Boggle Clone";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button beginB;



    }
}

