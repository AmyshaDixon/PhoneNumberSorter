namespace PhoneNumberSorter
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
            this.lblDelete = new System.Windows.Forms.Label();
            this.lblCompare = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tbDelete = new System.Windows.Forms.TextBox();
            this.tbCompare = new System.Windows.Forms.TextBox();
            this.btnCompare = new System.Windows.Forms.Button();
            this.btnParse = new System.Windows.Forms.Button();
            this.lblDirections = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDelete
            // 
            this.lblDelete.AutoSize = true;
            this.lblDelete.Location = new System.Drawing.Point(42, 234);
            this.lblDelete.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblDelete.Name = "lblDelete";
            this.lblDelete.Size = new System.Drawing.Size(131, 13);
            this.lblDelete.TabIndex = 0;
            this.lblDelete.Text = "Select a File (Delete from):";
            // 
            // lblCompare
            // 
            this.lblCompare.AccessibleDescription = "";
            this.lblCompare.AutoSize = true;
            this.lblCompare.Location = new System.Drawing.Point(42, 280);
            this.lblCompare.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblCompare.Name = "lblCompare";
            this.lblCompare.Size = new System.Drawing.Size(128, 13);
            this.lblCompare.TabIndex = 1;
            this.lblCompare.Text = "Select a File (Compare to)";
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.Blue;
            this.btnDelete.Location = new System.Drawing.Point(353, 224);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(101, 31);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Browse";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // tbDelete
            // 
            this.tbDelete.Enabled = false;
            this.tbDelete.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbDelete.Location = new System.Drawing.Point(178, 232);
            this.tbDelete.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.tbDelete.MinimumSize = new System.Drawing.Size(152, 4);
            this.tbDelete.Name = "tbDelete";
            this.tbDelete.Size = new System.Drawing.Size(152, 20);
            this.tbDelete.TabIndex = 3;
            // 
            // tbCompare
            // 
            this.tbCompare.Enabled = false;
            this.tbCompare.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbCompare.Location = new System.Drawing.Point(178, 280);
            this.tbCompare.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.tbCompare.MinimumSize = new System.Drawing.Size(152, 4);
            this.tbCompare.Name = "tbCompare";
            this.tbCompare.Size = new System.Drawing.Size(152, 20);
            this.tbCompare.TabIndex = 4;
            // 
            // btnCompare
            // 
            this.btnCompare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompare.ForeColor = System.Drawing.Color.Blue;
            this.btnCompare.Location = new System.Drawing.Point(353, 272);
            this.btnCompare.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(101, 31);
            this.btnCompare.TabIndex = 5;
            this.btnCompare.Text = "Browse";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.BtnCompare_Click);
            // 
            // btnParse
            // 
            this.btnParse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParse.ForeColor = System.Drawing.Color.Green;
            this.btnParse.Location = new System.Drawing.Point(137, 340);
            this.btnParse.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(104, 43);
            this.btnParse.TabIndex = 6;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.BtnParse_Click);
            // 
            // lblDirections
            // 
            this.lblDirections.AutoSize = true;
            this.lblDirections.Location = new System.Drawing.Point(55, 32);
            this.lblDirections.MaximumSize = new System.Drawing.Size(400, 0);
            this.lblDirections.Name = "lblDirections";
            this.lblDirections.Size = new System.Drawing.Size(52, 13);
            this.lblDirections.TabIndex = 7;
            this.lblDirections.Text = "directions";
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExit.Location = new System.Drawing.Point(265, 340);
            this.btnExit.Margin = new System.Windows.Forms.Padding(1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(104, 43);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 425);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblDirections);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.tbCompare);
            this.Controls.Add(this.tbDelete);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblCompare);
            this.Controls.Add(this.lblDelete);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "Form1";
            this.Text = "Phone Number Sorter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDelete;
        private System.Windows.Forms.Label lblCompare;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox tbDelete;
        private System.Windows.Forms.TextBox tbCompare;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.Label lblDirections;
        private System.Windows.Forms.Button btnExit;
    }
}

