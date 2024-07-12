namespace Chat_Client
{
    partial class NameChoice
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
            this.chooseNameLabel = new System.Windows.Forms.Label();
            this.chooseNameTextbox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // chooseNameLabel
            // 
            this.chooseNameLabel.AutoSize = true;
            this.chooseNameLabel.Location = new System.Drawing.Point(252, 34);
            this.chooseNameLabel.Name = "chooseNameLabel";
            this.chooseNameLabel.Size = new System.Drawing.Size(142, 20);
            this.chooseNameLabel.TabIndex = 0;
            this.chooseNameLabel.Text = "Choose your name";
            this.chooseNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chooseNameTextbox
            // 
            this.chooseNameTextbox.Location = new System.Drawing.Point(114, 159);
            this.chooseNameTextbox.Name = "chooseNameTextbox";
            this.chooseNameTextbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.chooseNameTextbox.Size = new System.Drawing.Size(435, 50);
            this.chooseNameTextbox.TabIndex = 1;
            this.chooseNameTextbox.Text = "";
            this.chooseNameTextbox.WordWrap = false;
            this.chooseNameTextbox.TextChanged += new System.EventHandler(this.NameChoice_TextChanged);
            this.chooseNameTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NameChoice_KeyPressed);
            // 
            // NameChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 288);
            this.Controls.Add(this.chooseNameTextbox);
            this.Controls.Add(this.chooseNameLabel);
            this.Name = "NameChoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NameChoice";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NameChoice_FormClosed);
            this.Load += new System.EventHandler(this.NameChoice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label chooseNameLabel;
        private System.Windows.Forms.RichTextBox chooseNameTextbox;
    }
}