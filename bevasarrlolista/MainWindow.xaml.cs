using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace bevasarrlolista
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
     class ItemModel
        {
            public string Név { get; set; }
            public int Mennyiség { get; set; }
            public int Ár { get; set; }
            public string Tipus { get; set; }

            public int Összesen { get; set; }

            public ItemModel(string név, int mennyiség, int ár, string tipus)
            {
                Név = név;
                Mennyiség = mennyiség;
                Ár = ár;
                Tipus = tipus;
                Összesen = mennyiség * ár;
            }
        }
    public partial class MainWindow : Window
    {

        List<ItemModel> termekek = new List<ItemModel>();

        public MainWindow()
        {
            InitializeComponent();
            termekek.Add(new ItemModel("Tej", 5, 450, "A"));
            termekek.Add(new ItemModel("Kenyer", 10, 350, "B"));
            termekek.Add(new ItemModel("Sajt", 2, 1200, "A"));
            termekek.Add(new ItemModel("Alma", 20, 200, "C"));
            termekek.Add(new ItemModel("Narancs", 15, 300, "C"));
            termekek.Add(new ItemModel("Hús", 3, 2500, "D"));
            termekek.Add(new ItemModel("Csokoládé", 7, 900, "B"));
            termekek.Add(new ItemModel("Kenyér", 1, 450, "B"));
            termekek.Add(new ItemModel("Tej", 12, 400, "A"));
            termekek.Add(new ItemModel("Sajt", 5, 1500, "D"));
            dataGrid.ItemsSource = termekek;
        }

        private void add(object sender, RoutedEventArgs e)
        {

        }

        private void addWindow(object sender, RoutedEventArgs e)
        {
            var ablak = new Hozzaadas();
            ablak.ShowDialog();
        }
    }
}