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


namespace IskolaWPF2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Tanulo> tanulolista = new List<Tanulo>();

        public MainWindow()
        {
            InitializeComponent();
            StreamReader sr = new StreamReader("nevek (1).txt");
            while (!sr.EndOfStream)
            {
                string? sor = sr.ReadLine();
                Tanulo t = new Tanulo(sor);
                tanulolista.Add(t);
            }
            sr.Close();

            
            ListBox.ItemsSource = tanulolista;
            ListBox.Items.Refresh();
        }

        private void TorlesGomb_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox.SelectedItem != null)
            {
                tanulolista.Remove((Tanulo)ListBox.SelectedItem);
                ListBox.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Nem jelölt ki tanulót!");
            }

        }

        private void MentésGomb_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("nevekNEW.txt"))
                {
                    foreach (var tanulo in tanulolista)
                    {
                        sw.WriteLine($"{tanulo.ev};{tanulo.osztaly};{tanulo.nev}");
                    }
                }
                MessageBox.Show("Sikeres mentés!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a mentés során: {ex.Message}");
            }

        }
    }
}