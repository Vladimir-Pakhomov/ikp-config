   M S B A M L   `   `   `  ���� L  HMenuTreeComponent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MenuTreeComponentMenuTreeComponent  &     MenuTreeComponent.MediaPresenter   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:MenuTreeComponent     J FMahApps.Metro, Version=1.6.0.184, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  .���   � RowDefinitions  �� $��8* ��� $��1* ��� $��1* � � ColumnDefinitions �� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* �.+��� $��0��$��0��$��9��
���   �.��r� -    r�Name$ mediaElement�� r� LoadedBehavior$ Manual=�)  #MahApps.Metro.Controls.ProgressRing  -     Name$ loader��$��0��$��0��$��9��$y�Hidden=��� $��1��$��0��$��2��$��9��
������ ����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ Black��� $ 	#FFA86E6E�� � Offset$ 1Q��� -   	 ��Name$	 	uploadBtn��$��1��$��4��   MetroCircleButtonStyle#���   
���   �.���� 
 �� Orientation$
 
Horizontal=�.+��� $��10��$��10������  �� RelativeSource ��  �� AncestorType$ ButtonL� �� Path$ 
Foreground� J� OpacityMask !�  j� Stretch$
 Fill=�  appbar_upload !� Visual# [ �� -   $	 playBtn��$��2��$��0��#���   
���   �.���� $
 
Horizontal=�.+��� $��10��$��10������  �� $ ButtonL�$ 
Foreground� !� $
 Fill=�  appbar_control_play# [ �� -   $	 pauseBtn��$��2��$��1��#���   
���   �.���� $
 
Horizontal=�.+��� $��10��$��10������  �� $ ButtonL�$ 
Foreground� !� $
 Fill=�  appbar_control_pause# [ �� -   $	 stopBtn��$��2��$��2��#���   
���   �.���� $
 
Horizontal=�.+��� $��10��$��10������  �� $ ButtonL�$ 
Foreground� !� $
 Fill=�  appbar_control_stop# [ -  'MahApps.Metro.Controls.MetroProgressBar  -     Name$ progressBar�� � Minimum$ 0Q� � Value$ 0Q�$��2��$��3��$��3���� -   $	 muteBtn��$��2��$��6��#���   
���   �.���� $
 
Horizontal=�.+��� $��10��$��10������  �� $ ButtonL�$ 
Foreground� !� $
 Fill=�  appbar_sound_mute# [ �� -	   $	 volumeDecBtn��$��2��$��7��#���   
���   �.���� $
 
Horizontal=�.+��� $��10��$��10������  �� $ ButtonL�$ 
Foreground� !� $
 Fill=�  appbar_sound_0# [ �� -
   $	 soundIncBtn��$��2��$��8��#���   
���   �.���� $
 
Horizontal=�.+��� $��10��$��10������  �� $ ButtonL�$ 
Foreground� !� $
 Fill=�  appbar_sound_3# [ 