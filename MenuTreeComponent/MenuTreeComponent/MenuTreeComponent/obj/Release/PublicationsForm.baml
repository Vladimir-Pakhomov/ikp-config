   M S B A M L   `   `   `  ���� L  HMenuTreeComponent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MenuTreeComponentMenuTreeComponent  (    "MenuTreeComponent.PublicationsForm   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     J FMahApps.Metro, Version=1.6.0.184, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  +localclr-namespace:MenuTreeComponent    � Title$  Публикации��$	��600��$	��900�� � 
ResizeMode$ NoResize=� � WindowState$ 	Maximized=� � WindowStyle$
 None=� � 	Resources    pubTemplate ��Name �� RelativeSource �� AncestorType �� Path	 J� OpacityMask
 j� Stretch , (appbar_transform_rotate_counterclockwise !� Visual  cmdTemplate  statusTemplate��%�  &	        7  &	 �     7  &	 F    �� .R��� $ repeatPublication��-   {��� *
CanRestart+.���� $��10��$��10������  �� $ ButtonL�$ 
Foreground�	 !� $

 Fill=�8   �� .R��� $ repeatCommand��-   {��� *
CanRestart+.���� $��10��$��10������  �� $ ButtonL�$ 
Foreground�	 !� $

 Fill=�8   �� .R��� $��10��$��10����!� $

 Fill=� �� *
StatusIcon+.��� ����  �� Color$
 #EEE�� � RowDefinitions �� $��1* ��� $��1* ��� $��1* ��� $��5* ��� $��1* � � ColumnDefinitions �� $��3* ��� $��1* ��� $��2* �.+��� $��0��$��0��$��5q�$��Публикации��$��Center=��� $��0��$��1��$��2��$��5q�$��Список команд��$��Center=��� -    ��Name$ publicationsListView��$��1��$��4��$��0��$��5q����� *Publications+ �� View �� .P���  �� DisplayMemberBinding �� *ApiKey+.��
Ключ��  �� *Name+.��Название��  �� CellTemplate# [ .��Статус�� # [  .��Повтор�� -   $ commandsListView��$��1��$��4��$��1��$��2��$��5q� �� .P���  �� *
FileName+.��
Файл��  �� *Start+.��Начало��  �� *End+.��Завершение�� # [ .��Статус�� # [ .��Повтор