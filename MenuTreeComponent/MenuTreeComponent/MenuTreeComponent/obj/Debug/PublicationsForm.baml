   M S B A M L   `   `   `  ����L  HMenuTreeComponent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MenuTreeComponentMenuTreeComponent  5   	   (    "MenuTreeComponent.PublicationsForm   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   J FMahApps.Metro, Version=1.6.0.184, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	   +localclr-namespace:MenuTreeComponent  5   	     � Title$  Публикации��5	   	   $	��600��6   $	��900��6)    � 
ResizeMode$ NoResize=�65    � WindowState$ 	Maximized=�6K    � WindowStyle$
 None=�6c    � 	Resources 5
         pubTemplate ��Name �� RelativeSource �� AncestorType �� Path	 J� OpacityMask
 j� Stretch , (appbar_transform_rotate_counterclockwise !� Visual  cmdTemplate  statusTemplate��%  &	        7  &	 %    7  &	 F    �� 5   
   .R�5      �� $ repeatPublication��6   -   5        {�5   0   �� *
CanRestart+.��5      �� $��10��6   $��10��5      ��5      ��  �� $ ButtonL�$ 
Foreground�	 5      !� 5      $

 Fill=�6&   8   65   5      5      5      �� 5   
   .R�5      �� $ repeatCommand��6   -   5        {�5   ,   �� *
CanRestart+.��5      �� $��10��6   $��10��5      ��5      ��  �� $ ButtonL�$ 
Foreground�	 5      !� 5      $

 Fill=�6&   8   65   5      5      5       �� 5!   
   .R�5"      �� $��10��6   $��10��6#   ��5#      !� 5$      $

 Fill=�6"    61   �� *
StatusIcon+5&      5'      5(      .��5)      � ��5*   
   �� 5+       �� Color$
 #EEE��6   6-    � RowDefinitions 5-   
   �� 5.      $��1* �6   6*   �� 5/      $��1* �6   6*   �� 50      $��1* �6   6*   �� 51      $��5* �6   6*   �� 52      $��1* �6   6*    � ColumnDefinitions 54   
   �� 55      $��3* �6   6,   �� 56      $��1* �6   6,   �� 57      $��2* �6   6,   .+�59   
   �� $��0��6   $��0��6!   $��5q�61   $��Публикации��6<   $��Center=�6N   6k   �� 5:   
   $��0��6   $��1��6!   $��2��61   $��5q�6E   $��Список команд��6P   $��Center=�6e   6�   �� 5;   
   -   5         ��Name$ publicationsListView��5;      $��1��61   $��4��6>   $��0��6O   $��5q�6_   ��5<      �� *Publications+ �� View 5=      �� 5>      .P�5?      ��  �� DisplayMemberBinding 6%   �� *ApiKey+.��6M   
Ключ6S   �� 5@       6%   �� *Name+.��6K   Название6U   �� 5A       �� CellTemplate# [ 6%   .��6T   Статус6\   �� 5B      # [  6%   .��6Q   Повтор6Y   5C      5E      �� 5F   
   -   5        $ commandsListView��5F      $��1��6-   $��4��6:   $��1��6K   $��2��6[   $��5q�6o    5G      �� 5H      .P�5I      ��  6%   �� *
FileName+.��6O   
Файл6U   �� 5J       6%   �� *Start+.��6L   Начало6T   �� 5K       6%   �� *End+.��6J   Завершение6V   �� 5L      # [ 6%   .��6T   Статус6\   �� 5M      # [ 6%   .��6Q   Повтор6Y   5N      5P      5Q      5R      