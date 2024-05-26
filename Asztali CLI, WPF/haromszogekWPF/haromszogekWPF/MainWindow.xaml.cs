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
using System.IO;

namespace haromszogekWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<haromszog> haromszogeklista = new List<haromszog>();

        public MainWindow()
        {
            InitializeComponent();
            //beolvasom a fájlt
            StreamReader sr = new StreamReader("haromszogek2.csv");
            //a végéig
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                haromszog h = new haromszog(sor);
                haromszogeklista.Add(h);
            }
            sr.Close();
            DataGrid.ItemsSource = haromszogeklista;
            DataGrid.Items.Refresh();



        }

        private void HozzaadGomb_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(textboxA.Text);
            int b = Convert.ToInt32(textboxB.Text);
            int c = Convert.ToInt32(textboxC.Text);
            if (a < b && b < c)
            {
                haromszog h = new haromszog(a, b, c);
                haromszogeklista.Add(h);
                DataGrid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("A háromszög oldalai nem megfelelőek");
            }
        }

        private void MentesGomb_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("haromszogek3.csv");
            try
            {
                foreach (var item in haromszogeklista)
                {
                    sw.WriteLine(item.a + " " + item.b + " " + item.c);
                }
                sw.Close();
                MessageBox.Show("A mentés sikeres!");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Hiba történt a mentés során: {ex.Message}");

            }

        }
    }
}