   M S B A M L   `   `   `  ����H  DForGreen Aelf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:ForGreen_Aelf.Componenet.ModalForGreen_Aelf.Componenet.Modal  5      1    +ForGreen_Aelf.Componenet.Modal.ViewBidModal   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:ForGreen_Aelf.Componenet.Modal     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $��Stretch=�5   &   $��Stretch=�5	      .��5
      � .+�5   
   �� -   5        
���   �  J� Opacity$  .8Q�5   "   6/   �� 5   
   -   5         ��Name$ SizeBox��5       �� CornerRadius$ 3��6"   
�������$	��800��6F   $	��400��6R   $	��400��6_   ._�5      � ���#0b2435 � RowDefinitions 5      �� 5      $��50 �6$   �� 5      $��* �6$   .+�5      �� $��.5q�6   
�������
�������._�5      � $��5q�6   .+�5      �� -   5         ��Name$ HeaderTitle��5   M   $��Center=�6$   $��20(�6?   $��View Bid��6b   �� 5      -   5         ��Name$ CloseBTN��5   z   $��Right=�6!   ���#012033$��X��6R   $��0,4,0,3q�6^   $��41��6o   6�   5      5      �� 5      $��1��6   $��20q�6*   .+�5      �� -   5         ��Name$ AlertBox��5   !   $y�	Collapsed=�63   .+�5      �� $��0,0,0,15q�6!   $��40��63   ._�5      � .+�5   "   �� 
��� ���$��8��6:   $
��Left=�6D   �� 5   "   ���#E6AC00$  .7Q�6;   $��Stretch=�6H   �� 5    "   -   5        $ AlertMessage��5    ,   $��Center=�6B   $��Center=�6_   
�������$��20(�6�   �� 6�   $�Amount should be above��6�   6�   5!      5"      5#      �� 5$      $��0,0,0,15q�6!   .+�5%      &   System.Windows.Controls.DataGrid  -   5        $��HistoryGrid��5%   #   $	��315��66   ���	#39000000   GridLinesVisibility$	 All=�6[      Columns 5'      1  +MaterialDesignThemes.Wpf.DataGridTextColumn  5(   "   ,  &System.Windows.Controls.DataGridColumn	   
IsReadOnly$
	 True��6E   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 150 6q      Header$
 Date��6}   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6X   �� *Date+6}     5)   "   $
	 True��6E      CanUserResize$ False��6u   $
 * 6�   $ 	User Name��6�    6X   �� *
UserName+6�   0  *System.Windows.Controls.DataGridTextColumn  5*   "   $	
 130 65   $
	 True��6B   $	 Bid��6m    6U   �� *Bid+6m   5-      5.      51      52      53      55      56      