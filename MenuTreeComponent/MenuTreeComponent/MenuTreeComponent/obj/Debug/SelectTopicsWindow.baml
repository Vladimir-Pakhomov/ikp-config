   M S B A M L   `   `   `  ����L  HMenuTreeComponent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MenuTreeComponentMenuTreeComponent  5   	   *    $MenuTreeComponent.SelectTopicsWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   J FMahApps.Metro, Version=1.6.0.184, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	   +localclr-namespace:MenuTreeComponent  5   	     � Title$G  AВыберите упражнения для добавления��5	   	   $	��400��64   $	��600��6A    � 
ResizeMode$ NoResize=�6M   .��5
      � ��5   
   �� 5       �� Color$
 #EEE��6   6-    � RowDefinitions 5   
   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��5* �6   6*   �� 5      $��1* �6   6*    � ColumnDefinitions 5   
   �� 5      $��3* �6   6,   �� 5      $��1* �6   6,   �� 5      $��2* �6   6,   .+�5   
   �� $��0��6   $��0��6!   $��5q�61   $��Center=�6<   CAОтметьте упражнения для добавления6{   �� 5   
   -   5         ��Name$ listBox1��5   _   $��1��6   $��0��6   $��4��6/   $��2��6@   $��5q�6T   ��5      �� 5      .R�5      �� $��16(�6Q   $
��Left=�6_    d� 	IsChecked 6   ��  �� Path$ 	IsChecked� �� Mode$ TwoWay=���6z   �� $
 Name�6�   5      5!      �� 5"   
   -   5        	 ��Name$	 okButton��5"   F   $
��ОК��6   $��1��6   $��2��6+   $��5q�6;   6q   �� 5#   
   -   5        $	 cancelButton��5#   J   $��Отмена��6   $��2��6"   $��2��6/   $��5q�6?   6}   5$      5%      