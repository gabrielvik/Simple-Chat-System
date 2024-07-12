using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace Chat_Client
{
    public class Message
    {
        public string Text;
        public int Sender;
    }

    public class Messages : Main
    {
        public static void ResetScrollbar()
        {
            Instance.messagesBack.AutoScrollPosition = new Point(0, int.MaxValue);
        }

        public static void StartReceiving()
        {
            NetworkMessages.RetreiveMessage("ReceiveMessage", delegate (List<string> args)
            {
                var msgSender = int.Parse(args[0]);
                var msg = args[1];

                if (!User.Messages.ContainsKey(msgSender))
                    User.Messages[msgSender] = new List<Message>();

                var newMsg = new Message()
                {
                    Text = msg,
                    Sender = msgSender
                };

                User.Messages[msgSender].Add(newMsg);

                Instance.messagesBack.Invoke(new Action(() =>
                {
                    if (SelectedUserID != msgSender)
                    {
                        var userBtn = userBtnList.FirstOrDefault(btn => btn.UserObj.ID == msgSender);
                        userBtn.BackColor = Color.Green;
                        return;
                    }

                    InsertMessage(newMsg, msgSender);
                    ResetScrollbar();
                }));
            });
        }

        public static void InsertMessage(Message msg, int userID)
        {
            var lineAmount = msg.Text.Count(message => message == '\n');
            var msgPanelHeight = 60 + lineAmount * 20;

            var msgPanel = new Panel();
            msgPanel.BackColor = Color.FromKnownColor(KnownColor.ControlDark);
            msgPanel.SetBounds(0, Instance.messagesBack.Height - 60, Instance.messagesBack.Width, msgPanelHeight);
            msgPanel.Dock = DockStyle.Bottom;

            msgPnlList.Add(msgPanel);

            var margin = new Panel();
            margin.BackColor = Instance.messagesBack.BackColor;
            margin.SetBounds(0, msgPanel.Height - 5, msgPanel.Width, 5);

            msgPanel.Controls.Add(margin);

            var senderName = new Label();
            senderName.Dock = DockStyle.Top;
            senderName.Text = userID == User.ClientUser.ID ? "You" : User.GetById(userID).Name; 
            senderName.Font = new Font("Montserrat", 10);
            senderName.ForeColor = Color.White;

            msgPanel.Controls.Add(senderName);

            var msgText = new Label();
            msgText.SetBounds(0, msgPanel.Height - 25 - (lineAmount * 20), msgText.Width, 50 + lineAmount * 20);

            msgText.Text = msg.Text;
            msgText.Font = new Font("Montserrat", 10);
            msgText.ForeColor = Color.White;

            msgPanel.Controls.Add(msgText);

            Instance.messagesBack.Controls.Add(msgPanel);
        }

        public static void RebuildMessageList(int msgSender)
        {
            Instance.messagesBack.Controls.Clear();

            if (!User.Messages.ContainsKey(msgSender))
                User.Messages[msgSender] = new List<Message>();

            foreach (var msg in User.Messages[msgSender])
                InsertMessage(msg, msgSender);

            
        }
    }
}
