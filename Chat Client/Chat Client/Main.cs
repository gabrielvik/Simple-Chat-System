using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Chat_Client
{
    public partial class Main : Form
    {
        public class UserButton : Button
        {
            public User UserObj;
        }

        protected static List<UserButton> userBtnList = new List<UserButton>();
        protected static List<Panel> msgPnlList = new List<Panel>();
        public static int SelectedUserID = -1;
        public static NameChoice ActiveNameChoice;

        public Main()
        {
            Networking.ConnectToServer();
            Networking.ReceiveResponses();
            InitializeComponent();
        }

        private void Form1_Load(Object sender, EventArgs e)
        {
            Instance.messagesBack.AutoScroll = true;
            Instance.messagesBack.AutoScrollMinSize = new Size(0, 5);

            // Börja lyssna för svar från servern
            Messages.StartReceiving();
            User.ListenForConnectionChanges();
            User.ListenForUserList();

            leftPanel.BorderStyle = BorderStyle.None;

            ActiveNameChoice = new NameChoice();
            ActiveNameChoice.ShowDialog();

            // Name Choice rutan har stängts
            nameLabel.Invoke(new Action(() => nameLabel.Text = User.ClientUser.Name));
        }

        private static void SelectUser(Object sender, EventArgs e)
        {
            UserButton btn = (UserButton)sender;

            if(btn.BackColor != Color.Empty)
                btn.BackColor = Color.Empty;

            User user = btn.UserObj;

            Instance.choosenUserText.Text = user.Name;

            SelectedUserID = user.ID;

            Messages.RebuildMessageList(user.ID);
        }

        public static void RebuildUsersPanel()
        {
            Instance.usersPanel.Invoke(new Action(() =>
            {
                Instance.usersPanel.Controls.Clear();

                int y = 20;
                foreach(User user in User.Users)
                {
                   // if (user.ID == User.ClientUser.ID)
                     //   continue;

                    UserButton userPnl = new UserButton();
                    userPnl.Location = new Point(0, y);

                    userPnl.Size = new Size(Instance.usersPanel.Width, 50);
                    userPnl.TabIndex = 0;
                    userPnl.UserObj = user;
                    userPnl.Text = user.Name;
                    userPnl.Font = new Font("Montserrat", 10);
                    userPnl.BackColor = Color.Empty;
                    userPnl.ForeColor = Color.White;

                    userPnl.Click += new EventHandler(SelectUser);

                    userBtnList.Add(userPnl);

                    Instance.usersPanel.Invoke(new Action(() => Instance.usersPanel.Controls.Add(userPnl)));

                    y += 50 + 5;
                }
            }));
        }

        private void refershUsersBtn_Click(Object sender, EventArgs e)
        {
            User.RequestUserList();
            RebuildUsersPanel();
        }

        private void usersPanel_Paint(Object sender, PaintEventArgs e)
        {

        }

        public void sendMsgBtn_Click(Object sender, EventArgs e)
        {
            // Returna om man inte valt en giltig användare
            if (User.GetById(SelectedUserID) == null)
                return;

            var message = Instance.messageTextBox.Text;
            if (message.Length < 1 || message.Length > 255)
                return;
            else if (message.Count(msg => msg == '\n') == message.Length)
                return;
            else if (message.Count(msg => msg == '\n') > 10)
                return;


            var netMsg = $"SendMessage|{SelectedUserID}|{message}";
            Networking.ClientSocket.Send(Encoding.UTF8.GetBytes(netMsg));

            var newMsg = new Message()
            {
                Text = Instance.messageTextBox.Text,
                Sender = User.ClientUser.ID
            };

            // Lägg till meddelandet i listan så man kan ladda det senare
            User.Messages[SelectedUserID].Add(newMsg);

            Messages.InsertMessage(newMsg, User.ClientUser.ID);

            Messages.ResetScrollbar();
        }

        private void resetMessages_Click(Object sender, EventArgs e)
        {
            //Networking.ClientSocket.Send(Encoding.UTF8.GetBytes("ResetMessages"));
            User.Messages = new Dictionary<int, List<Message>>();
        }
        
        private void refreshMessages_Click(Object sender, EventArgs e)
        {
            User.Messages = new Dictionary<int, List<Message>>();
            Messages.RebuildMessageList(SelectedUserID);
        }
    }
}