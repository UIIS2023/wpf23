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
    /// <summary>
    /// Interaction logic for FrmKorisnik.xaml
    /// </summary>
    public partial class FrmKorisnik : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;
        public FrmKorisnik()
        {
            InitializeComponent();
            txtIme.Focus();
            konekcija = kon.KreirajKonekciju();
        }
        public FrmKorisnik(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            txtIme.Focus();
            konekcija = kon.KreirajKonekciju();
            this.azuriraj = azuriraj;
            this.red = red;
        }
        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };

                cmd.Parameters.Add("@imeKor", SqlDbType.NVarChar).Value = txtIme.Text;
                cmd.Parameters.Add("@prezimeKor", SqlDbType.NVarChar).Value = txtPrezime.Text;
                cmd.Parameters.Add("@JMBGKor", SqlDbType.VarChar).Value = txtJMBG.Text;
                cmd.Parameters.Add("@gradKor", SqlDbType.NVarChar).Value = txtGrad.Text;
                cmd.Parameters.Add("@adresaKor", SqlDbType.NVarChar).Value = txtAdresa.Text;
                cmd.Parameters.Add("@kontaktKor", SqlDbType.NVarChar).Value = txtKontakt.Text;

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"UPDATE tblKorisnik SET imeKor=@imeKor,prezimeKor=@prezimeKor,JMBGKor=@JMBGKor,
                                       gradKor=@gradKor , adresaKor=@adresaKor, kontaktKor=@kontaktKor
                                       WHERE korisnikID=@id";

                    red = null;
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO tblKorisnik(imeKor,prezimeKor,JMBGKor,gradKor, adresaKor, kontaktKor)
                                    VALUES (@imeKor,@prezimeKor,@JMBGKor,@gradKor, @adresaKor, @kontaktKor)";
                }

                cmd.ExecuteNonQuery(); //ova metoda pokrece izvrsenje nase komande gore
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
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
    }
}


