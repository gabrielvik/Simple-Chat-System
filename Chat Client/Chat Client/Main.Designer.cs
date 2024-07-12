namespace Chat_Client
{
    partial class Main
    {
        public static Main Instance;
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
            Instance = this;

            this.leftPanel = new System.Windows.Forms.Panel();
            this.usersPanel = new System.Windows.Forms.Panel();
            this.refershUsersBtn = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.messageTextBox = new System.Windows.Forms.RichTextBox();
            this.choosenUserPanel = new System.Windows.Forms.Panel();
            this.refreshMessages = new System.Windows.Forms.Button();
            this.choosenUserText = new System.Windows.Forms.Label();
            this.sendMsgBtn = new System.Windows.Forms.Button();
            this.messagesBack = new System.Windows.Forms.Panel();
            this.leftPanel.SuspendLayout();
            this.usersPanel.SuspendLayout();
            this.choosenUserPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.leftPanel.Controls.Add(this.usersPanel);
            this.leftPanel.Controls.Add(this.nameLabel);
            this.leftPanel.ForeColor = System.Drawing.Color.Red;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(256, 731);
            this.leftPanel.TabIndex = 0;
            // 
            // usersPanel
            // 
            this.usersPanel.Controls.Add(this.refershUsersBtn);
            this.usersPanel.Location = new System.Drawing.Point(0, 56);
            this.usersPanel.Name = "usersPanel";
            this.usersPanel.Size = new System.Drawing.Size(253, 672);
            this.usersPanel.TabIndex = 2;
            // 
            // refershUsersBtn
            // 
            this.refershUsersBtn.Location = new System.Drawing.Point(5, 14);
            this.refershUsersBtn.Name = "refershUsersBtn";
            this.refershUsersBtn.Size = new System.Drawing.Size(253, 34);
            this.refershUsersBtn.TabIndex = 3;
            this.refershUsersBtn.Text = "Refresh Users";
            this.refershUsersBtn.UseVisualStyleBackColor = true;
            this.refershUsersBtn.Click += new System.EventHandler(this.refershUsersBtn_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameLabel.Font = new System.Drawing.Font("Montserrat", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.nameLabel.Location = new System.Drawing.Point(0, 0);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(256, 53);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(263, 620);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(867, 80);
            this.messageTextBox.TabIndex = 1;
            this.messageTextBox.Text = "";
            // 
            // choosenUserPanel
            // 
            this.choosenUserPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.choosenUserPanel.Controls.Add(this.refreshMessages);
            this.choosenUserPanel.Controls.Add(this.choosenUserText);
            this.choosenUserPanel.Location = new System.Drawing.Point(259, 0);
            this.choosenUserPanel.Name = "choosenUserPanel";
            this.choosenUserPanel.Size = new System.Drawing.Size(974, 53);
            this.choosenUserPanel.TabIndex = 2;
            // 
            // refreshMessages
            // 
            this.refreshMessages.Location = new System.Drawing.Point(718, 12);
            this.refreshMessages.Name = "refreshMessages";
            this.refreshMessages.Size = new System.Drawing.Size(253, 34);
            this.refreshMessages.TabIndex = 4;
            this.refreshMessages.Text = "Reset Messages";
            this.refreshMessages.UseVisualStyleBackColor = true;
            this.refreshMessages.Click += new System.EventHandler(this.refreshMessages_Click);
            // 
            // choosenUserText
            // 
            this.choosenUserText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.choosenUserText.Font = new System.Drawing.Font("Montserrat", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.choosenUserText.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.choosenUserText.Location = new System.Drawing.Point(1, 0);
            this.choosenUserText.Margin = new System.Windows.Forms.Padding(0);
            this.choosenUserText.Name = "choosenUserText";
            this.choosenUserText.Size = new System.Drawing.Size(511, 53);
            this.choosenUserText.TabIndex = 3;
            this.choosenUserText.Text = "No User Selected";
            this.choosenUserText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sendMsgBtn
            // 
            this.sendMsgBtn.Location = new System.Drawing.Point(1133, 620);
            this.sendMsgBtn.Name = "sendMsgBtn";
            this.sendMsgBtn.Size = new System.Drawing.Size(100, 80);
            this.sendMsgBtn.TabIndex = 3;
            this.sendMsgBtn.Text = "Send";
            this.sendMsgBtn.UseVisualStyleBackColor = true;
            this.sendMsgBtn.Click += new System.EventHandler(this.sendMsgBtn_Click);
            // 
            // messagesBack
            // 
            this.messagesBack.AutoScroll = true;
            this.messagesBack.Location = new System.Drawing.Point(264, 60);
            this.messagesBack.Name = "messagesBack";
            this.messagesBack.Size = new System.Drawing.Size(960, 554);
            this.messagesBack.TabIndex = 4;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 729);
            this.Controls.Add(this.messagesBack);
            this.Controls.Add(this.sendMsgBtn);
            this.Controls.Add(this.choosenUserPanel);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.leftPanel);
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.leftPanel.ResumeLayout(false);
            this.usersPanel.ResumeLayout(false);
            this.choosenUserPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftPanel;
        public System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Panel usersPanel;
        private System.Windows.Forms.Button refershUsersBtn;
        public System.Windows.Forms.RichTextBox messageTextBox;
        private System.Windows.Forms.Panel choosenUserPanel;
        public System.Windows.Forms.Label choosenUserText;
        private System.Windows.Forms.Button sendMsgBtn;
        public System.Windows.Forms.Panel messagesBack;
        private System.Windows.Forms.Button refreshMessages;
    }
}

