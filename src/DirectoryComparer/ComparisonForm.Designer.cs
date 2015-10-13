namespace hk.DirectoryComparer
{
    partial class ComparisonForm
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
            this.btnBrowseFolder1 = new System.Windows.Forms.Button();
            this.btnBrowseFolder2 = new System.Windows.Forms.Button();
            this.textBoxDir1 = new System.Windows.Forms.TextBox();
            this.textBoxDir2 = new System.Windows.Forms.TextBox();
            this.btnCompare = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowseFolder1
            // 
            this.btnBrowseFolder1.Location = new System.Drawing.Point(33, 36);
            this.btnBrowseFolder1.Name = "btnBrowseFolder1";
            this.btnBrowseFolder1.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseFolder1.TabIndex = 0;
            this.btnBrowseFolder1.Text = "Browse";
            this.btnBrowseFolder1.UseVisualStyleBackColor = true;
            // 
            // btnBrowseFolder2
            // 
            this.btnBrowseFolder2.Location = new System.Drawing.Point(33, 92);
            this.btnBrowseFolder2.Name = "btnBrowseFolder2";
            this.btnBrowseFolder2.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseFolder2.TabIndex = 1;
            this.btnBrowseFolder2.Text = "Browse";
            this.btnBrowseFolder2.UseVisualStyleBackColor = true;
            // 
            // textBoxDir1
            // 
            this.textBoxDir1.Location = new System.Drawing.Point(125, 36);
            this.textBoxDir1.Name = "textBoxDir1";
            this.textBoxDir1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBoxDir1.Size = new System.Drawing.Size(696, 20);
            this.textBoxDir1.TabIndex = 2;
            // 
            // textBoxDir2
            // 
            this.textBoxDir2.Location = new System.Drawing.Point(125, 95);
            this.textBoxDir2.Name = "textBoxDir2";
            this.textBoxDir2.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBoxDir2.Size = new System.Drawing.Size(696, 20);
            this.textBoxDir2.TabIndex = 3;
            // 
            // btnCompare
            // 
            this.btnCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompare.Location = new System.Drawing.Point(746, 483);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(75, 23);
            this.btnCompare.TabIndex = 4;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Directory 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Directory 2";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 417);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(389, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "*** Red italic font indicates that the file has been modified in one of the direc" +
                "tories";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 443);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(330, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "*** Blue font indicates which the latest file according to its time stamp";
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(25, 139);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(796, 255);
            this.dataGridView.TabIndex = 12;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(33, 483);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(679, 23);
            this.progressBar.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 522);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.textBoxDir2);
            this.Controls.Add(this.textBoxDir1);
            this.Controls.Add(this.btnBrowseFolder2);
            this.Controls.Add(this.btnBrowseFolder1);
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowseFolder1;
        private System.Windows.Forms.Button btnBrowseFolder2;
        private System.Windows.Forms.TextBox textBoxDir1;
        private System.Windows.Forms.TextBox textBoxDir2;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

