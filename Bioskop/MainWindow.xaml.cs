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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Bioskop.Forme;


namespace Bioskop
{
    public partial class MainWindow : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private string ucitanaTabela;
        private bool azuriraj;
        private DataRowView red;

        #region Select upiti

        private static string filmSelect = @"SELECT filmID AS ID, imeFilma AS 'Ime filma', cenaFilma as 'Cena filma' FROM tblFilm";

        private static string hranaIPiceSelect = @"SELECT hranaIPiceID AS ID, naziv, cena , kolicina FROM tblHranaIPice";

      
        private static string kartaSelect = @"SELECT kartaID AS ID, vrstaKarte AS 'Vrsta karte', brMesta, brSedista FROM tblKarta
                                            JOIN tblRezervacija on tblKarta.rezervacijaID = tblRezervacija.rezervacijaID
                                            JOIN tblSala ON tblKarta.salaID = tblSala.salaID";

        private static string korisnikSelect = @"SELECT korisnikID as ID, imeKor as 'Ime', prezimeKor as 'Prezime', JMBGKor as 'JMBG',
                                                gradKor as 'Grad', adresaKor as 'Adresa' , kontaktKor as 'Kontakt' FROM tblKorisnik";


        private static string musterijaSelect = @"SELECT musterijaID AS ID, ime, prezime FROM tblMusterija";

        private static string racunSelect = @"SELECT racunID AS ID, brRacuna AS 'Broj racuna', brKarata AS 'Broj karata'
                                              FROM tblRacun";


        private static string rezervacijaSelect = @"SELECT rezervacijaID AS ID, datum , brSedista as 'Broj sedista' , brSale as 'Broj sale' , vreme, imeFilma as 'Film'
                                                    ,imeKor as 'Korisnik', ime as 'Musterija' FROM tblRezervacija
                                                   JOIN tblKorisnik on tblRezervacija.korisnikID= tblKorisnik.korisnikID
                                                   JOIN tblFilm on tblRezervacija.filmID = tblFilm.filmID
                                                   JOIN tblMusterija on tblRezervacija.musterijaID = tblMusterija.musterijaID";

        private static string salaSelect = @"SELECT salaID AS ID, brMesta as 'Broj mesta', brSale FROM tblSala
                                            JOIN tblRezervacija on tblSala.rezervacijaID = tblRezervacija.rezervacijaID";

        private static string salaFilm2Select = @"SELECT sala_film2ID AS ID, imeFilma as 'Ime filma', brMesta as 'Broj mesta' FROM tblSalaFilm2
                                                   JOIN tblSala on tblSalaFilm2.salaID= tblSala.salaID
                                                   JOIN tblFilm on tblSalaFilm2.filmID = tblFilm.filmID";
        #endregion

        #region Select sa uslovom

        private static string selectUslovFilm = @"SELECT * FROM tblFilm WHERE filmID=";

        private static string selectUslovHranaIPice = @"SELECT * FROM tblHranaIPice WHERE hranaIPiceID=";

        private static string selectUslovKarta = @"SELECT * FROM tblKarta WHERE kartaID=";

        private static string selectUslovKorisnik = @"SELECT * FROM tblKorisnik WHERE korisnikID=";

        private static string selectUslovMusterija = @"SELECT * FROM tblMusterija WHERE musterijaID=";

        private static string selectUslovRacun = @"SELECT * FROM tblRacun WHERE racunID=";

        private static string selectUslovRezervacija = @"SELECT * FROM tblRezervacija WHERE rezervacijaID=";

        private static string selectUslovSala = @"SELECT * FROM tblSala WHERE salaID=";

        private static string selectUslovSalaFilm2 = @"SELECT * FROM tblSalaFilm2 WHERE sala_film2ID=";

        #endregion

        #region Delete naredbe


        private static string FilmDelete = @"DELETE FROM tblFilm WHERE filmID=";

        private static string HranaIPiceDelete = @"DELETE FROM tblHranaIPice WHERE hranaIPiceID=";

        private static string KartaDelete = @"DELETE FROM tblKarta WHERE kartaID=";

        private static string KorisnikDelete = @"DELETE FROM tblKorisnik WHERE korisnikID=";

        private static string MusterijaDelete = @"DELETE FROM tblMusterija WHERE musterijaID=";

        private static string RacunDelete = @"DELETE FROM tblRacun WHERE racunID=";

        private static string RezervacijaDelete = @"DELETE FROM tblRezervacija WHERE rezervacijaID=";

        private static string SalaDelete = @"DELETE FROM tblSala WHERE salaID=";

        private static string SalaFilm2Delete = @"DELETE FROM tblSalaFilm2 WHERE sala_film2ID=";


        #endregion

        public MainWindow()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            UcitajPodatke(filmSelect);
           
        }

        private void UcitajPodatke(string selectUpit)
        {
            try
            {
                konekcija.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectUpit, konekcija);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                if (dataGridCentralni != null)
                {
                    dataGridCentralni.ItemsSource = dataTable.DefaultView;
                    dataGridCentralni.Visibility = Visibility.Visible;

                }

                ucitanaTabela = selectUpit;
                dataAdapter.Dispose();
                dataTable.Dispose();

            }
            catch (SqlException)
            {
                MessageBox.Show("Nastala je greska pri ucitavanju tabele", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Window prozor;

            if (ucitanaTabela.Equals(filmSelect))
            {
                prozor = new FrmFilm();
                prozor.ShowDialog();
                UcitajPodatke(filmSelect);

            }
            else if (ucitanaTabela.Equals(hranaIPiceSelect))
            {
                prozor = new FrmHranaIPice();
                prozor.ShowDialog();
                UcitajPodatke(hranaIPiceSelect);
            }
            else if (ucitanaTabela.Equals(kartaSelect))
            {
                prozor = new FrmKarta();
                prozor.ShowDialog();
                UcitajPodatke(kartaSelect);
            }
            else if (ucitanaTabela.Equals(korisnikSelect))
            {
                prozor = new FrmKorisnik();
                prozor.ShowDialog();
                UcitajPodatke(korisnikSelect);
            }

            else if (ucitanaTabela.Equals(musterijaSelect))
            {
                prozor = new FrmMusterija();
                prozor.ShowDialog();
                UcitajPodatke(musterijaSelect);
            }
            else if (ucitanaTabela.Equals(racunSelect))
            {
                prozor = new FrmRacun();
                prozor.ShowDialog();
                UcitajPodatke(racunSelect);
            }
            else if (ucitanaTabela.Equals(rezervacijaSelect))
            {
                prozor = new FrmRezervacija();
                prozor.ShowDialog();
                UcitajPodatke(rezervacijaSelect);
            }
            else if (ucitanaTabela.Equals(salaSelect))
            {
                prozor = new FrmSala();
                prozor.ShowDialog();
                UcitajPodatke(salaSelect);
            }
            else if (ucitanaTabela.Equals(salaFilm2Select))
            {
                prozor = new FrmSalaFilm2();
                prozor.ShowDialog();
                UcitajPodatke(salaFilm2Select);
            }

        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(filmSelect))
            {
                PopuniFormu(selectUslovFilm);
                UcitajPodatke(filmSelect);

            }
            else if (ucitanaTabela.Equals(hranaIPiceSelect))
            {
                PopuniFormu(selectUslovHranaIPice);
                UcitajPodatke(hranaIPiceSelect);
            }
            else if (ucitanaTabela.Equals(racunSelect))
            {
                PopuniFormu(selectUslovRacun);
                UcitajPodatke(racunSelect);
            }
            else if (ucitanaTabela.Equals(musterijaSelect))
            {
                PopuniFormu(selectUslovMusterija);
                UcitajPodatke(musterijaSelect);
            }
            else if (ucitanaTabela.Equals(kartaSelect))
            {
                PopuniFormu(selectUslovKarta);
                UcitajPodatke(kartaSelect);
            }
            else if (ucitanaTabela.Equals(korisnikSelect))
            {
                PopuniFormu(selectUslovKorisnik);
                UcitajPodatke(korisnikSelect);
            }
            else if (ucitanaTabela.Equals(rezervacijaSelect))
            {
                PopuniFormu(selectUslovRezervacija);
                UcitajPodatke(rezervacijaSelect);
            }
            else if (ucitanaTabela.Equals(salaSelect))
            {
                PopuniFormu(selectUslovSala);
                UcitajPodatke(salaSelect);
            }
            else if (ucitanaTabela.Equals(salaFilm2Select))
            {
                PopuniFormu(selectUslovSalaFilm2);
                UcitajPodatke(salaFilm2Select);
            }
        }

        private void PopuniFormu(object selectUslov)
        {
            try
            {
                konekcija.Open();
                azuriraj = true;
                red = (DataRowView)dataGridCentralni.SelectedItems[0];
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                cmd.CommandText = selectUslov + "@id";
                SqlDataReader citac = cmd.ExecuteReader();
                cmd.Dispose();
                if (citac.Read())
                {
                    if (ucitanaTabela.Equals(filmSelect))
                    {
                        FrmFilm prozorFilm = new FrmFilm(azuriraj, red);
                        prozorFilm.txtIme.Text = citac["imeFilma"].ToString();
                        prozorFilm.txtCena.Text = citac["cenaFilma"].ToString();
                        prozorFilm.ShowDialog();

                    }
                    else if (ucitanaTabela.Equals(hranaIPiceSelect))
                    {
                        FrmHranaIPice prozorHranaIPice = new FrmHranaIPice(azuriraj, red);
                        prozorHranaIPice.txtCena.Text = citac["naziv"].ToString();
                        prozorHranaIPice.txtCena.Text = citac["cena"].ToString();
                        prozorHranaIPice.txtKolicina.Text = citac["kolicina"].ToString();
                        prozorHranaIPice.ShowDialog();

                    }
                    else if (ucitanaTabela.Equals(kartaSelect))
                    {
                        FrmKarta prozorKarta = new FrmKarta(azuriraj, red);
                        prozorKarta.txtVrstaKarte.Text = citac["vrstaKarte"].ToString();
                        prozorKarta.cbRezervacija.SelectedValue = citac["rezervacijaID"].ToString();
                        prozorKarta.cbSala.SelectedValue = citac["salaID"].ToString();

                        prozorKarta.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(korisnikSelect))
                    {
                        FrmKorisnik prozorKorisnik = new FrmKorisnik(azuriraj, red);
                        prozorKorisnik.txtIme.Text = citac["imeKor"].ToString();
                        prozorKorisnik.txtPrezime.Text = citac["prezimeKor"].ToString();
                        prozorKorisnik.txtJMBG.Text = citac["JMBGKor"].ToString();
                        prozorKorisnik.txtGrad.Text = citac["gradKor"].ToString();
                        prozorKorisnik.txtAdresa.Text = citac["adresaKor"].ToString();
                        prozorKorisnik.txtKontakt.Text = citac["kontaktKor"].ToString();

                        prozorKorisnik.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(musterijaSelect))
                    {
                        FrmMusterija prozorMusterija = new FrmMusterija(azuriraj, red);
                        prozorMusterija.txtIme.Text = citac["ime"].ToString();
                        prozorMusterija.txtPrezime.Text = citac["prezime"].ToString(); ;
                        prozorMusterija.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(racunSelect))
                    {
                        FrmRacun prozorRacun = new FrmRacun(azuriraj, red);
                        prozorRacun.txtBrojRacuna.Text = citac["brRacuna"].ToString();
                        prozorRacun.txtBrojKarata.Text = citac["brKarata"].ToString();
                        prozorRacun.ShowDialog();
                    }

                    else if (ucitanaTabela.Equals(rezervacijaSelect))
                    {
                        FrmRezervacija prozorRezervacija = new FrmRezervacija(azuriraj, red);
                        prozorRezervacija.dpDatum.SelectedDate = (DateTime)citac["datum"];
                        prozorRezervacija.txtBrojSedista.Text = citac["brSedista"].ToString();
                        prozorRezervacija.txtBrojSale.Text = citac["brSale"].ToString();
                        prozorRezervacija.txtVreme.Text = citac["vreme"].ToString();
                        prozorRezervacija.cbFilm.SelectedValue = citac["filmID"].ToString();
                        prozorRezervacija.cbKorisnik.SelectedValue = citac["korisnikID"].ToString();
                        prozorRezervacija.cbMusterija.SelectedValue = citac["musterijaID"].ToString();

                        prozorRezervacija.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(salaSelect))
                    {
                        FrmSala prozorSala = new FrmSala(azuriraj, red);
                        prozorSala.txtBrojMesta.Text = citac["brMesta"].ToString();
                        prozorSala.cbRezervacija.SelectedValue = citac["rezervacijaID"].ToString();

                        prozorSala.ShowDialog();

                    }
                    else if (ucitanaTabela.Equals(salaFilm2Select))
                    {
                        FrmSalaFilm2 prozorSalaFilm2 = new FrmSalaFilm2(azuriraj, red);
                        prozorSalaFilm2.cbFilm.SelectedValue = citac["filmID"].ToString();
                        prozorSalaFilm2.cbSala.SelectedValue = citac["salaID"].ToString();

                        prozorSalaFilm2.ShowDialog();

                    }
                }
            }

            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(filmSelect))
            {
                ObrisiZapis(FilmDelete);
                UcitajPodatke(filmSelect);

            }
            else if (ucitanaTabela.Equals(hranaIPiceSelect))
            {
                ObrisiZapis(HranaIPiceDelete);
                UcitajPodatke(hranaIPiceSelect);
            }
            else if (ucitanaTabela.Equals(kartaSelect))
            {
                ObrisiZapis(KartaDelete);
                UcitajPodatke(kartaSelect);
            }
            else if (ucitanaTabela.Equals(korisnikSelect))
            {
                ObrisiZapis(KorisnikDelete);
                UcitajPodatke(korisnikSelect);
            }
            else if (ucitanaTabela.Equals(musterijaSelect))
            {
                ObrisiZapis(MusterijaDelete);
                UcitajPodatke(musterijaSelect);
            }
            else if (ucitanaTabela.Equals(racunSelect))
            {
                ObrisiZapis(RacunDelete);
                UcitajPodatke(racunSelect);
            }

            else if (ucitanaTabela.Equals(rezervacijaSelect))
            {
                ObrisiZapis(RezervacijaDelete);
                UcitajPodatke(rezervacijaSelect);
            }
            else if (ucitanaTabela.Equals(salaSelect))
            {
                ObrisiZapis(SalaDelete);
                UcitajPodatke(salaSelect);
            }
            else if (ucitanaTabela.Equals(salaFilm2Select))
            {
                ObrisiZapis(SalaFilm2Delete);
                UcitajPodatke(salaFilm2Select);
            }
        }

        private void ObrisiZapis(string deleteUslov)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = konekcija
                    };
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = deleteUslov + "@id";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnFilm_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(filmSelect);
        }

        private void btnHranaIPice_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(hranaIPiceSelect);
        }

        private void btnKarta_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(kartaSelect);
        }

        private void btnKorisnik_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(korisnikSelect);
        }

        private void btnMusterija_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(musterijaSelect);
        }

        private void btnRacun_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(racunSelect);
        }

        private void btnRezervacija_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(rezervacijaSelect);
        }

        private void btnSala_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(salaSelect);
        }

        private void btnSalaFilm2_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(salaFilm2Select);
        }
    }

}
