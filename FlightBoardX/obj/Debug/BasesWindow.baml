   M S B A M L   `   `   `  ����G  CFlightBoardX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:FlightBoardX.ModelsFlightBoardX.Models  5   �       FlightBoardX.BasesWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6F   4Models!clr-namespace:FlightBoardX.Models     6�   -   5          �Name$
  load��5   �    � Title$ Bases��5   	   $	��500��6   $	��570��6$    � WindowStartupLocation$ CenterScreen=�6E    � 	Resources 5         baseViewSource  MyDataGridStyle �� 
TargetType&   System.Windows.Controls.DataGrid �� Property �� Value*  $System.Windows.Controls.DataGridCell��%I  &	        &	      �� 5   
   6   �� 5   
   "  6(   .�5	      ��  � ��
 �   �6+   �� 5
       �@ 	CellStyle 5      �� 5      "  6   .�5      ��  � ��$ 0q�6<   �� 5       � ��
 �  ��67   �� 5       �@�FocusVisualStyle 6=   Z� 5      5      5      5      .��5      �  � DataContext# [  6   .+�5   
   �� $
��ICAO��6   $
��Left=�6   $��	13,71,0,0q�6:   $	��Top=�6M    J� RenderTransformOrigin$ -1.27,0.462&�6e   �� 5   
   -   5        $��IcaoTextBox��5      	 �� 	MaxLength$	 4��6%   $
��Left=�63   $��23��6N   $��	59,71,0,0q�6Z   
 �� CharacterCasing$
 Upper=�6m    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�     5   
   -   5        $��BasesDataGrid��5      $��10,132,20,0q�6(   $	��Top=�6=   $	��300��6U      SelectionMode$ Single=�6z      
IsReadOnly . #��[ 6�   ��6b   �� 6�   �� 5   
   -   5        $��	AddButton��5      $	��Add��6"   $
��Left=�60   $��
187,71,0,0q�6K   $	��Top=�6_   $��75��6w   6�   �� 5   
   -   5        $��CloseButton��5      $��Close��6$   $
��Left=�64   $��467,438,0,0q�6O   $	��Top=�6d   $��75��6|   6�   �� 5   
   -   5        $��DeleteButton��5      $��Delete��6%   $
��Left=�66   $��239,437,0,0q�6Q   $	��Top=�6f   $��75��6~   6�   5      5      