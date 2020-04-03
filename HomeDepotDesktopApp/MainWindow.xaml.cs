using HomeDepotWebApp;
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

namespace HomeDepotDesktopApp
{
    
    public partial class MainWindow : Window
    {
        private ByggepladsEntities1 _context;
        KundeSet valgtekunde = new KundeSet();
        BookingSet valgteBooking = new BookingSet();


        public MainWindow()
        {
            InitializeComponent();
            _context = new ByggepladsEntities1();
            //OpretDatabase();
        }

        private void BTNFindKunde(object sender, RoutedEventArgs e)
        {
                
                valgtekunde = _context.KundeSets.Find(Int32.Parse(TBId.Text));
            if (valgtekunde != null)
            {
                this.DataContext = null;
                this.DataContext = valgtekunde.BookingSets.ToList().OrderBy(x => x.Afhentningstid);
                TBNavn.Text = valgtekunde.Name;
                TBAdresse.Text = valgtekunde.Adresse;
                TBEmail.Text = valgtekunde.Email;
                TBBrugernavn.Text = valgtekunde.Brugernavn;

            }
            else
            {
                this.DataContext = null;
                MessageBox.Show("KundeID findes ikke");
            }
            CBox.Text = "";
            CBox.SelectedIndex = -1;
        }

        private void BTNOpretKunde(object sender, RoutedEventArgs e)
        {
            try
            {

                KundeSet kundeSet = new KundeSet
                {
                    Name = TBNavn.Text,
                    Adresse = TBAdresse.Text,
                    Email = TBEmail.Text,
                    Brugernavn = TBBrugernavn.Text,
                    Password = TBPassword.Text



                };

                _context.KundeSets.Add(kundeSet);
                _context.SaveChanges();
                MessageBox.Show("Kunde oprettet");

            }
            catch
            {
                
                MessageBox.Show("Fejl");

            }
            TBNavn.Text = "";
            TBId.Text = "";
            TBAdresse.Text = "";
            TBEmail.Text = "";
            TBBrugernavn.Text = "";
            TBPassword.Text = "";
            this.DataContext = null;
            CBox.Text = "";
            CBox.SelectedIndex = -1;

        }

        private void BTNUpdateKunde(object sender, RoutedEventArgs e)
        {
            {

                try
                {

                    valgtekunde.Name = TBNavn.Text;
                    valgtekunde.Adresse = TBAdresse.Text;
                    valgtekunde.Email = TBEmail.Text;
                    valgtekunde.Brugernavn = TBBrugernavn.Text;
                    valgtekunde.Password = TBPassword.Text;

                    _context.SaveChanges();

                    TBNavn.Text = valgtekunde.Name;
                    TBAdresse.Text = valgtekunde.Adresse;
                    TBEmail.Text = valgtekunde.Email;
                    TBBrugernavn.Text = valgtekunde.Brugernavn;
                    TBPassword.Text = TBPassword.Text;
                    MessageBox.Show("Kunde er Opdateret");
                }
                catch
                {

                    MessageBox.Show("Fejl");
                    this.DataContext = null;
                }
            }
        }

        private void Booking_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListBox).SelectedItem is BookingSet b)
            {
                valgteBooking = b;
                if (b.Status == "Reserveret")
                {
                    CBox.SelectedItem = CBReserveret;
                }
                if (b.Status == "Udleveret")
                {
                    CBox.SelectedItem = CBUdleveret;
                }
                if (b.Status == "Tilbageleveret")
                {
                    CBox.SelectedItem = CBUTilbageleveret;
                }
            }
        }
        private void ComboBox_StatusChanged(object sender, MouseButtonEventArgs e)
        {
            ComboBoxItem Cmb = sender as ComboBoxItem;
            {
                MessageBox.Show("" + Cmb.Content.ToString());
                if (Cmb.Content.ToString() == "Reserveret")
                {
                    valgteBooking.Status = Cmb.Content.ToString();
                }
                if (Cmb.Content.ToString() == "Udleveret")
                {
                    valgteBooking.Status = Cmb.Content.ToString();
                }
                if (Cmb.Content.ToString() == "Tilbageleveret")
                {
                    valgteBooking.Status = Cmb.Content.ToString();
                }
                _context.SaveChanges();
                CBox.SelectedItem = Cmb;
            }
        }
        private void OpretDatabase()
        {
            VærktøjSet værktøj = new VærktøjSet();
            værktøj.Navn = "Havetromler";
            værktøj.Beskrivelse = "En havetromle kan bruges til at jævne jord eller plæne i haven";
            værktøj.Depositum = 1000;
            værktøj.Døgnpris = 500;
            _context.VærktøjSet.Add(værktøj);
            _context.SaveChanges();

            værktøj.Navn = "Kompostkværn";
            værktøj.Beskrivelse = "En kompostkværn er en maskine, der kværner og snitter dit haveaffald";
            værktøj.Depositum = 1000;
            værktøj.Døgnpris = 300;
            _context.VærktøjSet.Add(værktøj);
            _context.SaveChanges();

            værktøj.Navn = "Vinkelsliber";
            værktøj.Beskrivelse = "Træskærelse";
            værktøj.Depositum = 600;
            værktøj.Døgnpris = 400;
            _context.VærktøjSet.Add(værktøj);
            _context.SaveChanges();

            værktøj.Navn = "Motersav";
            værktøj.Beskrivelse = "Til at save store ting med";
            værktøj.Depositum = 800;
            værktøj.Døgnpris = 800;
            _context.VærktøjSet.Add(værktøj);
            _context.SaveChanges();

            værktøj.Navn = "Hækkeklipper";
            værktøj.Beskrivelse = "Til at klippe hæk med";
            værktøj.Depositum = 300;
            værktøj.Døgnpris = 300;
            _context.VærktøjSet.Add(værktøj);
            _context.SaveChanges();
        }
    }
}