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
        /*private CancellationTokenSource isWorking;*/
        public chatPage()
        {
            InitializeComponent();

            usersLbx.ItemsSource = MainWindow.users;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(MainWindow.ip, 8888);
            RecieveMessage();
        }

        private async Task RecieveMessage()
        {
            while (true)
            {
                byte[] bytes = new byte[1024];
                await socket.ReceiveAsync(bytes, SocketFlags.None);
                string message = Encoding.UTF8.GetString(bytes);

                messagesLbx.Items.Add(message);
            }
        }

        private async Task sendMsg(string msg)
        {
                byte[] bytes = Encoding.UTF8.GetBytes(msg);
                await socket.SendAsync(bytes, SocketFlags.None);
        }

        private void sendBtn_Click(object sender, RoutedEventArgs e)
        {
            sendMsg(messageTbx.Text);
        }

        private void quitBtn_Click(object sender, RoutedEventArgs e)
        {
            /*isWorking.Cancel();*/

        }
    }
}
