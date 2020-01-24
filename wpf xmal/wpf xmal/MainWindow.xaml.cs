using Microsoft.Win32;
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

namespace wpf_xmal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int number= 0;
        public MainWindow()
        {
            InitializeComponent();

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Title = e.GetPosition(this).ToString();
        }

       
        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            number = number + 8;
            MessageBox.Show("8");
            
        }
        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            number = number + 9;
        }
        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            number = number + 7;
        }
        

    }
}
