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
    /// Interaction logic for FrmFilm.xaml
    /// </summary>
    public partial class FrmSala : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;
        public FrmSala()
        {
            InitializeComponent();
            txtBrojMesta.Focus();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }

        public FrmSala(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            txtBrojMesta.Focus();
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

                string vratiRezervaciju = @"SELECT rezervacijaID,  brSale AS Info FROM tblRezervacija";
                SqlDataAdapter daRezervacija = new SqlDataAdapter(vratiRezervaciju, konekcija);
                DataTable dtRezervacija = new DataTable();
                daRezervacija.Fill(dtRezervacija);
                cbRezervacija.ItemsSource = dtRezervacija.DefaultView;
                daRezervacija.Dispose();
                dtRezervacija.Dispose();



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
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };

                cmd.Parameters.Add("@brMesta", SqlDbType.NVarChar).Value = txtBrojMesta.Text;
                cmd.Parameters.Add("@rezervacijaID", SqlDbType.Int).Value = cbRezervacija.SelectedValue;

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"UPDATE tblSala SET brMesta=@brMesta, rezervacijaID=@rezervacijaID WHERE salaID=@id";

                    red = null;
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO tblSala(brMesta, rezervacijaID)
                                    VALUES (@brMesta,@rezervacijaID)";
                }


                cmd.ExecuteNonQuery(); //ova metoda pokrece izvrsenje nase komande gore
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void cbRezervacija_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtBrojMesta_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cbRezervacija_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

