   M S B A M L   `   `   `  ����B  >Bioskop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Bioskop.FormeBioskop.Forme  5   	   "    Bioskop.Forme.FrmRezervacija   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Bioskop.Forme     5   	     � Title$  Rezervacija��5   	   $	��400��6   $	��600��6*   .��5	      � .+�5
   
   �� $��Datum:��6   $
��Left=�6!   $��	30,20,0,0q�6<   $	��Top=�6O   �� 5   
   $��Vreme:��6   $
��Left=�6!   $��
30,116,0,0q�6<   $	��Top=�6P   �� 5   
   -   5         ��Name$ txtVreme��5      $
��Left=�6$   $��23��6?   $��130,117,0,0q�6K    �� TextWrapping$
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��120��6�   �� 5   
   $��Broj sedista:��6   $
��Left=�6(   $��	30,50,0,0q�6C   $	��Top=�6V   �� 5   
   $��
Broj sale:��6   $
��Left=�6%   $��	30,81,0,0q�6@   $	��Top=�6S   �� 5   
   $��	Korisnik:��6   $
��Left=�6$   $��
32,195,0,0q�6?   $	��Top=�6S   �� 5   
   -   5        $ txtBrojSedista��5      $
��Left=�6*   $��23��6E   $��
130,51,0,0q�6Q   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��120��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dpDatum��5      $
��Left=�6$   $��
130,10,0,0q�6?   $	��Top=�6S   $��36��6k   $	��120��6w   �� 5   
   -   5        $ txtBrojSale��5      $
��Left=�6'   $��23��6B   $��
130,84,0,0q�6N   $
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��120��6�   �� 5   
   -   5         ��Name$ cbFilm��5      $
��Left=�6#   $��130,157,0,0q�6>   $	��Top=�6S   $	��120��6k    �� DisplayMemberPath$
 Film��6w    �� SelectedValuePath$ filmID��6�   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sačuvaj��6%   $
��Left=�67   $��130,304,0,0q�6R   $	��Top=�6g   $	��105��6   $��43��6�   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkaži��6$   $
��Left=�65   $��340,306,0,0q�6P   $	��Top=�6e   $	��103��6}   $��41��6�   �� 5   
   $��Film:��6   $
��Left=�6    $��
32,155,0,0q�6;   $	��Top=�6O   �� 5   
   -   5        $ 
cbKorisnik��5      $
��Left=�6'   $��130,195,0,0q�6B   $	��Top=�6W   $	��120��6o   $ Korisnik��6{   $ 
korisnikID��6�   �� 5   
   -	   5        $ cbMusterija��5      $
��Left=�6(   $��130,238,0,0q�6C   $	��Top=�6X   $	��120��6p   $ 	Musterija��6|   $ musterijaID��6�   �� 5   
   $��
Musterija:��6   $
��Left=�6%   $��
30,241,0,0q�6@   $	��Top=�6T   5      5      