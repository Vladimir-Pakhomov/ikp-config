   M S B A M L   `   `   `  ����L  HMenuTreeComponent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MenuTreeComponentMenuTreeComponent  5   	   .    (MenuTreeComponent.VideoVerdictVisualForm   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   J FMahApps.Metro, Version=1.6.0.184, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	   +localclr-namespace:MenuTreeComponent  5   	     � Title$3  -Формирование заключения��5	   	    � WindowState$ 	Maximized=�6)    � WindowStyle$
 None=�6A    � 
ResizeMode$ NoResize=�6T    � WindowStartupLocation$ CenterOwner=�6j   .��5
      � ��5   
   �� 5       �� Color$
 #EEE��6   6-    � RowDefinitions 5   
   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��5* �6   6*   �� 5      $��1* �6   6*    � ColumnDefinitions 5   
   �� 5      $��1* �6   6,   �� 5      $��1* �6   6,   �� 5      $��1* �6   6,   �� 5      $��1* �6   6,   �� 5      $��1* �6   6,   �� 5      $��1* �6   6,   .+�5   
   R� -   5         R�Name$ verdictTreeView��5      $��1��6,   $��0��69   $��3��6I   $��6��6Z   $��5q�6n   ��5      �� 5      	 �� ItemsSource	 6+   �� 
 �� Path$
 
ChildNodes�.R�5      �� -   5        .��5       ��  �� Orientation$ 
Horizontal=�6%   .+�5!      �� $��20��6(   $��20��63   ��6?   ��  �� RelativeSource ��  �� AncestorType$ ButtonL�$
 
Foreground� J� OpacityMask 5"   "   !� 5#   &    j� Stretch$
 Fill=�62    !� Visual 6A   �� *Icon+5%      �� 5&      $��4 0 0 0q�6(   $��Center=�69   $��18(�6T   ��6b   �� *Name+5'      5(      5)      ��5+      �� 5,       �� 
TargetType" Q�6   .�5-      ��  �� Property �@Q�
IsExpanded �� Value . 6B   5.      50      �� 51   
   -   5         ��Name$ verdictAddBtn��51      $��0��6(   $��0��65   $��5q�6E   .��52      �� $ 
Horizontal=�6   .+�53      �� $��10��6   $��10��54      ��55      ��  �� $ ButtonL�$
 
Foreground� 56      !� 57      $
 Fill=�6&      
appbar_add# [  65   59      �� 5:      $��5 0 0 0q�6   $��Center=�5;      $��Добавить��5<      5=      5>      �� 5?   
   -   5        $ verdictEditBtn��5?      $��0��6)   $��1��66   $��5q�6F   {�.  .��5@      �� $ 
Horizontal=�6   .+�5A      �� $��10��6   $��10��5B      ��5C      ��  �� $ ButtonL�$
 
Foreground� 5D      !� 5E      $
 Fill=�6&     appbar_edit# [ 65   5G      �� 5H      $��5 0 0 0q�6   $��Center=�5I      $��Изменить��5J      5K      5L      �� 5M   
   -   5        $ verdictRemoveBtn��5M      $��0��6+   $��2��68   $��5q�6H   {�.  .��5N      �� $ 
Horizontal=�6   .+�5O      �� $��10��6   $��10��5P      ��5Q      ��  �� $ ButtonL�$
 
Foreground� 5R      !� 5S      $
 Fill=�6&     appbar_delete# [ 65   5U      �� 5V      $��5 0 0 0q�6   $��Center=�5W      $��Удалить��5X      5Y      5Z      �� 5[   
   -   5        $ okBtn��5[      $��0��6    $��4��6-   $��5q�6=   .��6\   ОК6`   �� 5\   
   -   5        $ 	cancelBtn��5\      $��0��6$   $��5��61   $��5q�6A   .��6d   Отмена6l   5]      5^      