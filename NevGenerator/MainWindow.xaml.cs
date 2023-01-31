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
using System.ComponentModel;

namespace NevGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<String> csaladiNevek = new ObservableCollection<string>();
        private ObservableCollection<String> utoNevek = new ObservableCollection<string>();
        Random r = new Random();
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

        private void btnGeneral_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Convert.ToInt32(lblGeneralando.Text); i++)
            {
                if (cbEgy.IsChecked == true)
                {
                    string csaladnev = csaladiNevek[r.Next(csaladiNevek.Count)];
                    string utonev = utoNevek[r.Next(utoNevek.Count)];
                    lbxKeszNevek.Items.Add($"{csaladnev} {utonev}");
                    csaladiNevek.Remove(csaladnev);
                    utoNevek.Remove(utonev);
                }
                else if (cbKetto.IsChecked == true)
                {
                    string csaladnev = csaladiNevek[r.Next(csaladiNevek.Count)];
                    string utonev = utoNevek[r.Next(utoNevek.Count)];
                    string utonev2 = utoNevek[r.Next(utoNevek.Count)];
                    lbxKeszNevek.Items.Add($"{csaladnev} {utonev} {utonev2}");
                    csaladiNevek.Remove(csaladnev);
                    utoNevek.Remove(utonev);
                    utoNevek.Remove(utonev2);
                }
            }
            NevlistaVegere();
        }

        private void NevlistaVegere()
        {
            lbxCsNevek.Items.MoveCurrentToLast();
            lbxCsNevek.ScrollIntoView(lbxCsNevek.Items.CurrentItem);
            lbxUtNevek.Items.MoveCurrentToLast();
            lbxUtNevek.ScrollIntoView(lbxUtNevek.Items.CurrentItem);
        }

        private void btnTorol_Click(object sender, RoutedEventArgs e)
        {
            lbxKeszNevek.Items.Clear();
        }

        private void btnRendez_Click(object sender, RoutedEventArgs e)
        {
            lbxKeszNevek.Items.SortDescriptions.Add(new SortDescription("", ListSortDirection.Ascending));
            stbRendezes.Content = "Nevek rendezve";
        }

        private void btnMent_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.DefaultExt = "txt";
            sfd.Filter = "Szöveges fájl (*.txt)|*.txt|CSV fájl (*.csv)|*.csv|Összes fájl (*.*)|*.*";
            sfd.Title = "Adja meg a névsor nevét!";
            if (sfd.ShowDialog() == true) 
            {
                try
                {
                    var ListaKiir = lbxKeszNevek.Items.Cast<String>().ToList();
                    File.WriteAllLines(sfd.FileName, ListaKiir);
                    
                }
                catch (Exception)
                {
                    MessageBox.Show("Nem sikerült a mentés");
                    
                }
            }
        }
    }
}
