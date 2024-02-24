using Bioskop;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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


namespace Bioskop.Forme
{
    public partial class FrmRezervacija : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;
        public FrmRezervacija()
        {
            InitializeComponent();
            txtBrojSedista.Focus();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }

        public FrmRezervacija(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            txtBrojSedista.Focus();
            konekcija = kon.KreirajKonekciju();
            this.azuriraj = azuriraj;
            this.red = red;
            PopuniPadajuceListe();
        }

        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija.Open();

                string vratiFilm = @"SELECT filmID, imeFilma AS Film FROM tblFilm";
                SqlDataAdapter daFilm = new SqlDataAdapter(vratiFilm, konekcija);
                DataTable dtGost = new DataTable();
                daFilm.Fill(dtGost);
                cbFilm.ItemsSource = dtGost.DefaultView;
                daFilm.Dispose();
                dtGost.Dispose();


                string vratiKorisnika = @"SELECT korisnikID, imeKor + ' ' + prezimeKor AS Korisnik FROM tblKorisnik";
                SqlDataAdapter daKorisnik = new SqlDataAdapter(vratiKorisnika, konekcija);
                DataTable dtKorisnik = new DataTable();
                daKorisnik.Fill(dtKorisnik);
                cbKorisnik.ItemsSource = dtKorisnik.DefaultView;
                daKorisnik.Dispose();
                dtKorisnik.Dispose();

                string vratiMusteriju = @"SELECT musterijaID, ime + ' ' + prezime AS Musterija FROM tblMusterija";
                SqlDataAdapter daSoba = new SqlDataAdapter(vratiMusteriju, konekcija);
                DataTable dtMusterija = new DataTable();
                daSoba.Fill(dtMusterija);
                cbMusterija.ItemsSource = dtMusterija.DefaultView;
                daSoba.Dispose();
                dtMusterija.Dispose();

            }
            catch (SqlException)
            {
                MessageBox.Show("Padajuce liste nisu popunjene", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DateTime date = (DateTime)dpDatum.SelectedDate;
                string datum = date.ToString("yyyy-MM-dd");
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };

                cmd.Parameters.Add("@datum", SqlDbType.DateTime).Value = datum;
                cmd.Parameters.Add("@brSedista", SqlDbType.Int).Value = txtBrojSedista.Text;
                cmd.Parameters.Add("@brSale", SqlDbType.Int).Value = txtBrojSale.Text;
                cmd.Parameters.Add("@vreme", SqlDbType.NVarChar).Value = txtVreme.Text;
                cmd.Parameters.Add("@filmID", SqlDbType.Int).Value = cbFilm.SelectedValue;
                cmd.Parameters.Add("@korisnikID", SqlDbType.Int).Value = cbKorisnik.SelectedValue;
                cmd.Parameters.Add("@musterijaID", SqlDbType.Int).Value = cbMusterija.SelectedValue;

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"UPDATE tblRezervacija SET datum=@datum, brSedista = @brSedista, brSale= @brSale, vreme=@vreme, 
                                       filmID=@filmID,korisnikID=@korisnikID, musterijaID= @musterijaID
                                       WHERE rezervacijaID=@id";

                    red = null;
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO tblRezervacija(datum , brSedista, brSale, vreme, filmID, korisnikID, musterijaID)
                                        VALUES (@datum , @brSedista, @brSale, @vreme, @filmID, @korisnikID, @musterijaID)";
                }

                cmd.ExecuteNonQuery(); //ova metoda pokrece izvrsenje nase komande gore
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Odaberite datum", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Doslo je do greske prilikom konverzija podataka", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbMusterija_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
