   M S B A M L   `   `   `  ����L  HMenuTreeComponent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MenuTreeComponentMenuTreeComponent  5   	   1    +MenuTreeComponent.PreviewForms.PreviewForm2   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   J FMahApps.Metro, Version=1.6.0.184, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	   +localclr-namespace:MenuTreeComponent  5   	   -   5          � Title$J  DПредварительный просмотр упражнения��5	   	   $	��600��65   $	��600��6B    � 
ResizeMode$ NoResize=�6N    � WindowStartupLocation$ CenterOwner=�6d    � 	Resources 5
         TextResolverTemplate  ImageResolverTemplate)   #MenuTreeComponent.ResolverPresenter  ResolverPresenter��%�   &	        &	 B     &	 �     �� 5   
   .R�5      �� ��6   �� *	Content+5      �� 5   
   .R�5      �� $��40��6.   $��40��69   ��6   �� *Origin+69   5        5   
   6>   5      .��5      � ��5   
   �� 5       �� Color$
 #EEE��6   6-    � RowDefinitions 5   
   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��2* �6   6*   �� 5      $��1* �6   6*   �� 5      $��2* �6   6*   �� 5      $��1* �6   6*    � ColumnDefinitions 5    
   �� 5!      $��1* �6   6,   �� 5"      $��2* �6   6,   �� 5#      $��1* �6   6,   �� 5$      $��1* �6   6,   �� 5%      $��1* �6   6,   .+�5'   
   �� -   5         ��Name$ generalQuestionTxt��5'      $��0��60   $��1��6=   $��3��6M   $��Center=�6a   $��Center=�6~   6�   &    MenuTreeComponent.MediaPresenter  5(   
   -   5          Name$ media��5(      
���   �$��5q�6A   $��1��6L   $��3��6Y   $��1��6j   $��3��6z   	   IsSearchEnabled	 .  6�   �� 5)   
   -   5        
 ��Name$
 	normalBtn��5)   B   $��4��6   $��0��6   $��2��6.   $��5q�6U   {�.  .��6�   
Норма6�   �� 5*   
   -   5        $
 
problemBtn��5*   B   $��4��6   $��2��6   $��3��6.   $��5q�6V   {�.  .��6�   Нарушение6�   �� 5+   
   -   5         ��Name$ questionsListBox��5+      $��5��6,   $��0��69   $��2��6I   $��2��6Z   $��5q�6n   ��5,      �� 5-      .R�5.      �� $��16(�66   ��6    �� *Name+66   5/      51      �� 52   
   -   5        $ resolversListBox��52      $��5��6,   $��2��69   $��2��6I   $��3��6Z   $��5q�6n   #��[ 53      $��Disabled=�54      6J   55      56      