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
using System.Windows.Shapes;

namespace bevasarrlolista
{
    /// <summary>
    /// Interaction logic for Hozzaadas.xaml
    /// </summary>
    public partial class Hozzaadas : Window
    {

        public ItemModel ujTermek;
        public Hozzaadas()
        {
            InitializeComponent();
        }

        private void okkeButton(object sender, RoutedEventArgs e)
        {
            int Mennyiseg_;
            int EgysegAr_;
            if (Nev.Text == "" || !int.TryParse(Mennyiseg.Text, out Mennyiseg_) || !int.TryParse(Egysegar.Text, out EgysegAr_) || Tipus.SelectedItem == null)
            {
                MessageBox.Show("Minden adatot adjon meg!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                ujTermek = new ItemModel(Nev.Text, int.Parse(Mennyiseg.Text), int.Parse(Egysegar.Text), Tipus.Text);
                DialogResult = true;
            }


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
