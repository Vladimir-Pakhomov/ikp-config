   M S B A M L   `   `   `  ���� c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  L HMenuTreeComponent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MenuTreeComponentMenuTreeComponent @ <Tools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null@,clr-namespace:ListBoxBehavior;assembly=ToolsListBoxBehavior !   MenuTreeComponent.TopicForm   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:MenuTreeComponent     HlistBoxBehavior,clr-namespace:ListBoxBehavior;assembly=Tools     J FMahApps.Metro, Version=1.6.0.184, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls    � Title$3  -Управление упражнениями�� � WindowState$ 	Maximized=� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterOwner=�.���  � RowDefinitions �� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��5* ��� $��1* ��� $��5* � � ColumnDefinitions �� $��2* ��� $��1* ��� $��1* ��� $��2* ��� $��1* ��� $��1* ��� $��1* ��� $��2* ��� $��1* ��� $��1* ��� $��1* �.+��� $��0��$��0�� �� Orientation$ 
Horizontal=�$��5q�.+��� $��20��$��20��$��5q���!�    appbar_book !� Visual# [  �� $��Упражнения��$��4 0 0 0q�$��14(�$��Segoe UI)�$��Center=�$��Center=��� -   	 ��Name$	 topicsSaveBtn��$��0��$��1��$��0 5 5 0q�.���� $ Vertical=�.+��� $��10��$��10������ 
 �� RelativeSource
 ��  �� AncestorType$ ButtonL� �� Path$ 
Foreground� J� OpacityMask !�  j� Stretch$
 Fill=�  appbar_save# [ �� $��0q�$��Center=�$��9(�$��Сохранить���� -   $	 topicAddBtn��$��0��$��2��$��0 5 5 0q�.���� $ Vertical=�.+��� $��10��$��10������ 
 �� $ ButtonL�$ 
Foreground� !� $
 Fill=�  
appbar_add# [ �� $��0q�$��Center=�$��9(�$��Добавить���� -    ��Name$ topicsListBox��$��1��$��5��$��0��$��3��$��5q�$��Disabled=����� .R��  �� $��* � �� $��9* ��� $��1* �.+��� $��0��$��0��$��16(�$��WordEllipsis=�$
��Wrap=����� *Name+�� $	 topicRemoveBtn��-   $��0��$��1��.���� $��10��$��10��$��5q���!�   appbar_close# [ �� $��0��$��3��$��1��$ 
Horizontal=�$��5q�.+��� $��20��$��20��$��5q���!�   appbar_app_favorite# [ �� $��Название��$��4 0 0 0q�$��14(�$��Segoe UI)�$��Center=�$��Center=��� -    ��Name$ topicNameTextBox��$��0��$��4��$��5��{�.  $��18(�$��Center=����� *Name+�� -   $	 editTopicNameBtn��$��0��$��9��$��2��$��0 5 5 5q�{�.  .���� $ 
Horizontal=�.+��� $��10��$��10������ 
 �� $ ButtonL�$ 
Foreground� !� $
 Fill=�  appbar_edit# [ �� $��5 0 0 0q�$��Center=�$��Изменить���� $��1��$��3��$��1��$ 
Horizontal=�$��5q�.+��� $��20��$��20��$��5q���!�   appbar_star# [ �� $!��Главный вопрос��$��4 0 0 0q�$��14(�$��Segoe UI)�$��Center=�$��Center=��� -   $ topicMainQuestionTextBox��$��1��$��4��$��5��{�.  $��18(�$��Center=����� *GeneralQuestion+�� -   $	 editTopicMainQuestionBtn��$��1��$��9��$��2��$��0 5 5 5q�{�.  .���� $ 
Horizontal=�.+��� $��10��$��10������ 
 �� $ ButtonL�$ 
Foreground� !� $
 Fill=�# [ �� $��5 0 0 0q�$��Center=�$��Изменить���� $��2��$��3��$��1��$ 
Horizontal=�$��5q�.+��� $��20��$��20��$��5q���!�   appbar_medical_pulse# [ �� $+��%Привязка заключения��$��4 0 0 0q�$��14(�$��Segoe UI)�$��Center=�$��Center=��� -	   $	 conclusionAddBtn��$��2��$��8��{�.  $��0 0 0 5q�.���� $ Vertical=�.+��� $��10��$��10������ 
 �� $ ButtonL�$ 
Foreground� !� $
 Fill=�# [ �� $��0q�$��Center=�$��Добавить���� -
   $	 conclusionEditBtn��$��2��$��9��$��0 0 0 5q�{�.  .���� $ Vertical=�.+��� $��10��$��10������ 
 �� $ ButtonL�$ 
Foreground� !� $
 Fill=�# [ �� $��0q�$��Center=�$��Изменить���� -   $	 conclusionRemoveBtn��$��2��$��10��$��0 0 5 5q�{�.  .���� $ Vertical=�.+��� $��10��$��10������ 
 �� $ ButtonL�$ 
Foreground� !� $
 Fill=�  appbar_delete# [ �� $��0q�$��Center=�$��Удалить���� $��3��$��3��$��2��$��4�� �� CornerRadius$ 5��$��3q�����  �� Color$ Black���� $��3��$��3��$ 
Horizontal=�$��5q�.+��� $��20��$��20��$��5q���!�  	 appbar_question# [	 �� $��Вопросы��$��4 0 0 0q�$��14(�$��Segoe UI)�$��Center=�$��Center=��� -   $	 questionAddBtn��$��3��$��4��$��0 5 0 0q�{�.  .���� $ Vertical=�.+��� $��10��$��10������ 
 �� $ ButtonL�$ 
Foreground� !� $
 Fill=�# [ �� $��0q�$��Center=�$��Добавить���� -   $	 questionEditBtn��$��3��$��5��$��0 5 0 0q�{�.  .���� $ Vertical=�.+��� $��10��$��10������ 
 �� $ ButtonL�$ 
Foreground� !� $
 Fill=�# [ �� $��0q�$��Center=�$��Изменить���� -   $	 questionRemoveBtn��$��3��$��6��$��0 5 5 0q�{�.  .���� $ Vertical=�.+��� $��10��$��10������ 
 �� $ ButtonL�$ 
Foreground� !� $
 Fill=�# [ �� $��0q�$��Center=�$��Удалить���� -   $ questionsListBox��$��4��$��3��$��5q�$��4��%  ListBoxBehavior.ListBoxBehavior   
AutoScroll . $��Disabled=����� .R��� $��16(�$
��Wrap=����� *Name+�� $��3��$��7��$��2��$��4��
���   �$��3q�$ 5���� $��3��$��7��$ 
Horizontal=�$��5q�.+��� $��20��$��20��$��5q���!�  
 appbar_book_list# [
 �� $��Материалы��$��4 0 0 0q�$��14(�$��Segoe UI)�$��Center=�$��Center=��� -   $	 resolverAddBtn��$��3��$��8��{�.  $��0 5 0 0q�.   (System.Windows.Interactivity.Interaction   	Behaviors .  (MenuTreeComponent.DropDownButtonBehavior   � ContextMenu �� $��Right=�.@�m� -    m�Name$ resolverTextAddBtn��$��
Текст��m� -   $ resolverImageAddBtn��$��Картинка��.���� $ Vertical=�.+��� $��10��$��10������ 
 �� $ ButtonL�$ 
Foreground� !� $
 Fill=�# [ �� $��0q�$��Center=�$��Добавить���� -   $	 resolverEditBtn��$��3��$��9��$��0 5 0 0q�{�.  .���� $ Vertical=�.+��� $��10��$��10������ 
 �� $ ButtonL�$ 
Foreground� !� $
 Fill=�# [ �� $��0q�$��Center=�$��Изменить���� -   $	 resolverRemoveBtn��$��3��$��10��$��0 5 5 0q�{�.  .���� $ Vertical=�.+��� $��10��$��10������ 
 �� $ ButtonL�$ 
Foreground� !� $
 Fill=�# [ �� $��0q�$��Center=�$��Удалить���� -   $ resolversListBox��$��4��$��7��$��5q�$��4�� . $��Disabled=����� .R��� $��16(����� *Name+�� $��5��$��3��$��2��$��4��
���   �$��3q�$ 5���� $��5��$��3��$ 
Horizontal=�$��5q�.+��� $��20��$��20��$��5q���!�   appbar_video_gallery# [ �� $��
Медиа��$��4 0 0 0q�$��14(�$��Segoe UI)�$��Center=�$��Center=��� -   $	 visualAddBtn��$��5��$��4��{�.  $��0 5 0 0q�    �� $��Right=�.@�m� -   $ visualVideoPairAddBtn��$��Видео-пара��m� -   $ visualSingleVideoAddBtn��$#��Одиночное видео��.���� $ Vertical=�.+��� $��10��$��10������ 
 �� $ ButtonL�$ 
Foreground� !� $
 Fill=�# [ �� $��0q�$��Center=�$��Добавить���� -   $	 visualEditBtn��$��5��$��5��$��0 5 0 0q�{�.  .���� $ Vertical=�.+��� $��10��$��10������ 
 �� $ ButtonL�$ 
Foreground� !� $
 Fill=�# [ �� $��0q�$��Center=�$��Изменить���� -   $	 visualRemoveBtn��$��5��$��6��$��0 5 5 0q�{�.  .���� $ Vertical=�.+��� $��10��$��10������ 
 �� $ ButtonL�$ 
Foreground� !� $
 Fill=�# [ �� $��0q�$��Center=�$��Удалить���� $��5��$��7��$��2��$��4��
���   �$��3q�$ 5���� $��5��$��7��$ 
Horizontal=�$��5q�.+��� $��20��$��20��$��5q���!�   appbar_information_circle# [ �� $��Инфо��$��4 0 0 0q�$��14(�$��Segoe UI)�$��Center=�$��Center=��� -   $ 	mediaInfo��$��6��$��3��$��4��$��Center=�$��Center=�$
��Wrap=� �� TextAlignment$ Center=����� *VisualContentTypeMessage+�� -   $	 
previewBtn��$��5��$��8��$��3��$��5q�{�.  .���� $ 
Horizontal=�.+��� $��15��$��15������ 
 �� $ ButtonL�$ 
Foreground� !� $
 Fill=�  
appbar_eye# [ �� $��4 0 0 0q�$��Center=�$5��/ПРЕДВАРИТЕЛЬНЫЙ ПРОСМОТР��