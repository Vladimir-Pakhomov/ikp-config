   M S B A M L   `   `   `  ���� L  HMenuTreeComponent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MenuTreeComponentMenuTreeComponent  .    (MenuTreeComponent.VideoVerdictVisualForm   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     J FMahApps.Metro, Version=1.6.0.184, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  +localclr-namespace:MenuTreeComponent    � Title$3  -Формирование заключения�� � WindowState$ 	Maximized=� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterOwner=�.��� ����  �� Color$
 #EEE�� � RowDefinitions �� $��1* ��� $��1* ��� $��5* ��� $��1* � � ColumnDefinitions �� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* �.+�R� -    R�Name$ verdictTreeView��$��1��$��0��$��3��$��6��$��5q����� 	 �� ItemsSource	 �� 
 �� Path$
 
ChildNodes�.R��� -   .����  �� Orientation$ 
Horizontal=�.+��� $��20��$��20������  �� RelativeSource ��  �� AncestorType$ ButtonL�$
 
Foreground� J� OpacityMask !�  j� Stretch$
 Fill=� !� Visual �� *Icon+�� $��4 0 0 0q�$��Center=�$��18(����� *Name+����  �� 
TargetType" Q�.���  �� Property �@Q�
IsExpanded �� Value . �� -    ��Name$ verdictAddBtn��$��0��$��0��$��5q�.���� $ 
Horizontal=�.+��� $��10��$��10������  �� $ ButtonL�$
 
Foreground� !� $
 Fill=�   
appbar_add# [  �� $��5 0 0 0q�$��Center=�$��Добавить���� -   $ verdictEditBtn��$��0��$��1��$��5q�{�.  .���� $ 
Horizontal=�.+��� $��10��$��10������  �� $ ButtonL�$
 
Foreground� !� $
 Fill=�  appbar_edit# [ �� $��5 0 0 0q�$��Center=�$��Изменить���� -   $ verdictRemoveBtn��$��0��$��2��$��5q�{�.  .���� $ 
Horizontal=�.+��� $��10��$��10������  �� $ ButtonL�$
 
Foreground� !� $
 Fill=�  appbar_delete# [ �� $��5 0 0 0q�$��Center=�$��Удалить���� -   $ okBtn��$��0��$��4��$��5q�.��ОК�� -   $ 	cancelBtn��$��0��$��5��$��5q�.��Отмена