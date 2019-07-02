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
            this.SuspendLayout();
            // 
            // lblDelete
            // 
            this.lblDelete.AutoSize = true;
            this.lblDelete.Location = new System.Drawing.Point(112, 270);
            this.lblDelete.Name = "lblDelete";
            this.lblDelete.Size = new System.Drawing.Size(351, 32);
            this.lblDelete.TabIndex = 0;
            this.lblDelete.Text = "Select a file to delete from:";
            // 
            // lblCompare
            // 
            this.lblCompare.AccessibleDescription = "";
            this.lblCompare.AutoSize = true;
            this.lblCompare.Location = new System.Drawing.Point(112, 378);
            this.lblCompare.Name = "lblCompare";
            this.lblCompare.Size = new System.Drawing.Size(350, 32);
            this.lblCompare.TabIndex = 1;
            this.lblCompare.Text = "Select a file to compare to:";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(941, 246);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(270, 73);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Browse";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // tbDelete
            // 
            this.tbDelete.Enabled = false;
            this.tbDelete.Location = new System.Drawing.Point(474, 264);
            this.tbDelete.MinimumSize = new System.Drawing.Size(400, 0);
            this.tbDelete.Name = "tbDelete";
            this.tbDelete.Size = new System.Drawing.Size(400, 38);
            this.tbDelete.TabIndex = 3;
            // 
            // tbCompare
            // 
            this.tbCompare.Enabled = false;
            this.tbCompare.Location = new System.Drawing.Point(474, 378);
            this.tbCompare.MinimumSize = new System.Drawing.Size(400, 0);
            this.tbCompare.Name = "tbCompare";
            this.tbCompare.Size = new System.Drawing.Size(400, 38);
            this.tbCompare.TabIndex = 4;
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(941, 360);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(270, 73);
            this.btnCompare.TabIndex = 5;
            this.btnCompare.Text = "Browse";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.BtnCompare_Click);
            // 
            // btnParse
            // 
            this.btnParse.ForeColor = System.Drawing.Color.Green;
            this.btnParse.Location = new System.Drawing.Point(528, 528);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(276, 103);
            this.btnParse.TabIndex = 6;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.BtnParse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1349, 784);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.tbCompare);
            this.Controls.Add(this.tbDelete);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblCompare);
            this.Controls.Add(this.lblDelete);
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
    }
}

