   M S B A M L   `   `   `  ����G  CFlightBoardX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:FlightBoardX.ModelsFlightBoardX.Models  5   �       FlightBoardX.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6F   4Models!clr-namespace:FlightBoardX.Models     6�   -   5          � Title$  
MainWindow��5   	   $	��413��6   $	��697��6)    � WindowStartupLocation$ CenterScreen=�6L    � 	Resources 5         boardJobViewSource��%   &	        �� 5   
   6   5      .��5	      �  � DataContext# [  6   .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ boardJobDataGrid��5
         AutoGenerateColumns .    EnableRowVirtualization . $��19,41,131,59q�6      RowDetailsVisibilityMode$ VisibleWhenSelected=�6�      
IsReadOnly . ��6g   �� 6�   �� 5   
   -   5        	 ��Name$	 BasesButton��5      $��My Bases��6&   $��Right=�69   $��
0,302,36,0q�6U   $	��Top=�6i   $��75��6�   6�   �� 5   
   -   5        $	 PlanesButton��5      $��	My Planes��6'   $��Right=�6;   $��
0,247,36,0q�6W   $	��Top=�6k   $��75��6�   6�   �� 5   
   -   5        $	 ReGenJobsButton��5      $��Genarate Jobs��6*   $��	0,41,31,0q�6B   $	��Top=�6U   $��Right=�6�   $��80��6�   $��50��6�   �� 5   
   -   5        $	 RunJoButton��5      $��Run Job��6&   $��
0,114,31,0q�68   $	��Top=�6L   $��53��6d   $��Right=�6�   $��80��6�   �� 5   
   -   5        
 ��Name$
 
MoneyLabel��5      $�� ��6$   $
��Left=�6/   $��	20,10,0,0q�6J   $	��Top=�6]   �� 5   
   -   5        $
 CurrentLocationLabel��5      $�� ��6.   $��	20,0,0,31q�69   $��26��6L   $��Bottom=�6X   $
��Left=�6s   �� 5   
   -	   5        $	 ChangeLocationButton��5      $��Change��6/   $��20,0,0,9q�6@   $��Bottom=�6R   $
��Left=�6n   6�   5      5      