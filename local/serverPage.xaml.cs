using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

    public partial class serverPage : Page
    {

        private Socket Socket;
        private CancellationTokenSource isWorking = new CancellationTokenSource();

        private List<Socket> clients = new List<Socket>();
        public serverPage()
        {
            InitializeComponent();

            //usersLbx.ItemsSource = currentUsers;
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Any, 8888);
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Socket.Bind(ipPoint);
            Socket.Listen(1000);

            ListenToClients();
        }

        private async Task SendClients(Socket client)
        {
            if (!isWorking.IsCancellationRequested)
            {
                foreach (var user in mainPage.users)
                {
                    string u = "/u" + user;
                    byte[] name = Encoding.UTF8.GetBytes(u);
                    await client.SendAsync(name, SocketFlags.None);
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

                foreach (var item in clients)
                {
                    SendClients(item);
                }
            }
        }*/

        private async Task ListenToClients()
        {
            while (!isWorking.IsCancellationRequested)
            {
                var client = await Socket.AcceptAsync();
                clients.Add(client);
                RecieveMessage(client);
                SendClients(client);
            }
        }

        private async Task RecieveMessage(Socket client)
        {
            while (!isWorking.Token.IsCancellationRequested)
            {
                byte[] bytes = new byte[1024];
                await client.ReceiveAsync(bytes, SocketFlags.None);
                string message = Encoding.UTF8.GetString(bytes);
                if (message.Contains("/u"))
                {
                    char[] r = { '/', 'u' };
                    usersLbx.Items.Add(message.TrimStart(r));
                    //SendClients(client);
                }
                else
                {
                    messagesLbx.Items.Add($"[{DateTime.Now}]: {message}");
                    foreach (var item in clients)
                    {
                        SendMessage(item, message);
                    }
                }
            }
        }

        private async Task SendMessage(Socket client, string message)
        {
            if (!isWorking.Token.IsCancellationRequested)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(message);
                await client.SendAsync(bytes, SocketFlags.None);
            }
        }
        private void sendBtn_Click_1(object sender, RoutedEventArgs e)
        {
            string msg = $"[{DateTime.Now}]: {messageTbx.Text}";
            foreach (var item in clients)
            {
                SendMessage(item, msg);
            }
            messagesLbx.Items.Add(msg);
        }

        private void quitBtn_Click(object sender, RoutedEventArgs e)
        {
            isWorking = new CancellationTokenSource();
            isWorking.Cancel();
            Socket.Close();
            serverFrame.Content = new mainPage();
        }
    }
}
