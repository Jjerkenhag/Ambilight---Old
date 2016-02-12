namespace Ambilight
{
    partial class VideoForm
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
            this.buttonFindOffset = new System.Windows.Forms.Button();
            this.buttonCaptureMode = new System.Windows.Forms.Button();
            this.buttonAddOffset = new System.Windows.Forms.Button();
            this.buttonRemoveOffset = new System.Windows.Forms.Button();
            this.labelOffset = new System.Windows.Forms.Label();
            this.textBoxOffset = new System.Windows.Forms.TextBox();
            this.labelHeight = new System.Windows.Forms.Label();
            this.buttonRemoveHeight = new System.Windows.Forms.Button();
            this.buttonAddHeight = new System.Windows.Forms.Button();
            this.buttonRemovePxlX = new System.Windows.Forms.Button();
            this.buttonAddPxlX = new System.Windows.Forms.Button();
            this.buttonRemovePxlY = new System.Windows.Forms.Button();
            this.buttonAddPxlY = new System.Windows.Forms.Button();
            this.labelPixelPerX = new System.Windows.Forms.Label();
            this.labelPixelPerY = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonFindOffset
            // 
            this.buttonFindOffset.BackColor = System.Drawing.Color.Azure;
            this.buttonFindOffset.Location = new System.Drawing.Point(2, 2);
            this.buttonFindOffset.Name = "buttonFindOffset";
            this.buttonFindOffset.Size = new System.Drawing.Size(136, 40);
            this.buttonFindOffset.TabIndex = 0;
            this.buttonFindOffset.Text = "Find";
            this.buttonFindOffset.UseVisualStyleBackColor = false;
            this.buttonFindOffset.Click += new System.EventHandler(this.buttonFindOffset_Click);
            // 
            // buttonCaptureMode
            // 
            this.buttonCaptureMode.BackColor = System.Drawing.Color.Azure;
            this.buttonCaptureMode.Location = new System.Drawing.Point(142, 2);
            this.buttonCaptureMode.Name = "buttonCaptureMode";
            this.buttonCaptureMode.Size = new System.Drawing.Size(136, 40);
            this.buttonCaptureMode.TabIndex = 1;
            this.buttonCaptureMode.Text = "Linear";
            this.buttonCaptureMode.UseVisualStyleBackColor = false;
            this.buttonCaptureMode.Click += new System.EventHandler(this.buttonCaptureMode_Click);
            // 
            // buttonAddOffset
            // 
            this.buttonAddOffset.BackColor = System.Drawing.Color.Azure;
            this.buttonAddOffset.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddOffset.Location = new System.Drawing.Point(194, 44);
            this.buttonAddOffset.Name = "buttonAddOffset";
            this.buttonAddOffset.Size = new System.Drawing.Size(40, 40);
            this.buttonAddOffset.TabIndex = 3;
            this.buttonAddOffset.Text = "+";
            this.buttonAddOffset.UseVisualStyleBackColor = false;
            this.buttonAddOffset.Click += new System.EventHandler(this.buttonAddOffset_Click);
            // 
            // buttonRemoveOffset
            // 
            this.buttonRemoveOffset.BackColor = System.Drawing.Color.Azure;
            this.buttonRemoveOffset.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveOffset.Location = new System.Drawing.Point(238, 44);
            this.buttonRemoveOffset.Name = "buttonRemoveOffset";
            this.buttonRemoveOffset.Size = new System.Drawing.Size(40, 40);
            this.buttonRemoveOffset.TabIndex = 4;
            this.buttonRemoveOffset.Text = "-";
            this.buttonRemoveOffset.UseVisualStyleBackColor = false;
            this.buttonRemoveOffset.Click += new System.EventHandler(this.buttonRemoveOffset_Click);
            // 
            // labelOffset
            // 
            this.labelOffset.AutoSize = true;
            this.labelOffset.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOffset.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelOffset.Location = new System.Drawing.Point(2, 49);
            this.labelOffset.Name = "labelOffset";
            this.labelOffset.Size = new System.Drawing.Size(89, 29);
            this.labelOffset.TabIndex = 4;
            this.labelOffset.Text = "Offset:";
            // 
            // textBoxOffset
            // 
            this.textBoxOffset.BackColor = System.Drawing.Color.Azure;
            this.textBoxOffset.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOffset.Location = new System.Drawing.Point(90, 45);
            this.textBoxOffset.MaxLength = 4;
            this.textBoxOffset.Name = "textBoxOffset";
            this.textBoxOffset.Size = new System.Drawing.Size(100, 37);
            this.textBoxOffset.TabIndex = 2;
            this.textBoxOffset.Text = "0";
            this.textBoxOffset.TextChanged += new System.EventHandler(this.textBoxOffset_TextChanged);
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeight.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelHeight.Location = new System.Drawing.Point(2, 94);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(123, 29);
            this.labelHeight.TabIndex = 6;
            this.labelHeight.Text = "Height: 1/3";
            // 
            // buttonRemoveHeight
            // 
            this.buttonRemoveHeight.BackColor = System.Drawing.Color.Azure;
            this.buttonRemoveHeight.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveHeight.Location = new System.Drawing.Point(238, 88);
            this.buttonRemoveHeight.Name = "buttonRemoveHeight";
            this.buttonRemoveHeight.Size = new System.Drawing.Size(40, 40);
            this.buttonRemoveHeight.TabIndex = 6;
            this.buttonRemoveHeight.Text = "-";
            this.buttonRemoveHeight.UseVisualStyleBackColor = false;
            this.buttonRemoveHeight.Click += new System.EventHandler(this.buttonRemoveHeight_Click);
            // 
            // buttonAddHeight
            // 
            this.buttonAddHeight.BackColor = System.Drawing.Color.Azure;
            this.buttonAddHeight.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddHeight.Location = new System.Drawing.Point(194, 88);
            this.buttonAddHeight.Name = "buttonAddHeight";
            this.buttonAddHeight.Size = new System.Drawing.Size(40, 40);
            this.buttonAddHeight.TabIndex = 5;
            this.buttonAddHeight.Text = "+";
            this.buttonAddHeight.UseVisualStyleBackColor = false;
            this.buttonAddHeight.Click += new System.EventHandler(this.buttonAddHeight_Click);
            // 
            // buttonRemovePxlX
            // 
            this.buttonRemovePxlX.BackColor = System.Drawing.Color.Azure;
            this.buttonRemovePxlX.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemovePxlX.Location = new System.Drawing.Point(238, 134);
            this.buttonRemovePxlX.Name = "buttonRemovePxlX";
            this.buttonRemovePxlX.Size = new System.Drawing.Size(40, 40);
            this.buttonRemovePxlX.TabIndex = 8;
            this.buttonRemovePxlX.Text = "-";
            this.buttonRemovePxlX.UseVisualStyleBackColor = false;
            this.buttonRemovePxlX.Click += new System.EventHandler(this.buttonRemovePxlX_Click);
            // 
            // buttonAddPxlX
            // 
            this.buttonAddPxlX.BackColor = System.Drawing.Color.Azure;
            this.buttonAddPxlX.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddPxlX.Location = new System.Drawing.Point(194, 134);
            this.buttonAddPxlX.Name = "buttonAddPxlX";
            this.buttonAddPxlX.Size = new System.Drawing.Size(40, 40);
            this.buttonAddPxlX.TabIndex = 7;
            this.buttonAddPxlX.Text = "+";
            this.buttonAddPxlX.UseVisualStyleBackColor = false;
            this.buttonAddPxlX.Click += new System.EventHandler(this.buttonAddPxlX_Click);
            // 
            // buttonRemovePxlY
            // 
            this.buttonRemovePxlY.BackColor = System.Drawing.Color.Azure;
            this.buttonRemovePxlY.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemovePxlY.Location = new System.Drawing.Point(238, 180);
            this.buttonRemovePxlY.Name = "buttonRemovePxlY";
            this.buttonRemovePxlY.Size = new System.Drawing.Size(40, 40);
            this.buttonRemovePxlY.TabIndex = 10;
            this.buttonRemovePxlY.Text = "-";
            this.buttonRemovePxlY.UseVisualStyleBackColor = false;
            this.buttonRemovePxlY.Click += new System.EventHandler(this.buttonRemovePxlY_Click);
            // 
            // buttonAddPxlY
            // 
            this.buttonAddPxlY.BackColor = System.Drawing.Color.Azure;
            this.buttonAddPxlY.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddPxlY.Location = new System.Drawing.Point(194, 180);
            this.buttonAddPxlY.Name = "buttonAddPxlY";
            this.buttonAddPxlY.Size = new System.Drawing.Size(40, 40);
            this.buttonAddPxlY.TabIndex = 9;
            this.buttonAddPxlY.Text = "+";
            this.buttonAddPxlY.UseVisualStyleBackColor = false;
            this.buttonAddPxlY.Click += new System.EventHandler(this.buttonAddPxlY_Click);
            // 
            // labelPixelPerX
            // 
            this.labelPixelPerX.AutoSize = true;
            this.labelPixelPerX.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPixelPerX.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelPixelPerX.Location = new System.Drawing.Point(2, 140);
            this.labelPixelPerX.Name = "labelPixelPerX";
            this.labelPixelPerX.Size = new System.Drawing.Size(175, 29);
            this.labelPixelPerX.TabIndex = 13;
            this.labelPixelPerX.Text = "Pixels X/LED: 10";
            // 
            // labelPixelPerY
            // 
            this.labelPixelPerY.AutoSize = true;
            this.labelPixelPerY.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPixelPerY.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelPixelPerY.Location = new System.Drawing.Point(2, 186);
            this.labelPixelPerY.Name = "labelPixelPerY";
            this.labelPixelPerY.Size = new System.Drawing.Size(173, 29);
            this.labelPixelPerY.TabIndex = 14;
            this.labelPixelPerY.Text = "Pixels Y/LED: 10";
            // 
            // VideoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 38F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.MediumBlue;
            this.ClientSize = new System.Drawing.Size(280, 300);
            this.Controls.Add(this.labelPixelPerY);
            this.Controls.Add(this.labelPixelPerX);
            this.Controls.Add(this.buttonRemovePxlY);
            this.Controls.Add(this.buttonAddPxlY);
            this.Controls.Add(this.buttonRemovePxlX);
            this.Controls.Add(this.buttonAddPxlX);
            this.Controls.Add(this.buttonRemoveHeight);
            this.Controls.Add(this.buttonAddHeight);
            this.Controls.Add(this.labelHeight);
            this.Controls.Add(this.textBoxOffset);
            this.Controls.Add(this.labelOffset);
            this.Controls.Add(this.buttonRemoveOffset);
            this.Controls.Add(this.buttonAddOffset);
            this.Controls.Add(this.buttonCaptureMode);
            this.Controls.Add(this.buttonFindOffset);
            this.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.Name = "VideoForm";
            this.Text = "VideoForm";
            this.Load += new System.EventHandler(this.VideoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFindOffset;
        private System.Windows.Forms.Button buttonCaptureMode;
        private System.Windows.Forms.Button buttonAddOffset;
        private System.Windows.Forms.Button buttonRemoveOffset;
        private System.Windows.Forms.Label labelOffset;
        private System.Windows.Forms.TextBox textBoxOffset;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Button buttonRemoveHeight;
        private System.Windows.Forms.Button buttonAddHeight;
        private System.Windows.Forms.Button buttonRemovePxlX;
        private System.Windows.Forms.Button buttonAddPxlX;
        private System.Windows.Forms.Button buttonRemovePxlY;
        private System.Windows.Forms.Button buttonAddPxlY;
        private System.Windows.Forms.Label labelPixelPerX;
        private System.Windows.Forms.Label labelPixelPerY;
    }
}