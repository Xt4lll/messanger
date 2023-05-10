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

            usersLbx.ItemsSource = mainPage.users;
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Any, 8888);
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Socket.Bind(ipPoint);
            Socket.Listen(1000);

            ListenToClients();
        }

        private async Task ListenToClients()
        {
            if (!isWorking.Token.IsCancellationRequested)
            {
                var client = await Socket.AcceptAsync();
                clients.Add(client);
                RecieveMessage(client);
            }
        }

        private async Task RecieveMessage(Socket client)
        {
            if (!isWorking.Token.IsCancellationRequested)
            {
                byte[] bytes = new byte[1024];
                await client.ReceiveAsync(bytes, SocketFlags.None);
                string message = Encoding.UTF8.GetString(bytes);
                messagesLbx.Items.Add($"[{DateTime.Now}]: {message}");

                foreach (var item in clients)
                {
                    SendMessage(item, message);
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
            CancellationToken token = isWorking.Token;
            isWorking.Cancel();
            Socket.Close();
        }
    }
}
