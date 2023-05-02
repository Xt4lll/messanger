using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
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
    
    public partial class MainWindow : Window
    {
        public static string ip { get; set; }

        public static List<string> users = new List<string>();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void joinBtn_Click(object sender, RoutedEventArgs e)
        {
            IPAddress address = IPAddress.Parse(ip);
            if (nameTbx.Text != "" && IPAddress.TryParse(ip, out address) == true)
            {
                ip = ipTbx.Text;
                users.Add(nameTbx.Text);
                mainFrame.Content = new chatPage();
            } else
            {
                MessageBox.Show("неправильно введены данные");
            }
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            if (nameTbx.Text != "" && ipTbx.Text == "")
            {
                users.Add(nameTbx.Text);
                mainFrame.Content = new serverPage();
            }
        }

        private void ipTbx_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //e.Handled = !Regex.IsMatch(e.Text, @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
        }
    }
}
