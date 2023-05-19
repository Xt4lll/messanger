using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class mainPage : Page
    {
        public static string ip { get; set; }

        public static List<string> users = new List<string>();
        public mainPage()
        {
            InitializeComponent();
        }

        private void joinBtn_Click(object sender, RoutedEventArgs e)
        {
            Regex validateIPv4Regex = new Regex("^(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
            if (nameTbx.Text != "" && ipTbx.Text != "" && validateIPv4Regex.IsMatch(ipTbx.Text) == true)
            {
                ip = ipTbx.Text;
                users.Add(nameTbx.Text);
                menuFrame.Content = new chatPage();
            }
            else
                MessageBox.Show("неправильно введены данные");
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            if (nameTbx.Text != "" && ipTbx.Text == "")
            {
                users.Add(nameTbx.Text);
                menuFrame.Content = new serverPage();
            }
            else
                MessageBox.Show("неправильно введены данные");
        }
    }
}