namespace BoggleClone
{
    partial class LibraryLoader
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
            this.libTypeLB = new System.Windows.Forms.ListBox();
            this.libLoadB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.heightNUM = new System.Windows.Forms.NumericUpDown();
            this.widthNUM = new System.Windows.Forms.NumericUpDown();
            this.resizeB = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.loadTimeL = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heightNUM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthNUM)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // libTypeLB
            // 
            this.libTypeLB.FormattingEnabled = true;
            this.libTypeLB.Items.AddRange(new object[] {
            "Tree",
            "Hash Table",
            "Array"});
            this.libTypeLB.Location = new System.Drawing.Point(6, 19);
            this.libTypeLB.Name = "libTypeLB";
            this.libTypeLB.Size = new System.Drawing.Size(120, 43);
            this.libTypeLB.TabIndex = 0;
            // 
            // libLoadB
            // 
            this.libLoadB.Location = new System.Drawing.Point(132, 19);
            this.libLoadB.Name = "libLoadB";
            this.libLoadB.Size = new System.Drawing.Size(75, 23);
            this.libLoadB.TabIndex = 1;
            this.libLoadB.Text = "Load Library";
            this.libLoadB.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Load Time:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.heightNUM);
            this.groupBox1.Controls.Add(this.widthNUM);
            this.groupBox1.Controls.Add(this.resizeB);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(254, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(189, 85);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Board Dementions";
            // 
            // heightNUM
            // 
            this.heightNUM.Location = new System.Drawing.Point(47, 43);
            this.heightNUM.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.heightNUM.Name = "heightNUM";
            this.heightNUM.Size = new System.Drawing.Size(47, 20);
            this.heightNUM.TabIndex = 10;
            this.heightNUM.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // widthNUM
            // 
            this.widthNUM.Location = new System.Drawing.Point(47, 18);
            this.widthNUM.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.widthNUM.Name = "widthNUM";
            this.widthNUM.Size = new System.Drawing.Size(47, 20);
            this.widthNUM.TabIndex = 9;
            this.widthNUM.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // resizeB
            // 
            this.resizeB.Location = new System.Drawing.Point(116, 19);
            this.resizeB.Name = "resizeB";
            this.resizeB.Size = new System.Drawing.Size(67, 48);
            this.resizeB.TabIndex = 8;
            this.resizeB.Text = "Resize!";
            this.resizeB.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Height";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Width";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.loadTimeL);
            this.groupBox2.Controls.Add(this.libLoadB);
            this.groupBox2.Controls.Add(this.libTypeLB);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 85);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Library Type";
            // 
            // loadTimeL
            // 
            this.loadTimeL.AutoSize = true;
            this.loadTimeL.Location = new System.Drawing.Point(64, 65);
            this.loadTimeL.Name = "loadTimeL";
            this.loadTimeL.Size = new System.Drawing.Size(50, 13);
            this.loadTimeL.TabIndex = 4;
            this.loadTimeL.Text = "loadTime";
            // 
            // LibraryLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "LibraryLoader";
            this.Size = new System.Drawing.Size(446, 95);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heightNUM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthNUM)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.NumericUpDown heightNUM;
        internal System.Windows.Forms.NumericUpDown widthNUM;
        internal System.Windows.Forms.ListBox libTypeLB;
        internal System.Windows.Forms.Button libLoadB;
        internal System.Windows.Forms.Label loadTimeL;
        internal System.Windows.Forms.Button resizeB;
    }
}
