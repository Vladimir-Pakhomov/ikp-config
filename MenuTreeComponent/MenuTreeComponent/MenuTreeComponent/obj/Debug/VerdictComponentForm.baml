   M S B A M L   `   `   `  ����L  HMenuTreeComponent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MenuTreeComponentMenuTreeComponent  5   	   ,    &MenuTreeComponent.VerdictComponentForm   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   J FMahApps.Metro, Version=1.6.0.184, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	   +localclr-namespace:MenuTreeComponent  5   	     � Title$K  EКомпонент заключения: редактирование��5	   	   $	��400��66   $	��600��6C    � 
ResizeMode$ NoResize=�6O    � WindowStartupLocation$ CenterOwner=�6e   .��5
      � ��5   
   �� 5       �� Color$
 #EEE��6   6-    � RowDefinitions 5   
   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��5* �6   6*   �� 5      $��1* �6   6*    � ColumnDefinitions 5   
   �� 5      $��3* �6   6,   �� 5      $��1* �6   6,   �� 5      $��2* �6   6,   .+�5   
   �� $��0��6   $��0��6!   $��5q�61   $��Center=�6<   '%Название компонента6l   �� 5   
   -   5         ��Name$ nameTextBox��5      $��1��6'   $��0��64   $��2��6D   $��5q�6X   6e   �� 5   
   -   5         ��Name$ okBtn��5      $��1��6    $��2��6-   $��5q�6=   .��6\   ОК6`   �� 5   
   $��2��6   $��0��6!   $��5q�61   $��Center=�6<   .,Выберите тип компонента6p   �� 5   
    �� Orientation$ Vertical=�6   $��3��6,   $��0��69   $��2��6I   .+�5      �� $ 
Horizontal=�6   .+�5       	� -   5        	 	�Name$	 finalRadioBtn��5       $��1��65   $��0��6B   $��5q�6R   $��Center=�6]   
 	� 	GroupName$
 vcfGroup��6x    d� 	IsChecked$
 TrueY�6�   .��6�   %#Конечный компонент6�   	� 5!      -   5        $	 branchRadioBtn��5!      $��1��66   $��1��6C   $��5q�6S   $��Center=�6^   $
 vcfGroup��6y   .��6�   Пункт меню6�   5"      �� 5#      $ 
Horizontal=�6   .+�5$      	� -   5        $	 isCorrectRadioBtn��5$      $��1��69   $��1��6F   $��5q�6V   $��Center=�6a   $
 ansGroup��6|   $
 TrueY�6�   .��6�   Правильно6�   	� 5%      -   5        $	 isIncorrectRadioBtn��5%      $��1��6;   $��2��6H   $��5q�6X   $��Center=�6c   $
 ansGroup��6~   .��6�   Неправильно6�   5&      5'      �� 5)   
   -   5        $ 	cancelBtn��5)      $��2��6$   $��2��61   $��5q�6A   .��6d   Отмена6l   5+      5,      