using System.IO;
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

namespace celloveszetWPF2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {            
        List<Cellovo> cellovolista = new List<Cellovo>();

        public MainWindow()
        {
            InitializeComponent();

            StreamReader sr = new StreamReader("lovesek (1).csv");
            while (!sr.EndOfStream)
            {
                string? sor = sr.ReadLine();
                Cellovo cellovo = new Cellovo(sor);
                cellovolista.Add(cellovo);
            }
            sr.Close();
            DataGrid.ItemsSource = cellovolista;

        }

        private void ButtonHozzaad_Click(object sender, RoutedEventArgs e)
        {
            int elsoloves = int.Parse(TextBox1.Text);
            int masodikloves= int.Parse(TextBox2.Text);
            int harmadikloves=int.Parse(TextBox3.Text);
            int negyedikloves=int.Parse(TextBox4.Text);
            if (elsoloves>=0 && elsoloves <= 100)
            {
                if(masodikloves>=0&& masodikloves<= 100)
                {
                    if(harmadikloves>=0 && harmadikloves<= 100)
                    {
                        if(negyedikloves>=0 && negyedikloves <= 100)
                        {
                            Cellovo cellovo = new Cellovo(TextBoxNev.Text, elsoloves, masodikloves, harmadikloves, negyedikloves);
                            cellovolista.Add(cellovo);
                        }
                        else
                        {
                            MessageBox.Show("Nem megfelelő értékek!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nem megfelelő értékek!");
                        }
                }
                else
                {
                    MessageBox.Show("Nem megfelelő értékek!");
                        }
            }
            else
            {
                MessageBox.Show("Nem megfelelő értékek!");
                        }
            DataGrid.Items.Refresh();
        }

        private void ButtonMentes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("lovesek2.csv"))
                {
                    foreach (var cellovo in cellovolista)
                    {
                        sw.WriteLine($" {cellovo.nev};{cellovo.elsoloves};{cellovo.masodikloves};{cellovo.harmadikloves};{cellovo.negyedikloves}");
                    }
                }
                MessageBox.Show("Sikeres mentés!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt a mentés során: " + ex.Message);
            }

        }
    }
        
}