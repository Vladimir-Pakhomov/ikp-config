   M S B A M L   `   `   `  ����L  HMenuTreeComponent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MenuTreeComponentMenuTreeComponent  5   	   +    %MenuTreeComponent.VideoPairVisualForm   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   J FMahApps.Metro, Version=1.6.0.184, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	   +localclr-namespace:MenuTreeComponent  5   	     � Title$7  1Видео-пара: редактирование��5	   	   $	��400��6,   $	��600��69    � 
ResizeMode$ NoResize=�6E    � WindowStartupLocation$ CenterOwner=�6[   .��5
      � ��5   
   �� 5       �� Color$
 #EEE��6   6-    � RowDefinitions 5   
   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��5* �6   6*   �� 5      $��1* �6   6*    � ColumnDefinitions 5   
   �� 5      $��3* �6   6,   �� 5      $��1* �6   6,   �� 5      $��2* �6   6,   .+�5   
   �� $��0��6   $��0��6!   $��Center=�61   $��5q�6L   !Правильное видео6i   �� 5   
   $��0��6   $��1��6!   $��2��61   $��Center=�6E   $��5q�6`   Ошибочное видео6|   &    MenuTreeComponent.MediaPresenter  5   
   -   5          Name$ correctSrcMediaElement��5      
���   �$��1��6R   $��0��6_   $��3��6o   $��1��6�   $��5q�6�   6�     5   
   -   5        $ incorrectSrcMediaElement��5      
���   �$��1��6T   $��1��6a   $��3��6q   $��3��6�   $��5q�6�   6�   �� 5   
   -   5         ��Name$ okBtn��5      $��4��6    $��1��6-   $��5q�6=   .��6\   ОК6`   �� 5   
   -   5        $ 	cancelBtn��5      $��4��6$   $��2��61   $��5q�6A   .��6d   Отмена6l   5       5!      