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
    public partial class FrmFilm : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;
        public FrmFilm()
        {
            InitializeComponent();
            txtIme.Focus();
            konekcija = kon.KreirajKonekciju();
        }

        public FrmFilm(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            txtCena.Focus();
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

                cmd.Parameters.Add("@imeFilma", SqlDbType.NVarChar).Value = txtIme.Text;
                cmd.Parameters.Add("@cenaFilma", SqlDbType.Int).Value = txtCena.Text;
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"UPDATE tblFilm SET imeFilma=@imeFilma, cenaFilma=@cenaFilma WHERE filmID=@id";

                    red = null;
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO tblFilm(imeFilma,cenaFilma)
                                    VALUES (@imeFilma,@cenaFilma)";
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

        private void txtCena_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtIme_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

