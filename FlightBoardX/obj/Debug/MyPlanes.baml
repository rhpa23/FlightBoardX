   M S B A M L   `   `   `  ����G  CFlightBoardX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:FlightBoardX.ModelsFlightBoardX.Models  5   �       FlightBoardX.MyPlanes   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6F   4Models!clr-namespace:FlightBoardX.Models     6�   -   5          �Name$
  load��5   �    � Title$ 	MyPlaness��5   	   $	��500��6   $	��570��6(    � WindowStartupLocation$ CenterScreen=�6I    � 	Resources 5         planeViewSource��%   &	        �� 5   
   6   5      .��5
      �  � DataContext# [  6   .+�5   
   �� $��Companny��6   $
��Left=�6#   $��	13,31,0,0q�6>   $	��Top=�6Q    J� RenderTransformOrigin$ -1.27,0.462&�6i   �� 5   
   -   5        $��CompannyTextBox��5      $
��Left=�6)   $��23��6D   $��	91,31,0,0q�6P    �� TextWrapping$
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��223��6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��MyPlanessDataGrid��5      $��10,132,20,0q�6,   $	��Top=�6A   $	��300��6Y      SelectionMode$ Single=�6~      
IsReadOnly . 	   AutoGenerateColumns	 .  ��6f   �� 
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Companny��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *
Companny+  5      $ Country��6%    66   �� *	Country+  5      $ Model��6%    64   �� *	ModelName+5      �� 5   
   -   5        $��	AddButton��5      $	��Add��6"   $
��Left=�60   $��
467,71,0,0q�6K   $	��Top=�6_   $��75��6w   6�   �� 5   
   -   5        $��CloseButton��5      $��Close��6$   $
��Left=�64   $��467,438,0,0q�6O   $	��Top=�6d   $��75��6|   6�   �� 5   
   -   5        $��DeleteButton��5      $��Delete��6%   $
��Left=�66   $��239,437,0,0q�6Q   $	��Top=�6f   $��75��6~   6�   �� 5   
   $��Country��6   $
��Left=�6"   $��	26,62,0,0q�6=   $	��Top=�6P   �� 5   
   -   5        $��CountryComboBox��5      $
��Left=�6*   $��	91,65,0,0q�6E   $	��Top=�6X   $	��223��6p   �� 5   
   $��Model��6   $
��Left=�6    $��	39,93,0,0q�6;   $	��Top=�6N   �� 5   
   -   5        $��ModelComboBox��5      $
��Left=�6(   $��	91,97,0,0q�6C   $	��Top=�6V   $	��223��6n   �� 5   
   -	   5         ��Name$ ModelsButton��5      $	��...��6'   $
��Left=�65   $��
335,97,0,0q�6P   $	��Top=�6d   $��20��6|   6�   5      5      