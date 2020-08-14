namespace yemeksepeti
{
    partial class UserControl2
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
            this.label_isim = new System.Windows.Forms.Label();
            this.label_fiyat = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_isim
            // 
            this.label_isim.AutoSize = true;
            this.label_isim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_isim.Location = new System.Drawing.Point(3, 14);
            this.label_isim.Name = "label_isim";
            this.label_isim.Size = new System.Drawing.Size(86, 20);
            this.label_isim.TabIndex = 0;
            this.label_isim.Text = "yemek ismi";
            // 
            // label_fiyat
            // 
            this.label_fiyat.AutoSize = true;
            this.label_fiyat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_fiyat.ForeColor = System.Drawing.Color.Green;
            this.label_fiyat.Location = new System.Drawing.Point(115, 14);
            this.label_fiyat.Name = "label_fiyat";
            this.label_fiyat.Size = new System.Drawing.Size(47, 20);
            this.label_fiyat.TabIndex = 1;
            this.label_fiyat.Text = "Fiyat:";
            // 
            // UserControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_fiyat);
            this.Controls.Add(this.label_isim);
            this.Name = "UserControl2";
            this.Size = new System.Drawing.Size(191, 47);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_isim;
        private System.Windows.Forms.Label label_fiyat;
    }
}
