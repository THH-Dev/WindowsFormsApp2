namespace WindowsFormsApp2
{
    partial class Form1
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
            this.cogAcqFifoEditV21 = new Cognex.VisionPro.CogAcqFifoEditV2();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnLoad4Img = new System.Windows.Forms.Button();
            this.btnStitchImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cogAcqFifoEditV21)).BeginInit();
            this.SuspendLayout();
            // 
            // cogAcqFifoEditV21
            // 
            this.cogAcqFifoEditV21.Location = new System.Drawing.Point(3, 3);
            this.cogAcqFifoEditV21.MinimumSize = new System.Drawing.Size(489, 0);
            this.cogAcqFifoEditV21.Name = "cogAcqFifoEditV21";
            this.cogAcqFifoEditV21.Size = new System.Drawing.Size(835, 445);
            this.cogAcqFifoEditV21.SuspendElectricRuns = false;
            this.cogAcqFifoEditV21.TabIndex = 0;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 494);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnLoad4Img
            // 
            this.btnLoad4Img.Location = new System.Drawing.Point(117, 494);
            this.btnLoad4Img.Name = "btnLoad4Img";
            this.btnLoad4Img.Size = new System.Drawing.Size(75, 23);
            this.btnLoad4Img.TabIndex = 1;
            this.btnLoad4Img.Text = "Load4Image";
            this.btnLoad4Img.UseVisualStyleBackColor = true;
            this.btnLoad4Img.Click += new System.EventHandler(this.btnLoad4Img_Click);
            // 
            // btnStitchImage
            // 
            this.btnStitchImage.Location = new System.Drawing.Point(228, 494);
            this.btnStitchImage.Name = "btnStitchImage";
            this.btnStitchImage.Size = new System.Drawing.Size(75, 23);
            this.btnStitchImage.TabIndex = 1;
            this.btnStitchImage.Text = "Stitch";
            this.btnStitchImage.UseVisualStyleBackColor = true;
            this.btnStitchImage.Click += new System.EventHandler(this.btnStitchImage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 551);
            this.Controls.Add(this.btnStitchImage);
            this.Controls.Add(this.btnLoad4Img);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.cogAcqFifoEditV21);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cogAcqFifoEditV21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cognex.VisionPro.CogAcqFifoEditV2 cogAcqFifoEditV21;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnLoad4Img;
        private System.Windows.Forms.Button btnStitchImage;
    }
}

