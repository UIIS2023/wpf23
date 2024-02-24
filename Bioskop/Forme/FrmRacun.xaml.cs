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
    public partial class FrmRacun : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;
        public FrmRacun()
        {
            InitializeComponent();
            txtBrojRacuna.Focus();
            konekcija = kon.KreirajKonekciju();
        }

        public FrmRacun(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            txtBrojKarata.Focus();
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

                cmd.Parameters.Add("@brRacuna", SqlDbType.NVarChar).Value = txtBrojRacuna.Text;
                cmd.Parameters.Add("@brKarata", SqlDbType.Int).Value = txtBrojKarata.Text;
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"UPDATE tblRacun SET brRacuna=@brRacuna,brKarata=@brKarata WHERE racunID=@id";

                    red = null;
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO tblRacun(brRacuna,brKarata)
                                    VALUES (@brRacuna,@brKarata)";
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
    }
}
