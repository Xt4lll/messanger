﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
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

        private List<Socket> clients = new List<Socket>();
        public serverPage()
        {
            InitializeComponent();

            usersLbx.ItemsSource = MainWindow.users;
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Any, 8888);
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Socket.Bind(ipPoint);
            Socket.Listen(1000);

            ListenToClients();
        }

        private async Task ListenToClients()
        {
            while (true)
            {
                var client = await Socket.AcceptAsync();
                clients.Add(client);
                RecieveMessage(client);
            }
        }

        private async Task RecieveMessage(Socket client)
        {
            while (true)
            {
                byte[] bytes = new byte[1024];
                await client.ReceiveAsync(bytes, SocketFlags.None);
                string message = Encoding.UTF8.GetString(bytes);

                messagesLbx.Items.Add($"[Сообщение от {client.RemoteEndPoint}]: {message}");

                foreach (var item in clients)
                {
                    SendMessage(item, message);
                }
            }
        }

        private async Task SendMessage(Socket client, string message)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            await client.SendAsync(bytes, SocketFlags.None);
        }

        private async Task sendMsg(string msg)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(msg);
            await Socket.SendAsync(bytes, SocketFlags.None);
        }
        private void sendBtn_Click_1(object sender, RoutedEventArgs e)
        {
            sendMsg(messageTbx.Text);
        }
    }
}