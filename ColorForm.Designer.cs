namespace Ambilight
{
    partial class ColorForm
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
            this.textBoxRed = new System.Windows.Forms.TextBox();
            this.labelOffset = new System.Windows.Forms.Label();
            this.buttonRemoveRed = new System.Windows.Forms.Button();
            this.buttonAddRed = new System.Windows.Forms.Button();
            this.textBoxGreen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRemoveGreen = new System.Windows.Forms.Button();
            this.buttonAddGreen = new System.Windows.Forms.Button();
            this.textBoxBlue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonRemoveBlue = new System.Windows.Forms.Button();
            this.buttonAddBlue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxRed
            // 
            this.textBoxRed.BackColor = System.Drawing.Color.Azure;
            this.textBoxRed.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRed.Location = new System.Drawing.Point(87, 6);
            this.textBoxRed.MaxLength = 3;
            this.textBoxRed.Name = "textBoxRed";
            this.textBoxRed.Size = new System.Drawing.Size(100, 37);
            this.textBoxRed.TabIndex = 1;
            this.textBoxRed.Text = "0";
            this.textBoxRed.TextChanged += new System.EventHandler(this.textBoxRed_TextChanged);
            this.textBoxRed.GotFocus += new System.EventHandler(this.textBoxRed_GotFocus);
            // 
            // labelOffset
            // 
            this.labelOffset.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOffset.ForeColor = System.Drawing.Color.Red;
            this.labelOffset.Location = new System.Drawing.Point(-1, 10);
            this.labelOffset.Name = "labelOffset";
            this.labelOffset.Size = new System.Drawing.Size(89, 29);
            this.labelOffset.TabIndex = 8;
            this.labelOffset.Text = "Red";
            this.labelOffset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonRemoveRed
            // 
            this.buttonRemoveRed.BackColor = System.Drawing.Color.Azure;
            this.buttonRemoveRed.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveRed.Location = new System.Drawing.Point(235, 5);
            this.buttonRemoveRed.Name = "buttonRemoveRed";
            this.buttonRemoveRed.Size = new System.Drawing.Size(40, 40);
            this.buttonRemoveRed.TabIndex = 7;
            this.buttonRemoveRed.Text = "-";
            this.buttonRemoveRed.UseVisualStyleBackColor = false;
            this.buttonRemoveRed.Click += new System.EventHandler(this.buttonRemoveRed_Click);
            // 
            // buttonAddRed
            // 
            this.buttonAddRed.BackColor = System.Drawing.Color.Azure;
            this.buttonAddRed.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddRed.Location = new System.Drawing.Point(191, 5);
            this.buttonAddRed.Name = "buttonAddRed";
            this.buttonAddRed.Size = new System.Drawing.Size(40, 40);
            this.buttonAddRed.TabIndex = 4;
            this.buttonAddRed.Text = "+";
            this.buttonAddRed.UseVisualStyleBackColor = false;
            this.buttonAddRed.Click += new System.EventHandler(this.buttonAddRed_Click);
            // 
            // textBoxGreen
            // 
            this.textBoxGreen.BackColor = System.Drawing.Color.Azure;
            this.textBoxGreen.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGreen.Location = new System.Drawing.Point(87, 51);
            this.textBoxGreen.MaxLength = 3;
            this.textBoxGreen.Name = "textBoxGreen";
            this.textBoxGreen.Size = new System.Drawing.Size(100, 37);
            this.textBoxGreen.TabIndex = 2;
            this.textBoxGreen.Text = "0";
            this.textBoxGreen.TextChanged += new System.EventHandler(this.textBoxGreen_TextChanged);
            this.textBoxGreen.GotFocus += new System.EventHandler(this.textBoxGreen_GotFocus);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(-1, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 29);
            this.label1.TabIndex = 12;
            this.label1.Text = "Green";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonRemoveGreen
            // 
            this.buttonRemoveGreen.BackColor = System.Drawing.Color.Azure;
            this.buttonRemoveGreen.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveGreen.Location = new System.Drawing.Point(235, 50);
            this.buttonRemoveGreen.Name = "buttonRemoveGreen";
            this.buttonRemoveGreen.Size = new System.Drawing.Size(40, 40);
            this.buttonRemoveGreen.TabIndex = 8;
            this.buttonRemoveGreen.Text = "-";
            this.buttonRemoveGreen.UseVisualStyleBackColor = false;
            this.buttonRemoveGreen.Click += new System.EventHandler(this.buttonRemoveGreen_Click);
            // 
            // buttonAddGreen
            // 
            this.buttonAddGreen.BackColor = System.Drawing.Color.Azure;
            this.buttonAddGreen.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddGreen.Location = new System.Drawing.Point(191, 50);
            this.buttonAddGreen.Name = "buttonAddGreen";
            this.buttonAddGreen.Size = new System.Drawing.Size(40, 40);
            this.buttonAddGreen.TabIndex = 5;
            this.buttonAddGreen.Text = "+";
            this.buttonAddGreen.UseVisualStyleBackColor = false;
            this.buttonAddGreen.Click += new System.EventHandler(this.buttonAddGreen_Click);
            // 
            // textBoxBlue
            // 
            this.textBoxBlue.BackColor = System.Drawing.Color.Azure;
            this.textBoxBlue.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBlue.Location = new System.Drawing.Point(87, 94);
            this.textBoxBlue.MaxLength = 3;
            this.textBoxBlue.Name = "textBoxBlue";
            this.textBoxBlue.Size = new System.Drawing.Size(100, 37);
            this.textBoxBlue.TabIndex = 3;
            this.textBoxBlue.Text = "0";
            this.textBoxBlue.TextChanged += new System.EventHandler(this.textBoxBlue_TextChanged);
            this.textBoxBlue.GotFocus += new System.EventHandler(this.textBoxBlue_GotFocus);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(-1, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 29);
            this.label2.TabIndex = 16;
            this.label2.Text = "Blue";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonRemoveBlue
            // 
            this.buttonRemoveBlue.BackColor = System.Drawing.Color.Azure;
            this.buttonRemoveBlue.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveBlue.Location = new System.Drawing.Point(235, 93);
            this.buttonRemoveBlue.Name = "buttonRemoveBlue";
            this.buttonRemoveBlue.Size = new System.Drawing.Size(40, 40);
            this.buttonRemoveBlue.TabIndex = 9;
            this.buttonRemoveBlue.Text = "-";
            this.buttonRemoveBlue.UseVisualStyleBackColor = false;
            this.buttonRemoveBlue.Click += new System.EventHandler(this.buttonRemoveBlue_Click);
            // 
            // buttonAddBlue
            // 
            this.buttonAddBlue.BackColor = System.Drawing.Color.Azure;
            this.buttonAddBlue.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddBlue.Location = new System.Drawing.Point(191, 93);
            this.buttonAddBlue.Name = "buttonAddBlue";
            this.buttonAddBlue.Size = new System.Drawing.Size(40, 40);
            this.buttonAddBlue.TabIndex = 6;
            this.buttonAddBlue.Text = "+";
            this.buttonAddBlue.UseVisualStyleBackColor = false;
            this.buttonAddBlue.Click += new System.EventHandler(this.buttonAddBlue_Click);
            // 
            // ColorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 38F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(280, 300);
            this.Controls.Add(this.textBoxBlue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonRemoveBlue);
            this.Controls.Add(this.buttonAddBlue);
            this.Controls.Add(this.textBoxGreen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRemoveGreen);
            this.Controls.Add(this.buttonAddGreen);
            this.Controls.Add(this.textBoxRed);
            this.Controls.Add(this.labelOffset);
            this.Controls.Add(this.buttonRemoveRed);
            this.Controls.Add(this.buttonAddRed);
            this.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.Name = "ColorForm";
            this.Text = "ColorForm";
            this.Load += new System.EventHandler(this.ColorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxRed;
        private System.Windows.Forms.Label labelOffset;
        private System.Windows.Forms.Button buttonRemoveRed;
        private System.Windows.Forms.Button buttonAddRed;
        private System.Windows.Forms.TextBox textBoxGreen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRemoveGreen;
        private System.Windows.Forms.Button buttonAddGreen;
        private System.Windows.Forms.TextBox textBoxBlue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonRemoveBlue;
        private System.Windows.Forms.Button buttonAddBlue;
    }
}