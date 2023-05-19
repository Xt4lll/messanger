using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace local
{

    public partial class chatPage : Page
    {
        private Socket socket;
        private CancellationTokenSource isWorking = new CancellationTokenSource();
        public chatPage()
        {
            InitializeComponent();

            //usersLbx.ItemsSource = currentUsers;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(mainPage.ip, 8888);
            RecieveMessage();
            SendClients();
        }

        private async Task SendClients()
        {
            if (!isWorking.IsCancellationRequested)
            {
                foreach (var user in mainPage.users)
                {
                    byte[] name = Encoding.UTF8.GetBytes("/u" + user);
                    await socket.SendAsync(name, SocketFlags.None);
                }
            }
        }

        /*private async Task GetClients(Socket client)
        {
            if (!isWorking.IsCancellationRequested)
            {
                byte[] bytes = new byte[1024];
                await client.ReceiveAsync(bytes, SocketFlags.None);
                string nameStr = Encoding.UTF8.GetString(bytes);
                usersLbx.Items.Add(nameStr);

                usersLbx.Items.Add(nameStr);
            }
        }*/

        private async Task RecieveMessage()
        {
            while (true)
            {
                byte[] bytes = new byte[1024];
                await socket.ReceiveAsync(bytes, SocketFlags.None);
                string message = Encoding.UTF8.GetString(bytes);

                if (message.Contains("/u"))
                {
                    char[] r = { '/', 'u' };
                    usersLbx.Items.Add(message.TrimStart(r));
                }
                else
                    messagesLbx.Items.Add(message);
            }
        }

        private async Task sendMsg(string msg)
        {
            if (!isWorking.IsCancellationRequested)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(msg);
                await socket.SendAsync(bytes, SocketFlags.None);
            }
        }

        private void sendBtn_Click(object sender, RoutedEventArgs e)
        {
            if (messageTbx.Text == "/disconnect")
            {
                quitBtn_Click(sender, e);
            }
            else
            {
                string msg = $"[{DateTime.Now}]: {messageTbx.Text}";
                sendMsg(msg);
            }
        }

        private void quitBtn_Click(object sender, RoutedEventArgs e)
        {
            isWorking = new CancellationTokenSource();
            isWorking.Cancel();
            socket.Close();
            chatFrame.Content = new mainPage();
        }
    }
}
