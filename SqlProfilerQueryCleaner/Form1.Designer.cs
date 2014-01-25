namespace SqlProfilerQueryCleaner
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
            this.txtInputSql = new System.Windows.Forms.TextBox();
            this.txtOutputSql = new System.Windows.Forms.TextBox();
            this.btnClean = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInputSql
            // 
            this.txtInputSql.Location = new System.Drawing.Point(12, 12);
            this.txtInputSql.Multiline = true;
            this.txtInputSql.Name = "txtInputSql";
            this.txtInputSql.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInputSql.Size = new System.Drawing.Size(628, 231);
            this.txtInputSql.TabIndex = 0;
            // 
            // txtOutputSql
            // 
            this.txtOutputSql.Location = new System.Drawing.Point(12, 287);
            this.txtOutputSql.Multiline = true;
            this.txtOutputSql.Name = "txtOutputSql";
            this.txtOutputSql.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutputSql.Size = new System.Drawing.Size(628, 231);
            this.txtOutputSql.TabIndex = 1;
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(268, 250);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(75, 23);
            this.btnClean.TabIndex = 2;
            this.btnClean.Text = "\\/ Clean \\/";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 545);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.txtOutputSql);
            this.Controls.Add(this.txtInputSql);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInputSql;
        private System.Windows.Forms.TextBox txtOutputSql;
        private System.Windows.Forms.Button btnClean;
    }
}

