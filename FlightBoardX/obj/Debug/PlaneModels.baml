   M S B A M L   `   `   `  ����G  CFlightBoardX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:FlightBoardX.ModelsFlightBoardX.Models  5          FlightBoardX.PlaneModels   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6F   4Models!clr-namespace:FlightBoardX.Models     5      -   5          �Name$
  load��5       � Title$ Models��5   	   $	��500��6   $	��570��6%    � WindowStartupLocation$ CenterScreen=�61    � 	Resources 5         planeModelViewSource��%   &	        �� 5	   
   6   5
      .��5      �  � DataContext# [  6   .+�5   
   �� $
��Name��6   $
��Left=�6   $��
103,31,0,0q�6:   $	��Top=�6N    J� RenderTransformOrigin$ -1.27,0.462&�6f   �� 5   
   -   5        $��NameTextBox��5      $
��Left=�6%   $��23��6@   $��
150,34,0,0q�6L    �� TextWrapping$
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��223��6�   �� 5   
   $
��Cost��6   $
��Left=�6   $��
111,62,0,0q�6:   $	��Top=�6N   �� 5   
   -   5        $��CostTextBox��5      $
��Left=�6%   $��23��6@   $��
150,62,0,0q�6L   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��223��6�   �� 5   
   $��Fuel Consumption��6   $
��Left=�6+   $��	44,93,0,0q�6F   $	��Top=�6Y   �� 5   
   -   5        $��FuelTextBox��5      $
��Left=�6%   $��23��6@   $��
150,93,0,0q�6L   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��223��6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��ModelsDataGrid��5      $��10,132,20,0q�6)   $	��Top=�6>   $	��300��6V      SelectionMode$ Single=�6{      
IsReadOnly . ��6c   �� 6�   �� 5   
   -   5        $��	AddButton��5      $	��Add��6"   $
��Left=�60   $��
467,71,0,0q�6K   $	��Top=�6_   $��75��6w   6�   �� 5   
   -   5        $��CloseButton��5      $��Close��6$   $
��Left=�64   $��467,438,0,0q�6O   $	��Top=�6d   $��75��6|   6�   �� 5   
   -   5        $��DeleteButton��5      $��Delete��6%   $
��Left=�66   $��239,437,0,0q�6Q   $	��Top=�6f   $��75��6~   6�   5      5      