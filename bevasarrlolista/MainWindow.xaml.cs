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
     public class ItemModel
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
                priceProgressBar.Minimum = termekek.Min(x => x.Ár);
                priceProgressBar.Maximum = termekek.Max(x => x.Ár);
        }

        private void add(object sender, RoutedEventArgs e)
        {

        }

        private void addWindow(object sender, RoutedEventArgs e)
        {
            var ujTermek = new Hozzaadas();
            if (ujTermek.ShowDialog()==true)
            {
                termekek.Add(ujTermek.ujTermek);
                dataGrid.ItemsSource = termekek;
                dataGrid.Items.Refresh();
            }
        }

        private void delete(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem!=null)
            {
                termekek.Remove((ItemModel)dataGrid.SelectedItem);
                dataGrid.ItemsSource = termekek;
                dataGrid.Items.Refresh();
            }
        }   

        private void aTipusHaromLegdragabb(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = termekek.Where(item => item.Tipus == "A").OrderByDescending(item => item.Összesen).Take(3);
        }

        private void TopOtOsszertek(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = termekek.OrderByDescending(item => item.Összesen).Take(5);
        }

        private void MennyisegNagyobbMint1(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = termekek.Where(item => item.Mennyiség > 1);

        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = termekek;
        }

        private void ArSzerintCsokkeno(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource=termekek.OrderByDescending(item => item.Ár);

        }

        private void MindenDAmiTobbMint500(object sender, RoutedEventArgs e)
        {
           dataGrid.ItemsSource = termekek.Where(item => item.Tipus == "D" && item.Összesen > 500);
        }

        private void NevPluszOsszertekABC(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = termekek.OrderBy(item => item.Név).Select(item => new { Nev = item.Név, Ar = item.Összesen });
        }

        private void TipusDarabPluszOsszertek(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = termekek.GroupBy(item => item.Tipus).Select(g => new { Tipus = g.Key, Darab = g.Count(), Osszertek = g.Sum(item => item.Összesen) });
        }

        private void TipusAtlagar(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = termekek.GroupBy(item => item.Tipus).Select(g => new { Tipus = g.Key, AtlagAr = (int) (g.Average(item => item.Összesen))});
        }

        private void LegnagyobbOsszertekKategoriankent(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = termekek.GroupBy(item => item.Tipus).Select(g => new { Tipus = g.Key, LegnagyobbOsszertek = g.Max(item => item.Összesen) });
        }

        private void BEsCTipus1000NelKisebb(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = termekek.Where(item => (item.Tipus == "B" || item.Tipus == "C") && item.Összesen < 1000);
        }

        private void nagyobbMint10dbEsKisebbMint1000Ft(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = termekek.Where(item => item.Mennyiség > 10 && item.Ár < 1000);
        }

        private void DTipusNAgyobbMint500FtMindenEgysegAr(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = termekek.Where(item => item.Tipus == "D" && item.Összesen > 500).Select(item => new { Nev = item.Név, EgysegAr = item.Ár });
        }

        private void OsszertekNagyobbMint2000ABCTipus(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = termekek.Where(item => (item.Tipus == "A" || item.Tipus == "B" || item.Tipus == "C") && item.Összesen > 2000);
        }

        private void TermekNevPluszTipus(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = termekek.Select(item => new { Nev = item.Név, Tipus = item.Tipus });
        }

        private void LegertekesebbTermekTipusonkentTipusTermekEgysegar(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = termekek.GroupBy(item => item.Tipus).Select(g => g.OrderByDescending(item => item.Ár).First()).Select(item => new {item.Tipus,  item.Név, EgysegAr = item.Ár });
        }

        private void OsszesDarabszamTipusonkent(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = termekek.GroupBy(item => item.Tipus).Select(g => new { Tipus = g.Key, OsszesDarab = g.Sum(item => item.Mennyiség) });
        }

        private void NullaForintosTermekek(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = termekek.Where(item => item.Összesen == 0);
        }

//((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((()))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))))

        private void kenyerek(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = termekek.Where(x => x.Név.Contains("Kenyer")).OrderByDescending(c => c.Ár);

        }

        private void egyezoAr(object sender, RoutedEventArgs e)
        {
            var egyformak = termekek.GroupBy(x => x.Ár)
                .Select(g => new { darab = g.Count() })
                .Any(z => z.darab > 1);

            if (egyformak == true)
            {
                MessageBox.Show($"Van olyan adataink, amelyeknek megeggyezik az ára!");
            }
            else
            {
                MessageBox.Show($"Nincs olyan adat amely egy másik adat árával megeggyezne, mind egyedi");
            }
        }

        private void Valtozas(object sender, TextChangedEventArgs e)
        {
            dataGrid.ItemsSource = termekek.Where(t => t.Név.ToLower().Contains(textBox.Text.ToLower())).ToList();
        }

        private void egyezo(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = termekek
                .GroupBy(t => t.Név)
                .Where(t => t.Count() > 1)
                .SelectMany(t => t);
        }   
    }
}