   M S B A M L   `   `   `  ���� L  HMenuTreeComponent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MenuTreeComponentMenuTreeComponent  1    +MenuTreeComponent.PreviewForms.PreviewForm3   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     J FMahApps.Metro, Version=1.6.0.184, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  +localclr-namespace:MenuTreeComponent  -     � Title$J  DПредварительный просмотр упражнения�� � WindowState$ 	Maximized=� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterOwner=� � 	Resources    TreeViewItemFocusVisual �� Property �� Value �� StrokeDashArray	 J� Opacity
 �� 
TargetType �� Path �� RelativeSource �� AncestorType �� 
TargetType � ColumnDefinitions � RowDefinitions �� Padding ��Name ��Name �� Triggers P� Property P� Value �� 
TargetName ]� 
Conditions �� Property �� Value  TextResolverTemplate  ImageResolverTemplate)   #MenuTreeComponent.ResolverPresenter  ResolverPresenter��%�  &	        'Q� [     7   &	 h    &	 �    &	 �    �� .���  � �� �� .R��� ._��� $��0q�$��5��
���   �$	 1 2R�$	 0Q��� "
 Q�.���  � ��
 ���� ��  � �� �� $  HorizontalContentAlignment� �� " ����  � �� �� $ VerticalContentAlignment� �� " ����  � ��$ 1,0,0,0q���  � ��# � ����  �@�FocusVisualStyle8   ��  � �� �� " Q�.R��  �� $��10 ��� $
��Auto ��� $��* � �� $
��Auto ��� .+��� $��Bd��$��1��#��z��#��z��#��z��# z��._��� $ PART_Header��$��Header��#��z���� $ 	ItemsHost��$��1��$��1��$��2�� P�  �@Q�
IsExpanded .  . ��� $ 	ItemsHost�� � y�$ 	Collapsed=�]�  ��  � �� .  ��  � ��$
 Auto��./��� $ PART_Header�� � ��$ 75��]�  ��  � �� .  ��  � ��$
 Auto��./��� $ PART_Header�� � ��$ 19��P�  �@Q�
IsSelected . . ��� $ Bd��# � �� � ���� # � �� � ��]�  ��  �@Q�
IsSelected . ��  �@Q�IsSelectionActive .  ./��� $ Bd��# � �� � ���� # � �� � ��P�  � {� .  . ��� # � �� � ���� .R��� ���� *	Content+�� .R��� $��40��$��40������ *Origin+  .��� ����  �� Color$
 #EEE�� �� $��1* ��� $��1* ��� $��1* ��� $��2* ��� $��1* ��� $��2* ��� $��1* � �� $��3* ��� $��1* ��� $��1* ��� $��1* �.+��� -    ��Name$ generalQuestionTxt��$��0��$��0��$��Center=�$��Center=��� -   $ correctnessTxt��$��0��$��1��
���  ��$
��Bold"�$��Center=�$��Center=��� -   $ rationalityTxt��$��0��$��2��
��� � �$
��Bold"�$��Center=�$��Center=�&    MenuTreeComponent.MediaPresenter  -     Name$ media��$��1��
���   �$��5q�$��0��$��4��   IsSearchEnabled .  R� -    R�Name$ verdictTree��$��1��$��1��$��5q�$��4��$��3������   �� ItemsSource  �� $ 
ChildNodes�.R��� -   ���� *Bg+.���� ! �� Orientation$! 
Horizontal=�.+��� $��4 0 0 0q�$��Center=�$
��Left=�$��12(����� *Name+�� -   " ��Name$" questionsListBox��$��5��$��0��$��5q�$��2������ .R��� $��16(����� *Name+�� -	   $" resolversListBox��$��5��$��1��$��2��$��3��$��5q�#��[ $��Disabled=�