   M S B A M L   `   `   `  ����B  >Bioskop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Bioskop.FormeBioskop.Forme  5   	       Bioskop.Forme.FrmKarta   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Bioskop.Forme     5   	     � Title$  Karta��5   	   $	��250��6   $	��350��6$   .��5	      � .+�5
   
   �� $��Vrsta karte:��6   $
��Left=�6'   $��	30,20,0,0q�6B   $	��Top=�6U   �� 5   
   -   5         ��Name$ txtVrstaKarte��5      $
��Left=�6)   $��23��6D   $��
130,20,0,0q�6P    �� TextWrapping$
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��120��6�   6�   �� 5   
   $��Rezervacija:��6   $
��Left=�6'   $��	30,51,0,0q�6B   $	��Top=�6U   �� 5   
   -   5         ��Name$ cbRezervacija��5      $
��Left=�6*   $��
130,55,0,0q�6E   $	��Top=�6Y   $	��120��6q    �� DisplayMemberPath$ Sediste��6}    �� SelectedValuePath$ rezervacijaID��6�   6�   �� 5   
   $��Sala:��6   $
��Left=�6    $��	33,87,0,0q�6;   $	��Top=�6N    J� RenderTransformOrigin$ 0.968,0.233&�6f   �� 5   
   -   5        $ cbSala��5      $
��Left=�6#   $��
130,91,0,0q�6>   $	��Top=�6R   $	��120��6j   $ brMesta��6v   $ salaID��6�   6�   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sačuvaj��6%   $
��Left=�67   $��
50,176,0,0q�6R   $	��Top=�6f   $��79��6~   6�   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkaži��6$   $
��Left=�65   $��210,176,0,0q�6P   $	��Top=�6e   $��75��6}   6�   5      5      