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
    public partial class FrmSalaFilm2 : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;
        public FrmSalaFilm2()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();

        }

        public FrmSalaFilm2(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
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

                string vratiFilm = @"SELECT filmID, imeFilma AS Info FROM tblFilm";
                SqlDataAdapter daFilm = new SqlDataAdapter(vratiFilm, konekcija);
                DataTable dtFilm = new DataTable();
                daFilm.Fill(dtFilm);
                cbFilm.ItemsSource = dtFilm.DefaultView;
                daFilm.Dispose();
                dtFilm.Dispose();

                string vratiSalu = @"SELECT salaID, brMesta AS Info FROM tblSala";
                SqlDataAdapter daSala = new SqlDataAdapter(vratiSalu, konekcija);
                DataTable dtSala = new DataTable();
                daSala.Fill(dtSala);
                cbSala.ItemsSource = dtSala.DefaultView;
                daSala.Dispose();
                dtSala.Dispose();



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

                cmd.Parameters.Add("@filmID", SqlDbType.Int).Value = cbFilm.SelectedValue;
                cmd.Parameters.Add("@salaID", SqlDbType.Int).Value = cbSala.SelectedValue;

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"UPDATE tblSalaFilm2 SET filmID = @filmID, salaID = @salaID WHERE sala_film2ID = @id";

                    red = null;
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO tblSalaFilm2 (filmID, salaID)
                                    VALUES (@filmID, @salaID)";
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

        private void cbSala_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

