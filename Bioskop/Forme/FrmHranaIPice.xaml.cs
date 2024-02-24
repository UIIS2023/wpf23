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
    /// Interaction logic for FrmHranaIPice.xaml
    /// </summary>
    public partial class FrmHranaIPice : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;
        public FrmHranaIPice()
        {
            InitializeComponent();
            txtCena.Focus();
            konekcija = kon.KreirajKonekciju();
        }
        public FrmHranaIPice(bool azuriraj, DataRowView red)
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

                cmd.Parameters.Add("@naziv", SqlDbType.NVarChar).Value = txtNaziv.Text;
                cmd.Parameters.Add("@cena", SqlDbType.NVarChar).Value = txtCena.Text;
                cmd.Parameters.Add("@kolicina", SqlDbType.Int).Value = txtKolicina.Text;
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"UPDATE tblHranaIPice SET naziv=@naziv,cena=@cena,kolicina=@kolicina WHERE hranaIPiceID=@id";

                    red = null;
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO tblHranaIPice(naziv,cena,kolicina)
                                    VALUES (@naziv,@cena,@kolicina)";
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
    }
}
