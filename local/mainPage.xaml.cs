using System;
using System.Collections.Generic;
using System.Linq;
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
    /// <summary>
    /// Логика взаимодействия для mainPage.xaml
    /// </summary>
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
            if (nameTbx.Text != "" && ipTbx.Text != "")
            {
                ip = ipTbx.Text;
                users.Add(nameTbx.Text);
                menuFrame.Content = new chatPage();
            }
            else
            {
                MessageBox.Show("неправильно введены данные");
            }
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            if (nameTbx.Text != "" && ipTbx.Text == "")
            {
                users.Add(nameTbx.Text);
                menuFrame.Content = new serverPage();
            }
        }

        private void ipTbx_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //e.Handled = !Regex.IsMatch(e.Text, @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
        }
    }
}