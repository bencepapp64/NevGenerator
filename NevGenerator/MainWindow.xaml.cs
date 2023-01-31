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
using System.IO;
using Microsoft.Win32;
using System.Collections.ObjectModel;

namespace NevGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<String> csaladiNevek = new ObservableCollection<string>();
        private ObservableCollection<String> utoNevek = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCsBetolt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog()==true)
            {
                foreach (var item in File.ReadAllLines(ofd.FileName).ToList())
                {
                    csaladiNevek.Add(item);
                }
                lbxCsNevek.ItemsSource = csaladiNevek;
            }
        }

        private void btnUtBetolt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                foreach (var item in File.ReadAllLines(ofd.FileName).ToList())
                {
                    utoNevek.Add(item);
                }
                lbxUtNevek.ItemsSource = utoNevek;
            }
        }
    }
}
