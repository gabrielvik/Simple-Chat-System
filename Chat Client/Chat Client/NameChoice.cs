using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using Newtonsoft.Json;

namespace Chat_Client
{
    public partial class NameChoice : Form
    {
        public NameChoice()
        {
            InitializeComponent();
        }

        private void NameChoice_Load(Object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;

            chooseNameTextbox.Multiline = false;
            chooseNameTextbox.SelectAll();
            chooseNameTextbox.SelectionAlignment = HorizontalAlignment.Center;

            NetworkMessages.RetreiveMessage("NameChoiceSuccess", delegate (List<string> args)
            {
                var msg = args[0];

                Main.ActiveNameChoice.Invoke(new Action(() =>
                {
                    Main.ActiveNameChoice.Close();
                    User.ClientUser = JsonConvert.DeserializeObject<User>(msg);
                    User.RequestUserList();
                }));
            });
        }

        private void NameChoice_TextChanged(Object sender, EventArgs e)
        {
            chooseNameTextbox.SelectionFont = new Font("Montserrat", 12);
        }

        private void NameChoice_FormClosed(Object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void NameChoice_KeyPressed(Object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                RequestChooseName(chooseNameTextbox.Text);
            }
        }

        private static void RequestChooseName(string name)
        {
            Networking.ClientSocket.Send(Encoding.UTF8.GetBytes($"NameChoice|{name}"), SocketFlags.None);

            //Networking.ReceiveResponse(delegate (string msg) {
            //    Console.WriteLine("Received msg: " + msg);
            //    if (msg != "0")
            //    {
            //        User.ClientUser = JsonConvert.DeserializeObject<User>(msg);

            //        Main.ActiveNameChoice.Invoke((Action)Main.ActiveNameChoice.Close);
            //    }
            //    User.RequestUserList();
            //});
        }


    }
}
