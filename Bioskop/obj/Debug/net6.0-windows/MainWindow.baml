   M S B A M L   `   `   `  ����B  >Bioskop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:BioskopBioskop  5   	       Bioskop.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Bioskop     5   	     � Title$  Bioskop��5   	   $	��500��6   $	��800��6&   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��dataGridCentralni��5
      $��Center=�6,   $��Center=�6I   $	��230��6d   $
��Auto��6q      
IsReadOnly$
 True��6~      AlternatingRowBackground
 �����   CanUserAddRows$ False��5   8      SelectionUnit$ FullRow=�6O      SelectionMode$ Single=�6g   �� 5   
   $��Center=�6   $��30��62   $	��Top=�6>   $
��auto��6V    �� Orientation$ 
Horizontal=�6c   .+�5      �� -   5         ��Name$ btnFilm��5      $
��Film��6&   
�������
���   �$
��Left=�6`   $��30��6{   $	��Top=�6�   $��75��6�   6�   �� 5      -   5        $ btnHranaIPice��5      $��
HranaIPice��6,   
�������
���   �$
��Left=�6k   $��30��6�   $	��Top=�6�   $��75��6�   6�   �� 5      -   5        $ btnKarta��5      $��Karta��6'   
�������
���   �$
��Left=�6b   $��30��6}   $	��Top=�6�   $��75��6�   6�   �� 5      -   5        $ btnKorisnik��5      $��Korisnik��6*   
�������
���   �$
��Left=�6g   $��30��6�   $	��Top=�6�   $��75��6�   6�   �� 5      -   5        $ btnMusterija��5      $��	Musterija��6+   
�������
���   �$
��Left=�6i   $��30��6�   $	��Top=�6�   $��75��6�   6�   �� 5      -   5        $ btnRacun��5      $��Racun��6'   
�������
���   �$
��Left=�6a   $��30��6|   $	��Top=�6�   $��75��6�   6�   �� 5      -   5        $ btnRezervacija��5      $��Rezervacija��6-   
�������
���   �$
��Left=�6m   $��30��6�   $	��Top=�6�   $��75��6�   6�   �� 5      -	   5        $ btnSala��5      $
��Sala��6&   
�������
���   �$
��Left=�6_   $��30��6z   $	��Top=�6�   $��75��6�   6�   �� 5      -
   5        $ btnSalaFilm2��5      $��	SalaFilm2��6+   
�������
���   �$
��Left=�6i   $��30��6�   $	��Top=�6�   $��75��6�   6�   5      �� 5   
   $��Center=�6   $��30��62   $	��Top=�6?   $	��415��6W   $ 
Horizontal=�6c   $��	0,404,0,0q�6|   .+�5      �� -   5        $ btnDodaj��5      $��Dodaj��6'   
����i��
���   �$	��150��6_   6k   �� 5      -   5        $ 	btnIzmeni��5      $��Izmeni��6(   
����i��
���   �$	��150��6a   6m   �� 5      -   5        $ 	btnObrisi��5      $��Obriši��6(   
����i��
���   �$	��120��6b   6n   5      5      5!      