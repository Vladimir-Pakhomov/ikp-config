   M S B A M L   `   `   `  ����L  HMenuTreeComponent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MenuTreeComponentMenuTreeComponent  5   	   )    #MenuTreeComponent.ImageResolverForm   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:MenuTreeComponent     5   	   J FMahApps.Metro, Version=1.6.0.184, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	     � Title$E  ?Материал-картинка: редактирование��5	   	   $	��400��63   $	��600��6@    � 
ResizeMode$ NoResize=�6L    � WindowStartupLocation$ CenterOwner=�6b   .��5
      � ��5   
   �� 5       �� Color$
 #EEE��6   6-    � RowDefinitions 5   
   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��5* �6   6*   �� 5      $��1* �6   6*    � ColumnDefinitions 5   
   �� 5      $��3* �6   6,   �� 5      $��1* �6   6,   �� 5      $��2* �6   6,   .+�5   
   �� $��0��6   $��0��6!   $��5q�61   $��Center=�6<   %#Название материала6k   �� 5   
   -   5         ��Name$ nameTextBox��5      $��1��6'   $��0��64   $��2��6D   $��5q�6X   6e   �� 5   
   $��2��6   $��0��6!   $��5q�61   $��Center=�6<   %#Картинка материала6k   �� 5   
   -   5         ��Name$ okBtn��5      $��1��6    $��2��6-   $��5q�6=   .��6\   OK6`   �� 5   
   $��3��6   $��0��6   $��2��6.   $��2��6?   ._�5      �� -   5         ��Name$ contentImage��5      $��5q�6*   67   5       �� 5!   
   -   5        $ selectImageBtn��5!      $��2��6)   $��1��66   $��5q�6F   .��6n   Обзор...6x   �� 5"   
   -   5        $ 	cancelBtn��5"      $��2��6$   $��2��61   $��5q�6A   .��6d   Отмена6l   5#      5$      