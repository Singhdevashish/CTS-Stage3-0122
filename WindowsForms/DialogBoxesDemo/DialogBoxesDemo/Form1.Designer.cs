
namespace DialogBoxesDemo
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
            this.btnFonts = new System.Windows.Forms.Button();
            this.lblText = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.btnSaveLocation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFonts
            // 
            this.btnFonts.Location = new System.Drawing.Point(113, 59);
            this.btnFonts.Name = "btnFonts";
            this.btnFonts.Size = new System.Drawing.Size(173, 52);
            this.btnFonts.TabIndex = 1;
            this.btnFonts.Text = "Choose Fonts";
            this.btnFonts.UseVisualStyleBackColor = true;
            this.btnFonts.Click += new System.EventHandler(this.btnFonts_Click);
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(224, 315);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(202, 25);
            this.lblText.TabIndex = 2;
            this.lblText.Text = "Hello Windows Forms";
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(343, 59);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(173, 52);
            this.btnColor.TabIndex = 1;
            this.btnColor.Text = "Choose Color";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(113, 141);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(173, 52);
            this.btnChooseFile.TabIndex = 1;
            this.btnChooseFile.Text = "Choose File";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // btnSaveLocation
            // 
            this.btnSaveLocation.Location = new System.Drawing.Point(343, 141);
            this.btnSaveLocation.Name = "btnSaveLocation";
            this.btnSaveLocation.Size = new System.Drawing.Size(188, 78);
            this.btnSaveLocation.TabIndex = 1;
            this.btnSaveLocation.Text = "Choose Save Location";
            this.btnSaveLocation.UseVisualStyleBackColor = true;
            this.btnSaveLocation.Click += new System.EventHandler(this.btnSaveLocation_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.btnSaveLocation);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.btnFonts);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFonts;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.Button btnSaveLocation;
    }
}

